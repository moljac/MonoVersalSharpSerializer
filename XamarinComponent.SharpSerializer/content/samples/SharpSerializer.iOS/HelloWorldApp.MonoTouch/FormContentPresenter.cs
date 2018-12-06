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
	public partial class FormContentPresenter : UIViewController
	{
		private string name;

		static bool UserInterfaceIdiomIsPhone {
			get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
		}

		public FormContentPresenter (string name)
			: base (UserInterfaceIdiomIsPhone ? "FormContentPresenter_iPhone" : "FormContentPresenter_iPad", null)
		{
			// TODO: Complete member initialization
			this.name = name;

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
			
			//Navigation Bar TITLE
			contentTitle.Title =
				"path = " +	NSBundle.MainBundle.BundlePath
				+ Environment.NewLine +
				name
				;

			//TEXT BOX - textBoxContent
			//	textBoxContent
			textBoxContent.Text = ControllerPersonOperations.LoadFileTextual(name);

			return;
		}

		partial void buttonDone (NSObject sender)
		{
			this.DismissViewController(true,null);
		}
	}
}

