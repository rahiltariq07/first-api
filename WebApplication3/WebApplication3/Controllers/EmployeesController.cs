using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Entities;
using WebApplication3.Requests;
using WebApplication3.Responses;

namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly EmployeeDbContext _employeeDbContext;

        public EmployeesController(EmployeeDbContext employeeDbContext)
        {
            _employeeDbContext = employeeDbContext;
        }

        [HttpGet]

        public IActionResult GetAll() 
        {
            var result = (from employee in _employeeDbContext.Employees
                         join department in _employeeDbContext.Departments
                         on employee.DepartmentId equals department.Id
                         select new EmployeeResponse
                         {
                             Address = employee.Address,
                             City = employee.City,
                             EmployeeName = employee.Name,
                             DepartmentName = department.Name,
                             EmployeeId = employee.Id,
                         }).OrderByDescending(x => x.EmployeeName).Where(x => x.City == "Srinagar" && x.DepartmentName == "Sales");

            return Ok(result);
        }

        [HttpGet("{id}")]

        public IActionResult Get(int id) 
        {
            return Ok(_employeeDbContext.Employees.FirstOrDefault(x => x.Id == id));
        }

        [HttpPost]
        [ProducesResponseType(typeof(Employee), 201)]

        public IActionResult CreateEmployee(EmployeeRequest request)
        {
            Employee employee = new()
            {
                Address = request.Address,
                City = request.City,
                Name = request.Name,
                DepartmentId = request.DepartmentId
            };

            _employeeDbContext.Employees.Add(employee);
            _employeeDbContext.SaveChanges();

            return CreatedAtAction("Get", new {id = employee.Id}, employee);
        }

        [HttpDelete("{id}")]

        public IActionResult Delete(int id) 
        { 
            var employee = _employeeDbContext.Employees.FirstOrDefault(x =>x.Id == id);
            _employeeDbContext.Employees.Remove(employee);
            _employeeDbContext.SaveChanges();

            return NoContent();
        }

        [HttpPut("{id}")]

        public IActionResult Update(int id, EmployeeRequest request) 
        {
            var employee = _employeeDbContext.Employees.FirstOrDefault(x => x.Id == id);
            employee.Name = request.Name;
            employee.Address = request.Address;
            employee.City = request.City;
            _employeeDbContext.Employees.Update(employee);
            _employeeDbContext.SaveChanges();

            return Ok(employee);
        }
    }
}
