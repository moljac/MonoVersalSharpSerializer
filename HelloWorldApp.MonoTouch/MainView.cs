
using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace HelloWorldApp
{
	public partial class MainView : UIViewController
	{
		static bool UserInterfaceIdiomIsPhone {
			get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
		}

		public MainView ()
			: base (UserInterfaceIdiomIsPhone ? "MainView_iPhone" : "MainView_iPad", null)
		{
			this.NavigationItem.Title = "www.sharpserializer.com";
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
			buttonForm2.TouchUpInside += (object sender, EventArgs e) => 
			{
				SimpleSampleView ssv = new SimpleSampleView();
				this.NavigationController.PushViewController(ssv,true);
			};


		}
	}
}

