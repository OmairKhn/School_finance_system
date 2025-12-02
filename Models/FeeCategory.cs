using System;
using System.Collections.Generic;

namespace StudentService.Models
{
    public class FeeCategory
    {
        public Guid FeeCategoryId { get; set; }
        public string Name { get; set; } = null!;

        // Navigation
        public List<FeeRecord> FeeRecords { get; set; } = new();
    }
}
