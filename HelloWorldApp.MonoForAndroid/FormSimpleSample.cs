
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
	[Activity(Label = "Simple Sample")]
	public partial class FormSimpleSample : Activity
	{
		private DateTime date;
		private EditText textBoxNameFirst;
		private EditText textBoxNameLast;
		private EditText textBoxAge;
		private EditText dateTimePicker1;
		private Button buttonLoad;
		private Button buttonSave;
		private Button buttonOpen;
		private Button buttonClear;
		private Spinner comboBoxFormats;


		String[] items = new String[] 
				{ 
				  "Binary Formatter"
				, "XmlSerializer"
				, "SharpSerializer Binary"
				, "SharpSerializer Xml" 
				};

		const int DATE_DIALOG_ID = 0;

		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			// Create your application here
			SetContentView(Resource.Layout.SimpleSample);

			textBoxNameFirst = FindViewById<EditText>(Resource.Id.textBoxNameFirst);
			textBoxNameLast = FindViewById<EditText>(Resource.Id.textBoxNameLast);
			textBoxAge = FindViewById<EditText>(Resource.Id.textBoxAge);
			dateTimePicker1 = FindViewById<EditText>(Resource.Id.dateTimePicker1);

			buttonLoad = FindViewById<Button>(Resource.Id.buttonLoad);
			buttonSave = FindViewById<Button>(Resource.Id.buttonSave);
			buttonOpen = FindViewById<Button>(Resource.Id.buttonOpen);
			buttonClear = FindViewById<Button>(Resource.Id.buttonClear);

			comboBoxFormats = FindViewById<Spinner>(Resource.Id.comboBoxFormats);

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


			var folder =
					System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal)
				//@"."	// Android Access Denied
					;
			ControllerPersonOperations.StorageRoot = folder;

			// Code sharing from WF app
			buttonLoad.Click += new EventHandler(this.buttonLoad_Click);
			buttonSave.Click += new EventHandler(this.buttonSave_Click);
			buttonOpen.Click += new EventHandler(this.buttonOpen_Click);
			buttonClear.Click += new EventHandler(this.buttonClear_Click);

			return;

		}

		void DateChooser(object sender, EventArgs e)
		{
			ShowDialog(DATE_DIALOG_ID);
		}

		// updates the date in the TextView
		private void UpdateDisplay()
		{
			dateTimePicker1.Text = date.ToString();
		}

		// the event received when the user "sets" the date in the dialog
		void OnDateSet(object sender, DatePickerDialog.DateSetEventArgs e)
		{
			this.date = e.Date;
			UpdateDisplay();
		}

		void NavigateToFormContentPresenter(object sender, EventArgs e)
		{
			StartActivity(typeof(FormContentPersenter));
		}

		protected override Dialog OnCreateDialog(int id)
		{
			switch (id)
			{
				case DATE_DIALOG_ID:
					return new DatePickerDialog(this, OnDateSet, date.Year, date.Month - 1, date.Day);
			}
			return null;
		}









		# region    Platform dependant code (port needed)
		//-------------------------------------------------------------------------
		private void buttonOpen_Click(object sender, EventArgs e)
		{
			if (null != comboBoxFormats.SelectedItem)
			{
				string name = comboBoxFormats.SelectedItem.ToString();
				//FormContentPersenter fcp = new FormContentPersenter(name);
				//fcp.Show();
				NavigateToFormContentPresenter(sender, e);
			}

			return;
		}
		//-------------------------------------------------------------------------
		private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
		{
			// http://stackoverflow.com/questions/9/how-do-i-calculate-someones-age
			DateTime birthday = DateTime.Parse(dateTimePicker1.Text);
			int age = new DateTime(DateTime.Now.Subtract(birthday).Ticks).Year - 1;

			textBoxAge.Text = age.ToString();

			return;
		}
		//-------------------------------------------------------------------------
		private Person UIToObject()
		{
			object o = comboBoxFormats.SelectedItem;
			Person p = default(Person);

			if (null == o)
			{
				return p;
			}
			else
			{
				string name = o.ToString();

				DateTime dob = DateTime.Now;
				DateTime.TryParse(this.dateTimePicker1.Text, out dob);

				p = new Person()
				{
				  NameFirst = this.textBoxNameFirst.Text
				, NameLast = this.textBoxNameLast.Text
				, DateOfBirth = dob
				};

				switch (name)
				{
					case "Binary Formatter":
						ControllerPersonOperations.SerializeBinaryFormatter(p);
						break;
					case "XmlSerializer":
						ControllerPersonOperations.SerializeXmlSerializer(p);
						break;
					case "SharpSerializer Binary":
						ControllerPersonOperations.SerializeSharpSerializerBinary(p);
						break;
					case "SharpSerializer Xml":
						ControllerPersonOperations.SerializeSharpSerializerXml(p);
						break;
					default:
						break;
				}
			}

			return p;
		}

		//-------------------------------------------------------------------------
		private void UIFromObject()
		{
			Person p = default(Person);

			// difficult to port (iOS especially)
			object o = comboBoxFormats.SelectedItem;

			if (null == o)
			{
				this.textBoxNameFirst.Text = "";
				this.textBoxNameLast.Text = "";
				this.textBoxAge.Text = "????";
				this.dateTimePicker1.Text = DateTime.Today.ToString();

				return;
			}
			else
			{
				string name = o.ToString();

				switch (name)
				{
					case "Binary Formatter":
						p = ControllerPersonOperations.DeserializeBinaryFormatter();
						break;
					case "XmlSerializer":
						p = ControllerPersonOperations.DeserializeXmlSerializer();
						break;
					case "SharpSerializer Binary":
						p = ControllerPersonOperations.DeserializeSharpSerializerBinary();
						break;
					case "SharpSerializer Xml":
						p = ControllerPersonOperations.DeserializeSharpSerializerXml();
						break;
					default:
						return;
					//break;
				}
			}

			if (null == p)
			{
				this.textBoxNameFirst.Text = "";
				this.textBoxNameLast.Text = "";
				this.textBoxAge.Text = "????";
				this.dateTimePicker1.Text = DateTime.Today.ToString();
			}
			else
			{
				this.textBoxNameFirst.Text = p.NameFirst;
				this.textBoxNameLast.Text = p.NameLast;
				this.textBoxAge.Text = p.Age.ToString();
				this.dateTimePicker1.Text = p.DateOfBirth.ToString();
			}

			return;
		}
		//-------------------------------------------------------------------------
		# endregion Platform dependant code (port needed)


	}
}

