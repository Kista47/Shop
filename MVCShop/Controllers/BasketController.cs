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
        public IActionResult Index()
        {
            return View(_basketService.GetOrder());
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


    }
}
