using System.IO;
using System.Linq;
using NGit;
using NGit.Api;
using NGit.Storage.File;
using NGit.Util;
using Sharpen;
using Console = System.Console;

namespace status
{

    using System;
    using System.Collections.Generic;
    using static System.IO.Directory;
    using static System.IO.Path;
    using static Console;

    internal class Program
    {
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
            return GetRepos();
        }

        private int GetRepos()
        {
            var dirs = GetDirectories(GetCurrentDirectory());
            var repos = dirs.Where(d => Directory.Exists(Combine(d, ".git"))).ToList();

            foreach (var dir in dirs)
                if (repos.Contains(dir))
                    GetStatus(dir);

            return 0;
        }

        private void GetStatus(string dir)
        {
            Write($"{dir}: ");
            Git git = Git.Open(new FilePath(dir), FS.Detect(false));
            Repository repository = git.GetRepository();
            repository.ScanForRepoChanges();
            Status status = git.Status().Call();

            var modified = status.GetModified().Any();
            var added = status.GetAdded().Any();
            var removed = status.GetRemoved().Any();
            var changed = status.GetChanged().Any();
            var missing = status.GetMissing().Any();
            var untracked = status.GetUntracked().Any();

            var outOfDate = modified || added || removed || changed || missing || untracked;

            WriteLine(outOfDate ? $"\x1b[2m\x1b[91mLocal has been modified.\x1b[0m" : $"\x1b[2mNo changes to local.\x1b[0m");
        }
    }
}
