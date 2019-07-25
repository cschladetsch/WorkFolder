# Go to repo
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
```
go -k or -clear
```
Clear all `.current` files in all repos.
```
go -c or -current
```
Go to root of current repo.

If a file called `.enter` exists in the current repo before it is entered, it will be executed.

If a file called `.leave` exists in the current repo before it is left, it will be executed.
