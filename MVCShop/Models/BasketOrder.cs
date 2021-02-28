using MVCShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCShop.Models
{
    public class BasketOrder
    {
        private ICollection<Toy> toys { get;}

        public BasketOrder()
        {
            toys = new LinkedList<Toy>();
        }

        public void AddToy(Toy toy)
        {
            toys.Add(toy);
        }

        public void RemoveToy(Toy toy)
        {
            toys.Remove(toy);
        }

        public ICollection<Toy> GetToys()
        {
            return toys;
        }
    }
}
