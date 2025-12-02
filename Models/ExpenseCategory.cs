using System;
using System.Collections.Generic;

namespace StudentService.Models
{
    public class ExpenseCategory
    {
        public Guid ExpenseCategoryId { get; set; }
        public string Name { get; set; } = null!;

        // Navigation
        public List<ExpenseRecord> ExpenseRecords { get; set; } = new();
    }
}
