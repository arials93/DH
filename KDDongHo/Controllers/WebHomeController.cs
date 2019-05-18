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
            ViewBag.Brand = s;


            string ss = "";
            var slide = db.SLIDEs.ToList();
            for (int i = 0; i < slide.Count(); i++ )
            {
                ss += "<div class='item-slick1 item1-slick1' style='background-size: cover; background-image: url("+slide[i].HINH+"); '>";
                    ss += "<div class='wrap-content-slide1 sizefull flex-col-c-m p-l-15 p-r-15 p-t-150 p-b-170'>";
                        ss += "<h2 class='caption1-slide1 xl-text2 t-center bo14 p-b-6 animated visible-false m-b-22' data-appear='fadeInUp'>"
                            + slide[i].LOGAN + "";                           
                        ss += "</h2>";
                        ss += "<div class='wrap-btn-slide1 w-size1 animated visible-false' data-appear='zoomIn'>";

                        ss += "<a href='product.html' class='flex-c-m size2 bo-rad-23 s-text2 bgwhite hov1 trans-0-4'>"
                            + "Mua ngay";                              
                            ss += "</a>";
                        ss += "</div>";
                    ss += "</div>";
                ss += "</div>";
            }
            PartialView("_slide");


            return View();
        }
	}
}