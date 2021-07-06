using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication5.Data;

namespace Otlob.Data
{
    public class Cart
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int FoodId { get; set; }
        public Food Food { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}
