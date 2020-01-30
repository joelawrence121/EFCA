<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ConfirmOrder.aspx.cs" Inherits="Home_ConfirmOrder" %>

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
    
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <table class="auto-style1">
            <tr>
                <td>
                    <asp:Label ID="lblConfirm" runat="server" Font-Size="XX-Large" Text="Confirm your order of: "></asp:Label>
                    <asp:Label ID="lblQuantity" runat="server" Font-Bold="True" Font-Size="XX-Large"></asp:Label>
&nbsp;<asp:Label ID="lblProduct" runat="server" Font-Bold="True" Font-Size="XX-Large"></asp:Label>
                    <asp:Label ID="Label4" runat="server" Font-Bold="False" Font-Size="XX-Large" Text="/s:"></asp:Label>
                    <br />
                    <asp:Label ID="Label5" runat="server" Font-Size="XX-Large" Text="For £"></asp:Label>
                    <asp:Label ID="lblTotal" runat="server" Font-Bold="True" Font-Size="XX-Large"></asp:Label>
                    <asp:Label ID="Label7" runat="server" Font-Size="XX-Large" Text="."></asp:Label>
                    <br />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnConfirm" runat="server" Font-Size="X-Large" Text="Confirmed" OnClick="btnConfirm_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnCancel" runat="server" Font-Size="X-Large" OnClick="btnCancel_Click" Text="Cancel" />
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
        <br />
    
    </div>
    </form>
</body>
</html>
