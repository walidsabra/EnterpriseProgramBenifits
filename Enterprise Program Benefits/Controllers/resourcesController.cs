using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Enterprise_Program_Benefits.Models;

namespace Enterprise_Program_Benefits.Controllers
{
    public class resourcesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: resources
        public ActionResult Index(string searchString)
        {
            var res = from s in db.resources select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                res = res.Where(r => r.GEO.Contains(searchString));
            }
            return View(res);
        }

        // GET: resources/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            resource resource = db.resources.Find(id);
            if (resource == null)
            {
                return HttpNotFound();
            }
            return View(resource);
        }

        // GET: resources/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: resources/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "resourceId,Name,Role,phone,email,address,reponsibilities,GEO,Team")] resource resource)
        {
            if (ModelState.IsValid)
            {
                db.resources.Add(resource);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(resource);
        }

        // GET: resources/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            resource resource = db.resources.Find(id);
            if (resource == null)
            {
                return HttpNotFound();
            }
            return View(resource);
        }

        // POST: resources/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "resourceId,Name,Role,phone,email,address,reponsibilities,GEO,Team")] resource resource)
        {
            if (ModelState.IsValid)
            {
                db.Entry(resource).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(resource);
        }

        // GET: resources/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            resource resource = db.resources.Find(id);
            if (resource == null)
            {
                return HttpNotFound();
            }
            return View(resource);
        }

        // POST: resources/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            resource resource = db.resources.Find(id);
            db.resources.Remove(resource);
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
