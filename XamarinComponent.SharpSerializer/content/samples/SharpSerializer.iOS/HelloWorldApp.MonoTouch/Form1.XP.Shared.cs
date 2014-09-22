using System;
using System.IO;
using Polenter.Serialization;
using System.Diagnostics;
using HelloWorldApp.BusinessObjects;
using System.Collections.Generic;

namespace HelloWorldApp
{
	/// <summary>
	/// Cross Platform shareable code
	/// no platform specific stuff
	/// 
	/// UI Controls/Views/Widget names:
	///		used:
	///			Button		serializeXmlButton
	///			Button		serializeBurstBinary
	///			Button		serializeSizeOptimizedBinary
	///		unused:
	///			linkLabel1
	///			label1
	///			label2
	///			label3
	/// </summary>
	public partial class Form1
	{
		private string serialize(object obj, SharpSerializer serializer, string shortFilename)
		{
			// Serializing the first object
			var file1 = getFullFilename(shortFilename, "1");
			serializer.Serialize(obj, file1);

			// Deserializing to a second object
			var obj2 = serializer.Deserialize(file1);

			// Serializing the second object
			var file2 = getFullFilename(shortFilename, "2");
			serializer.Serialize(obj2, file2);

			// Comparing two files
			string retval = compareTwoFiles(file1, file2);

			// Show files in explorer
			showInExplorer(file1);

			return retval;
		}



		private static string getFullFilename(string shortFilename, string nameSufix)
		{
			// original
			//var folder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

			// do not want to spit all over the desktop (there is no desktop in mobile)
			//
			var folder = 
					Environment.GetFolderPath(Environment.SpecialFolder.Personal)
					//@"."	// Android Access Denied
					;
			ControllerPersonOperations.StorageRoot = folder;

			var filenameWithoutExtension = string.Format("{0}{1}", Path.GetFileNameWithoutExtension(shortFilename),
														 nameSufix);
			var filenameWithExtension = Path.ChangeExtension(filenameWithoutExtension, Path.GetExtension(shortFilename));
			return Path.Combine(folder, filenameWithExtension);
		}




		public void serializeXmlButton_Click(object sender, EventArgs e)
		{
			// create fake obj
			var obj = RootContainer.CreateFakeRoot();

			// create instance of sharpSerializer
			// with the standard constructor it serializes to xml
			var serializer = new SharpSerializer();


			// *************************************************************************************
			// For advanced serialization you create SharpSerializer with an overloaded constructor
			//
			//  SharpSerializerXmlSettings settings = createXmlSettings();
			//  serializer = new SharpSerializer(settings);
			//
			// Scroll the page to the createXmlSettings() method for more details
			// *************************************************************************************


			// *************************************************************************************
			// You can alter the SharpSerializer with its settings, you can provide your custom readers
			// and writers as well, to serialize data into Json or other formats.
			//
			// var serializer = createSerializerWithCustomReaderAndWriter();
			//
			// Scroll the page to the createSerializerWithCustomReaderAndWriter() method for more details
			// *************************************************************************************


			// set the filename
			var filename = "sharpSerializerExample.xml";

			// serialize
			SerializationMessage = serialize(obj, serializer, filename);

			//IKI: iOS UIAlertView
			ShowMessageAlert (this, null);
			

			return;
		}

		string SerializationMessage = default(string);

		public void serializeSizeOptimizedBinary_Click(object sender, EventArgs e)
		{
			// create fake obj
			var obj = RootContainer.CreateFakeRoot();

			// create instance of sharpSerializer
			var serializer = new SharpSerializer(true);


			// *************************************************************************************
			// For advanced serialization you create SharpSerializer with an overloaded constructor
			//
			//  SharpSerializerBinarySettings settings = createBinarySettings();
			//  serializer = new SharpSerializer(settings);
			//
			// Scroll the page to the createBinarySettings() method for more details
			// *************************************************************************************


			// set the filename
			var filename = "sharpSerializerExample.sizeOptimized";

			// serialize
			SerializationMessage = serialize(obj, serializer, filename);

			//IKI: iOS UIAlertView
			ShowMessageAlert(this, null);

			return;
		}

		public void serializeBurstBinary_Click(object sender, EventArgs e)
		{
			// create fake obj
			var obj = RootContainer.CreateFakeRoot();

			// create instance of sharpSerializer
			var settings = new SharpSerializerBinarySettings(BinarySerializationMode.Burst);
			var serializer = new SharpSerializer(settings);


			// *************************************************************************************
			// For advanced serialization you create SharpSerializer with an overloaded constructor
			//
			//  SharpSerializerBinarySettings settings = createBinarySettings();
			//  serializer = new SharpSerializer(settings);
			//
			// Scroll the page to the createBinarySettings() method for more details
			// *************************************************************************************


			// set the filename
			var filename = "sharpSerializerExample.burst";

			// serialize
			SerializationMessage = serialize(obj, serializer, filename);

			//IKI: iOS UIAlertView
			ShowMessageAlert(this, null);

			return;
		}

	}
}