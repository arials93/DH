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
            return View();
        }
	}
}