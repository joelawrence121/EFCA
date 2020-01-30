<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EditMember.aspx.cs" Inherits="Home_EditMember" %>

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
            height: 50px;
        }
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
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblID" runat="server" Text="MemberID"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtID" runat="server" ReadOnly="True" Width="400px"></asp:TextBox>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblFirstName" runat="server" Text="First Name"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtFirstName" runat="server" Width="400px"></asp:TextBox>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblLastName" runat="server" Text="Last Name"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtLastName" runat="server" Width="400px"></asp:TextBox>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblEmail" runat="server" Text="Email"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtEmail" runat="server" Width="400px"></asp:TextBox>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblDOB" runat="server" Text="DOB"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtDOB" runat="server" Width="400px"></asp:TextBox>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblPayment" runat="server" Text="Payment"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlPayment" runat="server" AutoPostBack="True" Width="308px">
                                <asp:ListItem>Monthly</asp:ListItem>
                                <asp:ListItem>Per Session</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblPostcode" runat="server" Text="Post Code"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtPostcode" runat="server" Width="400px"></asp:TextBox>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblAddress" runat="server" Text="Address"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtAddress" runat="server" Width="400px"></asp:TextBox>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style2">
                            <asp:Label ID="lblMobile" runat="server" Text="Mobile"></asp:Label>
                        </td>
                        <td class="auto-style2">
                            <asp:TextBox ID="txtMobile" runat="server" Width="400px"></asp:TextBox>
                        </td>
                        <td class="auto-style2"></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="btnConfirm" runat="server" OnClick="btnConfirm_Click" Text="Confirm Changes" />
                        </td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblError" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="#FF3300" Text="Error in saving details, please check the fields." Visible="False"></asp:Label>
                            <br />
                            <asp:Label ID="lblSuccess" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="Lime" Text="Changes saved." Visible="False"></asp:Label>
                        </td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblOldPassword" runat="server" Text="Old Password"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblNewPassword" runat="server" Text="New Password"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtNewPassword" runat="server"></asp:TextBox>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="btnChangePassword" runat="server" OnClick="btnChangePassword_Click" Text="Change Password" />
                        </td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblErrorP" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="#FF3300" Text="Error in changing password." Visible="False"></asp:Label>
                            &nbsp;<asp:Label ID="lblErrorOld" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="#FF3300" Text="Old password not correct. " Visible="False"></asp:Label>
                            <br />
                            <asp:Label ID="lblSuccessP" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="Lime" Text="Password saved." Visible="False"></asp:Label>
                        </td>
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
