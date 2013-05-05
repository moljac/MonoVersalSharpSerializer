using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using HelloWorldApp.BusinessObjects;
using Polenter.Serialization;


namespace HelloWorldApp
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();

			// Event chaining Multicast Delegates 
			serializeXmlButton.Click += new EventHandler(ShowMessageAlert);
			serializeBurstBinary.Click += new EventHandler(ShowMessageAlert);
			serializeSizeOptimizedBinary.Click += new EventHandler(ShowMessageAlert);

			return;
		}

		# region    Platform dependant code (port needed)
		//-------------------------------------------------------------------------
		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Navigate("http://www.sharpserializer.com");
		}
		//-------------------------------------------------------------------------
		private void buttonForm2_Click(object sender, EventArgs e)
		{
			NavigateToFormSimpleSample();

			return;
		}
		//-------------------------------------------------------------------------
		private static void NavigateToFormSimpleSample()
		{
			FormSimpleSample f = new FormSimpleSample();
			f.Show();
		}
		//-------------------------------------------------------------------------
		// For showing 
		//		WF messages 
		//		Android Alerts
		//		iOS ???
		private void ShowMessageAlert(object sender, EventArgs e)
		{
			MessageBox.Show(SerializationMessage);

			return;
		}
		//-------------------------------------------------------------------------
		public void showInExplorer(string filename)
		{
			if (!string.IsNullOrEmpty(filename) && File.Exists(filename))
			{
				string arguments = string.Format("/n, /select, \"{0}\"", filename);
				Process.Start("explorer", arguments);
			}
		}
		//-------------------------------------------------------------------------
		# endregion Platform dependant code (port needed)
	}
}