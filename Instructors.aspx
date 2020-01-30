<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Instructors.aspx.cs" Inherits="Home_Instructors" %>

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
                <table class="auto-style1">
                    <tr>
                        <td>
                            <asp:Button ID="btnBack0" runat="server" OnClick="btnBack_Click" Text="Back" />
                        </td>
                        <td>
                            &nbsp;<asp:Label ID="lblHead" runat="server" Font-Bold="True" Font-Size="XX-Large" Font-Underline="True" Text="Instructors"></asp:Label>
                            <br />
                            <asp:Label ID="lblAdminView" runat="server" Font-Bold="True" Font-Size="X-Large" Text="Admin View" Visible="False"></asp:Label>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>
                            <asp:TextBox ID="txtSearch" runat="server" AutoPostBack="True" OnTextChanged="txtSearch_TextChanged"></asp:TextBox>
                            &nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="Search" />
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td><asp:Button ID="btnAdmin" runat="server" OnClick="btnAdmin_Click" Text="Admin" />
                            &nbsp;&nbsp;<asp:Button ID="btnAddInstructor" runat="server" OnClick="btnAddInstructor_Click" Text="Add New Instructor" Visible="False" />
                            &nbsp;&nbsp;<asp:Button ID="btnDeleteInstructor" runat="server" OnClick="btnDeleteInstructor_Click" Text="Delete Instructor" OnClientClick="return confirm('Are you sure? Deleting will delete all records of this instructor from the database. ')" Visible="False" />
                            &nbsp;&nbsp;&nbsp;<br />
                            <asp:Label ID="lblError" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="#FF3300" Text="Error in deleting instructor." Visible="False"></asp:Label>
                            <br />
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>
                            <asp:GridView ID="gvInstructors" runat="server" AutoGenerateSelectButton="True" CellPadding="4" ForeColor="#333333" GridLines="None">
                                <AlternatingRowStyle BackColor="White" />
                                <EditRowStyle BackColor="#7C6F57" />
                                <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#E3EAEB" />
                                <SelectedRowStyle Font-Bold="True" ForeColor="#333333" />
                                <SortedAscendingCellStyle BackColor="#F8FAFA" />
                                <SortedAscendingHeaderStyle BackColor="#246B61" />
                                <SortedDescendingCellStyle BackColor="#D4DFE1" />
                                <SortedDescendingHeaderStyle BackColor="#15524A" />
                            </asp:GridView>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                </table>
                <br />
            </ContentTemplate>
        </asp:UpdatePanel>
    
    </div>
    </form>
</body>
</html>
