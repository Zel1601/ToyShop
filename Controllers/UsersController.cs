using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToyShop.Models;

namespace ToyShop.Controllers
{
    public class UsersController : Controller
    {
        ToyShopDBContext data = new ToyShopDBContext();
        // GET: Users
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(FormCollection collection, NguoiDung main)
        {
            var name = collection["Hoten"];
            var username = collection["UserAccount"];
            var mail = collection["Email"];
            var pass = collection["Password"];
            var diachi = collection["Address"];
            var sdt = collection["Phone"];
            var birthday = String.Format("{0:MM/dd/yyyy}", collection["Ngaysinh"]);
            if(String.IsNullOrEmpty(name))
            {
                ViewData["Loi1"] = "Họ tên người dùng không được để trống";
            }    
            else if(String.IsNullOrEmpty(username))
            {
                ViewData["Loi 2"] = "Phải nhập UserName";
            }
            else if(String.IsNullOrEmpty(mail))
            {
                ViewData["Loi3"] = "Phải nhập Email";
            }    
            else if (String.IsNullOrEmpty(pass)){
                ViewData["Loi4"] = "Phải nhập Password";
            }
            else if (String.IsNullOrEmpty(diachi))
            {
                ViewData["Loi5"] = " Vui Lòng Nhập Địa Chỉ";
            }
            else if (String.IsNullOrEmpty(sdt))
            {
                ViewData["Loi6"] = " Vui Lòng Nhập Số Điện Thoại";
            }
            else
            {
                main.name= name;
                main.username= username;
                main.email= mail;
                main.pass= pass;
                main.address= diachi;
                main.phone = sdt;
                main.birthday =DateTime.Parse(birthday);
                data.NguoiDungs.Add(main);
                data.SaveChanges();
                return RedirectToAction("Login");
            }
            return this.Register();
        }
        public ActionResult Login(FormCollection collection)
        {
            var name = collection["UserAccount"];
            var pass = collection["Password"];
            if (String.IsNullOrEmpty(name))
            {
                ViewData["Loi1"] = "Phải Nhập Tên Đăng Nhập";
            }
            else if (String.IsNullOrEmpty(pass))
            {
                ViewData["Loi2"] = "Phải nhập mật khẩu";
            }
            else
            {
                NguoiDung main = data.NguoiDungs.SingleOrDefault(n => n.username == name && n.pass == pass);
                if (main != null)
                {
                    Session["TaiKhoan"] = main;
                    return RedirectToAction("Index", "Home");
                }
                else
                    ViewBag.Thongbao = "Tên đăng nhập hoặc mật khẩu của bạn không đúng!";
            }
            return View();
          
        }
        
        }
    }
