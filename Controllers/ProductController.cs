using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToyShop.Models;
using PagedList;
using PagedList.Mvc;


namespace ToyShop.Controllers
{
    public class ProductController : Controller
    {
        ToyShopDBContext data = new ToyShopDBContext();
        List<Product> laytoanbo(int count)
        {
            return data.Products.OrderByDescending(a => a.ProId).Take(count).ToList();
        }
        List<Product> laygiamgia(int count)
        {

            return data.Products.OrderByDescending(a => a.Discount > 0).Take(count).ToList();
        }
        // GET: Product
        public ActionResult Index(int? Page)
        {
            int pageSize = 6;
            int pageNum = (Page ?? 1);


            var sanpham = laytoanbo(24);
            return View(sanpham.ToPagedList(pageNum, pageSize));
        }


    }
}
