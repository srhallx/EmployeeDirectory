using System;
using Worklight;
using System.Text;
using System.Json;
using System.Threading.Tasks;

namespace EmployeeDirectory
{
	public class EmployeeDirectoryClient 
	{

		//Our IBM MobileFirst Client instance
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
		public async Task<Employee> FindEmployee(string empName)
		{
			Employee emp = null;

			try
			{

				if (!Connected) {
					WorklightResponse response = await WorklightClientInstance.Connect();

					if (response.Success)
						Connected = true;
					else
						throw new Exception("Cannot connect to server.");
				}

				WorklightProcedureInvocationData invocationData = new WorklightProcedureInvocationData("EmployeeAdapter", "findEmployee", new object[] {empName});
				WorklightResponse task = await WorklightClientInstance.InvokeProcedure(invocationData);

				if (task.Success)
				{
					JsonObject obj = (JsonObject)task.ResponseJSON;

					//parse JSON object
					emp = new Employee(obj["fullname"], obj["email"], obj["phone"]);
				}
				else {
					throw new Exception("Invocation of adapter procedure failed.");
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine (ex.Message);
			}
				
			return emp;
		}
	}
}

