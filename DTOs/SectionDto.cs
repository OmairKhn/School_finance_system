using System;
using System.ComponentModel.DataAnnotations;

namespace StudentService.DTOs
{
    public class SectionCreateDto
    {
        [Required]
        public Guid ClassId { get; set; }

        [Required, MaxLength(50)]
        public string Name { get; set; } = null!;
    }

    public class SectionReadDto
    {
        public Guid SectionId { get; set; }
        public Guid ClassId { get; set; }
        public string Name { get; set; } = null!;
    }
}
