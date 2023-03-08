# Working Folder ![Icon](/doc/icon.png)

Contains common functionality used by developers, to assist with dealing with many repositories. It also contains common scripts and aliases so that any dev can work confidently on another's machine.

This repo is intended to be at the root of their work folder. In many cases this will be at `~/work`, or more verbosely `/c/Users/user-name/work`. Note that it could also be at `e:\Projects`, (`/e/Projects` in git-bash syntax) or wherever. Specifically: *Never hard-code `~/work` into any script*. Rather, use `$WORK_FOLDER`.

Internal packages are always at `$WORK_FOLDER/Packages`.

Currently supported platforms include:

* GitBash
* WSL
* Ubuntu
* Debian
* macOS
* Plan9

## Contents

* [bin/](bin) Often used [shell scripts](bin/Readme.md) and other tools
* [doc/](doc) Top-level project-agnostic [documentation](doc/Readme.md). 
* [Packages/](Packages) Contains all **Unity3d** Packages used across folders, and may also include other commonly used third-party systems. Note that this is a folder that contains a collection of other git repos that are *not* sub-modules. By Placing them all here, then `ProjectName/ProjectName-Unity/Packages/manifest.json` can find packages by default by hard-wiring references.
* [repos/](repos) This can be a symbolic link to another folder or even another drive. Use the `go` command to list and move between repos.
* [src/](src) Source code for tools in `$WORK_FOLDER/bin`.
* [tmp/](src) A folder that is expected to exist, which can be used per-session for storage of temporary information.

## Setup

This documentation will assume a Unix-like environment. That is - macOS, Linux, Windows (WSL) or Windows (GitBash).

```bash
git clone https://github.com/Ched-Services/WorkFolder ~/work
sh work/bootstrap
```

This will ensure that the environment variable WORK\_FOLDER is set on shell start.

## Common Usage Patterns

See $WORK\_FOLDER/docs/default for a set of files that may be used to start from for common items, such as Git Ignore files, etc.

* [bin/](bin) Contains often used [shell scripts](bin/Readme.md) and other tools.
* [doc/](doc) Contains top-level project-agnostic [documentation](doc/Readme.md). TODO. For example, *GitCommands.md*.
* [Packages/](Packages) Contains all **Unity3d** Packages used across folders, and may also include other commonly used third-party systems. Note that this is a folder that contains a collection of other git repos that are *not* sub-modules. By Placing them all here, then `ProjectName/ProjectName-Unity/Packages/manifest.json` can find packages by default by hard-wiring references.
* [repos/](repos) Contains all your various work repos. This can be a symbolic link to another folder or even another drive. Use the `go` command to list and move between repos.
* [src/](src) Source for custom tools in `$WORK_FOLDER/bin`.

