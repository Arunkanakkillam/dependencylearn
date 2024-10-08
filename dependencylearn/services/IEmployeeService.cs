using WebApplication1.model;
namespace WebApplication1.Services
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetEmployees();
        Employee? GetEmployeeById(int id);
        void AddEmployee(Employee employee);
        void UpdateEmployee(int id, Employee updatedEmployee);
        void DeleteEmployee(int id);
    }
}
