<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Member Classes.aspx.cs" Inherits="Home_Member_Classes" %>

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
                            <asp:Label ID="lblMainHeader" runat="server" Font-Bold="True" Font-Size="XX-Large" Font-Underline="True" Text="Classes"></asp:Label>
                            <br />
                            <asp:Label ID="lblInfo1" runat="server" Text="The current classes that are on offer at EFCA."></asp:Label>
                            <br />
                            <asp:Label ID="lblInfo2" runat="server" Text="DOB Upper and Lower show the age boundaries for the class."></asp:Label>
                        </td>
                        <td class="auto-style2">
                            &nbsp;</td>
                        <td class="auto-style2" colspan="2" rowspan="3">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:GridView ID="gvClasses" runat="server" HorizontalAlign="Justify">
                                <HeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="X-Large" />
                                <RowStyle Font-Size="Large" />
                                <SelectedRowStyle BackColor="#CCCCCC" />
                            </asp:GridView>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                    <br />
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                    <br />
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
    <div>
    
    </div>
    </form>
</body>
</html>
