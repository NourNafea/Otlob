using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication5.Data;

namespace Otlob.Data
{
    public class Address
    {
        public int Id { get; set; }
        public int Name { get; set; }
      
        public string ApplicationUserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}
