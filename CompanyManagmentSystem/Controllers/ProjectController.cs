using CompanyManagmentSystem.Models;
using CompanyManagmentSystem.Models.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CompanyManagmentSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {

        readonly AppDbContext _context;

        public ProjectController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllProjects()
        {
            var project = _context.Projects.ToList();
            if (project.Count == 0)
                return Ok(new { isempty = true});
            return Ok(new { isempty = false , project});
        }
        [HttpGet("{id}")]
        public IActionResult GetProjectById(int id)
        {
            var project = _context.Projects.FirstOrDefault(x => x.Id == id);
            if (project == null)
                return NotFound(new{ isFound = false });
            return Ok(project);
        }

        [HttpPost]
        public IActionResult PostNewProject(Project project)
        {
            if (project == null)
                return BadRequest("");

            project.Id = 0;

            _context.Projects.Add(project);
            _context.SaveChanges();
            return Ok("Added Successfully");
        }

        [HttpPut("{id}")]
        public IActionResult EditOnProject(Project project , int id)
        {
            var OldProject = _context.Projects.AsNoTracking().FirstOrDefault(x => x.Id == id);
            if (OldProject == null)
                return NotFound("");
            if (!ModelState.IsValid)
                return BadRequest("");

            project.Id = id;
            _context.Projects.Update(project);
            _context.SaveChanges();
            return Ok("Edited");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProject(int id)
        {
            var project = _context.Projects.FirstOrDefault(x => x.Id == id);
            if (project == null)
                return NotFound();
            _context.Projects.Remove(project);
            _context.SaveChanges();
            return Ok("Deleted");
        }
    }
}
