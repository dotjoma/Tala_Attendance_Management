@echo off
echo Environment Configuration Tool
echo ==============================

if "%1"=="" (
    echo Usage: SetEnvironment.bat [Development^|Staging^|Production]
    echo.
    echo Current environment settings:
    echo.
    echo App.config:
    findstr "Environment" "%~dp0..\App.config" 2>nul
    echo.
    echo Release build config:
    findstr "Environment" "%~dp0..\bin\Release\Tala_Attendance_Management_System.exe.config" 2>nul
    echo.
    echo SingleExe_Release config:
    findstr "Environment" "%~dp0..\SingleExe_Release\Tala_Attendance_Management_System.exe.config" 2>nul
    echo.
    pause
    exit /b 0
)

set "ENV=%1"
if /i "%ENV%"=="Development" goto :valid
if /i "%ENV%"=="Staging" goto :valid
if /i "%ENV%"=="Production" goto :valid

echo Error: Invalid environment. Use Development, Staging, or Production
pause
exit /b 1

:valid
echo Setting environment to: %ENV%
echo.

REM Update App.config
powershell -Command "(Get-Content '%~dp0..\App.config') -replace 'value=\"(Development|Staging|Production)\"', 'value=\"%ENV%\"' | Set-Content '%~dp0..\App.config'"

REM Update Release build config if it exists
if exist "%~dp0..\bin\Release\Tala_Attendance_Management_System.exe.config" (
    powershell -Command "(Get-Content '%~dp0..\bin\Release\Tala_Attendance_Management_System.exe.config') -replace 'value=\"(Development|Staging|Production)\"', 'value=\"%ENV%\"' | Set-Content '%~dp0..\bin\Release\Tala_Attendance_Management_System.exe.config'"
    echo Updated Release build config
)

REM Update SingleExe_Release config if it exists
if exist "%~dp0..\SingleExe_Release\Tala_Attendance_Management_System.exe.config" (
    powershell -Command "(Get-Content '%~dp0..\SingleExe_Release\Tala_Attendance_Management_System.exe.config') -replace 'value=\"(Development|Staging|Production)\"', 'value=\"%ENV%\"' | Set-Content '%~dp0..\SingleExe_Release\Tala_Attendance_Management_System.exe.config'"
    echo Updated SingleExe_Release config
)

echo.
echo Environment successfully set to: %ENV%
echo.
echo Configuration files updated:
echo - App.config
if exist "%~dp0..\bin\Release\Tala_Attendance_Management_System.exe.config" echo - Release build config
if exist "%~dp0..\SingleExe_Release\Tala_Attendance_Management_System.exe.config" echo - SingleExe_Release config
echo.
echo Next steps:
if /i "%ENV%"=="Production" (
    echo 1. Update Config\config.prod.json with production database settings
    echo 2. Build release: msbuild /p:Configuration=Release
    echo 3. Create package: BuildScripts\EmbedDlls.bat
) else if /i "%ENV%"=="Staging" (
    echo 1. Update Config\config.staging.json with staging database settings
    echo 2. Build release: msbuild /p:Configuration=Release
    echo 3. Create package: BuildScripts\EmbedDlls.bat
) else (
    echo 1. Update Config\config.dev.json with development database settings
    echo 2. Build and test your application
)
echo.
pause