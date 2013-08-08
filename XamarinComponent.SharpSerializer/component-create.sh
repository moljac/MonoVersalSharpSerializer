@echo off

set MONO="%PROGRAMFILES%\Mono-3.0.9\bin\mono.exe"
set XPKG=bin.apps\xpkg\xpkg.exe
set RAKE=C:\bin\Ruby200\bin\rake


:: rake downloads xpkg and runs:

set PACKAGE=HolisticWare-SharpSerializer
cd SharpSerializer

%MONO% ^
	%XPKG% ^
	create %PACKAGE%-1.0.xam ^
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
	--sample="iOS Sample. Demonstrates Awesomeness on iOS.":"content/samples/Awesome.iOS.sln" ^
	--sample="Android Sample. Demonstrates Awesomeness on Android":"content/samples/Awesome.Android.sln"

	
pause