using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AmazingShop.Models;
using AmazingShop.Filters;

namespace AmazingShop.Controllers
{
    [AdminAuthorisation]
    public class AdministrationController : Controller
    {
        //
        // GET: /Administration/

        public ActionResult Index()
        {
            return View(new Login());
        }

        [HttpPost]
        public ActionResult LogIn(Login model)
        {
            if (model.Name == "Administrator")
            {
                var cookie = new HttpCookie("auth");
                cookie.Expires = DateTime.Now.AddDays(30);
                cookie.Value = model.Name;
                Response.Cookies.Add(cookie);
                return RedirectToAction("AdministratorControlPanel", "Administration");
            }
            else
            {
                return View("AuthorisationFailed");
            }
        }

        public ActionResult AdministratorControlPanel()
        {
            return View();
        }

        public ActionResult AdminCategories()
        {
            var entity = new ProductsDBEntities1();
            var allCategories = entity.Categories.ToList();
            return View(allCategories);
        }

        public ActionResult AdminProducts()
        {
            var entity = new ProductsDBEntities1();
            var allProducts = entity.ProductLists.ToList();
            return View(allProducts);
        }

    }
}
