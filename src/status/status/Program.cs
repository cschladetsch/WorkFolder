using System.Collections.Generic;
using System.Text;
using NGit.Diff;
using Tamir.SharpSsh.java.lang;

namespace status
{
    using System;
    using System.Linq;
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

            return GetRepos();
        }

        private int GetRepos()
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
            Write($"{dir}: ");
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

            WriteLine(outOfDate ? $"\x1b[2m\x1b[91mLocal has been modified.\x1b[0m" : $"\x1b[2mNo changes to local.\x1b[0m");
            if (outOfDate && _verbose)
            {
                Info($"Modified", mods);
                Info($"Added", adds);
                Info($"Removed", rem);
                Info($"Changed", changed);
                Info($"Missing", missing);
                Info($"Untracked", untracked);
            }
        }

        private static void Info(string title, ICollection<string> mods)
        {
            if (mods.Count == 0)
                return;

            var sb = new StringBuilder();
            sb.Append($"\t{title}:\n");
            foreach (var item in mods)
                sb.AppendLine($"\t\t{item}");

            Write(sb.ToString());
        }
    }
}

