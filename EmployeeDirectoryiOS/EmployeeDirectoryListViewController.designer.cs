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
	[Register ("EmployeeDirectoryListViewController")]
	partial class EmployeeDirectoryListViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField tbxSearch { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (tbxSearch != null) {
				tbxSearch.Dispose ();
				tbxSearch = null;
			}
		}
	}
}
