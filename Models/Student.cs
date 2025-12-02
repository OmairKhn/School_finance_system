using System;

namespace StudentService.Models
{
    public class Student
    {
        public Guid StudentId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTime AdmissionDate { get; set; }

        public Guid? ClassId { get; set; }
        public Guid? SectionId { get; set; }

        // Navigation properties
        public Class? Class { get; set; }
        public Section? Section { get; set; }
    }
}
