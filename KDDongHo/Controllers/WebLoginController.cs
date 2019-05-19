using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KDDongHo.Models;

namespace KDDongHo.Controllers
{
    public class WebLoginController : Controller
    {
        QLKD_DONGHOEntities db = new QLKD_DONGHOEntities();
        //
        // GET: /WebLogin/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            var brand = db.HANG_SX.ToList();
            ViewBag.Brand = brand;

            if (Session["account_id"] != null)
            {
                return RedirectToAction("Index", "WebHome");
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login([Bind(Include = "EMAIL, PASS")] KHACH_HANG account)
        {
            var brand = db.HANG_SX.ToList();
            ViewBag.Brand = brand;
            if (ModelState.IsValid)
            {
                try
                {
                    KHACH_HANG kh = db.KHACH_HANG.Where(s => s.EMAIL == account.EMAIL && s.PASS == account.PASS).First();
                    Session["account_id"] = kh.ID;
                    Session["account_name"] = kh.EMAIL;
                    Session["account_hoten"] = kh.HOTEN;
                    Session["account_phone"] = kh.SDT;
                    return RedirectToAction("Index", "WebHome");
                }
                catch (InvalidOperationException)
                {
                    ModelState.AddModelError("", "Tài khoản hoặc mật khẩu không đúng");
                    return View(account);
                }
            }

            return View(account);
        }
        public ActionResult Logout()
        {
            var brand = db.HANG_SX.ToList();
            ViewBag.Brand = brand;
            Session["account_id"] = null;
            Session["account_name"] = null;
            Session["account_hoten"] = null;
            Session["account_phone"] = null;
            return RedirectToAction("Login", "WebLogin");
        }
	}
}