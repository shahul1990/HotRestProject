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

        public class ProductsModel
        {
            public ProductsModel()
            {
                products = new List<ItemList>();
                categories = new List<SelectListItem>();
            }

            public List<ItemList> products { get; set; }
            public List<SelectListItem> categories { get; set; }

            public int CategoryID { get; set; }

        }


        // GET: /Menu/
        public ActionResult Index()
        {
            var categories = db.ItemCategories.ToList();
            return View(categories);
        }

        public ActionResult Browse(int category)
        {
            var categoryModel = db.ItemLists.Include("ItemCategory").All(c=>c.Category_id ==  category);
            return View(categoryModel);
        }

        
        
    }

}