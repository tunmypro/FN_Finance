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

        public ActionResult AutoaddGua()
        {
            var data = db.GuaranteeCustomers.ToList();
            List<GuaranteeCustomers> _guaranteeCustomers = new List<GuaranteeCustomers>();

            foreach (var item in data)
            {
                Random random = new Random();
                string idran = random.Next(100000000, 999999999).ToString();
                string idran2 = random.Next(1000, 9999).ToString();
                string idnew = idran + idran2;
                _guaranteeCustomers.Add(new GuaranteeCustomers { ID_Card_g = idnew, titleid = item.titleid, Name_g = item.Name_g, Lname_g = item.Lname_g, tel = item.tel, Address_g = item.Address_g, District_g = item.District_g, Amphur_g = item.Amphur_g, Province_g = item.Province_g, Zipcode_g = item.Zipcode_g, Career_g = item.Career_g, Salary_g = item.Salary_g, Status_g = item.Status_g, Image_g = item.Image_g, ID_img_g = item.ID_img_g });
                db.GuaranteeCustomers.AddRange(_guaranteeCustomers);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));

        }

        public ActionResult AutoaddCus()
        {
            var data = db.Customers.ToList();
            List<Customers> _Customers = new List<Customers>();

            foreach (var item in data)
            {
                Random random = new Random();
                string idran = random.Next(100000000, 999999999).ToString();
                string idran2 = random.Next(1000, 9999).ToString();
                string idnew = idran + idran2;
                _Customers.Add(new Customers { ID_Card_m = idnew, titleid = item.titleid, Name_m = item.Name_m, Lname_m = item.Lname_m, tel = item.tel, Address_m = item.Address_m, District_m = item.District_m, Amphur_m = item.Amphur_m, Province_m = item.Province_m, Zipcode_m = item.Zipcode_m, Career_m = item.Career_m, Salary_m = item.Salary_m, Status_m = item.Status_m, Image_m = item.Image_m, ID_img_m = item.ID_img_m });
                db.Customers.AddRange(_Customers);
                db.SaveChanges();
                return RedirectToAction("Index", "Customers");
            }
            return RedirectToAction("Index","Customers");
        }

        public ActionResult AutoaddLic()
        {
            var data = db.License.ToList();
            List<License> _License = new List<License>();

            foreach (var item in data)
            {
                Random random = new Random();
                string idran = random.Next(1000, 99999).ToString();
                _License.Add(new License { LicensePlate = idran, LicenseName = item.LicenseName, KeepAddressID = item.KeepAddressID, District_l = item.District_l, Amphur_l = item.Amphur_l, Province_l = item.Province_l, Zipcode_l = item.Zipcode_l, LicenseType = item.LicenseType,LicenseStatusID=item.LicenseStatusID,Licen_img=item.Licen_img });
                db.License.AddRange(_License);
                db.SaveChanges();
                return RedirectToAction("Index", "Licenses");
            }
            return RedirectToAction("Index","Licenses");
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
        public ActionResult Edit(GuaranteeCustomers guaranteeCustomers)
        {
            ViewBag.Status_g = new SelectList(db.StatusCustomer, "StatusID", "StatusType", guaranteeCustomers.Status_g);
            ViewBag.titleid = new SelectList(db.title, "titleid", "titlename", guaranteeCustomers.titleid);
            if (ModelState.IsValid)
            {
                if (guaranteeCustomers.Mypic1 != null)
                {
                    byte[] img = new byte[guaranteeCustomers.Mypic1.ContentLength];
                    guaranteeCustomers.Mypic1.InputStream.Read(img, 0, guaranteeCustomers.Mypic1.ContentLength);
                    guaranteeCustomers.Image_g = img;
                }
                else
                {
                    ModelState.AddModelError("Image_g", "กรุณาใส่รูป");
                    return View(guaranteeCustomers);
                }
                if (guaranteeCustomers.Mypic2 != null)
                {
                    byte[] ID_img = new byte[guaranteeCustomers.Mypic2.ContentLength];
                    guaranteeCustomers.Mypic2.InputStream.Read(ID_img, 0, guaranteeCustomers.Mypic2.ContentLength);
                    guaranteeCustomers.ID_img_g = ID_img;
                }
                else
                {
                    ModelState.AddModelError("ID_img_g", "กรุณาใส่รูป");
                    return View(guaranteeCustomers);
                }
                db.Entry(guaranteeCustomers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
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