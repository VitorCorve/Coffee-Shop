using CoffeeShop.Context.Models;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace CoffeeShop.Context.Context
{
    public class CoffeeShopContext : DbContext
    {
        public DbSet<Drink> Drinks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // TODO: Remove 
            if (optionsBuilder.IsConfigured != true)
            {
                string connectionString = ConfigurationManager.ConnectionStrings["CoffeeShopDbContext"].ConnectionString;
                optionsBuilder.UseSqlServer(connectionString);
            }

            base.OnConfiguring(optionsBuilder);
        }

        public CoffeeShopContext(DbContextOptions options) : base(options)
        {
        }
    }
}
