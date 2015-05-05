using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System;
using System.CodeDom.Compiler;
using EmployeeDirectory;
using Worklight.Xamarin.iOS;
using System.Threading.Tasks;
using MonoTouch.CoreLocation;
using MonoTouch.MapKit;

namespace EmployeeDirectoryiOS
{
	partial class EmployeeDirectoryDetailViewController : UIViewController
	{
		private Employee employeeData;
		private EmployeeDirectoryClient employeeDirectory;

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

			//Get geodata
			employeeDirectory = new EmployeeDirectoryClient (WorklightClient.CreateInstance ());

			if (employeeData.City != null && employeeData.City.Length > 0) {
				RetrieveLocation (employeeData.City).ContinueWith (
					t => {

						if (t.Result != null) {

							CLLocationCoordinate2D zoomLocation = new CLLocationCoordinate2D ();
							zoomLocation.Latitude = t.Result.Lattitude;
							zoomLocation.Longitude = t.Result.Longitude;
							mapLocation.SetCenterCoordinate(zoomLocation, true);
							MKCoordinateRegion viewRegion = new MKCoordinateRegion (zoomLocation, new MKCoordinateSpan (0.125, 0.125));
							mapLocation.SetRegion (viewRegion, true);
						}
					}, TaskScheduler.FromCurrentSynchronizationContext ());
			}
		}


		private async Task<GeoLocation> RetrieveLocation (string city)
		{
			GeoLocation loc = await employeeDirectory.GetGeolocation (System.Net.WebUtility.UrlEncode (city));
			return loc;
		}

		public override void ViewDidAppear (bool animated)
		{
			base.ViewDidAppear (animated);

		}
	}
}
