using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


using HelloWorldApp.BusinessObjects;

namespace HelloWorldApp
{
	public partial class FormContentPresenter : Form
	{
		public FormContentPresenter(string name)
		{
			InitializeComponent();

			string filename = "";
			switch (name)
			{
				case "Binary Formatter":
					filename = "Person.bin";
					break;
				case "XmlSerializer":
					filename = "Person.xml";
					break;
				case "SharpSerializer Binary":
					filename = "Person.SharpSerializer.bin";
					break;
				case "SharpSerializer Xml":
					filename = "Person.SharpSerializer.xml";
					break;
				default:
					return;
				//break;
			}


			byte[] bytes = null;
			if ("" != filename)
			{
				bytes = ControllerPersonOperations.Deserialize(filename);
			}

			string content = System.Text.Encoding.UTF8.GetString(bytes);
			textBoxContent.Text = content;

			return;
		}
	}
}
