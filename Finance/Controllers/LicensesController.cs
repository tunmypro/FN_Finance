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
    public class LicensesController : Controller
    {
        private Finance5917Entities1 db = new Finance5917Entities1();

        public ActionResult Index()
        {
            var license = db.License.Include(l => l.LicenseStatusDisplay).Include(l => l.LicenseTypes);
            return View(license.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            License license = db.License.Find(id);
            if (license == null)
            {
                return HttpNotFound();
            }
            return View(license);
        }

        public ActionResult Create(string CusID = "")
        {
            var data = new License();
            if (!String.IsNullOrEmpty(CusID))
            {
                var d = db.License.Where(x => x.LicensePlate == CusID).FirstOrDefault();

                if (d != null)
                {
                    data.liname = d.LicenseName;
                    data.litempstatus = d.LicenseStatusDisplay.LicenseStatusName;
                    data.liid = d.LicenseID;
                }
                else
                {
                    ModelState.AddModelError("tempName", "ไม่พบทะเบียนรถ");
                }
            }
            ViewBag.LicenseStatusID = new SelectList(db.LicenseStatusDisplay, "LicenseStatusID", "LicenseStatusName");
            ViewBag.LicenseType = new SelectList(db.LicenseTypes, "LicenseType", "InterestName");
            return View(data);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(License license)
        {
            if (ModelState.IsValid)
            {
                if (license.Mypic1 != null)
                {
                    byte[] img = new byte[license.Mypic1.ContentLength];
                    license.Mypic1.InputStream.Read(img, 0, license.Mypic1.ContentLength);
                    license.Licen_img = img;
                }
                db.License.Add(license);
                db.SaveChanges();
                Session["idlicen"] = license.LicenseID;
                return RedirectToAction("Create", "Contracts",new {id=license.LicenseID });
            }
            ViewBag.LicenseStatusID = new SelectList(db.LicenseStatusDisplay, "LicenseStatusID", "LicenseStatusName", license.LicenseStatusID);
            ViewBag.LicenseType = new SelectList(db.LicenseTypes, "LicenseType", "InterestName", license.LicenseType);
            return View(license);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            License license = db.License.Find(id);
            if (license == null)
            {
                return HttpNotFound();
            }
            ViewBag.LicenseStatusID = new SelectList(db.LicenseStatusDisplay, "LicenseStatusID", "LicenseStatusName", license.LicenseStatusID);
            ViewBag.LicenseType = new SelectList(db.LicenseTypes, "LicenseType", "InterestName", license.LicenseType);
            return View(license);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(License license)
        {
            if (ModelState.IsValid)
            {
                db.Entry(license).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Create");
            }
            ViewBag.LicenseStatusID = new SelectList(db.LicenseStatusDisplay, "LicenseStatusID", "LicenseStatusName", license.LicenseStatusID);
            ViewBag.LicenseType = new SelectList(db.LicenseTypes, "LicenseType", "InterestName", license.LicenseType);
            return View(license);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            License license = db.License.Find(id);
            if (license == null)
            {
                return HttpNotFound();
            }
            return View(license);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            License license = db.License.Find(id);
            db.License.Remove(license);
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