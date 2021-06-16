using System.Collections.Generic;
using TestTaskForPryaniky.Models;

namespace TestTaskForPryaniky
{
    public class StaticDB
    {
        public static readonly List<Product> Products = new List<Product>
        {
            new Product{Id=1,Name="Milk"},
            new Product{Id=2,Name="Water"},
            new Product{Id=3,Name="Bread"},
            new Product{Id=4,Name="Сheese"},
            new Product{Id=5,Name="Egg"},
            new Product{Id=6,Name="Meat"},
            new Product{Id=7,Name="Butter"},
        };

        public static List<CartProduct> CartProducts = new List<CartProduct>();

        public static List<Cart> Carts = new List<Cart>();

        public static List<User> Users = new List<User>
        {
           new User{Id=1,Name="Alex",CartId=1}
        }; 
    }
}
