using DataModels;
using Microsoft.EntityFrameworkCore;

namespace MockData.Models
{
    public class PersonContext : DbContext
    {
        public DbSet<PersonModel> People { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Data Source=localhost,1600;Initial Catalog=DB_BENCHMARK;User ID=sa;Password=DBPass123;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PersonModel>().ToTable("TB_PERSON");
            modelBuilder.Entity<PersonModel>().HasKey(lc => new { lc.UserId });
        }
    }
}
