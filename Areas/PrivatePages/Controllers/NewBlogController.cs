using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToyShop.Models;

namespace ToyShop.Areas.PrivatePages.Controllers
{
    public class NewBlogController : Controller
    {
        ToyShopDBContext data = new ToyShopDBContext();
        // GET: PrivatePages/NewBlog
        public ActionResult Index()
        {
            return View();
        }
    }
}