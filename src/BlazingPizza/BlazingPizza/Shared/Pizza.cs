﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlazingPizza.Shared
{
    public class Pizza
    {
        public const int DefaultSize = 12;
        public const int MinimumSize = 9;
        public const int MaximumSize = 17;

        public int Id { get; set; }
        public int OrderId { get; set; }
        public PizzaSpecial Special { get; set; }
        public int SpecialId { get; set; }
        public int Size { get; set; }
        public List<PizzaTopping> Toppings { get; set; }
        public decimal BasePrice =>
               ((decimal)Size)/ DefaultSize * Special.BasePrice;
        public decimal TotalPrice =>
            BasePrice + Toppings.Sum(t => t.Topping.Price);
        public string FormattedTotalPrice =>
            TotalPrice.ToString("0.00");
    }
}
