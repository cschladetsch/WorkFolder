using Console = System.Console;

namespace go
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
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
    ///         Show a list of repos, each preceeded by a number.
    ///     λ go n
    ///         Go to the nth repo.
    ///     λ go -
    ///         Go to the last thing you went from.
    ///     λ go -current || -c
    ///         Go to root of current repo.
    ///     λ go -clear || -k
    ///         Clear all .current files in repos.
    /// </code>
    /// </summary>
    internal class Program
    {
        private const string ReposRoot = @"w:\repos\";
        private const string PackagesRoot = @"w:\Packages\";
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
            GetFavourites();
            GetRepos();

            if (args.Count == 0)
                return ShowRepos();

            switch (args[0])
            {
                case "-":
                    return GotoPrev();
                case "-current":
                case "-c":
                    WriteLine("/w" + GetCurrentRepo().Substring(2).Replace("\\", "/"));
                    return 0;
                case "-clear":
                case "-k":
                    return ClearCurrents();
            }

            return GotoRepo(int.Parse(args[0]));
        }

        private static string Sanitise(string input)
            => input.Replace("\\", "/");

        private void GetFavourites()
        {
            if (!File.Exists($"{ReposRoot}/.favourites"))
                File.Create($"{ReposRoot}/.favourites");

            var favouritesText = File.ReadAllText($"{ReposRoot}/.favourites");
            string[] favourites = favouritesText.Split(',');
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
            foreach (var repo in GetDirectories(ReposRoot).Concat(GetDirectories(PackagesRoot)))
            {
                var combine = Combine(repo, ".current");
                _repos.Add(new Repo
                {
                    Name = GetFileName(repo),
                    FullPath = Sanitise(repo),
                    CurrentPath = Sanitise(File.Exists(combine) ? ReadAllText(combine) : repo),
                    CurrentName = combine
                });
            }
        }

        private static string Format(string text, IEnumerable<string> format)
        {
            var sb = new StringBuilder();
            foreach (var str in format)
                sb.Append(str);
            return $"{sb}{text}\x1b[0m";
        }

        private static void WriteFormat(string text, IEnumerable<string> format)
            => Write(Format(text, format));

        private static void WriteLineFormat(string text, IEnumerable<string> format)
            => WriteLine(Format(text, format));

        private int ShowRepos()
        {
            string Substring(Repo repo)
            {
                var nameIndex = repo.CurrentPath.IndexOf(repo.Name, StringComparison.Ordinal);
                var nameSub = repo.CurrentPath.Substring(0, nameIndex-1);
                var parentIndex = nameSub.LastIndexOf("/", StringComparison.Ordinal);
                return repo.CurrentPath.Substring(parentIndex+1);
            }

            for (var n = 0; n < _repos.Count; n++)
            {
                var repo = _repos[n];
                var current = GetCurrentDirectory().ToLower().Contains(repo.FullPath.ToLower());
                var mainFormat = new List<string>();
                if (current)
                {
                    mainFormat.Add(ColorFormat.LightGreen);
                    mainFormat.Add(ColorFormat.Bold);
                }
                else if (repo.FullPath.Contains("Packages"))
                    mainFormat.Add(ColorFormat.Cyan);
                else
                    mainFormat.Add(ColorFormat.LightGrey);

                var pathFormat = new List<string>(mainFormat) {ColorFormat.Dim};

                WriteFormat(n < 10 ? $"{n: 0} {repo.Name}" : $"{n:00} {repo.Name}", mainFormat);
                WriteLineFormat($" @{Substring(repo).Replace("\\", "/").Replace("\n", "")}", pathFormat);
            }

            return 0;
        }

        private int GotoRepo(int number)
        {
            if (number < 0 || number >= _repos.Count)
                return 1;

            var dest = _repos[number];
            var curRepo = GetCurrentRepo();
            var wd = GetCurrentDirectory();

            LeaveThenEnter(curRepo, wd, dest);
            WriteAllText(Previous, wd);
            WriteLine(dest.CurrentPath);

            return 0;
        }

        private static void LeaveThenEnter(string curRepo, string wd, Repo dest)
        {
            var leaveEnter = string.Empty;
            if (!string.IsNullOrEmpty(curRepo))
            {
                WriteAllText(Combine(curRepo, ".current"), wd);
                if (File.Exists($@"{curRepo}\.leave"))
                    leaveEnter += $"/w/repos/{GetFileName(curRepo)}/.leave";
            }

            if (File.Exists($@"w:\repos\{dest.Name}\.enter"))
            {
                if (!string.IsNullOrEmpty(leaveEnter))
                    leaveEnter += "\n";
                leaveEnter += $@"/w/repos/{dest.Name}/.enter";
            }

            if (!string.IsNullOrEmpty(leaveEnter))
                Error.WriteLine(leaveEnter);
        }

        private static string GetCurrentRepo()
        {
            var current = GetCurrentDirectory();
            while (true)
            {
                if (EnumerateDirectories(current).Select(GetFileName).Contains(".git"))
                    return current;

                var parent = GetParent(current);
                if (parent == null)
                    return string.Empty;

                current = parent.FullName;
            }
        }
    }
}

