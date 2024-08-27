<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateProduct.aspx.cs" Inherits="InventoryManagementSystemCMPG223.CreateProduct" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add Lipstick</title>
</head>
<link rel="stylesheet" href="ProductStyles.css" type="text/css" />
<body>
    <form id="form1" runat="server">

        <div>

            <table style="width: 100%;">
                <tr>
                    <td style="width: 20%;">&nbsp;</td>
                    
                    <td >
                        <h1 id="AddLipstickHeading">Add new lisptick</h1>    
                    </td>

                    <td style="width: 20%;">&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 20%;">&nbsp;</td>
                    <td class="content">

                       

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="Name" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="Name" runat="server" placeholder="P R O D U C T  N A M E"></asp:TextBox><br />

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="Price1" ErrorMessage="*"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="Price1" runat="server" placeholder="P R O D U C T  P R I C E"></asp:TextBox>
                        <br />

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="Description" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="Description" runat="server" placeholder="P R O D U C T  D E S C R I P T I O N"></asp:TextBox><br />

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="Size" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="Size" runat="server" placeholder="P R O D U C T  S I Z E"></asp:TextBox><br />

                      
                        <asp:TextBox ID="inventoryId" runat="server" placeholder="I N V E N T O R Y  I D"></asp:TextBox><br />


                       
                        <asp:Button ID="AddProductBtn" runat="server" Text="Add Lipstick" OnClick="AddProduct_Click" />
                        <br />
                        <asp:Label ID="FeedbackLbl" runat="server" Text=""></asp:Label><br />
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:HyperLink ID="HyperLink1" NavigateUrl="~/Products.aspx" runat="server">See products</asp:HyperLink>
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
