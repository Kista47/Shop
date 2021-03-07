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
            return  View(await _catalogeService.GetSearchCatalogeViewModel(searchFilter,id,this.HttpContext).ConfigureAwait(false));
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

        [HttpPost]
        public async Task Buy(string id)
        {
            _catalogeService.Buy(this.HttpContext,Int32.Parse(id));
            //return RedirectToRoute(new {controller = "Catalog", action = "Index" });
        }
    }
}
