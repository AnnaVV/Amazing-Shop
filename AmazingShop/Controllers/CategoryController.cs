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
            var entity = new ProductsDBEntities1();
            var categories = entity.Categories.ToList();
            return View(categories);
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

        public ActionResult GetProductListByCategory(int id)
        {
            var entity = new ProductsDBEntities1();

            var productListQuery = entity.ProductLists.Where(x => x.CategoryId == id).ToList();
            var categoryName = entity.Categories.First(x => x.Id == id).CategoryName;

            ViewBag.CategoryName = categoryName;
            return View(productListQuery);
        }

    }
}
