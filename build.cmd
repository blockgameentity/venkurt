@echo off
cd vencord-plugins
7z a a.zip *
cd ..\src
move /y ..\vencord-plugins\a.zip files
dotnet publish -r win-x64 -c Release /p:DebugType=none /p:DebugSymbols=false
cd bin\Release\net8.0\win-x64\publish
upx -9 venkurt.exe
pause