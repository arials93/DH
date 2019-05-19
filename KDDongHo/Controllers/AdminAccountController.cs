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
    public class AdminAccountController : AdminBaseController
    {
        private QLKD_DONGHOEntities db = new QLKD_DONGHOEntities();

        // GET: AdminAccount
        public ActionResult Index()
        {
            int auth_id = int.Parse(Session["account_id"].ToString());
            return View(db.NGUOI_DUNG.Where(s => s.ID != auth_id && s.IS_SUPER_USER == false).ToList());
        }

        // GET: AdminAccount/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NGUOI_DUNG nGUOI_DUNG = db.NGUOI_DUNG.Find(id);
            if (nGUOI_DUNG == null)
            {
                return HttpNotFound();
            }
            return View(nGUOI_DUNG);
        }

        // GET: AdminAccount/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminAccount/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,NAME,PASS,HOTEN,NGAYSINH,DIACHI,SDT,TRANGTHAI,IS_SUPER_USER")] NGUOI_DUNG nGUOI_DUNG)
        {
            if (ModelState.IsValid)
            {
                db.NGUOI_DUNG.Add(nGUOI_DUNG);
                TempData["success"] = "Tạo tài khoản thành công";
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nGUOI_DUNG);
        }

        // GET: AdminAccount/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NGUOI_DUNG nGUOI_DUNG = db.NGUOI_DUNG.Find(id);
            if (nGUOI_DUNG == null)
            {
                return HttpNotFound();
            }
            return View(nGUOI_DUNG);
        }

        // POST: AdminAccount/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,NAME,PASS,HOTEN,NGAYSINH,DIACHI,SDT,TRANGTHAI,IS_SUPER_USER")] NGUOI_DUNG nGUOI_DUNG)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nGUOI_DUNG).State = EntityState.Modified;
                TempData["success"] = "Sửa tài khoản thành công";
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nGUOI_DUNG);
        }

        // GET: AdminAccount/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NGUOI_DUNG nGUOI_DUNG = db.NGUOI_DUNG.Find(id);
            if (nGUOI_DUNG == null)
            {
                return HttpNotFound();
            }
            return View(nGUOI_DUNG);
        }

        // POST: AdminAccount/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NGUOI_DUNG nGUOI_DUNG = db.NGUOI_DUNG.Find(id);
            db.NGUOI_DUNG.Remove(nGUOI_DUNG);
            TempData["success"] = "Xóa tài khoản thành công";
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost, ActionName("UpdateStatus")]
        [ValidateAntiForgeryToken]
        public ActionResult StatusConfirmed(int id, bool status)
        {
            NGUOI_DUNG nGUOI_DUNG = db.NGUOI_DUNG.Find(id);
            nGUOI_DUNG.TRANGTHAI = status;
            TempData["success"] = "Cập nhập trạng thái thành công";
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
