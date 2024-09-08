using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToyShop.Models;

namespace ToyShop.Controllers
{
    public class ShopingCartController : Controller
    {
        // tao doi tuong chua du lieu lay tu db
        ToyShopDBContext data = new ToyShopDBContext();
        // GET: ShopingCart
        // phuong thuc laygiohang
        public List<Carts> layGioHang()
        {
            List<Carts> i = Session["Carts"] as List<Carts>;
            if(i == null)
            {
                //Neu giỏ hàng chưa có thì khỏi tạo giỏ hàng
                i = new List<Carts>();
                Session["Carts"] = i;
            }
            return i;
        }

        //phuong thuc them vao gio hang
        public ActionResult AddCart(int iproId, string strURL) 
        {
        List<Carts> i = layGioHang();
            Carts sp = i.Find(n => n.iproId== iproId);
            if(sp == null)
            {
                sp = new Carts(iproId);
                i.Add(sp);
                return Redirect(strURL);
            }
            else
            {
                sp.isoLuong++;
                return Redirect(strURL);
            }    
        }
        
        //phuong thuc tinh tong so luong
        private int SumSoLuong()
        {
            int sumsoluong = 0;
            List<Carts> i = Session["Carts"] as List<Carts> ;
            if(i != null)
            {
                sumsoluong = i.Sum(n => n.isoLuong);
            }
            return sumsoluong;
        }

        //phuong thuc tinh tong tien
        private double Sum()
        {
            double s = 0;
            List<Carts> i = Session["Carts"] as List<Carts>;
            if(i != null)
            {
                s = i.Sum(n => n.ithanhtien);
            }
            return s;
        }

        public ActionResult Cart()
        {
            List<Carts> i = layGioHang() ;
            if ( i.Count == 0)
            {
                return RedirectToAction("Index", "Home");
            }
            ViewBag.SumSoLuong = SumSoLuong();
            ViewBag.Sum = Sum();
            return View(i);
        }
        public ActionResult DeleteCart(int iproId)
        {
            List<Carts> i = layGioHang();
            Carts sp = i.SingleOrDefault(n => n.iproId== iproId);

            if(sp != null)
            {
                i.RemoveAll(n => n.iproId== iproId);
                return RedirectToAction("Cart");
            }
            if(i.Count == 0)
            {
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Cart");
        }
        public ActionResult UpdateCart(int iproId, FormCollection f)
        {
            Product product = data.Products.SingleOrDefault(n => n.ProId == iproId);
            if( product == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            List<Carts> i = layGioHang();
            Carts sanpham = i.SingleOrDefault(n =>n.iproId== iproId);
            if( sanpham != null)
            {
                sanpham.isoLuong = int.Parse(f["txtSoluong"].ToString());
            }
            return RedirectToAction("Carts");
        }
        public ActionResult RepairCarts()
        {
            if (Session["Carts"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            List<Carts> i = layGioHang();
            return View(i);
        }
        public ActionResult DeleteAllCart()
        {
            List<Carts> i = layGioHang();
            i.Clear();
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public ActionResult CheckOut()
        {
            if (Session["TaiKhoan"] == null || Session["TaiKhoan"].ToString() =="")
            {
                return RedirectToAction("Login", "Users");
            }
            if (Session["Carts"] == null)
            {
                return RedirectToAction("Cart", "ShopingCart");
            }

            List<Carts> i = layGioHang();
            ViewBag.SumSoLuong = SumSoLuong();
            ViewBag.Sum = Sum();

            return View(i);
        }
        public ActionResult CheckOut(FormCollection collection)
        {
            Order o = new Order();
            NguoiDung main = (NguoiDung)Session["TaiKhoan"];
            List<Carts> u = layGioHang();
            o.id = main.id;
            o.OrderDate = DateTime.Now;
            var ngaygiao = String.Format("{0:MM/dd/yyyy}", collection["NgayGiao"]);
            o.NgayGiao = DateTime.Parse(ngaygiao);
            o.TinhTrangGiaoHang = false;
            o.DaThanhToan = false;
            data.Orders.Add(o);
            data.SaveChanges();
            // phần thêm chi tiết
            foreach (var item in u)
            {
                ChiTietDatHang chitiet = new ChiTietDatHang();
                chitiet.id = o.id;
                chitiet.ProId = item.iproId;
                chitiet.Number = item.isoLuong;
                chitiet.Price = (decimal)item.iproPrice;
                data.ChiTietDatHangs.Add(chitiet);
            }
            data.SaveChanges();
            Session["Carts"] = null;
            return RedirectToAction("CheckOrders", "ShopingCart");
        }
         public ActionResult CheckOrders()
        {
            return View();
        }
            //
            public ActionResult Index()
        {
            return View();
        }
    }
}