using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KDDongHo.Controllers
{
    public class AdminBaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            InitAppController(filterContext);
            base.OnActionExecuting(filterContext);
        }

        // Redirect to login page if user's session is not valid.
        public void InitAppController(ActionExecutingContext filterContext)
        {
            if (Session["account_id"] == null)
            {
                filterContext.Result = RedirectToAction("Login", "AdminLogin");
            }
        }
    }
}