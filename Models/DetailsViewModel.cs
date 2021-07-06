using Otlob.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebApplication5.Data;

namespace WebApplication5.Models
{
    public class DetailsViewModel
    {
        public TotalViewModel TotalViewModel { get; set; }
        //public BillingAddress BillingAddress { get; set; }

        [Required]
        public string NameOnCard { get; set; }
        [Required]

        public string CreditCardNumber { get; set; }
        [Required]

        public string ExpMonth { get; set; }

        [Required]
        public string CVV { get; set; }
        [Required]

        public string ExpYear { get; set; }
        [Required]

        public string FullName { get; set; }
        [Required]

        public string Email { get; set; }
        [Required]

        public string Address { get; set; }
        [Required]

        public string City { get; set; }
        [Required]

        public string ZIP { get; set; }
        [Required]

        public string State { get; set; }
        [Required]


        public string ApplicationUserId { get; set; }

        public ApplicationUser User { get; set; }
    }
}
