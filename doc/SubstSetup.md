# Subst Setup

This document describes how to set up Windows `subst` command for creating virtual drives that map to specific directories.

## Windows Subst Command

The `subst` command allows you to create virtual drives on Windows systems:

```cmd
subst W: C:\Users\username\work
```

This creates a virtual drive `W:` that maps to your work directory.

## Benefits

- Shorter paths for accessing frequently used directories
- Consistent drive mapping across different systems
- Easier navigation in command line and file explorer

## Usage with WorkFolder

When using the WorkFolder system on Windows, you can map your work directory to a drive letter for easier access:

```cmd
subst W: %WORK_FOLDER%
```

## Persistent Mapping

To make the mapping persistent across reboots, add the subst command to your startup scripts or create a batch file in your startup folder.
