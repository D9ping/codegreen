REM Copyright (C) 2009-2010
REM This program is free software; you can redistribute it and/or modify it
REM Free Software Foundation; either version 2, or (at your option) any
REM later version.
REM
REM This program is distributed in the hope that it will be useful,
REM but WITHOUT ANY WARRANTY; without even the implied warranty of
REM MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
REM GNU General Public License for more details.
REM
REM You should have received a copy of the GNU General Public License
REM along with this program; if not, write to the Free Software
REM Foundation, Inc., 59 Temple Place - Suite 330, Boston, MA  02111-1307, USA
@echo off
set path7z="C:\Program Files\7-Zip\7z.exe"
set VERSION=1.5.1
set VERSIONSTATUS=""

echo Making zip archive: src_CodeGreen_v%VERSION%%VERSIONSTATUS%.zip
echo 7-zip(7z.exe) should be installed in: %path7z%

pause
IF NOT EXIST %path7z% GOTO NO7ZDIR

%path7z% a -tzip "%cd%\build\src_CodeGreen_v%VERSION%%VERSIONSTATUS%.zip" -r %cd%\*.cs %cd%\*.resx %cd%\*.config %cd%\*.sln %cd%\*.csproj %cd%\*.eqconfig %cd%\*.png %cd%\*.bmp %cd%\*.ico %cd%\*.jpg %cd%\*.bat %cd%\*.xsd %cd%\*.manifest %cd%\*.nsi %cd%\*.settings %cd%\*.wav %cd%\*.iss %cd%\*.csproj.user %cd%\*.txt

echo done.
pause
exit

:NO7ZDIR
echo Cannot find 7-zip (7z.exe). Please change the path7z variable in this script.
pause
