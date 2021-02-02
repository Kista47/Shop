using Microsoft.AspNetCore.Http;
using MVCShop.Models;
using MVCShop.Repositories;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCShop.Services
{
    public class BasketService
    {
        private BasketOrder _order;
        private readonly ToyRepository _toyRepository;
        public void RemoveToy(Toy toy)
        {
            _order.RemoveToy(toy);
        }
        public BasketService(ToyRepository toyRepository)
        {
            _order = new BasketOrder();
            _toyRepository = toyRepository;
        }
        public int Price()
        {
           return _order.GetPrice();
        }

        public BasketOrder GetOrder()
        {
            return _order;
        }
        public async Task<ICollection<Toy>> GetToys(HttpContext context)
        {
            var toysIds = JsonConvert.DeserializeObject<ICollection<int>>(context.Request.Cookies[CatalogeService.BASKET_COOK]);
            List<Toy> toys = new List<Toy>();
            foreach(int toyId in toysIds)
            {
                Toy toy = await _toyRepository.GetToy(toyId);
                toys.Add(toy);
            }
            return toys;
        }
        public void Delete(HttpContext context,int id)
        {
            
        }

    }
}
