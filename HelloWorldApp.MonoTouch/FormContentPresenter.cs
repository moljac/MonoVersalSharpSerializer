using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;


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

