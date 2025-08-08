# W Drive Subst Setup

This document provides step-by-step instructions for setting up a Windows `subst` mapping for the W: drive.

## Creating a Subst Shortcut

Create a shortcut that maps your work directory to the W: drive:

1. Right-click on your desktop and select "New" → "Shortcut"
2. In the target field, enter:
   ```cmd
   C:\Windows\System32\cmd.exe /c "subst W: C:\Users\%USERNAME%\work"
   ```
3. Name the shortcut "Map W Drive" or similar
4. Run the shortcut to create the mapping

## Alternative Method

You can also create the mapping directly from command line:

```cmd
subst W: %WORK_FOLDER%
```

## Verification

To verify the mapping is active:
```cmd
subst
```

This will list all active drive substitutions.

## Removing the Mapping

To remove the W: drive mapping:
```cmd
subst W: /d
```
