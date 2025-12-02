using System;
using System.ComponentModel.DataAnnotations;

namespace StudentService.DTOs
{
    public class ClassCreateDto
    {
        [Required, MaxLength(100)]
        public string Name { get; set; } = null!;
    }

    public class ClassReadDto
    {
        public Guid ClassId { get; set; }
        public string Name { get; set; } = null!;
    }
}
