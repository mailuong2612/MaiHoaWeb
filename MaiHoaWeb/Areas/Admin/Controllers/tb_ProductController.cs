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
    public class tb_ProductController : Controller
    {
        private MyPhamOnlineFinalEntities db = new MyPhamOnlineFinalEntities();
        
        // GET: Admin/tb_Product
        public ActionResult Index()
        {
            var tb_Product = db.tb_Product.Include(t => t.tb_Category);
            return View(tb_Product.ToList());
        }

        // GET: Admin/tb_Product/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_Product tb_Product = db.tb_Product.Find(id);
            if (tb_Product == null)
            {
                return HttpNotFound();
            }
            return View(tb_Product);
        }

        // GET: Admin/tb_Product/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.tb_Category, "Id", "Name");
            return View();
        }

        // POST: Admin/tb_Product/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Id,Name,CategoryId,Description,ShortDescription,Image,Quantity,Price,PriceSale")] tb_Product tb_Product)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.tb_Product.Add(tb_Product);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.CategoryId = new SelectList(db.tb_Category, "Id", "Name", tb_Product.CategoryId);
        //    return View(tb_Product);
        //}

        //// GET: Admin/tb_Product/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    tb_Product tb_Product = db.tb_Product.Find(id);
        //    if (tb_Product == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.CategoryId = new SelectList(db.tb_Category, "Id", "Name", tb_Product.CategoryId);
        //    return View(tb_Product);
        //}

        //// POST: Admin/tb_Product/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,Name,CategoryId,Description,ShortDescription,Image,Quantity,Price,PriceSale")] tb_Product tb_Product)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(tb_Product).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.CategoryId = new SelectList(db.tb_Category, "Id", "Name", tb_Product.CategoryId);
        //    return View(tb_Product);
        //}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,CategoryId,Description,Image,Quantity,Price,PriceSale")] tb_Product tb_Product)
        {
            if (ModelState.IsValid)
            {
                var fileImg = Request.Files["fileImg"];
                if (fileImg != null && fileImg.ContentLength > 0)
                {
                    string[] ext = fileImg.FileName.Split('.');
                    string fileName = "";
                    int Index = fileImg.FileName.IndexOf(".");
                    fileName = DateTime.Now.ToString("yyyyMMddHHmmssffff") + "." + ext[ext.Length - 1];
                    string path = Server.MapPath("~/Assets/Images/Product/" + fileName);
                    fileImg.SaveAs(path);
                    tb_Product.Image = "/Assets/Images/Product/" + fileName;
                }
                else
                {
                    tb_Product.Image = "";
                }
                db.tb_Product.Add(tb_Product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.tb_Category, "Id", "Name", tb_Product.CategoryId);
            return View(tb_Product);
        }

        // GET: Admin/tb_Product/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_Product tb_Product = db.tb_Product.Find(id);
            if (tb_Product == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.tb_Category, "Id", "Name", tb_Product.CategoryId);
            return View(tb_Product);
        }

        // POST: Admin/tb_Product/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,CategoryId,Description,Image,Quantity,Price,PriceSale")] tb_Product tb_Product)
        {
            if (ModelState.IsValid)
            {
                var fileImg = Request.Files["fileImg"];
                if (fileImg != null && fileImg.ContentLength > 0)
                {
                    string[] ext = fileImg.FileName.Split('.');
                    string fileName = "";
                    int Index = fileImg.FileName.IndexOf(".");
                    fileName = DateTime.Now.ToString("yyyyMMddHHmmssffff") + "." + ext[ext.Length - 1];
                    string path = Server.MapPath("~/Assets/Images/Product/" + fileName);
                    fileImg.SaveAs(path);
                    tb_Product.Image = "/Assets/Images/Product/" + fileName;
                }
                else
                {
                    fileImg = null;
                }
                tb_Product obj = db.tb_Product.Find(tb_Product.Id);
                if (obj != null)
                {
                    obj.Name = tb_Product.Name;
                    obj.CategoryId = tb_Product.CategoryId;
                    obj.Description = tb_Product.Description;
                    if (fileImg != null)
                        obj.Image = tb_Product.Image;
                    obj.Quantity = tb_Product.Quantity;
                    obj.Price = tb_Product.Price;
                    obj.PriceSale = tb_Product.PriceSale;
                }
                //db.Entry(tb_Product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.tb_Category, "Id", "Name", tb_Product.CategoryId);
            return View(tb_Product);
        }

        // GET: Admin/tb_Product/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_Product tb_Product = db.tb_Product.Find(id);
            if (tb_Product == null)
            {
                return HttpNotFound();
            }
            return View(tb_Product);
        }

        // POST: Admin/tb_Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_Product tb_Product = db.tb_Product.Find(id);
            db.tb_Product.Remove(tb_Product);
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
