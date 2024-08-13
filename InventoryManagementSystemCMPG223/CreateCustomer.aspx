<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateCustomer.aspx.cs" Inherits="InventoryManagementSystemCMPG223.CreateCustomer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Create a new customer profile</title>
    <link rel="stylesheet" href="ProductStyles.css" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <table style="width: 100%;">
                <tr>
                    <td style="width: 20%;">&nbsp;</td>
                    <td id="AddLipstickHeading">Add new Customer Profile</td>
                    <td style="width: 20%;">&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 20%;">&nbsp;</td>
                    <td class="content">
                      
                        
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="CustomerNameTB" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="CustomerNameTB" runat="server"  placeholder="Customer name"></asp:TextBox><br />
                        
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="CustomerEmailTB" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="CustomerEmailTB" runat="server"  placeholder="Customer Email"></asp:TextBox><br />

                        <asp:Button ID="CreateCustomerProfileBtn" runat="server" Text="Create Profile" OnClick="CreateCustomerProfileBtn_Click" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>
                        <br/>
                        <asp:Label ID="FeedbackLbl" runat="server" Text=""></asp:Label>
                        <asp:HyperLink ID="HyperLink1" NavigateUrl="~/Customers.aspx" runat="server">See Customers</asp:HyperLink>
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
