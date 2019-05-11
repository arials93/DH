using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KDDongHo.Models;

namespace KDDongHo.Controllers
{
    public class WebHomeController : Controller
    {
        QLKD_DONGHOEntities db = new QLKD_DONGHOEntities();
        // GET: /Home/
        public ActionResult Index()
        {
            string s = "";
            var brand = (from b in db.HANG_SX select b).ToList();
            for (int i = 0; i < brand.Count(); i++ )
            {
                s += "<li><a href='index.html'>"+brand[i].TEN+"</a></li>";
            }
            ViewBag.View = s;


            return View();
        }
	}
}