using Finance.Models;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Finance.Report
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private Finance5917Entities1 db = new Finance5917Entities1();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var data = db.View_Customers.ToList();
            data = data.Where(x => x.ID_Card_m == search.Text).ToList();
            if (data != null)
            {
                var rd = new ReportDataSource("DataSet1", data);
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Report/Customer.rdlc");
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(rd);
            }
            //data = data.Where(x => x.ID_Card_g == search.Text).ToList();
            //if (data != null)
            //{
            //    var rd = new ReportDataSource("DataSet1", data);
            //    ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Report/Customer.rdlc");
            //    ReportViewer1.LocalReport.DataSources.Clear();
            //    ReportViewer1.LocalReport.DataSources.Add(rd);
            //}
        }
    }
}