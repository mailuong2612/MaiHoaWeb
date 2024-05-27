using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MaiHoaWeb.Models
{
    public class Cart
    {
        public int producId { get; set; }
        public string Name { set; get; }
        public int quantity { get; set; }
        public string Image { set; get; }
        public double Price { set; get; }
        public double dThanhtien
        {
            get { return quantity * Price; }
        }
        private MyPhamOnlineFinalEntities db = new MyPhamOnlineFinalEntities();
        public Cart(int MaSP)
        {
            producId = MaSP;
            tb_Product sp = db.tb_Product.Single(t => t.Id == producId);
            Name = sp.Name;
            Image = sp.Image;
            Price = double.Parse(sp.Price.ToString());
            quantity = 1;
        }
        //public tb_Product productDetail { get; set; }
    }
}