using Microsoft.EntityFrameworkCore;
using RestApiAnimals.DataAccess.Entities;

namespace RestApiAnimals.DataAccess.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<AnimalEntity> Animals { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AnimalEntity>()
                .HasDiscriminator<string>("Species")
                .HasValue<LionEntity>("Lion")
                .HasValue<ElephantEntity>("Elephant")
                .HasValue<PenguinEntity>("Penguin");
        }
    }
}
