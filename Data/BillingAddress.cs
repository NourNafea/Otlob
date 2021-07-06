using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication5.Data
{
    public class BillingAddress
    {
        public int Id { get; set; }
       
        public string NameOnCard { get; set; }
        public string CreditCardNumber { get; set; }
        public string ExpMonth { get; set; }

        public string CVV { get; set; }
        public string ExpYear { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string ZIP { get; set; }
        public string State { get; set; }
       
        public string ApplicationUserId { get; set; }
        
        public ApplicationUser User { get; set; }

    }
}
