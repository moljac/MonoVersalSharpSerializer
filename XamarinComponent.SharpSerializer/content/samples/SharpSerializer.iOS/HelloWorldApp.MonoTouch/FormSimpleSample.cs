
using System;
using System.Drawing;

#if __UNIFIED__
using UIKit;
using Foundation;
using CoreAnimation;
using CoreGraphics;
#else
using MonoTouch.UIKit;
using MonoTouch.Foundation;
using MonoTouch.CoreAnimation;
using MonoTouch.CoreGraphics;

using System.Drawing;
using CGRect = global::System.Drawing.RectangleF;
using CGPoint = global::System.Drawing.PointF;
using CGSize = global::System.Drawing.SizeF;
using nfloat = global::System.Single;
using nint = global::System.Int32;
using nuint = global::System.UInt32;
#endif

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
			buttonSave.TouchUpInside += buttonSave_Click;
			buttonLoad.TouchUpInside += buttonLoad_Click;
			buttonOpen.TouchUpInside += buttonOpen_Click;
			buttonClear.TouchUpInside += buttonClear_Click;

			UIReset();
			
			return;
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
			pickerDismissalView.Frame = new RectangleF
												(
												#if __UNIFIED__
												  (float) 0, 
												  (float) 0, 
												#else
												  (float) 0, 
												  (float) 0, 
												#endif	
												  (float) this.View.Bounds.Width, 
												  (float)(this.View.Bounds.Height - picker.Frame.Height)
												  );
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
		Person person = null;
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

			if (null == f)
			{
				return person;
			}
			else
			{
				string name = f.ToString();

				DateTime dob = DateTime.Now;
				DateTime.TryParse(this.dateTimePicker1.Text, out dob);

				person = new Person()
				{
				  NameFirst = this.textBoxNameFirst.Text
				, NameLast = this.textBoxNameLast.Text
				, DateOfBirth = dob
				};

				switch (name)
				{
					case "Binary Formatter":
						ControllerPersonOperations.SerializeBinaryFormatter(person);
						break;
					case "XmlSerializer":
						ControllerPersonOperations.SerializeXmlSerializer(person);
						break;
					case "SharpSerializer Binary":
						ControllerPersonOperations.SerializeSharpSerializerBinary(person);
						break;
					case "SharpSerializer Xml":
						ControllerPersonOperations.SerializeSharpSerializerXml(person);
						break;
					default:
						break;
				}
			}

			return person;
		}
		//-------------------------------------------------------------------------
		private void UIFromObject()
		{
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
						person = ControllerPersonOperations.DeserializeBinaryFormatter();
						break;
					case "XmlSerializer":
						person = ControllerPersonOperations.DeserializeXmlSerializer();
						break;
					case "SharpSerializer Binary":
						person = ControllerPersonOperations.DeserializeSharpSerializerBinary();
						break;
					case "SharpSerializer Xml":
						person = ControllerPersonOperations.DeserializeSharpSerializerXml();
						break;
					default:
						return;
					//break;
				}
			}

			if (null == person)
			{
				UIReset();
			}
			else
			{
				UISet(person);
			}

			return;
		}
		//-------------------------------------------------------------------------
		private void UISet(Person p)
		{
			this.textBoxNameFirst.Text = p.NameFirst;
			this.textBoxNameLast.Text = p.NameLast;
			this.textBoxAge.Text = p.Age.ToString();
			this.dateTimePicker1.Text = p.DateOfBirth.ToString();

			return;
		}
		//-------------------------------------------------------------------------
		private void UIReset()
		{
			this.textBoxNameFirst.Text = "";
			this.textBoxNameLast.Text = "";
			this.textBoxAge.Text = "????";
			this.dateTimePicker1.Text = DateTime.Today.ToString();

			return;
		}
		//-------------------------------------------------------------------------
		# endregion Platform dependant code (port needed)
	}
}














