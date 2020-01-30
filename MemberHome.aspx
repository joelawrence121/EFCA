<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MemberHome.aspx.cs" Inherits="Home_MemberHome" %>

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
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table class="auto-style1">
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="lblMainHeader" runat="server" Font-Bold="True" Font-Size="X-Large" Text="EFCA Database Management System"></asp:Label>
                </td>
                <td>Welcome,
                    <asp:Label ID="lblMemberName" runat="server" Font-Bold="True"></asp:Label>
                    <br />
                    <asp:Label ID="Label3" runat="server" Text="ID: "></asp:Label>
                    <asp:Label ID="lblID" runat="server" Font-Bold="True"></asp:Label>
                    <br />
                    <asp:Button ID="btnLogOut" runat="server" OnClick="btnLogOut_Click" Text="Log out" />
                &nbsp;
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Member</td>
                <td>
                    <asp:LinkButton ID="lbtnChangeDetails" runat="server" OnClick="lbtnChangeDetails_Click">Change Details</asp:LinkButton>
                </td>
            </tr>
            <tr>
                <td class="auto-style2" rowspan="4">
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Home/Images/logo.jpg" />
                </td>
                <td>
                    <asp:Button ID="btnClubInfo" runat="server" OnClick="btnClubInfo_Click" Text="Club Information" Width="300px" Font-Size="X-Large" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnTimetable" runat="server" Text="View Timetable" Width="300px" OnClick="btnTimetable_Click" Font-Size="X-Large" />
                </td>
            </tr>
            <tr>
                <td style="margin-left: 120px">
                    <asp:Button ID="btnClasses" runat="server" Text="Classes Available" Width="300px" OnClick="btnClasses_Click" Font-Size="X-Large" />
                </td>
            </tr>
            <tr>
                <td style="margin-left: 120px">
                    <asp:Button ID="btnProducts" runat="server" Text="View and Order Products" Width="300px" OnClick="btnProducts_Click" Font-Size="X-Large" />
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
