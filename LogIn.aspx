<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LogIn.aspx.cs" Inherits="Home_LogIn" %>

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
                <td>&nbsp;</td>
                <td>
                    <asp:Label ID="lblMainHeader" runat="server" Font-Bold="True" Font-Size="X-Large" Text="East Finchley Combat Academy"></asp:Label>
                    <br />
                    <asp:Label ID="lbSubHeader" runat="server" Font-Italic="True" Font-Size="Large" Text="Online Gym DBMS"></asp:Label>
                </td>
                <td colspan="2">
                    <br />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td colspan="2">
                    <asp:Label ID="lblMemberHeader" runat="server" Font-Bold="True" Font-Size="X-Large" Font-Underline="True" Text="Member Login"></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td rowspan="4">
                    <asp:ImageButton ID="imgbtnLogo" runat="server" ImageUrl="~/Home/Images/logo.jpg" OnClick="imgbtnLogo_Click" />
                </td>
                <td>
                    <asp:Label ID="lblID" runat="server" Text="MemberID" Font-Size="Large"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server" Font-Size="Large"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:Label ID="lblPassword" runat="server" Text="Password" Font-Size="Large"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox2" runat="server" Font-Size="Large" TextMode="Password"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:Label ID="lblInvalid" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="Red" Text="Invalid details." Visible="False"></asp:Label>
                </td>
                <td>
                    <asp:LinkButton ID="lbtnForgot" runat="server" OnClick="lbtnForgot_Click">Forgotten ID/Password?</asp:LinkButton>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:Button ID="btnLogIn" runat="server" Text="Log in " Width="230px" OnClick="btnLogIn_Click" Font-Size="Large" />
                </td>
                <td>
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" Width="230px" OnClick="btnCancel_Click" Font-Size="Large" />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                            &nbsp;</td>
                <td colspan="2">
                    <asp:Button ID="btnSignUp" runat="server" OnClick="btnSignUp_Click" Text="Sign Up " Width="645px" Font-Size="Large" />
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
        <br />
    
    </div>
    </form>
</body>
</html>
