<%@ Control Language="C#" AutoEventWireup="true" Inherits="logonContent" Codebehind="logonContent.ascx.cs" %>

<div id="setupContent" >
    <asp:Panel ID="Panel1st" runat="server" Height="50px" Width="100%">
        <table id="1stLevel" border="0" cellpadding="1" cellspacing="2" style="width: 100%">
            <tr>
                <td style="width: 36px">
                </td>
                <td style="width: 100px">
                </td>
            </tr>
            <tr>
                <td style="padding-left: 5px; width: 36px; height: 80px" valign="top">
                    <asp:ImageButton ID="btn_enrolNew1" runat="server" ImageUrl="~/images/icon_enrolnew.gif" OnClick="btn_enrolNew1_Click" /></td>
                <td style="width: 100px; height: 80px">
                    <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="14px"
                        ForeColor="#2E6F8B" Text="Lookup Table Maintenance" Width="201px"></asp:Label>
                    <asp:Label ID="Label4" runat="server" CssClass="Label" Height="82px" Text="This module allows the officer to easily update lookup table data. It allows the officer to add, update and delete the data."
                        Width="526px"></asp:Label></td>
            </tr>
        </table>
        <table id="Table1" border="0" cellpadding="1" cellspacing="2" style="width: 100%">
            <tr>
                <td style="padding-left: 5px; width: 36px; height: 80px" valign="top">
                    <asp:ImageButton ID="btn_DeleteIncomplete" runat="server" ImageUrl="~/images/delete_file.gif" OnClick="btn_DeleteIncomplete_Click" /></td>
                <td style="width: 100px; height: 80px">
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="14px"
                        ForeColor="#2E6F8B" Text="Delete Incomplete Transaction" Width="281px"></asp:Label>
                    <asp:Label ID="Label3" runat="server" CssClass="Label" Height="82px" Text="This module allows the officer to remove the incomplete transaction from resuming at the point it got interrupted.  "
                        Width="526px"></asp:Label></td>
            </tr>
        </table>        
    </asp:Panel>
</div>
