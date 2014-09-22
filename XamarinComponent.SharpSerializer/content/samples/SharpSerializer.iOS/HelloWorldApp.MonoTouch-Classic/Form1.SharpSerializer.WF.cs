using System;
using System.IO;

using Polenter.Serialization;

namespace HelloWorldApp
{
	public partial class Form1
	{
		private static void TextEncoding(SharpSerializerXmlSettings settings)
		{
			// Encoding
			// Default Encoding is UTF8. Encoding impacts the format in which the whole Xml file is stored.
			settings.Encoding = System.Text.Encoding.ASCII;

			return;
		}

		private static void TextEncoding(SharpSerializerBinarySettings settings)
		{
			// Encoding
			// Default Encoding is UTF8. 
			// Changing of Encoding has impact on format in which are all strings stored (type names, property names and string values)
			settings.Encoding = System.Text.Encoding.ASCII;
		}

		//-------------------------------------------------------------------------
		private string compareTwoFiles(string file1, string file2)
		{
			string retval = default(string);
			// comparing
			var fileInfo1 = new FileInfo(file1);
			var fileInfo2 = new FileInfo(file2);


			if (fileInfo1.Length > 0 && fileInfo1.Length == fileInfo2.Length)
			{
				byte[] content1 = File.ReadAllBytes(file1);
				byte[] content2 = File.ReadAllBytes(file2);

				for (int i = 0; i < content1.Length; i++)
					if (content1[i] != content2[i])
					{
						//MessageBox.Show(string.Format("Files differ at offset {0}", i));
						retval = string.Format("Files differ at offset {0}", i);
						return retval;
					}

				// MessageBox.Show(string.Format("Both files have the same length of {0} bytes and the same content", fileInfo1.Length));
				retval = string.Format("Both files have the same length of {0} bytes and the same content", fileInfo1.Length);
			}
			else
			{
				//MessageBox.Show(string.Format("Length of file1: {0}, Length of file2: {1}", fileInfo1.Length,
				//							  fileInfo2.Length));
				retval = string.Format("Length of file1: {0}, Length of file2: {1}", fileInfo1.Length, fileInfo2.Length);
			}

			return retval;
		}
	}
}