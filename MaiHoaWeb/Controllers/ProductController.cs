using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MaiHoaWeb.Models;
using PagedList;
using PagedList.Mvc;
namespace MaiHoaWeb.Controllers
{
    public class ProductController : Controller
    {
        private MyPhamOnlineFinalEntities db = new MyPhamOnlineFinalEntities();
        // GET: Product
        private List<tb_Product> GetAllProduct()
        {
            return db.tb_Product.OrderBy(x => x.Id).ToList();
        }
        public ActionResult Index(int? page)
        {
            int pageSize = 4;
            int pageNum = (page ?? 1);
            var SP = GetAllProduct();
            return View(SP.ToPagedList(pageNum, pageSize));
        }

        //danh mục sản phẩm
        [ChildActionOnly]
        public ActionResult LoaiSP()
        {
            var loai = from item in db.tb_Category select item;
            return PartialView(loai);
        }

        public ActionResult SPTheoLoai(int id, int? page)
        {
            int pageSize = 2;
            int pageNum = (page ?? 1);
            var products = db.tb_Product.Where(p => p.CategoryId == id).OrderBy(x => x.Id).ToPagedList(pageNum, pageSize);
            return View(products);
        }

        public ActionResult ChiTietSP(int id)
        {
            tb_Product ct = db.tb_Product.SingleOrDefault(t => t.Id == id);
            return View(ct);
        }
        [HttpPost]
        public ActionResult Search(string catsearch, string s)
        {
            // Thực hiện tìm kiếm sản phẩm dựa trên các tham số nhận được
            var products = db.tb_Product.Where(p => p.Name == catsearch || p.Name.Contains(s)).ToList();
            return View(products);
        }
    }
}