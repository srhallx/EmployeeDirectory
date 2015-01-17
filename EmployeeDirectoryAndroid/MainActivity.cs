using System;
using EmployeeDirectory;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Worklight;
using Worklight.Xamarin.Android;

namespace EmployeeDirectoryAndroid
{
	[Activity (Label = "EmployeeDirectoryAndroid", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		EmployeeDirectoryClient employeeDirectory;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			employeeDirectory = new EmployeeDirectoryClient (WorklightClient.CreateInstance (this));

			SearchView search = FindViewById<SearchView> (Resource.Id.searchView1);
			TextView lblName = FindViewById<TextView> (Resource.Id.lblName);
			TextView lblEmail = FindViewById<TextView> (Resource.Id.lblEmail);
			TextView lblPhone = FindViewById<TextView> (Resource.Id.lblPhone);

			search.QueryTextSubmit += async (object sender, SearchView.QueryTextSubmitEventArgs e) => {

				Employee employeeRecord = await employeeDirectory.FindEmployee (search.Query);

				if (employeeRecord != null) {
					lblName.Text = employeeRecord.Name;
					lblEmail.Text = employeeRecord.Email;
					lblPhone.Text = employeeRecord.Phone;
				} else {
					lblName.Text = "No Record Found";
					lblEmail.Text = "";
					lblPhone.Text = "";
				}
			};

		}
	}
}


