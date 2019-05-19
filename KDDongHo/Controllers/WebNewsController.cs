using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KDDongHo.Models;


namespace KDDongHo.Controllers
{
    public class WebNewsController : Controller
    {
        QLKD_DONGHOEntities db = new QLKD_DONGHOEntities();
        //
        // GET: /WebNews/
        public ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult News_Related(string loaitin)
        {
            var news = new List<BAI_VIET>();
            news = db.BAI_VIET.Where(x => x.LOAITIN == loaitin).Take(8).ToList();
            return PartialView(news);
        }

        public ActionResult News()
        {
            var news = new List<BAI_VIET>();
            news = db.BAI_VIET.Where(a => a.LOAITIN != "GT").OrderByDescending(x => x.NGAYDANG).Take(3).ToList();
            return PartialView(news); 
        }

        public ActionResult News_All()
        {
            ViewBag.Image_Header = "/Static/Storage/header_page2.png";
            ViewBag.Title_Header = "Tin tức";

            var brand = db.HANG_SX.ToList();
            ViewBag.Brand = brand;
            
            var news = new List<BAI_VIET>();
            news = db.BAI_VIET.Where(a => a.LOAITIN != "GT").OrderByDescending(x => x.NGAYDANG).ToList();
            return View(news);
        }

        public ActionResult About()
        {
            ViewBag.Image_Header = "/Static/Storage/header_page3.jpg";
            ViewBag.Title_Header = "Giới thiệu";

            var brand = db.HANG_SX.ToList();
            ViewBag.Brand = brand;

            var news = new List<BAI_VIET>();
            news = db.BAI_VIET.Where(a => a.LOAITIN == "GT").ToList();
            return View(news);
        }

        public ActionResult News_Detail(int id)
        {
            var brand = db.HANG_SX.ToList();
            ViewBag.Brand = brand;

            var news = db.BAI_VIET.Find(id);

            var news_related = db.BAI_VIET.Where(x => x.LOAITIN== news.LOAITIN).Take(5).ToList();
            ViewBag.News_Related = news_related;

            return View(news);
        }
	}
}