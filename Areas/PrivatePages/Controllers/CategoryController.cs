using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToyShop.Models;

namespace ToyShop.Areas.PrivatePages.Controllers
{
    public class CategoryController : Controller
    {
        ToyShopDBContext data = new ToyShopDBContext();
        // GET: PrivatePages/Category
        public ActionResult Index()
        {
            return View(data.Categories.ToList());
        }
    }
}