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
            builder.Entity<Category>().Property(p => p.name).IsRequired().HasMaxLength(100);
            builder.Entity<Category>().Property(p => p.short_name).IsRequired().HasMaxLength(50);
            builder.Entity<Category>().Property(p => p.special_instructions).IsRequired().HasMaxLength(4000);
            builder.Entity<Category>().Property(p => p.url).IsRequired().HasMaxLength(1000);
            builder.Entity<Category>().HasMany(p => p.menu_items).WithOne(p => p.category).HasForeignKey(p => p.categoryId);

            builder.Entity<Category>().HasData{
                new Category{ name = "Lunch ", short_name = "L", special_instructions = "Sunday-Friday 11:15am-3:00pm. Served with your choice of rice (Vegetable Fried RIce, Steamed Rice, Brown Rice), AND EITHER soup (Hot & Sour, Wonton, Vegetable, Egg Drop, Chicken Corn Soup) OR veggie egg roll. $1.00 extra to have both soup and egg roll.", url = "aguardando"},
                new Category{ name = "Soup ", short_name = "A", special_instructions = "", url = "aguardando"}
            };

            builder.Entity<MenuItem>().ToTable("MenuItems");
            builder.Entity<MenuItem>().HasKey(p => p.id);
            builder.Entity<MenuItem>().Property(p => p.id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<MenuItem>().Property(p => p.description).IsRequired().HasMaxLength(4000);
            builder.Entity<MenuItem>().Property(p => p.large_portion_name).IsRequired().HasMaxLength(100);
            builder.Entity<MenuItem>().Property(p => p.name).IsRequired().HasMaxLength(100);
            builder.Entity<MenuItem>().Property(p => p.price_large).IsRequired();
            builder.Entity<MenuItem>().Property(p => p.price_small).IsRequired();
            builder.Entity<MenuItem>().Property(p => p.short_name).IsRequired().HasMaxLength(50);
            builder.Entity<MenuItem>().Property(p => p.small_portion_name).IsRequired().HasMaxLength(100);

            builder.Entity<Category>()
                .HasMany(p => p.menu_items)
                .WithOne(p => p.category)
                .HasForeignKey(p => p.categoryId);
        }
    }
}