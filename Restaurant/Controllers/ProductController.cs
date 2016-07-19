using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Restaurant.Models;

namespace Restaurant.Controllers
{
    public class ProductController : Controller
    {
        private RestaurantDBEntities db = new RestaurantDBEntities();

        // GET: /Product/
        public ActionResult Index()
        {
            var itemlists = db.ItemLists.Include(i => i.ItemCategory);
            return View(itemlists.ToList());
        }

        // GET: /Product/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemList itemlist = db.ItemLists.Find(id);
            if (itemlist == null)
            {
                return HttpNotFound();
            }
            return View(itemlist);
        }

        // GET: /Product/Create
        public ActionResult Create()
        {
            ViewBag.Category_id = new SelectList(db.ItemCategories, "id", "Name");
            return View();
        }

        // POST: /Product/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id,Name,Description,Price,Image,CreatedDate,ModifiedDate,Quantity,Category_id")] ItemList itemlist)
        {
            if (ModelState.IsValid)
            {
                db.ItemLists.Add(itemlist);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Category_id = new SelectList(db.ItemCategories, "id", "Name", itemlist.Category_id);
            return View(itemlist);
        }

        // GET: /Product/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemList itemlist = db.ItemLists.Find(id);
            if (itemlist == null)
            {
                return HttpNotFound();
            }
            ViewBag.Category_id = new SelectList(db.ItemCategories, "id", "Name", itemlist.Category_id);
            return View(itemlist);
        }

        // POST: /Product/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id,Name,Description,Price,Image,CreatedDate,ModifiedDate,Quantity,Category_id")] ItemList itemlist)
        {
            if (ModelState.IsValid)
            {
                db.Entry(itemlist).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Category_id = new SelectList(db.ItemCategories, "id", "Name", itemlist.Category_id);
            return View(itemlist);
        }

        // GET: /Product/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemList itemlist = db.ItemLists.Find(id);
            if (itemlist == null)
            {
                return HttpNotFound();
            }
            return View(itemlist);
        }

        // POST: /Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ItemList itemlist = db.ItemLists.Find(id);
            db.ItemLists.Remove(itemlist);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
