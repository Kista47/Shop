
using Microsoft.AspNetCore.Http;
using MVCShop.Models;
using MVCShop.Repositories;
using MVCShop.Views.Catalog;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCShop.Services
{
    public class CatalogeService
    {
        private readonly ToyRepository _toyRepository;
        private BasketService _Bservice;
        private const int MAXTOYSPAGE = 12;
        public const string BASKET_COOK = "BasketCook";

        public CatalogeService(ToyRepository toyRepository, BasketService Bservice)
        {
            _toyRepository = toyRepository;
            _Bservice = Bservice;
        }

        public async Task<ICollection<Toy>> GetToysList()
        {
            return await _toyRepository.GetToys().ConfigureAwait(false);
        }

        public int GetPageCount(ICollection<Toy> toys)
        {
            int count = (int)Math.Ceiling((decimal)toys.Count / MAXTOYSPAGE);

            return count;
        }
        public async Task<CatalogViewModel> GetCatalogeViewModel()
        {
            var toys = await GetToysList().ConfigureAwait(false);
            return new CatalogViewModel(toys.ToArray(), GetPageCount(toys));
        }
        public async void Buy(HttpContext context, int id)
        {

            if (context.Request.Cookies.ContainsKey(BASKET_COOK))
            {
                var toys = JsonConvert.DeserializeObject<ICollection<int>>(context.Request.Cookies[BASKET_COOK]);
                toys.Add(id);
                context.Response.Cookies.Delete(BASKET_COOK);
                context.Response.Cookies.Append(BASKET_COOK, JsonConvert.SerializeObject(toys));
            }
            else
            {
                context.Response.Cookies.Append(BASKET_COOK, JsonConvert.SerializeObject(new[] { id }));
            }
        }
        public async Task<Toy> GetToy(int id)
        {
            return await _toyRepository.GetToy(id).ConfigureAwait(false);
        }

        public async Task<List<Toy>> GetPageToys(int pageNumber)
        {
            var allToys = await GetToysList().ConfigureAwait(false);
            List<Toy> toys = new List<Toy>();

            for (int i = pageNumber * 12; i < GetCount(pageNumber, allToys); i++)
            {
                toys.AddRange(allToys.ToList<Toy>().GetRange(i, GetCount(pageNumber, allToys)));
            }
            return toys;
        }

        public int GetCount(int pageNumber, ICollection<Toy> allToys)
        {
            int count = allToys.Count - pageNumber * MAXTOYSPAGE;
            return  MAXTOYSPAGE >= count ? count : MAXTOYSPAGE;
        }

    }
}
