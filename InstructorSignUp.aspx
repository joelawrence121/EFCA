<%@ Page Language="C#" AutoEventWireup="true" CodeFile="InstructorSignUp.aspx.cs" Inherits="Home_InstructorSignUp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">


        .auto-style1 {
            width: 100%;
            border-style: none;
            border-width: 6px;
            background-color: #A0A0A0;
        }
        .auto-style2 {
            height: 50px;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
                <table class="auto-style1" >
                    <tr>
                        <td>
                            <asp:Button ID="btnBack" runat="server" OnClick="btnBack_Click" Text="Back" />
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="lblMainHeader" runat="server" Font-Bold="True" Font-Size="XX-Large" Font-Underline="True" Text="Register a New Instructor"></asp:Label>
                            <br />
                            * Required fields.</td>
                    </tr>
                    <tr>
                        <td>First Name *</td>
                        <td>
                            <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Last Name *</td>
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
                        <td>DOB (dd/mm/yyyy) *</td>
                        <td>
                            <asp:TextBox ID="txtDOB" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Postcode </td>
                        <td>
                            <asp:TextBox ID="txtPostcode" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblAddress" runat="server" Text="Address"></asp:Label>
                            &nbsp;</td>
                        <td>
                            <br />
                            <asp:TextBox ID="txtAddressLine1" runat="server"></asp:TextBox>
                            <br />
                            <asp:TextBox ID="txtAddressLine2" runat="server"></asp:TextBox>
                            <br />
                            <asp:TextBox ID="txtAddressLine3" runat="server"></asp:TextBox>
                            <br />
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td>Mobile </td>
                        <td>
                            <asp:TextBox ID="txtMobile" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblPassword" runat="server" Text="Password"></asp:Label>
                            &nbsp;*</td>
                        <td>
                            <asp:TextBox ID="txtPassword" runat="server" OnTextChanged="TextBox9_TextChanged"></asp:TextBox>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Label ID="lblPasswordError" runat="server" Text="Label" Visible="False" Font-Italic="True"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblConfirm" runat="server" Text="Confirm Password"></asp:Label>
                        &nbsp;*</td>
                        <td>
                            <asp:TextBox ID="txtConfirmPW" runat="server"></asp:TextBox>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblError0" runat="server" ForeColor="Red" Text="Please enter the required fields." Visible="False" Font-Bold="True" Font-Size="X-Large"></asp:Label>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="btnConfirm" runat="server" OnClick="btnConfirm_Click" Text="Sign Up" />
                        </td>
                        <td>
                            <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="Cancel" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" class="auto-style2">
                            <asp:Label ID="lblSuccess" runat="server" ForeColor="#00CC00" Text="Sign up successful! " Visible="False" Font-Bold="True" Font-Size="X-Large"></asp:Label>
                            <br />
                            <asp:Label ID="lblError" runat="server" ForeColor="Red" Text="Error in signing up, please try again. " Visible="False" Font-Bold="True" Font-Size="X-Large"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style2" colspan="2">
                            <asp:GridView ID="gvID" runat="server" Visible="False">
                            </asp:GridView>
                            <asp:Label ID="lblInformation" runat="server" Text="Please note your InstructorID, this will allow you to login in conjunction with your password. " Visible="False"></asp:Label>
                            <br />
                        </td>
                    </tr>
                </table>
    
    </div>
    </form>
</body>
</html>
