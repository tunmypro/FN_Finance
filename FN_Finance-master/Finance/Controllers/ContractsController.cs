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

        // GET: Contracts
        public ActionResult Index()
        {
            var contracts = db.Contracts.Include(c => c.Customers).Include(c => c.GuaranteeCustomers).Include(c => c.License);
            return View(contracts.ToList());
        }

        // GET: Contracts/Details/5
        public ActionResult Details(string id)
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
                decimal? permonth = GetMonthDifference(contracts.Date_Start.Value, contracts.Date_End.Value);
                contracts.Per_Month_Amount = (interest.LicenseTypes.InterestRate * contracts.Balance + contracts.Balance) / permonth;
                contracts.Out_Balance = contracts.Per_Month_Amount * permonth;
                contracts.TotalBalance = contracts.Out_Balance;
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

        public static int GetMonthDifference(DateTime startDate, DateTime endDate)
        {
            int monthsApart = 12 * (startDate.Year - endDate.Year) + startDate.Month - endDate.Month;
            return Math.Abs(monthsApart);
        }

        public ActionResult AutoaddCon()
        {
            var test = db.Contracts.ToList();
            Random ra = new Random();
            var data = db.Customers.ToList()[ra.Next(1, db.Customers.Count())].ID_Card_m;
            var data2 = db.GuaranteeCustomers.ToList()[ra.Next(1, db.GuaranteeCustomers.Count())].ID_Card_g;
            var data3 = db.License.ToList()[ra.Next(1, db.License.Count())].LicenseID;
            var interest = db.License.Find(data3);
            var data4 = db.Contracts.ToList()[ra.Next(1, db.Contracts.Count())].ContractID;
            decimal? permonth = GetMonthDifference(db.Contracts.ToList()[ra.Next(1, db.Contracts.Count())].Date_Start.Value, db.Contracts.ToList()[ra.Next(1, db.Contracts.Count())].Date_End.Value);
            decimal? bala = ra.Next(1000, 100000);
            if (bala == 0 || permonth == 0)
            {
                return RedirectToAction(nameof(Index));
            }
            decimal? _Per_Month = (interest.LicenseTypes.InterestRate * bala + bala) / permonth;
            List<Contracts> _cont = new List<Contracts>();
            foreach (var item in test)
            {
                _cont.Add(new Contracts
                {
                    ContractID = data.Substring(8, 5) + data2.Substring(8, 5),
                    LicenseID = data3,
                    ID_Card_m = data,
                    ID_Card_g = data2,
                    Date_Start = DateTime.Now.AddDays(ra.Next(-90, 0)),
                    Date_End = DateTime.Now.AddDays(ra.Next(1, 700)),
                    Date_Last = DateTime.Now.AddDays(ra.Next(-60, 0)),
                    Balance = bala,
                    Per_Month_Amount = _Per_Month,
                    TotalBalance = bala + (bala * interest.LicenseTypes.InterestRate),
                    Out_Balance = bala
                });
                db.Contracts.AddRange(_cont);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }
        // GET: Contracts/Edit/5
        public ActionResult Edit(string id)
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
            ViewBag.ID_Card_m = new SelectList(db.Customers, "ID_Card_m", "Name_m", contracts.ID_Card_m);
            ViewBag.ID_Card_g = new SelectList(db.GuaranteeCustomers, "ID_Card_g", "Name_g", contracts.ID_Card_g);
            ViewBag.LicenseID = new SelectList(db.License, "LicenseID", "LicensePlate", contracts.LicenseID);
            return View(contracts);
        }

        // POST: Contracts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ContractID,LicenseID,ID_Card_m,ID_Card_g,Date_Start,Date_End,Date_Last,Balance,TotalBalance,Out_Balance,Per_Month_Amount")] Contracts contracts)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contracts).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Card_m = new SelectList(db.Customers, "ID_Card_m", "Name_m", contracts.ID_Card_m);
            ViewBag.ID_Card_g = new SelectList(db.GuaranteeCustomers, "ID_Card_g", "Name_g", contracts.ID_Card_g);
            ViewBag.LicenseID = new SelectList(db.License, "LicenseID", "LicensePlate", contracts.LicenseID);
            return View(contracts);
        }

        // GET: Contracts/Delete/5
        public ActionResult Delete(string id)
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

        // POST: Contracts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
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
