using BannerFlowDemo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BannerFlowDemo.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Banner> Banners { get; set; }

        public override int SaveChanges()
        {
            AddStateInfo();
            return base.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            AddStateInfo();
            return await base.SaveChangesAsync();
        }

        private void AddStateInfo()
        {
            var entries = ChangeTracker.Entries().Where(x => x.Entity is Banner && (x.State == EntityState.Added || x.State == EntityState.Modified));
            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    ((Banner)entry.Entity).Created = DateTime.Now;
                }
                ((Banner)entry.Entity).Modified = DateTime.Now;
            }
        }
    }
}
