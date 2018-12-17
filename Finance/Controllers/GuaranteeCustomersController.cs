using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Finance.Models;

namespace Finance.Controllers
{
    public class GuaranteeCustomersController : Controller
    {
        readonly Finance5917Entities1 db = new Finance5917Entities1();
        public ActionResult Index()
        {
            var guaranteeCustomers = db.GuaranteeCustomers.Include(g => g.StatusCustomer);
            return View(guaranteeCustomers.ToList());
        }

        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GuaranteeCustomers guaranteeCustomers = db.GuaranteeCustomers.Find(id);
            if (guaranteeCustomers == null)
            {
                return HttpNotFound();
            }
            return View(guaranteeCustomers);
        }

        public ActionResult Create(string CusID = "")
        {
            ViewBag.Status_g = new SelectList(db.StatusCustomer, "StatusID", "StatusType");
            ViewBag.titleid = new SelectList(db.title, "titleid", "titlename");
            var data = new GuaranteeCustomers();
            ViewBag.ID = Session["IDCARDM"];
            Session["IDCARDM"] = null;
            if (!String.IsNullOrEmpty(CusID))
            {
                var m = db.Customers.Find(CusID);
                var g = db.GuaranteeCustomers.Find(CusID);
                if (m != null)
                {
                    Session["IDCARDM1"] = m.ID_Card_m;
                    data.tempid = m.ID_Card_m;
                    data.tempname = m.Name_m;
                    data.templname = m.Lname_m;
                    data.tempstatus = m.StatusCustomer.StatusType;
                    data.tempshow = "คนกู้";
                }
                else if (g != null)
                {
                    data.tempid = m.ID_Card_m;
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
            return View(data);
        }

        [HttpPost]
        public ActionResult Create(GuaranteeCustomers guaranteeCustomers)
        {
            ViewBag.Status_g = new SelectList(db.StatusCustomer, "StatusID", "StatusType", guaranteeCustomers.Status_g);
            ViewBag.titleid = new SelectList(db.title, "titleid", "titlename", guaranteeCustomers.titleid);
            var gid = db.GuaranteeCustomers.FirstOrDefault(x => x.ID_Card_g == guaranteeCustomers.ID_Card_g);
            if (!CheckIDCard.IsValidCheckPersonId(guaranteeCustomers.ID_Card_g))
            {
                ModelState.AddModelError("ID_Card_g", "บัตรประชาชนไม่ถูกต้อง");
                return View(guaranteeCustomers);
            }
            if (ModelState.IsValid)
            {
                if (gid != null)
                {
                    ModelState.AddModelError("ID_Card_g", "บัตรประชาชนในระบบแล้ว");
                    return View(guaranteeCustomers);
                }
                if (guaranteeCustomers.Mypic1 != null)
                {
                    byte[] img = new byte[guaranteeCustomers.Mypic1.ContentLength];
                    guaranteeCustomers.Mypic1.InputStream.Read(img, 0, guaranteeCustomers.Mypic1.ContentLength);
                    guaranteeCustomers.Image_g = img;
                }
                if (guaranteeCustomers.Mypic2 != null)
                {
                    byte[] ID_img = new byte[guaranteeCustomers.Mypic2.ContentLength];
                    guaranteeCustomers.Mypic2.InputStream.Read(ID_img, 0, guaranteeCustomers.Mypic2.ContentLength);
                    guaranteeCustomers.ID_img_g = ID_img;
                }
                Session["IDCARDG1"] = guaranteeCustomers.ID_Card_g;
                db.GuaranteeCustomers.Add(guaranteeCustomers);
                db.SaveChanges();
                return RedirectToAction("Create", "Licenses");
            }
            return View(guaranteeCustomers);
        }

        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GuaranteeCustomers guaranteeCustomers = db.GuaranteeCustomers.Find(id);
            if (guaranteeCustomers == null)
            {
                return HttpNotFound();
            }
            ViewBag.Status_g = new SelectList(db.StatusCustomer, "StatusID", "StatusType", guaranteeCustomers.Status_g);
            ViewBag.titleid = new SelectList(db.title, "titleid", "titlename", guaranteeCustomers.titleid);
            return View(guaranteeCustomers);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Card_g,Name_g,Lname_g,Address_g,Career_g,Salary_g,Status_g")] GuaranteeCustomers guaranteeCustomers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(guaranteeCustomers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Status_g = new SelectList(db.StatusCustomer, "StatusID", "StatusType", guaranteeCustomers.Status_g);
            ViewBag.titleid = new SelectList(db.title, "titleid", "titlename", guaranteeCustomers.titleid);
            return View(guaranteeCustomers);
        }

        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GuaranteeCustomers guaranteeCustomers = db.GuaranteeCustomers.Find(id);
            if (guaranteeCustomers == null)
            {
                return HttpNotFound();
            }
            return View(guaranteeCustomers);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            GuaranteeCustomers guaranteeCustomers = db.GuaranteeCustomers.Find(id);
            db.GuaranteeCustomers.Remove(guaranteeCustomers);
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