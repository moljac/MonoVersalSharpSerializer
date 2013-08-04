# Details #

SharpSerializer fast XML and binary serialization (serialization library) for:

* 	Binary and
*	Xml

Serialization

Succinct code snippet[s] showing the minimum viable integration of the
component into the user's app.


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

Cross-platform port by HolisticWare team:

* 	[http://holisticware.net](http://holisticware.net)



