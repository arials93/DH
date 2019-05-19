using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KDDongHo.Models;

namespace KDDongHo.Controllers
{
    public class WebCartController : Controller
    {
        QLKD_DONGHOEntities db = new QLKD_DONGHOEntities();
        private string strCart = "Cart";
        //
        // GET: /WebCart/
        public ActionResult Index()
        {
            var brand = db.HANG_SX.ToList();
            ViewBag.Brand = brand;
            return View(strCart);
        }

        [ChildActionOnly]
        public ActionResult Cart_Product(int id)
        {
            List<Cart> lsCart = (List<Cart>)Session[strCart];
            ViewBag.Cart = lsCart;
            return PartialView();
        }

        public ActionResult OrderNow(int id)
        {

            if (Session[strCart] == null)
            {
                List<Cart> lsCart = new List<Cart>
                {
                    new Cart(db.DONG_HO.Find(id),1)
                };
                Session[strCart] = lsCart;
            }
            else
            {
                List<Cart> lsCart = (List<Cart>)Session[strCart];
                var find_dh = lsCart.Find(r => r.Dongho.ID == id);

                if (find_dh != null)
                {
                    find_dh.Soluong += 1;
                }
                else
                {
                    lsCart.Add(new Cart(db.DONG_HO.Find(id), 1));
                }

                Session[strCart] = lsCart;
            }

            return Redirect(Request.UrlReferrer.ToString());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateCard()
        {
            int cart_total = int.Parse(Request["cart_total"]);
            List<Cart> lsCart = (List<Cart>)Session[strCart]; 
            for (int i = 0; i <= cart_total; i++ )
            {
                if (Request["product_id-" + i.ToString()] != null)
                {
                    int dh_id = int.Parse(Request["product_id-" + i.ToString()]);
                    int dh_quantity = int.Parse(Request["quantity-" + i.ToString()]);
                    var find_dh = lsCart.Find(r => r.Dongho.ID == dh_id);
                    if (dh_quantity <= 0)
                    {
                        lsCart.Remove(find_dh);
                    }
                    else
                    {
                        find_dh.Soluong = dh_quantity;
                    }
                }
                
            }

            Session[strCart] = lsCart;
            

            return Redirect(Request.UrlReferrer.ToString());
        }
	}
}