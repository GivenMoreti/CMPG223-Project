<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="InventoryManagementSystemCMPG223.Products" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>lipsticks home</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>See all lispticks</h1>

            <asp:GridView ID="ProductsGridView" runat="server"></asp:GridView>



        </div>
    </form>
</body>
</html>
