using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Otlob.Models
{
    public class CartViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Currency { get; set; }
        public int Quantity { get; set; }
        public int Total { get; set; }
    }
}
