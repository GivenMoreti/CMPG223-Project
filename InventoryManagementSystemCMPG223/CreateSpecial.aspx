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
              <div class="calendars">
                  <asp:Label ID="Label1" runat="server" Text="Start: "></asp:Label><br />
              <asp:Calendar ID="txtStartDate" runat="server"></asp:Calendar>
                  <asp:Label ID="Label2" runat="server" Text="End: "></asp:Label><br />
              <asp:Calendar ID="txtEndDate" runat="server"></asp:Calendar>
            
</div>
             

              <asp:Button ID="CreateSpecialBtn" runat="server" Text="Create Special" OnClick="CreateSpecialBtn_Click" />
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
