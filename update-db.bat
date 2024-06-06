echo off
shift
shift
dotnet ef database update -p LifeTracker.Infrastructure -s LifeTracker.API -c DatabaseContext