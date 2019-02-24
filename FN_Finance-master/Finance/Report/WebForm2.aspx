<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="Finance.Report.WebForm2" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=15.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../jquery-ui-1.12.1.custom/jquery-ui.min.css" rel="stylesheet" />
    <script src="../jquery-ui-1.12.1.custom/external/jquery/jquery.js"></script>
    <script src="../jquery-ui-1.12.1.custom/jquery-ui.min.js"></script>
    <script>
        $(function () {
            var dateFormat = "mm/dd/yy",
                from = $("#from")
                    .datepicker({
                        changeMonth: true,
                        changeYear: true,
                        numberOfMonths: 1
                    })
                    .on("change", function () {
                        to.datepicker("option", "minDate", getDate(this));
                    }),
                to = $("#to").datepicker({
                    changeMonth: true,
                    changeYear: true,
                    numberOfMonths: 1
                })
                    .on("change", function () {
                        from.datepicker("option", "maxDate", getDate(this));
                    });
            function getDate(element) {
                var date;
                try {
                    date = $.datepicker.parseDate(dateFormat, element.value);
                } catch (error) {
                    date = null;
                }
                return date;
            }
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="row">
                <div class="col-lg-4">
                    <div class="form-group">
                        เรียกดูจากวันที่
                    <div class="input-group">
                        <asp:TextBox ID="from" runat="server" autocomplete="off" CssClass="form-control" OnTextChanged="from_TextChanged"></asp:TextBox>
                    </div>
                    </div>
                    <div class="form-group">
                        ถึงวันที่
                        <div class="input-group">
                            <asp:TextBox ID="to" runat="server" autocomplete="off" CssClass="form-control"></asp:TextBox>
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
        <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>
        <rsweb:ReportViewer ID="ReportViewer2" runat="server" AsyncRendering="False" PageCountMode="Actual" SizeToReportContent="True" Width="100%">
        </rsweb:ReportViewer>
    </form>
</body>
</html>
