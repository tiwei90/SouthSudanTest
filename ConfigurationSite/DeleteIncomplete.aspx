<%@ Page Language="C#" MasterPageFile="~/iden.master" AutoEventWireup="true"
    Inherits="DeleteIncomplete" Codebehind="DeleteIncomplete.aspx.cs" %>

<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="Server">
        <asp:Panel ID="Panel1" runat="server" BackImageUrl="./images/bg.gif" Height="24px"
        Width="100%">
        <asp:Label ID="fly" runat="server" BackColor="Transparent" CssClass="HeaderMainTitle"
            Height="16px" Width="353px">Delete Incomplete Transaction </asp:Label></asp:Panel>
        <table border="0" cellpadding="0" cellspacing="0" style="width:800px">
        <tr>
        <td style="width:50px"></td>
        <td style="width:750px;" > 
  
        
        <asp:Label ID="Label1" runat="server" CssClass="Label" Font-Bold="True" Font-Underline="True"
            Text="Enrollment Files"></asp:Label>
        <asp:Panel ID="PanelEnroll" runat="server" >               
        <table  border="0" cellpadding="0" cellspacing="0">
        <tr>
        <td style="height: 150px"><asp:ListBox ID="lstEnrolFiles" runat="server" Height="150px" Width="225px"></asp:ListBox></td>
        <td style="height: 150px">
        <table border="0" cellpadding="0" cellspacing="0" >
        <tr>
        <td align="center" style="width: 50px; height: 30px">
                    <asp:Button ID="btnSelectAllEnrol" runat="server" Text=">>" Width="34px" OnClick="btnSelectAllEnrol_Click" /></td>                                               
            </tr>
            <tr>
                <td align="center" style="width: 50px; height: 30px">
                    <asp:Button ID="btnSelectEnrol" runat="server" Text=">" Width="34px" OnClick="btnSelectEnrol_Click" /></td>
            </tr>
            <tr>
                <td align="center" style="width: 50px; height: 30px">
                    <asp:Button ID="btnUnselectEnrol" runat="server" Text="<" Width="34px" OnClick="btnUnselectEnrol_Click" /></td>
            </tr>
            <tr>
                <td align="center" style="width: 50px; height: 30px">
                    <asp:Button ID="btnUnselectAllEnrol" runat="server" Text="<<" Width="34px" OnClick="btnUnselectAllEnrol_Click" /></td>
            </tr>
            </table>        
        </td>
        <td style="width: 228px; height: 150px"><asp:ListBox ID="lstSelectedEnrolFiles" runat="server" Height="150px" Width="225px"></asp:ListBox></td>
        </tr>
        </table>
        </asp:Panel>
        <br />
        <asp:Label ID="Label2" runat="server" CssClass="Label" Font-Bold="True" Font-Underline="True"
            Text="Data Entry Files"></asp:Label>
        <asp:Panel ID="PanelDataEntry" runat="server">                       
        <table  border="0" cellpadding="0" cellspacing="0" >
        <tr>
        <td style="height: 150px"><asp:ListBox ID="lstDataEntryFiles" runat="server" Height="150px" Width="225px" SelectionMode="Multiple"></asp:ListBox></td>
        <td style="height: 150px">
        <table border="0" cellpadding="0" cellspacing="0" >
        <tr>
        <td align="center" style="width: 50px; height: 30px">
                    <asp:Button ID="btnSelectAllDataEntry" runat="server" Text=">>" Width="34px" OnClick="btnSelectAllDataEntry_Click" /></td>                                               
            </tr>
            <tr>
                <td align="center" style="width: 50px; height: 30px">
                    <asp:Button ID="btnSelectDataEntry" runat="server" Text=">" Width="34px" OnClick="btnSelectDataEntry_Click" /></td>
            </tr>
            <tr>
                <td align="center" style="width: 50px; height: 30px">
                    <asp:Button ID="btnUnselectDataEntry" runat="server" Text="<" Width="34px" OnClick="btnUnselectDataEntry_Click" /></td>
            </tr>
            <tr>
                <td align="center" style="width: 50px; height: 30px">
                    <asp:Button ID="btnUnselectAllDataEntry" runat="server" Text="<<" Width="34px" OnClick="btnUnselectAllDataEntry_Click" /></td>
            </tr>
            </table>        
        </td>
        <td style="width: 228px; height: 150px"><asp:ListBox ID="lstSelectedDataEntryFiles" runat="server" Height="150px" Width="225px"></asp:ListBox></td>
        </tr>
        </table>
        </asp:Panel>
        <br />
                <asp:Label ID="Label3" runat="server" CssClass="Label" Font-Bold="True" Font-Underline="True"
            Text="Update Profile Files"></asp:Label>

        <asp:Panel ID="PanelUpdateProfile" runat="server" >               
        <table  border="0" cellpadding="0" cellspacing="0">
        <tr>
        <td style="height: 150px"><asp:ListBox ID="lstUpdateProfileFiles" runat="server" Height="150px" Width="225px"></asp:ListBox></td>
        <td style="height: 150px">
        <table border="0" cellpadding="0" cellspacing="0" >
        <tr>
        <td align="center" style="width: 50px; height: 30px">
                    <asp:Button ID="btnSelectAllUpdateProfile" runat="server" Text=">>" Width="34px" OnClick="btnSelectAllUpdateProfile_Click" /></td>                                               
            </tr>
            <tr>
                <td align="center" style="width: 50px; height: 30px">
                    <asp:Button ID="btnSelectUpdateProfile" runat="server" Text=">" Width="34px" OnClick="btnSelectUpdateProfile_Click" /></td>
            </tr>
            <tr>
                <td align="center" style="width: 50px; height: 30px">
                    <asp:Button ID="btnUnselectUpdateProfile" runat="server" Text="<" Width="34px" OnClick="btnUnselectUpdateProfile_Click" /></td>
            </tr>
            <tr>
                <td align="center" style="width: 50px; height: 30px">
                    <asp:Button ID="btnUnselectAllUpdateProfile" runat="server" Text="<<" Width="34px" OnClick="btnUnselectAllUpdateProfile_Click" /></td>
            </tr>
            </table>        
        </td>
        <td style="width: 228px; height: 150px"><asp:ListBox ID="lstSelectedUpdateProfileFiles" runat="server" Height="150px" Width="225px"></asp:ListBox></td>
        </tr>
        </table>
        </asp:Panel>
        <asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" Text="Delete" />
        &nbsp;&nbsp;<asp:Label ID="lblMsg" runat="server" CssClass="Label" ForeColor="Blue"></asp:Label>
            
        </td></tr></table>
       <script type="text/javascript">
     function confirmDelete()
            {
                   return confirm('Are you sure you want to delete these files?');
           }
    </script>
</asp:Content>