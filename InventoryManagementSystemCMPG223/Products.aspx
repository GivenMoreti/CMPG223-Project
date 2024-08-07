<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="InventoryManagementSystemCMPG223.Products" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title>lipsticks home</title>
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
                    <td id="AddLipstickHeading">

                        <asp:TextBox ID="SearchItem" runat="server" placeholder="search"></asp:TextBox>
                        <asp:Button ID="SearchBtn" runat="server" Text="Search" OnClick="SearchBtn_Click" />


                    </td>
                    <td style="width: 20%;">&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 20%;" class="sidebar">
                        <div class="div-item">
                            <span class="material-icons">add</span>
                            <asp:HyperLink ID="HyperLink5" NavigateUrl="~/CreateProduct.aspx" runat="server">Add products</asp:HyperLink><br />
                        </div>
                        <div class="div-item">
                            <span class="material-icons">update</span>
                            <asp:HyperLink ID="HyperLink6" NavigateUrl="~/UpdateProduct.aspx" runat="server">Update product</asp:HyperLink><br />
                        </div>
                        <div class="div-item">
                            <span class="material-icons">delete</span>


                            <asp:HyperLink ID="HyperLink7" NavigateUrl="~/DeleteProduct.aspx" runat="server">Delete product</asp:HyperLink><br />
                        </div>
                        <div class="div-item">
                            <span class="material-icons">dashboard</span>


                            <asp:HyperLink ID="HyperLink8" runat="server" NavigateUrl="~/Homepage.aspx">Dashboard</asp:HyperLink><br />
                        </div>

                    </td>
                    <td class="content">

                        <div>
                            <h1 id="productHeading">Products</h1>
                        </div>

                        <asp:GridView ID="ProductsGridView" runat="server" CellSpacing="2" AllowSorting="True" AllowPaging="True" PagerSettings-Mode="Numeric" PageSize="15"></asp:GridView>
                        <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString="<%$ ConnectionStrings:InventoryManagementSystemDBConnectionString %>" DeleteCommand="DELETE FROM [Products] WHERE [Id] = @Id" InsertCommand="INSERT INTO [Products] ([Id], [ProductName], [Price], [ProductDescription], [ProductSize], [InventoryId]) VALUES (@Id, @ProductName, @Price, @ProductDescription, @ProductSize, @InventoryId)" SelectCommand="SELECT * FROM [Products]" UpdateCommand="UPDATE [Products] SET [ProductName] = @ProductName, [Price] = @Price, [ProductDescription] = @ProductDescription, [ProductSize] = @ProductSize, [InventoryId] = @InventoryId WHERE [Id] = @Id">
                            <DeleteParameters>
                                <asp:Parameter Name="Id" Type="Int32"></asp:Parameter>
                            </DeleteParameters>
                            <InsertParameters>
                                <asp:Parameter Name="Id" Type="Int32"></asp:Parameter>
                                <asp:Parameter Name="ProductName" Type="String"></asp:Parameter>
                                <asp:Parameter Name="Price" Type="Decimal"></asp:Parameter>
                                <asp:Parameter Name="ProductDescription" Type="String"></asp:Parameter>
                                <asp:Parameter Name="ProductSize" Type="Decimal"></asp:Parameter>
                                <asp:Parameter Name="InventoryId" Type="Int32"></asp:Parameter>
                            </InsertParameters>
                            <UpdateParameters>
                                <asp:Parameter Name="ProductName" Type="String"></asp:Parameter>
                                <asp:Parameter Name="Price" Type="Decimal"></asp:Parameter>
                                <asp:Parameter Name="ProductDescription" Type="String"></asp:Parameter>
                                <asp:Parameter Name="ProductSize" Type="Decimal"></asp:Parameter>
                                <asp:Parameter Name="InventoryId" Type="Int32"></asp:Parameter>
                                <asp:Parameter Name="Id" Type="Int32"></asp:Parameter>
                            </UpdateParameters>
                        </asp:SqlDataSource>
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
