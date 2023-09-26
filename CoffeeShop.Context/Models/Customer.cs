using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoffeeShop.Context.Models
{
    public class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }
        [Key]
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public DateTime RegistrationDate { get; set; }

        [InverseProperty(nameof(Order.Customer))]
        public IEnumerable<Order> Orders { get; set; }
    }
}
