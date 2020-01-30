<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Classes.aspx.cs" Inherits="Home_Classes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
            border: 1px solid #000000;
        }
        .auto-style2 {}
    </style>
</head>
<body>
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
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style2">
                            <asp:Label ID="lblClassName" runat="server" Text="Class Name *"></asp:Label>
                            &nbsp;</td>
                        <td class="auto-style2">
                            <asp:TextBox ID="txtClassName" runat="server"></asp:TextBox>
                        </td>
                        <td class="auto-style2" colspan="2" rowspan="3">
                            <asp:GridView ID="gvClasses" runat="server" AutoGenerateSelectButton="True">
                                <SelectedRowStyle BackColor="#CCCCCC" />
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblUpperDOB" runat="server" Text="Maximum Age"></asp:Label>
                    <br />
                            <asp:Label ID="lblExtraDetails" runat="server" Text="Leave blank if not applicable"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtUpperDOB" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblLowerDOB" runat="server" Text="Minimum Age"></asp:Label>
                    <br />
                            <asp:Label ID="lblExtraDetails1" runat="server" Text="Leave blank if not applicable"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtLowerDOB" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblErrorMessage" runat="server" ForeColor="#FF3300" Text="Error in sign up, please check your values. " Visible="False"></asp:Label>
                    <br />
                            <asp:Label ID="lblWarning" runat="server" Font-Italic="True" Text="Deleting a class will delete all lessons and products they are associated to."></asp:Label>
                        </td>
                        <td>
                            <asp:Button ID="btnAddClass" runat="server" OnClick="btnAddClass_Click" Text="Add Class" />
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>
                            <asp:Button ID="btnDeleteClass" runat="server" OnClick="btnDeleteClass_Click" Text="Delete Class" />
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
        <br />
    
    </div>
    </form>
</body>
</html>
