using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KDDongHo.Models;

namespace KDDongHo.Controllers
{
    public class AdminLoginController : Controller
    {
        QLKD_DONGHOEntities db = new QLKD_DONGHOEntities();
        // GET: AdminLogin
        public ActionResult Login()
        {
            if (Session["account_id"] != null)
            {
                return RedirectToAction("Index", "AdminDashboard");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login([Bind(Include = "NAME, PASS")] NGUOI_DUNG account)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    NGUOI_DUNG ng_d = db.NGUOI_DUNG.Where(s => s.NAME == account.NAME && s.PASS == account.PASS).First();
                    Session["account_id"] = ng_d.ID;
                    Session["account_name"] = ng_d.NAME;
                    Session["account_hoten"] = ng_d.HOTEN;
                    Session["account_phone"] = ng_d.SDT;
                    return RedirectToAction("Index", "AdminDashboard");
                }
                catch (InvalidOperationException)
                {
                    ModelState.AddModelError("", "Tài khoản sai");
                    return View(account);
                }
            }

            return View(account);
        }

        public ActionResult Logout()
        {
            Session["account_id"] = null;
            Session["account_name"] = null;
            Session["account_hoten"] = null;
            Session["account_phone"] = null;
            return RedirectToAction("Login", "AdminLogin");
        }
    }
}