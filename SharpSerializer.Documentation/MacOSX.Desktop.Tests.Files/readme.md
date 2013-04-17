# Bug Mono <= 3.x.x #

## Reduced version ##

netfx

		Both files have the same length of 430 bytes and the same content
		Both files have the same length of 267 bytes and the same content
		Both files have the same length of 288 bytes and the same content
		Bress Anny Key West!!!!!


mono 2.10.8

		Files differ at offset 284
		Both files have the same length of 267 bytes and the same content
		Both files have the same length of 288 bytes and the same content
		Press any key to continue . . .

mono 3.0.1

		Both files have the same length of 430 bytes and the same content
		Both files have the same length of 267 bytes and the same content
		Both files have the same length of 288 bytes and the same content
		Press any key to continue . . .


xml file line 6

xml code

	<Complex name="Root" type="HelloWorldApp.BusinessObjects.RootContainer, HelloWorldApp.Console, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null">
	  <Properties>
		<SingleArray name="SingleArrayOfChars">
		  <Items>
			<Simple value="o" />
			<Simple value="	" />
			<Simple value="&#xA;" />
			<Simple value="&amp;#x0;" />
		  </Items>
		</SingleArray>
	  </Properties>
	</Complex>


## Original xml file ##


xml file line 63

xml code

	<SingleArray name="SingleArrayOfChars">
	  <Items>
		<Simple value="o" />
		<Simple value=" " />
		<Simple value="&#xA;" />
		<Simple value="&amp;#x0;" />
	  </Items>
	</SingleArray>
