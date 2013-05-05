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
			Person p = new Person()
			{
			  NameFirst = this.textBoxNameFirst.Text
			, NameLast = this.textBoxNameLast.Text
			, DateOfBirth = this.dateTimePicker1.Value
			};

			return p;
		}

		//-------------------------------------------------------------------------
		private void UIFromObject(Person p)
		{
			if (null == p)
			{
				this.textBoxNameFirst.Text = "";
				this.textBoxNameLast.Text = "";
				this.textBoxAge.Text = "????";
				this.dateTimePicker1.Value = DateTime.Today;
			}
			else
			{
				this.textBoxNameFirst.Text = p.NameFirst;
				this.textBoxNameLast.Text = p.NameLast;
				this.textBoxAge.Text = p.Age.ToString();
				this.dateTimePicker1.Value = p.DateOfBirth;
			}

			return;
		}
		//-------------------------------------------------------------------------
		# endregion Platform dependant code (port needed)
	}
}
