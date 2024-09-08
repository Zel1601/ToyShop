using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.UI.WebControls;

namespace ToyShop.Models
{
    public class Original
    {
        //ham lay tat ca san pham thuoc the loai 
       
        public static List<Product> laySanPham()
        {
            List<Product> sp = new List<Product>();
            // -- Khai bao 1 đối tượng 
            DbContext who = new DbContext("name=ToyShopDBContext");
            // -- lấy dữ liệu của db
            sp = who.Set<Product>().ToList<Product>();
            return sp;
        }
        // ham lay the loai
        public static List<Category> layTheLoai()
        {
            return new DbContext("name=ToyShopDBContext").Set<Category>().ToList<Category>();
        }

        public static List<Product> Sptheotheloai (int id)
        {
            List<Product> data = new List<Product>();
            DbContext who = new DbContext("name=ToyShopDBContext");
            data = who.Set<Product>().Where(x =>x.CatId== id).ToList<Product>();
            return data;
        }
        public static List<Blog> laybaiviet()
        {
            List<Blog> bl = new List<Blog>();
            // -- Khai bao 1 đối tượng 
            DbContext who = new DbContext("name=ToyShopDBContext");
            // -- lấy dữ liệu của db
            bl = who.Set<Blog>().ToList<Blog>();
            return bl;
        }
        public static List<Product> laysanphamgiamgia()
        {
            List<Product> p = new List<Product>();
            DbContext who = new DbContext("name=ToyShopDBContext");
            p = who.Set<Product>().Where(n => n.Discount >0).ToList<Product>();
            return p;
        }
        public static List<Product> laysanphammoinhat()
        {
            List<Product> j = new List<Product>();
            DbContext who = new DbContext("name=ToyShopDBContext");
            j = who.Set<Product>().OrderByDescending(m => m.ProId).ToList<Product>();
            return j;
        }
        public static List<Product> laysanphamphobien()
        {
            List<Product> j = new List<Product>();
            DbContext who = new DbContext("name=ToyShopDBContext");
            j = who.Set<Product>().OrderByDescending(m => m.ProPrice).ToList<Product>();
            return j;
        }
        public static List<Product> laysanphamtheoview()
        {
            List<Product> j = new List<Product>();
            DbContext who = new DbContext("name=ToyShopDBContext");
            j = who.Set<Product>().OrderByDescending(m => m.ViewSee).ToList<Product>();
            return j;
        }
    }
}