using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Otlob.Data;
using Otlob.Models;
using WebApplication5.Data;
using WebApplication5.Models;

namespace Otlob.Controllers
{
    public class CartController : Controller
    {
        ApplicationDbContext Db;
        public CartController(ApplicationDbContext _db)
        {
            Db = _db;
        }

        [Authorize]
        public IActionResult ShoppingCart()
        {
            DetailsViewModel detailsViewModel = new DetailsViewModel();
            TotalViewModel totalViewModel = new TotalViewModel();
            List<CartViewModel> cart = new List<CartViewModel>();
            var Result = Db.Carts.Include(c => c.Food).Where(c =>c.ApplicationUserId == HttpContext.User.Claims.FirstOrDefault().Value).ToList(); /*to filter by Id and application user id*/

            var FinalTotal = 0;
            foreach (var item in Result)
            {
                var total = item.Food.Price * item.Quantity;
                cart.Add(new CartViewModel
                {
                    Id=item.Id,
                    Price = item.Food.Price,
                    Quantity = item.Quantity,
                    Name = item.Food.Name,
                    Total = total,
                    Currency=item.Food.Currency
                }) ;
                FinalTotal += total;
            }
            totalViewModel.FinalTotal = FinalTotal;
            totalViewModel.cartViewModels = cart;
            detailsViewModel.TotalViewModel = totalViewModel;

            return View(detailsViewModel);
        }
        public IActionResult Delete(int id)
        {
            var Data = Db.Carts.FirstOrDefault(c => c.Id == id);
            Db.Carts.Remove(Data);
            Db.SaveChanges();
            return RedirectToAction("ShoppingCart");
        }

        public IActionResult Proceed()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Proceed (DetailsViewModel detailsViewModel)
        {
            // 
            BillingAddress billingAddress = new BillingAddress();

            // auto mapper
            billingAddress.NameOnCard = detailsViewModel.NameOnCard;
            billingAddress.CreditCardNumber = detailsViewModel.CreditCardNumber;
            billingAddress.ExpMonth = detailsViewModel.ExpMonth;
            billingAddress.ExpYear = detailsViewModel.ExpYear;
            billingAddress.CVV = detailsViewModel.CVV;
            billingAddress.FullName = detailsViewModel.FullName;
            billingAddress.Email = detailsViewModel.Email;
            billingAddress.Address = detailsViewModel.Address;
            billingAddress.City = detailsViewModel.City;
            billingAddress.ZIP = detailsViewModel.ZIP;
            billingAddress.State = detailsViewModel.State;
            billingAddress.ApplicationUserId= HttpContext.User.Claims.FirstOrDefault().Value;

            Db.billingAddresses.Add(billingAddress);
            Db.SaveChanges();

            
            var ID = HttpContext.User.Claims.FirstOrDefault().Value;

            var cardItems = Db.Carts.Include(c => c.Food).Where(c => c.ApplicationUserId == HttpContext.User.Claims.FirstOrDefault().Value).ToList(); /*to filter by Id and application user id*/

            var FinalTotal = 0;
            foreach (var item in cardItems)
            {
                var total = item.Food.Price * item.Quantity;
                FinalTotal += total;
            }
            Order order = new Order();

            order.ApplicationUserId = ID;
            order.BillingAddressId = billingAddress.Id;
            order.DateTime = DateTime.Now;
            order.FinalTotal =FinalTotal;

            var cards = Db.Carts.Where(c => c.ApplicationUserId == ID).ToList();

            Db.Orders.Add(order);
            Db.SaveChanges();


            Db.Carts.RemoveRange(cards);
            Db.SaveChanges();


            List<OrderDetails> orderDetails = new List<OrderDetails>();
            foreach (var item in cardItems)
            {
                orderDetails.Add(new OrderDetails(){
                    OrderId=order.Id,
                    FoodId=item.FoodId
                });
            }
            Db.orderDetails.AddRange(orderDetails);
            Db.SaveChanges();


            return RedirectToAction("OrderData" ,"Order");
        }

    }
}