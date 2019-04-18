# Work Scripts

Contains a set of 
* bash scripts
* Windows batch files, 
* Binary executables

That are to be available on all _Liminal_ workstations.

## Contents
Brief description of each script/exe:
  * `status`: Prints the current status of all git repositories in the current directory.
  * `clone-packages`: Clones the following Unity packages into the current directory:
    * Dekuple
    * CoLib
    * Flow
    * UniRx
    * NUnit
  * `diff-so-fancy`: makes nicer git diff output
  * `duse`: show disk-space usage
  * `get-non-meta`: Gets a list of all files that do not have a .meta extension.
  * `list-android-packages`: lists all packages on connected Android device.
  * `rg` [ripgrep](<https://github.com/BurntSushi/ripgrep/blob/master/README.md>)
  * `jq` json utility

## Useful links
  * Chocolatey - 
    * run the following command from an admin level command prompt.:
  
    `@"%SystemRoot%\System32\WindowsPowerShell\v1.0\powershell.exe" -NoProfile -InputFormat None -ExecutionPolicy Bypass -Command "iex ((New-Object System.Net.WebClient).DownloadString('https://chocolatey.org/install.ps1'))" && SET "PATH=%PATH%;%ALLUSERSPROFILE%\chocolatey\bin"`




