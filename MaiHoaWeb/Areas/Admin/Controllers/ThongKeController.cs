using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MaiHoaWeb.Models;

namespace MaiHoaWeb.Areas.Admin.Controllers
{
    [Authorize]
    public class ThongKeController : Controller
    {
        private MyPhamOnlineFinalEntities db = new MyPhamOnlineFinalEntities();
        

        // GET: Admin/ThongKe
        public ActionResult Index()
        {
            //    var reportInfo = db.tb_Oder
            //.GroupBy(o => 1) // Group tất cả các đơn hàng thành một nhóm
            //.Select(g => new 
            //{
            //    Sum = g.Sum(p => p.TotalAmount),
            //    ViewBag.Count = g.Count()
            //})
            //.FirstOrDefault(); // Lấy phần tử đầu tiên từ kết quả (nếu có)
            var totalRevenue = db.tb_Oder.Sum(o => o.TotalAmount);
            ViewBag.Count = totalRevenue;


            var totalDonHang = db.tb_Oder
                .Count();
            ViewBag.CountOD = totalDonHang;

            int totalOutOfStockProducts = db.tb_Product.Count(p => p.Quantity == 0);
            ViewBag.TotalOutOfStockProducts = totalOutOfStockProducts;

            var totalsp = db.tb_Product
                .Count();
            ViewBag.totalsp = totalsp;

            return View();
        }
    }
}