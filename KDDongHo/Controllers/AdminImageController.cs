using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KDDongHo.Models;

namespace KDDongHo.Controllers
{
    public class AdminImageController : Controller
    {
        private QLKD_DONGHOEntities db = new QLKD_DONGHOEntities();

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HINH_ANH hinh_anh = db.HINH_ANH.Find(id);
            //Xóa hình cũ
            if (System.IO.File.Exists(Server.MapPath(hinh_anh.URL)))
            {
                System.IO.File.Delete(Server.MapPath(hinh_anh.URL));
            }
            db.HINH_ANH.Remove(hinh_anh);
            db.SaveChanges();
            TempData["success"] = "Xóa hình ảnh thành công";
            return Redirect(Request.UrlReferrer.ToString());
        }
    }
}