using MVCShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCShop.Views.Basket
{
    public class BasketViewModel
    {
        public ICollection<Toy> toys { get; set; }
        public int Price { get; set; }

        public BasketViewModel(ICollection<Toy> toys, int price)
        {
            this.toys = toys;
            Price = price;
        }
    }
}
