<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdminHome.aspx.cs" Inherits="Home_Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
            border: 1px solid #FFFFFF;
        }
        .auto-style2 {
            width: 649px;
        }
        .auto-style3 {
            height: 78px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <table class="auto-style1">
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="lblMainHeader" runat="server" Font-Bold="True" Font-Size="X-Large" Text="EFCA Database Management System"></asp:Label>
                </td>
                <td>Welcome,
                    <asp:Label ID="lblFirstName" runat="server" Font-Bold="True"></asp:Label>
                    <br />
                    ID:
                    <asp:Label ID="lblLastName" runat="server" Font-Bold="True"></asp:Label>
                    <br />
                    <asp:Button ID="btnLogOut" runat="server" OnClick="btnLogOut_Click" Text="Log out" />
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Admin</td>
                <td>
                    <asp:LinkButton ID="lbtnChangeDetails" runat="server" OnClick="lbtnChangeDetails_Click">Change Details</asp:LinkButton>
                </td>
            </tr>
            <tr>
                <td class="auto-style2" rowspan="4">
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Home/Images/logo.jpg" />
                </td>
                <td style="margin-left: 120px">
                    <asp:Button ID="btnTimetable" runat="server" Text="Timetable" Width="230px" OnClick="btnTimetable_Click" Font-Size="Large" Height="50px" />
                &nbsp;&nbsp;
                    <asp:Button ID="btnClasses" runat="server" Text="Classes" Width="230px" OnClick="btnClasses_Click" Font-Size="Large" Height="50px" />
                </td>
            </tr>
            <tr>
                <td style="margin-left: 120px">
                    <asp:Button ID="btnMembers" runat="server" Text="Members" Width="230px" OnClick="btnMembers_Click" Font-Size="Large" Height="50px" />
                &nbsp;&nbsp;
                    <asp:Button ID="btnInstructors" runat="server" Text="Instructors" Width="230px" OnClick="btnInstructors_Click" Font-Size="Large" Height="50px" />
                </td>
            </tr>
            <tr>
                <td style="margin-left: 120px">
                    <asp:Button ID="btnTransactions" runat="server" Text="Recent Transactions" Width="230px" OnClick="btnTransactions_Click" Font-Size="Large" Height="50px" />
                &nbsp;&nbsp;
                    <asp:Button ID="btnClubStats" runat="server" OnClick="btnClubStats_Click" Text="Club Statistics" Width="230px" Font-Size="Large" Height="50px" />
                </td>
            </tr>
            <tr>
                <td style="margin-left: 120px">
                    <asp:Button ID="btnProducts" runat="server" Text="Products" Width="230px" OnClick="btnProducts_Click" Font-Size="Large" Height="50px" />
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
