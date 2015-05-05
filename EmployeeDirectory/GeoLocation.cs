using System;

namespace EmployeeDirectory
{
	public class GeoLocation
	{
		public double Longitude { get; set; }
		public double Lattitude { get; set; }

		public GeoLocation (double lat, double lng)
		{
			Longitude = lng;
			Lattitude = lat;
		}
	}
}

