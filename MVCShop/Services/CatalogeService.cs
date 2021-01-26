using MVCShop.Models;
using MVCShop.Repositories;
using MVCShop.Views.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCShop.Services
{
    public class CatalogeService
    {
        private readonly ToyRepository _toyRepository;
        private const int MaxPages = 9;

        public CatalogeService(ToyRepository toyRepository)
        {
            _toyRepository = toyRepository;
        }

        public async Task<ICollection<Toy>> GetToysList()
        {
           return await _toyRepository.GetToys().ConfigureAwait(false);
        }

        public int GetPageCount(ICollection<Toy> toys)
        {
            int count = (int)Math.Ceiling((decimal)toys.Count / MaxPages);

            return count;
        }
        public async Task<CatalogViewModel> GetCatalogeViewModel()
        {
            var toys = await GetToysList().ConfigureAwait(false);
            return new CatalogViewModel(toys.ToArray(), GetPageCount(toys));
        }
        public async void Buy(int id)
        {
            Toy toy = await GetToy(id).ConfigureAwait(false);
            BasketOrder.Initialize().AddToy(toy);
        }
       public async Task<Toy> GetToy(int id)
        {
            return await _toyRepository.GetToy(id).ConfigureAwait(false);
        }

    }
}
