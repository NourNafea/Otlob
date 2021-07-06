using System;
using System.Collections.Generic;
using System.Linq;  
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Otlob.Data;
using Otlob.Models;
using WebApplication5.Data;
using WebApplication5.Models;

namespace Otlob.Controllers
{
    public class FoodController : Controller
    {
        ApplicationDbContext Db;
        public FoodController(ApplicationDbContext _db)
        {
            Db = _db;
        }


        public IActionResult Menu (int id)
        {
            MenuViewModel menue = new MenuViewModel();
            var Data = Db.Foods.Where(c => c.RestaurantId == id).ToList(); // filter by Id
            menue.foods = new List<Food>();
            foreach (var item in Data)
            {
                menue.foods.Add(new Food()
                {
                    Id=item.Id,
                    Description=item.Description,
                    Image=item.Image,
                    Name=item.Name,
                    Price=item.Price,
                    Currency=item.Currency,
                    RestaurantId=item.RestaurantId
                });
            }
            var res = Db.Restaurants.FirstOrDefault(c => c.Id == id);
            menue.Restaurant = res;
             return View(menue);
        }


        public IActionResult FoodFilter(int id)
        {
            MenuViewModel menue = new MenuViewModel();
            var Data = Db.Foods.Include(s=>s.restaurant).Where(c => c.Id == id).ToList(); // filter by Id
            menue.foods = Data;
            menue.Restaurant = Data.FirstOrDefault().restaurant;
            return View("~/Views/Food/Menu.cshtml",menue);
        }


        public IActionResult searchResauot(string SearchString="")
        {
            var list = new List<ProductViewModel>();
            var Data = Db.Foods.ToList();
            var foods = Db.Foods.Select(s => new ProductViewModel
            {
                Description = s.Description,
                Id = s.Id,
                Image = s.Image,
                Name = s.Name
            }).Where(s => s.Name.ToLower().Contains(SearchString.ToLower())).ToList();
            if (foods != null)
            {
                list.AddRange(foods);
            }
            return Json(new { Data = list });
        }


        public IActionResult searchRes(string SearchString)
        {
            var food = Db.Foods.FirstOrDefault(x => x.Name == SearchString);
            return RedirectToAction("FoodFilter", "Food", new { id = food.Id });
        }

        [Authorize]
        public IActionResult AddToCart(int Id, int Quantity)
        {
            var Isfound = Db.Carts.FirstOrDefault(c => c.FoodId == Id && c.ApplicationUserId == HttpContext.User.Claims.FirstOrDefault().Value);

            if (Isfound != null)
            {
                Isfound.Quantity += Quantity;
                Db.SaveChanges();
            }
            else
            {
                  Cart cart = new Cart();
                  cart.Quantity = Quantity;
                  cart.FoodId = Id;
                  cart.ApplicationUserId = HttpContext.User.Claims.FirstOrDefault().Value;
                  Db.Carts.Add(cart);
                  Db.SaveChanges();
            }
          

            return Json(true);
        }
    }


}
