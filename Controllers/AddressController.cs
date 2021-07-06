using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Otlob.Data;
using WebApplication5.Data;

namespace Otlob.Controllers
{
    public class AddressController : Controller
    {
        ApplicationDbContext Db;
        public AddressController (ApplicationDbContext _db)
        {
            Db = _db;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
