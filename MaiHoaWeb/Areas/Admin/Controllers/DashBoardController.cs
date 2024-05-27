using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MaiHoaWeb.Areas.Admin.Controllers
{
    public class DashBoardController : Controller
    {
        [Authorize]
        // GET: Admin/DashBoard
        public ActionResult Index()
        {
            return View();
        }
    }
}