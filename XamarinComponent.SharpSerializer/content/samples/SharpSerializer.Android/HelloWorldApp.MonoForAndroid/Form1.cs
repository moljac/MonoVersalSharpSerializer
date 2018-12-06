using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;



using HelloWorldApp.BusinessObjects;

namespace HelloWorldApp
{
	[Activity (Label = "www.sharpserializer.com", MainLauncher = true)]
	//public class Activity1 : Activity
	public partial class Form1 : Activity
	{

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it
			var serializeXmlButton = FindViewById<Button> (Resource.Id.serializeXmlButton);
			var serializeSizeOptimizedBinary = FindViewById<Button> (Resource.Id.serializeSizeOptimizedBinary);
			var serializeBurstBinary = FindViewById<Button> (Resource.Id.serializeBurstBinary);
			var buttonForm2 = FindViewById<Button> (Resource.Id.buttonForm2);

			buttonForm2.Click += NavigateToFormSimpleSample;

			// Code sharing from WF app
			Form1 f1 = new Form1();
			serializeXmlButton.Click += new EventHandler(f1.serializeXmlButton_Click);
			serializeSizeOptimizedBinary.Click += new EventHandler(f1.serializeSizeOptimizedBinary_Click);
			serializeBurstBinary.Click += new EventHandler(f1.serializeBurstBinary_Click);

			return;
		}

		# region    Platform dependant code (port needed)
		//-------------------------------------------------------------------------
		//private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		//{
		//	Navigate("http://www.sharpserializer.com");
		//}
		//-------------------------------------------------------------------------
		private void buttonForm2_Click(object sender, EventArgs e)
		{
			NavigateToFormSimpleSample(sender, e);

			return;
		}
		//-------------------------------------------------------------------------
		private void NavigateToFormSimpleSample(object sender, EventArgs e)
		{
			StartActivity(typeof(FormSimpleSample));

			return;
		}
		//-------------------------------------------------------------------------
		// For showing 
		//		WF messages 
		//		Android Alerts
		//		iOS ???
		private void ShowMessageAlert(object sender, EventArgs e)
		{
			bool show_toast = false;
			bool show_alert = false;

			string text = SerializationMessage.ToString();

			# region    Toast
			//-------------------------------------------------------------------------
			// Java.Lang.NullPointerException: 
			// Toast.MakeText(this, SerializationMessage, ToastLength.Long);
			// Toast.MakeText(this, SerializationMessage, ToastLength.Long).Show();
			// Toast.MakeText(ApplicationContext, SerializationMessage, ToastLength.Long).Show();

			// Context context = ApplicationContext;
			// Antext = new CharSequence SerializationMessage;
			// int duration = Toast.LENGTH_SHORT;
			// 

			if (show_toast)
			{
				Toast toast = Toast.MakeText(this, text, ToastLength.Short);
				toast.Show(); 
			}
			//-------------------------------------------------------------------------
			# endregion Toast


			# region    Alert
			//-------------------------------------------------------------------------
			if (show_alert)
			{
				AlertDialog.Builder builder = new AlertDialog.Builder(this);
				builder.SetTitle("!! Alert !!");
				builder.SetMessage(text);
				builder.SetCancelable(false);

				builder.SetPositiveButton
					(
					  "OK"
					, delegate
					{
						//DO SOMEETHING
					}
					);

				builder.Show();
			}
			//-------------------------------------------------------------------------
			# endregion Alert
	




			return;
		}
		//-------------------------------------------------------------------------
		public void showInExplorer(string filename)
		{
			// if (!string.IsNullOrEmpty(filename) && File.Exists(filename))
			// {
			// 	string arguments = string.Format("/n, /select, \"{0}\"", filename);
			// 	Process.Start("explorer", arguments);
			// }

			return;
		}
		//-------------------------------------------------------------------------
		# endregion Platform dependant code (port needed)
	}
}


