using CrystalDecisions.CrystalReports.Engine;
using Finance.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Finance.Controllers
{
    public class ReportController  : Controller
    {
        Finance5917Entities1 db = new Finance5917Entities1();
        // GET: Report
        public ActionResult MoneyReport()
        {
            return View(db.MoneyView.ToList());
        }

        public ActionResult exportReport()
        {
            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/Report"), "CrystalReport.rpt"));
            rd.SetDataSource(db.MoneyView.Select(x => new {
                Balance = x.Balance,
                Per_Month_Amount = x.Per_Month_Amount,
                Out_Balance = x.Out_Balance,
                Payment_Money = x.Payment_Money,
                PaymentDate = x.PaymentDate
            }).ToList());
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();
            try
            {
                Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                stream.Seek(0,SeekOrigin.Begin);
                return File(stream, "application/pdf", "Money.pdf");
            }
            catch
            {
                throw;
            }
        }

        public ActionResult viewReport()
        {
            return Redirect("~/Report/WebForm1.aspx");
        }
    }
}