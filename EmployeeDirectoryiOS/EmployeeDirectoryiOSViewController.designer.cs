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
	[Register ("EmployeeDirectoryiOSViewController")]
	partial class EmployeeDirectoryiOSViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		MonoTouch.MapKit.MKMapView mapLocation { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel tbxEmail { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel tbxName { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel tbxPhone { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel tbxTitle { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel tbxTwitter { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (mapLocation != null) {
				mapLocation.Dispose ();
				mapLocation = null;
			}
			if (tbxEmail != null) {
				tbxEmail.Dispose ();
				tbxEmail = null;
			}
			if (tbxName != null) {
				tbxName.Dispose ();
				tbxName = null;
			}
			if (tbxPhone != null) {
				tbxPhone.Dispose ();
				tbxPhone = null;
			}
			if (tbxTitle != null) {
				tbxTitle.Dispose ();
				tbxTitle = null;
			}
			if (tbxTwitter != null) {
				tbxTwitter.Dispose ();
				tbxTwitter = null;
			}
		}
	}
}
