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
    public class LicenseTypesController : Controller
    {
        private Finance5917Entities1 db = new Finance5917Entities1();

        // GET: LicenseTypes
        public ActionResult Index()
        {
            return View(db.LicenseTypes.ToList());
        }

        // GET: LicenseTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LicenseTypes licenseTypes = db.LicenseTypes.Find(id);
            if (licenseTypes == null)
            {
                return HttpNotFound();
            }
            return View(licenseTypes);
        }

        // GET: LicenseTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LicenseTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LicenseType,InterestName,InterestRate")] LicenseTypes licenseTypes)
        {
            if (ModelState.IsValid)
            {
                db.LicenseTypes.Add(licenseTypes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(licenseTypes);
        }

        // GET: LicenseTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LicenseTypes licenseTypes = db.LicenseTypes.Find(id);
            if (licenseTypes == null)
            {
                return HttpNotFound();
            }
            return View(licenseTypes);
        }

        // POST: LicenseTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LicenseType,InterestName,InterestRate")] LicenseTypes licenseTypes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(licenseTypes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(licenseTypes);
        }

        // GET: LicenseTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LicenseTypes licenseTypes = db.LicenseTypes.Find(id);
            if (licenseTypes == null)
            {
                return HttpNotFound();
            }
            return View(licenseTypes);
        }

        // POST: LicenseTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LicenseTypes licenseTypes = db.LicenseTypes.Find(id);
            db.LicenseTypes.Remove(licenseTypes);
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
