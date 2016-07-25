using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Restaurant.Models;
using Restaurant.Repository;

namespace Restaurant.Controllers
{
    public class MenuController : Controller
    {
        private RestaurantDBEntities db = new RestaurantDBEntities();

        private IProductRepository iProductRepository = new ProductRepository();
        private ICategoryRepository iCategoryRepository = new CategoryRepository();

        // GET: /Menu/
        public ActionResult Index()
        {
            var categories = db.ItemCategories.ToList();
            return View(categories);
        }

        [HttpPost]
        public ActionResult Browse(int category)
        {
            var categoryModel = db.ItemLists.Include("ItemCategory").Single(c=>c.Category_id ==  category);
            return View(categoryModel);
        }

        
    }

}