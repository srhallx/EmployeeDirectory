using System;
using Worklight;
using System.Text;
using System.Json;
using Newtonsoft.Json;
using System.Threading.Tasks;
using EmployeeDirectory;

namespace EmployeeDirectory
{
	public class EmployeeDirectoryClient
	{
		private static string MFPAdapter = "EmployeeAdapter";
		private static string MFPGeoAdapter = "GeoLocation";

		//Our MFP Client instance
		public IWorklightClient WorklightClientInstance { get; private set; }

		private bool Connected { get; set; }

		public EmployeeDirectoryClient (IWorklightClient wlc)
		{
			WorklightClientInstance = wlc;
			Connected = false;
		}


		public async Task<Employee[]> FindEmployee (string empName)
		{
			WorklightProcedureInvocationData invocationData;
			WorklightResponse task;

			try {
				await ConnectMobileFirst();
					
				invocationData = new WorklightProcedureInvocationData (
					MFPAdapter, "findEmployee", new object[] { empName });
				task = await WorklightClientInstance.InvokeProcedure (invocationData);

				if (task.Success) {

					Employee emp = ParseSingleEmployeeResult((JsonObject)task.ResponseJSON);

					return new Employee[] {emp};

				} else {
					throw new Exception ("Adapter procedure failed.");
				}
			} catch (Exception ex) {
				Console.WriteLine (ex.Message);
			}
				
			return null;
		}

		public async Task<Employee[]> AllEmployees ()
		{
			WorklightProcedureInvocationData invocationData;
			WorklightResponse task;

			try {

				await ConnectMobileFirst();
					
				invocationData = new WorklightProcedureInvocationData (
					MFPAdapter, "allEmployees", new object[] {});
				task = await WorklightClientInstance.InvokeProcedure (invocationData);

				if (task.Success) {

					Employee[] emp = ParseEmployeeResultSet((JsonObject)task.ResponseJSON);

					return emp;

				} else {
					throw new Exception ("Adapter procedure failed.");
				}
			} catch (Exception ex) {
				Console.WriteLine (ex.Message);
			}

			return null;
		}

		public async Task<GeoLocation> GetGeolocation(string city)
		{
			WorklightProcedureInvocationData invocationData;
			WorklightResponse task;

			try {

				await ConnectMobileFirst();

				invocationData = new WorklightProcedureInvocationData (
					MFPGeoAdapter, "getLocation", new object[] {city});
				task = await WorklightClientInstance.InvokeProcedure (invocationData);

				if (task.Success) {

					GeoLocation loc = ParseLocationResult((JsonObject)task.ResponseJSON);

					return loc;

				} else {
					throw new Exception ("Adapter procedure failed.");
				}
			} catch (Exception ex) {
				Console.WriteLine (ex.Message);
			}

			return null;
		}


		protected Employee[] ParseEmployeeResultSet(JsonObject obj)
		{

			Employee[] emp = new Employee[obj["resultSet"].Count];
			emp = JsonConvert.DeserializeObject<Employee[]> (obj ["resultSet"].ToString ());

			return emp;
		}

		protected Employee ParseSingleEmployeeResult(JsonObject obj)
		{
			Employee emp = JsonConvert.DeserializeObject<Employee> (obj.ToString ());
			return emp;
		}

		protected GeoLocation ParseLocationResult(JsonObject obj)
		{
			GeoLocation loc = JsonConvert.DeserializeObject<GeoLocation> (obj.ToString ());
			return loc;
		}

		protected async Task ConnectMobileFirst()
		{
			if (!Connected) {
				WorklightResponse response = await WorklightClientInstance.Connect ();

				if (response.Success)
					Connected = true;
				else
					throw new Exception ("Cannot connect to server.");
			}
		}
	}

}

