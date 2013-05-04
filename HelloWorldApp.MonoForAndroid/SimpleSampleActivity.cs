
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

namespace HelloWorldApp.MonoForAndroid
{
	[Activity (Label = "Simple Sample")]			
	public class SimpleSampleActivity : Activity
	{
		private DateTime date;
		private EditText textBoxNameFirst;
		private EditText textBoxNameLast;
		private EditText dateTimePicker1;
		private Button buttonLoad;
		private Button buttonSave;
		private Button buttonOpen;
		private Button buttonClear;
		private Spinner comboBoxFormats;


		String[] items = new String[] { "Binary Formatter", "XML Serializer","SharpSerializer Binary", "SharpSerializer XML" };

		const int DATE_DIALOG_ID = 0;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Create your application here
			SetContentView (Resource.Layout.SimpleSample);

			textBoxNameFirst = FindViewById<EditText> (Resource.Id.textBoxNameFirst);
			textBoxNameLast = FindViewById<EditText> (Resource.Id.textBoxNameLast);
			dateTimePicker1 = FindViewById<EditText> (Resource.Id.dateTimePicker1);

			buttonLoad = FindViewById<Button> (Resource.Id.buttonLoad);
			buttonSave = FindViewById<Button> (Resource.Id.buttonSave);
			buttonOpen = FindViewById<Button> (Resource.Id.buttonOpen);
			buttonClear = FindViewById<Button> (Resource.Id.buttonClear);

			comboBoxFormats = FindViewById<Spinner> (Resource.Id.comboBoxFormats);





			dateTimePicker1.Click += DateChooser;
			date = DateTime.Today;

			ArrayAdapter ad = new ArrayAdapter(this, Android.Resource.Layout.SimpleSpinnerItem, items);
			ad.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
			
			comboBoxFormats.Adapter = ad;
			comboBoxFormats.ItemSelected += (sender, e) => 
			{
				//var s = sender as Spinner;
				//Toast.MakeText(this, "My favorite is " + s.GetItemAtPosition(e.Position), ToastLength.Short).Show();
			};


		}

		void DateChooser (object sender, EventArgs e)
		{
			ShowDialog (DATE_DIALOG_ID);
		}

		// updates the date in the TextView
		private void UpdateDisplay()
		{
			dateTimePicker1.Text = date.ToString();
		}

		// the event received when the user "sets" the date in the dialog
		void OnDateSet (object sender, DatePickerDialog.DateSetEventArgs e)
		{
			this.date = e.Date;
			UpdateDisplay ();
		}

		protected override Dialog OnCreateDialog (int id)
		{
			switch (id) {
			case DATE_DIALOG_ID:
				return new DatePickerDialog (this, OnDateSet, date.Year, date.Month - 1, date.Day); 
			}
			return null;
		}

	}
}

