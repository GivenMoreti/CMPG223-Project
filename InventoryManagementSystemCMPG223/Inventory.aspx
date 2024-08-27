<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inventory.aspx.cs" Inherits="InventoryManagementSystemCMPG223.Inventory" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Inventory</title>
    <link rel="stylesheet" href="ProductStyles.css" type="text/css" />
<link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet">
</head>


<body>
    <form id="form1" runat="server">
        <div>
              <table style="width: 100%;">
      <tr>
          <td style="width: 20%;">&nbsp;</td>
          <td>
              <div class="headerItems">
                  <asp:TextBox ID="SearchItem" runat="server" placeholder="search"></asp:TextBox>
                  <asp:Button ID="SearchBtn" runat="server" Text="Search inventory" />
              </div>

          </td>
          <td style="width: 20%;">&nbsp;</td>
      </tr>
      <tr>
          <td style="width: 20%;" class="sidebar">
              <div class="div-item">
                  <span class="material-icons">add</span>
                  <asp:HyperLink ID="HyperLink5" NavigateUrl="~/CreateInventory.aspx" runat="server">Add Inventory</asp:HyperLink><br />
              </div>
              <div class="div-item">
                  <span class="material-icons">update</span>
                  <asp:HyperLink ID="HyperLink6" NavigateUrl="~/UpdateInventory.aspx" runat="server">Update Inventory</asp:HyperLink><br />
              </div>
              <div class="div-item">
                  <span class="material-icons">delete</span>


                  <asp:HyperLink ID="HyperLink7" NavigateUrl="~/DeleteInventory.aspx" runat="server">Delete Inventory</asp:HyperLink><br />
              </div>
              <div class="div-item">
                  <span class="material-icons">dashboard</span>


                  <asp:HyperLink ID="HyperLink8" runat="server" NavigateUrl="~/Homepage.aspx">Dashboard</asp:HyperLink><br />
              </div>

          </td>
          <td class="content">

              <div>
                  <h1 id="productHeading">Inventory</h1>
              </div>

              <asp:GridView ID="InventoryGridView" runat="server" CellSpacing="2" AllowSorting="True" AllowPaging="True" PagerSettings-Mode="Numeric" PageSize="15"></asp:GridView>
             
             
          </td>
          <td>&nbsp;</td>
      </tr>
      <tr>
          <td>&nbsp;</td>
          <td>
              <asp:Label ID="FeedbackLbl" runat="server" Text=""></asp:Label>
          </td>
          <td>&nbsp;
          </td>
      </tr>
  </table>
        </div>
    </form>
</body>
</html>
