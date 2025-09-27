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
    public class ContractController : ControllerBase
    {
        readonly AppDbContext _context;
        public ContractController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllContracts()
        {
            var cons = _context.Contracts
            .Include(c => c.Employee) // ensures Employee is loaded
            .Select(c => new
            {
                c.Id,
                c.Title,
                c.StartDate,
                c.EndDate,
                c.EmployeeId,
                Employee = new { c.Employee.Id, c.Employee.Name }
            })
            .ToList();
            return Ok(cons);

        }

        [HttpGet("{id}")]
        public IActionResult GetConById(int id)
        {
            var con = _context.Contracts.FirstOrDefault(x => x.Id == id);
            if (con == null )
                return BadRequest("ShitMan");

            return Ok(con);
        }

        [HttpPost]
        public IActionResult PostNewContract(Contract con)
        {
            if (con == null || !ModelState.IsValid)
                return BadRequest("Invalid Data");
            _context.Contracts.Add(con);
            _context.SaveChanges();
            return Ok("Added Success");
        }

        [HttpPut("{id}")]
        public IActionResult EditContract(Contract con,int id)
        {
            var OldCon = _context.Contracts.AsNoTracking().FirstOrDefault(x => x.Id == id);
            if (OldCon == null)
                return NotFound();
            if (!ModelState.IsValid)
                return BadRequest();

            con.Id = id;
            _context.Contracts.Update(con);
            _context.SaveChanges();
            return Ok("Edited");

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCon(int id)
        {
            var con = _context.Contracts.FirstOrDefault(x => x.Id == id);
            if (con == null)
                return NotFound();

            _context.Contracts.Remove(con);
            _context.SaveChanges();
            return Ok("Deleted");
        }


    }
}
