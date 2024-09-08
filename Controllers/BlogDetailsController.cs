using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToyShop.Models;

namespace ToyShop.Controllers
{
    public class BlogDetailsController : Controller
    {
        // GET: BlogDetails
        public ActionResult Index(int mabaiviet)
        {
            ToyShopDBContext data = new ToyShopDBContext();
            Blog x = data.Blogs.Where(sp => sp.BlogId.Equals(mabaiviet)).First<Blog>();
            ViewData["BaiVietCanXem"] = x;
            return View();
            
        }
    }
}