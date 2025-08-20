<%@ Page Language="C#" AutoEventWireup="true" Inherits="EnrollmentIssuanceSite.UsercontrolErrorPage" Codebehind="ErrorPage.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
		<title>Visa - Enrollment and Issuance System - v1.0.0</title>
		<meta http-equiv='REFRESH' content='2;URL=default.aspx'/>
		<link href="inc/main.css" type="text/css" rel="stylesheet"/>
		<script type="text/javascript" src="inc/CSJSRequestObject.js"></script>
		<script type="text/JavaScript">
            javascript:window.history.forward(2);
		</script>
	</head>
	<body>
		<form id="Form1" method="post" runat="server">
			<asp:Label id="Label1" style="Z-INDEX: 101; LEFT: 160px; POSITION: absolute; TOP: 88px" runat="server"
				CssClass="Label" ForeColor="Blue" Width="100%"> Error occurs when trying to proceed!</asp:Label>
			<asp:Label id="Label2" style="Z-INDEX: 102; LEFT: 160px; POSITION: absolute; TOP: 120px" runat="server"
				CssClass="Label" ForeColor="Blue">Redirecting to Login page</asp:Label>
			<asp:Image id="Image1" style="Z-INDEX: 103; LEFT: 304px; POSITION: absolute; TOP: 124px" runat="server"
				ImageUrl="./images/logout.gif" Height="8px"></asp:Image>
		</form>
	</body>
</html>
