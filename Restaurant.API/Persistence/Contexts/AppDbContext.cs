using Microsoft.EntityFrameworkCore;
using Restaurant.API.Domain.Models;

namespace Restaurant.API.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Category>().ToTable("Categories");
            builder.Entity<Category>().HasKey(p => p.id);
            builder.Entity<Category>().Property(p => p.id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Category>().Property(p => p.name).IsRequired().HasMaxLength(30);
            builder.Entity<Category>().HasMany(p => p.menu_items).WithOne(p => p.category).HasForeignKey(p => p.categoryId);

            builder.Entity<Category>().HasData{
                new Category{ id = 100, name = "Fruits and Vegetables"},
                new Category{ id = 101, name = "Dairy"}
            };
            
        }
    }
}