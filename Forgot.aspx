<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Forgot.aspx.cs" Inherits="Home_Forgot" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style3 {
            height: 60px;
        }
        .auto-style2 {
            height: 94px;
        }
        .auto-style1 {
            width: 100%;
            border: 1px solid #000000;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    <div>
    
                <table class="auto-style1">
                    <tr>
                        <td class="auto-style3">
                            <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style2">
                            <asp:Label ID="lblHeader" runat="server" Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Size="XX-Large" Font-Underline="True" Text="Forgotten your password or ID? "></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblDescription" runat="server" Text="Please talk to one of the instructors to gain your ID, if you have forgotten your password, sign up again."></asp:Label>
                            <br />
                            <br />
                            <br />
                        </td>
                    </tr>
                </table>
        <br />
    
    </div>
    
    </div>
    </form>
</body>
</html>
