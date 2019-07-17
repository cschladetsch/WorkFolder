# Project Name
*go* allows the user to switch between *git* repositories quickly, while remembering where it came from when later re-entering a repo.

## Usage
```
go
```
Shows a list of repos, prefixed with a number.
```
go n
```
Go to the given repo, first remembering where we are so a later *go* to this repo will restore the local path.
```
go -
```
Return to the previous repo and restoring its path.

