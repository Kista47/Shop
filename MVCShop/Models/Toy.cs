using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCShop.Models
{
    public class Toy
    {
        public int Id { get; }
        
        [Required(ErrorMessage ="Ввведите цену")]
        public int Price { get; private set; }

        [Required(ErrorMessage = "Ввведите Название игрушки")]
        public string Name { get; private set; }
        [Required(ErrorMessage = "Ввведите Описание игрушки")]
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

        public Toy()
        {
        }
    }
}
