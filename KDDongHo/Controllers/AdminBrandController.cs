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
    public class AdminBrandController : AdminBaseController
    {
        private QLKD_DONGHOEntities db = new QLKD_DONGHOEntities();
        const String IMAGE_PATH = "/Static/Storage/Brand";

        // GET: AdminBrand
        public ActionResult Index()
        {
            return View(db.HANG_SX.ToList());
        }

        // GET: AdminBrand/Details/5
        // Phần này để xem chi tiết, cũng thừa có thể bỏ
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HANG_SX hANG_SX = db.HANG_SX.Find(id);
            if (hANG_SX == null)
            {
                return HttpNotFound();
            }
            return View(hANG_SX);
        }

        // GET: AdminBrand/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminBrand/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,TEN,LOGO,GIOITHIEU")] HANG_SX hANG_SX)
        {
            if (ModelState.IsValid)
            {
                var file = Request.Files["LOGO"];
                if (file != null && file.ContentLength > 0)
                {
                    String localDate = DateTime.Now.ToString("yyyyMMddHHmmss");
                    String image_name = localDate + "-" + file.FileName;
                    var imagePath = System.IO.Path.Combine(Server.MapPath(IMAGE_PATH), image_name);
                    var imageUrl = IMAGE_PATH + "/" + image_name;
                    file.SaveAs(imagePath);
                    hANG_SX.LOGO = imageUrl;
                }

                db.HANG_SX.Add(hANG_SX);
                db.SaveChanges();
                TempData["success"] = "Thêm nhãn hiệu thành công";
                return RedirectToAction("Index");
            }

            return View(hANG_SX);
        }

        // GET: AdminBrand/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HANG_SX hANG_SX = db.HANG_SX.Find(id);
            if (hANG_SX == null)
            {
                return HttpNotFound();
            }
            return View(hANG_SX);
        }

        // POST: AdminBrand/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,TEN,LOGO,GIOITHIEU")] HANG_SX hANG_SX)
        {
            if (ModelState.IsValid)
            {
                HANG_SX hangsx = db.HANG_SX.FirstOrDefault(x => x.ID == hANG_SX.ID);
                var file = Request.Files["LOGO"];
                if (file != null && file.ContentLength > 0)
                {
                    String localDate = DateTime.Now.ToString("yyyyMMddHHmmss");
                    String image_name = localDate + "-" + file.FileName;
                    var imagePath = System.IO.Path.Combine(Server.MapPath(IMAGE_PATH), image_name);
                    var imageUrl = IMAGE_PATH + "/" + image_name;
                    file.SaveAs(imagePath);
                    //Xóa hình cũ khi update hình mới
                    if (System.IO.File.Exists(Server.MapPath(hangsx.LOGO)))
                    {
                        System.IO.File.Delete(Server.MapPath(hangsx.LOGO));
                    }
                    //Cập nhập hình ảnh mới
                    hangsx.LOGO = imageUrl;
                }

                hangsx.TEN = hANG_SX.TEN;
                hangsx.GIOITHIEU = hANG_SX.GIOITHIEU;

                db.SaveChanges();
                TempData["success"] = "Sửa nhãn hiệu thành công";
                return RedirectToAction("Index");
            }
            return View(hANG_SX);
        }

        // GET: AdminBrand/Delete/5
        //Phần này thừa, có thể bỏ
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HANG_SX hANG_SX = db.HANG_SX.Find(id);
            if (hANG_SX == null)
            {
                return HttpNotFound();
            }
            return View(hANG_SX);
        }

        // POST: AdminBrand/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HANG_SX hANG_SX = db.HANG_SX.Find(id);

            //Xóa hình cũ khi update hình mới
            if (System.IO.File.Exists(Server.MapPath(hANG_SX.LOGO)))
            {
                System.IO.File.Delete(Server.MapPath(hANG_SX.LOGO));
            }
            db.HANG_SX.Remove(hANG_SX);
            db.SaveChanges();
            TempData["success"] = "Xóa nhãn hiệu thành công";
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
