using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCShop.Filters;
using MVCShop.Models;
using MVCShop.Services;
using Newtonsoft.Json;

namespace MVCShop.Controllers
{
    public class CatalogController : Controller
    {
        private readonly CatalogeService _catalogeService;

        public CatalogController(CatalogeService catalogeService)
        {
            _catalogeService = catalogeService;
        }

        public async Task<IActionResult> Index(SearchFilter searchFilter, int id)
        {
            return  View(await _catalogeService.GetSearchCatalogeViewModel(searchFilter,id).ConfigureAwait(false));
        }
        //public async Task<IActionResult> Index(IActionResult action)
        //{
        //    return View(action);
        //}

        //public async Task<IActionResult> Page(int id)
        //{
        //    return View(await _catalogeService.GetCatalogeViewModel(id).ConfigureAwait(false));
        //}
        public async Task<IActionResult> ToyPage(int id)
        {
            var toy = await _catalogeService.GetToy(id).ConfigureAwait(false);
            if (toy != null) return View(toy);
            return NotFound();
        }

        //[HttpGet]
        //public IActionResult Buy()
        //{
        //    return RedirectToRoute(new { controller = "Catalog", action = "Index" });
        //}

        [HttpPost]
        public async Task<IActionResult> Buy(int id)
        {
            _catalogeService.Buy(this.HttpContext,id);
            return RedirectToRoute(new {controller = "Catalog", action = "Index" });
        }
        //[HttpPost]
        //public async Task<IActionResult> Search(string keyWords)
        //{
        //    return RedirectToAction("Index","Catalog",await _catalogeService.GetSearchCatalogeViewModel(keyWords, 0));
        //}

    }
}
