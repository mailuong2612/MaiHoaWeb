using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MaiHoaWeb.Models;
namespace MaiHoaWeb.Controllers
{
    public class NguoiDungController : Controller
    {
        // GET: NguoiDung
        private MyPhamOnlineFinalEntities db = new MyPhamOnlineFinalEntities();
        // GET: NguoiDung
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Dangnhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Dangnhap(FormCollection collection)
        {
            var tendn = collection["TenDN"];
            var matkhau = collection["Matkhau"];
            if (string.IsNullOrEmpty(tendn))
            {
                ViewData["Loi1"] = "Tên đăng nhập không được để trống";
            }
            else if (string.IsNullOrEmpty(matkhau))
            {
                ViewData["loi2"] = "Mật khẩu không được để trống";
            }
            else
            {
                tb_Customer kh = db.tb_Customer.SingleOrDefault(t => t.Email == tendn && t.MatKhau == matkhau);
                if (kh != null)
                {
                    ViewBag.Thongbao = "Đăng nhập thành công";
                    Session["Taikhoan"] = kh;
                    Session["HoTenUser"] = kh.CustomerName;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Thongbao = "Sai tên đăng nhập hoặc mật khẩu";
                }
            }
            return View();
        }
        public ActionResult Dangxuat()
        {
            Session.Remove("Taikhoan");
            Session.Remove("HoTenUser");
            return RedirectToAction("Index", "Home");
        }
    }
}