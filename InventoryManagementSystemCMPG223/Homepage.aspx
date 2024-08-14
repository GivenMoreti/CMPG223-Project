<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Homepage.aspx.cs" Inherits="InventoryManagementSystemCMPG223.Homepage" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Homepage</title>
    <link rel="stylesheet" href="ProductStyles.css" type="text/css" />
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons"
        rel="stylesheet">
</head>
<body>
    <div class="home-container">
        <form id="form1" runat="server">

            <table style="width: 100%;">
                <tr>
                    <td style="width: 20%;">
                        <h1>SimpliU</h1>
                    </td>
                    <td>
                        <div class="headerItems">
                            <asp:TextBox ID="SearchItem" runat="server" placeholder="search"></asp:TextBox>
                            <asp:Button ID="SearchBtn" runat="server" Text="Search" />

                        </div>


                    </td>
                    <td style="width: 20%;">
                        <asp:Label ID="LblGreet" runat="server" Text=""></asp:Label>

                    </td>

                </tr>
                <tr>

                    <td style="width: 20%;" class="sidebar">

                        <div class="div-item">
                            <span class="material-icons">category</span>
                            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Products.aspx"> Products</asp:HyperLink>
                        </div>

                        <div class="div-item">
                            <span class="material-icons">people</span>
                            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Customers.aspx">Customers</asp:HyperLink>
                        </div>
                        <div class="div-item"><span class="material-icons">inventory</span><asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/Products.aspx">Inventory</asp:HyperLink></div>
                        <div class="div-item">
                            <span class="material-icons">local_shipping</span>
                            <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/Products.aspx">Orders</asp:HyperLink>
                        </div>
                        <div class="div-item">
                            <span class="material-icons">discount</span>
                            <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/Products.aspx">Specials</asp:HyperLink>
                        </div>
                        <div class="div-item">
                            <span class="material-icons">business</span>
                            <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="~/Products.aspx">Supplier</asp:HyperLink>
                        </div>
                        <div class="div-item">
                            <span class="material-icons">shopping_cart</span>
                            <asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl="~/Products.aspx">Ordered product</asp:HyperLink>
                        </div>
                        <div class="div-item">
                            <span class="material-icons">manage_accounts</span>
                             <asp:HyperLink ID="HyperLink9" runat="server" NavigateUrl="~/Users.aspx">Users</asp:HyperLink>
                        </div>



                        <div class="div-item">
                            <span class="material-icons">logout</span>
                            <asp:HyperLink ID="HyperLink8" runat="server" NavigateUrl="~/LoginPage.aspx">Logout</asp:HyperLink>
                        </div>


                    </td>

                    <td class="mid-container">


                        <div id="productCountContainer">
                            <asp:Label ID="ProductCountLbl" runat="server" Text=""></asp:Label>
                        </div>

                        <div id="productCountContainer">
                            <asp:Label ID="CustomerCountLbl" runat="server" Text=""></asp:Label>
                        </div>

                         <div id="productCountContainer">
                             <asp:Label ID="UsersCountLbl" runat="server" Text=""></asp:Label>
                        </div>


                    </td>

                </tr>
                <tr>

                    <td>
                        <asp:Label ID="FeedbackLbl" runat="server" Text=""></asp:Label>
                    </td>

                </tr>
            </table>



        </form>
    </div>

</body>
</html>
