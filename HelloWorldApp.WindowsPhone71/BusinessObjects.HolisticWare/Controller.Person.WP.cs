using System;
using System.Collections.Generic;
using System.Text;


using System.IO;

namespace HelloWorldApp.BusinessObjects
{
	public partial class ControllerPersonOperations
	{

		public static void SerializeBinaryFormatter(Person p)
		{
			// using (var ms = new MemoryStream())
			// {
			// 	var ser = new System.Runtime.Serialization.ormatters.Binary.BinaryFormatter();
			// 	ser.Serialize(ms, p);
			// 
			// 	Write(ms, "Person.bin");
			// }

			return;
		}


		public static void SerializeXmlSerializer(Person p)
		{
			using (var ms = new MemoryStream())
			{
				var ser = new System.Xml.Serialization.XmlSerializer(typeof(Person));
				ser.Serialize(ms, p);
			
				Write(ms, "Person.xml");
			}

			return;
		}


		public static Person DeserializeBinaryFormatter()
		{
			Person p = default(Person);

			// byte[] bytes = Read("Person.bin");
			// 
			// using (var ms = new MemoryStream(bytes))
			// {
			// 	var ser = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
			// 	p = (Person)ser.Deserialize(ms);
			// }

			return p;
		}

		public static Person DeserializeXmlSerializer()
		{
			Person p = default(Person);

			byte[] bytes = Read("Person.xml");

			using (var ms = new MemoryStream(bytes))
			{
				var ser = new System.Xml.Serialization.XmlSerializer(typeof(Person));
				p = (Person)ser.Deserialize(ms);
			}

			return p;
		}
	}
}
