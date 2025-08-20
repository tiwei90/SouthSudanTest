<%@ Control Language="C#" Inherits="ConfigurationSite.usercontrol.login" Codebehind="login.ascx.cs" %>

<div id="portalCenterLogin">
    <div  id="setupLogin">
        <table style="width: 100%" border="0">
            <tr>
                <td style="width: 39px; height: 26px;">
                    <asp:Label ID="Label1" runat="server" CssClass="Label" Text="User Name" Width="70px" Height="20px"></asp:Label>
                </td>       
                <td style="width: 202px; height: 26px;">
                    <input id="txt_name" style="WIDTH: 116px" type="text" name="Text1" runat="server"/>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txt_name"
                        CssClass="label" ValidationExpression="([a-z]|[A-Z]|\d){1,99}">*</asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td style="width: 39px">
                    <asp:Label ID="Label2" runat="server" CssClass="Label" Text="Password"></asp:Label>
                </td>           
                <td style="width: 202px">
                    <asp:TextBox ID="txt_pwd" runat="server" Width="116px" TextMode="Password" CssClass="Label"></asp:TextBox>
                    <asp:RegularExpressionValidator
                        ID="RegularExpressionValidator1" runat="server" ControlToValidate="txt_pwd"
                        CssClass="label" ValidationExpression="([a-z]|[A-Z]|\d){1,99}">*</asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:ValidationSummary id="ValidationSummary1" runat="server" Width="160px" CssClass="Label" DisplayMode="List" HeaderText="Only decimal and character allow"></asp:ValidationSummary>
		            <asp:Label id="lblMsg" ForeColor="Red" runat="server" CssClass="Label" Visible="False" Width="190px">Error !</asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 39px">
                </td>
                <td style="width: 202px">
                    <asp:ImageButton ID="btn_login" runat="server" ImageUrl="~/images/btnLogin.gif" tabIndex="-1" OnClick="btn_login_Click"/>
                </td>
            </tr>
        </table>
    </div>
</div>
<asp:HiddenField ID="txtCompName" runat="server" />