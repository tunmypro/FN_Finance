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
    public class User_FinanceController : Controller
    {
        private Finance5917Entities1 db = new Finance5917Entities1();

        // GET: User_Finance
        public ActionResult Index()
        {
            var user_Finance = db.User_Finance.Include(u => u.StatusUser1);
            return View(user_Finance.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User_Finance user_Finance = db.User_Finance.Find(id);
            if (user_Finance == null)
            {
                return HttpNotFound();
            }
            return View(user_Finance);
        }

        // GET: User_Finance/Create
        public ActionResult Create()
        {
            ViewBag.StatusUser = new SelectList(db.StatusUser, "StatusUser1", "StatusName");
            return View();
        }

        // POST: User_Finance/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserID,Username,Password,Name,Lname,StatusUser")] User_Finance user_Finance)
        {
            if (ModelState.IsValid)
            {
                db.User_Finance.Add(user_Finance);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StatusUser = new SelectList(db.StatusUser, "StatusUser1", "StatusName", user_Finance.StatusUser);
            return View(user_Finance);
        }

        // GET: User_Finance/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User_Finance user_Finance = db.User_Finance.Find(id);
            if (user_Finance == null)
            {
                return HttpNotFound();
            }
            ViewBag.StatusUser = new SelectList(db.StatusUser, "StatusUser1", "StatusName", user_Finance.StatusUser);
            return View(user_Finance);
        }

        // POST: User_Finance/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserID,Username,Password,Name,Lname,StatusUser")] User_Finance user_Finance)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user_Finance).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StatusUser = new SelectList(db.StatusUser, "StatusUser1", "StatusName", user_Finance.StatusUser);
            return View(user_Finance);
        }

        // GET: User_Finance/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User_Finance user_Finance = db.User_Finance.Find(id);
            if (user_Finance == null)
            {
                return HttpNotFound();
            }
            return View(user_Finance);
        }

        // POST: User_Finance/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User_Finance user_Finance = db.User_Finance.Find(id);
            db.User_Finance.Remove(user_Finance);
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
