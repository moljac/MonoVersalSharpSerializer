MonoVersalSharpSerializer
=========================

SharpSerializer ports to 

*	MonoForAndroid, 
*	MonoTouch, 
*	WindowsPhone (work in progress)
*	MonoMac (work in progress)


Executables (applications) are direct port of the Windows Forms application which
is part of original SharpSerializer package (three buttons for test and message box)


## Known issues ##

2013-05 

If working with stable versions of Xamarin.iOS and Xamarin.Android Alert message
states that files differ. Stable version is based on Mono 2.10.x and HolisticWare team
reported a bug. 

For those on alpha channels of Xamarin Studio and Xamarin.iOS and Xamarin.Android which
are based on Mono 3.x - there is no error in serialization. So, alerts will return
the size of the file[s].

[https://bugzilla.xamarin.com/show_bug.cgi?id=11822](https://bugzilla.xamarin.com/show_bug.cgi?id=11822)

It seems that there is issue with serialization of '\t' character.


## Original ##

By 
* 	[http://www.sharpserializer.com](http://www.sharpserializer.com)  
* 	[http://sharpserializer.codeplex.com/](http://sharpserializer.codeplex.com/)

## License ##

New BSD License (BSD)
Copyright (c) 2011, Pawel Idzikowski
All rights reserved.

Redistribution and use in source and binary forms, with or without modification, 
are permitted provided that the following conditions are met:

* 	Redistributions of source code must retain the above copyright notice, this list   
	of conditions and the following disclaimer.

* 	Redistributions in binary form must reproduce the above copyright notice, this    
	list of conditions and the following disclaimer in the documentation and/or other  
	materials provided with the distribution.

* 	Neither the name of Polenter - Software Solutions nor the names of its contributors   
	may be used to endorse or promote products derived from this software without specific   
	prior written permission.

THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS 
OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY 
AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR 
CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, 
OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR 
SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY 
THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR 
OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE 
POSSIBILITY OF SUCH DAMAGE.



Ported by HolisticWare team:

[http://holisticware.net](http://holisticware.net)


## Log ##

### 2013-04-15 ###

XML serialization bug - not i mono 3.0.8


### 2013-04-07 ###

XML serilization not the same

error in serialization 

