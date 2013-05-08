using System;
using System.IO;

namespace HelloWorldApp
{
	public partial class Form1
	{
		private static void Navigate(string url)
		{
			System.Diagnostics.Process.Start(url);

			return;
		}
	}
}