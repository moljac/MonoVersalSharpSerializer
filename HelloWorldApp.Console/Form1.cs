using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelloWorldApp 
{
	public partial class Form1 
	{
		# region    Platform dependant code (port needed)
		//-------------------------------------------------------------------------
		// For showing 
		//		WF messages 
		//		Android Alerts
		//		iOS ???
		private void ShowMessageAlert(object sender, EventArgs e)
		{
			// Java.Lang.NullPointerException: 
			// Toast.MakeText(this, SerializationMessage, ToastLength.Long);
			// Toast.MakeText(this, SerializationMessage, ToastLength.Long).Show();
			// Toast.MakeText(ApplicationContext, SerializationMessage, ToastLength.Long).Show();

			// Context context = ApplicationContext;
			// Antext = new CharSequence SerializationMessage;
			// int duration = Toast.LENGTH_SHORT;
			// 
			// Toast toast = Toast.makeText(context, text, duration);
			// toast.show(); 

			//Toast.MakeText(this, SerializationMessage.ToString(), ToastLength.Short).Show();

			System.Console.WriteLine("Message=" + Environment.NewLine + SerializationMessage);

			return;
		}
		//-------------------------------------------------------------------------
		# endregion Platform dependant code (port needed)
	}
}
