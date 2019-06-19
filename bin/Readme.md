# Work/Bin

This is part of the [WorkFolder](<https://github.com/LiminalVR/WorkFolder>) system.

Contains a set of:

* Bash scripts.
* Windows batch files
* Binary executables.

That are to be available on all _Liminal_ workstations.

## Verbosity
Change global environment variable `WORK_DIR_VERBOSE`:
* 0. Show no messages.
* 1. Show basic messages.
* 2. Show more things.

In general, the higher the number, the more detail you will get when starting a new shell.

## Python
These scripts rely on Python. To setup:
1. Install [Python](https://www.python.org/ftp/python/3.7.3/python-3.7.3-amd64.exe) into `c:\Python`. Note that this is *not* the default install location.
1. Open a `git-bash` shell as **Administrator**.
1. Say `ln -s /c/Python/python.exe /usr/bin/python`

Then you can make python scripts starting with the shebang `#!/usr/bin/python`

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
  * `jq` Json utility.
  * `git-lfs` Redirects to `git-lfs.exe` for Ubuntu shell.

## Useful links
  * Chocolatey - 
    * run the following command from an admin level command prompt.:
    `@"%SystemRoot%\System32\WindowsPowerShell\v1.0\powershell.exe" -NoProfile -InputFormat None -ExecutionPolicy Bypass -Command "iex ((New-Object System.Net.WebClient).DownloadString('https://chocolatey.org/install.ps1'))" && SET "PATH=%PATH%;%ALLUSERSPROFILE%\chocolatey\bin"`
