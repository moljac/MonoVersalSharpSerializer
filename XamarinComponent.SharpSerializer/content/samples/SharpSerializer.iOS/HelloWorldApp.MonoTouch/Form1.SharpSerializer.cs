using System;
using System.IO;


using System.Collections.Generic;
using Polenter.Serialization;

namespace HelloWorldApp
{
	public partial class Form1
	{
		private SharpSerializerXmlSettings createXmlSettings()
		{
			// create the settings instance
			var settings = new SharpSerializerXmlSettings();

			// Bare instance of SharpSerializerXmlSettings is enough for SharpSerializer to know, 
			// it should serialize data as xml. 

			// However there is more you can influence.


			// Culture
			// All float numbers and date/time values are serialized as text according to the Culture.
			// The default Culture is InvariantCulture but you can override this settings with your own culture.
			settings.Culture = System.Globalization.CultureInfo.CurrentCulture;


			TextEncoding(settings);


			// AssemblyQualifiedName
			// During serialization all types must be converted to strings. 
			// Since v.2.12 the type is stored as an AssemblyQualifiedName per default.
			// You can force the SharpSerializer to shorten the type descriptions
			// by setting the following properties to false
			// Example of AssemblyQualifiedName:
			// "System.String, mscorlib, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
			// Example of the short type name:
			// "System.String, mscorlib"
			settings.IncludeAssemblyVersionInTypeName = true;
			settings.IncludeCultureInTypeName = true;
			settings.IncludePublicKeyTokenInTypeName = true;



			// ADVANCED SETTINGS
			// Most of the classes needed to alter these settings are in the namespace Polenter.Serialization.Advanced


			// PropertiesToIgnore
			// Sometimes you want to ignore some properties during the serialization.
			// If they are parts of your own business objects, you can mark these properties with ExcludeFromSerializationAttribute. 
			// However it is not possible to mark them in the built in .NET classes
			// In such a case you add these properties to the list PropertiesToIgnore.
			// I.e. System.Collections.Generic.List<string> has the "Capacity" property which is irrelevant for
			// the whole Serialization and should be ignored
			// serializer.PropertyProvider.PropertiesToIgnore.Add(typeof(List<string>), "Capacity")
			settings.AdvancedSettings.PropertiesToIgnore.Add(typeof(List<string>), "Capacity");


			// RootName
			// There is always a root element during serialization. Default name of this element is "Root", 
			// but you can change it to any other text.
			settings.AdvancedSettings.RootName = "MyFunnyClass";


			// SimpleValueConverter
			// During xml serialization all simple values are converted to their string representation.
			// Float values, DateTime are default converted to format of the settings.Culture or CultureInfo.InvariantCulture
			// if the settings.Culture is not set.
			// If you want to store these values in your own format (Morse alphabet?) create your own converter as an instance of ISimpleValueConverter.
			// Important! This setting overrides the settings.Culture
			settings.AdvancedSettings.SimpleValueConverter = new MyCustomSimpleValueConverter();



			// TypeNameConverter
			// Since the v.2.12 all types are serialized as AssemblyQualifiedName.
			// To change this you can alter the settings above (Include...) or create your own instance of ITypeNameConverter.
			// Important! This property overrides the three properties below/above: 
			//    IncludeAssemblyVersionInTypeName, IncludeCultureInTypeName, IncludePublicKeyTokenInTypeName            
			settings.AdvancedSettings.TypeNameConverter = new MyTypeNameConverterWithCompressedTypeNames();


			return settings;
		}


