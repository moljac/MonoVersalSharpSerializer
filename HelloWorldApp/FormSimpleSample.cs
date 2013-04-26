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
	public partial class FormSimpleSample : Form
	{
		public FormSimpleSample()
		{
			InitializeComponent();
		}

		private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
		{
			// http://stackoverflow.com/questions/9/how-do-i-calculate-someones-age
			DateTime birthday = dateTimePicker1.Value;
			int age = new DateTime(DateTime.Now.Subtract(birthday).Ticks).Year - 1;

			textBoxAge.Text = age.ToString();

			return;
		}

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

				this.textBoxNameFirst.Text = p.NameFirst;
				this.textBoxNameLast.Text = p.NameLast;
				this.textBoxAge.Text = p.Age.ToString();
				this.dateTimePicker1.Value = p.DateOfBirth;
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
				Person p = new Person()
				{
				   NameFirst = this.textBoxNameFirst.Text
				 , NameLast = this.textBoxNameLast.Text
				 , DateOfBirth = this.dateTimePicker1.Value
				};

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

		private void buttonOpen_Click(object sender, EventArgs e)
		{
			string name = comboBoxFormats.SelectedItem.ToString();
			FormContentPresenter fcp = new FormContentPresenter(name);
			fcp.Show();

			return;
		}
	}
}
