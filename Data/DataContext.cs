using bitacorabackend.Models;
using Microsoft.EntityFrameworkCore;

namespace bitacorabackend.Data
{
    public class DataContext : DbContext
    {
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Bitacory> Bitacories { get; set; }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=bitacory.db");
            }
        }
    }
}