# Liminal Working Folder
Contains common functionality used by all developers at [Liminal](www.liminalvr.com).

See [Installer](https://github.com/LiminalVR/WorkFolderInstaller) for a Gui for setup.

**All developers _must_ have [git-bash shell](https://gitforwindows.org/) installed on their workstation**.

This repo is intended to be at the root of their work folder. In many cases this will be at `~/work`, or more verbosely `/c/Users/user-name/work`. Note that it could also be at `e:\Projects`, (`/e/Projects` in git-bash syntax) or wherever. Specifically: *Never hard-code `~/work` into any script*. Rather, use `$WORK_DIR` and `$REPOS_DIR` for repositories.

Internal packages are always at `$WORK_DIR\Packages`.

Whenever `~/work` folder is referenced in the documentation or wiki, it is a synonym for this root work folder specified in `$WORK_DIR` environment variable.

*NOTE* Some hand-holding may be required for artists unfamiliar with using `bash`.

## Contents
* [bin/](bin) Contains often used [shell scripts](bin/Readme.md) and other tools
* [doc/](doc) Contains top-level project-agnostic [documentation](doc/Readme.md). TODO. For example, *GitCommands.md*
* _Packages/_ Contains all **Unity3d** Packages used across folders. Note that this is a folder that contains a collection of other git repos that are *not* sub-modules. By Placing them all here, then `ProjectName/ProjectName-Unity/Packages/manifest.json` can find packages by default by hard-wiring references. This is not ideal, but still practical.
* [repos/](repos) Contains all work repos. This can be a symbolic link to another folder or even another drive.
* [src/](src) Source for tools in `$WORK_DIR/bin`.

