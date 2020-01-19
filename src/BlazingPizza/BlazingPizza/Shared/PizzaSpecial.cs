﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BlazingPizza.Shared
{
    public class PizzaSpecial
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal BasePrice { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string FormattedBasePrice =>
            BasePrice.ToString("0.00");
    }
}