# Working Folder ![Icon](/doc/icon.png)
Contains common functionality used by a collection of developers.

**All developers _must_ have [git-bash shell](https://gitforwindows.org/) installed on their workstation**.

All developers *must* have their `work` folder mapped to a logical drive, and designated by the system environment variable `WORK_DIR`. Typically this is `w:`, but it could be anything.

- This can be done by follow the steps laid out [here](doc/SubstSetup.md)

This repo is intended to be at the root of their work folder. In many cases this will be at `~/work`, or more verbosely `/c/Users/user-name/work`. Note that it could also be at `e:\Projects`, (`/e/Projects` in git-bash syntax) or wherever. Specifically: *Never hard-code `~/work` into any script*. Rather, use `$WORK_DIR` and `$REPOS_DIR` for repositories.

Internal packages are always at `$WORK_DIR/Packages`.

Whenever `~/work` folder is referenced in the documentation or wiki, it is a synonym for this root work folder specified in `$WORK_DIR` environment variable.

*NOTE* Some hand-holding may be required for artists unfamiliar with using `bash`.

## Contents
* [bin/](bin) Contains often used [shell scripts](bin/Readme.md) and other tools
* [doc/](doc) Contains top-level project-agnostic [documentation](doc/Readme.md). TODO. For example, *GitCommands.md*
* [Packages/](Packages) Contains all **Unity3d** Packages used across folders. Note that this is a folder that contains a collection of other git repos that are *not* sub-modules. By Placing them all here, then `ProjectName/ProjectName-Unity/Packages/manifest.json` can find packages by default by hard-wiring references. This is not ideal, but still practical.
* [repos/](repos) Contains all work repos. This can be a symbolic link to another folder or even another drive.
* [src/](src) Source for tools in `$WORK_DIR/bin`.

# Working Folder
Contains common functionality shared by a group of developers.

Internal Unity3d and other packages are always at `$WORK_DIR\Packages`.

Whenever `~/work` folder is referenced in the documentation or wiki, it is a synonym for this root work folder specified in `$WORK_DIR` environment variable.

*NOTE* Some hand-holding may be required for artists unfamiliar with using `bash`.

## Contents
* [bin/](bin) Contains often used [shell scripts](bin/Readme.md) and other tools
* [doc/](doc) Contains top-level project-agnostic [documentation](doc/Readme.md). TODO. For example, *GitCommands.md*
* [Packages/](Packages) Contains all **Unity3d** Packages used across folders, and may also include other commonly used third-party systems. Note that this is a folder that contains a collection of other git repos that are *not* sub-modules. By Placing them all here, then `ProjectName/ProjectName-Unity/Packages/manifest.json` can find packages by default by hard-wiring references.
* [repos/](repos) Contains all your various work repos. This can be a symbolic link to another folder or even another drive. Use the `go` command to list and move between repos.
* [src/](src) Source for tools in `$WORK_DIR/bin`.

## Todo
Clean.
