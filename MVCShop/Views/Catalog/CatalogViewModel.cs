using MVCShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCShop.Views.Catalog
{
    public class CatalogViewModel
    {
        public IReadOnlyCollection<Toy> Toys { get; }
        public int PagesCount { get; }

        public CatalogViewModel(IReadOnlyCollection<Toy> toys, int pagesCount)
        {
            Toys = toys;
            PagesCount = pagesCount;
        }
    }
}
