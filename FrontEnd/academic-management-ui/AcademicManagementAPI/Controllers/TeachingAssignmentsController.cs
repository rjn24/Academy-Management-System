using AcademicManagementAPI.Data;
using AcademicManagementAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AcademicManagementAPI.Controllers
{
    [ApiController]
    [Route("api/teachingassignments")]
    public class TeachingAssignmentsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TeachingAssignmentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _context.TeachingAssignments.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Create(TeachingAssignment assignment)
        {
            _context.TeachingAssignments.Add(assignment);
            await _context.SaveChangesAsync();
            return Ok(assignment);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var assignment = await _context.TeachingAssignments.FindAsync(id);
            if (assignment == null) return NotFound();

            _context.TeachingAssignments.Remove(assignment);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
