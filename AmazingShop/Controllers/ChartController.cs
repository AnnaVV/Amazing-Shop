using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AmazingShop.Controllers
{
    public class ChartController : Controller
    {
        //
        // GET: /Chart/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddToChart(int id)
        {
            HttpCookie cookie;
            if (Request.Cookies.AllKeys.Contains("chart"))
            {
                cookie = Request.Cookies["chart"];
                cookie.Value = cookie.Value + ',' + id.ToString();
            }
            else
            {
                cookie = new HttpCookie("chart");
                cookie.Value = id.ToString();
            }

            cookie.Expires = DateTime.Now.AddDays(10);
            Response.Cookies.Add(cookie);
            return Redirect(Request.UrlReferrer.ToString());
        }

    }
}
