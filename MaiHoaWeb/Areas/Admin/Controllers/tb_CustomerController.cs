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
    public class tb_CustomerController : Controller
    {
        private MyPhamOnlineFinalEntities db = new MyPhamOnlineFinalEntities();
        
        // GET: Admin/tb_Customer
        public ActionResult Index()
        {
            return View(db.tb_Customer.ToList());
        }

        // GET: Admin/tb_Customer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_Customer tb_Customer = db.tb_Customer.Find(id);
            if (tb_Customer == null)
            {
                return HttpNotFound();
            }
            return View(tb_Customer);
        }

        // GET: Admin/tb_Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/tb_Customer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,CustomerName,MatKhau,Email,Phone,Address")] tb_Customer tb_Customer)
        {
            if (ModelState.IsValid)
            {
                db.tb_Customer.Add(tb_Customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tb_Customer);
        }

        // GET: Admin/tb_Customer/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_Customer tb_Customer = db.tb_Customer.Find(id);
            if (tb_Customer == null)
            {
                return HttpNotFound();
            }
            return View(tb_Customer);
        }

        // POST: Admin/tb_Customer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,CustomerName,MatKhau,Email,Phone,Address")] tb_Customer tb_Customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_Customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tb_Customer);
        }

        // GET: Admin/tb_Customer/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_Customer tb_Customer = db.tb_Customer.Find(id);
            if (tb_Customer == null)
            {
                return HttpNotFound();
            }
            return View(tb_Customer);
        }

        // POST: Admin/tb_Customer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_Customer tb_Customer = db.tb_Customer.Find(id);
            db.tb_Customer.Remove(tb_Customer);
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
