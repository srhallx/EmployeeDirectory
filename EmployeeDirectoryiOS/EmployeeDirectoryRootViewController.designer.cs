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
	[Register ("EmployeeDirectoryRootViewController")]
	partial class EmployeeDirectoryRootViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITableView tblEmployees { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField tbxSearch { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (tblEmployees != null) {
				tblEmployees.Dispose ();
				tblEmployees = null;
			}
			if (tbxSearch != null) {
				tbxSearch.Dispose ();
				tbxSearch = null;
			}
		}
	}
}
