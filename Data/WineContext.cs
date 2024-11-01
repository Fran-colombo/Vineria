using Data.Entities;
using Microsoft.EntityFrameworkCore;


namespace Data
{
    public class WineContext : DbContext
    {

        public DbSet<Wine> Wines { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Tasting> Tastings { get; set; }

        public WineContext(DbContextOptions<WineContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tasting>()
                .HasMany(w => w.Wines)
                .WithMany();
        }
    }
}
