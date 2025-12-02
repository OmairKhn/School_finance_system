using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentService.Data;
using StudentService.DTOs;
using StudentService.Models;

namespace StudentService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClassesController : ControllerBase
    {
        private readonly StudentDbContext _db;
        public ClassesController(StudentDbContext db) => _db = db;

        // GET: api/classes
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var items = await _db.Classes
                .AsNoTracking()
                .Select(c => new ClassReadDto { ClassId = c.ClassId, Name = c.Name })
                .ToListAsync();
            return Ok(items);
        }

        // POST: api/classes
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ClassCreateDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var c = new Class { ClassId = Guid.NewGuid(), Name = dto.Name };
            _db.Classes.Add(c);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAll), new { id = c.ClassId }, new ClassReadDto { ClassId = c.ClassId, Name = c.Name });
        }
    }
}
