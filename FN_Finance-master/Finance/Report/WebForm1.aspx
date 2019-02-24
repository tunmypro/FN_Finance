<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Finance.Report.WebForm1" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<%@ Register TagPrefix="rsweb" Namespace="Microsoft.Reporting.WebForms" Assembly="Microsoft.ReportViewer.WebForms, Version=15.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../jquery-ui-1.12.1.custom/jquery-ui.min.css" rel="stylesheet" />
    <script src="../jquery-ui-1.12.1.custom/external/jquery/jquery.js"></script>
    <script src="../jquery-ui-1.12.1.custom/jquery-ui.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <br />
        <div class="container">
            <div class="row">
                <div class="col-lg-4">
                    <div class="form-group">
                        ค้นหา หมายเลขบัตรประชาชน
                    <div class="input-group">
                        <asp:TextBox ID="search" runat="server" autocomplete="off" CssClass="form-control"></asp:TextBox>
                    </div>
                    </div>
                    <div class="form-group">
                        <div class="input-group">
                            <asp:Button ID="Button1" runat="server" Text="ค้นหา" class="btn btn-primary" OnClick="Button1_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" AsyncRendering="False" PageCountMode="Actual" SizeToReportContent="True" Width="100%">
        </rsweb:ReportViewer>
    </form>
</body>
</html>
