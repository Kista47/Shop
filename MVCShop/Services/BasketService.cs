using MVCShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCShop.Services
{
    public class BasketService
    {
        private BasketOrder _order;

        public void RemoveToy(Toy toy)
        {
            _order.RemoveToy(toy);
        }
        public BasketService()
        {
            _order = BasketOrder.Initialize();
        }

        public int Price()
        {
           return _order.GetPrice();
        }

        public BasketOrder GetOrder()
        {
            return _order;
        }
    }
}
