using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication5.Data;

namespace Otlob.Data
{
    public class Order
    {
        public int Id { get; set; }

        public int BillingAddressId { get; set; }
        public BillingAddress BillingAddress { get; set; }


        public string ApplicationUserId { get; set; }
        public ApplicationUser User { get; set; }


        public List<OrderDetails> orderDetails { get; set; }

        public int FinalTotal { get; set; }
        public DateTime DateTime { get; set; }
    }
}
