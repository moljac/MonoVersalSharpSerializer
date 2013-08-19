# Getting Started #


SharpSerializer fast XML and binary serialization by Polenter


* 	Xamarin.iOS
* 	Xamarin.Android

Cross-platform port by HolisticWare.



## Hello world with xml serialization ##

The easiest way to use sharpSerializer is to instantiate it with its standard constructor. 
Out of the box sharpSerializer serializes to Xml.


```csharp
		// create fake obj
		var obj = createFakeObject();

		// create instance of sharpSerializer
		// with standard constructor it serializes to xml
		var serializer = new SharpSerializer();

		// serialize
		serializer.Serialize(obj, "test.xml");

		// deserialize
		var obj2 = serializer.Deserialize("test.xml");
```


## Hello world with binary serialization ##

To activate binary serialization you need to use overloaded constructor.

```csharp

		// create fake obj
		var obj = createFakeObject();

		// create instance of sharpSerializer
		// true - binary serialization, false - xml serialization
		var serializer = new SharpSerializer(true);

		// serialize
		serializer.Serialize(obj, "test.bin");

		// deserialize
		var obj2 = serializer.Deserialize("test.bin");
```



## Different modes of the binary serialization ##

There are two modes of binary serialization: SizeOptimized and Burst.

What is the difference?
To successfully restore an object tree from the serialized stream, all objects 
must be serialized including their type information. Both modes differ in the 
art the type information is stored.

### BinarySerializationMode.Burst ###

In the burst mode, type of every object is serialized as part of this object. 
It doesn't matter if all serialized objects are of the same type, their types are
serialized as many times, as many objects. Type information is duplicated. It increases 
the file size especially when serializing listings of items of the same type (collections, 
arrays, dictionaries). This mode is recommended only for serializing of single, simple 
objects. It has small overhead and no extended logic. BurstBinaryWriter supports this 
mode.

```csharp
		// create sharpSerializer in the burst binary mode
		// overloaded constructor of SharpSerializerBinarySettings accepts one value from the enumeration BinarySerializationMode
		var settings = new SharpSerializerBinarySettings(BinarySerializationMode.Burst);
		var burstSerializer = new SharpSerializer(settings);

```

### BinarySerializationMode.SizeOptimized (the default one) ###

In the SizeOptimized mode all types are gathered in a list which is stored in the 
file header. All type duplicates are removed. Serialized objects refer only to this 
list using index of the correlated type. It's recommended approach for serializing of 
complex objects with many properties, or serializing of listings. The drawback is - 
serialized objects must be at first analysed, then their types are cached in the list, 
duplicates are removed, type indexes are estimated and injected back to the objects. 
Finally the data is written to stream.
Apart from types, the same optimization is applied to property names. 
SizeOptimizedBinaryWriter supports this mode.

```csharp
	// create sharpSerializer in the size optimized binary mode - Default
	// overloaded constructor accepts bool value. If true then binary serialization, if false - xml
	var sizeOptimizedSerializer1 = new SharpSerializer(true);

	// or with the same usage as for the burst mode
	var settings = new SharpSerializerBinarySettings(BinarySerializationMode.SizeOptimized);
	var sizeOptimizedSerializer2 = new SharpSerializer(settings);
```






## Using custom serializer and custom deserializer ##

### Creating Serializer ###

The namespace Polenter.Serialization.Advanced contains some classes which are 
indispensable during serialization.

#### XmlPropertySerializer ####

serializes objects into a tree oriented structure, where every element has its beginning 
and end. XmlPropertySerializer is not responsible for serializing to xml. Instead it uses 
an instance of IXmlWriter to access the serialization stream.

DefaultXmlWriter implements IXmlWriter and contains the build in .NET XmlWriter which is 
responsible for writing to a stream.

To make your own tree oriented writer, you make a class which implements IXmlWriter

```csharp
	Polenter.Serialization.Advanced.Xml.IXmlWriter
				  jsonWriter = new MyJsonWriter();

```


