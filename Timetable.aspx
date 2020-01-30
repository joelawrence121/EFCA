<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Timetable.aspx.cs" Inherits="Timetable_Timetable" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style2 {
            width: 313px;
        }
        .auto-style8 {
            width: 307px;
        }
        .auto-style4 {
            height: 50px;
        }
        .auto-style9 {
            width: 307px;
            height: 50px;
        }
        .auto-style1 {
            width: 100%;
            border: 1px solid #000000;
        }
        .auto-style10 {
            height: 51px;
        }
        .auto-style11 {
            width: 307px;
            height: 51px;
        }
        .auto-style12 {
            width: 108px;
        }
        .auto-style13 {
            height: 50px;
            width: 108px;
        }
        .auto-style14 {
            height: 51px;
            width: 108px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                <br />
                <table class="auto-style1">
                    <tr>
                        <td class="auto-style12">
                            <asp:Button ID="btnBack0" runat="server" OnClick="btnBack_Click" Text="Back" />
                        </td>
                        <td class="auto-style2" colspan="2">
                            <asp:Label ID="Label34" runat="server" Font-Bold="True" Font-Size="XX-Large" Font-Underline="True" Text="Timetable"></asp:Label>
                        </td>
                        <td class="auto-style8">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style12">
                            &nbsp;</td>
                        <td class="auto-style2" colspan="2">
                            <asp:Label ID="lblAddHeader" runat="server" Font-Bold="True" Font-Italic="False" Font-Size="Large" Font-Underline="True" Text="Add New Lesson:"></asp:Label>
                        </td>
                        <td class="auto-style8">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style13">
                            &nbsp;</td>
                        <td class="auto-style4" colspan="2">
                            <asp:Label ID="lblClass" runat="server" Text="Class"></asp:Label>
                        </td>
                        <td class="auto-style9">
                            <asp:DropDownList ID="ddlClasses" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style12">
                            &nbsp;</td>
                        <td class="auto-style2" colspan="2">
                            <asp:Label ID="lblInstructor" runat="server" Text="Instructor"></asp:Label>
                        </td>
                        <td class="auto-style8">
                            <asp:DropDownList ID="ddlInstructors" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style12">
                            &nbsp;</td>
                        <td class="auto-style2" colspan="2">
                            <asp:Label ID="lblDuration" runat="server" Text="Duration (hours) eg: 1.5"></asp:Label>
                        </td>
                        <td class="auto-style8">
                            <asp:TextBox ID="txtDuration" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style12">
                            &nbsp;</td>
                        <td class="auto-style2" colspan="2">
                            <asp:Label ID="lblDay" runat="server" Text="Day"></asp:Label>
                        </td>
                        <td class="auto-style8">
                            <asp:DropDownList ID="ddlDays" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style13">
                            &nbsp;</td>
                        <td class="auto-style4" colspan="2">
                            <asp:Label ID="lblStart" runat="server" Text="Start Time (hh:mm) eg 13:00"></asp:Label>
                        </td>
                        <td class="auto-style9">
                            <asp:TextBox ID="txtStart" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style14">
                            &nbsp;</td>
                        <td class="auto-style10" colspan="2">
                            <asp:Button ID="btnAddLesson" runat="server" OnClick="btnAddLesson_Click" Text="Add Lesson" Width="300px" />
                            <br />
                            <asp:Label ID="lblError" runat="server" ForeColor="#FF3300" Text="ERROR, check field values" Visible="False"></asp:Label>
                        </td>
                        <td class="auto-style11">
                            </td>
                    </tr>
                    <tr>
                        <td class="auto-style13">
                            &nbsp;</td>
                        <td class="auto-style4">
                            &nbsp;</td>
                        <td class="auto-style4">
                            &nbsp;</td>
                        <td class="auto-style9">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style13">
                            &nbsp;</td>
                        <td class="auto-style4" colspan="2">
                            <asp:Label ID="lblMonday" runat="server" Font-Bold="True" Font-Size="X-Large" Text="Monday"></asp:Label>
                            &nbsp;<asp:GridView ID="gvDay1" runat="server" AutoGenerateSelectButton="True">
                                <SelectedRowStyle BackColor="#CCCCCC" />
                            </asp:GridView>
                            <br />
                            &nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnAttendance1" runat="server" OnClick="btnAttendance1_Click" Text="Record Attendance" Width="150px" />
                            &nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnDelete1" runat="server" OnClick="btnDelete1_Click" Text="Delete Lesson" Width="150px" OnClientClick="return confirm('Are you sure you want to delete this lesson? All attendance records will also be deleted. ')" />
                            &nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnRecords1" runat="server" OnClick="btnRecords1_Click" Text="View Attendance Records" Width="200px" />
                            <br />
                            <br />
                            <asp:Label ID="Label28" runat="server" Font-Bold="True" Font-Size="X-Large" Text="Tuesday"></asp:Label>
                            <asp:GridView ID="gvDay2" runat="server" AutoGenerateSelectButton="True">
                                <SelectedRowStyle BackColor="#CCCCCC" />
                            </asp:GridView>
                            <br />
                            &nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnAttendance2" runat="server" OnClick="btnAttendance2_Click" Text="Record Attendance" Width="150px" />
                            &nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnDelete2" runat="server" OnClick="btnDelete2_Click" Text="Delete Lesson" Width="150px" OnClientClick="return confirm('Are you sure you want to delete this lesson? All attendance records will also be deleted. ')"/>
                            &nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnRecords2" runat="server" OnClick="btnRecords2_Click" Text="View Attendance Records" Width="200px" />
                            <br />
                            <br />
                            <asp:Label ID="Label29" runat="server" Font-Bold="True" Font-Size="X-Large" Text="Wednesday"></asp:Label>
                            <asp:GridView ID="gvDay3" runat="server" AutoGenerateSelectButton="True">
                                <SelectedRowStyle BackColor="#CCCCCC" />
                            </asp:GridView>
                            <br />
                            &nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnAttendance3" runat="server" OnClick="btnAttendance3_Click" Text="Record Attendance" Width="150px" />
                            &nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnDelete3" runat="server" OnClick="btnDelete3_Click" Text="Delete Lesson" Width="150px" OnClientClick="return confirm('Are you sure you want to delete this lesson? All attendance records will also be deleted. ')"/>
                            &nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnRecords3" runat="server" OnClick="btnRecords3_Click" Text="View Attendance Records" Width="200px" />
                            <br />
                            <br />
                            <asp:Label ID="Label30" runat="server" Font-Bold="True" Font-Size="X-Large" Text="Thursday"></asp:Label>
                            <asp:GridView ID="gvDay4" runat="server" AutoGenerateSelectButton="True">
                                <SelectedRowStyle BackColor="#CCCCCC" />
                            </asp:GridView>
                            <br />
                            &nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnAttendance4" runat="server" OnClick="btnAttendance4_Click" Text="Record Attendance" Width="150px" />
                            &nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnDelete4" runat="server" OnClick="btnDelete4_Click" Text="Delete Lesson" Width="150px" OnClientClick="return confirm('Are you sure you want to delete this lesson? All attendance records will also be deleted. ')" />
                            &nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnRecords4" runat="server" OnClick="btnRecords4_Click" Text="View Attendance Records" Width="200px" />
                            <br />
                            <br />
                            <asp:Label ID="Label31" runat="server" Font-Bold="True" Font-Size="X-Large" Text="Friday"></asp:Label>
                            <asp:GridView ID="gvDay5" runat="server" AutoGenerateSelectButton="True">
                                <SelectedRowStyle BackColor="#CCCCCC" />
                            </asp:GridView>
                            <br />
                            &nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnAttendance5" runat="server" OnClick="btnAttendance5_Click" Text="Record Attendance" Width="150px" />
                            &nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnDelete5" runat="server" OnClick="btnDelete5_Click" Text="Delete Lesson" Width="150px" OnClientClick="return confirm('Are you sure you want to delete this lesson? All attendance records will also be deleted. ')"/>
                            &nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnRecords5" runat="server" OnClick="btnRecords5_Click" Text="View Attendance Records" Width="200px" />
                            <br />
                            <br />
                            <asp:Label ID="Label32" runat="server" Font-Bold="True" Font-Size="X-Large" Text="Saturday"></asp:Label>
                            <asp:GridView ID="gvDay6" runat="server" AutoGenerateSelectButton="True">
                                <SelectedRowStyle BackColor="#CCCCCC" />
                            </asp:GridView>
                            <br />
                            &nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnAttendance6" runat="server" OnClick="btnAttendance6_Click" Text="Record Attendance" Width="150px" />
                            &nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnDelete6" runat="server" OnClick="btnDelete6_Click" Text="Delete Lesson" Width="150px" OnClientClick="return confirm('Are you sure you want to delete this lesson? All attendance records will also be deleted. ')" />
                            &nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnRecords6" runat="server" OnClick="btnRecords6_Click" Text="View Attendance Records" Width="200px" />
                            <br />
                            <br />
                            <asp:Label ID="Label33" runat="server" Font-Bold="True" Font-Size="X-Large" Text="Sunday"></asp:Label>
                            <asp:GridView ID="gvDay7" runat="server" AutoGenerateSelectButton="True" OnSelectedIndexChanged="GridView7_SelectedIndexChanged">
                                <SelectedRowStyle BackColor="#CCCCCC" />
                            </asp:GridView>
                            <br />
                            &nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnAttendance7" runat="server" OnClick="btnAttendance7_Click" Text="Record Attendance" Width="150px" />
                            &nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnDelete7" runat="server" OnClick="btnDelete7_Click" Text="Delete Lesson" Width="150px" OnClientClick="return confirm('Are you sure you want to delete this lesson? All attendance records will also be deleted. ')" />
                            &nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnRecords7" runat="server" OnClick="btnRecords7_Click" Text="View Attendance Records" Width="200px" />
                            <br />
                            <br />
                        </td>
                        <td class="auto-style4">
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    
    </div>
    </form>
</body>
</html>
