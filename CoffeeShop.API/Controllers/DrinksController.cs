using CoffeeShop.Context.Context;
using CoffeeShop.Context.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShop.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DrinksController : ControllerBase
    {
        private readonly CoffeeShopContext _context;
        public DrinksController(CoffeeShopContext context)
        {
            _context = context;
        }

        [HttpGet("GetDrinks")]
        public async Task<ActionResult<IEnumerable<Drink>>> GetDrinksAsync()
        {
            return await _context.Drinks.ToListAsync();
        }

        [HttpPost("CreateDrink")]
        public async Task<ActionResult> CreateDrinkAsync(Drink drink)
        {
            ActionResult result = Ok();

            if (string.IsNullOrWhiteSpace(drink.Name))
                result = BadRequest("Drink name is empty.");
            if (drink.Cost == 0.0M)
                result = BadRequest("Incorrect price.");

            if (result is OkResult)
            {
                _context.Drinks.Add(drink);
                await _context.SaveChangesAsync();
            }
    

            return result;
        }

        [HttpDelete("DeleteDrink")]
        public async Task<ActionResult> DeleteDrinkAsync(int drinkId)
        {
            ActionResult result = Ok();

            Drink? drink = _context.Drinks.FirstOrDefault(x => x.DrinkId == drinkId);
            if (drink is null)
                result = BadRequest("Drink with specified id isn't exists.");

            else
            {
                _context.Drinks.Remove(drink);
                await _context.SaveChangesAsync();
            }

            return result;
        }
    }
}
