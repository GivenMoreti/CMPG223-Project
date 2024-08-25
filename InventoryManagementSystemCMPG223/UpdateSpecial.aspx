<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateSpecial.aspx.cs" Inherits="InventoryManagementSystemCMPG223.UpdateSpecial" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Update Special</title>
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
                        <h1 id="AddLipstickHeading">Update Special Details</h1>


                    </td>
                    <td style="width: 20%;">&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 20%;">&nbsp;</td>
                    <td class="content">
                        <asp:RequiredFieldValidator ID="ffd" runat="server" ControlToValidate="pId" ErrorMessage="*"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="pId" runat="server" placeholder="product id"></asp:TextBox>
                        
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="SpecialId" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="SpecialId" runat="server" placeholder="Special Code/id"></asp:TextBox><br />

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtDiscount" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtDiscount" runat="server" placeholder="Discount %"></asp:TextBox><br />

                        <div class="calendars">
                            <asp:Label ID="Label1" runat="server" Text="Start: "></asp:Label> 
                        <asp:Calendar ID="StartDate" runat="server"></asp:Calendar>
                            <br />
                            <asp:Label ID="Label2" runat="server" Text="End: "></asp:Label>    
                        <asp:Calendar ID="EndDate" runat="server"></asp:Calendar>
                            </div>

                        <asp:Button ID="UpdateSpecialBtn" runat="server" Text="Save & Update" OnClick="UpdateSpecialBtn_Click1" />
                        <br />
                        <asp:Label ID="FeedbackLbl" runat="server" Text=""></asp:Label><br />
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>


                        <asp:HyperLink ID="HyperLink1" NavigateUrl="~/Specials.aspx" runat="server">See Specials</asp:HyperLink>
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
