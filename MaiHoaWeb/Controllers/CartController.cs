using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MaiHoaWeb.Models;
namespace MaiHoaWeb.Controllers
{
    public class CartController : Controller
    {
        private MyPhamOnlineFinalEntities db = new MyPhamOnlineFinalEntities();
        // GET: Cart
        public List<Cart> Laygiohang() 
        {
            List<Cart> lstCart = (List<Cart>)Session["lstCart"];
            if (lstCart == null)
            {
                lstCart = new List<Cart>();
            }
            return lstCart;
        }
        // GET: Cart
        public ActionResult Index()
        {
            List<Cart> lstCart = (List<Cart>)Session["lstCart"];
            if (lstCart == null)
            {
                lstCart = new List<Cart>();
            }
            return View(lstCart);
        }
        private int Tongsoluong()
        {
            int iTongsoluong = 0;
            List<Cart> lstGiohang = Session["Cart"] as List<Cart>;
            if (lstGiohang != null)
            {
                iTongsoluong = lstGiohang.Sum(t => t.quantity);
            }
            return iTongsoluong;
        }
        private double Tongtien()
        {
            double iTongtien = 0;
            List<Cart> lstGiohang = Session["Cart"] as List<Cart>;
            if (lstGiohang != null)
            {
                iTongtien = Convert.ToDouble(lstGiohang.Sum(t => t.Price * t.quantity));
            }
            return iTongtien;
        }

        public ActionResult AddToCart(int productId)
        {
            List<Cart> lstCart = (List<Cart>)Session["lstCart"];
            if (lstCart == null)
            {
                lstCart = new List<Cart>();
            }
            Cart obj = lstCart.Find(x => x.producId == productId);

            if (obj != null)
            {
                obj.quantity = obj.quantity + 1;

            }
            else
            {
                //tb_Product product = db.tb_Product.First(x => x.Id == productId);
                obj = new Cart(productId);
                //obj.producId = productId;
                //obj.Name
                //obj.quantity = 1;
                lstCart.Add(obj);
            }
            Session["lstCart"] = lstCart;
            return RedirectToAction("Index", "Home");
        }
        public ActionResult XoaGioHang(int iMaSP)
        {
            List<Cart> lstGiohang = Laygiohang();
            Cart sanpham = lstGiohang.SingleOrDefault(t => t.producId == iMaSP);
            if (sanpham != null)
            {
                lstGiohang.RemoveAll(t => t.producId == iMaSP);
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }
        public ActionResult XoaTatcaGiohang()
        {
            List<Cart> lstGiohang = Laygiohang();
            lstGiohang.Clear();
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public ActionResult UpdateCart( FormCollection collection)
        {
            //List<Cart> lstCart = Laygiohang();
            //foreach (var item in lstCart)
            //{
            //    if (item.producId == iMaSp)
            //    {
            //        item.quantity = Convert.ToInt32(collection["qtybutton"]);
            //        break;
            //    }
            //}
            //return RedirectToAction("Index");
            List<Cart> lstCart = Laygiohang();
            foreach (var item in lstCart)
            {
                var quantityKey = "qtybutton_" + item.producId;
                if (collection.AllKeys.Contains(quantityKey))
                {
                    item.quantity = Convert.ToInt32(collection[quantityKey]);
                }
            }
            // Lưu lại giỏ hàng ở đây nếu cần
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Dathang()
        {
            if (Session["Taikhoan"] == null || Session["Taikhoan"].ToString() == "")
            {
                return RedirectToAction("Dangnhap", "NguoiDung");
            }
            //if (Session["Cart"] == null)
            //{
            //    return RedirectToAction("Index", "Home");
            //}
            List<Cart> lstGiohang = Laygiohang();
            ViewBag.Tongsoluong = Tongsoluong();
            ViewBag.Tongtien = Tongtien();
            return View(lstGiohang);
        }
        [HttpPost]
        public ActionResult Dathang(FormCollection collection)
        {
            List<Cart> lstGiohang = Laygiohang();
            tb_Oder ddh = new tb_Oder();
            tb_Customer kh = (tb_Customer)Session["Taikhoan"];
            ddh.CustomerId = kh.id;
            ddh.CustomerName = kh.CustomerName;
            double Tongtien = Convert.ToDouble(lstGiohang.Sum(t => t.dThanhtien));
            ddh.TotalAmount = Tongtien;
            ddh.Date = DateTime.Now;
            ddh.IsPaid = false;
            db.tb_Oder.Add(ddh);
            db.SaveChanges();
            foreach (var item in lstGiohang)
            {
                tb_OrderDetail ctdh = new tb_OrderDetail();
                ctdh.OderId = ddh.Id;
                ctdh.ProductId = item.producId;
                ctdh.Quantity = item.quantity;
                ctdh.Price = item.Price;

                db.tb_OrderDetail.Add(ctdh);
            }
            db.SaveChanges();
            lstGiohang.Clear();
            Session["Cart"] = null;
            return RedirectToAction("Xacnhandonhang", "Cart");
        }
        public ActionResult Xacnhandonhang()
        {
            return View();
        }
    }
}