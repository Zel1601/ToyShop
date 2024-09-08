using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToyShop.Models;

namespace ToyShop.Controllers
{
    public class ProductDetailsController : Controller
    {
        // GET: ProductDetails
        public ActionResult Index(int masanpham)
        {
            ToyShopDBContext data = new ToyShopDBContext();
            Product x = data.Products.Where(sp => sp.ProId.Equals(masanpham)).First<Product>();
            ViewData["SPCanXem"] = x;
            return View();
        }
    }
   }
