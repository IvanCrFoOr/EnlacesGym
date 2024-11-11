﻿using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Persistence.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        public DbSet<Place> Places { get; set; }
        public DbSet<Categories> Sugerencia { get; set; }
        public DbSet<PlacesPhotos> PlacesPhotos { get; set; }
        public DbSet<SubscriptionType> SubscriptionTypes  { get; set; }
        public DbSet<SubscriptionUser> SubscriptionUsers { get; set; }
        public DbSet<Rol> Rol { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<CatCosts> CatCosts { get; set; }


        public virtual async Task<int> SaveChangesAsync(string email, int userId, string accountType, bool saveAudit = false)
        {
            var result = await base.SaveChangesAsync();
            
            return result;
        }
    }
}
