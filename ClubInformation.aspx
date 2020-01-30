<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ClubInformation.aspx.cs" Inherits="Home_Club_Information" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
            border: 1px solid #000000;
        }
 p.MsoNormal
	{margin-top:0cm;
	margin-right:0cm;
	margin-bottom:8.0pt;
	margin-left:0cm;
	line-height:107%;
	font-size:11.0pt;
	font-family:"Calibri",sans-serif;
	}
        .auto-style2 {}
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
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblMainHeader" runat="server" Font-Bold="True" Font-Size="XX-Large" Font-Underline="True" Text="East Finchley Combat Academy"></asp:Label>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                            <asp:Label ID="lblLocation" runat="server" Text="Location:"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style2" rowspan="3">
                            <p class="MsoNormal">
                                <asp:Label ID="lblSubHeader" runat="server" Font-Bold="True" Text="Welcome to the East Finchley Combat Academy."></asp:Label>
                                <p class="MsoNormal">Whether you want to get fit and tone up, learn self-defence, wish to compete or are simply bored of doing the same old thing at the gym every day, this is the place for you. Juniors, adults, beginners through to seasoned fighters are all welcome. So weather you’re interested in non, semi or full contact training; we aim to provide the classes you require at all levels.<p class="MsoNormal" style="font-stretch: normal;font-variant-ligatures: normal;
font-variant-caps: normal;opacity: 1;orphans: 2;widows: 2;-webkit-text-stroke-width: 0px;
word-spacing:0px">
                                    We boast 2 dedicated Muay Thai instructors, a world no.1 Brazillian Jiu jitsu coach, two Strength and Conditioning coaches and a decorated MMA coach. Our fully equipped, totally refurbished gym contains a full array of training equipment such as kettle bells, gladiator walls, boxing ring, punch bags, boxing gloves, pads and shin guards, tractor tyres and a whole host more...<p class="MsoNormal" style="font-stretch: normal;font-variant-ligatures: normal;
font-variant-caps: normal;opacity: 1;orphans: 2;widows: 2;-webkit-text-stroke-width: 0px;
word-spacing:0px">
                                        Our competitive pricing structure means that you can attend any class and train in any discipline as often as you like for one fixed monthly cost or pay-as-you-go and pay for each class you attend.<p class="MsoNormal" style="font-stretch: normal;font-variant-ligatures: normal;
font-variant-caps: normal;opacity: 1;orphans: 2;widows: 2;-webkit-text-stroke-width: 0px;
word-spacing:0px">
                                            <asp:Label ID="lblSubHeader2" runat="server" Font-Bold="True" Text="How to use the online system:"></asp:Label>
                                            <p class="MsoNormal" style="font-stretch: normal;font-variant-ligatures: normal;
font-variant-caps: normal;opacity: 1;orphans: 2;widows: 2;-webkit-text-stroke-width: 0px;
word-spacing:0px">
                                                This new online system serves as a interface for you, the member, to view up to date information about the classes available in the week, products and general information about the club. By registering your details to the club, the instructors can more easily add you to attendance records for classes and look up your details if need be. <p class="MsoNormal" style="font-stretch: normal;font-variant-ligatures: normal;
font-variant-caps: normal;opacity: 1;orphans: 2;widows: 2;-webkit-text-stroke-width: 0px;
word-spacing:0px">
                                                    &nbsp;<p class="MsoNormal" style="font-stretch: normal;font-variant-ligatures: normal;
font-variant-caps: normal;opacity: 1;orphans: 2;widows: 2;-webkit-text-stroke-width: 0px;
word-spacing:0px">
                                                        This system is currently in testing, please excuse any bugs. New features in development: emailing, registering your interest in upcoming classes, suggestion boxes, news, updates, twitter feed and image feed.
                                                        <p class="MsoNormal" style="font-stretch: normal;font-variant-ligatures: normal;
font-variant-caps: normal;opacity: 1;orphans: 2;widows: 2;-webkit-text-stroke-width: 0px;
word-spacing:0px">
                                                            Have a suggestion or would like to report a bug? Please email <a href="mailto:joenoobish@hotmail.co.uk">joenoobish@hotmail.co.uk</a> .<p class="MsoNormal" style="font-stretch: normal;font-variant-ligatures: normal;
font-variant-caps: normal;opacity: 1;orphans: 2;widows: 2;-webkit-text-stroke-width: 0px;
word-spacing:0px">
                                                                &nbsp;<p class="MsoNormal" style="font-stretch: normal;font-variant-ligatures: normal;
font-variant-caps: normal;opacity: 1;orphans: 2;widows: 2;-webkit-text-stroke-width: 0px;
word-spacing:0px">
                                                                    &nbsp;</p>
                                                                <p>
                                                                </p>
                                                                <p>
                                                                </p>
                                                                <p>
                                                                </p>
                                                                <p>
                                                                </p>
                                                                <p>
                                                                </p>
                                                                <p>
                                                                </p>
                                                                <p>
                                                                </p>
                                                                <p>
                                                                </p>
                                                                <p>
                                                                </p>
                                                                <p>
                                                                </p>
                                                                <p>
                                                                </p>
                                                                <p>
                                                                </p>
                                                                <p>
                                                                </p>
                                                                <p>
                                                                </p>
                                                                <p>
                                                                </p>
                                                                <p>
                                                                </p>
                                                                <p>
                                                                </p>
                                                                <p>
                                                                </p>
                                                                <p>
                                                                </p>
                                                                <p>
                                                                </p>
                                                                <p>
                                                                </p>
                                                                <p>
                                                                </p>
                                                                <p>
                                                                </p>
                                                                <p>
                                                                </p>
                                                                <p>
                                                                </p>
                                                                <p>
                                                                </p>
                                                                <p>
                                                                </p>
                                                                <p>
                                                                </p>
                                                                <p>
                                                                </p>
                                                                <p>
                                                                </p>
                                                                <p>
                                                                </p>
                                                                <p>
                                                                </p>
                                                                <p>
                                                                </p>
                                                                <p>
                                                                </p>
                                                                <p>
                                                                </p>
                                                                <p>
                                                                </p>
                                                            </p>
                                                        </p>
                                                    </p>
                                                </p>
                                            </p>
                                        </p>
                                    </p>
                                    </p>
                                </p>
                            </p>
                        </td>
                        <td class="auto-style2" rowspan="2"><iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d2478.582454076178!2d-0.17193033483206718!3d51.5942155621738!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x48761a1eb10a9989%3A0x896871bd32fd9608!2sChurch+Ln%2C+London+N2+8DX!5e0!3m2!1sen!2suk!4v1510930422285" width="400" height="300" frameborder="0" style="border:0" allowfullscreen></iframe>

                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style2">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style2">
                            <asp:Label ID="Label5" runat="server" Font-Italic="True" ForeColor="#CCCCCC" Text="System created by Joseph Lawrence, 2017 as part of Computer Science Coursework"></asp:Label>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
        <br />
    
    </div>
    </form>
</body>
</html>
