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
    public partial class ContractForm : System.Web.UI.Page
    {
        private readonly Finance5917Entities1 db = new Finance5917Entities1();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Finance.Models.View_Contract> view = null;
                using (Finance.Models.Finance5917Entities1 dc = new Finance.Models.Finance5917Entities1())
                {
                    view = dc.View_Contract.OrderBy(a => a.ContractID).ToList();
                    ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Report/Contract.rdlc");
                    ReportViewer1.LocalReport.DataSources.Clear();
                    ReportDataSource rdc = new ReportDataSource("DataSet1", view);
                    ReportViewer1.LocalReport.DataSources.Add(rdc);
                    ReportViewer1.LocalReport.Refresh();
                }
            }
        }
    }
}