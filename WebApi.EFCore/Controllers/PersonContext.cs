using DataModels;
using Microsoft.EntityFrameworkCore;

namespace WebApi.EFCore.Controllers
{
    public class PersonContext : DbContext
    {
        public PersonContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<PersonModel> People { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PersonModel>().ToTable("TB_PERSON");
            modelBuilder.Entity<PersonModel>().HasKey(lc => new { lc.UserId });
        }
    }
}
