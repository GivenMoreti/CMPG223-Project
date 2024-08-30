<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="InventoryManagementSystemCMPG223.LoginPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sign in page</title>
    <link rel="stylesheet" href="ProductStyles.css" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table style="width: 100%;">
                <tr>
                    <td style="width: 20%;">&nbsp;</td>
                    <td id="AddLipstickHeading">
                        <h1>Sign in</h1>
                    </td>
                    <td style="width: 20%;">&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 20%;">&nbsp;</td>
                    <td class="content">

                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="Username" runat="server" ErrorMessage="*" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                        <asp:TextBox ID="Username" runat="server" placeholder="Enter your name"></asp:TextBox><br />


                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="UserPassword" ErrorMessage="*"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="UserPassword" type="password" runat="server" placeholder="Enter your password"></asp:TextBox><br />

                        <asp:Button ID="SignInBtn" runat="server" Text="Sign in" OnClick="SignInBtn_Click" />

                        <div class="HaveAccountContainer">
                            <p id="haveAccountText">Don't have account?</p>
                            <asp:HyperLink ID="LoginLbl" runat="server" NavigateUrl="~/SignUpPage.aspx">Sign up</asp:HyperLink>
                        </div>
                        <asp:Label ID="LblDisplay" runat="server" Text=""></asp:Label>

                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td></td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
