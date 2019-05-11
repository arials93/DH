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
            return View();
        }
        public ActionResult Product()
        {
            return View();
        }
	}
}