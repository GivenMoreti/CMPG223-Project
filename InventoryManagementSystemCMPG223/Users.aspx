<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="InventoryManagementSystemCMPG223.Users" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>users</title>
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

                        <h1>All current Users</h1>

                    </td>
                    <td style="width: 20%;">&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 20%;" class="sidebar">

                        <div class="div-item">
                            <span class="material-icons">add</span>
                            <asp:HyperLink ID="HyperLink5" NavigateUrl="~/SignUpPage.aspx" runat="server">Register User</asp:HyperLink>
                        </div>

                        <div class="div-item">
                            <span class="material-icons">update</span>
                            <asp:HyperLink ID="HyperLink6" NavigateUrl="~/UpdateUser.aspx" runat="server">Update User</asp:HyperLink>
                        </div>

                        <div class="div-item">
                            <span class="material-icons">delete</span>
                            <asp:HyperLink ID="HyperLink7" NavigateUrl="~/DeleteUser.aspx" runat="server">Delete User</asp:HyperLink>
                        </div>

                        <div class="div-item">
                            <span class="material-icons">dashboard</span>
                            <asp:HyperLink ID="HyperLink8" runat="server" NavigateUrl="~/Homepage.aspx">Dashboard</asp:HyperLink>
                        </div>

                    </td>
                    <td class="content">

                        <asp:GridView ID="UsersGridView" runat="server"></asp:GridView>
                        <asp:Label ID="FeedbackLbl" runat="server" Text=""></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                </tr>

            </table>

        </div>
    </form>
</body>
</html>
