using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Restaurant.Models;

namespace Restaurant.Controllers
{
    public class HomeController : Controller
    {
        private RestaurantDBEntities db = new RestaurantDBEntities();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            //  ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            //ViewBag.Message = "Your contact page.";

            return View();
        }

        //public ActionResult Menu(int? SelectedCategory)
        //{
        //    var categories = db.ItemCategories.OrderBy(q => q.Name).ToList();
        //    ViewBag.SelectedCategories = new SelectList(categories, "Category_id",  "ItemName", SelectedCategory);
                
        //        //departments, "DepartmentID", "Name", SelectedDepartment);
        //    int categoryId = SelectedCategory.GetValueOrDefault();
        //    IQueryable<ItemList> itemlist = db.ItemLists.Where(c => !SelectedCategory.HasValue || c.Category_id == categoryId)
        //        .OrderBy(d => d.id)
        //        ;
        //    var sql = itemlist.ToString();
        //    return View(itemlist.ToList());


        //    //IQueryable<Course> courses = db.Courses
        //    //    .Where(c => !SelectedDepartment.HasValue || c.DepartmentID == departmentID)
        //    //    .OrderBy(d => d.CourseID)
        //    //    .Include(d => d.Department);
        //    //var sql = courses.ToString();
        //    //return View(courses.ToList());
        //    //return View();
        //}


        public ActionResult Menu()
        {
            //ViewBag.Message = "Your contact page.";

            return View();
        }



        //public ActionResult PartyHall()
        //{
        //    //ViewBag.Message = "Your contact page.";

        //    return View();
        //}

        //public ActionResult Dinning_Buffets()
        //{
        //    //ViewBag.Message = "Your contact page.";

        //    return View();
        //}

        //public ActionResult Catering()
        //{
        //    return View();
        //}
    }
}