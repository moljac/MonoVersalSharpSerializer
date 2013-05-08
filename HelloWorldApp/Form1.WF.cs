using System;
using System.IO;
using Polenter.Serialization;
using System.Diagnostics;
using HelloWorldApp.BusinessObjects;
using System.Collections.Generic;

namespace HelloWorldApp
{
	/// <summary>
	/// </summary>
	public partial class Form1
	{

		# region    Platform Dependant Code
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
		# endregion Platform Dependant Code	
	}
}