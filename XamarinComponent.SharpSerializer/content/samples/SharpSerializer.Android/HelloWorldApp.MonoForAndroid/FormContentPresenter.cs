
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using HelloWorldApp.BusinessObjects;

namespace HelloWorldApp
{
	[Activity (Label = "Content Presenter")]			
	public partial class FormContentPersenter : Activity
	{
		EditText textBoxContent = null;

		private string name;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Create your application here
			SetContentView (Resource.Layout.FormContentPresenter);

			textBoxContent = FindViewById<EditText>(Resource.Id.textBoxContent);

			name = (string) this.Intent.Extras.Get("name");

			//iOS:			Navigation Bar TITLE
			// Android:		Activity Label
			this.Title = name;

			//TEXT BOX - textBoxContent
			//	textBoxContent
			textBoxContent.Text =
				"path_combined = " + "android path_combined?!?!!"
				+ System.Environment.NewLine +
				ControllerPersonOperations.LoadFileTextual(name)
				;

			return;

		}

	}
}

