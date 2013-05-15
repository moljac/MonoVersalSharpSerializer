// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;

namespace HelloWorldApp
{
	[Register ("MainView")]
	partial class Form1
	{
		[Outlet]
		MonoTouch.UIKit.UIButton serializeXmlButton { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton serializeSizeOptimizedBinary { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton serializeBurstBinary { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton buttonForm2 { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel label1 { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel label2 { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton linkLabel1 { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (serializeXmlButton != null) {
				serializeXmlButton.Dispose ();
				serializeXmlButton = null;
			}

			if (serializeSizeOptimizedBinary != null) {
				serializeSizeOptimizedBinary.Dispose ();
				serializeSizeOptimizedBinary = null;
			}

			if (serializeBurstBinary != null) {
				serializeBurstBinary.Dispose ();
				serializeBurstBinary = null;
			}

			if (buttonForm2 != null) {
				buttonForm2.Dispose ();
				buttonForm2 = null;
			}

			if (label1 != null) {
				label1.Dispose ();
				label1 = null;
			}

			if (label2 != null) {
				label2.Dispose ();
				label2 = null;
			}

			if (linkLabel1 != null) {
				linkLabel1.Dispose ();
				linkLabel1 = null;
			}
		}
	}
}
