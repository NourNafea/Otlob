using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Otlob.Data;
using WebApplication5.Data;

namespace Otlob.Controllers
{
    public class OrderController : Controller
    {
        ApplicationDbContext Db;
        public OrderController(ApplicationDbContext _db)
        {
            Db = _db;
        }
        [Microsoft.AspNetCore.Authorization.Authorize]
        public IActionResult OrderData()
        {
            var ID = HttpContext.User.Claims.FirstOrDefault().Value;
            List<Order> orders = new List<Order>();
            orders = Db.Orders.Include(i => i.BillingAddress).Where(x => x.ApplicationUserId == ID).OrderByDescending(c=>c.DateTime).ToList();

            return View(orders);
        }
        public IActionResult OrderDetails(int Id)
        {
            var Details = Db.orderDetails.Include(c=>c.food).Where(c => c.OrderId == Id).ToList(); /*to filter by Id and application user id*/
            return View(Details);
        }

    }
}
