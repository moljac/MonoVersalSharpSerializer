using System;
using System.Collections.Generic;
using System.Text;


using System.IO;

namespace HelloWorldApp.BusinessObjects
{
	public partial class ControllerPersonOperations
	{
		static string path_root = 
			Environment.GetFolderPath(Environment.SpecialFolder.Personal)
			// "" // application folder or bundle, package, XAP, ipa, apk
			;

		public static void SerializeBinaryFormatter(Person p)
		{
			using (var ms = new MemoryStream())
			{
				var ser = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
				ser.Serialize(ms, p);

				Write(ms, Path.Combine(path_root, "Person.bin"));
			}

			return;
		}


		public static void SerializeXmlSerializer(Person p)
		{
			using (var ms = new MemoryStream())
			{
				var ser = new System.Xml.Serialization.XmlSerializer(typeof(Person));
				ser.Serialize(ms, p);

				Write(ms, Path.Combine(path_root, "Person.xml"));
			}

			return;
		}


		public static Person DeserializeBinaryFormatter()
		{
			Person p = default(Person);

			byte[] bytes = Read(Path.Combine(path_root, "Person.bin"));

			if (null == bytes)
			{
				return default(Person);
			}

			using (var ms = new MemoryStream(bytes))
			{
				var ser = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
				p = (Person)ser.Deserialize(ms);
			}

			return p;
		}

		public static Person DeserializeXmlSerializer()
		{
			Person p = default(Person);

			byte[] bytes = Read(Path.Combine(path_root, "Person.xml"));

			using (var ms = new MemoryStream(bytes))
			{
				var ser = new System.Xml.Serialization.XmlSerializer(typeof(Person));
				p = (Person)ser.Deserialize(ms);
			}

			return p;
		}




		public static string LoadFileTextual(string name)
		{
			string filename = "";
			switch (name)
			{
				case "Binary Formatter":
					filename = Path.Combine(path_root,"Person.bin");
					break;
				case "XmlSerializer":
					filename = Path.Combine(path_root,"Person.xml");
					break;
				case "SharpSerializer Binary":
					filename = Path.Combine(path_root,"Person.SharpSerializer.bin");
					break;
				case "SharpSerializer Xml":
					filename = Path.Combine(path_root,"Person.SharpSerializer.xml");
					break;
				default:
					return "Please choose serialization/deserialization type!!";
				//break;
			}

			string content = "N/A";
			try
			{
				byte[] bytes = null;
				if ("" != filename)
				{
					bytes = ControllerPersonOperations.Read(filename);
				}

				content = System.Text.Encoding.UTF8.GetString(bytes);
			}
			catch (System.Exception exc)
			{
				content = exc.Message;
			}

			return content;
		}
	
	
	}
}
