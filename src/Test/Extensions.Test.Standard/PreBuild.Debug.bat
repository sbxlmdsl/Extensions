ECHO OFF
REM Starting PreBuild.bat...
REM Note:  Beware that .bat files in VS have junk characters at beginning that must be removed via Binary Editor.
REM Usage: Call "$(ProjectDir)PreBuild.$(ConfigurationName).bat" "$(ProjectDir)" "$(ConfigurationName)"
REM Vars:  $(TargetPath) = output file, $(TargetDir) = full bin path , $(OutDir) = bin\debug

ECHO Starting PreBuild.bat

REM Locals
SET Configuration="Debug"
SET FullPath=%1
SET FullPath=%FullPath:"=%
ECHO FullPath: %FullPath%

REM \App_Data\AppSettings.config
%WINDIR%\system32\attrib.exe "%FullPath%App_Data\AppSettings.%Configuration%.Config" -r
%WINDIR%\system32\xcopy.exe  "%FullPath%App_Data\AppSettings.%Configuration%.config" "%FullPath%App_Data\AppSettings.config" /f/r/c/y
%WINDIR%\system32\attrib.exe "%FullPath%App_Data\AppSettings.%Configuration%.Config" +r

REM \App_Data\ConnectionStrings.config
%WINDIR%\system32\attrib.exe "%FullPath%App_Data\ConnectionStrings.%Configuration%.Config" -r
%WINDIR%\system32\xcopy.exe  "%FullPath%App_Data\ConnectionStrings.%Configuration%.Config" "%FullPath%App_Data\ConnectionStrings.config" /f/r/c/y
%WINDIR%\system32\attrib.exe "%FullPath%App_Data\ConnectionStrings.%Configuration%.Config" +r

exit 0
