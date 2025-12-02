using System;

namespace StudentService.Models
{
    public class ExpenseRecord
    {
        public Guid ExpenseRecordId { get; set; }
        public Guid ExpenseCategoryId { get; set; }

        public decimal Amount { get; set; }
        public DateTime DateIssued { get; set; }
        public string Description { get; set; } = null!;

        // Navigation
        public ExpenseCategory? Category { get; set; }
    }
}
