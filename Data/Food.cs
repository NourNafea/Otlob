using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Otlob.Data
{
    public class Food
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int Price { get; set; }
        public string Currency { get; set; }
        public int Quantity { get; set; }

        public int RestaurantId { get; set; }

        public Restaurant restaurant { get; set; }
    }
}
