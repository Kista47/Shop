using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCShop.Models
{
    public class Toy
    {
        public int Id { get; }
        public int Price { get; private set; }
        public string Name { get; private set; }
        public string Info { get; private set; }

        public Toy(int id, string name, string info,int price) : this(name,info,price)
        {
            Id = id;
        }
        public Toy(string name, string info,int price)
        {
            Name = name;
            Info = info;
            Price = price;
        }
    }
}
