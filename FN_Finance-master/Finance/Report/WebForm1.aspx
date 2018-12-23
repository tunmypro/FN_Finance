<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Finance.Report.WebForm1" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=15.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ReportView</title>
    <script runat="server">
        void Page_Load(object sender,EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Finance.Models.Contracts> view = null;
                using (Finance.Models.Finance5917Entities1 dc = new Finance.Models.Finance5917Entities1())
                {
                    view = dc.Contracts.OrderBy(a => a.Date_Start).ToList();
                    ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Report/eptMoney.rdlc");
                    ReportViewer1.LocalReport.DataSources.Clear();
                    ReportDataSource rdc = new ReportDataSource("DataSet1",view);
                    ReportViewer1.LocalReport.DataSources.Add(rdc);
                    ReportViewer1.LocalReport.Refresh();
                }
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <rsweb:ReportViewer ID="ReportViewer1" runat="server" AsyncRendering="false" SizeToReportContent="true">
            </rsweb:ReportViewer>
        </div>
    </form>
</body>
</html>
