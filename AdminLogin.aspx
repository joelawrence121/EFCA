<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdminLogin.aspx.cs" Inherits="Home_AdminLogin" %>

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
    
        <table class="auto-style1">
            <tr>
                <td>
                    <asp:Button ID="btnBack" runat="server" OnClick="btnBack_Click" Text="Back" />
                </td>
                <td colspan="2">
                    <asp:Label ID="lblMainHeader" runat="server" Font-Bold="True" Font-Size="X-Large" Text="Admin Login"></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td rowspan="4">
                    &nbsp;</td>
                <td>
                    <asp:Label ID="lblID" runat="server" Text="AdminID"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtID" runat="server" Width="125px"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblPassword" runat="server" Text="Password"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="125px"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblInvalid" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="Red" Text="Invalid details." Visible="False"></asp:Label>
                </td>
                <td>
                    <asp:LinkButton ID="lbtnForgot" runat="server" OnClick="lbtnForgot_Click">Forgotten ID/Password?</asp:LinkButton>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnLogIn" runat="server" Text="Log in " Width="230px" OnClick="btnLogIn_Click" />
                </td>
                <td>
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" Width="230px" OnClick="btnCancel_Click" />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td colspan="2">
                    &nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
