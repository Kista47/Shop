using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCControllers.Models;
using MVCControllers.Services;

namespace MVCControllers.Controllers
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
        
    }
}
