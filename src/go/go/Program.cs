using static System.IO.File;

namespace go
{
    using System.IO;
    using System.Linq;
    using System.Collections.Generic;

    using static System.IO.Directory;
    using static System.IO.File;
    using static System.IO.Path;
    using static System.Console;

    internal class Repo
    {
        public string Name;
        public string CurrentPath;
        public string CurrentName;
    }

    /// <summary>
    /// The caller will change directory to the output if it exists.
    ///
    /// This requires /w/bin/functions as well.
    ///
    /// Usage:
    ///     λ go
    ///         show a list of repos, each preceeded by a number
    ///     λ go n
    ///         go to the nth repo.
    ///     λ go -
    ///         go to the last thing you went from.
    ///
    /// </summary>
    internal class Program
    {
        private const string ReposRoot = @"w:\repos\";
        private const string Previous = @"w:\repos\.prev";
        private readonly List<Repo> _repos = new List<Repo>();

        private static int Main(string[] args)
            => new Program().Run(args);

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
                    CurrentPath = File.Exists(combine) ? ReadAllText(combine) : repo,
                    CurrentName = combine
                });
            }
        }

        private int ShowRepos()
        {
            var n = 0;
            foreach (var repo in _repos)
                WriteLine($"{n++} {repo.Name} @{repo.CurrentPath.Substring(ReposRoot.Length)}");

            return 0;
        }

        private int GotoRepo(int number)
        {
            if (number < 0 || number >= _repos.Count)
                return 1;

            var dest = _repos[number];
            var curRepo = GetCurrentRepo();
            if (!string.IsNullOrEmpty(curRepo))
                WriteAllText(Combine(curRepo, ".current"), GetCurrentDirectory());

            WriteAllText(Previous, GetCurrentDirectory());
            WriteLine(dest.CurrentPath);
            return 0;
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

