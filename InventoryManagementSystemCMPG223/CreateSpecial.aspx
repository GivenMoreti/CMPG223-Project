<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateSpecial.aspx.cs" Inherits="InventoryManagementSystemCMPG223.CreateSpecial" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Create Special</title>
     <link rel="stylesheet" href="ProductStyles.css" type="text/css" />
 <link href="https://fonts.googleapis.com/icon?family=Material+Icons"
     rel="stylesheet">
</head>
<body>
    <form id="form1" runat="server">
        <div>

              <table style="width: 100%;">
      <tr>
          <td style="width: 20%;">&nbsp;</td>
          <td id="AddLipstickHeading">Add new Special </td>
          <td style="width: 20%;">&nbsp;</td>
      </tr>
      <tr>
          <td style="width: 20%;">&nbsp;</td>
          <td class="content">
            
              
              <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtProductId" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
              <asp:TextBox ID="txtProductId" runat="server" placeholder="product id"></asp:TextBox>
              
              <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtDiscount" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
              <asp:TextBox ID="txtDiscount" placeholder="Discount" runat="server"></asp:TextBox>
              <asp:TextBox ID="txtStartDate" placeholder="use calenda" runat="server"></asp:TextBox>

               <asp:TextBox ID="txtEndDate" placeholder="use calenda" runat="server"></asp:TextBox>

              <asp:Button ID="CreateCustomerProfileBtn" runat="server" Text="Create Special" />
          </td>
          <td>&nbsp;</td>
      </tr>
      <tr>
          <td>&nbsp;</td>
          <td>
              <br/>
                <asp:Label ID="errorLabel" runat="server" Text=""></asp:Label>

              <asp:HyperLink ID="HyperLink1" NavigateUrl="~/Specials.aspx" runat="server">See Specials</asp:HyperLink>
          </td>
          <td>&nbsp;</td>
      </tr>
  </table>
        </div>
    </form>
</body>
</html>
