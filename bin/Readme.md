# Work/Bin

This is part of the [WorkFolder](<https://github.com/cschladetsch/WorkFolder>) system, which in turn is based on `git-bash`.

Contains a set of:

* *Bash* scripts.
* *Python* scripts.
* *Windows* batch files.
* Cross-platform *.Net* binary executables.

These are available on all workstations.

## Contents

Brief description of each script/exe:
  * `functions` Global functions.
  * `aliases` Global aliases.
  * `status` Prints the current status of all git repositories in the current directory.
  * `clone-packages` Clones the current set of internal Unity packages into the current directory.
  * `diff-so-fancy` Makes nicer git diff output.
  * `duse` Show disk-space usage.
  * `get-non-meta` Gets a list of all files that do not have a .meta extension.
  * `list-android-packages` Lists all packages on connected Android device.
  * `rg` [ripgrep](<https://github.com/BurntSushi/ripgrep/blob/master/README.md>).
  * `jq` *Json* utility.
  * `git-lfs` Redirects to `git-lfs.exe` for Ubuntu shell.
  * `hi` Show issues in current repo.
  * `issue` Make a new issue.
  * `go` Fast way to switch between repos.
  * `mpr` Fast way to make a *Pull Request*.
  * `issue` Fast way to make an issue for current repo.
  * `r` Go to root of current repo.

## Todo

`hi #num` - browse to given issue.

## Verbosity

Change global environment variable `WORK_DIR_VERBOSE`:

 **= 0** Show no messages.

 **= 1** Show basic messages.

**>= 2** Be more talkative.

In general, the higher the number, the more detail you will get when starting a new shell. The default is no value, which is equivalent to 0 (zero).

## Useful links

  * Chocolatey - 
    * run the following command from an admin level command prompt.:
    `@"%SystemRoot%\System32\WindowsPowerShell\v1.0\powershell.exe" -NoProfile -InputFormat None -ExecutionPolicy Bypass -Command "iex ((New-Object System.Net.WebClient).DownloadString('https://chocolatey.org/install.ps1'))" && SET "PATH=%PATH%;%ALLUSERSPROFILE%\chocolatey\bin"`
