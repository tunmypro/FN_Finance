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
    public partial class WebForm2 : System.Web.UI.Page
    {
        private readonly Finance5917Entities1 db = new Finance5917Entities1();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                List<Finance.Models.Contracts> view = null;
                using (Finance.Models.Finance5917Entities1 dc = new Finance.Models.Finance5917Entities1())
                {
                    view = dc.Contracts.OrderBy(a => a.Date_Start).ToList();
                    ReportViewer2.LocalReport.ReportPath = Server.MapPath("~/Report/Group.rdlc");
                    ReportViewer2.LocalReport.DataSources.Clear();
                    ReportDataSource rdc = new ReportDataSource("DataSet1", view);
                    ReportViewer2.LocalReport.DataSources.Add(rdc);
                    ReportViewer2.LocalReport.Refresh();
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            {
                var t1 = DropDownList1.SelectedValue;
                var t2 = TextBox1.Text;

                var data = db.MoneyView.OrderBy(p => p.Date_Start).ToList(); // Read data from file

                //if (!String.IsNullOrEmpty(t1) && !String.IsNullOrEmpty(t2)) //เลือกทั้งสองอย่าง
                //{
                //    var s1 = Convert.ToInt32(t1);
                //    data = db.MoneyView.
                //        Where(p => p.SectionID == s1 && p.AccOpenDate.Contains(t2)).ToList(); // Read data from file
                //}
                //else
                if (!String.IsNullOrEmpty(t2)) // เลือกสาขาอย่างเดียว
                {
                    var s1 = Convert.ToString(t2);
                    data = db.MoneyView.
                        Where(p => p.Date_Start.Value.ToShortDateString().Contains(s1)).ToList(); // Read data from file
                }

                var rd = new ReportDataSource("DataSet1", data); // binding datatable
                ReportViewer2.LocalReport.ReportPath = Server.MapPath("~/Report/Group.rdlc");
                ReportViewer2.LocalReport.DataSources.Clear();
                ReportViewer2.LocalReport.DataSources.Add(rd);
            }
        }
    }
}