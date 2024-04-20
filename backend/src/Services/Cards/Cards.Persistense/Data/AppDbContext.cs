using System.Reflection;
using Cards.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cards.Persistense.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Card> Cards => Set<Card>();
        public DbSet<CardStatus> CardStatuses => Set<CardStatus>();
        public AppDbContext(DbContextOptions options) : base(options) 
        { 
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}