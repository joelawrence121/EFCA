<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SignUp.aspx.cs" Inherits="Home_SignUp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">

        .auto-style1 {
            width: 100%;
            border-style: none;
            border-width: 6px;
            background-color: #c0c0c0;
        }
        .auto-style2 {
            height: 50px;
        }
        .auto-style3 {
            height: 83px;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <br />
        <asp:Button ID="btnBack" runat="server" OnClick="btnBack_Click" Text="Back" />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table class="auto-style1">
                    <tr>
                        <td>
                            <asp:Label ID="lblRegisterHeader" runat="server" Font-Bold="True" Font-Size="XX-Large" Font-Underline="True" Text="Register as a Member"></asp:Label>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>First Name*</td>
                        <td>
                            <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Last Name*</td>
                        <td>
                            <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblEmail" runat="server" Text="Email"></asp:Label>
                            &nbsp;*</td>
                        <td>
                            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>DOB*</td>
                        <td>
                            <asp:TextBox ID="txtDOB" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Payment*</td>
                        <td>
                            <asp:DropDownList ID="ddlPayment" runat="server" AutoPostBack="True" Width="308px">
                                <asp:ListItem>Monthly</asp:ListItem>
                                <asp:ListItem>Per Session</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>Postcode</td>
                        <td>
                            <asp:TextBox ID="txtPostcode" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblAddress" runat="server" Text="Address"></asp:Label>
                            </td>
                        <td>
                            <asp:TextBox ID="txtAddress1" runat="server"></asp:TextBox>
                            <br />
                            <asp:TextBox ID="txtAddress2" runat="server"></asp:TextBox>
                            <br />
                            <asp:TextBox ID="txtAddress3" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style3">Mobile</td>
                        <td class="auto-style3">
                            <asp:TextBox ID="txtMobile" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblPW" runat="server" Text="Password"></asp:Label>
                            *</td>
                        <td>
                            <asp:TextBox ID="txtPassword" runat="server" OnTextChanged="TextBox9_TextChanged"></asp:TextBox>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Label ID="lblPWError" runat="server" Visible="False"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblConfirmPW" runat="server" Text="Confirm Password"></asp:Label>
                            *</td>
                        <td>
                            <asp:TextBox ID="txtConfirmPassword" runat="server"></asp:TextBox>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="btnSignUp" runat="server" OnClick="btnSignUp_Click" Text="Sign Up" />
                        </td>
                        <td>
                            <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="Cancel" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" class="auto-style2">
                            <asp:Label ID="lblError" runat="server" ForeColor="Red" Text="Error in signing up, please try again. " Visible="False" Font-Bold="True" Font-Size="X-Large"></asp:Label>
                            <br />
                            <asp:Label ID="lblSuccess" runat="server" Font-Bold="True" Font-Size="X-Large" ForeColor="#003300" Text="Sign up successful! " Visible="False"></asp:Label>
                            <br />
                            <asp:Label ID="lblInformation" runat="server" Font-Bold="True" Font-Size="Large" Text="Please note your MemberID, this will allow you to login in conjunction with your password. " Visible="False"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style2" colspan="2">
                            <asp:GridView ID="gvID" runat="server" Visible="False">
                            </asp:GridView>
                            <br />
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
        </asp:UpdateProgress>
        <br />
    </form>
</body>
</html>
