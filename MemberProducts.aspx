<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MemberProducts.aspx.cs" Inherits="Home_MemberProducts" %>

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
                <br />
    <form id="form1" runat="server">
    <div>
    
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table class="auto-style1">
                    <tr>
                        <td>
                            <asp:Button ID="btnBack" runat="server" OnClick="btnBack_Click" Text="Back" />
                        </td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblCurrentOrders" runat="server" Font-Bold="True" Font-Size="X-Large" Font-Underline="True" Text="Your Current Orders"></asp:Label>
                        </td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:GridView ID="gvCurrentOrders" runat="server" AutoGenerateSelectButton="True" OnSelectedIndexChanged="gvCurrentOrders_SelectedIndexChanged">
                                <SelectedRowStyle BackColor="#CCCCCC" />
                            </asp:GridView>
                        </td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblProducts" runat="server" Font-Bold="True" Font-Size="X-Large" Font-Underline="True" Text="Products"></asp:Label>
                            <br />
                        </td>
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
                            <br />
                            <asp:Button ID="btnOrder" runat="server" OnClick="btnOrder_Click" Text="Order" />
                        </td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>&nbsp;&nbsp;<br /> </td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
        <br />
    
    </div>
    </form>
</body>
</html>
