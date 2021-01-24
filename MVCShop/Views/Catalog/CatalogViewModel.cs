using MVCControllers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCControllers.Views.Catalog
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
