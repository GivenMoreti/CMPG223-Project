<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateSupplier.aspx.cs" Inherits="InventoryManagementSystemCMPG223.UpdateSupplier" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Update Supplier</title>
      
    <link rel="stylesheet" href="ProductStyles.css" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
             <table style="width: 100%;">
     <tr>
         <td style="width: 20%;">&nbsp;</td>
         <td >
             <h1 id="AddLipstickHeading"> Update Supplier Profile</h1>
            

         </td>
         <td style="width: 20%;">&nbsp;</td>
     </tr>
     <tr>
         <td style="width: 20%;">&nbsp;</td>
         <td class="content">
             
             <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtSupplierId" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
            <asp:TextBox ID="txtSupplierId" runat="server" placeholder="Supplier Id"></asp:TextBox>



             <asp:RequiredFieldValidator ControlToValidate="txtName" ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
              <asp:TextBox ID="txtName" runat="server" placeholder="Supplier Name"></asp:TextBox>



             <asp:RequiredFieldValidator ControlToValidate="txtEmail" ID="RequiredFieldValidator3" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
             <asp:TextBox ID="txtEmail" placeholder="Supplier Email" runat="server"></asp:TextBox>
             <br />
             
             <asp:Button ID="UpdateSupplierBtn" runat="server" Text="Update Supplier Profile" OnClick="UpdateSupplierBtn_Click" />
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
