<%@ Register Src="usercontrol/login.ascx" TagName="login" TagPrefix="uc2" %>
<%@ Register Src="usercontrol/header_main.ascx" TagName="header_main" TagPrefix="uc1" %>

<%@ Page Language="C#" Inherits="Default" Codebehind="Default.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Visa - System Configuration</title>
    <link href="inc/main.css" rel="stylesheet" type="text/css" />   
    <link href="inc/menuitem.css" rel="stylesheet" type="text/css" />   
</head>
<body>
    <form id="form1" runat="server" method="post" >
        <uc1:header_main ID="Header1" runat="server" /> 
        <uc2:login ID="Login1" runat="server" />
    </form>
    <script type="javascript">
		document.getElementById('Login1_btn_login').focus();
    </script>
</body>
</html>
