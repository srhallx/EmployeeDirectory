using System;
using Worklight;
using System.Text;
using System.Json;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace EmployeeDirectory
{
	public class EmployeeDirectoryClient
	{

		//Our MFP Client instance
		public IWorklightClient WorklightClientInstance { get; private set; }

		private bool Connected { get; set; }

		public EmployeeDirectoryClient (IWorklightClient wlc)
		{
			WorklightClientInstance = wlc;
			Connected = false;
		}

		/// <summary>
		/// Find Employee by name.
		/// </summary>
		/// <returns>The employee record.</returns>
		/// <param name="empName">employee name</param>
		public async Task<Employee[]> FindEmployee (string empName)
		{
			Employee[] emp;

			try {
				//
				// Connect to MFP
				//
				if (!Connected) {
					WorklightResponse response = await WorklightClientInstance.Connect ();

					if (response.Success)
						Connected = true;
					else
						throw new Exception ("Cannot connect to server.");
				}

				//
				// Invoke MFP Procedure findEmployee
				//
				WorklightProcedureInvocationData invocationData = new WorklightProcedureInvocationData ("mysqladapter", "findEmployee", new object[] { empName });
				WorklightResponse task = await WorklightClientInstance.InvokeProcedure (invocationData);

				if (task.Success) {
					JsonObject obj = (JsonObject)task.ResponseJSON;

					emp = new Employee[obj["resultSet"].Count];

					emp = JsonConvert.DeserializeObject<Employee[]> (obj ["resultSet"].ToString ());
					return emp;

				} else {
					throw new Exception ("Invocation of adapter procedure failed.");
				}
			} catch (Exception ex) {
				Console.WriteLine (ex.Message);
			}
				
			return null;
		}

		public async Task<Employee[]> AllEmployees ()
		{
			Employee[] emp;

			try {
				//
				// Connect to MFP
				//
				if (!Connected) {
					WorklightResponse response = await WorklightClientInstance.Connect ();

					if (response.Success)
						Connected = true;
					else
						throw new Exception ("Cannot connect to server.");
				}

				//
				// Invoke MFP Procedure findEmployee
				//
				WorklightProcedureInvocationData invocationData = new WorklightProcedureInvocationData ("mysqladapter", "allEmployees", new object[] {});
				WorklightResponse task = await WorklightClientInstance.InvokeProcedure (invocationData);

				if (task.Success) {
					JsonObject obj = (JsonObject)task.ResponseJSON;

					emp = new Employee[obj["resultSet"].Count];

					emp = JsonConvert.DeserializeObject<Employee[]> (obj ["resultSet"].ToString ());
					return emp;

				} else {
					throw new Exception ("Invocation of adapter procedure failed.");
				}
			} catch (Exception ex) {
				Console.WriteLine (ex.Message);
			}

			return null;
		}
	}

}

