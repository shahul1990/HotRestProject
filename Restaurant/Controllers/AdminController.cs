using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Restaurant.Models;
using System.Web.Security;
using WebMatrix.WebData;
using Restaurant.Filters;


namespace Restaurant.Controllers
{
    //[Authorize]
    //[InitializeSimpleMembership]
    public class AdminController : Controller
    {
        //
        // GET: /Admin/
        public ActionResult Index()
        {
            return View();
        }

        //[AllowAnonymous]

        public ActionResult Login() 
        {
            //ViewBag.ReturnUrl = returnUrl;
            return View();
        }


        [HttpPost]
        //[AllowAnonymous]
        //[ValidateAntiForgeryToken]
        public ActionResult Login(Admin user)
        {
            using (RestaurantDBEntities db = new RestaurantDBEntities())
            {
                var usr = db.Admins.Single(u => u.UserName == user.UserName && u.Password == user.Password);
                if(usr!=null)
                {
                    Session["UserName"] = usr.UserName.ToString();
                    return RedirectToAction("LoggedIn");
                }
                else
                {
                    ModelState.AddModelError("", "Username or Password is wrong...");
                }
            }
            return View();
        }

        public ActionResult LoggedIn()
        {
            if (Session["UserName"] != null) 
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
        

        //[HttpPost]
        ////[AllowAnonymous]
        ////[ValidateAntiForgeryToken]
        //public ActionResult Login(LoginModel user)
        //{
        //    using (RestaurantDBEntities db = new RestaurantDBEntities())
        //    {
        //        try
        //        {
        //            if (ModelState.IsValid)
        //            {
        //                LoginModel us = db.LoginModels.SingleOrDefault(m => m.UserName == user.UserName);
        //                //LoginModel us = db.LoginModels.SingleOrDefault(m => m.UserName == user.UserName);
        //                if (us != null)
        //                {
        //                    if (us.Password == user.Password)
        //                    {
        //                        FormsAuthentication.SetAuthCookie(user.UserName, false);
        //                        return RedirectToAction("Index");
        //                    }
        //                    ModelState.AddModelError("", "Invalid Username or Password");
        //                    return View();
        //                }
        //                throw new ArgumentException("User doesn't exists");
        //            }
        //        }
        //        catch (ArgumentException e)
        //        {
        //            ModelState.AddModelError("", e.Message);
        //            return View();
        //        }
        //    }
        //    return View();
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            WebSecurity.Logout();
            return RedirectToAction("Index", "Home");
        }

    }
}