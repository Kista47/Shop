
using Microsoft.AspNetCore.Http;
using MVCShop.Filters;
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
        public const int MAXTOYSPAGE = 6;
        public const string BASKET_COOK = "BasketCook";
        public const string COUNT_BUYS = "CountBuys";
        public const string CURRENT_PAGE = "CurrentPage";
        public static int CurrentPage = 0;

        public CatalogeService(ToyRepository toyRepository, BasketService Bservice)
        {
            _toyRepository = toyRepository;
        }

        public async Task<ICollection<Toy>> GetToysList()
        {
            return await _toyRepository.GetToys().ConfigureAwait(false);
        }

        public int GetPageCount()
        {
            int count = (int)Math.Ceiling((double)_toyRepository.countToys / MAXTOYSPAGE);

            return count;
        }
        //public async Task<CatalogViewModel> GetCatalogeViewModel(SearchFilter searchFilter,int pageIndex)
        //{
        //    var toys = await GetToysList(pageIndex).ConfigureAwait(false);
        //    return new CatalogViewModel(toys.ToArray(), GetPageCount(await _toyRepository.SearchToys(searchFilter)));
        //}
        public async void Buy(HttpContext context, int id)
        {

            if (context.Request.Cookies.ContainsKey(BASKET_COOK))
            {
                var toys = JsonConvert.DeserializeObject<ICollection<int>>(context.Request.Cookies[BASKET_COOK]);
                toys.Add(id);
                context.Response.Cookies.Append(BASKET_COOK, JsonConvert.SerializeObject(toys));
            }
            else
            {
                context.Response.Cookies.Append(BASKET_COOK, JsonConvert.SerializeObject(new[] { id }));
            }
            if (context.Request.Cookies.ContainsKey(COUNT_BUYS))
            {
                int count = Int32.Parse(context.Request.Cookies[COUNT_BUYS]);
                context.Response.Cookies.Append(COUNT_BUYS,(count + 1).ToString());
            }
            else
            {
                context.Response.Cookies.Append(COUNT_BUYS, "1");
            }

        }
        public async Task<Toy> GetToy(int id)
        {
            return await _toyRepository.GetToy(id).ConfigureAwait(false);
        }

        public async Task<CatalogViewModel> GetSearchCatalogeViewModel(SearchFilter searchFilter, int pageIndex, HttpContext context)
        {
            var toys = await _toyRepository.SearchToys(searchFilter, pageIndex).ConfigureAwait(false);
            //if (context.Request.Cookies.ContainsKey(CURRENT_PAGE))
            //{
            //    context.Response.Cookies.Delete(CURRENT_PAGE);
            //    context.Response.Cookies.Append(CURRENT_PAGE, pageIndex.ToString());
            //} else
            //{
            //    context.Response.Cookies.Append(CURRENT_PAGE, pageIndex.ToString());
            //}
            CurrentPage = pageIndex;

            return new CatalogViewModel(toys.ToArray(), GetPageCount());
        }

        public static int GetCurrentPage()
        {
            //if (context.Request.Cookies.ContainsKey(CURRENT_PAGE))
            //{
            //    return Int32.Parse(context.Request.Cookies[CURRENT_PAGE]);
            //}

            //context.Response.Cookies.Append(CURRENT_PAGE, "0");

            return 0;
        }
    }
}
