using System;

namespace EmployeeDirectory
{
	public class Employee
	{
		public Employee ()
		{
		}

		public string Name { get; set; }
		public string Email {get; set; }
		public string Phone { get; set;}

		public Employee (string name, string email, string phone)
		{
			Name = name;
			Email = email;
			Phone = phone;
		}
	}
}

