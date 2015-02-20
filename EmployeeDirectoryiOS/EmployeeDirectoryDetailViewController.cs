using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System;
using System.CodeDom.Compiler;
using EmployeeDirectory;

namespace EmployeeDirectoryiOS
{
	partial class EmployeeDirectoryDetailViewController : UIViewController
	{
		private Employee employeeData;

		public EmployeeDirectoryDetailViewController (IntPtr handle) : base (handle)
		{
		}

		public void SetEmployee (object obj, Employee empData){

			employeeData = empData;

		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			lblName.Text = employeeData.FullName;
			lblTitle.Text = employeeData.Title;
			lblPhone.Text = employeeData.Phone;
			lblTwitter.Text = employeeData.Twitter;
			lblEmail.Text = employeeData.Email;
		}

		public override void ViewDidAppear (bool animated)
		{
			base.ViewDidAppear (animated);

		}
	}
}
