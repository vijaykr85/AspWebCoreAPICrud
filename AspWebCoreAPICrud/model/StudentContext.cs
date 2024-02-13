using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace AspWebCoreAPICrud.model
{
    public class StudentContext:DbContext
    {
        private readonly DbContextOptions options;

        public StudentContext(DbContextOptions options) : base(options)
        {
            this.options = options;
        }
        public DbSet<Student> StudentsMarkseet { get; set; }

    }
}
