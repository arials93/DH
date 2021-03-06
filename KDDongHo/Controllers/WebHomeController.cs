﻿using System;
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
            
            var brand = db.HANG_SX.ToList();
            ViewBag.Brand = brand;

            var slide = db.SLIDEs.ToList();
            ViewBag.Slide = slide;

            var logo_brand = db.HANG_SX.Take(3).ToList();
            ViewBag.Logo_Brand = logo_brand;

            return View();
        }
	}
}