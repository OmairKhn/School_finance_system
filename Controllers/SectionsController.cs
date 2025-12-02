using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentService.Data;
using StudentService.DTOs;
using StudentService.Models;

namespace StudentService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SectionsController : ControllerBase
    {
        private readonly StudentDbContext _db;
        public SectionsController(StudentDbContext db) => _db = db;

        // GET: api/sections
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var items = await _db.Sections
                .AsNoTracking()
                .Select(s => new SectionReadDto { SectionId = s.SectionId, ClassId = s.ClassId, Name = s.Name })
                .ToListAsync();
            return Ok(items);
        }

        // POST: api/sections
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SectionCreateDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            // ensure class exists
            var cls = await _db.Classes.FindAsync(dto.ClassId);
            if (cls == null) return BadRequest($"Class with id {dto.ClassId} not found.");

            var section = new Section { SectionId = Guid.NewGuid(), ClassId = dto.ClassId, Name = dto.Name };
            _db.Sections.Add(section);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAll), new { id = section.SectionId }, new SectionReadDto { SectionId = section.SectionId, ClassId = section.ClassId, Name = section.Name });
        }
    }
}
