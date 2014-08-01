using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AmazingShop.Models;

namespace AmazingShop.Controllers
{
    public class ProductController : Controller
    {
        //
        // GET: /Product/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddProduct()
        {
            var entity = new ProductsDBEntities1();
            var categories = entity.Categories.ToList();

            var categoryList = categories.Select(x => { return new SelectListItem { Text = x.CategoryName, Value = x.Id.ToString() }; }).ToList();

            ViewBag.Categories = categoryList;
            return View(new ProductList());
        }

        [HttpPost]
        public ActionResult SaveProduct(ProductList model)
        {
            var entity = new ProductsDBEntities1();
            var categories = entity.Categories.ToList().First(x => x.Id == model.CategoryId);
            model.Category = categories;
            entity.ProductLists.Add(model);
            entity.SaveChanges();
            return RedirectToAction("AddProduct");
        }

    }
}
