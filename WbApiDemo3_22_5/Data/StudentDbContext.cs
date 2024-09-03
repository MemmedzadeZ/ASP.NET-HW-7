using Microsoft.EntityFrameworkCore;
using WbApiDemo3_22_5.Entities;

namespace WbApiDemo3_22_5.Data
{
    public class StudentDbContext:DbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options)
            :base(options) { }

        public DbSet<Student>  Students { get; set; }
    }
}
