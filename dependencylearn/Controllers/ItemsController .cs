//using Microsoft.AspNetCore.Mvc;
//using WebApplication1.model;

//namespace WebApplication1.Controllers
//{
//    [ApiController]
//    [Route("api/[controller]")]
//    public class ItemsController : ControllerBase
//    {
//        private static List<Employee> employ = new List<Employee>
//            {
//            new Employee {Id=1,Name="Arun",Salary=80000},
//            new Employee {Id=2,Name="Arjun",Salary=100000},
//            new Employee {Id=1,Name="Arunima",Salary=80000}
//            };
//        [HttpGet]
//        public ActionResult<IEnumerable<Employee>> Getemploy()
//        {
//            return Ok(employ);
//        }

//        [HttpGet("{id}")]
//        public IActionResult Getemploy(int id)
//        {
//            var item = employ.FirstOrDefault(i => i.Id == id);
//            if (item == null)
//            {
//                return NotFound();
//            }

//            return Ok(item);
//        }

//        [HttpPost]
//        public IActionResult AddEmployee([FromBody] Employee newEmployee)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }
//            newEmployee.Id = employ.Count + 1;
//            employ.Add(newEmployee);
//            return Ok($"your new employe:{newEmployee.Name}");
//        }

//        [HttpPut("{id}")]
//    public IActionResult UpdateEmployee(int id, Employee  UpdatedEmploy)
//        {
//            var emply = employ.FirstOrDefault(i => i.Id == id);
//            if (emply == null)
//            {
//                return NotFound();
//            }
//            emply.Name = UpdatedEmploy.Name;
//            emply.Salary = UpdatedEmploy.Salary;
//            return Ok($"successfully Updated{emply.Name}");

//        }

//        [HttpDelete("{id}")]

//        public IActionResult  DeleteEmploy(int id)
//        {
//            var emply = employ.FirstOrDefault(i => i.Id == id);
//                if (emply == null)
//            {
//                return NotFound();
//            }
//            employ.Remove(emply);
//            return Ok($"employ removed successfully:{emply.Name}");
//        }
//    }
//}



using Microsoft.AspNetCore.Mvc;
using WebApplication1.model;
using WebApplication1.Services;
using System.Collections.Generic;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemsController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        // Inject IEmployeeService into the controller
        public ItemsController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        // GET: api/items
        [HttpGet]
        public ActionResult<IEnumerable<Employee>> GetEmployees()
        {
            var employees = _employeeService.GetEmployees();
            return Ok(employees);
        }

        // GET: api/items/1
        [HttpGet("{id}")]
        public IActionResult GetEmployee(int id)
        {
            var employee = _employeeService.GetEmployeeById(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        // POST: api/items
        [HttpPost]
        public IActionResult AddEmployee([FromBody] Employee newEmployee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _employeeService.AddEmployee(newEmployee);
            return Ok($"New employee added: {newEmployee.Name}");
        }

        // PUT: api/items/1
        [HttpPut("{id}")]
        public IActionResult UpdateEmployee(int id, [FromBody] Employee updatedEmployee)
        {
            var employee = _employeeService.GetEmployeeById(id);
            if (employee == null)
            {
                return NotFound();
            }

            _employeeService.UpdateEmployee(id, updatedEmployee);
            return Ok($"Successfully updated: {updatedEmployee.Name}");
        }

        // DELETE: api/items/1
        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            var employee = _employeeService.GetEmployeeById(id);
            if (employee == null)
            {
                return NotFound();
            }

            _employeeService.DeleteEmployee(id);
            return Ok($"Employee removed successfully: {employee.Name}");
        }
    }
}
