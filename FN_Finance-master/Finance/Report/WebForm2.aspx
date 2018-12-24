<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="Finance.Report.WebForm2" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=15.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../Scripts/bootstrap.js"></script>
    <link href="../Content/bootstrap.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>
            <br />
            <div style="float: left" class="col-xs-6 col-sm-3">
                <asp:DropDownList ID="DropDownList1" runat="server" class="form-control">
                </asp:DropDownList>
            </div>

            <div style="float: left" class="col-xs-6 col-sm-3">
                <asp:TextBox ID="TextBox1" runat="server" placeholder="กรุณาป้อนปี" class="form-control"></asp:TextBox>
            </div>

            <div>
                &nbsp;
                <asp:Button ID="Button1" CssClass="btn btn-danger" runat="server" Text="ค้นหา" OnClick="Button1_Click" />
            </div>
            <br />
        </div>
            <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>
            <rsweb:ReportViewer ID="ReportViewer2" runat="server" AsyncRendering="False" PageCountMode="Actual" SizeToReportContent="True">
            </rsweb:ReportViewer>
        </div>
    </form>
</body>
</html>
