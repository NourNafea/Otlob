using Otlob.Data;
using Otlob.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication5.Data
{
    public class OrderDetails
    {
        public int Id { get; set; }

        public int OrderId { get; set; }
        public Order order { get; set; }

        public int FoodId { get; set; }
        public Food food { get; set; }
        

    }
}
