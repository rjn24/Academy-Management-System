using AcademicManagementAPI.Data;
using AcademicManagementAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AcademicManagementAPI.Controllers
{
  [Authorize]
  [ApiController]
  [Route("api/attendance")]
    public class AttendanceController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AttendanceController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _context.Attendances.ToListAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var attendance = await _context.Attendances.FindAsync(id);
            return attendance == null ? NotFound() : Ok(attendance);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Attendance attendance)
        {
            _context.Attendances.Add(attendance);
            await _context.SaveChangesAsync();
            return Ok(attendance);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, Attendance attendance)
        {
            if (id != attendance.AttendanceID) return BadRequest();

            _context.Entry(attendance).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok(attendance);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var attendance = await _context.Attendances.FindAsync(id);
            if (attendance == null) return NotFound();

            _context.Attendances.Remove(attendance);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
