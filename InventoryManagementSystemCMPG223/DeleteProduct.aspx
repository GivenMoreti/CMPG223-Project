<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DeleteProduct.aspx.cs" Inherits="InventoryManagementSystemCMPG223.DeleteProduct" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Delete product</title>
</head>
        <link rel="stylesheet" href="ProductStyles.css" type="text/css" />
<body>
    <form id="form1" runat="server">
        
        
        <table style="width: 100%;">
    <tr>
        <td style="width: 20%;">&nbsp;</td>
        <td id="AddLipstickHeading">Delete A lisptick</td>
        <td style="width: 20%;">&nbsp;</td>
    </tr>
    <tr>
        <td style="width: 20%;">&nbsp;</td>
        <td class="content">
              <asp:TextBox ID="ProductId" runat="server" placeholder="enter item id"></asp:TextBox><br/>
              <asp:Button ID="AddProductBtn" runat="server" Text="Delete"  OnClick="DeleteProducts" /> <br />

              <asp:Label ID="FeedbackLbl" runat="server" Text=""></asp:Label><br />
        </td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td>


            <asp:HyperLink ID="HyperLink1" NavigateUrl="~/Products.aspx" runat="server">See products</asp:HyperLink>
        </td>
        <td>&nbsp;</td>
    </tr>
</table>
        
    </form>
</body>
</html>
