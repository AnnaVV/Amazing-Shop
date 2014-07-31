using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AmazingShop.Models;

namespace AmazingShop.Controllers
{
    public class CategoryController : Controller
    {
        //
        // GET: /Category/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddCategory()
        {
            return View(new Category());
        }

        [HttpPost]
        public ActionResult SaveCategory(Category model)
        {
            var entity = new ProductsDBEntities1();
            
            entity.Categories.Add(model);
            entity.SaveChanges();
            return RedirectToAction("AddCategory");
        }

    }
}
