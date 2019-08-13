namespace status
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;
    using NGit.Api;
    using NGit.Util;
    using Sharpen;

    using static System.IO.Directory;
    using static System.IO.Path;
    using static System.Console;

    /// <summary>
    /// DOC
    /// </summary>
    internal class Program
    {
        private bool _verbose;

        private static int Main(string[] args)
        {
            try
            {
                return new Program().Run(args);
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e);
            }

            return -1;
        }

        private int Run(string[] args)
        {
            if (args.Length > 0 && args[0] == "-v")
                _verbose = true;

            return ShowRepos();
        }

        private int ShowRepos()
        {
            var dirs = GetDirectories(GetCurrentDirectory());
            var repos = dirs.Where(d => Exists(Combine(d, ".git"))).ToList();

            foreach (var dir in dirs)
                if (repos.Contains(dir))
                    GetStatus(dir);

            return 0;
        }

        private void GetStatus(string dir)
        {
            Write($"{dir.Substring(dir.LastIndexOf("\\", StringComparison.Ordinal) + 1)}: ");
            var git = Git.Open(new FilePath(dir), FS.Detect(false));
            var repository = git.GetRepository();
            repository.ScanForRepoChanges();
            var status = git.Status().Call();

            var mods = status.GetModified();
            var adds = status.GetAdded();
            var rem = status.GetRemoved();
            var changed = status.GetChanged();
            var untracked = status.GetUntracked();
            var missing = status.GetMissing();

            var outOfDate = mods.Any() || adds.Any() || rem.Any() || changed.Any()
                || missing.Any() || untracked.Any();

            WriteLine(outOfDate
                ? $"\x1b[2m\x1b[91mChanges.\x1b[0m"
                : $"\x1b[2mClean.\x1b[0m");

            if (outOfDate && _verbose)
            {
                Info(dir, "Modified", mods);
                Info(dir, "Added", adds);
                Info(dir, "Removed", rem);
                Info(dir, "Changed", changed);
                Info(dir, "Deleted", missing);
                Info(dir, "Untracked", untracked);
            }
        }

        private static void Info(string root, string title, ICollection<string> mods)
        {
            //if (mods.Count == 0)
            //    return;
            //var subs = new List<string>();
            //foreach (var sub in GetDirectories(root))
            //{
            //    var s = GetDirectories(sub, ".git", SearchOption.AllDirectories)
            //        .Select(d => new DirectoryInfo(d).Parent?.Name).ToArray();
            //    if (s.Length == 0)
            //        return;
            //    subs.AddRange(s);
            //    foreach (var p in s)
            //        WriteLine(p);
            //}

            var sb = new StringBuilder();
            sb.Append($"  {title}:\n");
            foreach (var item in mods)
            {
                // ignore submodules
                //if (EnumerateDirectories("/w/repos/" + item).Any(d => d == ".git"))
                //    continue;

                // TODO: HACK!!
                //if (item.Contains("Shared"))
                //    continue;
                sb.AppendLine($"    {item}");
            }

            Write(sb.ToString());
        }
    }
}

