using System;
using System.Collections.Generic;
using System.Text;


using System.IO;

namespace HelloWorldApp.BusinessObjects
{
	public partial class ControllerPersonOperations
	{
		public static string StorageRoot = "";

		public static byte[] Read(string filename)
		{
			string path_combined = Path.Combine(ControllerPersonOperations.StorageRoot, filename);

			if (!File.Exists(path_combined))
			{
				return null;
			}

			FileStream file = new FileStream
									(
									  path_combined
									, FileMode.Open
									, FileAccess.Read
									);
			byte[] bytes = new byte[file.Length];
			file.Read(bytes, 0, (int)file.Length);

			MemoryStream ms = new MemoryStream();
			ms.Write(bytes, 0, (int)file.Length);
			file.Close();
			ms.Close();

			return bytes;
		}

		public static void Write(MemoryStream ms, string filename)
		{
			FileStream file = new FileStream
									(
									  Path.Combine(ControllerPersonOperations.StorageRoot, filename)
									, FileMode.Create
									, System.IO.FileAccess.Write
									);
			byte[] bytes = ms.ToArray();
			file.Write(bytes, 0, bytes.Length);
			file.Close();
			ms.Close();

			string content = 
				// System.Text.Encoding.UTF8.GetString(bytes)  // WP lacks this
				System.Text.Encoding.UTF8.GetString(bytes,0,bytes.Length)
				;

			return;
		}

	}
}
