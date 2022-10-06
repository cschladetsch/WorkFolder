# Working Folder ![Icon](/doc/icon.png)
Contains common functionality used by evelopers, to assist with dealing with many repositories. It also contains common scripts and aliases so that any dev can work confidently on another's machine.

This repo is intended to be at the root of their work folder. In many cases this will be at `~/work`, or more verbosely `/c/Users/user-name/work`. Note that it could also be at `e:\Projects`, (`/e/Projects` in git-bash syntax) or wherever. Specifically: *Never hard-code `~/work` into any script*. Rather, use `$WORK_FOLDER`.

Internal packages are always at `$WORK_FOLDER/Packages`.

## Contents
* [bin/](bin) Contains often used [shell scripts](bin/Readme.md) and other tools
* [doc/](doc) Contains top-level project-agnostic [documentation](doc/Readme.md). TODO. For example, *GitCommands.md*
* [Packages/](Packages) Contains all **Unity3d** Packages used across folders, and may also include other commonly used third-party systems. Note that this is a folder that contains a collection of other git repos that are *not* sub-modules. By Placing them all here, then `ProjectName/ProjectName-Unity/Packages/manifest.json` can find packages by default by hard-wiring references.
* [repos/](repos) Contains all your various work repos. This can be a symbolic link to another folder or even another drive. Use the `go` command to list and move between repos.
* [src/](src) Source for tools in `$WORK_FOLDER/bin`.
