<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Order.aspx.cs" Inherits="InventoryManagementSystemCMPG223.Order" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="SelectedProductsGridView" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="Product ID" />
                    <asp:BoundField DataField="ProductName" HeaderText="Product Name" />
                    <asp:BoundField DataField="Price" HeaderText="Price" />
                    <asp:BoundField DataField="ProductDescription" HeaderText="Description" />

                    <asp:BoundField DataField="ProductSize" HeaderText="Size" />
                    <asp:BoundField DataField="InventoryId" HeaderText="Inventory Id" />


                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:TextBox ID="QuantityTextBox" runat="server" Text="1" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:Button ID="PlaceOrderButton" runat="server" Text="Place Order" OnClick="PlaceOrderButton_Click" />

        </div>
    </form>
</body>
</html>
