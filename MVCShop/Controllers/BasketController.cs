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
        
        [HttpPost]
        public void RemoveToy(Toy toy)
        {
            _basketService.RemoveToy(toy);
        }
        
        public async Task<ActionResult> DeleteAll()
        {
            _basketService.DeleteAll(this.HttpContext);
            return RedirectToRoute(new { controller = "Basket", action = "Index" });
        }
        public async Task<ActionResult> DeleteToy(int id)
        {
            _basketService.Delete(this.HttpContext, id);
            return RedirectToRoute(new { controller = "Basket", action = "Index" });
        }
    }
}
