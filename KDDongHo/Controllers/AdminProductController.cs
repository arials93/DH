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
    public class AdminProductController : AdminBaseController
    {
        private QLKD_DONGHOEntities db = new QLKD_DONGHOEntities();
        const String IMAGE_PATH = "/Static/Storage/ProductImages";

        // GET: /AdminProduct/
        public ActionResult Index()
        {
            var dong_ho = db.DONG_HO.Include(d => d.HANG_SX).Include(d => d.KIEU_MAY);
            return View(dong_ho.ToList());
        }

        // GET: /AdminProduct/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DONG_HO dong_ho = db.DONG_HO.Find(id);
            if (dong_ho == null)
            {
                return HttpNotFound();
            }
            return View(dong_ho);
        }

        // GET: /AdminProduct/Create
        public ActionResult Create()
        {
            ViewBag.ID_HANGSX = new SelectList(db.HANG_SX, "ID", "TEN");
            ViewBag.ID_KIEUMAY = new SelectList(db.KIEU_MAY, "ID", "TEN");
            return View();
        }

        // POST: /AdminProduct/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,MAUMA,KICHCO,DODAY,CHATLIEU_VO,CHATLIEU_DAY,CHATLIEU_KINH,DOCHIEUNUOC,BAOHANH,DONGIA,NGAYDANG,GIAMGIA,ID_HANGSX,ID_KIEUMAY,MOI")] DONG_HO dong_ho, IEnumerable<HttpPostedFileBase> Images)
        {
            if (ModelState.IsValid)
            {
                dong_ho.NGAYDANG = DateTime.Now;
                db.DONG_HO.Add(dong_ho);
                try
                {
                    foreach (var file in Images)
                    {
                        if (file != null && file.ContentLength > 0)
                        {
                            String localDate = DateTime.Now.ToString("yyyyMMddHHmmss");
                            String image_name = localDate + "-" + file.FileName;
                            var imagePath = System.IO.Path.Combine(Server.MapPath(IMAGE_PATH), image_name);
                            var imageUrl = IMAGE_PATH + "/" + image_name;
                            file.SaveAs(imagePath);
                            var image = new HINH_ANH()
                            {
                                URL = imageUrl,
                                ID_DONGHO = dong_ho.ID
                            };
                            db.HINH_ANH.Add(image);
                        }
                    }
                }
                catch (NullReferenceException)
                {
                    //Không làm gì cả
                }
                TempData["success"] = "Tạo sản phẩm thành công";
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_HANGSX = new SelectList(db.HANG_SX, "ID", "TEN", dong_ho.ID_HANGSX);
            ViewBag.ID_KIEUMAY = new SelectList(db.KIEU_MAY, "ID", "TEN", dong_ho.ID_KIEUMAY);
            return View(dong_ho);
        }

        // GET: /AdminProduct/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DONG_HO dong_ho = db.DONG_HO.Find(id);
            if (dong_ho == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_HANGSX = new SelectList(db.HANG_SX, "ID", "TEN", dong_ho.ID_HANGSX);
            ViewBag.ID_KIEUMAY = new SelectList(db.KIEU_MAY, "ID", "TEN", dong_ho.ID_KIEUMAY);
            return View(dong_ho);
        }

        // POST: /AdminProduct/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,MAUMA,KICHCO,DODAY,CHATLIEU_VO,CHATLIEU_DAY,CHATLIEU_KINH,DOCHIEUNUOC,BAOHANH,DONGIA,NGAYDANG,GIAMGIA,ID_HANGSX,ID_KIEUMAY,MOI")] DONG_HO dong_ho, IEnumerable<HttpPostedFileBase> Images)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dong_ho).State = EntityState.Modified;
                try
                {
                    foreach (var file in Images)
                    {
                        if (file != null && file.ContentLength > 0)

                        {
                            String localDate = DateTime.Now.ToString("yyyyMMddHHmmss");
                            String image_name = localDate + "-" + file.FileName;
                            var imagePath = System.IO.Path.Combine(Server.MapPath(IMAGE_PATH), image_name);
                            var imageUrl = IMAGE_PATH + "/" + image_name;
                            file.SaveAs(imagePath);
                            var image = new HINH_ANH()
                            {
                                URL = imageUrl,
                                ID_DONGHO = dong_ho.ID
                            };
                            db.HINH_ANH.Add(image);
                        }
                    }
                }
                catch (NullReferenceException)
                {
                    //Không làm gì cả
                }

                TempData["success"] = "Chỉnh sửa sản phẩm thành công";
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_HANGSX = new SelectList(db.HANG_SX, "ID", "TEN", dong_ho.ID_HANGSX);
            ViewBag.ID_KIEUMAY = new SelectList(db.KIEU_MAY, "ID", "TEN", dong_ho.ID_KIEUMAY);
            return View(dong_ho);
        }

        // GET: /AdminProduct/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DONG_HO dong_ho = db.DONG_HO.Find(id);
            if (dong_ho == null)
            {
                return HttpNotFound();
            }
            return View(dong_ho);
        }

        // POST: /AdminProduct/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DONG_HO dong_ho = db.DONG_HO.Find(id);
            foreach (HINH_ANH item in dong_ho.HINH_ANH.ToList())
            {
                //Xóa hình cũ
                if (System.IO.File.Exists(Server.MapPath(item.URL)))
                {
                    System.IO.File.Delete(Server.MapPath(item.URL));
                }
                db.HINH_ANH.Remove(item);
            }

            db.DONG_HO.Remove(dong_ho);
            TempData["success"] = "Xóa sản phẩm thành công";
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
