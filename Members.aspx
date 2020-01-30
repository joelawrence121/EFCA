<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Members.aspx.cs" Inherits="Home_Members" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
            border: 1px solid #000000;
        }
        .auto-style2 {
            width: 627px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        &nbsp;<asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table class="auto-style1">
                    <tr>
                        <td>
                            <asp:Button ID="btnBack0" runat="server" OnClick="btnBack_Click" Text="Back" />
                        </td>
                        <td>
                            <asp:Label ID="lblMembers" runat="server" Font-Bold="True" Font-Size="XX-Large" Font-Underline="True" Text="Members"></asp:Label>
                            <br />
                            <asp:Label ID="lblAdminView" runat="server" Font-Bold="True" Font-Size="X-Large" Text="Admin View" Visible="False"></asp:Label>
                        </td>
                        <td colspan="2">&nbsp;</td>
                        <td class="auto-style2">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>
                            <asp:TextBox ID="txtSearch" runat="server" AutoPostBack="True" EnableTheming="True" OnTextChanged="txtSearch_TextChanged"></asp:TextBox>
                            &nbsp;<asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="Search" />
                        </td>
                        <td colspan="2">&nbsp;</td>
                        <td class="auto-style2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td colspan="4">
                            <asp:Button ID="btnAdmin0" runat="server" OnClick="btnAdmin_Click" Text="Admin" />
                            &nbsp;
                            <asp:Button ID="btnSeePayments" runat="server" OnClick="btnSeePayments_Click" Text="See Payment Records" />
                            &nbsp;
                            <asp:Button ID="btnAddMember" runat="server" OnClick="btnAddMember_Click" Text="Add New Member" />
                            &nbsp;&nbsp;
                            <asp:Button ID="btnDeleteMember" runat="server" OnClick="btnDeleteMember_Click" Text="Delete Selected" Visible="False" OnClientClick="return confirm('Are you sure you want to delete? Deletion will clear all records of this member from the database.')" />
                            &nbsp; &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td colspan="2">
                            <asp:GridView ID="gvMembers" runat="server" AutoGenerateSelectButton="True" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" GridLines="Horizontal" >
                                <FooterStyle BackColor="White" ForeColor="#333333" />
                                <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="White" ForeColor="#333333" />
                                <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                                <SortedAscendingCellStyle BackColor="#F7F7F7" />
                                <SortedAscendingHeaderStyle BackColor="#487575" />
                                <SortedDescendingCellStyle BackColor="#E5E5E5" />
                                <SortedDescendingHeaderStyle BackColor="#275353" />
                            </asp:GridView>
                        </td>
                        <td colspan="2">&nbsp;</td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
        <br />
    
    </div>
    </form>
</body>
</html>
