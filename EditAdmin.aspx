<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EditAdmin.aspx.cs" Inherits="Home_EditAdmin" %>

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
    
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table class="auto-style1">
                    <tr>
                        <td>
                            <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" />
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblID" runat="server" Text="InstructorID" Font-Bold="True"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtID" runat="server" ReadOnly="True"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="margin-left: 80px">
                            <asp:Label ID="lblFirstName" runat="server" Text="First Name *"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="margin-left: 80px">
                            <asp:Label ID="lblLastName" runat="server" Text="Last Name *"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="margin-left: 80px">
                            <asp:Label ID="lblEmail" runat="server" Text="Email *"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="margin-left: 80px">
                            <asp:Label ID="lblDOB" runat="server" Text="DOB *"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtDOB" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="margin-left: 80px">
                            <asp:Label ID="lblPostcode" runat="server" Text="Postcode"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtPostcode" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="margin-left: 80px">
                            <asp:Label ID="lblAddress" runat="server" Text="Address"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="margin-left: 80px">
                            <asp:Label ID="lblMobile" runat="server" Text="Mobile"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtMobile" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="margin-left: 80px">
                            <asp:Button ID="btnConfirmChanges" runat="server" OnClick="btnConfirmChanges_Click" Text="Confirm Changes" />
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="margin-left: 80px">
                            <asp:Label ID="lblError" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="#FF3300" Text="Error in saving details, please check the fields." Visible="False"></asp:Label>
                            <br />
                            <asp:Label ID="lblSuccess" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="Lime" Text="Changes saved." Visible="False"></asp:Label>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="margin-left: 80px">
                            <asp:Label ID="lblOldPassword" runat="server" Text="Old Password"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="margin-left: 80px">
                            <asp:Label ID="lblNewPassword" runat="server" Text="New Password"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtNewPassword" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="margin-left: 80px">
                            <asp:Button ID="btnChangePassword" runat="server" OnClick="btnChangePassword_Click" Text="Change Password" />
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="margin-left: 80px">
                            <asp:Label ID="lblErrorP" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="#FF3300" Text="Error in changing password." Visible="False"></asp:Label>
                            &nbsp;
                            <asp:Label ID="lblErrorOld" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="#FF3300" Text="Old password not correct. " Visible="False"></asp:Label>
                            <br />
                            <asp:Label ID="lblSuccessP" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="Lime" Text="Password saved." Visible="False"></asp:Label>
                            <br />
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    <div>
    
    </div>
    </form>
</body>
</html>
