using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class bookContext: DbContext
    {
        public bookContext(DbContextOptions<bookContext> options) : base(options)
        {

            
        }

        public DbSet<emp> emple { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer("Server=DESKTOP-89M2005\\BCDEMO;Database=Emple;Integrated Security=True");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
