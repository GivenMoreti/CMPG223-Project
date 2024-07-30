<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Homepage.aspx.cs" Inherits="InventoryManagementSystemCMPG223.Homepage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1> this is the main homepage</h1>

        </div>
        <div>
            <h3>This part will come from the rest of the group</h3>
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Products.aspx">Products</asp:HyperLink>
            
            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Products.aspx">Customers</asp:HyperLink>
             <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/Products.aspx">Inventory</asp:HyperLink>
             <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/Products.aspx">Orders</asp:HyperLink>
             <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/Products.aspx">Specials</asp:HyperLink>
             <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="~/Products.aspx">Supplier</asp:HyperLink>
             <asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl="~/Products.aspx">Ordered product</asp:HyperLink>
            
    </form>
</body>
</html>
