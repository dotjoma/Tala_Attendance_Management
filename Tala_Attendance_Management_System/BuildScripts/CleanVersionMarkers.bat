@echo off
echo Cleaning Version Marker Files
echo =============================
echo.

set "ProjectDir=%~dp0.."
set "BuildDir=%ProjectDir%\Build\TalaSystem"
set "ReleaseDir=%ProjectDir%\bin\Release"
set "SingleFileDir=%ProjectDir%\Project_Release"

echo Searching for version marker files (v*.*.*)...
echo.

REM Clean Build directory
if exist "%BuildDir%" (
    echo Checking: %BuildDir%
    for %%f in ("%BuildDir%\v*.*.*") do (
        echo   Deleting: %%~nxf
        del "%%f"
    )
)

REM Clean Release directory
if exist "%ReleaseDir%" (
    echo Checking: %ReleaseDir%
    for %%f in ("%ReleaseDir%\v*.*.*") do (
        echo   Deleting: %%~nxf
        del "%%f"
    )
)

REM Clean SingleFile directory
if exist "%SingleFileDir%" (
    echo Checking: %SingleFileDir%
    for %%f in ("%SingleFileDir%\v*.*.*") do (
        echo   Deleting: %%~nxf
        del "%%f"
    )
)

echo.
echo Cleanup complete!
echo.
echo These version marker files should NOT be included in update packages.
echo They are created by the update process and should be excluded from ZIP files.
echo.
pause
