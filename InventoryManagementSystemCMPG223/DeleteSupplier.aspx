<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DeleteSupplier.aspx.cs" Inherits="InventoryManagementSystemCMPG223.DeleteSupplier" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Delete Supplier</title>
     <link rel="stylesheet" href="ProductStyles.css" type="text/css" />
 <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet">
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <table style="width: 100%;">
    <tr>
        <td style="width: 20%;">&nbsp;</td>
        <td id="AddLipstickHeading">Delete A Supplier</td>
        <td style="width: 20%;">&nbsp;</td>
    </tr>
    <tr>
        <td style="width: 20%;">&nbsp;</td>
        <td class="content">
            <asp:TextBox ID="txtSupplierId" placeholder="Supplier Id" runat="server"></asp:TextBox><br />
            <asp:Button ID="DeleteSupplierBtn" runat="server" Text="Delete Supplier Profile" OnClick="DeleteSupplierBtn_Click" />
            <br />

            <asp:Label ID="FeedbackLbl" runat="server" Text=""></asp:Label><br />
        </td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td>


            <asp:HyperLink ID="HyperLink1" NavigateUrl="~/Suppliers.aspx" runat="server">See Suppliers</asp:HyperLink>
        </td>
        <td>&nbsp;</td>
    </tr>
</table>
        </div>
    </form>
</body>
</html>
