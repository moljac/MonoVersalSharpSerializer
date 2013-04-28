
using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace HelloWorldApp
{
	public partial class SimpleSampleView : UIViewController
	{
		static bool UserInterfaceIdiomIsPhone {
			get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
		}

		public SimpleSampleView ()
			: base (UserInterfaceIdiomIsPhone ? "SimpleSampleView_iPhone" : "SimpleSampleView_iPad", null)
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
	}
}














