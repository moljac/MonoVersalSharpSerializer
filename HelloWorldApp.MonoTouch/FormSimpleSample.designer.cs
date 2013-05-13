// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;

namespace HelloWorldApp
{
	[Register ("FormSimpleSample")]
	partial class FormSimpleSample
	{
		[Outlet]
		MonoTouch.UIKit.UITextField textBoxNameFirst { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField textBoxNameLast { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField dateTimePicker1 { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField textBoxAge { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton buttonLoad { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton buttonSave { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton buttonOpen { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton buttonClear { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField comboBoxFormats { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (textBoxNameFirst != null) {
				textBoxNameFirst.Dispose ();
				textBoxNameFirst = null;
			}

			if (textBoxNameLast != null) {
				textBoxNameLast.Dispose ();
				textBoxNameLast = null;
			}

			if (dateTimePicker1 != null) {
				dateTimePicker1.Dispose ();
				dateTimePicker1 = null;
			}

			if (textBoxAge != null) {
				textBoxAge.Dispose ();
				textBoxAge = null;
			}

			if (buttonLoad != null) {
				buttonLoad.Dispose ();
				buttonLoad = null;
			}

			if (buttonSave != null) {
				buttonSave.Dispose ();
				buttonSave = null;
			}

			if (buttonOpen != null) {
				buttonOpen.Dispose ();
				buttonOpen = null;
			}

			if (buttonClear != null) {
				buttonClear.Dispose ();
				buttonClear = null;
			}

			if (comboBoxFormats != null) {
				comboBoxFormats.Dispose ();
				comboBoxFormats = null;
			}
		}
	}
}
