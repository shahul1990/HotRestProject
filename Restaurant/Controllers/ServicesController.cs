using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Restaurant.Models;

namespace Restaurant.Controllers
{
    public class ServicesController : Controller
    {
        private RestaurantDBEntities db = new RestaurantDBEntities();

        public ActionResult Dining()
        {
            return View();
        }

        public ActionResult PartyHall()
        {
            //  ViewBag.Message = "PartyHall";

            return View();
        }

        public ActionResult Catering()
        {
            //ViewBag.Message = "Catering";

            return View();
        }

       
    }
}