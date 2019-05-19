using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KDDongHo.Models;

namespace KDDongHo.Controllers
{
    public class AdminSlideController : AdminBaseController
    {
        private QLKD_DONGHOEntities db = new QLKD_DONGHOEntities();
        const String IMAGE_PATH = "/Static/Storage/Slide";
        // GET: AdminSlide
        public ActionResult Index()
        {
            return View(db.SLIDEs.ToList());
        }

        // GET: AdminSlide/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SLIDE sLIDE = db.SLIDEs.Find(id);
            if (sLIDE == null)
            {
                return HttpNotFound();
            }
            return View(sLIDE);
        }

        // GET: AdminSlide/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminSlide/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,HINH,LOGAN")] SLIDE sLIDE)
        {
            if (ModelState.IsValid)
            {
                var file = Request.Files["HINH"];
                if (file != null && file.ContentLength > 0)
                {
                    String localDate = DateTime.Now.ToString("yyyyMMddHHmmss");
                    String image_name = localDate + "-" + file.FileName;
                    var imagePath = System.IO.Path.Combine(Server.MapPath(IMAGE_PATH), image_name);
                    var imageUrl = IMAGE_PATH + "/" + image_name;
                    file.SaveAs(imagePath);
                    sLIDE.HINH = imageUrl;
                }

                db.SLIDEs.Add(sLIDE);
                TempData["success"] = "Tạo Slide thành công";
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sLIDE);
        }

        // GET: AdminSlide/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SLIDE sLIDE = db.SLIDEs.Find(id);
            if (sLIDE == null)
            {
                return HttpNotFound();
            }
            return View(sLIDE);
        }

        // POST: AdminSlide/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,HINH,LOGAN")] SLIDE sLIDE)
        {
            if (ModelState.IsValid)
            {
                SLIDE slider = db.SLIDEs.FirstOrDefault(x => x.ID == sLIDE.ID);
                var file = Request.Files["LOGO"];
                if (file != null && file.ContentLength > 0)
                {
                    String localDate = DateTime.Now.ToString("yyyyMMddHHmmss");
                    String image_name = localDate + "-" + file.FileName;
                    var imagePath = System.IO.Path.Combine(Server.MapPath(IMAGE_PATH), image_name);
                    var imageUrl = IMAGE_PATH + "/" + image_name;
                    file.SaveAs(imagePath);
                    //Xóa hình cũ khi update hình mới
                    if (System.IO.File.Exists(Server.MapPath(slider.HINH)))
                    {
                        System.IO.File.Delete(Server.MapPath(slider.HINH));
                    }
                    //Cập nhập hình ảnh mới
                    slider.HINH = imageUrl;
                }
                slider.LOGAN = sLIDE.LOGAN;
                TempData["success"] = "Sửa Slide thành công";
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sLIDE);
        }

        // GET: AdminSlide/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SLIDE sLIDE = db.SLIDEs.Find(id);
            if (sLIDE == null)
            {
                return HttpNotFound();
            }
            return View(sLIDE);
        }

        // POST: AdminSlide/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SLIDE sLIDE = db.SLIDEs.Find(id);
            //Xóa hình cũ khi update hình mới
            if (System.IO.File.Exists(Server.MapPath(sLIDE.HINH)))
            {
                System.IO.File.Delete(Server.MapPath(sLIDE.HINH));
            }
            db.SLIDEs.Remove(sLIDE);
            TempData["success"] = "Xóa Slide thành công";
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
