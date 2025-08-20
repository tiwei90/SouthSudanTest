<%@ Page Language="C#" AutoEventWireup="true" Inherits="EnrollmentIssuanceSite.ApprovalHistory" Codebehind="ApprovalHistory.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <link href="inc/main.css"  type="text/css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table cellpadding="1" cellspacing="2" border="0" >
        <tr>
            <td style="width: 9px">
                <asp:Label ID="Label13" runat="server" CssClass="Label" Text="Application ID" Width="99px"></asp:Label></td>
            <td>
                :</td>
            <td style="width: 510px">
                <asp:Label ID="lblAppID" runat="server" CssClass="Label" Text="-" Width="268px"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 9px">
                <asp:Label ID="Label12" runat="server" CssClass="Label" Text="Level"></asp:Label></td>
            <td>
                :</td>
            <td style="width: 510px">
                <asp:Label ID="lblLevel" runat="server" CssClass="Label" Text="-" Width="268px"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 9px">
                <asp:Label ID="Label16" runat="server" CssClass="Label" Text="Status"></asp:Label></td>
            <td>
                :</td>
            <td style="width: 510px">
                <asp:Label ID="lblStatus" runat="server" CssClass="Label" Text="-" Width="268px"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 9px">
                <asp:Label ID="Label18" runat="server" CssClass="Label" Text="Update By" Width="70px"></asp:Label></td>
            <td>
                :</td>
            <td style="width: 510px">
                <asp:Label ID="lblUpdatedBy" runat="server" CssClass="Label" Text="-" Width="268px"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 9px; height: 21px">
                <asp:Label ID="Label19" runat="server" CssClass="Label" Text="Updated Time" Width="107px"></asp:Label></td>
            <td style="height: 21px">
                :</td>
            <td style="width: 510px; height: 21px">
                <asp:Label ID="lblUpdatedTime" runat="server" CssClass="Label" Text="-" Width="268px"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 9px">
                <asp:Label ID="Label20" runat="server" CssClass="Label" Text="Location"></asp:Label></td>
            <td>
                :</td>
            <td style="width: 510px">
                <asp:Label ID="lblLocation" runat="server" CssClass="Label" Text="-" Width="268px"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 9px; height: 10px;">
            </td>
            <td>
            </td>
            <td style="width: 510px">
            </td>
        </tr>
        <tr>
            <td colspan="3" style="height: 19px; background-color: #c6efef">
                <asp:Label ID="Label108" runat="server" CssClass="LabelHeadGreen" Text="Details"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 9px; height: 21px;">
                <asp:Label ID="Label1" runat="server" Text="Duration" CssClass="Label"></asp:Label>
            </td>
            <td style="height: 21px;">:</td>
            <td style="width: 510px; height: 21px;">
                <asp:Label ID="lblDuration" runat="server" Text="-" Width="266px" CssClass="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 9px">
                <asp:Label ID="Label2" runat="server" Text="DOC" CssClass="Label"></asp:Label>
            </td>
            <td>:</td>
            <td style="width: 510px">
                <asp:Label ID="lblDOC" runat="server" Text="-" Width="266px" CssClass="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 9px">
                <asp:Label ID="Label10" runat="server" Text="Fee Category" CssClass="Label" Width="78px"></asp:Label></td>
            <td>
                :</td>
            <td style="width: 510px">
                <asp:Label ID="lblFeeCategory" runat="server" CssClass="Label" Text="-" Width="268px"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 9px">
                <asp:Label ID="Label8" runat="server" Text="DOI's Recommendation" Width="156px" CssClass="Label"></asp:Label></td>
            <td>
                :</td>
            <td style="width: 510px">
                <asp:Label ID="lblDOIRecommendation" runat="server" Text="-" Width="268px" CssClass="Label"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 9px" valign="top">
                <asp:Label ID="Label4" runat="server" Text="Applicant Summary" Width="145px" CssClass="Label"></asp:Label>
            </td>
            <td valign="top">:</td>
            <td colspan="1" style="width: 510px">
                <asp:Label ID="lblAppSummary" runat="server" Text="-" CssClass="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 9px" valign="top">
                <asp:Label ID="Label6" runat="server" Text="Remarks" CssClass="Label"></asp:Label>
            </td>
            <td valign="top">:</td>
            <td colspan="1" style="width: 510px">
                <asp:Label ID="lblRemarks" runat="server" Text="-" CssClass="Label"></asp:Label>
            </td>
        </tr>
    </table>
    </div>    
    </form>    
</body>
</html>
