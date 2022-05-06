@echo off
REM  batch script for loading git-bash and the vs tools in the same window

REM  inspiration: http://www.drrandom.org/post/2011/11/16/Grappling-with-multiple-remotes-in-git-tfs.aspx


call "c:\Program Files (x86)\Microsoft Visual Studio\2019\Community\Common7\Tools\VsDevCmd.bat"

rem cd "C:\Program Files (x86)\Microsoft Visual Studio\2019\Community\"
rem call "C:\Program Files (x86)\Microsoft Visual Studio\2019\Community\vcvarsall.bat" x86
rem call "C:\Program Files (x86)\Microsoft Visual Studio 10.0\VC\vcvarsall.bat" x86

echo Use full exe names when running under bash, e.g. "msbuild.exe"
echo Loading bash, you may now use git and msbuild in the same console \o/.
"C:\Program Files\Git\git-bash.exe"
