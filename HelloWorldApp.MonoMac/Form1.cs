
using System;
using System.Collections.Generic;
using System.Linq;
using MonoMac.Foundation;
using MonoMac.AppKit;

namespace HelloWorldApp.Mac
{
    public partial class Form1 : MonoMac.AppKit.NSWindow
    {
		#region Constructors
		
        // Called when created from unmanaged code
        public Form1(IntPtr handle) : base (handle)
        {
            Initialize();
        }
		
        // Called when created directly from a XIB file
        [Export ("initWithCoder:")]
        public Form1(NSCoder coder) : base (coder)
        {
            Initialize();
        }
		
        // Shared initialization code
        void Initialize()
        {
        }
		
		#endregion
    }
}

