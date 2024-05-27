using EFCore8FullTextIssueExample.Model;
using Microsoft.EntityFrameworkCore;

namespace EFCore8FullTextIssueExample
{
    public class FullTextExampleDataContext : DbContext
    {
        public FullTextExampleDataContext()
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=[YOURSERVER]; Initial Catalog=FullTextExample;User ID=[YOURUSERID];Password=[YOURPASSWORD];");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasQueryFilter(e => e.TenantId == Cons.TENANT_ID);
            modelBuilder.Entity<Store>().HasQueryFilter(e => e.TenantId == Cons.TENANT_ID);
            modelBuilder.Entity<StoreProduct>().HasQueryFilter(e => e.TenantId == Cons.TENANT_ID);

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<StoreProduct> StoreProducts { get; set; }
    }
}
