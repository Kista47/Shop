﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCShop.DataBaseEntity.Models
{
    public class DbToy
    {
        public int Id { get; set; }
        public int Price { get; set; }
        public string Name { get; set; }
        public string Info { get; set; }
    }
}
