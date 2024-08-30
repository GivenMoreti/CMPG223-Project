<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderConfirmation.aspx.cs" Inherits="InventoryManagementSystemCMPG223.OrderConfirmation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Order Product</title>
    <link rel="stylesheet" href="ProductStyles.css" type="text/css" />
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet">
</head>
<body>
    <form id="form1" runat="server">
        <table style="width: 100%;">
            <tr>
                <td style="width: 20%;">&nbsp;</td>
                <td>
                   
                </td>
                <td style="width: 20%;">&nbsp;</td>

            </tr>
            <tr>
                <td style="width: 20%;" class="sidebar"></td>
                <td class="content">
                    <div>
                        <h1 id="productHeading">Ordered Products</h1>
                    </div>
                    <asp:GridView ID="OrderProductGridView" runat="server" OnRowCommand="OrderProductGridView_RowCommand">

                        

                    </asp:GridView>

                    <br />
                    <asp:HyperLink ID="HyperLink1" NavigateUrl="~/Homepage.aspx" runat="server">Home</asp:HyperLink>
                    <asp:Label ID="FeedbackLbl" runat="server" Text=""></asp:Label>

                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp; </td>
                <td>&nbsp; </td>
            </tr>
        </table>
    </form>
</body>
</html>
