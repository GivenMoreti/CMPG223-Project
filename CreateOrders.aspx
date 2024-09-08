<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateOrders.aspx.cs" Inherits="InventoryManagementSystemCMPG223.CreateOrders" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Create a new order</title>
    <link rel="stylesheet" href="ProductStyles.css" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <table style="width: 100%;">
                <tr>
                    <td style="width: 20%;">&nbsp;</td>
                    <td id="AddLipstickHeading">Add a new order</td>
                    <td style="width: 20%;">&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 20%;">&nbsp;</td>
                    <td class="content">
                       
                        <asp:TextBox ID="CustomerID" runat="server" placeholder="Customer ID"></asp:TextBox>
                        <asp:Calendar ID="OrderDate" runat="server"></asp:Calendar>
                        <asp:TextBox ID="ProductId" runat="server" placeholder="item id"></asp:TextBox><br/>
                        <asp:TextBox ID="Quantity" runat="server" placeholder="Quantity"></asp:TextBox><br />
                        <asp:Button ID="AddOrderBtn" runat="server" Text="Create Order" OnClick="CreateOrderBtn_Click" /> <br />
                        <asp:Label ID="Label1" runat="server" Text=""></asp:Label><br />
                        
                        <br />
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:Label ID="FeedbackLbl" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:HyperLink ID="HyperLink1" NavigateUrl="~/Orders.aspx" runat="server">See Orders</asp:HyperLink>
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>