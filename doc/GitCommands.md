# Useful Git Commands

## Logging

Add the following to your ~/.gitconfig

```bash
[alias]
    lg = log --graph --pretty=format:'%C(magenta)%h%Creset -%C(red)%d%Creset %s %C(dim green)(%cr) %C(cyan)<%an>%Creset' --abbrev-commit
```

## Useful things

```bash
$ git remote update	# update remote refs
$ git status -uno	# tell if you're ahead or behind or diverged
$ git show-branch \*master # show commits in all branches with name 'master' in them
$ git checkout d7c2579 -- Readme.md # Restore a file from a given commit.

```

## To make an old commit the HEAD of a branch
```bash
$ git checkout <OLD_COMMIT>
$ git branch temp
$ git checkout temp
$ git branch -f master temp
$ git checkout master
$ git branch -d temp
```

## To cleanup stale references to remote branches
```bash
git remote update origin --prune
```
