using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Otlob.Data
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }

        public List<Food> Foods { get; set; } 
    }
}
