using Microsoft.EntityFrameworkCore;

namespace CitizenData.Models
{
    public class EntityContext : DbContext
    {
        public DbSet<Entity> Entities { get; set; }
        // Add DbSet properties for other entities if needed

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Configure database connection string
            optionsBuilder.UseSqlServer("CitizenCS");
        }
    }
}
