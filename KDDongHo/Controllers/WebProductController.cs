using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KDDongHo.Models;

namespace KDDongHo.Controllers
{
    public class WebProductController : Controller
    {
        QLKD_DONGHOEntities db = new QLKD_DONGHOEntities();
        //
        // GET: /WebProduct/
        public ActionResult Index()
        {
            var brand = db.HANG_SX.ToList();
            ViewBag.Brand = brand;
            return View();
        }

        [ChildActionOnly]
        public ActionResult Products(String type)
        {
            var products = new List<DONG_HO>();
            if (type == "sale")
            {
                products = db.DONG_HO.Where(x => x.GIAMGIA > 0).OrderByDescending(a => a.GIAMGIA).Take(8).ToList();
            }
            else if (type == "new") {
                products = db.DONG_HO.Where(x => x.MOI == true).OrderByDescending(a => a.NGAYDANG).Take(8).ToList();
            }
            return PartialView(products);           
        }

        [ChildActionOnly]
        public ActionResult Product_Related(int id)
        {
            var products = new List<DONG_HO>();
            products = db.DONG_HO.Where(x => x.ID_HANGSX == id).Take(8).ToList();
            return PartialView(products);
        }

        public ActionResult Product_All_News()
        {
            var products = new List<DONG_HO>();
            products = db.DONG_HO.Where(x => x.MOI == true).OrderByDescending(a => a.NGAYDANG).Take(8).ToList();
            return PartialView(products);
        }

        public ActionResult Products_Brand(int id)
        {
            ViewBag.Image_Header = "/Static/Storage/header_page1.png";
            ViewBag.Title_Header = "Sản phẩm";

            var brand = db.HANG_SX.ToList();
            ViewBag.Brand = brand;

            var logo_brand = db.HANG_SX.Take(3).ToList();
            ViewBag.Logo_Brand = logo_brand;

            if(id == 0)
            {
                var products = db.DONG_HO.ToList();
                return View(products);
            }

            var product = db.DONG_HO.Where(x => x.ID_HANGSX == id).ToList();
            return View(product);
        }

        public ActionResult Product_Detail(int id)
        {
            var brand = db.HANG_SX.ToList();
            ViewBag.Brand = brand;

            var product = db.DONG_HO.Find(id);

            return View(product);
        }
	}
}