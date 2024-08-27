<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GenerateReport.aspx.cs" Inherits="InventoryManagementSystemCMPG223.GenerateReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Reports</title>
    <link rel="stylesheet" href="ProductStyles.css" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">

        <table style="width: 100%;">
            <tr>
                <td style="width: 20%;">&nbsp;</td>
                <td>
                      <h1 id="header">Reports | Outputs</h1>
                </td>
                <td style="width: 20%;">&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <div class="content">
                      
                

                        <asp:Button ID="GenerateReportBtn" runat="server" Text="Generate Report" OnClick="GenerateReportBtn_Click1" />
                        <br />
                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Homepage.aspx">Home</asp:HyperLink>
                    </div>


                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>

    </form>
</body>
</html>
