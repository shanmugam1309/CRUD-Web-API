using Microsoft.EntityFrameworkCore;

namespace CRUD_Web_API.Models
{
    public class StudentDBContext : DbContext
    {

        public StudentDBContext(DbContextOptions<StudentDBContext> options) : base(options)
        {
        }

        public DbSet<Students> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.; initial Catalog=Students; TrustServerCertificate= True");
        }
    }
}
