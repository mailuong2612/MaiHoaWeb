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
    public class tb_SliderController : Controller
    {
        private MyPhamOnlineFinalEntities db = new MyPhamOnlineFinalEntities();

        // GET: Admin/tb_Slider
        public ActionResult Index()
        {
            return View(db.tb_Slider.ToList());
        }

        // GET: Admin/tb_Slider/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_Slider tb_Slider = db.tb_Slider.Find(id);
            if (tb_Slider == null)
            {
                return HttpNotFound();
            }
            return View(tb_Slider);
        }

        // GET: Admin/tb_Slider/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/tb_Slider/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Image,Description")] tb_Slider tb_Slider)
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
                    string path = Server.MapPath("~/Assets/Default/img/slider/" + fileName);
                    fileImg.SaveAs(path);
                    tb_Slider.Image = "/Assets/Default/img/slider/" + fileName;
                }
                else
                {
                    tb_Slider.Image = "";
                }
                db.tb_Slider.Add(tb_Slider);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }

        // GET: Admin/tb_Slider/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_Slider tb_Slider = db.tb_Slider.Find(id);
            if (tb_Slider == null)
            {
                return HttpNotFound();
            }
            return View(tb_Slider);
        }

        // POST: Admin/tb_Slider/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Image,Description")] tb_Slider tb_Slider)
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
                    string path = Server.MapPath("~/Assets/Default/img/slider/" + fileName);
                    fileImg.SaveAs(path);
                    tb_Slider.Image = "/Assets/Default/img/slider/" + fileName;
                }
                else
                {
                    fileImg = null;
                }
                tb_Slider obj = db.tb_Slider.Find(tb_Slider.Id);
                if (obj != null)
                {
                    obj.Title = tb_Slider.Title;
                    obj.Description = tb_Slider.Description;
                    if (fileImg != null)
                        obj.Image = tb_Slider.Image;
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tb_Slider);
        }

        // GET: Admin/tb_Slider/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_Slider tb_Slider = db.tb_Slider.Find(id);
            if (tb_Slider == null)
            {
                return HttpNotFound();
            }
            return View(tb_Slider);
        }

        // POST: Admin/tb_Slider/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_Slider tb_Slider = db.tb_Slider.Find(id);
            db.tb_Slider.Remove(tb_Slider);
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
