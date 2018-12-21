using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Finance.Models;

namespace Finance.Controllers
{
    public class LicenseStatusDisplaysController : Controller
    {
        private Finance5917Entities1 db = new Finance5917Entities1();

        // GET: LicenseStatusDisplays
        public ActionResult Index()
        {
            return View(db.LicenseStatusDisplay.ToList());
        }

        // GET: LicenseStatusDisplays/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LicenseStatusDisplay licenseStatusDisplay = db.LicenseStatusDisplay.Find(id);
            if (licenseStatusDisplay == null)
            {
                return HttpNotFound();
            }
            return View(licenseStatusDisplay);
        }

        // GET: LicenseStatusDisplays/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LicenseStatusDisplays/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LicenseStatusID,LicenseStatusName")] LicenseStatusDisplay licenseStatusDisplay)
        {
            if (ModelState.IsValid)
            {
                db.LicenseStatusDisplay.Add(licenseStatusDisplay);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(licenseStatusDisplay);
        }

        // GET: LicenseStatusDisplays/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LicenseStatusDisplay licenseStatusDisplay = db.LicenseStatusDisplay.Find(id);
            if (licenseStatusDisplay == null)
            {
                return HttpNotFound();
            }
            return View(licenseStatusDisplay);
        }

        // POST: LicenseStatusDisplays/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LicenseStatusID,LicenseStatusName")] LicenseStatusDisplay licenseStatusDisplay)
        {
            if (ModelState.IsValid)
            {
                db.Entry(licenseStatusDisplay).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(licenseStatusDisplay);
        }

        // GET: LicenseStatusDisplays/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LicenseStatusDisplay licenseStatusDisplay = db.LicenseStatusDisplay.Find(id);
            if (licenseStatusDisplay == null)
            {
                return HttpNotFound();
            }
            return View(licenseStatusDisplay);
        }

        // POST: LicenseStatusDisplays/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LicenseStatusDisplay licenseStatusDisplay = db.LicenseStatusDisplay.Find(id);
            db.LicenseStatusDisplay.Remove(licenseStatusDisplay);
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
