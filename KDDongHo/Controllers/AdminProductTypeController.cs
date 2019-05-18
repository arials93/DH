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
    public class AdminProductTypeController : Controller
    {
        private QLKD_DONGHOEntities db = new QLKD_DONGHOEntities();

        // GET: /AdminProductType/
        public ActionResult Index()
        {
            return View(db.KIEU_MAY.ToList());
        }

        // GET: /AdminProductType/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KIEU_MAY kieu_may = db.KIEU_MAY.Find(id);
            if (kieu_may == null)
            {
                return HttpNotFound();
            }
            return View(kieu_may);
        }

        // GET: /AdminProductType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /AdminProductType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,TEN,GHICHU")] KIEU_MAY kieu_may)
        {
            if (ModelState.IsValid)
            {
                db.KIEU_MAY.Add(kieu_may);
                db.SaveChanges();
                TempData["success"] = "Thêm kiểu máy thành công";
                return RedirectToAction("Index");
            }

            return View(kieu_may);
        }

        // GET: /AdminProductType/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KIEU_MAY kieu_may = db.KIEU_MAY.Find(id);
            if (kieu_may == null)
            {
                return HttpNotFound();
            }
            return View(kieu_may);
        }

        // POST: /AdminProductType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,TEN,GHICHU")] KIEU_MAY kieu_may)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kieu_may).State = EntityState.Modified;
                db.SaveChanges();
                TempData["success"] = "Sửa kiểu máy thành công";
                return RedirectToAction("Index");
            }
            return View(kieu_may);
        }

        // GET: /AdminProductType/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KIEU_MAY kieu_may = db.KIEU_MAY.Find(id);
            if (kieu_may == null)
            {
                return HttpNotFound();
            }
            return View(kieu_may);
        }

        // POST: /AdminProductType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KIEU_MAY kieu_may = db.KIEU_MAY.Find(id);
            db.KIEU_MAY.Remove(kieu_may);
            db.SaveChanges();
            TempData["success"] = "Xóa kiểu máy thành công";
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
