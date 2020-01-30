<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Attendance.aspx.cs" Inherits="Home_Attendance" %>

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
                        <td>
                            <asp:Label ID="lblMainHeader" runat="server" Font-Bold="True" Font-Size="X-Large" Font-Underline="True" Text="Record Attendance"></asp:Label>
                        </td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblIDDetails" runat="server" Font-Bold="True" Font-Underline="True" Text="ID Details"></asp:Label>
                        </td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblLID" runat="server" Text="LessonID"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblLessonID" runat="server" Font-Bold="True"></asp:Label>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblIID" runat="server" Text="InstructorID"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblInstructorID" runat="server" Font-Bold="True"></asp:Label>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblCID" runat="server" Text="ClassID"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblClassID" runat="server" Font-Bold="True"></asp:Label>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblAttendanceHeader" runat="server" Font-Bold="True" Font-Size="Large" Text="Take Attendance For: "></asp:Label>
                        </td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:GridView ID="gvLesson" runat="server" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black">
                                <FooterStyle BackColor="#CCCCCC" />
                                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                                <RowStyle BackColor="White" />
                                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                <SortedAscendingHeaderStyle BackColor="#808080" />
                                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                <SortedDescendingHeaderStyle BackColor="#383838" />
                            </asp:GridView>
                        </td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style2">
                            <asp:Label ID="lblConfirm" runat="server" Font-Bold="True" Font-Size="Large" Font-Underline="True" Text="Confirm Attendance Records:"></asp:Label>
                        </td>
                        <td class="auto-style2">&nbsp;</td>
                        <td class="auto-style2">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style2">
                            <asp:Label ID="lblDate" runat="server" Font-Bold="True" Text="Date dd/mm/yyyy"></asp:Label>
                            &nbsp;<asp:TextBox ID="txtDate" runat="server" OnTextChanged="txtDate_TextChanged"></asp:TextBox>
                            &nbsp;<asp:Button ID="btnToday" runat="server" OnClick="btnToday_Click" Text="Today" />
                            &nbsp;
                            <asp:Label ID="lblDateError" runat="server" Font-Bold="True" ForeColor="Red" Text="Error in date format" Visible="False"></asp:Label>
                            <br />
                        </td>
                        <td class="auto-style2"></td>
                        <td class="auto-style2"></td>
                    </tr>
                    <tr>
                        <td class="auto-style2">
                            <asp:Label ID="lblMemberHead" runat="server" Font-Bold="True" Text="Member: " Visible="False"></asp:Label>
                            <asp:GridView ID="gvRecordMember" runat="server" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Horizontal">
                                <AlternatingRowStyle BackColor="#F7F7F7" />
                                <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                                <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
                                <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                                <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                                <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
                                <SortedAscendingCellStyle BackColor="#F4F4FD" />
                                <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
                                <SortedDescendingCellStyle BackColor="#D8D8F0" />
                                <SortedDescendingHeaderStyle BackColor="#3E3277" />
                            </asp:GridView>
                            <br />
                            <asp:Button ID="btnMonthly" runat="server" Text="Take Monthly Payment" Visible="False" OnClick="btnMonthly_Click" />
                            <br />
                            <asp:TextBox ID="txtAmount" runat="server" Visible="False" Width="100px"></asp:TextBox>
                            &nbsp;&nbsp;<asp:Label ID="lblAmount" runat="server" Font-Bold="True" Text="Payment Due" Visible="False"></asp:Label>
                            <br />
                            <asp:CheckBox ID="cbPaid" runat="server" Font-Bold="True" Text="Paid" Visible="False" />
                            <br />
                            <br />
                            <asp:Button ID="btnRecord" runat="server" Text="Record" OnClick="btnRecord_Click" Visible="False" />
                            <br />
                            <asp:Label ID="lblSaved" runat="server" Font-Bold="True" ForeColor="#00CC00" Text="Success" Visible="False"></asp:Label>
                            <br />
                            <asp:Label ID="lblError" runat="server" Font-Bold="True" ForeColor="#CC0000" Text="Error" Visible="False"></asp:Label>
                        </td>
                        <td class="auto-style2">
                            <asp:Label ID="lblList0" runat="server" Font-Bold="True" Font-Size="Large" Font-Underline="True" Text="Saved Attendance:"></asp:Label>
                            <br />
                            <asp:Button ID="btnSort0" runat="server" OnClick="btnSort_Click" Text="Sort by IDs" />
                            <br />
                            <asp:GridView ID="gvAttendance" runat="server" AutoGenerateSelectButton="True" HorizontalAlign="Left" OnSelectedIndexChanged="gvAttendance_SelectedIndexChanged">
                            </asp:GridView>
                        </td>
                        <td class="auto-style2">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style2">
                            <asp:Label ID="lblMembers" runat="server" Font-Bold="True" Text="Members:"></asp:Label>
                        </td>
                        <td class="auto-style2">
                            &nbsp;</td>
                        <td class="auto-style2">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style2">
                            <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>
                            &nbsp;&nbsp;
                            <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="Search" />
                        </td>
                        <td class="auto-style2">
                            &nbsp;</td>
                        <td class="auto-style2"></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:GridView ID="gvMembers" runat="server" AutoGenerateSelectButton="True" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="gvMembers_SelectedIndexChanged">
                                <AlternatingRowStyle BackColor="White" />
                                <EditRowStyle BackColor="#7C6F57" />
                                <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#E3EAEB" />
                                <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                                <SortedAscendingCellStyle BackColor="#F8FAFA" />
                                <SortedAscendingHeaderStyle BackColor="#246B61" />
                                <SortedDescendingCellStyle BackColor="#D4DFE1" />
                                <SortedDescendingHeaderStyle BackColor="#15524A" />
                            </asp:GridView>
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>&nbsp;&nbsp;&nbsp; </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
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
