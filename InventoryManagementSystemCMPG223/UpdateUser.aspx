<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateUser.aspx.cs" Inherits="InventoryManagementSystemCMPG223.UpdateUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>update user profile</title>
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
         <td >
             <h1 id="AddLipstickHeading"> Update User Profile</h1>
            

         </td>
         <td style="width: 20%;">&nbsp;</td>
     </tr>
     <tr>
         <td style="width: 20%;">&nbsp;</td>
         <td class="content">
             
             <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="UserIdTB" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
             <asp:TextBox ID="UserIdTB" runat="server" placeholder="User Id"></asp:TextBox><br />


             <asp:RegularExpressionValidator ControlToValidate="UsernameTB" ID="RegularExpressionValidator1" runat="server" ErrorMessage="*"></asp:RegularExpressionValidator>
             <asp:TextBox ID="UsernameTB" runat="server" placeholder="Email"></asp:TextBox><br />

             <asp:RequiredFieldValidator ControlToValidate="UserPassword" ID="RequiredFieldValidator3" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
            <asp:TextBox ID="UserPassword" runat="server" placeholder="Password"></asp:TextBox><br />


             
             
             <asp:Button ID="UpdateUserBtn" runat="server" Text="Update User profile" OnClick="UpdateUserBtn_Click" />
             <br />
             <asp:Label ID="FeedbackLbl" runat="server" Text=""></asp:Label><br />
         </td>
         <td>&nbsp;</td>
     </tr>
     <tr>
         <td>&nbsp;</td>
         <td>


             <asp:HyperLink ID="HyperLink1" NavigateUrl="~/Users.aspx" runat="server">See users</asp:HyperLink>
         </td>
         <td>&nbsp;</td>
     </tr>
 </table>
        </div>
    </form>
</body>
</html>
