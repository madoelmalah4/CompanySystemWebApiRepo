using AutoMapper;
using CompanyManagmentSystem.Models;
using CompanyManagmentSystem.Models.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CompanyManagmentSystem.Models.DTOs;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CompanyManagmentSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {

        private readonly AppDbContext _context;
        public EmployeesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult CreateEmployee(Employee_DTO_Get employee)
        {
            if(employee == null)
            {
                return BadRequest("No Data Received");
            }   
            _context.Employees.Add(new Employee
            {
                Name = employee.Name,
                Position = employee.Position
            });
            _context.SaveChanges();
            return Ok(new {message = "Add Successfully" });
        }

        [HttpGet]
        public IActionResult GetEmployees()
        {
           var employees = _context.Employees.ToList();
            if (employees.Count == 0)
                return Ok(new {isEmpty = true });
            var listOfEmployees = new List<Employee_DTO_Get>();
            for (int i = 0; i < employees.Count; i++)
            {
                listOfEmployees.Add(new Employee_DTO_Get
                {
                    Name = employees[i].Name,
                    Position = employees[i].Position
                });
            }
            return Ok(new { isEmpty = false , listOfEmployees});
        }

        [HttpGet("{id}")]
        public IActionResult GetEmployeeById(int id)
        {
            var emp = _context.Employees.FirstOrDefault(x => x.Id == id);
            if (emp == null)
                return NotFound(new { message = "Emp Is Not Found" });

            var employeeDTO = new Employee_DTO_Get
            {
                Name = emp.Name,
                Position = emp.Position
            };

            return Ok(new { message = "Found" , emp});
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            var emp = _context.Employees.FirstOrDefault(x => x.Id == id);
            if (emp == null)
                return NotFound(new { message = "Emp Is Not Found" });
            _context.Employees.Remove(emp);
            _context.SaveChanges();
            return Ok("Deleted Successfully");
        }

        [HttpPut("{id}")]
        public IActionResult EditEmployee(Employee emp,int id)
        {
            var oldEmp = _context.Employees.AsNoTracking().FirstOrDefault(x => x.Id == id);
            if (oldEmp == null)
                return NotFound("Not Found");

            if (!ModelState.IsValid)
                return BadRequest();

            emp.Id = id;
            _context.Employees.Update(emp);
            _context.SaveChanges();
            return Ok("Edited Successfully");
        }

    }
}
