using System;
using System.Collections.Generic;

namespace StudentService.Models
{
    public class Class
    {
        public Guid ClassId { get; set; }
        public string Name { get; set; } = null!;
        public List<Student> Students { get; set; } = new();
        public List<Section> Sections { get; set; } = new();
    }
}
