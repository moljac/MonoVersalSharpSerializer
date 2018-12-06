using System;
using System.Collections.Generic;
using System.Text;


using System.IO;

namespace HelloWorldApp.BusinessObjects
{
	/// <summary>
	/// 
	/// </summary>
	/// <see cref="http://www.sharpserializer.com/en/tutorial/index.html"/>
	public partial class ControllerPersonOperations
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="person"></param>
		public static void SerializeSharpSerializerBinary(Person p)
		{
			// create instance of sharpSerializer
			// true - binary serialization, false - xml serialization
			var serializer = new Polenter.Serialization.SharpSerializer(true);

			// serialize
			serializer.Serialize(p, Path.Combine(path_root, "Person.SharpSerializer.bin"));

			return;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="person"></param>
		public static void SerializeSharpSerializerXml(Person p)
		{
			// create instance of sharpSerializer
			// true - binary serialization, false - xml serialization
			var serializer = new Polenter.Serialization.SharpSerializer(false);

			// serialize
			serializer.Serialize(p, Path.Combine(path_root, "Person.SharpSerializer.xml"));

			return;
		}


		public static Person DeserializeSharpSerializerBinary()
		{
			Person p = default(Person);

			// create instance of sharpSerializer
			// true - binary serialization, false - xml serialization
			var serializer = new Polenter.Serialization.SharpSerializer(true);

			// deserialize
			p = (Person) serializer.Deserialize(Path.Combine(path_root, "Person.SharpSerializer.bin"));

			return p;
		}

		public static Person DeserializeSharpSerializerXml()
		{
			Person p = default(Person);

			// create instance of sharpSerializer
			// true - binary serialization, false - xml serialization
			var serializer = new Polenter.Serialization.SharpSerializer(false);

			// deserialize
			p = (Person)serializer.Deserialize(Path.Combine(path_root, "Person.SharpSerializer.xml"));

			return p;
		}
	}
}
