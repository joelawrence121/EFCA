<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Products.aspx.cs" Inherits="Home_Products" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
            border: 1px solid #000000;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                <br />
                <table class="auto-style1">
                    <tr>
                        <td>
                            <asp:Button ID="btnBack" runat="server" OnClick="btnBack_Click" Text="Back" />
                        </td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblCurrentOrders" runat="server" Font-Bold="True" Font-Size="X-Large" Font-Underline="True" Text="Current Orders"></asp:Label>
                        </td>
                        <td>&nbsp;</td>
                        <td>
                            <asp:Label ID="lblEditOrders0" runat="server" Font-Bold="True" Font-Size="X-Large" Font-Underline="True" Text="Edit Orders"></asp:Label>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:GridView ID="gvCurrentOrders" runat="server" AutoGenerateSelectButton="True" OnSelectedIndexChanged="gvCurrentOrders_SelectedIndexChanged">
                                <HeaderStyle BackColor="#CCCCCC" BorderColor="Black" Font-Bold="False" />
                                <SelectedRowStyle BackColor="#CCCCCC" />
                            </asp:GridView>
                            <br />
                            <br />
                        </td>
                        <td>&nbsp;</td>
                        <td>
                            <br />
                            <asp:GridView ID="gvOrderQueue" runat="server" HorizontalAlign="Center" OnSelectedIndexChanged="gvOrderQueue_SelectedIndexChanged">
                                <HeaderStyle BackColor="#CCCCCC" />
                            </asp:GridView>
                            <br />
                            <asp:Button ID="btnComplete0" runat="server" Font-Size="Large" OnClick="btnComplete_Click" Text="Complete Order" />
                            <br />
                            <asp:Button ID="btnSaveOrders0" runat="server" Font-Bold="True" Font-Size="Large" OnClick="btnSaveOrders_Click" Text="Save New Orders" />
                            <br />
                            <asp:Label ID="lblInfo3" runat="server" Font-Italic="True" Text="This will delete the orders completed."></asp:Label>
                        </td>
                        <td>
                            <br />
                            <br />
                            <br />
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblSummary" runat="server" Font-Bold="True" Font-Size="X-Large" Font-Underline="True" Text="Summary"></asp:Label>
                        </td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblQuantity" runat="server" Font-Bold="True" Font-Size="Large" Text="Quantity needed of each:"></asp:Label>
                            <asp:GridView ID="gvQuantity" runat="server">
                                <HeaderStyle BackColor="#CCCCCC" />
                            </asp:GridView>
                            <br />
                        </td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>&nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblProductsHeader" runat="server" Font-Bold="True" Font-Size="X-Large" Font-Underline="True" Text="Products"></asp:Label>
                            <br />
                            <asp:Button ID="btnAddProduct" runat="server" OnClick="btnAddProduct_Click" Text="Add New Product" />
                        </td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:GridView ID="gvProducts" runat="server" AutoGenerateColumns="False" AutoGenerateSelectButton="True">
                                <SelectedRowStyle BackColor="#CCCCCC" />
                                <Columns>
                                    <asp:BoundField DataField="ProductID" HeaderText="ProductID" />
                                    <asp:BoundField DataField="Name" HeaderText="Name" />
                                    <asp:BoundField DataField="Price" HeaderText="Price" />
                                    <asp:BoundField DataField="Size" HeaderText="Size" />
                                    <asp:BoundField DataField="Colour" HeaderText="Colour" />
                                    <asp:BoundField DataField="ClassName" HeaderText="Class Name" />
                                    <asp:TemplateField HeaderText="Image">
                                        <ItemTemplate>
                                            <asp:Image ID="Image1" runat="server" Height="100px" ImageURL='<%#"data:Image/png;base64," + Convert.ToBase64String((byte[])Eval("Image"))%>' Width="100px" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;<asp:Button ID="btnDeleteProduct" runat="server" OnClick="btnDeleteProduct_Click" Text="Delete" />
                            &nbsp;<br />
                            <asp:Label ID="lblInfo2" runat="server" Font-Italic="True" Text="Deleting a product will delete all orders associated to it. "></asp:Label>
                        </td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    
    </div>
    </form>
</body>
</html>
