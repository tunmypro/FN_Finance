using Finance.Models;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Globalization;
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
            if (!IsPostBack)
            {
                List<Finance.Models.MoneyView> view = null;
                using (Finance.Models.Finance5917Entities1 dc = new Finance.Models.Finance5917Entities1())
                {
                    view = dc.MoneyView.OrderBy(a => a.Date_Start).ToList();
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
            var view = db.MoneyView.ToList();
            DateTime from;
            DateTime to;
            if (this.from.Text != "" && this.to.Text != "")
            {
                from = DateTime.ParseExact(this.@from.Text, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                to = DateTime.ParseExact(this.@to.Text, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                view = view.Where(x => x.Date_Start >= from && x.Date_Start <= to).ToList();
            }
            else if (this.from.Text != "" && this.to.Text == "")
            {
                from = DateTime.ParseExact(this.@from.Text, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                view = view.Where(x => x.Date_Start >= from).ToList();
            }
            else if (this.from.Text == "" && this.to.Text != "")
            {
                to = DateTime.ParseExact(this.@to.Text, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                view = view.Where(x => x.Date_Start <= to).ToList();
            }
            var rd = new ReportDataSource("DataSet1", view);
            ReportViewer2.LocalReport.ReportPath = Server.MapPath("~/Report/Group.rdlc");
            ReportViewer2.LocalReport.DataSources.Clear();
            ReportViewer2.LocalReport.DataSources.Add(rd);
        }

        protected void from_TextChanged(object sender, EventArgs e)
        {

        }
    }
}