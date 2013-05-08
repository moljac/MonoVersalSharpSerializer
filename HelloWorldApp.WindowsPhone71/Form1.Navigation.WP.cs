using System;
using System.IO;

using System.Windows;
using Microsoft.Phone.Controls;

namespace HelloWorldApp
{
	public partial class Form1
	{
		private static void Navigate(string url)
		{
			// System.Diagnostics.Process.Start(url);
			Uri uri_next = new Uri(url, UriKind.Absolute);
			(Application.Current.RootVisual as PhoneApplicationFrame).Navigate(uri_next); 

			return;
		}
	}
}