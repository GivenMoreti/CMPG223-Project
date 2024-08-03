<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateCustomer.aspx.cs" Inherits="InventoryManagementSystemCMPG223.UpdateCustomer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
      <link rel="stylesheet" href="ProductStyles.css" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table style="width: 100%;">
                <tr>
                    <td style="width: 20%;">&nbsp;</td>
                    <td id="AddLipstickHeading">Update Customer Profile</td>
                    <td style="width: 20%;">&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 20%;">&nbsp;</td>
                    <td class="content">
                        <asp:TextBox ID="CustomerIdTB" runat="server" placeholder="customer id"></asp:TextBox><br />
                        <asp:TextBox ID="CustomerNameTB" runat="server" placeholder="customer name"></asp:TextBox><br />
                        <asp:TextBox ID="CustomerEmailTB" runat="server" placeholder="customer email"></asp:TextBox>
                        <asp:Button ID="UpdateCustomerBtn" runat="server" Text="Update Customer profile" OnClick="UpdateCustomerBtn_Click" />
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
