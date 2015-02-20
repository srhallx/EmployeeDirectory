using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System;
using System.CodeDom.Compiler;
using EmployeeDirectory;

namespace EmployeeDirectoryiOS
{
	partial class EmployeeDirectoryListViewController : UIViewController
	{
		public EmployeeDirectoryListViewController (IntPtr handle) : base (handle)
		{
			tbxSearch.ShouldReturn += (textField) => {
				tbxSearch.ResignFirstResponder ();
				return true;
			};

			tbxSearch.Ended += async delegate(object sender, EventArgs e) {
				//Employee employeeRecord = await employeeDirectory.FindEmployee (tbxSearch.Text);

			};
		}


		#region View lifecycle

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();


		}

		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);
		}

		public override void ViewDidAppear (bool animated)
		{
			base.ViewDidAppear (animated);
		}

		public override void ViewWillDisappear (bool animated)
		{
			base.ViewWillDisappear (animated);
		}

		public override void ViewDidDisappear (bool animated)
		{
			base.ViewDidDisappear (animated);
		}

		#endregion
	}
}
