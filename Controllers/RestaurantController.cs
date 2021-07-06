using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication5.Data;
using WebApplication5.Models;

namespace Otlob.Controllers
{
    public class RestaurantController : Controller
    {
        ApplicationDbContext Db;
        public RestaurantController (ApplicationDbContext _db)
        {
            Db = _db;
        }

        public IActionResult RN()
        {
            var Names = Db.Restaurants.ToList();
            return View(Names);
        }

        public JsonResult GetSearchValue(string SearchString)
        {
            //if (!string.IsNullOrWhiteSpace(SearchString))
            //{
            //}
            var list = new List<ProductViewModel>();
            var Data = Db.Restaurants.ToList();
            var restaurants = Db.Restaurants.Select(x => new ProductViewModel
            {
                Description = x.Description,
                Id = x.Id,
                Image = x.Image,
                Name = x.Name 
            }).Where(x => x.Name.ToLower().Contains(SearchString.ToLower())).ToList();
            

            if (restaurants != null)
            {
                list.AddRange(restaurants);

            }
            
            return Json(new { Data = list });
        }

        public IActionResult Search(string SearchString)
        {
           
            var res = Db.Restaurants.FirstOrDefault(x => x.Name == SearchString);
            return RedirectToAction("menu","Food",new { id=res.Id});
        }
      
    }
}