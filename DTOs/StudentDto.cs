using System;
using System.ComponentModel.DataAnnotations;

namespace StudentService.DTOs
{
    public class StudentCreateDto
    {
        [Required, MaxLength(100)]
        public string FirstName { get; set; } = null!;

        [Required, MaxLength(100)]
        public string LastName { get; set; } = null!;

        public Guid? ClassId { get; set; }
        public Guid? SectionId { get; set; }
        public DateTime? AdmissionDate { get; set; }
    }

    public class StudentUpdateDto
    {
        [Required, MaxLength(100)]
        public string FirstName { get; set; } = null!;

        [Required, MaxLength(100)]
        public string LastName { get; set; } = null!;

        public Guid? ClassId { get; set; }
        public Guid? SectionId { get; set; }
        public DateTime? AdmissionDate { get; set; }
    }

    public class StudentReadDto
    {
        public Guid StudentId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public Guid? ClassId { get; set; }
        public Guid? SectionId { get; set; }
        public DateTime AdmissionDate { get; set; }
    }
}
