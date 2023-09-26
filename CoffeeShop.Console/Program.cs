using CoffeeShop.Context.Context;
using CoffeeShop.Context.Models;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

//var context = GetContext();
//Drink drink = new()
//{
//    Cost = 8.0M,
//    Name = "Coffee"
//};

//context.Drinks.Add(drink);

//await context.SaveChangesAsync();
//context.Dispose();

Console.ReadLine();
static CoffeeShopContext GetContext()
{
    string connectionString = ConfigurationManager.ConnectionStrings["CoffeeShopDbContext"].ConnectionString;
    DbContextOptionsBuilder<CoffeeShopContext> options = new();
    options.UseSqlServer(connectionString);
    CoffeeShopContext context = new(options.Options);
    return context;
}