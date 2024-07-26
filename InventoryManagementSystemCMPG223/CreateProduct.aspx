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
                    <td id="AddLipstickHeading">Add new lisptick</td>
                    <td style="width: 20%;">&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 20%;">&nbsp;</td>
                    <td class="content">
                          <asp:TextBox ID="ProductId" runat="server" placeholder="item id"></asp:TextBox><br/>
                          <asp:TextBox ID="Name" runat="server" placeholder="item name"></asp:TextBox><br/>
                          <asp:TextBox ID="Price" runat="server" placeholder="item price"></asp:TextBox> <br/>
                          <asp:TextBox ID="Description" runat="server" placeholder="item description"></asp:TextBox><br/>
                          <asp:TextBox ID="Size" runat="server" placeholder="item size"></asp:TextBox><br/>
                          <asp:Button ID="AddProductBtn" runat="server" Text="Add Lipstick" OnClick="AddProduct_Click" /> <br />
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
