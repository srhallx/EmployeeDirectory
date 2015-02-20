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
			tbxName.Text = "";
			tbxEmail.Text = "";
			tbxPhone.Text = "";


			//
			// Create instance of MFP client
			//



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

