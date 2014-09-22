// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//

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

namespace HelloWorldApp
{
	[Register ("FormSimpleSample")]
	partial class FormSimpleSample
	{
		[Outlet]
		UITextField textBoxNameFirst { get; set; }

		[Outlet]
		UITextField textBoxNameLast { get; set; }

		[Outlet]
		UITextField dateTimePicker1 { get; set; }

		[Outlet]
		UITextField textBoxAge { get; set; }

		[Outlet]
		UIButton buttonLoad { get; set; }

		[Outlet]
		UIButton buttonSave { get; set; }

		[Outlet]
		UIButton buttonOpen { get; set; }

		[Outlet]
		UIButton buttonClear { get; set; }

		[Outlet]
		UITextField comboBoxFormats { get; set; }
		
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
