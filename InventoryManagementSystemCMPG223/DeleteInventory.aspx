﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DeleteInventory.aspx.cs" Inherits="InventoryManagementSystemCMPG223.DeleteInventory" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Delete Inventory</title>
     <link rel="stylesheet" href="ProductStyles.css" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table style="width: 100%;">
                <tr>
                    <td style="width: 20%;">&nbsp;</td>
                    <td id="AddLipstickHeading">Delete An Inventory Item</td>
                    <td style="width: 20%;">&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 20%;">&nbsp;</td>
                    <td class="content">
                        <asp:TextBox ID="inventoryId" runat="server" placeholder="Enter inventory id"></asp:TextBox><br />
                        <asp:Button ID="DeleteInventoryBtn" runat="server" Text="Delete Inventory" OnClick="DeleteInventoryBtn_Click" />
                        <br />

                        <asp:Label ID="FeedbackLbl" runat="server" Text=""></asp:Label><br />
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>


                        <asp:HyperLink ID="HyperLink1" NavigateUrl="~/Inventory.aspx" runat="server">See Inventory</asp:HyperLink>
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>