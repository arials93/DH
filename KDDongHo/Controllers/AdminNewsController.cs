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
    public class AdminNewsController : AdminBaseController
    {
        private QLKD_DONGHOEntities db = new QLKD_DONGHOEntities();
        const String IMAGE_PATH = "/Static/Storage/News";

        // GET: AdminNews
        public ActionResult Index()
        {
            var bAI_VIET = db.BAI_VIET.Include(b => b.NGUOI_DUNG);
            return View(bAI_VIET.ToList());
        }

        // GET: AdminNews/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BAI_VIET bAI_VIET = db.BAI_VIET.Find(id);
            if (bAI_VIET == null)
            {
                return HttpNotFound();
            }
            return View(bAI_VIET);
        }

        // GET: AdminNews/Create
        public ActionResult Create()
        {
            ViewBag.ID_NGUOIDUNG = new SelectList(db.NGUOI_DUNG, "ID", "NAME");
            return View();
        }

        // POST: AdminNews/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,TEN,HINH,ND_TOMTAT,NOIDUNG,NGAYDANG,LOAITIN,ID_NGUOIDUNG,DUYET")] BAI_VIET bAI_VIET)
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
                    bAI_VIET.HINH = imageUrl;
                }
                bAI_VIET.ID_NGUOIDUNG = int.Parse(Session["account_id"].ToString());
                bAI_VIET.NGAYDANG = DateTime.Now;
                db.BAI_VIET.Add(bAI_VIET);
                TempData["success"] = "Tạo bài viết thành công";
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_NGUOIDUNG = new SelectList(db.NGUOI_DUNG, "ID", "NAME", bAI_VIET.ID_NGUOIDUNG);
            return View(bAI_VIET);
        }

        // GET: AdminNews/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BAI_VIET bAI_VIET = db.BAI_VIET.Find(id);
            if (bAI_VIET == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_NGUOIDUNG = new SelectList(db.NGUOI_DUNG, "ID", "NAME", bAI_VIET.ID_NGUOIDUNG);
            return View(bAI_VIET);
        }

        // POST: AdminNews/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,TEN,HINH,ND_TOMTAT,NOIDUNG,NGAYDANG,LOAITIN,ID_NGUOIDUNG,DUYET")] BAI_VIET bAI_VIET)
        {
            if (ModelState.IsValid)
            {
                BAI_VIET bv = db.BAI_VIET.FirstOrDefault(x => x.ID == bAI_VIET.ID);
                var file = Request.Files["HINH"];
                if (file != null && file.ContentLength > 0)
                {
                    String localDate = DateTime.Now.ToString("yyyyMMddHHmmss");
                    String image_name = localDate + "-" + file.FileName;
                    var imagePath = System.IO.Path.Combine(Server.MapPath(IMAGE_PATH), image_name);
                    var imageUrl = IMAGE_PATH + "/" + image_name;
                    file.SaveAs(imagePath);
                    //Xóa hình cũ khi update hình mới
                    if (System.IO.File.Exists(Server.MapPath(bv.HINH)))
                    {
                        System.IO.File.Delete(Server.MapPath(bv.HINH));
                    }
                    //Cập nhập hình ảnh mới
                    bv.HINH = imageUrl;
                }
                //db.Entry(bAI_VIET).State = EntityState.Modified;
                bv.TEN = bAI_VIET.TEN;
                bv.LOAITIN = bAI_VIET.LOAITIN;
                bv.ND_TOMTAT = bAI_VIET.ND_TOMTAT;
                bv.NOIDUNG = bAI_VIET.NOIDUNG;
                TempData["success"] = "Sửa bài viết thành công";
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_NGUOIDUNG = new SelectList(db.NGUOI_DUNG, "ID", "NAME", bAI_VIET.ID_NGUOIDUNG);
            return View(bAI_VIET);
        }

        // GET: AdminNews/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BAI_VIET bAI_VIET = db.BAI_VIET.Find(id);
            if (bAI_VIET == null)
            {
                return HttpNotFound();
            }
            return View(bAI_VIET);
        }

        // POST: AdminNews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BAI_VIET bAI_VIET = db.BAI_VIET.Find(id);
            //Xóa hình cũ khi update hình mới
            if (System.IO.File.Exists(Server.MapPath(bAI_VIET.HINH)))
            {
                System.IO.File.Delete(Server.MapPath(bAI_VIET.HINH));
            }
            db.BAI_VIET.Remove(bAI_VIET);
            TempData["success"] = "Xóa bài viết thành công";
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // POST: AdminNews/Delete/5
        [HttpPost, ActionName("Censored")]
        [ValidateAntiForgeryToken]
        public ActionResult CensoredConfirmed(int id)
        {
            BAI_VIET bAI_VIET = db.BAI_VIET.Find(id);
            bAI_VIET.DUYET = true;
            //Duyệt bài viết
            TempData["success"] = "Duyệt bài viết thành công";
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
