<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GenerateReport.aspx.cs" Inherits="InventoryManagementSystemCMPG223.GenerateReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Reports</title>
    <link rel="stylesheet" href="ProductStyles.css" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
                <h1>Reports | Outputs</h1>
            <hr />

       


            <asp:Button ID="GenerateReportBtn" runat="server" Text="Generate Report" OnClick="GenerateReportBtn_Click1" />
             <br />   
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Homepage.aspx">Home</asp:HyperLink>
        </div>
    </form>
</body>
</html>
