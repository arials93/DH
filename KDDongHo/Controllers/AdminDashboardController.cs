using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KDDongHo.Models;

namespace KDDongHo.Controllers
{
    public class AdminDashboardController : AdminBaseController
    {
        QLKD_DONGHOEntities db = new QLKD_DONGHOEntities();
        //
        // GET: /Admin/
        public ActionResult Index()
        {
            return View();
        }

	}
}