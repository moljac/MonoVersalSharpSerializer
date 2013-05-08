using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;


namespace HelloWorldApp
{
	public partial class Form1 : PhoneApplicationPage
	{
		// Constructor
		public Form1()
		{
			InitializeComponent();
		}

		# region    Platform dependant code (port needed)
		//-------------------------------------------------------------------------
		//private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		//{
		//	Navigate("http://www.sharpserializer.com");
		//}
		//-------------------------------------------------------------------------
		private void buttonForm2_Click(object sender, EventArgs e)
		{
			NavigateToFormSimpleSample();

			return;
		}
		//-------------------------------------------------------------------------
		private static void NavigateToFormSimpleSample()
		{
			// FormSimpleSample f = new FormSimpleSample();
			// f.Show();

			Uri uri_next = new Uri("/FormSimpleSample.xaml", UriKind.Relative);
			(Application.Current.RootVisual as PhoneApplicationFrame).Navigate(uri_next); 

			return;
		}
		//-------------------------------------------------------------------------
		// For showing 
		//		WF messages 
		//		Android Alerts
		//		iOS ???
		private void ShowMessageAlert(object sender, EventArgs e)
		{
			// MessageBox.Show(SerializationMessage);
			MessageBox.Show("SerializationMessage TODO");

			return;
		}
		//-------------------------------------------------------------------------
		# endregion Platform dependant code (port needed)
	}
}