<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="InventoryManagementSystemCMPG223.Products" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   
    <title>lipsticks home</title>
     <link rel="stylesheet" href="ProductStyles.css" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>


            <table style="width: 100%;">
                <tr>
                    <td style="width: 20%;">&nbsp;</td>
                    <td id="AddLipstickHeading">
                        
                        <asp:TextBox ID="SearchItem" runat="server" placeholder="search" ></asp:TextBox>
                        <asp:Button ID="SearchBtn" runat="server" Text="Search" OnClick="SearchBtn_Click" />
                     


                    </td>
                    <td style="width: 20%;">&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 20%;">&nbsp;</td>
                    <td class="content">
                        <asp:GridView ID="ProductsGridView" runat="server" ></asp:GridView>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>

                                 <asp:HyperLink ID="HyperLink1" NavigateUrl="~/CreateProduct.aspx" runat="server">Add products</asp:HyperLink>
         <asp:HyperLink ID="HyperLink2" NavigateUrl="~/UpdateProduct.aspx" runat="server">Update product</asp:HyperLink>
         <asp:HyperLink ID="HyperLink3" NavigateUrl="~/DeleteProduct.aspx" runat="server">Delete product</asp:HyperLink><br />
                         <asp:Label ID="FeedbackLbl" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        
                       
                        </td>
                </tr>
            </table>







           
            <br />

   

        </div>
    </form>
</body>
</html>
