:: component-create.bat
@echo off
setlocal ENABLEDELAYEDEXPANSION

set MONO="%PROGRAMFILES%\Mono-3.0.9\bin\mono.exe"
::set XPKG=sbin\xpkg\xpkg.exe
set XPKG=sbin\xpkg\xamarin-component.exe
set RAKE=C:\bin\Ruby200\bin\rake

DEL /Q *.xam *.xam.zip

dir /s .\content\bin\*.dll
dir /s .\content\lib\


%XPKG% package .\
	

@IF %ERRORLEVEL% NEQ 0 PAUSE