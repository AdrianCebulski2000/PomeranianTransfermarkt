using Microsoft.EntityFrameworkCore;

namespace PomeranianTransfermarkt.Entities
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Players> Players { get; set; }
        
    }
}
