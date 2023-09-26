using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoffeeShop.Context.Models
{
    public class Drink
    {
        [Key]
        public int DrinkId { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public int? OrderId { get; set; }

        [ForeignKey(nameof(OrderId))]
        [InverseProperty("Drinks")]
        public Order? Order { get; set; }
    }
}
