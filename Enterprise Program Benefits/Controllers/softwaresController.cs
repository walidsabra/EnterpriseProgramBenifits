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
    public class softwaresController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: softwares
        public ActionResult Index(string SearchValue)
        {
            IQueryable<software> lstProdcut, lstName, lstDesc, lstPlatform, lstLicense, lstToken, lstPFamily;
            if (!string.IsNullOrEmpty(SearchValue))
            {
                lstName = db.softwares.Where(ex => ex.SoftwareName.Contains(SearchValue)).AsQueryable();
                lstDesc = db.softwares.Where(ex => ex.Description.Contains(SearchValue)).AsQueryable();
                lstPlatform = db.softwares.Where(ex => ex.Platform.Contains(SearchValue)).AsQueryable();
                lstLicense = db.softwares.Where(ex => ex.LicenseType.Contains(SearchValue)).AsQueryable();
                lstToken = db.softwares.Where(ex => ex.TokenRate.Contains(SearchValue)).AsQueryable();
                lstPFamily = db.softwares.Where(ex => ex.ProductFamily.Contains(SearchValue)).AsQueryable();


                lstProdcut = lstName.Concat(lstDesc).Concat(lstPlatform).Concat(lstLicense).Concat(lstToken).Concat(lstPFamily).Distinct().AsQueryable();
            }
            else
            {
                lstProdcut = db.softwares.AsQueryable();
            }
            return View(lstProdcut.ToList());
        }

        // GET: softwares/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            software software = db.softwares.Find(id);
            if (software == null)
            {
                return HttpNotFound();
            }
            return View(software);
        }

        // GET: softwares/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: softwares/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SoftwareId,SoftwareName,Description,TokenRate,LearnIt,ProductFamily,Platform,LicenseType,ImagePath")] software software)
        {
            if (ModelState.IsValid)
            {
                db.softwares.Add(software);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(software);
        }

        // GET: softwares/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            software software = db.softwares.Find(id);
            if (software == null)
            {
                return HttpNotFound();
            }
            return View(software);
        }

        // POST: softwares/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SoftwareId,SoftwareName,Description,TokenRate,LearnIt,ProductFamily,Platform,LicenseType,ImagePath")] software software)
        {
            if (ModelState.IsValid)
            {
                db.Entry(software).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(software);
        }

        // GET: softwares/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            software software = db.softwares.Find(id);
            if (software == null)
            {
                return HttpNotFound();
            }
            return View(software);
        }

        // POST: softwares/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            software software = db.softwares.Find(id);
            db.softwares.Remove(software);
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
