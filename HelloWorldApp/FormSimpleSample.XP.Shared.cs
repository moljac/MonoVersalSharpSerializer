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
			UIFromObject();

			return;
		}

		private void buttonSave_Click(object sender, EventArgs e)
		{
			Person p = UIToObject();

			return;
		}


		private void buttonClear_Click(object sender, EventArgs e)
		{
			UIFromObject();

			textBoxNameFirst.Text = String.Empty; 
			textBoxNameLast.Text = String.Empty;
			textBoxAge.Text = String.Empty;
			dateTimePicker1.Text = String.Empty;
			comboBoxFormats.Text = String.Empty;

			return;
		}
	}
}