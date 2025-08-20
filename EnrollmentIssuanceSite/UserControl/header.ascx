<%@ Control Language="C#" AutoEventWireup="true" Inherits="EnrollmentIssuanceSite.UserControl.IncHeader" Codebehind="header.ascx.cs" %>

<script src="inc/common.js" type="text/javascript"></script>

<table border="0" cellpadding="0" cellspacing="0" class="Header1">
		<tr>
			<td  style="background-image:url(./images/header.gif); width: 990px; height: 19px;" colspan="1" rowspan="1">
                <table border="0" cellpadding="0" cellspacing="0" style="display: inline; left: 247px;
                    position: absolute; top: 30px; width: 600px;">
                    <tr>
                        <td style="text-align:center; color: #000000; font-family:Tahoma;font-size:20px; height: 35px;font-weight:bold;">
                            Visa Enrollemnt and Issuance System
                        </td>
                    </tr>                   
                </table>
            </td>
		</tr>
</table>
<table cellpadding="0" cellspacing="0" class="Header2" border="0">
	<tr>
        <td style="background-image: url(./images/bar_left.gif); width: 12px; height: 33px">
        </td>
		<td style="height:26px; BACKGROUND-IMAGE: url(./images/bar_body.gif)" colspan="2"></td>
		<td align="center" style="width:200px; height:33px; BACKGROUND-IMAGE: url(./images/tab1.gif)">
			<asp:hyperlink id="HLServices" runat="server" ForeColor="Black" Font-Size="13px" Font-Bold="True" BackColor="Transparent" CssClass="url" NavigateUrl="../Logon.aspx">Home</asp:hyperlink>
        </td>
		<td id="tdLogout" align="center" style="width:189px; height:33px;BACKGROUND-IMAGE: url(./images/tab1.gif)">
            <asp:LinkButton ID="btnLogout" runat="server" CssClass="url" Font-Bold="True" OnClientClick="ConfirmLogout();" OnClick="btnLogout_Click" CausesValidation="False">Logout</asp:LinkButton>
        </td>
        <td style="background-image: url(./images/bar_right.gif); width: 11px; height: 33px">
        </td>
	</tr>
</table>
<script type="text/javascript">
    function ConfirmLogout()
    {
        if (!confirm('Are you sure you want to logout?')) 
        {
            return false;
        }
        else
        {      
            return true;
        }
    }
</script>