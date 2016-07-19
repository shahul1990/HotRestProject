using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using Restaurant.Repository;
using Restaurant.Models;

namespace Restaurant.Controllers
{
    public class CartController : Controller
    {
        RestaurantDBEntities restdb = new RestaurantDBEntities();
        private IProductRepository iProductRepository = new ProductRepository();
        private ICategoryRepository iCategoryRepository = new CategoryRepository();

        // GET: /Cart/
        public ActionResult OrderOnline()
        {
            return View("OrderOnline");
        }

        public ActionResult OrderOnlineCopy()
        {
            ViewBag.LatestProd = iProductRepository.LatestProd(100);
            return View();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            ViewBag.LatestProd = iProductRepository.find(id);
            ViewBag.RelatedProd = iProductRepository.RelatedProd(iProductRepository.find(id), 6);
            return View("Details");
        }

        public int AddCart(int ItemId)
        {
            //string username = Session["username"].ToString();
            Cart objcart = new Cart()
            {
               ItemId = ItemId
            };
            restdb.Carts.Add(objcart);
            restdb.SaveChanges();
            int count = restdb.Carts.Count();
            return count;
        }

        public PartialViewResult GetCartItems()
        {
            //string username = Session["username"].ToString();
            var sum = 0;
            var GetItemsId = restdb.Carts.Select(u => u.ItemId).ToList();
            var GetCartItem = from itemList in restdb.ItemLists where GetItemsId.Contains(itemList.id) select itemList;
            foreach (var totalsum in GetCartItem)
            {
                sum = sum + totalsum.Price;
                
            }
            ViewBag.Total = sum;
            return PartialView("_cartItem", GetCartItem);

        }
    }
}