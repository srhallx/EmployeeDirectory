// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;

namespace EmployeeDirectoryiOS
{
	[Register ("EmployeeDirectoryiOSViewController")]
	partial class EmployeeDirectoryiOSViewController
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
		UITextField tbxSearch { get; set; }

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
			if (tbxSearch != null) {
				tbxSearch.Dispose ();
				tbxSearch = null;
			}
		}
	}
}
