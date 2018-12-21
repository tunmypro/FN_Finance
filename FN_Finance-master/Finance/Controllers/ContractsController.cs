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
    public class ContractsController : Controller
    {
        private Finance5917Entities1 db = new Finance5917Entities1();
        readonly ConvertDate td = new ConvertDate();

        public ActionResult Index()
        {
            var contracts = db.Contracts.Include(c => c.Customers).Include(c => c.GuaranteeCustomers).Include(c => c.License);
            return View(contracts.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contracts contracts = db.Contracts.Find(id);
            if (contracts == null)
            {
                return HttpNotFound();
            }
            return View(contracts);
        }


        public static int GetMonthDifference(DateTime startDate, DateTime endDate)
        {
            int monthsApart = 12 * (startDate.Year - endDate.Year) + startDate.Month - endDate.Month;
            return Math.Abs(monthsApart);
        }

        public ActionResult Create(int? id)
        {
            ViewBag.ID_Card_m = new SelectList(db.Customers, "ID_Card_m", "ID_Card_m");
            ViewBag.ID_Card_g = new SelectList(db.GuaranteeCustomers, "ID_Card_g", "ID_Card_g");
            ViewBag.LicenseID = new SelectList(db.License, "LicenseID", "LicensePlate");
            var data = new Contracts();
            var m = db.License.Find(id);
            if (m != null)
            {
                data.LicenseID = m.LicenseID;
                data.liname = m.LicenseName;
                return View(data);
            }
            else return RedirectToAction("Create", "Licenses");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Contracts contracts)
        {
            contracts.Date_Start = DateTime.Now;
            //contracts.Date_End = td.ThaiDate(contracts.Mydate1).AddMonths(contracts.Addmonth);
            contracts.Date_End = DateTime.Now.AddMonths(contracts.Addmonth);
            ViewBag.ID_Card_m = new SelectList(db.Customers, "ID_Card_m", "ID_Card_m", contracts.ID_Card_m);
            ViewBag.ID_Card_g = new SelectList(db.GuaranteeCustomers, "ID_Card_g", "ID_Card_g", contracts.ID_Card_g);
            ViewBag.LicenseID = new SelectList(db.License, "LicenseID", "LicensePlate", contracts.LicenseID);
            var interest = db.License.Find(contracts.LicenseID);
            contracts.ContractID = contracts.ID_Card_m.Substring(8, 5) + contracts.ID_Card_g.Substring(8, 5);
            var c = db.Contracts.Find(contracts.ContractID);
            if (c == null && contracts.Addmonth != 0)
            {
                decimal permonth = GetMonthDifference(contracts.Date_Start.Value, contracts.Date_End.Value);
                contracts.Per_Month_Amount = (interest.LicenseTypes.InterestRate * contracts.Balance + contracts.Balance) / permonth;
                contracts.Out_Balance = contracts.Per_Month_Amount*permonth;
                contracts.Date_Last = contracts.Date_Start;
                db.Contracts.Add(contracts);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("ID_Card_m", "ไม่สามารถทำรายการ");
                ModelState.AddModelError("ID_Card_g", "ไม่สามารถทำรายการ");
                return View(contracts);
            }
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contracts contracts = db.Contracts.Find(id);
            if (contracts == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Card_m = new SelectList(db.Customers, "ID_Card_m", "ID_Card_m", contracts.ID_Card_m);
            ViewBag.ID_Card_g = new SelectList(db.GuaranteeCustomers, "ID_Card_g", "ID_Card_g", contracts.ID_Card_g);
            ViewBag.LicenseID = new SelectList(db.License, "LicenseID", "LicensePlate", contracts.LicenseID);
            return View(contracts);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ContractID,LicenseID,ID_Card_m,ID_Card_g,Date_Start,Date_End,Balance,Out_Balance,Per_Month_Amount")] Contracts contracts)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contracts).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Card_m = new SelectList(db.Customers, "ID_Card_m", "ID_Card_m", contracts.ID_Card_m);
            ViewBag.ID_Card_g = new SelectList(db.GuaranteeCustomers, "ID_Card_g", "ID_Card_g", contracts.ID_Card_g);
            ViewBag.LicenseID = new SelectList(db.License, "LicenseID", "LicensePlate", contracts.LicenseID);
            return View(contracts);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contracts contracts = db.Contracts.Find(id);
            if (contracts == null)
            {
                return HttpNotFound();
            }
            return View(contracts);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Contracts contracts = db.Contracts.Find(id);
            db.Contracts.Remove(contracts);
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

