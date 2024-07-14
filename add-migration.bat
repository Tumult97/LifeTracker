@echo off
set MIGRATION_NAME=%1
if "%MIGRATION_NAME%"=="" (
    echo Usage: add-migration.bat ^<migration_name^>
    exit /b 1
)
shift
shift
dotnet ef migrations add %MIGRATION_NAME% -p LifeTracker.Infrastructure -s LifeTracker.API -c DatabaseContext