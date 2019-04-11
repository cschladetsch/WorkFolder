# Enter for Workstation WorkFolder
This contains company-wide configuration of work folder.

The work folder can be stored anywhere on a given workstation (or even have multiple work folders!), and the developer should be able to `enter` any one of them by saying

```bash
$ . enter
$ # or
$ source enter
$ # which mean the same thing
```
So, when a developer enters a $WORK_ROOT, they say `. enter` and the system will bootstrap if needed, and generally setup by for example cloning all `Packages` required into $WORK_ROOT/Packages, etc.

Furthermore, when a developer enters a specific project and says `. enter`, it should boostrap if necessary, and also setup environment for that project.

Note that the developer will be able to say things like:

```bash
$ cd $WORK_ROOT
$ . enter
$ status
$ get-project ProjectName [git-url]
$ cd ProjectName
$ . enter
```





