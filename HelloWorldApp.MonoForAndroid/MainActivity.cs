using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace HelloWorldApp.MonoForAndroid
{
	[Activity (Label = "www.sharpserializer.com", MainLauncher = true)]
	public class Activity1 : Activity
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

			buttonForm2.Click += NavigateToSimpleSample;

		}

		void NavigateToSimpleSample (object sender, EventArgs e)
		{
			StartActivity(typeof(SimpleSampleActivity));
		}
	}
}


