<%@ Page Language="C#" AutoEventWireup="true" Inherits="Logon" Codebehind="Logon.aspx.cs" %>

<%@ Register Src="usercontrol/logonContent.ascx" TagName="logonContent" TagPrefix="uc4" %>
<%@ Register Src="usercontrol/header.ascx" TagName="header" TagPrefix="uc1" %>
<%@ Register Src="usercontrol/logon.ascx" TagName="logon" TagPrefix="uc3" %>
<%@ Register Src="usercontrol/Version.ascx" TagName="version" TagPrefix="uc5" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Visa - System Configuration</title>
    <link href="inc/main.css" rel="stylesheet" type="text/css" />   
    <link href="inc/menuitem.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <uc1:header ID="Header1" runat="server" />
            <uc3:logon ID="Logon1" runat="server" />
            <uc4:logonContent ID="LogonContent1" runat="server" />
            <uc5:version ID="Version1" runat="server" />
        </div>
    </form>
</body>
</html>

