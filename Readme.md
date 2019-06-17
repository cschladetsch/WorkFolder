# Liminal Working Projects folder
Contains common functionality used by all developers at [Liminal](www.liminalvr.com).

See [Installer](https://github.com/LiminalVR/WorkFolderInstaller) for a Gui for setup.

**All developers _must_ have [git-bash shell](https://gitforwindows.org/) installed on their workstation**.

This repo is intended to be at the root of their work folder. In many cases this will be at `~/work`, or more verbosely `/c/Users/user-name/work`. Note that it could also be at `e:\Projects`, (`/e/Projects` in git-bash syntax) or wherever. Specifically: *Never hard-code `~/work` into any script*. Rather, use `$WORK_DIR` and `$REPOS_DIR` for repositories.

Internal packages are always at `$WORK_DIR\Packages`.

Whenever `~/work` folder is referenced in the documentation or wiki, it is a synonym for this root work folder specified in `$WORK_DIR` environment variable.

*NOTE* Some hand-holding may be required for artists unfamiliar with using `bash`.

## Todo
* Use $WORK\_DIR to specify the root _Liminal_ project folder for a given workstation, ie ~/work
* Add `~/work/bin/enter`. This enters the general work environment.
* Add `~/work/bin/start-project project-name`. This would create a ready-to-use project from git, including custom `enter` script for that project.
* When *bootstrapping* a new project, some system (TBD) must change `Packages/manifest.json` to include references to `$WORK_ROOT/Packages/{Packagenames}`

## Contents
* [.proj/](.proj) Contains top-level initialisation and entry into either $WORK_ROOT or entry into any _Liminal_ project based on `WorkFolder` structure.
* [bin/](bin) Contains often used [shell scripts](bin/Readme.md) and other tools
* [doc/](doc) Contains top-level project-agnostic [documentation](doc/Readme.md). TODO. For example, *GitCommands.md*
* _Packages/_ Contains all **Unity3d** Packages used across folders. Note that this is a folder that contains a collection of other git repos that are *not* sub-modules. By Placing them all here, then `ProjectName/ProjectName-Unity/Packages/manifest.json` can find packages by default by hard-wiring references. This is not ideal, but still practical.
* _InternalPackages_ ??
* _ExternalPackages_ ??
