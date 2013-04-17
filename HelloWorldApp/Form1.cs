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
		}

		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Navigate("http://www.sharpserializer.com");
		}

	}
}