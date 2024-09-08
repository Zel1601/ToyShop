using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToyShop.Models;
using PagedList;
using PagedList.Mvc;
using System.Web.UI;

namespace ToyShop.Areas.PrivatePages.Controllers
{
    public class ShopProductController : Controller
    {
        ToyShopDBContext data = new ToyShopDBContext();
        // GET: PrivatePages/ShopProduct
        [HttpGet]
        public ActionResult Index(int ?page)
        {
            int pageSize = 6;
            int pageNum = (page ?? 1);

            return View(data.Products.ToList().OrderBy(n => n.ProId).ToPagedList(pageNum, pageSize));
        }
        public ActionResult DetailsProduct(int id)
        {
            Product product = data.Products.SingleOrDefault(n => n.ProId == id);
            ViewBag.ProId= product.ProId;
            if(product == null)
            {
                Response.StatusCode = 404;
                return null;
            }    
            return View(product);
        }
        public ActionResult DeleteProduct(int id)
        {
            Product product = data.Products.SingleOrDefault(n => n.ProId == id);
            ViewBag.ProId = product.ProId;
            if (product == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(product);
        }
        public ActionResult RepairProduct(int id)
        {
            Product product = data.Products.SingleOrDefault(n => n.ProId == id);
            ViewBag.ProId = product.ProId;
            if (product == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(product);
            
        }
    }
   
}