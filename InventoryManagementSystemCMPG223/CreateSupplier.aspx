<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateSupplier.aspx.cs" Inherits="InventoryManagementSystemCMPG223.CreateSupplier" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

     <title>Create Supplier</title>
    <link rel="stylesheet" href="ProductStyles.css" type="text/css" />
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet">
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table style="width: 100%;">
                <tr>
                    <td style="width: 20%;">&nbsp;</td>
                    <td id="AddLipstickHeading">Add new Supplier Profile</td>
                    <td style="width: 20%;">&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 20%;">&nbsp;</td>
                    <td class="content">


                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="supplierName" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="supplierName" runat="server" placeholder="Supplier Name"></asp:TextBox><br />

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="supplierEmail" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="supplierEmail" placeholder="Supplier Email" runat="server"></asp:TextBox><br />

                        <asp:Button ID="CreateSupplierBtn" runat="server" Text="Create Supplier Profile" OnClick="CreateSupplierBtn_Click" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>
                        <br />
                        <asp:Label ID="FeedbackLbl" runat="server" Text=""></asp:Label>
                        <asp:HyperLink ID="HyperLink1" NavigateUrl="~/Suppliers.aspx" runat="server">See Suppliers</asp:HyperLink>
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>

        </div>
    </form>
</body>
</html>
