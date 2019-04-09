# Liminal Working Projects folder
Contains common functionality used by all developers at [Liminal](www.liminalvr.com).

All developers *must have [git-bash shell](https://gitforwindows.org/) installed on their workstation*.

This repo is intended to be at the root of their work folder. In many cases this will be at `~/work`, or more verbosely `/c/Users/name/work`. Note that it could also be at `e:\Projects`, or wherever. *Never hard-code `~/work` into any script*. 

In fact, TODO, use $WORK_FOLDER to point to the nominal `work` folder, everywhere.

The explicit location is not enforced, but for consistency it is prefered to be in `~/work`. Whenever `~/work` folder is referenced in the documentation or wiki, it is a synonym for this root work folder.

*NOTE* Some hand-holding may be required for artists unfamiliar with using `bash`.

## Todo
* Use $WORK_FOLDER to specify the root Liminal project folder for a given workstation.
* Add `~/work/bin/enter`. This enters the general work environment.
* Add `~/work/bin/start-project project-name`. This would create a ready-to-use project from git, including custom `enter` script for that project.

## Contents
* _bin/_ Contains often used [shell scripts](bin/Readme.md) and other tools
* _doc/_ Contains top-level project-agnostic [documentation](doc/Readme.md). TODO. For example, *GitCommands.md*
* _LiminalPackages/_ Contains all Unity3d Packages used across folders. Note that this is a folder that contains a collection of other git repos that are *not* sub-modules. By Placing them all here, then `ProjectName/ProjectName-Unity/Packages/manifest.json` can find packages by default by hard-wiring references. This is not ideal, but still practical.
* _InternalPackages_ ??
* _ExternalPackages_ ??
* _Packages_ ??