		private SharpSerializerBinarySettings createBinarySettings()
		{
			// create the settings instance
			var settings = new SharpSerializerBinarySettings();

			// bare instance of SharpSerializerBinarySettings tells SharpSerializer to serialize data into binary format in the SizeOptimized mode

			// However there is more possibility to influence the serialization


			TextEncoding(settings);

			// AssemblyQualifiedName
			// During serialization all types must be converted to strings. 
			// Since v.2.12 the type is stored as an AssemblyQualifiedName per default.
			// You can force the SharpSerializer to shorten the type descriptions
			// by setting the following properties to false
			// Example of AssemblyQualifiedName:
			// "System.String, mscorlib, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
			// Example of the short type name:
			// "System.String, mscorlib"
			settings.IncludeAssemblyVersionInTypeName = true;
			settings.IncludeCultureInTypeName = true;
			settings.IncludePublicKeyTokenInTypeName = true;


			// Mode
			// The default mode, without altering the settings, is BinarySerializationMode.SizeOptimized
			// Actually you can choose another mode - BinarySerializationMode.Burst
			//
			// What is the difference?
			// To successfully restore the object tree from the serialized stream, all objects have to be serialized including their type information.
			// Both modes differ in the art the type information is stored.
			//
			// BinarySerializationMode.Burst
			// In the burst mode, type of every object is serialized as a string as part of this object. 
			// It doesn't matter if all serialized objects are of the same type, their types are serialized as text as many times as many objects.
			// It increases the file size especially when serializing collections. Type information is duplicated. 
			// It's ok for single, simple objects, as it has small overhead. BurstBinaryWriter supports this mode.
			//
			// BinarySerializationMode.SizeOptimized
			// In the SizeOptimized mode all types are grouped into a list. All type duplicates are removed. 
			// Serialized objects refer only to this list using index of their type. It's recommended approach for serializing of complex 
			// objects with many properties, or many items of the same type (collections). The drawback is - all objects are cached,
			// then their types are analysed, type list is created, objects are injected with indexes and finally the data is written. 
			// Apart from types, all property names are handled the same way in the SizeOptimized mode.
			// SizeOptimizedBinaryWriter supports this mode.            
			settings.Mode = BinarySerializationMode.SizeOptimized;



			// ADVANCED SETTINGS
			// Most of the classes needed to alter these settings are in the namespace Polenter.Serialization.Advanced


			// PropertiesToIgnore
			// Sometimes you want to ignore some properties during the serialization.
			// If they are parts of your own business objects, you can mark these properties with ExcludeFromSerializationAttribute. 
			// However it is not possible to mark them in the built in .NET classes
			// In such a case you add these properties to the list PropertiesToIgnore.
			// I.e. System.Collections.Generic.List<string> has the "Capacity" property which is irrelevant for
			// the whole Serialization and should be ignored
			// serializer.PropertyProvider.PropertiesToIgnore.Add(typeof(List<string>), "Capacity")
			settings.AdvancedSettings.PropertiesToIgnore.Add(typeof(List<string>), "Capacity");


			// RootName
			// There is always a root element during the serialization. Default name of this element is "Root", 
			// but you can change it to any other text.
			settings.AdvancedSettings.RootName = "MyFunnyClass";


			// TypeNameConverter
			// Since the v.2.12 all types are serialized as AssemblyQualifiedName.
			// To change this you can alter the settings above (Include...) or create your own instance of ITypeNameConverter.
			// Important! This property overrides the three properties below/above: 
			//    IncludeAssemblyVersionInTypeName, IncludeCultureInTypeName, IncludePublicKeyTokenInTypeName            
			settings.AdvancedSettings.TypeNameConverter = new MyTypeNameConverterWithCompressedTypeNames();


			return settings;
		}

		private SharpSerializer createSerializerWithCustomReaderAndWriter()
		{
			// *************************************************************************************
			// SERIALIZATION
			// The namespace Polenter.Serialization.Advanced contains some classes which are indispensable during the serialization.


			// *************************************************************************************
			// XmlPropertySerializer
			// serializes objects into elements and their attributes. 
			// Each element has its begin and end tag.
			// XmlPropertySerializer self is not responsible for the serializing to xml, it doesn't reference the built in .NET XmlWriter.
			// Instead it uses an instance of IXmlWriter to control the element writing. 
			// DefaultXmlWriter implements IXmlWriter and contains the build in .NET XmlWriter which is responsible for writing to the stream.

			// To make your own node oriented writer, you need to make a class which implements IXmlWriter 
			Polenter.Serialization.Advanced.Xml.IXmlWriter jsonWriter = new MyJsonWriter();

			// this writer is passed to the constructor of the XmlPropertySerializer
			Polenter.Serialization.Advanced.Serializing.IPropertySerializer serializer =
				new Polenter.Serialization.Advanced.XmlPropertySerializer(jsonWriter);

			// in such a was, the default XmlPropertySerializer can store data in any format which is node oriented (contains begin/end tags)


			// *************************************************************************************
			// BinaryPropertySerializer
			// serializes objects into elements which have known length and fixed position in the stream. 
			// It doesn't write directly to the stream. Instead, it uses an instance of IBinaryWriter. 
			// Actually there are two writers used by the SharpSerializer: BurstBinaryWriter and SizeOptimizedBinaryWriter 

			// To make your own binary writer you make a class which implements the IBinaryWriter.
			Polenter.Serialization.Advanced.Binary.IBinaryWriter compressedWriter = new MyVeryStrongCompressedAndEncryptedBinaryWriter();

			// this writer is passed to the constructor of the BinaryPropertySerializer
			serializer = new Polenter.Serialization.Advanced.BinaryPropertySerializer(compressedWriter);

			// Changing only the writer and not the whole serializer allows an easy serialization of data to any binary format



			// *************************************************************************************
			// DESERIALIZATION
			// The namespace Polenter.Serialization.Advanced contains classes which are counterparts of the above serializers/writers
			// XmlPropertySerializer -> XmlPropertyDeserializer
			// DefaultXmlWriter -> DefaultXmlReader
			// BurstBinaryWriter -> BurstBinaryReader
			// SizeOptimizedBinaryWriter -> SizeOptimizedBinaryReader

			// Deserializers are constructed analog or better say - symmetric to the Serializers/Writers, i.e.

			Polenter.Serialization.Advanced.Binary.IBinaryReader compressedReader =
				new MyVeryStrongCompressedAndEncryptedBinaryReader();

			Polenter.Serialization.Advanced.Deserializing.IPropertyDeserializer deserializer =
				new Polenter.Serialization.Advanced.BinaryPropertyDeserializer(compressedReader);

			// If you have created serializer and deserializer, the next step is to create SharpSerializer.


			// *************************************************************************************
			// Creating SharpSerializer
			// Both classes - serializer and deserializer are passed to the overloaded constructor

			var sharpSerializer = new SharpSerializer(serializer, deserializer);


			// there is one more option you can alter directly on your instance of SharpSerializer

			// *************************************************************************************
			// PropertyProvider
			// If the advanced setting PropertiesToIgnore are not enough there is possibility to create your own PropertyProvider
			// As a standard there are only properties serialized which:
			// - are public
			// - are not static
			// - does not contain ExcludeFromSerializationAttribute
			// - have their set and get accessors
			// - are not indexers
			// - are not in PropertyProvider.PropertiesToIgnore
			// You can replace this functionality with an inheritor class of PropertyProvider

			sharpSerializer.PropertyProvider = new MyVerySophisticatedPropertyProvider();

			// Override its methods GetAllProperties() and IgnoreProperty to customize the functionality

			return sharpSerializer;
		}





