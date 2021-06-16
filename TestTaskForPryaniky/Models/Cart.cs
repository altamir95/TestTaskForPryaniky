using System.Collections.Generic;

namespace TestTaskForPryaniky.Models
{
    public class Cart
    {
        public int Id { get; set; } 
        public int UserId { get; set; }

        public List<CartProduct> CartProducts { get; set; }
        public Cart()
        {
            CartProducts = new List<CartProduct>(); 
        }
    }
}
