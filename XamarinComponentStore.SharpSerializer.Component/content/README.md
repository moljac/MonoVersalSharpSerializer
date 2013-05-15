# Xamarin Component SharpSerializer

SharpSerializer fast XML and binary serialization (serialization library) for:

* 	Binary and
*	Xml
Serialization

* 	[http://sharpserializer.codeplex.com](http://sharpserializer.codeplex.com)
* 	[http://www.sharpserializer.com](http://www.sharpserializer.com)
* 	[http://holisticware.net](http://holisticware.net)


HolisticWare batch script (Visual Studio project template coming soon):

```shell
:: component-create.bat
@echo off

setlocal ENABLEDELAYEDEXPANSION

call .\compile.bat




set MONO="%PROGRAMFILES%\Mono-3.0.9\bin\mono.exe"
set XPKG=bin.apps\xpkg\xpkg.exe
set RAKE=C:\bin\Ruby200\bin\rake


:: rake downloads xpkg and runs:

set PACKAGE=SharpSerializer

set ASSEMBLIES=^
	..\SharpSerializer.Library.MonoForAndroid\bin\Debug\SharpSerializer.Library.MonoForAndroid.dll ^
	..\SharpSerializer.Library.MonoTouch\bin\Debug\SharpSerializer.Library.MonoTouch.dll


	
:: http://www.dostips.com/DtTipsStringManipulation.php
:: 

echo ===========================================================================
echo starting services
for %%A IN (%ASSEMBLIES%) DO (
	echo -----------------------------------
	echo %%A
	set FILENAME=%%~nA
	echo !FILENAME!

	:: not sure for filenames, so let's do some string replacements
	set FILENAME=!FILENAME:.Library=!
	set FILENAME=!FILENAME:.monodroid=.Android!
	set FILENAME=!FILENAME:.MonoDroid=.Android!
	set FILENAME=!FILENAME:.monoforandroid=.Android!
	set FILENAME=!FILENAME:.MonoForAndroid=.Android!

	set FILENAME=!FILENAME:.monotouch=.iOS!
	set FILENAME=!FILENAME:.MonoTouch=.iOS!

	set FILENAME=!FILENAME!.dll
	echo !FILENAME!
	
	echo f | xcopy /f /y %%A .\content\bin\!FILENAME!
)

echo ===========================================================================

DEL /Q *.xam *.xam.zip

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
	--sample="Sample for iOS. %PACKAGE% sample for iOS.":"content/samples/%PACKAGE%.iOS.sln" ^
	--sample="Sample for Android. %PACKAGE% sample for Android.":"content/samples/%PACKAGE%.Android.sln"
	

@IF %ERRORLEVEL% NEQ 0 PAUSE
```


To build this sample component:

```shell
# Download xpkg
curl -L https://components.xamarin.com/submit/xpkg > xpkg.zip
mkdir xpkg
unzip -o -d xpkg xpkg.zip

# Create the component package
mono xpkg/xpkg.exe create sample-component-1.0.xam \
    --name="My Awesome Component" \
    --summary="Add a huge amount of awesomeness to your Xamarin apps." \
    --publisher="Awesome Corp, Inc." \
    --website="http://awesomecorp.com/component" \
    --details="Details.md" \
    --license="License.md" \
    --getting-started="GettingStarted.md" \
    --icon="icons/Awesome_128x128.png" \
    --icon="icons/Awesome_512x512.png" \
    --library="ios":"bin/Awesome.iOS.dll" \
    --library="android":"bin/Awesome.Android.dll" \
    --sample="iOS Sample. Demonstrates Awesomeness on iOS.":"samples/Awesome.iOS.sln" \
    --sample="Android Sample. Demonstrates Awesomeness on Android":"samples/Awesome.Android.sln"
```

There's a Rakefile in this repo that will do these steps for you if you
simply type `rake`:

```shell
$ rake
* Downloading xpkg...
* Creating sample-component-1.0.xam...
mono xpkg/xpkg.exe create sample-component-1.0.xam \
    --name="My Awesome Component" \
    --summary="Add a huge amount of awesomeness to your Xamarin apps." \
    --publisher="Awesome Corp, Inc." \
    --website="http://awesomecorp.com/component" \
    --details="Details.md" \
    --license="License.md" \
    --getting-started="GettingStarted.md" \
    --icon="icons/Awesome_128x128.png" \
    --icon="icons/Awesome_512x512.png" \
    --library="ios":"bin/Awesome.iOS.dll" \
    --library="android":"bin/Awesome.Android.dll" \
    --sample="iOS Sample. Demonstrates Awesomeness on iOS.":"samples/Awesome.iOS.sln" \
    --sample="Android Sample. Demonstrates Awesomeness on Android":"samples/Awesome.Android.sln"
* Created sample-component-1.0.xam
```
