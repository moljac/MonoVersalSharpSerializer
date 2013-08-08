:: component-create.bat
@echo off

setlocal ENABLEDELAYEDEXPANSION

call .\compile.bat




set MONO="%PROGRAMFILES%\Mono-3.0.9\bin\mono.exe"
::set XPKG=bin.apps\xpkg\xpkg.exe
set XPKG=bin.apps\xpkg\xamarin-component.exe
set RAKE=C:\bin\Ruby200\bin\rake


:: rake downloads xpkg and runs:

set PACKAGE=SharpSerializer

set ASSEMBLIES=^
	..\SharpSerializer.Library.MonoForAndroid\bin\Release\SharpSerializer.Android.dll ^
	..\SharpSerializer.Library.MonoTouch\bin\Release\SharpSerializer.iOS.dll


	
:: http://www.dostips.com/DtTipsStringManipulation.php
:: 

echo ===========================================================================
echo copying assemblies
for %%A IN (%ASSEMBLIES%) DO (
	echo -----------------------------------
	echo %%A
	dir %%A
	set FILENAME=%%~nA
	echo !FILENAME!

	:: not sure for filenames, so let's do some string replacements
	:: not wise and not needed (change project properties)

::		set FILENAME=!FILENAME:.Library=!
::		set FILENAME=!FILENAME:.monodroid=.Android!
::		set FILENAME=!FILENAME:.MonoDroid=.Android!
::		set FILENAME=!FILENAME:.monoforandroid=.Android!
::		set FILENAME=!FILENAME:.MonoForAndroid=.Android!
::	
::		set FILENAME=!FILENAME:.monotouch=.iOS!
::		set FILENAME=!FILENAME:.MonoTouch=.iOS!
::	
::		set FILENAME=!FILENAME!.dll
::		echo !FILENAME!
::		echo f | xcopy /f /y %%A .\content\bin\!FILENAME!

		echo f | xcopy /f /y %%A .\content\bin\
)

echo ===========================================================================

dir .\content\bin\*.dll
DEL /Q *.xam *.xam.zip

%MONO% ^
	%XPKG% ^
	create-manually ^
	%PACKAGE%-1.0.xam ^
	--name="HolisticWare SharpSerializer component" ^
	--summary="HolisticWare featuring SharpSerializer" ^
	--publisher="HolisticWare LLC" ^
	--website="http://holisticware.net/" ^
	--details="content/Details.md" ^
	--license="content/License.md" ^
	--getting-started="content/GettingStarted.md" ^
	--icon="content/icons/%PACKAGE%_128x128.png" ^
	--icon="content/icons/%PACKAGE%_512x512.png" ^
	--library="ios":"content/bin/%PACKAGE%.iOS.dll" ^
	--library="android":"content/bin/%PACKAGE%.Android.dll" ^
	--sample="Sample for iOS. %PACKAGE% sample for iOS.":"content/samples/%PACKAGE%.iOS/%PACKAGE%.iOS.sln" ^
	--sample="Sample for Android. %PACKAGE% sample for Android.":"content/samples/%PACKAGE%.Android/%PACKAGE%.Android.sln"
	

@IF %ERRORLEVEL% NEQ 0 PAUSE