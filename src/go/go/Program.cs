using Console = System.Console;

namespace go
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;

    using static Console;
    using static System.IO.File;
    using static System.IO.Path;
    using static System.IO.Directory;

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
    ///         Show a list of repos, each preceded by a number.
    ///     λ go n
    ///         Go to the nth repo.
    ///     λ go -
    ///         Go to the last thing you went from.
    ///     λ go -current || -c || -root
    ///         Go to root of current repo.
    ///     λ go -clear || -k
    ///         Clear all .current files in repos.
    ///     λ go -unity || -u
    ///         Change to Assets folder of first found Unity3d project.
    /// </code>
    /// </summary>
    internal class Program
    {
        private readonly string _rootLetter;
        private string DosDrive => $@"{_rootLetter}:\";
        private string BashDrive => $@"/{_rootLetter}/";
        private string ReposRoot => $@"{DosDrive}\repos\";
        private string PackagesRoot => $@"{DosDrive}\Packages\";
        private string Previous => $@"{DosDrive}\repos\.prev";
        private readonly List<Repo> _repos = new List<Repo>();

        private static int Main(string[] args)
        {
            try
            {
                return new Program().Run(args);
            }
            catch (Exception e)
            {
                WriteLine($"{ColorFormat.LightRed}{e.Message}");
            }

            return -1;
        }

        private Program()
        {
            _rootLetter = Environment.GetEnvironmentVariable("WORK_LETTER");

            if (string.IsNullOrEmpty(_rootLetter))
            {
                Error.WriteLine("No WORK_LETTER found.");
                Environment.Exit(1);
            }
        }

        private int Run(IReadOnlyList<string> args)
        {
            GetRepos();

            if (args.Count == 0)
                return ShowRepos();

            switch (args[0])
            {
                case "-":
                    return GotoPrev();
                case "-c":
                case "-current":
                case "-root":
                    WriteLine($"/{_rootLetter}" + GetCurrentRepo().Substring(2).Replace("\\", "/"));
                    return 0;
                case "-k":
                case "-clear":
                    return ClearCurrents();
                case "-u":
                case "-unity":
                    return FindUnityProject();
            }

            return GotoRepo(args[0]);
        }

        private int FindUnityProject()
        {
            var proj = EnumerateDirectories(GetCurrentRepo(), "Assets", SearchOption.AllDirectories)
                .FirstOrDefault(d => !d.Contains(".git"));
            if (proj != null)
                WriteLine($"/{_rootLetter}/{Sanitise(proj.Substring(3))}");

            return 0;
        }

        private static string Sanitise(string input)
            => input.Replace("\\", "/");

        private int GotoPrev()
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
                var current = Combine(repo, ".current");
                _repos.Add(new Repo
                {
                    Name = GetFileName(repo),
                    FullPath = Sanitise(repo),
                    CurrentPath = Sanitise(File.Exists(current) ? ReadAllText(current) : repo),
                    CurrentName = current
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
                var nameSub = repo.CurrentPath.Substring(0, nameIndex - 1);
                var parentIndex = nameSub.LastIndexOf("/", StringComparison.Ordinal);
                return repo.CurrentPath.Substring(parentIndex + 1);
            }

            var repos = _repos.Where(r => !r.FullPath.Contains("Packages")).ToList();
            var packages = _repos.Where(r => r.FullPath.Contains("Packages")).ToList();

            WriteLineFormat($"\n> Repos", new List<string> { ColorFormat.Blue, ColorFormat.Bold });
            var defaultFormat = new List<string> { ColorFormat.LightGrey };
            var curFormat = new List<string> { "\x1b[48;5;240m", ColorFormat.White, ColorFormat.Bold };
            int count = 0;
            foreach (var repo in repos)
            {
                var format = defaultFormat;
                if (Sanitise(GetCurrentDirectory().ToLower()).Contains(repo.FullPath.ToLower()))
                    format = curFormat;

                var pathFormat = new List<string>(format) { ColorFormat.Dim };
                WriteFormat(count < 10 ? $"{count: 0} {repo.Name}" : $"{count:00} {repo.Name}", format);
                WriteLineFormat($" @{Substring(repo).Replace("\\", "/").Replace("\n", "")}", pathFormat);
                ++count;
            }

            WriteLineFormat($"\n> Packages", new List<string> { ColorFormat.Blue, ColorFormat.Bold });
            foreach (var package in packages)
            {
                var format = defaultFormat;
                if (Sanitise(GetCurrentDirectory().ToLower()).Contains(package.FullPath.ToLower()))
                    format = curFormat;

                var pathFormat = new List<string>(format) { ColorFormat.Dim };
                WriteFormat(count < 10 ? $"{count: 0} {package.Name}" : $"{count:00} {package.Name}", format);
                WriteLineFormat($" @{Substring(package).Replace("\\", "/").Replace("\n", "")}", pathFormat);
                ++count;
            }

            return 0;
        }

        private int GotoRepo(string text)
        {
            if (int.TryParse(text, out var number))
                return GotoNumberedRepo(number);

            var matches = new List<int>();
            var n = 0;
            foreach (var repo in _repos.Select(r => r.Name))
            {
                if (repo.ToLower().StartsWith(text))
                    matches.Add(n);
                ++n;
            }

            switch (matches.Count)
            {
                case 0:
                    ShowRepos();
                    return -1;
                case 1:
                    return GotoNumberedRepo(matches[0]);
                default:
                    Error.WriteLine($"Multiple matches for '{text}':");
                    foreach (var m in matches)
                        Error.WriteLine($"\t{_repos[m].Name}");
                    return -1;
            }
        }

        private int GotoNumberedRepo(int number)
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
        private void LeaveThenEnter(string curRepo, string wd, Repo dest)
        {
            var leaveEnter = string.Empty;
            if (!string.IsNullOrEmpty(curRepo))
            {
                WriteAllText(Combine(curRepo, ".current"), wd);
                if (File.Exists($@"{curRepo}\.leave"))
                    leaveEnter += $"/{_rootLetter}/repos/{GetFileName(curRepo)}/.leave";
            }

            if (File.Exists($@"{_rootLetter}:\repos\{dest.Name}\.enter"))
            {
                if (!string.IsNullOrEmpty(leaveEnter))
                    leaveEnter += "\n";
                leaveEnter += $@"/{_rootLetter}/repos/{dest.Name}/.enter";
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

