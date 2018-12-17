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
    public class CustomersController : Controller
    {
        readonly Finance5917Entities1 db = new Finance5917Entities1();

        public ActionResult Index()
        {
            var customers = db.Customers.Include(c => c.StatusCustomer).Include(c => c.title);
            return View(customers.ToList());
        }

        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customers customers = db.Customers.Find(id);
            if (customers == null)
            {
                return HttpNotFound();
            }
            return View(customers);
        }

        public ActionResult Create(string CusID = "")
        {
            var data = new Customers();
            if (!String.IsNullOrEmpty(CusID))
            {
                var m = db.Customers.Find(CusID);
                var g = db.GuaranteeCustomers.Find(CusID);
                if (m != null)
                {
                    data.tempid = m.ID_Card_m;
                    data.tempname = m.Name_m;
                    data.templname = m.Lname_m;
                    data.tempstatus = m.StatusCustomer.StatusType;
                    data.tempshow = "คนกู้";
                }
                else if (g != null)
                {
                    data.tempid = g.ID_Card_g;
                    data.tempname = g.Name_g;
                    data.templname = g.Lname_g;
                    data.tempstatus = g.StatusCustomer.StatusType;
                    data.tempshow = "คนค้ำ";
                }
                else
                {
                    ModelState.AddModelError("tempName", "ไม่พบชื่อลูกค้าค่ะ");
                }
            }
            ViewBag.Status_m = new SelectList(db.StatusCustomer, "StatusID", "StatusType");
            ViewBag.titleid = new SelectList(db.title, "titleid", "titlename");
            return View(data);
        }

        [HttpPost]
        public ActionResult Create(Customers customers)
        {
            ViewBag.Status_m = new SelectList(db.StatusCustomer, "StatusID", "StatusType", customers.Status_m);
            ViewBag.titleid = new SelectList(db.title, "titleid", "titlename", customers.titleid);
            var cid = db.Customers.FirstOrDefault(x => x.ID_Card_m == customers.ID_Card_m);
            if (!CheckIDCard.IsValidCheckPersonId(customers.ID_Card_m))
            {
                ModelState.AddModelError("ID_Card_m", "บัตรประชาชนไม่ถูกต้อง");
                return View(customers);

            }
            if (ModelState.IsValid)
            {
                if (cid != null)
                {
                    ModelState.AddModelError("ID_Card_m", "บัตรประชาชนในระบบแล้ว");
                    return View(customers);
                }
                if (customers.Mypic1 != null)
                {
                    byte[] img = new byte[customers.Mypic1.ContentLength];
                    customers.Mypic1.InputStream.Read(img, 0, customers.Mypic1.ContentLength);
                    customers.Image_m = img;
                }
                if (customers.Mypic2 != null)
                {
                    byte[] ID_img = new byte[customers.Mypic2.ContentLength];
                    customers.Mypic2.InputStream.Read(ID_img, 0, customers.Mypic2.ContentLength);
                    customers.ID_img_m = ID_img;
                }
                Session["IDCARDM"] = customers.ID_Card_m;
                db.Customers.Add(customers);
                db.SaveChanges();
                return RedirectToAction("Create", "GuaranteeCustomers");
            }
            return View(customers);
        }

        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customers customers = db.Customers.Find(id);
            if (customers == null)
            {
                return HttpNotFound();
            }
            ViewBag.titleid = new SelectList(db.title, "titleid", "titlename", customers.titleid);
            ViewBag.Status_m = new SelectList(db.StatusCustomer, "StatusID", "StatusType", customers.Status_m);
            return View(customers);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Customers customers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.titleid = new SelectList(db.title, "titleid", "titlename", customers.titleid);
            ViewBag.Status_m = new SelectList(db.StatusCustomer, "StatusID", "StatusType", customers.Status_m);
            return View(customers);
        }

        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customers customers = db.Customers.Find(id);
            if (customers == null)
            {
                return HttpNotFound();
            }
            return View(customers);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Customers customers = db.Customers.Find(id);
            db.Customers.Remove(customers);
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