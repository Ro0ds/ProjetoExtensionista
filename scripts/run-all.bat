@echo off
start "API" cmd /k "cd ../src/Api && dotnet watch run"
start "WEB" cmd /k "cd ../src/webapp && dotnet watch run"