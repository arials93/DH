using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KDDongHo.Models;

namespace KDDongHo.Controllers
{
    public class WebOrderController : Controller
    {
        private QLKD_DONGHOEntities db = new QLKD_DONGHOEntities();
        //
        // GET: /WebOrder/
        public ActionResult Detail(int id)
        {
            var brand = db.HANG_SX.ToList();
            ViewBag.Brand = brand;
            DON_HANG dh = db.DON_HANG.Find(id);
            return View(dh);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Checkout()
        {
            var cart = (List<KDDongHo.Models.Cart>)Session["Cart"];
            var order = new DON_HANG();
            if(cart != null) {
                var str_datetime = Request["ngaysinh"];
                var customers = new KHACH_HANG {
                HOTEN = Request["name"],
                NGAYSINH = DateTime.Parse(str_datetime),
                SDT = Request["sdt"],
                DIACHI = Request["diachi"],
                EMAIL = Request["email"]
                };
                db.KHACH_HANG.Add(customers);
                var localtime = DateTime.Now.ToString("yyyyMMddHHmmss");
                order = new DON_HANG {
                    SO_DH = localtime,
                    ID_KHACHHANG = customers.ID,
                    TONGTIEN = int.Parse(Request["total_money"]),
                    GHICHU = Request["ghichu"],
                    NGAYDAT = DateTime.Now,
                    NGAYGIAO = DateTime.Now.AddDays(3)
                };

                db.DON_HANG.Add(order);

                foreach (var item in cart)
                {
                    int gia = 0;
                    if (item.Dongho.GIAMGIA > 0)
                    {
                        gia = int.Parse((@item.Dongho.DONGIA - (@item.Dongho.DONGIA * @item.Dongho.GIAMGIA) / 100).ToString());
                    }
                    else
                    {
                        gia = int.Parse((@item.Dongho.DONGIA).ToString());
                    }

                    var dathang = new DAT_HANG
                    {
                        ID_DONGHO = item.Dongho.ID,
                        ID_DONHANG = order.ID,
                        SOLUONG = item.Soluong,
                        DONGIA = item.Dongho.DONGIA,
                        GIAGIAM = int.Parse(item.Dongho.GIAMGIA.ToString()),
                        THANHTIEN = gia * item.Soluong
                    };
                    db.DAT_HANG.Add(dathang);
                }

                
            }
            Session["Cart"] = null;
            db.SaveChanges();
            return RedirectToAction("Detail", "WebOrder", new { id = order.ID });
        }
	}
}