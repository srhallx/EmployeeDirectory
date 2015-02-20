// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System;
using System.CodeDom.Compiler;

namespace EmployeeDirectoryiOS
{
	[Register ("EmployeeDirectoryDetailViewController")]
	partial class EmployeeDirectoryDetailViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel lblEmail { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel lblName { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel lblPhone { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel lblTitle { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel lblTwitter { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		MonoTouch.MapKit.MKMapView mapLocation { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (lblEmail != null) {
				lblEmail.Dispose ();
				lblEmail = null;
			}
			if (lblName != null) {
				lblName.Dispose ();
				lblName = null;
			}
			if (lblPhone != null) {
				lblPhone.Dispose ();
				lblPhone = null;
			}
			if (lblTitle != null) {
				lblTitle.Dispose ();
				lblTitle = null;
			}
			if (lblTwitter != null) {
				lblTwitter.Dispose ();
				lblTwitter = null;
			}
			if (mapLocation != null) {
				mapLocation.Dispose ();
				mapLocation = null;
			}
		}
	}
}
