using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCShop.Models;
using MVCShop.Services;

namespace MVCShop.Controllers
{
    public class AdminController : Controller
    {
        private readonly AdminService _admin;

        public AdminController(AdminService admin)
        {
            _admin = admin;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddToy(string name, string info, int price)
        {
            await _admin.CreateToy(new Toy(name, info, price)).ConfigureAwait(false);
            return RedirectToRoute(new { controller = "Catalog", action = "Index" });
        }

        [HttpGet]
        public async Task<IActionResult> UpdateToy(int id)
        {
            var toy = await _admin.GetToy(id).ConfigureAwait(false);
            if (toy != null) return View(toy);
            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> GetToysList()
        {
            return View("Update",await _admin.GetToysList().ConfigureAwait(false));
        }

        [HttpPost]
        public async Task<IActionResult> UpdateToy(int id, string name, string info, int price)
        {
            await _admin.UpdateToy(new Toy(id, name, info, price)).ConfigureAwait(false);
            return RedirectToRoute(new { controller = "Catalog", action = "Index" });
        }

        public async Task<IActionResult> DeleteToy(int id)
        {
            await _admin.DeleteToy(id).ConfigureAwait(false);
            return RedirectToRoute(new { controller = "Admin", action = "GetToysList" });
        }
    }
}
