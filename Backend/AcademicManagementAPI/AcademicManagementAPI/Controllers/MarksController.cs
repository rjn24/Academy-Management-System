using AcademicManagementAPI.Data;
using AcademicManagementAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AcademicManagementAPI.Controllers
{

  [Authorize]
  [ApiController]
  [Route("api/marks")]
    public class MarksController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MarksController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _context.Marks.ToListAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var marks = await _context.Marks.FindAsync(id);
            return marks == null ? NotFound() : Ok(marks);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Marks marks)
        {
            _context.Marks.Add(marks);
            await _context.SaveChangesAsync();
            return Ok(marks);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, Marks marks)
        {
            if (id != marks.MarksID) return BadRequest();

            _context.Entry(marks).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok(marks);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var marks = await _context.Marks.FindAsync(id);
            if (marks == null) return NotFound();

            _context.Marks.Remove(marks);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
