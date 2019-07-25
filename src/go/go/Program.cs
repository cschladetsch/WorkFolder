using System;

namespace go
{
    using System.IO;
    using System.Linq;
    using System.Collections.Generic;

    using static System.IO.Directory;
    using static System.IO.File;
    using static System.IO.Path;
    using static Console;

    internal class Repo
    {
        public string Name;
        public string FullPath;
        public string CurrentPath;
        public string CurrentName;
    }

    /// <summary>
    /// The caller will change directory to the output if it exists.
    ///
    /// stderror is what to execute before moving.
    ///
    /// stdout is where to move to.
    ///
    /// NOTE: This requires /w/bin/functions as well.
    ///
    /// Usage:
    /// <code>
    ///     λ go
    ///         show a list of repos, each preceeded by a number.
    ///     λ go n
    ///         go to the nth repo.
    ///     λ go -
    ///         go to the last thing you went from.
    /// </code>
    /// </summary>
    internal class Program
    {
        private const string ReposRoot = @"w:\repos\";
        private const string Previous = @"w:\repos\.prev";
        private readonly List<Repo> _repos = new List<Repo>();

        private static int Main(string[] args)
        {
            try
            {
                return new Program().Run(args);
            }
            catch (Exception e)
            {
                WriteLine(e);
            }

            return -1;
        }

        private int Run(IReadOnlyList<string> args)
        {
            GetRepos();

            if (args.Count == 0)
                return ShowRepos();

            if (args[0] == "-")
                return GotoPrev();

            return args[0] == "-c"
                ? ClearCurrents()
                : GotoRepo(int.Parse(args[0]));
        }

        private static int GotoPrev()
        {
            if (!File.Exists(Previous))
                return 1;

            WriteLine(ReadAllText(Previous));
            WriteAllText(Previous, GetCurrentDirectory());

            return 0;
        }

        private int ClearCurrents()
        {
            foreach (var repo in _repos)
                File.Delete(repo.CurrentName);

            return 0;
        }

        private void GetRepos()
        {
            foreach (var repo in GetDirectories(ReposRoot))
            {
                var combine = Combine(repo, ".current");
                _repos.Add(new Repo
                {
                    Name = GetFileName(repo),
                    FullPath = repo,
                    CurrentPath = File.Exists(combine) ? ReadAllText(combine) : repo,
                    CurrentName = combine
                });
            }
        }

        private int ShowRepos()
        {
            var n = 0;
            foreach (var repo in _repos)
            {
                //Write($"--- {repo.FullPath} / {GetCurrentDirectory()} ---");
                var format = GetCurrentDirectory().ToLower().Contains(repo.FullPath.ToLower()) ? "\x1b[92m\x1b[1m" : "\x1b[37m";
                WriteLine($"{format}{n++} {repo.Name} \x1b[2m@{repo.CurrentPath.Substring(ReposRoot.Length).Replace("\\", "/").Replace("\n", "")}\x1b[0m");
            }

            return 0;
        }

        private const string _gitBash = @"C:\Program Files\Git\git-bash.exe";

        private int GotoRepo(int number)
        {
            if (number < 0 || number >= _repos.Count)
                return 1;

            var dest = _repos[number];
            var curRepo = GetCurrentRepo();
            var wd = GetCurrentDirectory();

            LeaveEnter(curRepo, wd, dest);
            WriteAllText(Previous, wd);
            WriteLine(dest.CurrentPath);

            return 0;
        }

        private static void LeaveEnter(string curRepo, string wd, Repo dest)
        {
            var leaveEnter = string.Empty;
            if (!string.IsNullOrEmpty(curRepo))
            {
                WriteAllText(Combine(curRepo, ".current"), wd);
                var leave = $"/w/repos/{Path.GetFileName(curRepo)}/.leave";
                if (File.Exists($@"{curRepo}\.leave"))
                    leaveEnter += leave;
            }

            var enter = $@"/w/repos/{dest.Name}/.enter";
            if (File.Exists($@"w:\repos\{dest.Name}\.enter"))
            {
                if (!string.IsNullOrEmpty(leaveEnter))
                    leaveEnter += "\n";
                leaveEnter += enter;
            }

            Error.WriteLine(leaveEnter);
        }

        private static string GetCurrentRepo()
        {
            var folder = GetCurrentDirectory();
            while (true)
            {
                if (EnumerateDirectories(folder).Select(GetFileName).Contains(".git"))
                    return folder;

                var parent = GetParent(folder);
                if (parent == null)
                    return string.Empty;

                folder = parent.FullName;
            }
        }
    }
}

