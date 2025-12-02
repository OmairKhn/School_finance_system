using System;

namespace StudentService.Models
{
    public class FeeRecord
    {
        public Guid FeeRecordId { get; set; }
        public Guid StudentId { get; set; }
        public Guid FeeCategoryId { get; set; }

        public decimal Amount { get; set; }
        public DateTime DatePaid { get; set; }

        // Navigation
        public Student? Student { get; set; }
        public FeeCategory? Category { get; set; }
    }
}
