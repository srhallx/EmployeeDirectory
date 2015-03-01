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


		public async Task<Employee[]> FindEmployee (string empName)
		{
			WorklightProcedureInvocationData invocationData;
			WorklightResponse task;

			try {
				await ConnectMobileFirst();
					
				invocationData = new WorklightProcedureInvocationData (
						"mysqladapter", "findEmployee", new object[] { empName });
				task = await WorklightClientInstance.InvokeProcedure (invocationData);

				if (task.Success) {

					Employee[] emp = ParseResultSet((JsonObject)task.ResponseJSON);

					return emp;

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
					"mysqladapter", "allEmployees", new object[] {});
				task = await WorklightClientInstance.InvokeProcedure (invocationData);

				if (task.Success) {

					Employee[] emp = ParseResultSet((JsonObject)task.ResponseJSON);

					return emp;

				} else {
					throw new Exception ("Adapter procedure failed.");
				}
			} catch (Exception ex) {
				Console.WriteLine (ex.Message);
			}

			return null;
		}


		protected Employee[] ParseResultSet(JsonObject obj)
		{

			Employee[] emp = new Employee[obj["resultSet"].Count];
			emp = JsonConvert.DeserializeObject<Employee[]> (obj ["resultSet"].ToString ());

			return emp;
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

