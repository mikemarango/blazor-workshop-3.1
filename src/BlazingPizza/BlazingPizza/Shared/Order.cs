using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlazingPizza.Shared
{
    public class Order
    {
        public int OrderId { get; set; }
        public string UserId { get; set; }
        public DateTime CreatedTime { get; set; }
        public Address DeliveryAddress { get; set; } = new Address();
        public LatLong DeliveryLocation { get; set; } = new LatLong();
        public List<Pizza> Pizzas { get; set; } = new List<Pizza>();
        public decimal TotalPrice =>
            Pizzas.Sum(p => p.TotalPrice);
        public string FormattedTotalPrice =>
            TotalPrice.ToString("0.00");
    }
}
