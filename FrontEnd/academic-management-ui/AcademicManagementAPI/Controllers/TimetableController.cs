using AcademicManagementAPI.Data;
using AcademicManagementAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AcademicManagementAPI.Controllers
{
    [ApiController]
    [Route("api/timetable")]
    public class TimetableController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TimetableController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _context.Timetables.ToListAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var timetable = await _context.Timetables.FindAsync(id);
            return timetable == null ? NotFound() : Ok(timetable);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Timetable timetable)
        {
            _context.Timetables.Add(timetable);
            await _context.SaveChangesAsync();
            return Ok(timetable);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, Timetable timetable)
        {
            if (id != timetable.TimetableID) return BadRequest();

            _context.Entry(timetable).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok(timetable);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var timetable = await _context.Timetables.FindAsync(id);
            if (timetable == null) return NotFound();

            _context.Timetables.Remove(timetable);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
