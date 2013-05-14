
using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

using HelloWorldApp.BusinessObjects;

namespace HelloWorldApp
{
	public partial class FormSimpleSample : UIViewController
	{
		static bool UserInterfaceIdiomIsPhone {
			get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
		}

		public FormSimpleSample ()
			: base (UserInterfaceIdiomIsPhone ? "FormSimpleSample_iPhone" : "FormSimpleSample_iPad", null)
		{
		}
		
		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}
		
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			
			// Perform any additional setup after loading the view, typically from a nib.
			DateChooser();
			FormatChooser();

			// BUTTONS ACTION
			buttonOpen.TouchUpInside += buttonOpen_Click;
			buttonClear.TouchUpInside += buttonClear_Click;

		}

		void DateChooser ()
		{
			UIDatePicker datePicker = new UIDatePicker();
			datePicker.ValueChanged += (object sender, EventArgs e) => 
			{
				dateTimePicker1.Text = datePicker.Date.ToString();
			};


			dateTimePicker1.InputView = datePicker;
			dateTimePicker1.InputAccessoryView = datePickerDismissalView(datePicker,dateTimePicker1);

            return;
		}

		void FormatChooser ()
		{
			//Setup the picker and model
			PickerModel model = new PickerModel (this.View);
			model.PickerChanged += (sender, e) => 
			{
				this.comboBoxFormats.Text = e.SelectedValue;
				
			};
			
			//UIPickerView
			UIPickerView picker = new UIPickerView ();
			picker.ShowSelectionIndicator = true;
			picker.Model = model;

			//Tell the textbox to use the picker for input
			comboBoxFormats.InputView = picker;
			comboBoxFormats.InputAccessoryView = datePickerDismissalView(picker,comboBoxFormats);
		}

		UIView datePickerDismissalView (UIView picker,UITextField inputElement)
		{
			var pickerDismissalView = new UIView ();
			pickerDismissalView.Frame = new System.Drawing.RectangleF (0, 0, this.View.Bounds.Width, this.View.Bounds.Height - picker.Frame.Height);
			pickerDismissalView.Alpha = 1.0f;
			pickerDismissalView.BackgroundColor = UIColor.FromWhiteAlpha(0.2f,0.2f);

			RemovalGesture(pickerDismissalView,inputElement);

			return pickerDismissalView;
		}

		void RemovalGesture (UIView dismissalView,UITextField inputElement)
		{
			//TAP GESTURE
			var tap = new UITapGestureRecognizer();

			//add gestures for removal
			tap.AddTarget(() => {inputElement.ResignFirstResponder();});
			dismissalView.AddGestureRecognizer(tap);
		}





		# region    Platform dependant code (port needed)
		//-------------------------------------------------------------------------
		private void buttonOpen_Click(object sender, EventArgs e)
		{

				string name = comboBoxFormats.Text;
				FormContentPresenter fcp = new FormContentPresenter(name);
				this.NavigationController.PresentViewController (fcp, true, null);

				//fcp.Push();
			System.Diagnostics.Debug.WriteLine ("BUTTON OPEN CLICKED!");

			return;
		}
		//-------------------------------------------------------------------------
		private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
		{
			// http://stackoverflow.com/questions/9/how-do-i-calculate-someones-age

			DateTime dob = DateTime.Now;
			DateTime.TryParse(this.dateTimePicker1.Text, out dob);

			DateTime birthday = dob;
			int age = new DateTime(DateTime.Now.Subtract(birthday).Ticks).Year - 1;

			textBoxAge.Text = age.ToString();

			return;
		}
		//-------------------------------------------------------------------------
		private Person UIToObject()
		{
			string  f = comboBoxFormats.Text;
			Person p = default(Person);

			if (null == f)
			{
				return p;
			}
			else
			{
				string name = f.ToString();

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

        private void UIReset()
        {
            this.textBoxNameFirst.Text = "";
            this.textBoxNameLast.Text = "";
            this.textBoxAge.Text = "????";
            this.dateTimePicker1.Text = DateTime.Today.ToString();
            
            return;
        }

		//-------------------------------------------------------------------------
		private void UIFromObject()
		{
            Person p = default(Person);
            
			// difficult to port (iOS especially)
			object o = comboBoxFormats.Text;

			if (null == o)
			{
				UIReset();

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














