using System;
using System.Collections.Generic;

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
	public class PickerModel : UIPickerViewModel
	{
		public event EventHandler<PickerChangedEventArgs> PickerChanged;
		
		List<string> column1 = new List<string>()
		{				
		  "Binary Formatter"
		, "XmlSerializer"				// was XML Serializer
		, "SharpSerializer Binary"		// 
		, "SharpSerializer Xml"			// was SharpSerializer XML
		};

		
		List<List<string>> columns = new List<List<string>>();

		public PickerModel(UIView currentView)
		{
			columns.Add(column1);

			return;
		}

		
		public override int GetComponentCount(UIPickerView uipv)
		{
			return(1);	
		}
		
		public override int GetRowsInComponent (UIPickerView uipv, int component)
		{
			int retval1 = columns[component].Count;
						
			return retval1;
		}
		
		public override string GetTitle(UIPickerView uipv, int row, int component)
		{
			//each component would get its own title.			
			return columns[component][row];		
		}

		
		public override float GetComponentWidth(UIPickerView uipv, int comp)
		{
			return(400f);
		}
		
		public override float GetRowHeight(UIPickerView uipv, int comp)
		{
			return(40f); 
		}
		
		public class PickerChangedEventArgs : EventArgs
		{
			public string SelectedValue { get; set; }
		}
		
		public override void Selected (UIPickerView picker, int row, int component)
		{
			if (this.PickerChanged != null)
			{
				this.PickerChanged(this, new PickerChangedEventArgs{SelectedValue = columns[component][row]});
			}
		}
		
		
	}
}

