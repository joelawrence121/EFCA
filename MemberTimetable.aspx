<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MemberTimetable.aspx.cs" Inherits="Home_MemberTimetable" %>

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
            width: 313px;
        }
        .auto-style4 {
            height: 50px;
        }
        .auto-style9 {
            width: 307px;
            height: 50px;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
                <table class="auto-style1">
                    <tr>
                        <td class="auto-style2">
                            <asp:Button ID="btnBack" runat="server" OnClick="btnBack_Click" Text="Back" />
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style2">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style9">
                            <asp:Label ID="lblMainHeader" runat="server" Font-Bold="True" Font-Size="XX-Large" Font-Underline="True" Text="Timetable"></asp:Label>
                            <br />
                            <asp:Label ID="lblInformation" runat="server" Text="View the lessons available in the week."></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style4">
                            <asp:Label ID="lblMonday" runat="server" Font-Bold="True" Font-Size="X-Large" Text="Monday"></asp:Label>
                            &nbsp;<asp:GridView ID="gvMonday" runat="server" Width="1000px">
                                <HeaderStyle BackColor="Silver" Font-Bold="True" Font-Size="Large" Font-Underline="False" ForeColor="Black" />
                                <RowStyle Font-Bold="False" Font-Size="Large" HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="#CCCCCC" />
                            </asp:GridView>
                            &nbsp;&nbsp;&nbsp;&nbsp;
                            &nbsp;&nbsp;&nbsp;
                            <br />
                            <br />
                            <asp:Label ID="lblTuesday" runat="server" Font-Bold="True" Font-Size="X-Large" Text="Tuesday"></asp:Label>
                            <br />
                            <asp:GridView ID="gvTuesday" runat="server" Width="1000px">
                                <HeaderStyle BackColor="Silver" Font-Bold="True" Font-Size="Large" Font-Underline="False" ForeColor="Black" />
                                <RowStyle Font-Bold="False" Font-Size="Large" HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="#CCCCCC" />
                            </asp:GridView>
                            &nbsp;&nbsp;&nbsp;&nbsp;
                            &nbsp;&nbsp;&nbsp;
                            <br />
                            <br />
                            <asp:Label ID="lblWednesday" runat="server" Font-Bold="True" Font-Size="X-Large" Text="Wednesday"></asp:Label>
                            &nbsp;
                            &nbsp;&nbsp;&nbsp;&nbsp;
                            &nbsp;&nbsp;&nbsp;
                            <br />
                            <asp:GridView ID="gvWednesday" runat="server" Width="1000px">
                                <HeaderStyle BackColor="Silver" Font-Bold="True" Font-Size="Large" Font-Underline="False" ForeColor="Black" />
                                <RowStyle Font-Bold="False" Font-Size="Large" HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="#CCCCCC" />
                            </asp:GridView>
                            <br />
                            <br />
                            <asp:Label ID="lblThursday" runat="server" Font-Bold="True" Font-Size="X-Large" Text="Thursday"></asp:Label>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            &nbsp;&nbsp;&nbsp;
                            <br />
                            <asp:GridView ID="gvThursday" runat="server" Width="1000px">
                                <HeaderStyle BackColor="Silver" Font-Bold="True" Font-Size="Large" Font-Underline="False" ForeColor="Black" />
                                <RowStyle Font-Bold="False" Font-Size="Large" HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="#CCCCCC" />
                            </asp:GridView>
                            <br />
                            <br />
                            <asp:Label ID="lblFriday" runat="server" Font-Bold="True" Font-Size="X-Large" Text="Friday"></asp:Label>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            &nbsp;&nbsp;&nbsp;
                            <br />
                            <asp:GridView ID="gvFriday" runat="server" Width="1000px">
                                <HeaderStyle BackColor="Silver" Font-Bold="True" Font-Size="Large" Font-Underline="False" ForeColor="Black" />
                                <RowStyle Font-Bold="False" Font-Size="Large" HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="#CCCCCC" />
                            </asp:GridView>
                            <br />
                            <br />
                            <asp:Label ID="lblSaturday" runat="server" Font-Bold="True" Font-Size="X-Large" Text="Saturday"></asp:Label>
                            &nbsp;&nbsp;&nbsp;
                            &nbsp;<br />
                            <asp:GridView ID="gvSaturday" runat="server" Width="1000px">
                                <HeaderStyle BackColor="Silver" Font-Bold="True" Font-Size="Large" Font-Underline="False" ForeColor="Black" />
                                <RowStyle Font-Bold="False" Font-Size="Large" HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="#CCCCCC" />
                            </asp:GridView>
                            &nbsp;&nbsp;
                            <br />
                            <br />
                            <asp:Label ID="lblSunday" runat="server" Font-Bold="True" Font-Size="X-Large" Text="Sunday"></asp:Label>
                            &nbsp;&nbsp;<br />
                            <asp:GridView ID="gvSunday" runat="server" Width="1000px">
                                <HeaderStyle BackColor="Silver" Font-Bold="True" Font-Size="Large" Font-Underline="False" ForeColor="Black" />
                                <RowStyle Font-Bold="False" Font-Size="Large" HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="#CCCCCC" />
                            </asp:GridView>
                            &nbsp;
                            &nbsp;&nbsp;&nbsp;
                            <br />
                            <br />
                        </td>
                    </tr>
                </table>
    
    </div>
    </form>
</body>
</html>
