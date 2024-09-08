using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToyShop.Models;

namespace ToyShop.Areas.PrivatePages.Controllers
{
    public class NewProductController : Controller
    {
        ToyShopDBContext data = new ToyShopDBContext();
        // GET: PrivatePages/NewProduct
        [HttpGet]
        [ValidateInput(false)]
        public ActionResult Index()
        {
            ViewBag.CatId = new SelectList(data.Categories.ToList().OrderBy(n => n.CatName), "Id", "CatName");
            return View();
        }

        [HttpPost]
        public ActionResult Index(Product product, HttpPostedFileBase image)
        {
            ViewBag.Id = new SelectList(data.Categories.ToList().OrderBy(n => n.CatName), "Id", "CatName");
            
            if(image == null)
            {
                ViewBag.ThongBao = "Vui Lòng Nhập Ảnh Bìa";
                return View();
            }
            else
            {
                if (ModelState.IsValid)
                {
                    var fileName = Path.GetFileName(image.FileName);
                    var link = Path.Combine(Server.MapPath("~/Images"), fileName);
                    if (System.IO.File.Exists(link))
                    {
                        ViewBag.ThongBao = "Hình Ảnh Đã Tồn tại";
                    }
                    else
                    {
                        image.SaveAs(link);
                    }
                    product.ProImage = fileName;
                    data.Products.Add(product);
                    data.SaveChanges();
                }
                return RedirectToAction("Index","ShopProduct");
            }
            
        }

    }
}