		# region    Helper Classes
		//-------------------------------------------------------------------------
		/// <summary>
		/// It's only a fake class!
		/// </summary>
		private class MyCustomSimpleValueConverter : Polenter.Serialization.Advanced.Xml.ISimpleValueConverter
		{
			/// <summary>
			/// </summary>
			/// <param name = "value"></param>
			/// <returns>string.Empty if the value is null</returns>
			public string ConvertToString(object value)
			{
				throw new NotImplementedException();
			}

			/// <summary>
			/// </summary>
			/// <param name = "text"></param>
			/// <param name = "type">expected type. Result should be of this type.</param>
			/// <returns>null if the text is null</returns>
			public object ConvertFromString(string text, Type type)
			{
				throw new NotImplementedException();
			}
		}

		/// <summary>
		/// It's only a fake class!
		/// </summary>
		private class MyTypeNameConverterWithCompressedTypeNames : Polenter.Serialization.Advanced.Serializing.ITypeNameConverter
		{
			/// <summary>
			///   Gives back Type as text.
			/// </summary>
			/// <param name = "type"></param>
			/// <returns>string.Empty if the type is null</returns>
			public string ConvertToTypeName(Type type)
			{
				throw new NotImplementedException();
			}

			/// <summary>
			///   Gives back Type from the text.
			/// </summary>
			/// <param name = "typeName"></param>
			/// <returns></returns>
			public Type ConvertToType(string typeName)
			{
				throw new NotImplementedException();
			}
		}

		/// <summary>
		/// It's only a fake class!
		/// </summary>
		private class MyJsonWriter : Polenter.Serialization.Advanced.Xml.IXmlWriter
		{
			///<summary>
			///  Writes start tag/node/element
			///</summary>
			///<param name = "elementId"></param>
			public void WriteStartElement(string elementId)
			{
				throw new NotImplementedException();
			}

			///<summary>
			///  Writes end tag/node/element
			///</summary>
			public void WriteEndElement()
			{
				throw new NotImplementedException();
			}

			///<summary>
			///  Writes attribute of type string
			///</summary>
			///<param name = "attributeId"></param>
			///<param name = "text"></param>
			public void WriteAttribute(string attributeId, string text)
			{
				throw new NotImplementedException();
			}

			///<summary>
			///  Writes attribute of type Type
			///</summary>
			///<param name = "attributeId"></param>
			///<param name = "type"></param>
			public void WriteAttribute(string attributeId, Type type)
			{
				throw new NotImplementedException();
			}

			///<summary>
			///  Writes attribute of type integer
			///</summary>
			///<param name = "attributeId"></param>
			///<param name = "number"></param>
			public void WriteAttribute(string attributeId, int number)
			{
				throw new NotImplementedException();
			}

			///<summary>
			///  Writes attribute of type array of int
			///</summary>
			///<param name = "attributeId"></param>
			///<param name = "numbers"></param>
			public void WriteAttribute(string attributeId, int[] numbers)
			{
				throw new NotImplementedException();
			}

