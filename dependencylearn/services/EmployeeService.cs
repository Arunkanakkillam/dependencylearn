using WebApplication1.model;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication1.Services
{
	public class EmployeeService : IEmployeeService
	{
		private List<Employee> _employees = new List<Employee>
		{
			new Employee {Id=1, Name="Arun", Salary=80000},
			new Employee {Id=2, Name="Arjun", Salary=100000},
			new Employee {Id=3, Name="Arunima", Salary=80000}
		};

		public IEnumerable<Employee> GetEmployees()
		{
			return _employees;
		}

		public Employee? GetEmployeeById(int id)
		{
			return _employees.FirstOrDefault(e => e.Id == id);
		}

		public void AddEmployee(Employee employee)
		{
			employee.Id = _employees.Count + 1;
			_employees.Add(employee);
		}

		public void UpdateEmployee(int id, Employee updatedEmployee)
		{
			var employee = _employees.FirstOrDefault(e => e.Id == id);
			if (employee != null)
			{
				employee.Name = updatedEmployee.Name;
				employee.Salary = updatedEmployee.Salary;
			}
		}

		public void DeleteEmployee(int id)
		{
			var employee = _employees.FirstOrDefault(e => e.Id == id);
			if (employee != null)
			{
				_employees.Remove(employee);
			}
		}
	}
}
