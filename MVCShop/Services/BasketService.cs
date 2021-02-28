using Microsoft.AspNetCore.Http;
using MVCShop.Models;
using MVCShop.Repositories;
using MVCShop.Views.Basket;
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
   
        public BasketOrder GetOrder()
        {
            return _order;
        }
        public async Task<ICollection<Toy>> GetToys(HttpContext context)
        {
            List<Toy> toys = new List<Toy>();
            if (context.Request.Cookies.ContainsKey(CatalogeService.BASKET_COOK))
            {
                var toysIds = JsonConvert.DeserializeObject<ICollection<int>>(context.Request.Cookies[CatalogeService.BASKET_COOK]);

                foreach (int toyId in toysIds)
                {
                    Toy toy = await _toyRepository.GetToy(toyId);
                    toys.Add(toy);
                }
            }
            return toys;
        }
        public void Delete(HttpContext context, int id)
        {
            var toys = JsonConvert.DeserializeObject<ICollection<int>>(context.Request.Cookies[CatalogeService.BASKET_COOK]);
            toys.Remove(id);
            context.Response.Cookies.Delete(CatalogeService.BASKET_COOK);
            context.Response.Cookies.Append(CatalogeService.BASKET_COOK, JsonConvert.SerializeObject(toys));
        }
        public async Task<BasketViewModel> GetBasketViewModel(HttpContext context)
        {
            var toys = await GetToys(context);
            return new BasketViewModel(toys.ToArray());
        }
        public void DeleteAll(HttpContext context)
        {
            context.Response.Cookies.Delete(CatalogeService.BASKET_COOK);
        }
    }
}
