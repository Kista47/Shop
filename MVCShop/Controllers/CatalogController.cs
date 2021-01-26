using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCShop.Models;
using MVCShop.Services;

namespace MVCShop.Controllers
{
    public class CatalogController : Controller
    {
        private readonly CatalogeService _catalogeService;

        public CatalogController(CatalogeService catalogeService)
        {
            _catalogeService = catalogeService;
        }

        public async Task<IActionResult> Index()
        {
            return  View(await _catalogeService.GetCatalogeViewModel().ConfigureAwait(false));
        }

        [HttpGet]
        public IActionResult Buy()
        {
            return RedirectToRoute(new { controller = "Catalog", action = "Index" });
        }

        [HttpPost]
        public async Task<IActionResult> Buy(int id)
        {
            _catalogeService.Buy(id);
            return RedirectToRoute(new {controller = "Catalog", action = "Index" });
        }
    }
}
