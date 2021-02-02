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
            return View(await _basketService.GetToys(this.HttpContext));
        }
        [HttpGet]
        public int Price()
        {
            return _basketService.Price();
        }
        [HttpPost]
        public void RemoveToy(Toy toy)
        {
            _basketService.RemoveToy(toy);
        }
        [HttpPost]
        public void DeleteAll()
        {

        }
        public void Delete(int id)
        {

        }

    }
}
