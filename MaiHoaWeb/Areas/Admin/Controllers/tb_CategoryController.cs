﻿using System;
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
    public class tb_CategoryController : Controller
    {
        private MyPhamOnlineFinalEntities db = new MyPhamOnlineFinalEntities();
        
        // GET: Admin/tb_Category
        public ActionResult Index()
        {
            return View(db.tb_Category.ToList());
        }

        // GET: Admin/tb_Category/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_Category tb_Category = db.tb_Category.Find(id);
            if (tb_Category == null)
            {
                return HttpNotFound();
            }
            return View(tb_Category);
        }

        // GET: Admin/tb_Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/tb_Category/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] tb_Category tb_Category)
        {
            if (ModelState.IsValid)
            {
                db.tb_Category.Add(tb_Category);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tb_Category);
        }

        // GET: Admin/tb_Category/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_Category tb_Category = db.tb_Category.Find(id);
            if (tb_Category == null)
            {
                return HttpNotFound();
            }
            return View(tb_Category);
        }

        // POST: Admin/tb_Category/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] tb_Category tb_Category)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_Category).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tb_Category);
        }

        // GET: Admin/tb_Category/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_Category tb_Category = db.tb_Category.Find(id);
            if (tb_Category == null)
            {
                return HttpNotFound();
            }
            return View(tb_Category);
        }

        // POST: Admin/tb_Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_Category tb_Category = db.tb_Category.Find(id);
            db.tb_Category.Remove(tb_Category);
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
