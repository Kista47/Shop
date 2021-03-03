using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCShop.Filters
{
    public class SearchFilter
    {
        public string keyWords   { get; set; }
        public int    pageNumber { get; set; }
        public SearchFilter() 
        {}
    }
}
