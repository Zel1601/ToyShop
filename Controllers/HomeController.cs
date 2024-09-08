using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToyShop.Models;

namespace ToyShop.Controllers
{
    public class HomeController : Controller
    {
        ToyShopDBContext data = new ToyShopDBContext();



        // GET: Home 
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Category()
        {
            var cat = from cate in data.Categories select cate;
            return PartialView(cat);
        }
        public ActionResult SPTheoCategory(int id)
        {
            var dochoine = from d in data.Products where d.CatId == id select d;
            return View(dochoine);
        }

    }
}