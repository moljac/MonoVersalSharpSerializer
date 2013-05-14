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

			textBoxContent.Text = ControllerPersonOperations.LoadFileTextual(name);

			return;
		}

	}
}
