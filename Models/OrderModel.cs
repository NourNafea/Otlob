using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication5.Data;

namespace WebApplication5.Models
{
    public class OrderModel
    {
        public DateTime DateTime { get; set; }
        public string ApplicationUserId { get; set; }
        public int BillingAddressId { get; set; }
        public BillingAddress BillingAddress { get; set; }
        public OrderDetails orderDetails { get; set; }
    }
}
