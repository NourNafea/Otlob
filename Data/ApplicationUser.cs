using Microsoft.AspNetCore.Identity;
using Otlob.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication5.Data
{
    public class ApplicationUser : IdentityUser
    {
        public List<Address> addresses { get; set; }
        public List<Cart> carts { get; set; }
        public List<BillingAddress> billingAddresses{ get; set; }

    }
}
