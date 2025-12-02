using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentService.Data;
using StudentService.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly StudentDbContext _db;

        public StudentsController(StudentDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetAll()
        {
            var students = await _db.Students.ToListAsync();
            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> Get(Guid id)
        {
            var student = await _db.Students.FindAsync(id);
            if (student == null) return NotFound();
            return Ok(student);
        }

        [HttpPost]
        public async Task<ActionResult<Student>> Create(Student dto)
        {
            dto.StudentId = Guid.NewGuid();
            _db.Students.Add(dto);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = dto.StudentId }, dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, Student dto)
        {
            var student = await _db.Students.FindAsync(id);
            if (student == null) return NotFound();

            student.FirstName = dto.FirstName;
            student.LastName = dto.LastName;
            student.ClassId = dto.ClassId;
            student.SectionId = dto.SectionId;

            await _db.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var student = await _db.Students.FindAsync(id);
            if (student == null) return NotFound();

            _db.Students.Remove(student);
            await _db.SaveChangesAsync();
            return NoContent();
        }
    }
}
