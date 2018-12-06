
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


using System.Xml;
using HelloWorldApp.BusinessObjects;
using Polenter.Serialization;
using System.IO;

namespace HelloWorldApp
{
	public partial class Form1 : UIViewController
	{
		static bool UserInterfaceIdiomIsPhone {
			get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
		}

		public Form1 ()
			: base (UserInterfaceIdiomIsPhone ? "Form1_iPhone" : "Form1_iPad", null)
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

			//BUTTONS ACTION
			buttonForm2.TouchUpInside += new EventHandler(buttonForm2_TouchUpInside);
			linkLabel1.TouchUpInside += linkLabel1_LinkClicked;
			
			serializeXmlButton.TouchUpInside += serializeXmlButton_Click;
			serializeBurstBinary.TouchUpInside += serializeBurstBinary_Click;
			serializeSizeOptimizedBinary.TouchUpInside += serializeSizeOptimizedBinary_Click;

			return;
		}

		void linkLabel1_LinkClicked (object sender, EventArgs e)
		{
			UIApplication.SharedApplication.OpenUrl (new NSUrl("http://www.sharpserializer.com"));
		}

		void buttonForm2_TouchUpInside(object sender, EventArgs e)
		{
			buttonForm2_Click(sender, e);

			return;
		}


		# region    Platform dependant code (port needed)
		//-------------------------------------------------------------------------
		//private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		//{
		//	Navigate("http://www.sharpserializer.com");
		//}
		//-------------------------------------------------------------------------
		private void buttonForm2_Click(object sender, EventArgs e)
		{
			NavigateToFormSimpleSample(sender, e);

			return;
		}
		//-------------------------------------------------------------------------
		private void NavigateToFormSimpleSample(object sender, EventArgs e)
		{
			FormSimpleSample ssv = new FormSimpleSample();
			this.NavigationController.PushViewController(ssv, true);

			return;
		}
		//-------------------------------------------------------------------------
		// For showing 
		//		WF messages 
		//		Android Alerts
		//		iOS ???

		//IKI: modified
		private void ShowMessageAlert(object sender, EventArgs e)
		{
			UIAlertView uia = new UIAlertView
								(
								  "Serialization result"
								, SerializationMessage
								, null
								, "OK"
								, null
								);
			uia.Show();

			return;
		}
		//-------------------------------------------------------------------------
		public void showInExplorer(string filename)
		{
			// if (!string.IsNullOrEmpty(filename) && File.Exists(filename))
			// {
			// 	string arguments = string.Format("/n, /select, \"{0}\"", filename);
			// 	Process.Start("explorer", arguments);
			// }

			return;
		}
		//-------------------------------------------------------------------------
		# endregion Platform dependant code (port needed)
	}
}

