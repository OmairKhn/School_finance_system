using System;

namespace StudentService.Models
{
    public class Section
    {
        public Guid SectionId { get; set; }
        public Guid ClassId { get; set; }
        public string Name { get; set; } = null!;
    }
}
