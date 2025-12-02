using Microsoft.EntityFrameworkCore;
using StudentService.Models;

namespace StudentService.Data
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options) { }

        public DbSet<Student> Students => Set<Student>();
        public DbSet<Class> Classes => Set<Class>();
        public DbSet<Section> Sections => Set<Section>();
    }
}
