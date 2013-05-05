using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using HelloWorldApp.BusinessObjects;

namespace HelloWorldApp
{
	public partial class FormSimpleSample
	{

		private void buttonLoad_Click(object sender, EventArgs e)
		{
			object o = comboBoxFormats.SelectedItem;

			if (null == o)
			{
				return;
			}
			else
			{
				Person p = null;
				string name = comboBoxFormats.SelectedItem.ToString();

				switch (name)
				{
					case "Binary Formatter":
						p = ControllerPersonOperations.DeserializeBinaryFormatter();
						break;
					case "XmlSerializer":
						p = ControllerPersonOperations.DeserializeXmlSerializer();
						break;
					case "SharpSerializer Binary":
						p = ControllerPersonOperations.DeserializeSharpSerializerBinary();
						break;
					case "SharpSerializer Xml":
						p = ControllerPersonOperations.DeserializeSharpSerializerXml();
						break;
					default:
						return;
					//break;
				}

				UIFromObject(p);
			}

			return;
		}


		private void buttonSave_Click(object sender, EventArgs e)
		{
			object o = comboBoxFormats.SelectedItem;

			if (null == o)
			{
				return;
			}
			else
			{
				Person p = UIToObject();

				string name = comboBoxFormats.SelectedItem.ToString();

				switch (name)
				{
					case "Binary Formatter":
						ControllerPersonOperations.SerializeBinaryFormatter(p);
						break;
					case "XmlSerializer":
						ControllerPersonOperations.SerializeXmlSerializer(p);
						break;
					case "SharpSerializer Binary":
						ControllerPersonOperations.SerializeSharpSerializerBinary(p);
						break;
					case "SharpSerializer Xml":
						ControllerPersonOperations.SerializeSharpSerializerXml(p);
						break;
					default:
						return;
					//break;
				}

			}

			return;
		}


		private void buttonClear_Click(object sender, EventArgs e)
		{
			Person p = null;
			UIFromObject(p);

			return;
		}
	}
}