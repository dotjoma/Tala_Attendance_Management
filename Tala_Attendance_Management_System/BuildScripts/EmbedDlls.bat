@echo off
echo Embedding DLLs into Single Executable
echo =====================================

set "ProjectDir=%~dp0.."
set "OutputDir=%ProjectDir%\bin\Release"
set "SingleFileDir=%ProjectDir%\Project_Release"
set "TargetName=TalaAMS"
set "ILMergePath=%ProjectDir%\Tools\ILMerge\tools\net452\ILMerge.exe"

echo Project Directory: %ProjectDir%
echo Output Directory: %OutputDir%
echo Single File Directory: %SingleFileDir%

REM Check if build exists
if not exist "%OutputDir%\%TargetName%.exe" (
    echo Error: Release build not found
    echo Please build the project in Release mode first
    pause
    exit /b 1
)

REM Check if ILMerge exists
if not exist "%ILMergePath%" (
    echo Error: ILMerge not found
    echo Please run DownloadILMerge.ps1 first
    pause
    exit /b 1
)

REM Create output directory
if exist "%SingleFileDir%" rmdir /s /q "%SingleFileDir%"
mkdir "%SingleFileDir%"

echo.
echo Merging Newtonsoft.Json.dll into executable...
"%ILMergePath%" /target:winexe /out:"%SingleFileDir%\%TargetName%.exe" ^
    "%OutputDir%\%TargetName%.exe" ^
    "%OutputDir%\Newtonsoft.Json.dll" ^
    /targetplatform:v4

if %ERRORLEVEL% EQU 0 (
    echo SUCCESS: Newtonsoft.Json.dll embedded!
) else (
    echo WARNING: Merge had issues
)

REM Copy config files
copy "%OutputDir%\%TargetName%.exe.config" "%SingleFileDir%\"
xcopy "%ProjectDir%\Config" "%SingleFileDir%\Config\" /E /I /Y >nul 2>&1
mkdir "%SingleFileDir%\Logs" >nul 2>&1

REM Check if merge was successful by checking file size
set "MERGE_SUCCESS=0"
if exist "%SingleFileDir%\%TargetName%.exe" (
    for %%A in ("%SingleFileDir%\%TargetName%.exe") do (
        if %%~zA GTR 1000000 (
            set "MERGE_SUCCESS=1"
        )
    )
)

if %MERGE_SUCCESS% EQU 0 (
    echo ERROR: Merge failed - falling back to simple copy
    if exist "%SingleFileDir%\%TargetName%.exe" del "%SingleFileDir%\%TargetName%.exe"
    copy "%OutputDir%\%TargetName%.exe" "%SingleFileDir%\"
    copy "%OutputDir%\*.dll" "%SingleFileDir%\"
) else (
    REM Merge succeeded, copy the DLLs that couldn't be merged
    echo Copying ReportViewer and SqlServer DLLs...
    copy "%OutputDir%\Microsoft.ReportViewer.*.dll" "%SingleFileDir%\" >nul 2>&1
    copy "%OutputDir%\Microsoft.SqlServer.*.dll" "%SingleFileDir%\" >nul 2>&1
)

REM Check for any remaining DLLs
set "DLL_COUNT=0"
for %%f in ("%SingleFileDir%\*.dll") do set /a DLL_COUNT+=1

echo.
echo ===================
echo DEPLOYMENT PACKAGE READY!
echo ===================
echo Location: %SingleFileDir%
echo.
echo Package contents:
dir "%SingleFileDir%" /B

echo.
if %DLL_COUNT% EQU 0 (
    echo *** Newtonsoft.Json.dll successfully embedded! ***
    echo No separate DLL files in package!
) else if %DLL_COUNT% LEQ 7 (
    echo Embedded: Newtonsoft.Json.dll
    echo Separate: %DLL_COUNT% DLL files ^(ReportViewer + SqlServer^)
    echo.
    echo NOTE: ReportViewer and SqlServer DLLs cannot be merged
    echo They contain native code and Visual Studio dependencies
) else (
    echo WARNING: Merge may have failed
    echo All %DLL_COUNT% DLLs are separate
)
echo.
pause