using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Persistence.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        public DbSet<Categories> Sugerencia { get; set; }
        public DbSet<SubscriptionType> SubscriptionTypes  { get; set; }
        public DbSet<SubscriptionUser> SubscriptionUsers { get; set; }
        public DbSet<Rol> Rol { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<CatCosts> CatCosts { get; set; }
        public DbSet<CatInventorySuplements> CatInventorySuplements { get; set; }
        public DbSet<DayAperture> DayAperture { get; set; }
        public DbSet<DayClose> DayClose { get; set; }
        public DbSet<InventorySold> InventorySold { get; set; }
        


        public virtual async Task<int> SaveChangesAsync(string email, int userId, string accountType, bool saveAudit = false)
        {
            var result = await base.SaveChangesAsync();
            
            return result;
        }
    }
}
