using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MaiHoaWeb.Models;
namespace MaiHoaWeb.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(tb_User data)
        {
            MyPhamOnlineFinalEntities db = new MyPhamOnlineFinalEntities();
            if (ModelState.IsValid)
            {
                int count = db.tb_User.Count(x => x.Username == data.Username && x.Password == data.Password);
                if (count == 1)
                {
                    FormsAuthentication.SetAuthCookie(data.Username, false);
                    return RedirectToAction("Index", "DashBoard");
                }
                else
                {
                    ModelState.AddModelError("", "Sai tài khoản hoặc mật khẩu");
                }
            }
            return View(data);
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
    }
}