using Otlob.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Otlob.Models
{
    public class MenuViewModel
    {
        public List<Food> foods {get; set;}
        public Restaurant Restaurant { get; set;}
    }
}
