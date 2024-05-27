using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MaiHoaWeb.Models;

namespace MaiHoaWeb.Controllers
{
    public class LayoutController : Controller
    {
        private MyPhamOnlineFinalEntities db = new MyPhamOnlineFinalEntities();
        // GET: Layout
        public ActionResult Slider()
        {
            List<tb_Slider> lst;
            lst = db.tb_Slider.ToList();
            return PartialView(lst);
        }
        public ActionResult SliderRight()
        {
            return PartialView();
        }

        //Get new product on slider mini
        private List<tb_Product> GetAllProduct()
        {
            return db.tb_Product.OrderByDescending(x => x.Id).Take(5).ToList();
        }

        public ActionResult NewProduct()
        {
            var SP = GetAllProduct();
            return PartialView(SP);
        }
        public ActionResult HotProduct()
        {
            var topProducts = (from product in db.tb_Product
                               join orderDetail in db.tb_OrderDetail on product.Id equals orderDetail.ProductId
                               group orderDetail by new { product.Id } into g
                               orderby g.Sum(od => od.Quantity) descending
                               select new
                               {
                                   ProductId = g.Key.Id,
                                   TotalQuantitySold = g.Sum(od => od.Quantity)
                               }).ToList();

            // Chuyển đổi topProducts thành danh sách các tb_Product
            var productIds = topProducts.Select(tp => tp.ProductId).ToList();
            var products = db.tb_Product.Where(p => productIds.Contains(p.Id)).ToList();

            // Sắp xếp danh sách products theo tổng số lượng bán được
            products = products.OrderBy(p => productIds.IndexOf(p.Id)).Take(5).ToList();

            return PartialView(products);
        }
        //Get product Sale
        public ActionResult BestSeller()
        {
            List<tb_Product> lst = db.tb_Product.Where(x => x.PriceSale != null).Take(8).ToList();
            return PartialView(lst);
        }
    }
}