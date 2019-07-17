namespace go
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Collections.Generic;

    internal class Repo
    {
        public string Name;
        public string CurrentPath;
        public string CurrentName;
        //public string GitName;
    }

    internal class Program
    {
        private const string ReposRoot = @"w:\repos\";
        private readonly List<Repo> _repos = new List<Repo>();

        private static int Main(string[] args)
            => new Program().Run(args);

        private int Run(string[] args)
        {
            GetRepos();

            if (args.Length == 0)
                return ShowRepos();

            if (args[0] == "-c")
                return ClearCurrents();

            return GotoRepo(int.Parse(args[0]));
        }

        private int ClearCurrents()
        {
            foreach (var repo in _repos)
                File.Delete(repo.CurrentName);

            return 0;
        }

        private void GetRepos()
        {
            foreach (var fi in Directory.GetDirectories(ReposRoot))
            {
                var combine = Path.Combine(fi, ".current");
                _repos.Add(new Repo
                {
                    Name = Path.GetFileName(fi),
                    CurrentPath = File.Exists(combine) ? File.ReadAllText(combine) : fi,
                    CurrentName = combine
                });
            }
        }

        private int ShowRepos()
        {
            var n = 0;
            foreach (var repo in _repos)
                Console.WriteLine($"{n++} {repo.Name} @{repo.CurrentPath.Substring(ReposRoot.Length)}");

            return 0;
        }

        private int GotoRepo(int number)
        {
            if (number < 0 || number >= _repos.Count)
                return 1;

            var dest = _repos[number];
            var curRepo = GetCurrentRepo();
            if (!string.IsNullOrEmpty(curRepo))
                File.WriteAllText(Path.Combine(curRepo, ".current"), Directory.GetCurrentDirectory());

            Console.WriteLine(dest.CurrentPath);
            return 0;
        }

        private static string GetCurrentRepo()
        {
            string GetRepo(string folder)
            {
                while (true)
                {
                    var directories = Directory.EnumerateDirectories(folder).Select(Path.GetFileName).ToArray();
                    if (directories.Contains(".git"))
                        return folder;

                    var parent = Directory.GetParent(folder);
                    if (parent == null)
                        return string.Empty;

                    folder = parent.FullName;
                }
            }

            return GetRepo(Directory.GetCurrentDirectory());
        }
    }
}

