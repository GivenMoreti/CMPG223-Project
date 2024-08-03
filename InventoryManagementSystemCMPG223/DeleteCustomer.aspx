<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DeleteCustomer.aspx.cs" Inherits="InventoryManagementSystemCMPG223.DeleteCustomer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Delete customer</title>
     <link rel="stylesheet" href="ProductStyles.css" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <table style="width: 100%;">
                <tr>
                    <td style="width: 20%;">&nbsp;</td>
                    <td id="AddLipstickHeading">Delete A lisptick</td>
                    <td style="width: 20%;">&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 20%;">&nbsp;</td>
                    <td class="content">
                        <asp:TextBox ID="CustomerIdTB" runat="server" placeholder="enter customer id"></asp:TextBox><br />
                        <asp:Button ID="DeleteCustomerBtn" runat="server" Text="Delete Customer Profile" OnClick="DeleteCustomerBtn_Click1" />
                        <br />

                        <asp:Label ID="FeedbackLbl" runat="server" Text=""></asp:Label><br />
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>


                        <asp:HyperLink ID="HyperLink1" NavigateUrl="~/Customers.aspx" runat="server">See customers</asp:HyperLink>
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
