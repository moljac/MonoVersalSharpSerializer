// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;

namespace HelloWorldApp
{
	[Register ("FormContentPresenter")]
	partial class FormContentPresenter
	{
		[Outlet]
		MonoTouch.UIKit.UITextView textBoxContent { get; set; }

		[Outlet]
		MonoTouch.UIKit.UINavigationItem contentTitle { get; set; }

		[Action ("buttonDone:")]
		partial void buttonDone (MonoTouch.Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (textBoxContent != null) {
				textBoxContent.Dispose ();
				textBoxContent = null;
			}

			if (contentTitle != null) {
				contentTitle.Dispose ();
				contentTitle = null;
			}
		}
	}
}
