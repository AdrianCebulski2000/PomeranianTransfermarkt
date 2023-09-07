using Microsoft.EntityFrameworkCore;

namespace PomeranianTransfermarkt.Entities
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Players> Players { get; set; }
        public DbSet<Clubs> Clubs { get; set; }
        public DbSet<Trainers> Trainers { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Players>(cb =>
            {
                cb.HasMany(p => p.Clubs)
                .WithMany(c => c.Players);
            });
            modelBuilder.Entity<Clubs>(cb =>
            {
                cb.HasMany(c => c.Trainers);
            });
            modelBuilder.Entity<Trainers>(tb =>
            {
                tb.HasMany(c => c.Players);
            });
        }
    }
}
