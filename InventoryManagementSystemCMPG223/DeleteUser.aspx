<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DeleteUser.aspx.cs" Inherits="InventoryManagementSystemCMPG223.DeleteUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Delete a user profile</title>
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
         <td id="AddLipstickHeading">Delete User Profile</td>
         <td style="width: 20%;">&nbsp;</td>
     </tr>
     <tr>
         <td style="width: 20%;">&nbsp;</td>
         <td class="content">
             <asp:TextBox ID="UserIdTB" runat="server" placeholder="Enter user id"></asp:TextBox><br />
             <asp:Button ID="DeleteUserBtn" runat="server" Text="Delete user Profile" OnClick="DeleteUserBtn_Click" />
             <br />

             <asp:Label ID="FeedbackLbl" runat="server" Text=""></asp:Label><br />
         </td>
         <td>&nbsp;</td>
     </tr>
     <tr>
         <td>&nbsp;</td>
         <td>


             <asp:HyperLink ID="HyperLink1" NavigateUrl="~/Users.aspx" runat="server">See Users</asp:HyperLink>
         </td>
         <td>&nbsp;</td>
     </tr>
 </table>
        </div>
    </form>
</body>
</html>
