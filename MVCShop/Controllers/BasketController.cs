using Microsoft.AspNetCore.Mvc;
using MVCShop.Models;
using MVCShop.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCShop.Controllers
{
    public class BasketController : Controller
    {
        private BasketService _basketService;

        public BasketController(BasketService basketService)
        {
            _basketService = basketService;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _basketService.GetBasketViewModel(HttpContext));
        }
        //[HttpGet]
        //public int Price()
        //{
        //    return _basketService.Price();
        //}
        [HttpPost]
        public void RemoveToy(Toy toy)
        {
            _basketService.RemoveToy(toy);
        }
        [HttpPost]
        public void DeleteAll()
        {
            _basketService.DeleteAll(this.HttpContext);
        }
        public void Delete(int id)
        {
            _basketService.Delete(this.HttpContext, id);
        }
        //ublic async Task<ICollection<Toy>> GetToys()
        //{p
        //    return await _basketService.GetToys(HttpContext);
        //}
        //public async Task<BaskView>
    }
}