this writer is passed to the constructor of the XmlPropertySerializer

```csharp
Polenter.Serialization.Advanced.Serializing.IPropertySerializer 
				  serializer = new Polenter.Serialization.Advanced.XmlPropertySerializer(jsonWriter);
```

with this strategy pattern, the default XmlPropertySerializer can store data 
in any format which is tree oriented (contains begin/end tags)


#### BinaryPropertySerializer ####

serializes objects into elements with known length and fixed position in the stream. 
It doesn't write directly to the stream. Instead, it uses an instance of IBinaryWriter.

Actually there are two writers used by the SharpSerializer: BurstBinaryWriter and 
SizeOptimizedBinaryWriter

To make your own binary writer you make a class which implements IBinaryWriter.

```csharp
Polenter.Serialization.Advanced.Binary.IBinaryWriter 
				  compressedWriter = new MyVeryStrongCompressedAndEncryptedBinaryWriter();
```
this writer is passed to the constructor of the BinaryPropertySerializer

```csharp
		serializer = new Polenter.Serialization.Advanced.BinaryPropertySerializer(compressedWriter);
```



### Creating Deserializer ###

The namespace Polenter.Serialization.Advanced contains classes which are counterparts 
of the above serializers/writers:



*	XmlPropertySerializer	XmlPropertyDeserializer
*	DefaultXmlWriter	DefaultXmlReader
*	BurstBinaryWriter	BurstBinaryReader
*	SizeOptimizedBinaryWriter	SizeOptimizedBinaryReader



Syntax of creating Deserializers/Readers is analog to creating the Serializers/Writers, i.e.

```csharp
	Polenter.Serialization.Advanced.Binary.IBinaryReader
				 compressedReader = new MyVeryStrongCompressedAndEncryptedBinaryReader();

	Polenter.Serialization.Advanced.Deserializing.IPropertyDeserializer
				  deserializer = new Polenter.Serialization.Advanced.BinaryPropertyDeserializer(compressedReader);
```


### Overriding the default Serializer and Deserializer ###

The last step is creating SharpSerializer with an overloaded constructor

```csharp
	var sharpSerializer = new SharpSerializer(serializer, deserializer);
```

Changing only reader and writer in fixed serializer and deserializer is very easy extensibility 
model allowing serialization to/from almost any data format.








## More samples ##

```csharp
		public static void SerializeSharpSerializerBinary(Person p)
		{
			// create instance of sharpSerializer
			// true - binary serialization, false - xml serialization
			var serializer = new Polenter.Serialization.SharpSerializer(true);

			// serialize
			serializer.Serialize(p, "Person.SharpSerializer.bin");

			return;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="p"></param>
		public static void SerializeSharpSerializerXml(Person p)
		{
			// create instance of sharpSerializer
			// true - binary serialization, false - xml serialization
			var serializer = new Polenter.Serialization.SharpSerializer(false);

			// serialize
			serializer.Serialize(p, "Person.SharpSerializer.xml");

			return;
		}


		public static Person DeserializeSharpSerializerBinary()
		{
			Person p = default(Person);

			// create instance of sharpSerializer
			// true - binary serialization, false - xml serialization
			var serializer = new Polenter.Serialization.SharpSerializer(true);

			// deserialize
			p = (Person) serializer.Deserialize("Person.SharpSerializer.bin");

			return p;
		}

		public static Person DeserializeSharpSerializerXml()
		{
			Person p = default(Person);

			// create instance of sharpSerializer
			// true - binary serialization, false - xml serialization
			var serializer = new Polenter.Serialization.SharpSerializer(false);

			// deserialize
			p = (Person)serializer.Deserialize("Person.SharpSerializer.xml");

			return p;
		}

```

## Other Resources ##

* 	[http://sharpserializer.codeplex.com](http://sharpserializer.codeplex.com)
* 	[http://www.sharpserializer.com](http://www.sharpserializer.com)
* 	[http://holisticware.net](http://holisticware.net)
