using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestTaskForPryaniky.Models
{
    public class CartProduct
    {
        public int Id { get; set; }
        public int CartId { get; set; } 
        public int ProductId { get; set; } 
    }
}
