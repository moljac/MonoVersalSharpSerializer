@echo off
call "%PROGRAMFILES%\Microsoft Visual Studio 10.0\VC\vcvarsall.bat"


rmdir /q /s .\bin\
rmdir /q /s .\bin\

:: =============================================================================================
:: select solution file sln to compile all projects
::		..\SharpSerializer.sln
:: project files to narrow selection
:: output of compilation is in <ProjectName>\bin\Debug.msbuild\
set PROJECTS=^
	..\SharpSerializer.Library.MonoTouch\SharpSerializer.Library.MonoTouch.csproj ^
	..\SharpSerializer.Library.MonoForAndroid\SharpSerializer.Library.MonoForAndroid.csproj 

set CONFIGURATION=Debug
::set CONFIGURATION=Release

for %%p IN (%PROJECTS%) DO (
	echo ------------------------------------------------------------------
	echo %%p
	msbuild %%p ^
			/p:Configuration=%CONFIGURATION% ^
			/property:OutDir=.\bin\%CONFIGURATION%.msbuild\

	msbuild %%p ^
			/p:Configuration=%CONFIGURATION% ^
			/property:OutDir=..\XamarinComponentStore.SharpSerializer.XamarinComponent\content\bin\
			
)
:: =============================================================================================

@IF %ERRORLEVEL% NEQ 0 PAUSE	
