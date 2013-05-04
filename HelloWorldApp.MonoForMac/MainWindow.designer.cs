// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoMac.Foundation;

namespace HelloWorldApp.MonoForMac
{
	[Register ("MainWindowController")]
	partial class MainWindowController
	{
		[Outlet]
		MonoMac.AppKit.NSButton serializeXmlButton { get; set; }

		[Outlet]
		MonoMac.AppKit.NSButton serializeSizeOptimizedBinary { get; set; }

		[Outlet]
		MonoMac.AppKit.NSButton serializeBurstBinary { get; set; }

		[Outlet]
		MonoMac.AppKit.NSButton buttonForm2 { get; set; }

		[Outlet]
		MonoMac.AppKit.NSTextField textBoxNameFirst { get; set; }

		[Outlet]
		MonoMac.AppKit.NSTextField textBoxNameLast { get; set; }

		[Outlet]
		MonoMac.AppKit.NSDatePicker dateTimePicker1 { get; set; }

		[Outlet]
		MonoMac.AppKit.NSTextField textBoxAge { get; set; }

		[Outlet]
		MonoMac.AppKit.NSComboBox comboBoxFormats { get; set; }

		[Outlet]
		MonoMac.AppKit.NSButton buttonLoad { get; set; }

		[Outlet]
		MonoMac.AppKit.NSButton buttonSave { get; set; }

		[Outlet]
		MonoMac.AppKit.NSButton buttonOpen { get; set; }

		[Outlet]
		MonoMac.AppKit.NSButton buttonClear { get; set; }
		
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

			if (comboBoxFormats != null) {
				comboBoxFormats.Dispose ();
				comboBoxFormats = null;
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
		}
	}

	[Register ("MainWindow")]
	partial class MainWindow
	{
		
		void ReleaseDesignerOutlets ()
		{
		}
	}
}
