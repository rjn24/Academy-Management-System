using AcademicManagementAPI.Data;
using AcademicManagementAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AcademicManagementAPI.Controllers
{
  [Authorize]
  [ApiController]
  [Route("api/professors")]
    public class ProfessorsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProfessorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _context.Professors.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Create(Professor professor)
        {
            _context.Professors.Add(professor);
            await _context.SaveChangesAsync();
            return Ok(professor);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, Professor professor)
        {
            if (id != professor.ProfessorID) return BadRequest();

            _context.Entry(professor).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok(professor);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var professor = await _context.Professors.FindAsync(id);
            if (professor == null) return NotFound();

            _context.Professors.Remove(professor);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
