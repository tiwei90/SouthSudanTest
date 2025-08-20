<%@ Page MasterPageFile="~/iden.master" Language="C#" AutoEventWireup="true" Inherits="EnrollmentIssuanceSite.ReadVisa" Codebehind="ReadVisa.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
<script type="text/javascript" src="inc/MRZ.js"></script> 
 <script type="text/javascript" src="inc/common.js"></script>
<asp:Panel ID="Panel1" runat="server" Height="28px" BackImageUrl="./images/bg.gif"
        Width="100%">
        <asp:Label ID="fly" runat="server" Height="16px" CssClass="HeaderMainTitle" ForeColor="DimGray" BackColor="Transparent" Width="353px" >Visa - Read Visa</asp:Label></asp:Panel>
         <table id="tbQuery" cellspacing="2"  cellpadding="0" width="98%" border="0" runat="server" >
            <tr>
                <td style="width: 8px;"> </td>               
                <td colspan="3" >
                <div id="PnlSearch" runat="server" class="PanelSearch">
                <table style="width: 100%">
                    <tr>
                        <td colspan="5" style="height: 19px; background-color: #c6efef">
                            <asp:Label ID="Label11" runat="server" CssClass="LabelHeadGreen" Text="Visa Holder Information"></asp:Label></td>
                    </tr>
                <tr>               
                    <td style="height: 22px; width: 4px;">
                    </td>
                    <td style="height: 22px;" colspan="4">
                        </td>
               
                </tr>
                <tr id="trSearchValue" runat="server">
                    <td style="width: 4px;">
                    </td>
                    <td style="width: 143px;">
                        <asp:Label ID="Label5" runat="server" CssClass="LabelHead">Document Number</asp:Label></td>
                    <td style="width: 6px;">
                        :</td>
                    <td colspan="2">
                        <asp:Label ID="lblDocNo2" runat="server" CssClass="Label"></asp:Label></td>
                </tr>
                <tr runat="server" id="trFirstname">
                    <td style="width: 4px;">
                    </td>
                    <td style="width: 143px;">
                        <asp:Label ID="Label6" runat="server" CssClass="LabelHead">Document Type</asp:Label></td>
                    <td style="width: 6px;">
                        :</td>
                    <td colspan="2">
                        <asp:Label ID="lblDocType2" runat="server" CssClass="Label"></asp:Label></td>
                </tr>
                <tr runat="server" id="trMiddlename">
                    <td style="width: 4px;">
                    </td>
                    <td style="width: 143px;">
                        <asp:Label ID="Label7" runat="server" CssClass="LabelHead">Surname</asp:Label></td>
                    <td style="width: 6px;">
                        :</td>
                    <td colspan="2">
                        <asp:Label ID="lblSurname2" runat="server" CssClass="Label"></asp:Label></td>
                </tr>
                <tr id="trDOB" runat="server">
                    <td style="width: 4px; height: 21px;">
                    </td>
                    <td style="width: 143px; height: 21px;">
                        <asp:Label ID="Label1" runat="server" CssClass="LabelHead">Given Names</asp:Label></td>
                    <td style="width: 6px; height: 21px;">
                        :</td>
                    <td colspan="2" style="height: 21px">
                        <asp:Label ID="lblFName2" runat="server" CssClass="Label"></asp:Label></td>
                 </tr>
                    <tr runat="server" id="trBirthCountry">
                        <td style="width: 4px;">
                        </td>
                        <td style="width: 143px;">
                            <asp:Label ID="Label8" runat="server" CssClass="LabelHead">Sex</asp:Label></td>
                        <td style="width: 6px;">
                            :</td>
                        <td colspan="2">
                            <asp:Label ID="lblSex2" runat="server" CssClass="Label"></asp:Label></td>
                    </tr>
                    <tr runat="server">
                        <td style="width: 4px">
                        </td>
                        <td style="width: 143px">
                            <asp:Label ID="Label10" runat="server" CssClass="LabelHead">Date of Birth</asp:Label></td>
                        <td style="width: 6px">
                            :</td>
                        <td colspan="2">
                            <asp:Label ID="lblDOB2" runat="server" CssClass="Label"></asp:Label></td>
                    </tr>
                    <tr runat="server">
                        <td style="width: 4px">
                        </td>
                        <td style="width: 143px">
                            <asp:Label ID="Label9" runat="server" CssClass="LabelHead">Nationality</asp:Label></td>
                        <td style="width: 6px">
                            :</td>
                        <td colspan="2">
                            <asp:Label ID="lblNationality2" runat="server" CssClass="Label"></asp:Label></td>
                    </tr>
                    <tr runat="server">
                        <td style="width: 4px">
                        </td>
                        <td style="width: 143px">
                            <asp:Label ID="Label12" runat="server" CssClass="LabelHead">Passport No</asp:Label></td>
                        <td style="width: 6px">
                            :</td>
                        <td colspan="2">
                            <asp:Label ID="lblPersonalNo2" runat="server" CssClass="Label" Width="136px"></asp:Label></td>
                    </tr>
                    <tr id="Tr1" runat="server">
                        <td style="width: 4px">
                        </td>
                        <td style="width: 143px">
                            <asp:Label ID="Label13" runat="server" CssClass="LabelHead">Date of Expiry</asp:Label></td>
                        <td style="width: 6px">
                            :</td>
                        <td colspan="2">
                            <asp:Label ID="lblDOE2" runat="server" CssClass="Label"></asp:Label></td>
                    </tr>
                    <tr id="Tr2" runat="server">
                        <td style="width: 4px">
                        </td>
                        <td style="width: 143px">
                        </td>
                        <td style="width: 6px">
                        </td>
                        <td colspan="2">
                        </td>
                    </tr>
                    <tr runat="server">
                        <td style="width: 4px">
                        </td>
                        <td style="width: 143px">
                        </td>
                        <td style="width: 6px">
                        </td>
                        <td colspan="2">
                        </td>
                    </tr>
                    <tr runat="server">
                        <td style="width: 4px">
                        </td>
                        <td style="width: 143px">
                        </td>
                        <td style="width: 6px">
                        </td>
                        <td colspan="2">
                            </td>
                    </tr>
                    <tr>
                        <td style="width: 4px; height: 19px">
                        </td>
                        <td colspan="4" style="height: 19px">
                            <input id="btnRead" runat="server" onclick="ReadVisa_Click()" style="width: 108px"
                                type="button" value="Read MRZ" visible="true" /></td>
                    </tr>
            </table>
            </div>
            </td>
        </tr>        
        </table>    
</asp:Content>