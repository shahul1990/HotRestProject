﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Restaurant.Models;
using System.Data.Entity.Infrastructure;



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


        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemList itemlist = await db.ItemLists.FindAsync(id);
            if (itemlist == null)
            {
                return HttpNotFound();
            }
            return View(itemlist);
        }












       // // GET: /Product/Details/5
       // public ActionResult Details(int? id)
       //// public async Task<ActionResult> Details(int? id)
       // {
       //     if (id == null)
       //     {
       //         return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
       //     }
       //     //ItemList itemlist = await db.ItemLists.FindAsync(id);
       //     //if (itemlist == null)
       //     //{
       //     //    return HttpNotFound();
       //     //}
       //     //return View(itemlist);
       //     ItemList itemlist = db.ItemLists.Single(x => x.id == id);
       //     if (itemlist == null)
       //     {
       //         return HttpNotFound();
       //     }
       //     return View(itemlist);
       // }

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
        public ActionResult Create([Bind(Include = "id,Name,Description,Price,Image,CreatedDate,ModifiedDate,Quantity,Category_id")] ItemList itemlist, HttpPostedFileBase upload)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (upload != null)
                    {
                        string pic = System.IO.Path.GetFileName(upload.FileName);
                        string path = System.IO.Path.Combine(Server.MapPath("~/Content/Images/Uploads"), pic);
                        // file is uploaded
                        upload.SaveAs(path);
                        itemlist.ImagePath = Url.Content("~/Content/Images/Uploads/" + pic);
                    }
                    db.ItemLists.Add(itemlist);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (RetryLimitExceededException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists contact your Web Developer");
            }
            return View(itemlist);
        }

        // GET: /Default1/Edit/5
        public ActionResult Edit(int? id, HttpPostedFileBase upload)
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
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Name,Description,Price,CreatedDate,ModifiedDate,Quantity,Category_id,ImagePath,ImageText")] ItemList itemlist, HttpPostedFileBase upload)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (upload != null)
                    {
                        string pic = System.IO.Path.GetFileName(upload.FileName);
                        string path = System.IO.Path.Combine(Server.MapPath("~/Content/Images/Uploads"), pic);
                        // file is uploaded
                        upload.SaveAs(path);
                        itemlist.ImagePath = Url.Content("~/Content/Images/Uploads/" + pic);
                    }
                    db.Entry(itemlist).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.Category_id = new SelectList(db.ItemCategories, "id", "Name", itemlist.Category_id);
            }
            catch (RetryLimitExceededException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists contact your Web Developer");
            }
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