			///<summary>
			///  Writes attribute of a simple type (value of a SimpleProperty)
			///</summary>
			///<param name = "attributeId"></param>
			///<param name = "value"></param>
			public void WriteAttribute(string attributeId, object value)
			{
				throw new NotImplementedException();
			}

			///<summary>
			///  Opens the stream
			///</summary>
			///<param name = "stream"></param>
			public void Open(Stream stream)
			{
				throw new NotImplementedException();
			}

			/// <summary>
			///   Writes all data to the stream, the stream can be further used.
			/// </summary>
			public void Close()
			{
				throw new NotImplementedException();
			}
		}

		/// <summary>
		/// It's only a fake class!
		/// </summary>
		private class MyVeryStrongCompressedAndEncryptedBinaryWriter : Polenter.Serialization.Advanced.Binary.IBinaryWriter
		{
			/// <summary>
			///   Writes Element Id
			/// </summary>
			/// <param name = "id"></param>
			public void WriteElementId(byte id)
			{
				throw new NotImplementedException();
			}

			/// <summary>
			///   Writes type
			/// </summary>
			/// <param name = "type"></param>
			public void WriteType(Type type)
			{
				throw new NotImplementedException();
			}

			/// <summary>
			///   Writes property name
			/// </summary>
			/// <param name = "name"></param>
			public void WriteName(string name)
			{
				throw new NotImplementedException();
			}

			/// <summary>
			///   Writes a simple value (value of a simple property)
			/// </summary>
			/// <param name = "value"></param>
			public void WriteValue(object value)
			{
				throw new NotImplementedException();
			}

			/// <summary>
			///   Writes an integer. It saves the number with the least required bytes
			/// </summary>
			/// <param name = "number"></param>
			public void WriteNumber(int number)
			{
				throw new NotImplementedException();
			}

			/// <summary>
			///   Writes an array of numbers. It saves numbers with the least required bytes
			/// </summary>
			/// <param name = "numbers"></param>
			public void WriteNumbers(int[] numbers)
			{
				throw new NotImplementedException();
			}

			/// <summary>
			///   Opens the stream for writing
			/// </summary>
			/// <param name = "stream"></param>
			public void Open(Stream stream)
			{
				throw new NotImplementedException();
			}

			/// <summary>
			///   Saves the data to the stream, the stream is not closed and can be further used
			/// </summary>
			public void Close()
			{
				throw new NotImplementedException();
			}
		}

		/// <summary>
		/// It's only a fake class!
		/// </summary>
		private class MyVeryStrongCompressedAndEncryptedBinaryReader : Polenter.Serialization.Advanced.Binary.IBinaryReader
		{
			/// <summary>
			///   Reads single byte
			/// </summary>
			/// <returns></returns>
			public byte ReadElementId()
			{
				throw new NotImplementedException();
			}

			/// <summary>
			///   Read type
			/// </summary>
			/// <returns>null if no type defined</returns>
			public Type ReadType()
			{
				throw new NotImplementedException();
			}

			/// <summary>
			///   Read integer which was saved as 1,2 or 4 bytes, according to its size
			/// </summary>
			/// <returns></returns>
			public int ReadNumber()
			{
				throw new NotImplementedException();
			}

			/// <summary>
			///   Read array of integers which were saved as 1,2 or 4 bytes, according to their size
			/// </summary>
			/// <returns>empty array if no numbers defined</returns>
			public int[] ReadNumbers()
			{
				throw new NotImplementedException();
			}

			/// <summary>
			///   Reads property name
			/// </summary>
			/// <returns>null if no name defined</returns>
			public string ReadName()
			{
				throw new NotImplementedException();
			}

			/// <summary>
			///   Reads simple value (value of a simple property)
			/// </summary>
			/// <param name = "expectedType"></param>
			/// <returns>null if no value defined</returns>
			public object ReadValue(Type expectedType)
			{
				throw new NotImplementedException();
			}

			/// <summary>
			///   Opens the stream for reading
			/// </summary>
			/// <param name = "stream"></param>
			public void Open(Stream stream)
			{
				throw new NotImplementedException();
			}

			/// <summary>
			///   Does nothing, the stream can be further used and has to be manually closed
			/// </summary>
			public void Close()
			{
				throw new NotImplementedException();
			}
		}

		/// <summary>
		/// It's only a fake class!
		/// </summary>
		private class MyVerySophisticatedPropertyProvider : Polenter.Serialization.Advanced.PropertyProvider
		{
		}
		//-------------------------------------------------------------------------
		# endregion Helper Classes
		
	
	}
}