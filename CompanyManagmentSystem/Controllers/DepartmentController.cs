using CompanyManagmentSystem.Models;
using CompanyManagmentSystem.Models.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace CompanyManagmentSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        readonly AppDbContext _context;
        public DepartmentController(AppDbContext context)
        {
         _context = context;   
        }

        [HttpGet]
        public IActionResult GetAllDepartmnet()
        {
            var Departments = _context.Departments.ToList();
            if (Departments.Count == 0)
            {
                return Ok(new {isEmpty = true });
            }
            return Ok(new { isEmpty = false , Departments });
        }

        [HttpGet("{id}")]
        public IActionResult GetDepById(int id)
        {
            var dep = _context.Departments.FirstOrDefault(x => x.Id == id);
            if (dep == null)
            {
                return NotFound();
            }
            return Ok(dep);
        }

        [HttpPost]
        public IActionResult PostNewDep(Department Dep)
        {
            if (Dep == null)
                return BadRequest("Null Value");
            if (!ModelState.IsValid)
                return BadRequest("invalid data");

            _context.Departments.Add(Dep);
            _context.SaveChanges();
            return Ok("Added Success");
        }

        [HttpPut]
        public IActionResult EditDep (Department dep , int id)
        {
            var Olddep = _context.Departments.AsNoTracking().FirstOrDefault(x => x.Id == id);
            if (Olddep == null)
                return NotFound("not found");
            if (!ModelState.IsValid)
                return BadRequest("Invalid Data");

            dep.Id = id;
            _context.Departments.Update(dep);
            _context.SaveChanges();
            return Ok("edited");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDep(int id)
        {
            var dep = _context.Departments.FirstOrDefault(x => x.Id == id);
            if (dep == null)
                return NotFound("notFound");
            _context.Departments.Remove(dep);
            _context.SaveChanges();
            return Ok("Deleted");
        }
    }
}
