SharpSerializer fast XML and binary serialization.

Cross-platform port by HolisticWare:

* 	Windows Phone
* 	Xamarin.iOS
* 	Xamarin.Android

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

## Other Resources

* 	[http://sharpserializer.codeplex.com](http://sharpserializer.codeplex.com)
* 	[http://www.sharpserializer.com](http://www.sharpserializer.com)
* 	[http://holisticware.net](http://holisticware.net)
