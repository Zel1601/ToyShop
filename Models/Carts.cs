using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToyShop.Models
{
    public class Carts
    {
        // Tạo đối tượng chứa dữ liệu từ model
        ToyShopDBContext data = new ToyShopDBContext();
        public int iproId { get; set; }
        public string iproName { get; set; }

        public string iproImage { get; set; }

        public double iproPrice { get; set; }

        public double idiscount { get; set; } // giam gia

        public int isoLuong { get; set; }

        public double ithanhtien { 
            get { return (isoLuong * iproPrice) - idiscount; }
        }

        public Carts (int ProId)
        {
            iproId = ProId;
            Product sanpham = data.Products.Single(n => n.ProId == iproId);
            iproName = sanpham.ProName;
            iproImage= sanpham.ProImage;
            iproPrice=double.Parse(sanpham.ProPrice.ToString());
            idiscount = double.Parse((sanpham.Discount.ToString()));
            isoLuong = 1;
        }
        
           
    }
}