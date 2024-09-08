using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToyShop.Models;

namespace ToyShop.Controllers
{
    public class AdminLoginController : Controller
    {
        ToyShopDBContext data = new ToyShopDBContext();
        // GET: AdminLogin
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login() 
        {
            return View(); 
        }
        [HttpPost]
        public ActionResult Login(FormCollection collection)
        {
            var adminuser = collection["username"];
            var adminpassword = collection["password"];
            if (String.IsNullOrEmpty(adminuser))
            {
                ViewData["Lỗi1 "] = "Phải nhập AdminUser";
            }
            else if (String.IsNullOrEmpty(adminpassword))
            {
                ViewData["Lỗi2 "] = "Phải Nhập Password";
            }
            else
            {
                Adminstrator admin = data.Adminstrators.SingleOrDefault(n => n.username== adminuser && n.pass == adminpassword);
                if (admin == null)
                {
                    Session["TaiKhoanadmin"] = admin;
                    return RedirectToAction("Index", "DashBoard", new { Area = "PrivatePages" });
                }
            }
                return View();
        }

       
            
    }
}