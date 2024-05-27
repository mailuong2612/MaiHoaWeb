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
{[Authorize]
    public class tb_OderController : Controller
    {
        private MyPhamOnlineFinalEntities db = new MyPhamOnlineFinalEntities();
        
        // GET: Admin/tb_Oder
        public ActionResult Index()
        {
            var tb_Oder = db.tb_Oder
                        .Include(t => t.tb_Customer)//nạp dữ liệu từ bảng tb_Customer liên quan đến bảng tb_Oder
                        .OrderByDescending(t => t.Date);
            return View(tb_Oder.ToList());
        }

        // GET: Admin/tb_Oder/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_Oder tb_Oder = db.tb_Oder.Find(id);
            if (tb_Oder == null)
            {
                return HttpNotFound();
            }
            return View(tb_Oder);
        }

        // GET: Admin/tb_Oder/Create
        public ActionResult Create()
        {
            ViewBag.CustomerId = new SelectList(db.tb_Customer, "id", "CustomerName");
            return View();
        }

        // POST: Admin/tb_Oder/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CustomerId,CustomerName,TotalAmount,Date,IsPaid")] tb_Oder tb_Oder)
        {
            if (ModelState.IsValid)
            {
                db.tb_Oder.Add(tb_Oder);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerId = new SelectList(db.tb_Customer, "id", "CustomerName", tb_Oder.CustomerId);
            return View(tb_Oder);
        }

        // GET: Admin/tb_Oder/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_Oder tb_Oder = db.tb_Oder.Find(id);
            if (tb_Oder == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerId = new SelectList(db.tb_Customer, "id", "CustomerName", tb_Oder.CustomerId);
            return View(tb_Oder);
        }

        // POST: Admin/tb_Oder/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CustomerId,CustomerName,TotalAmount,Date,IsPaid")] tb_Oder tb_Oder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_Oder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerId = new SelectList(db.tb_Customer, "id", "CustomerName", tb_Oder.CustomerId);
            return View(tb_Oder);
        }

        // GET: Admin/tb_Oder/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_Oder tb_Oder = db.tb_Oder.Find(id);
            if (tb_Oder == null)
            {
                return HttpNotFound();
            }
            return View(tb_Oder);
        }

        // POST: Admin/tb_Oder/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_Oder tb_Oder = db.tb_Oder.Find(id);
            db.tb_Oder.Remove(tb_Oder);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
