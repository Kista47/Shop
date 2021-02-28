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

        public BasketViewModel(ICollection<Toy> toys)
        {
            this.toys = toys;
            Price = GetPrice();
        }
        public int GetPrice()
        {
            int price = 0;
            if (toys.Count != 0)
            {
                foreach (Toy toy in toys)
                {
                    price += toy.Price;
                }
            }
            return price;
        }

    }
}
