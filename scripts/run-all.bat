@echo off
start "API" cmd /k "cd ../src/Api && dotnet watch run"

start "React" cmd /k "cd ../src/webapp && npm start"