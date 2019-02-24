using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Finance.Models;

namespace Finance.Controllers
{
    public class PaymentsController : Controller
    {
        private Finance5917Entities1 db = new Finance5917Entities1();

        // GET: Payments
        public ActionResult Index()
        {
            ViewBag.Change = TempData["Change"];
            var payments = db.Payments.Include(p => p.Contracts).Include(p => p.Customers);
            return View(payments.ToList());
        }

        // GET: Payments/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Payments payments = db.Payments.Find(id);
            if (payments == null)
            {
                return HttpNotFound();
            }
            return View(payments);
        }

        public static int GetMonthDifference(DateTime startDate, DateTime endDate)
        {
            int monthsApart = 12 * (startDate.Year - endDate.Year) + startDate.Month - endDate.Month;
            return Math.Abs(monthsApart);
        }

        // GET: Payments/Create
        public ActionResult Create(string ID)
        {
            var data = new Payments();
            var m = db.Contracts.Find(ID);
            if (m != null)
            {
                data.tempid = m.ContractID;
                data.tempname = m.ID_Card_m;
                data.bala = m.Balance.ToString();
                data.outbala = m.Out_Balance.ToString();
                data.chabala = m.Per_Month_Amount.ToString();
                if (m.Date_Last != null)
                {
                    decimal permonth = GetMonthDifference(m.Date_Last.Value, DateTime.Now);
                    data.bdate = (permonth * m.Per_Month_Amount).ToString();
                }
                else data.bdate = "0";
            }
            else return RedirectToAction("Index", "Searching");
            ViewBag.Status_m = new SelectList(db.StatusCustomer, "StatusID", "StatusType");
            ViewBag.ContractID = new SelectList(db.Contracts, "ContractID", "ContractID");
            ViewBag.ID_Card_m = new SelectList(db.Customers, "ID_Card_m", "ID_Card_m");
            return View(data);
        }

        // POST: Payments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Payments payments)
        {
            var data = new Payments();
            ViewBag.ContractID = new SelectList(db.Contracts, "ContractID", "ContractID", payments.ContractID);
            ViewBag.ID_Card_m = new SelectList(db.Customers, "ID_Card_m", "ID_Card_m", payments.ID_Card_m);
            string dateString = DateTime.Now.ToString("MM/dd/yyyy");
            var count = db.Payments.Include(p => p.Contracts).Include(p => p.Customers);
            int no = count.Count() + 1000;
            var b = db.Contracts.Find(payments.tempid);
            decimal c;
            decimal d;
            decimal.TryParse(payments.bdate, out c);
            decimal.TryParse(payments.tempshow, out d);
            if (payments.Payment_Money <= c)
            {
                ModelState.AddModelError("Payment_Money", "ยอดเงินไม่ถูกต้อง");
                return View(payments);
            }
            if (payments.Payment_Money > d)
            {
                ModelState.AddModelError("tempshow", "ยอดเงินไม่ถูกต้อง");
                return View(payments);
            }
            payments.PaymentID = dateString.Replace("/", "") + no.ToString();
            payments.ID_Card_m = payments.tempname;
            payments.ContractID = payments.tempid;
            payments.NameUser = Session["User"].ToString();
            payments.PaymentDate = DateTime.Now;
            b.Out_Balance -= payments.Payment_Money;
            b.Date_Last = DateTime.Now;
            db.Payments.Add(payments);
            db.SaveChanges();
            TempData["Change"] = (d - payments.Payment_Money).ToString();
            return RedirectToAction("Index");
        }

        // GET: Payments/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Payments payments = db.Payments.Find(id);
            if (payments == null)
            {
                return HttpNotFound();
            }
            ViewBag.ContractID = new SelectList(db.Contracts, "ContractID", "ContractID", payments.ContractID);
            ViewBag.ID_Card_m = new SelectList(db.Customers, "ID_Card_m", "ID_Card_m", payments.ID_Card_m);
            return View(payments);
        }

        // POST: Payments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Payments payments)
        {
            if (ModelState.IsValid)
            {
                db.Entry(payments).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ContractID = new SelectList(db.Contracts, "ContractID", "ContractID", payments.ContractID);
            ViewBag.ID_Card_m = new SelectList(db.Customers, "ID_Card_m", "ID_Card_m", payments.ID_Card_m);
            return View(payments);
        }

        // GET: Payments/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Payments payments = db.Payments.Find(id);
            if (payments == null)
            {
                return HttpNotFound();
            }
            return View(payments);
        }

        // POST: Payments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Payments payments = db.Payments.Find(id);
            db.Payments.Remove(payments);
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
