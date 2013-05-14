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

		# region    Platform dependant code (port needed)
		//-------------------------------------------------------------------------
		Person person = null;
		//-------------------------------------------------------------------------
		private void buttonOpen_Click(object sender, EventArgs e)
		{
			if (null != comboBoxFormats.SelectedItem)
			{
				string name = comboBoxFormats.SelectedItem.ToString();
				FormContentPresenter fcp = new FormContentPresenter(name);
				fcp.Show();
			}

			return;
		}
		//-------------------------------------------------------------------------
		private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
		{
			// http://stackoverflow.com/questions/9/how-do-i-calculate-someones-age
			DateTime birthday = dateTimePicker1.Value;
			int age = new DateTime(DateTime.Now.Subtract(birthday).Ticks).Year - 1;

			textBoxAge.Text = age.ToString();

			return;
		}
		//-------------------------------------------------------------------------
		private Person UIToObject()
		{
			object o = comboBoxFormats.SelectedItem;

			if (null == o)
			{
				return person;
			}
			else
			{
				string name = o.ToString();

				person = new Person()
				{ 
				  NameFirst = this.textBoxNameFirst.Text
				, NameLast = this.textBoxNameLast.Text
				, DateOfBirth = this.dateTimePicker1.Value
				};

				switch (name)
				{
					case "Binary Formatter":
						ControllerPersonOperations.SerializeBinaryFormatter(person);
						break;
					case "XmlSerializer":
						ControllerPersonOperations.SerializeXmlSerializer(person);
						break;
					case "SharpSerializer Binary":
						ControllerPersonOperations.SerializeSharpSerializerBinary(person);
						break;
					case "SharpSerializer Xml":
						ControllerPersonOperations.SerializeSharpSerializerXml(person);
						break;
					default:
						break;
				}
			}

			return person;
		}
		//-------------------------------------------------------------------------
		private void UIFromObject()
		{
			// difficult to port (iOS especially)
			object o = comboBoxFormats.SelectedItem;

			if (null == o)
			{
				UIReset();
				return;
			}
			else
			{
				string name = o.ToString();

				switch (name)
				{
					case "Binary Formatter":
						person = ControllerPersonOperations.DeserializeBinaryFormatter();
						break;
					case "XmlSerializer":
						person = ControllerPersonOperations.DeserializeXmlSerializer();
						break;
					case "SharpSerializer Binary":
						person = ControllerPersonOperations.DeserializeSharpSerializerBinary();
						break;
					case "SharpSerializer Xml":
						person = ControllerPersonOperations.DeserializeSharpSerializerXml();
						break;
					default:
						return;
					//break;
				}	
			}

			if (null == person)
			{
				UIReset();
			}
			else
			{
				UISet(person);
			}

			return;
		}
		//-------------------------------------------------------------------------
		private void UISet(Person p)
		{
			this.textBoxNameFirst.Text = p.NameFirst;
			this.textBoxNameLast.Text = p.NameLast;
			this.textBoxAge.Text = p.Age.ToString();
			this.dateTimePicker1.Text = p.DateOfBirth.ToString();

			return;
		}
		//-------------------------------------------------------------------------
		private void UIReset()
		{
			this.textBoxNameFirst.Text = "";
			this.textBoxNameLast.Text = "";
			this.textBoxAge.Text = "????";
			this.dateTimePicker1.Text = DateTime.Today.ToString();

			return;
		}
		//-------------------------------------------------------------------------
		# endregion Platform dependant code (port needed)

	}
}
