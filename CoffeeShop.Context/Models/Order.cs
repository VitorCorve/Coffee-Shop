using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoffeeShop.Context.Models
{
    public class Order
    {
        public Order()
        {
            Drinks = new HashSet<Drink>();
        }

        [Key]
        public int OrderId { get; set; }
        public int CustomerId { get; set; }

        [ForeignKey(nameof(CustomerId))]
        [InverseProperty("Orders")]
        public Customer Customer { get; set; }

        [InverseProperty(nameof(Drink.Order))]
        public IEnumerable<Drink> Drinks { get; set; }

        public DateTime OrderDate { get; set; }
    }
}
