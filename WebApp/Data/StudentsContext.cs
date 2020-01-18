using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp.DataAccess
{
    public class StudentsContext : DbContext
    {
        public StudentsContext()
        {
        }

        public StudentsContext(DbContextOptions<StudentsContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
    }
}