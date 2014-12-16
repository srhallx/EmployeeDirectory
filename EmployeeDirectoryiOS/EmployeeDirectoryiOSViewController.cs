using System;
using System.Drawing;
using EmployeeDirectory;
using Worklight.Xamarin.iOS;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace EmployeeDirectoryiOS
{
	public partial class EmployeeDirectoryiOSViewController : UIViewController
	{

		private EmployeeDirectoryClient employeeDirectory;

		public EmployeeDirectoryiOSViewController (IntPtr handle) : base (handle)
		{
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}

		#region View lifecycle

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			
			// Perform any additional setup after loading the view, typically from a nib.
			employeeDirectory = new EmployeeDirectoryClient (WorklightClient.CreateInstance ());

			tbxSearch.ShouldReturn += (textField) => {
				tbxSearch.ResignFirstResponder ();
				return true;
			};

			tbxSearch.Ended += async delegate(object sender, EventArgs e) {
				Employee employeeRecord = await employeeDirectory.FindEmployee (tbxSearch.Text);

				if (employeeRecord != null) {
					lblName.Text = employeeRecord.Name;
					lblEmail.Text = employeeRecord.Email;
					lblPhone.Text = employeeRecord.Phone;
				} else {
					lblName.Text = "No record found";
					lblEmail.Text = "";
					lblPhone.Text = "";
				}
			};
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

