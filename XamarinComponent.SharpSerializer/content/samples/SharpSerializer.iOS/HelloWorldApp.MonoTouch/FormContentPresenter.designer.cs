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
	[Register ("FormContentPresenter")]
	partial class FormContentPresenter
	{
		[Outlet]
		UITextView textBoxContent { get; set; }

		[Outlet]
		UINavigationItem contentTitle { get; set; }

		[Action ("buttonDone:")]
		partial void buttonDone (NSObject sender);
		
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
