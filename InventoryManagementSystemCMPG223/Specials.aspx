<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Specials.aspx.cs" Inherits="InventoryManagementSystemCMPG223.Specials" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Specials</title>
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
                    <td>
                        <div class="headerItems">
                            <asp:TextBox ID="SearchItem" runat="server" placeholder="search"></asp:TextBox>
                            <asp:Button ID="SearchSpecialBtn" runat="server" Text="Search" />
                        </div>
                    </td>
                    <td style="width: 20%;">&nbsp;</td>

                </tr>
                <tr>
                    <td style="width: 20%;" class="sidebar">

                        <div class="div-item">
                            <span class="material-icons">add</span>
                            <asp:HyperLink ID="HyperLink5" NavigateUrl="~/CreateSpecial.aspx" runat="server">Create Special</asp:HyperLink>
                        </div>

                        <div class="div-item">
                            <span class="material-icons">update</span>
                            <asp:HyperLink ID="HyperLink6" NavigateUrl="~/UpdateSpecial.aspx" runat="server">Update Special</asp:HyperLink>
                        </div>

                        <div class="div-item">
                            <span class="material-icons">delete</span>
                            <asp:HyperLink ID="HyperLink7" NavigateUrl="~/DeleteSpecial.aspx" runat="server">Delete Special</asp:HyperLink>
                        </div>

                        <div class="div-item">
                            <span class="material-icons">dashboard</span>
                            <asp:HyperLink ID="HyperLink8" runat="server" NavigateUrl="~/Homepage.aspx">Dashboard</asp:HyperLink>
                        </div>


                    </td>
                    <td class="content">
                        <div>
                            <h1 id="productHeading">View Specials</h1>
                        </div>

                        <asp:GridView ID="SpecialsGridView" runat="server" Height="183px" Width="301px"></asp:GridView>

                        <asp:Label ID="FeedbackLbl" runat="server" Text=""></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp; </td>
                    <td>&nbsp; </td>
                </tr>
            </table>

        </div>
    </form>
</body>
</html>
