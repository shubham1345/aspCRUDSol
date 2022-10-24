using Microsoft.EntityFrameworkCore;

namespace aspCRUD.Models
{
    public class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> options) : base(options)
        {

        }
        public DbSet<StudentModel> Tb_Student { get; set; }
    }
}
