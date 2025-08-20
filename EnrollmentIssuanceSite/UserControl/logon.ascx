<%@ Control Language="C#" AutoEventWireup="true" Inherits="EnrollmentIssuanceSite.UserControl.logon" Codebehind="logon.ascx.cs" %>

<div id="portalRightNavLogin">
    <div  id="setupLogin">
        <br/>
        <table style="width: 100%" border="0">
            <tr>
                <td colspan="2" style="height: 26px">
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Arial" Text="Welcome !"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="lbl_name" runat="server" CssClass="LabelHeadBlue" Height="20px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="height: 35px">
                    <asp:Label ID="lbl_msg" runat="server" CssClass="LabelHeadBlue" Width="210px" Height="21px"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
</div>