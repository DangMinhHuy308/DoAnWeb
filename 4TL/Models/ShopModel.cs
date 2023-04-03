using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace _4TL.Models
{
    public partial class ShopModel : IdentityDbContext<ApplicationUser>
    {
        public ShopModel()
            : base("name=ShopModel1")
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(e => e.Products)
                .WithOptional(e => e.Category)
                .HasForeignKey(e => e.CateId);

            modelBuilder.Entity<Product>()
                .Property(e => e.Price)
                .HasPrecision(10, 0);

            modelBuilder.Entity<Product>()
                .Property(e => e.FeatureImage)
                .IsUnicode(false);
        }
    }
}
