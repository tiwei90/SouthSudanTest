<%@ Page MasterPageFile="~/iden.master" Language="C#" AutoEventWireup="true" Inherits="EnrollmentIssuanceSite.Approval" Codebehind="Approval.aspx.cs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
<script src="inc/common.js" type="text/javascript"></script>

<%--<html>
<body>--%>
<asp:Panel id="Panel1" runat="server" Width="100%" BackImageUrl="./images/bg.gif" Height="24px">
        <asp:Label ID="fly" runat="server" Height="16px" CssClass="HeaderMainTitle" ForeColor="DimGray" BackColor="Transparent" Width="353px" >Visa - Application Details</asp:Label>
        </asp:Panel>
    <asp:Menu ID="Menu1" runat="server" Orientation="Horizontal"   
    OnMenuItemClick="Menu1_MenuItemClick"      
        StaticMenuItemStyle-CssClass="tab"
        StaticSelectedStyle-CssClass="selectedTab"
        CssClass="tabs" style="left: 0px; top: 1px;">
            <Items>
                <asp:MenuItem Text="Personal" Value="0"></asp:MenuItem>
                <asp:MenuItem Text="Contact" Value="1"></asp:MenuItem>                                
                <asp:MenuItem Text="Employment" Value="2"></asp:MenuItem>    
                <asp:MenuItem Text="Family" Value="3"></asp:MenuItem>            
                <asp:MenuItem Text="Travel" Value="4"></asp:MenuItem> 
                <asp:MenuItem Text="Criminal" Value="5"></asp:MenuItem> 
                <asp:MenuItem Text="Additional" Value="6"></asp:MenuItem> 
                <asp:MenuItem Text="Scanned Doc" Value="7"></asp:MenuItem> 
                <asp:MenuItem Text="Approval History" Value="8"></asp:MenuItem> 
                <asp:MenuItem Text="Action" Value="9"></asp:MenuItem>                                
             </Items>
        </asp:Menu>
        <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
            <asp:View ID="View1" runat="server">
          <table id="tbPInfo" runat="server" border="0" cellpadding="0" cellspacing="0" visible="true">
                <tr>
                    <td style="width: 10px; height: 10px">
                    </td>
                    <td colspan="6" style="height: 10px">
                    </td>
                </tr>
                <tr>
                    <td style="width: 10px; height: 19px">
                    </td>
                    <td colspan="6" style="height: 19px">
                        <asp:Label ID="Label4" runat="server" BackColor="#C6EFEF" CssClass="LabelHeadGreen"
                            Text="Application Details" Width="760px"></asp:Label></td>
                </tr>
                <tr>
                     <td style="width: 10px; height: 19px">
                    </td>
                    <td style="width: 210px; height: 19px">
                        <asp:Label ID="Label175" runat="server" CssClass="Label" Text="Application ID"></asp:Label></td>
                    <td style="width: 7px; height: 19px">
                        :</td>
                    <td style="width: 240px; height: 19px">
                        <asp:Label ID="lblAppID" runat="server" CssClass="Label"></asp:Label></td>
                    <td style="width: 138px; height: 19px"></td>
                        
                    <td style="height: 19px; width: 7px;">
                       </td>
                    <td style="width: 217px; height: 19px">
                       </td>
                </tr>
                <tr>
                    <td style="width: 10px; height: 19px">
                    </td>
                    <td style="width: 210px; height: 19px">
                        <asp:Label ID="Label89" runat="server" CssClass="Label" Text="Purpose of Application" Width="140px"></asp:Label></td>
                    <td style="width: 7px; height: 19px">
                        :</td>
                    <td style="width: 240px; height: 19px">
                        <asp:Label ID="lblAppType" runat="server" CssClass="Label"></asp:Label></td>
                    <td style="width: 138px; height: 19px">
                        <asp:Label ID="Label85" runat="server" CssClass="Label" Text="Visa Type"></asp:Label></td>
                    <td style="height: 19px; width: 7px;">
                        :</td>
                    <td style="width: 217px; height: 19px">
                        <asp:Label ID="lblDocType" runat="server" CssClass="Label"></asp:Label></td>
                </tr>
                <tr>
                    <td style="width: 10px; height: 35px" valign="top">
                    </td>
                    <td style="width: 210px; height: 35px" valign="top">
                        <asp:Label ID="Label6" runat="server" CssClass="Label" Text="Application Status"></asp:Label></td>
                    <td style="width: 7px; height: 35px" valign="top">
                        :</td>
                    <td style="width: 240px; height: 35px" valign="top">
                        <asp:Label ID="lblAppStatus" runat="server" CssClass="Label" Width="227px"></asp:Label></td>
                    <td style="width: 138px; height: 35px" valign="top">
                        <asp:Label ID="Label125" runat="server" CssClass="Label" Text="Entry Type"></asp:Label></td>
                    <td style="height: 35px; width: 7px;" valign="top">
                        :</td>
                    <td style="width: 217px; height: 35px" valign="top">
                        <asp:Label ID="lblEntryType" runat="server" CssClass="Label"></asp:Label></td>
                </tr>
                <tr runat="server" visible="false" id="trApp1">
                    <td style="width: 10px; height: 19px">
                    </td>
                    <td style="width: 210px; height: 19px">
                        <asp:Label ID="Label153" runat="server" CssClass="LabelHeadLine" Font-Bold="True"
                            Width="107px">Enrollment Details</asp:Label></td>
                    <td style="width: 7px; height: 19px">
                    </td>
                    <td style="width: 240px; height: 19px">
                    </td>
                    <td style="width: 138px; height: 19px">
                        <asp:Label ID="Label166" runat="server" CssClass="LabelHeadLine" Font-Bold="True"
                            Width="107px">Issuance Details</asp:Label></td>
                    <td style="height: 19px; width: 7px;">
                    </td>
                    <td style="width: 217px; height: 19px">
                    </td>
                </tr>
                <tr runat="server" visible="false" id="trApp2">
                    <td style="width: 10px; height: 19px">
                    </td>
                    <td style="width: 210px; height: 19px">
                        <asp:Label ID="Label155" runat="server" CssClass="Label" Text="Enrolled By"></asp:Label></td>
                    <td style="width: 7px; height: 19px">
                        :</td>
                    <td style="width: 240px; height: 19px">
                        <asp:Label ID="VPEnrolledBy" runat="server" CssClass="Label" Height="16px" Width="57px"></asp:Label></td>
                    <td style="width: 138px; height: 19px">
                        <asp:Label ID="Label167" runat="server" CssClass="Label" Text="Issued By"></asp:Label></td>
                    <td style="height: 19px; width: 7px;">
                        :</td>
                    <td style="width: 217px; height: 19px">
                        <asp:Label ID="VPIssuedBy" runat="server" CssClass="Label"></asp:Label></td>
                </tr>
                <tr runat="server" visible="false" id="trApp3">
                    <td style="width: 10px; height: 19px">
                    </td>
                    <td style="width: 210px; height: 19px">
                        <asp:Label ID="Label158" runat="server" CssClass="Label" Text="Enrolled Date"></asp:Label></td>
                    <td style="width: 7px; height: 19px">
                        :</td>
                    <td style="width: 240px; height: 19px">
                        <asp:Label ID="VPEnrolDate" runat="server" CssClass="Label"></asp:Label></td>
                    <td style="width: 138px; height: 19px">
                        <asp:Label ID="Label168" runat="server" CssClass="Label" Text="Issued Date"></asp:Label></td>
                    <td style="height: 19px; width: 7px;">
                        :</td>
                    <td style="width: 217px; height: 19px">
                        <asp:Label ID="VPIssuedDate" runat="server" CssClass="Label"></asp:Label></td>
                </tr>
                <tr runat="server" visible="false" id="trApp4">
                    <td style="width: 10px; height: 19px">
                    </td>
                    <td style="width: 210px; height: 19px">
                        <asp:Label ID="Label161" runat="server" CssClass="LabelHeadLine" Font-Bold="True"
                            Width="107px">Data Entry Details</asp:Label></td>
                    <td style="width: 7px; height: 19px">
                    </td>
                    <td style="width: 240px; height: 19px">
                    </td>
                    <td colspan="3" rowspan="4" valign="top">
                        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                            <tr id="trDocNo" visible="false" runat="server">
                                <td style="height: 19px; width: 138px;">
                        <asp:Label ID="Label169" runat="server" CssClass="Label" Text="Document No" Width="86px"></asp:Label></td>
                                <td style=" height: 19px; width: 2px;">
                                    :</td>
                                <td style=" height: 19px">
                                    &nbsp;<asp:Label ID="VPDocNo" runat="server" CssClass="Label" Width="71px"></asp:Label></td>
                            </tr>
                             <tr id="trDocDOI" visible="false" runat="server">
                                <td style=" height: 19px; width: 138px;">
                        <asp:Label ID="Label170" runat="server" CssClass="Label" Text="Date of Issue"></asp:Label></td>
                                <td style=" height: 19px; width: 2px;">
                                    :</td>
                                <td style=" height: 19px">
                                    &nbsp;<asp:Label ID="VPDOI" runat="server" CssClass="Label"></asp:Label></td>
                            </tr>
                              <tr id="trDocDOE" visible="false" runat="server">
                                <td style="width: 138px; height: 19px">
                        <asp:Label ID="Label171" runat="server" CssClass="Label" Text="Date of Expiry"></asp:Label></td>
                                <td style="width: 2px; height: 19px">
                                    :</td>
                                <td style="height: 19px" >
                                    &nbsp;<asp:Label ID="VPDOE" runat="server" CssClass="Label"></asp:Label></td>
                            </tr>
                            <tr runat="server" visible="false" id="trDocPOI">
                                <td style="width: 138px; height: 19px">
                                    <asp:Label ID="Label12" runat="server" CssClass="Label" Text="Place of Issue"></asp:Label></td>
                                <td style="width: 2px; height: 19px">
                                    :</td>
                                <td style="height: 19px">
                                    &nbsp;<asp:Label ID="VPPOI" runat="server" CssClass="Label"></asp:Label></td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr runat="server" visible="false" id="trApp5">
                    <td style="width: 10px; height: 19px">
                    </td>
                    <td style="width: 210px; height: 19px">
                        <asp:Label ID="Label162" runat="server" CssClass="Label" Text="Data Entry By"></asp:Label></td>
                    <td style="width: 7px; height: 19px">
                        :</td>
                    <td style="width: 240px; height: 19px">
                        <asp:Label ID="VPDataEntryBy" runat="server" CssClass="Label"></asp:Label></td>
                </tr>
                <tr runat="server" visible="false" id="trApp6">
                    <td style="width: 10px; height: 19px">
                    </td>
                    <td style="width: 210px; height: 19px">
                        <asp:Label ID="Label163" runat="server" CssClass="Label" Text="Data Entry Date"></asp:Label></td>
                    <td style="width: 7px; height: 19px">
                        :</td>
                    <td style="width: 240px; height: 19px">
                        <asp:Label ID="VPDataEntryDate" runat="server" CssClass="Label"></asp:Label></td>
                </tr>
               <tr id="trApp7" runat="server" visible="false">
                   <td style="width: 10px; height: 19px">
                   </td>
                   <td style="width: 210px; height: 19px">
                   </td>
                   <td style="width: 7px; height: 19px">
                   </td>
                   <td style="width: 240px; height: 19px">
                   </td>
               </tr>
               <tr id="Tr7" runat="server" visible="false">
                   <td style="width: 10px; height: 19px">
                   </td>
                   <td style="width: 210px; height: 19px">
                   </td>
                   <td style="width: 7px; height: 19px">
                   </td>
                   <td style="width: 240px; height: 19px">
                   </td>
                   <td style="width: 138px; height: 19px">
                   </td>
                   <td style="height: 19px; width: 7px;">
                   </td>
                   <td style="width: 217px; height: 19px">
                   </td>
               </tr>
               <tr id="Tr8" runat="server" visible="false">
                   <td style="width: 10px; height: 19px">
                   </td>
                   <td style="width: 210px; height: 19px">
                   </td>
                   <td style="width: 7px; height: 19px">
                   </td>
                   <td style="width: 240px; height: 19px">
                       &nbsp;</td>
                   <td style="width: 138px; height: 19px">
                   </td>
                   <td style="height: 19px; width: 7px;">
                   </td>
                   <td style="width: 217px; height: 19px">
                   </td>
               </tr>
            <tr>
                <td style="width: 10px; height: 19px">
                </td>
                <td colspan="6" style="height: 19px">
                    <asp:Label ID="Label152" runat="server" BackColor="#C6EFEF" CssClass="LabelHeadGreen"
                        Text="Personal Details" Width="760px"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 10px; height: 29px">
                </td>
                <td style="width: 210px; height: 29px">
                    <asp:Label ID="Label20" runat="server" CssClass="Label" Width="80px" Font-Bold="True">Photo</asp:Label></td>
                <td style="width: 7px; height: 29px">
                </td>
                <td style="width: 240px; height: 29px">
                    <asp:Label
                        ID="lblCompName" runat="server" Text="Label" Visible="False"></asp:Label><asp:Label
                            ID="lblChildNo" runat="server" Text="Label" Visible="False"></asp:Label></td>
                <td style="width: 138px; height: 29px">
                        <asp:Label ID="lblIdPerson" runat="server" Text="Label" Visible="False"></asp:Label>
                        <asp:Label ID="lblDocIssDate" runat="server" Text="Label" Visible="False"></asp:Label>
                    <asp:Label ID="lblDMSID" runat="server" Text="Label" Visible="False"></asp:Label></td>
                <td style="height: 29px; width: 7px;">
                </td>
                <td style="width: 217px; height: 29px">
                    &nbsp;<asp:Label ID="lblIsCert" runat="server" Text="Label" Visible="False"></asp:Label><asp:Label
                            ID="lblIsCard" runat="server" Text="Label" Visible="False"></asp:Label><asp:Label
                                ID="lblCertNo" runat="server" Text="Label" Visible="False"></asp:Label><asp:Label
                                    ID="lblEnrolledDate" runat="server" Text="Label" Visible="False"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 10px; height: 100px">
                </td>
                <td style="width: 210px; height: 100px">
                    <asp:Image ID="imgPhoto" runat="server" BorderStyle="Solid" CssClass="Img" Height="106px"
                        ImageUrl="~/images/spacer.gif" Width="85px" BorderColor="Gray" BorderWidth="1px" /></td>
                <td style="width: 7px; height: 100px">
                </td>
                <td colspan="4" style="height: 100px">
                    </td>
            </tr>
            <tr>
                <td style="width: 10px; height: 24px;">
                </td>
                <td style="width: 210px; height: 24px;">
                    <asp:Label ID="lblNIN" runat="server" CssClass="Label" Text="Title"
                        Width="29px"></asp:Label></td>
                <td style="width: 7px; height: 24px;">
                    :</td>
                <td style="width: 240px; height: 24px;">
                    <asp:Label ID="lblTitle" runat="server" CssClass="Label"></asp:Label></td>
                <td style="width: 138px; height: 24px;">
                    <asp:Label ID="Label21" runat="server" CssClass="Label" Text="National ID No"></asp:Label></td>
                <td style="height: 24px; width: 7px;">
                    :</td>
                <td style="width: 217px; height: 24px;">
                    <asp:Label ID="lblNIDNo" runat="server" CssClass="Label"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 10px; height: 23px">
                </td>
                <td style="width: 210px; height: 23px">
                    <asp:Label ID="Label14" runat="server" CssClass="Label" Text="Surname"></asp:Label></td>
                <td style="width: 7px; height: 23px">
                    :</td>
                <td style="width: 240px; height: 23px">
                    <asp:Label ID="lblSurname" runat="server" CssClass="Label"></asp:Label></td>
                <td style="width: 138px; height: 23px">
                    <asp:Label ID="Label24" runat="server" CssClass="Label" Text="Date of Birth"></asp:Label></td>
                <td style="height: 23px; width: 7px;">
                    </td>
                <td style="width: 217px; height: 23px">
                    <asp:Label ID="lblDOB" runat="server" CssClass="Label"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 10px; height: 24px">
                </td>
                <td style="width: 210px; height: 24px">
                    <asp:Label ID="Label15" runat="server" CssClass="Label" Text="First Name"></asp:Label></td>
                <td style="width: 7px; height: 24px">
                    :</td>
                <td style="width: 240px; height: 24px">
                    <asp:Label ID="lblFName" runat="server" CssClass="Label"></asp:Label></td>
                <td style="width: 138px; height: 24px">
                    <asp:Label ID="Label27" runat="server" CssClass="Label" Text="Place of Birth"></asp:Label></td>
                <td style="height: 24px; width: 7px;">
                    :</td>
                <td style="width: 217px; height: 24px">
                    <asp:Label ID="lblPOB" runat="server" CssClass="Label"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 10px; height: 24px">
                </td>
                <td style="width: 210px; height: 24px">
                    <asp:Label ID="Label16" runat="server" CssClass="Label" Text="Middle Name"></asp:Label></td>
                <td style="width: 7px; height: 24px">
                    :</td>
                <td style="width: 240px; height: 24px">
                    <asp:Label ID="lblMName" runat="server" CssClass="Label"></asp:Label></td>
                <td style="width: 138px; height: 24px">
                    <asp:Label ID="Label17" runat="server" CssClass="Label" Text="Country of Birth"></asp:Label></td>
                <td style="height: 24px; width: 7px;">
                    :</td>
                <td style="width: 217px; height: 24px">
                    <asp:Label ID="lblCOB" runat="server" CssClass="Label"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 10px; height: 24px">
                </td>
                <td style="width: 210px; height: 24px">
                    <asp:Label ID="Label29" runat="server" CssClass="Label" Text="Sex"></asp:Label></td>
                <td style="width: 7px; height: 24px">
                    :</td>
                <td style="width: 240px; height: 24px">
                    <asp:Label ID="lblSex" runat="server" CssClass="Label"></asp:Label></td>
                <td style="width: 138px; height: 24px">
                    <asp:Label ID="Label81" runat="server" CssClass="Label" Text="Nationality"></asp:Label></td>
                <td style="height: 24px; width: 7px;">
                    :</td>
                <td style="width: 217px; height: 24px">
                    <asp:Label ID="lblNationality" runat="server" CssClass="Label"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 10px; height: 24px">
                </td>
                <td style="width: 210px; height: 24px">
                    </td>
                <td style="width: 7px; height: 24px">
                    </td>
                <td style="width: 240px; height: 24px">
                    </td>
                <td style="width: 138px; height: 24px">
                    </td>
                <td style="height: 24px; width: 7px;">
                    </td>
                <td style="width: 217px; height: 24px">
                    </td>
            </tr>
                <tr>
                    <td style="width: 10px; height: 24px">
                    </td>
                    <td style="width: 210px; height: 24px">
                        <asp:Label ID="PassportTitle" runat="server" CssClass="Label" Font-Bold="True" Font-Overline="False"
                            Font-Underline="True" Width="80px">Passport</asp:Label></td>
                    <td style="width: 7px; height: 24px">
                    </td>
                    <td style="width: 240px; height: 24px">
                    </td>
                    <td style="width: 138px; height: 24px">
                    </td>
                    <td style="height: 24px; width: 7px;">
                    </td>
                    <td style="width: 217px; height: 24px">
                    </td>
                </tr>
                <tr id="trPassportNo" visible="false" runat="server">
                    <td style="width: 10px; height: 24px">
                    </td>
                    <td style="width: 210px; height: 24px">
                        <asp:Label ID="Label93" runat="server" CssClass="Label" Text="Passport Number"></asp:Label></td>
                    <td style="width: 7px; height: 24px">
                        :</td>
                    <td style="width: 240px; height: 24px">
                        <asp:Label ID="lblPassportNo" runat="server" CssClass="Label"></asp:Label></td>
                    <td style="width: 138px; height: 24px">
                    </td>
                    <td style="height: 24px; width: 7px;">
                    </td>
                    <td style="width: 217px; height: 24px">
                    </td>
                </tr>
                   <tr id="trPassportDate" visible="false" runat="server">
                    <td style="width: 10px; height: 24px">
                    </td>
                    <td style="width: 210px; height: 24px">
                        <asp:Label ID="Label101" runat="server" CssClass="Label" Text="Date Issued"></asp:Label></td>
                    <td style="width: 7px; height: 24px">
                        :</td>
                    <td style="width: 240px; height: 24px">
                        <asp:Label ID="lblPassportDOI" runat="server" CssClass="Label"></asp:Label></td>
                    <td style="width: 138px; height: 24px">
                        <asp:Label ID="Label98" runat="server" CssClass="Label" Text="Date Expiry"></asp:Label></td>
                    <td style="height: 24px; width: 7px;">
                        :</td>
                    <td style="width: 217px; height: 24px">
                        <asp:Label ID="lblPassportDOE" runat="server" CssClass="Label"></asp:Label></td>
                </tr>
                   <tr id="trPassportPlace" visible="false" runat="server">
                    <td style="width: 10px; height: 24px">
                    </td>
                    <td style="width: 210px; height: 24px">
                        <asp:Label ID="Label99" runat="server" CssClass="Label" Text="Country Issue"></asp:Label></td>
                    <td style="width: 7px; height: 24px">
                        :</td>
                    <td style="width: 240px; height: 24px">
                        <asp:Label ID="lblPassportCOI" runat="server" CssClass="Label"></asp:Label></td>
                    <td style="width: 138px; height: 24px">
                        <asp:Label ID="Label96" runat="server" CssClass="Label" Text="Place Issue"></asp:Label></td>
                    <td style="height: 24px; width: 7px;">
                        :</td>
                    <td style="width: 217px; height: 24px">
                        <asp:Label ID="lblPassportPOI" runat="server" CssClass="Label"></asp:Label></td>
                </tr>
                <tr>
                    <td style="height: 10px">
                    </td>
                    <td style="height: 10px; width: 210px;">
                    </td>
                    <td style="height: 10px">
                    </td>
                    <td style="height: 10px">
                    </td>
                    <td style="height: 10px">
                    </td>
                    <td style="height: 10px; width: 7px;">
                    </td>
                    <td style="height: 10px">
                    </td>
                </tr>
                <tr>
                    <td style="width: 10px; height: 24px">
                    </td>
                    <td colspan="6" style="height: 24px">
                        <asp:Label ID="lblSearchError" runat="server" CssClass="Label" ForeColor="Blue"></asp:Label><asp:Label
                            ID="lblErr" runat="server" CssClass="Label" ForeColor="Red" Visible="False"></asp:Label></td>
                </tr>
         
        </table>       
            </asp:View>
            <asp:View ID="View2" runat="server">
            <table id="Table1" runat="server" border="0" cellpadding="0" cellspacing="0" visible="true">
                <tr>
                    <td style="width: 10px; height: 10px">
                    </td>
                    <td colspan="6" style="height: 10px">
                    </td>
                </tr>
                <tr>
                    <td style="width: 10px; height: 19px">
                    </td>
                    <td colspan="6" style="height: 19px">
                        <asp:Label ID="Label2" runat="server" BackColor="#C6EFEF" CssClass="LabelHeadGreen"
                            Text="Contacl Details" Width="760px"></asp:Label></td>
                </tr>
                <tr>
                    <td style="width: 10px; height: 10px">
                    </td>
                    <td colspan="6" style="height: 10px">
                    </td>
                </tr>
                <tr>
                    <td style="width: 10px">
                    </td>
                    <td style="width: 153px">
                        <asp:Label ID="Label69" runat="server" CssClass="Label" Text="Present Address"></asp:Label>
                    </td>
                    <td style="width: 7px">
                        :</td>
                    <td colspan="4">
                        <asp:Label ID="lblPresentAddress" runat="server" CssClass="Label"></asp:Label></td>
                </tr>
                <tr>
                    <td style="height: 10px;">
                    </td>
                    <td style="height: 10px;">
                    </td>
                    <td style="height: 10px;">
                    </td>
                    <td colspan="4" style="height: 10px">
                    </td>
                </tr>
                <tr>
                    <td style="width: 10px">
                    </td>
                    <td style="width: 153px">
                        <asp:Label ID="Label1" runat="server" CssClass="Label" Text="Permanent Address"></asp:Label></td>
                    <td style="width: 7px">
                        :</td>
                    <td colspan="4">
                        <asp:Label ID="lblPermanentAddress" runat="server" CssClass="Label"></asp:Label></td>
                </tr>
                <tr>
                    <td style="height: 10px">
                    </td>
                    <td style="height: 10px">
                    </td>
                    <td style="height: 10px">
                    </td>
                    <td style="height: 10px">
                    </td>
                    <td style="height: 10px">
                    </td>
                    <td style="height: 10px">
                    </td>
                    <td style="height: 10px">
                    </td>
                </tr>
                <tr>
                    <td style="width: 10px; height: 10px">
                    </td>
                    <td style="width: 153px; height: 10px">
                        <asp:Label ID="Label90" runat="server" CssClass="Label" Text="Telephone"></asp:Label>
                        <asp:Label ID="Label25" runat="server" CssClass="Label" Font-Italic="True" Text="(Home)"></asp:Label></td>
                    <td style="width: 7px; height: 10px">
                        :</td>
                    <td style="width: 240px; height: 10px">
                        <asp:Label ID="lblPhoneHome" runat="server" CssClass="Label"></asp:Label></td>
                    <td style="width: 155px; height: 10px">
                        <asp:Label ID="Label22" runat="server" CssClass="Label" Text="Telephone"></asp:Label>
                        <asp:Label ID="Label23" runat="server" CssClass="Label" Font-Italic="True" Text="(Work)"></asp:Label></td>
                    <td style="width: 7px; height: 10px">
                        :</td>
                    <td style="width: 203px; height: 10px">
                        <asp:Label ID="lblPhoneWork" runat="server" CssClass="Label"></asp:Label></td>
                </tr>
                <tr>
                    <td style="width: 10px; height: 10px">
                    </td>
                    <td style="width: 153px; height: 10px">
                        <asp:Label ID="Label83" runat="server" CssClass="Label" Text="Fax"></asp:Label></td>
                    <td style="width: 7px; height: 10px">
                        :</td>
                    <td style="width: 240px; height: 10px">
                        <asp:Label ID="lblFax" runat="server" CssClass="Label"></asp:Label></td>
                    <td style="width: 155px; height: 10px">
                        <asp:Label ID="Label26" runat="server" CssClass="Label" Text="Mobile"></asp:Label></td>
                    <td style="width: 7px; height: 10px">
                        :</td>
                    <td style="width: 203px; height: 10px">
                        <asp:Label ID="lblMobile" runat="server" CssClass="Label"></asp:Label></td>
                </tr>
                <tr>
                    <td style="width: 10px; height: 19px">
                    </td>
                    <td style="width: 153px; height: 19px">
                        <asp:Label ID="Label79" runat="server" CssClass="Label" Text="Email"></asp:Label></td>
                    <td style="width: 7px; height: 19px">
                        :</td>
                    <td style="width: 240px; height: 19px">
                        <asp:Label ID="lblEmail" runat="server" CssClass="Label"></asp:Label></td>
                    <td style="width: 155px; height: 19px">
                    </td>
                    <td style="width: 7px; height: 19px">
                    </td>
                    <td style="width: 203px; height: 19px">
                    </td>
                </tr>
            <tr>
                <td style="height: 10px">
                </td>
                <td style="height: 10px">
                </td>
                <td style="height: 10px">
                </td>
                <td style="height: 10px">
                </td>
                <td style="height: 10px">
                </td>
                <td style="height: 10px">
                </td>
                <td style="height: 10px">
                </td>
            </tr>
                <tr>
                    <td style="width: 10px; height: 24px">
                    </td>
                    <td colspan="6" style="height: 24px">
                        <asp:Label ID="lblContactErr" runat="server" CssClass="Label" ForeColor="Red"></asp:Label></td>
                </tr>
         
        </table>      
            </asp:View>            
            <asp:View ID="View3" runat="server">
               <table id="Table4" runat="server" border="0" cellpadding="0" cellspacing="0" visible="true">
                <tr>
                    <td style="width: 10px; height: 10px">
                    </td>
                    <td colspan="6" style="height: 10px">
                    </td>
                </tr>
                <tr>
                    <td style="width: 10px; height: 19px">
                    </td>
                    <td colspan="6" style="height: 19px">
                        <asp:Label ID="Label7" runat="server" BackColor="#C6EFEF" CssClass="LabelHeadGreen"
                            Text="Employment Details" Width="760px"></asp:Label></td>
                </tr>
                <tr>
                    <td style="width: 10px; height: 10px">
                    </td>
                    <td colspan="6" style="height: 10px">
                    </td>
                </tr>
                <tr>
                    <td style="height: 0px">
                    </td>
                    <td style="height: 0px; width: 105px;">
                        <asp:Label ID="Label102" runat="server" CssClass="Label" Text="Occupation"></asp:Label></td>
                    <td style="height: 0px; width: 6px;">
                        :</td>
                    <td style="height: 0px; width: 207px;">
                        <asp:Label ID="lblOccupation" runat="server" CssClass="Label"></asp:Label></td>
                    <td style="height: 0px; width: 156px;">
                        <asp:Label ID="Label104" runat="server" CssClass="Label" Text="Former Occupation"></asp:Label></td>
                    <td style="height: 0px; width: 5px;">
                        :</td>
                    <td style="height: 0px">
                        <asp:Label ID="lblFormerOccupation" runat="server" CssClass="Label"></asp:Label></td>
                </tr>
                <tr>
                    <td style="height: 0px">
                    </td>
                    <td style="height: 0px; width: 105px;">
                        <asp:Label ID="Label154" runat="server" CssClass="Label" Text="Name"></asp:Label></td>
                    <td style="height: 0px; width: 6px;">
                        :</td>
                    <td style="height: 0px; width: 207px;">
                        <asp:Label ID="lblEmployerName" runat="server" CssClass="Label"></asp:Label></td>
                    <td style="height: 0px; width: 156px;">
                        <asp:Label ID="Label107" runat="server" CssClass="Label" Text="Name"></asp:Label></td>
                    <td style="height: 0px; width: 5px;">
                    </td>
                    <td style="height: 0px">
                        <asp:Label ID="lblFormerEmployerName" runat="server" CssClass="Label"></asp:Label></td>
                </tr>
                <tr>
                    <td style="height: 0px">
                    </td>
                    <td style="height: 0px; width: 105px;" valign="top">
                        <asp:Label ID="Label156" runat="server" CssClass="Label" Text="Address"></asp:Label></td>
                    <td style="height: 0px; width: 6px;" valign="top">
                        :</td>
                    <td style="height: 0px; width: 207px;" valign="top">
                        <asp:TextBox ID="lblEmployerAddress" runat="server" BorderStyle="None" CssClass="Label" ReadOnly="True"
                            Rows="4" TextMode="MultiLine" Width="202px"></asp:TextBox></td>
                    <td style="height: 0px; width: 156px;" valign="top">
                        <asp:Label ID="Label110" runat="server" CssClass="Label" Text="Address"></asp:Label></td>
                    <td style="height: 0px; width: 5px;" valign="top">
                        :</td>
                    <td style="height: 0px">
                        <asp:TextBox ID="lblFormerEmployerAddress" runat="server" BorderStyle="None" CssClass="Label"
                            ReadOnly="True" Rows="4" TextMode="MultiLine" Width="202px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="height: 20px">
                    </td>
                    <td style="height: 20px; width: 105px;">
                        <asp:Label ID="Label103" runat="server" CssClass="Label" Text="No. of Years Employed" Width="145px"></asp:Label></td>
                    <td style="height: 20px; width: 6px;">
                        :</td>
                    <td style="height: 20px; width: 207px;">
                        <asp:Label ID="lblYearsEmployed" runat="server" CssClass="Label"></asp:Label></td>
                    <td style="height: 20px; width: 156px;">
                        <asp:Label ID="Label105" runat="server" CssClass="Label" Text="No. of Years Employed"></asp:Label></td>
                    <td style="height: 20px; width: 5px;">
                        :</td>
                    <td style="height: 20px">
                        <asp:Label ID="lblFormerYearsEmployed" runat="server" CssClass="Label"></asp:Label></td>
                </tr>
           <tr>
               <td style="height: 20px">
               </td>
               <td style="height: 20px; width: 105px;">
                        <asp:Label ID="Label157" runat="server" CssClass="Label" Text="Telephone"></asp:Label></td>
               <td style="width: 6px; height: 20px">
                   :</td>
               <td style="height: 20px; width: 207px;">
                        <asp:Label ID="lblEmployerPhone" runat="server" CssClass="Label"></asp:Label></td>
               <td style="height: 20px; width: 156px;">
                        <asp:Label ID="Label113" runat="server" CssClass="Label" Text="Telephone"></asp:Label></td>
               <td style="height: 20px; width: 5px;">
                   :</td>
               <td style="height: 20px">
                        <asp:Label ID="lblFormerEmployerPhone" runat="server" CssClass="Label"></asp:Label></td>
           </tr>
                <tr>
                    <td style="height: 10px">
                    </td>
                    <td style="height: 10px; width: 105px;">
                    </td>
                    <td style="height: 10px; width: 6px;">
                    </td>
                    <td style="height: 10px; width: 207px;">
                    </td>
                    <td style="height: 10px; width: 156px;">
                    </td>
                    <td style="height: 10px; width: 5px;">
                    </td>
                    <td style="height: 10px">
                    </td>
                </tr>
                <tr>
                    <td style="width: 10px; height: 10px">
                    </td>
                    <td colspan="6" style="height: 24px">
                        <asp:Label ID="lblEmploymentErr" runat="server" CssClass="Label" ForeColor="Red"></asp:Label></td>
                </tr>
         
        </table>      
            </asp:View>
            <asp:View ID="View4" runat="server">
            <table id="Table3" runat="server" border="0" cellpadding="0" cellspacing="0" visible="true">
                <tr>
                    <td style="width: 10px; height: 10px">
                    </td>
                    <td colspan="6" style="height: 10px">
                    </td>
                </tr>
                <tr>
                    <td style="width: 10px; height: 19px">
                    </td>
                    <td colspan="6" style="height: 19px">
                        <asp:Label ID="Label5" runat="server" BackColor="#C6EFEF" CssClass="LabelHeadGreen"
                            Text="Family Details" Width="760px"></asp:Label></td>
                </tr>
                <tr>
                    <td style="width: 10px; height: 10px">
                    </td>
                    <td colspan="6" style="height: 10px">
                    </td>
                </tr>
                <tr>
                    <td style="width: 10px; height: 24px">
                    </td>
                    <td style="width: 153px; height: 24px">
                        <asp:Label ID="Label41" runat="server" CssClass="Label" Text="Marital Status"></asp:Label></td>
                    <td style="width: 7px; height: 24px">
                        :</td>
                    <td style="width: 240px; height: 24px">
                        <asp:Label ID="lblMaritalStatus" runat="server" CssClass="Label"></asp:Label></td>
                    <td style="width: 155px; height: 24px">
                    </td>
                    <td style="width: 7px; height: 24px">
                    </td>
                    <td style="width: 203px; height: 24px">
                    </td>
                </tr>
                <tr>
                    <td style="height: 10px">
                    </td>
                    <td style="height: 10px">
                    </td>
                    <td style="height: 10px">
                    </td>
                    <td style="height: 10px">
                    </td>
                    <td style="height: 10px">
                    </td>
                    <td style="height: 10px">
                    </td>
                    <td style="height: 10px">
                    </td>
                </tr>
                <tr>
                    <td style="width: 10px; height: 24px">
                    </td>
                    <td style="width: 153px; height: 24px">
                        <asp:Label ID="Label46" runat="server" CssClass="Label" Font-Bold="True" Font-Overline="False"
                            Font-Underline="True" Width="80px">Spouse</asp:Label></td>
                    <td style="width: 7px; height: 24px">
                    </td>
                    <td style="width: 240px; height: 24px">
                    </td>
                    <td style="width: 155px; height: 24px">
                    </td>
                    <td style="width: 7px; height: 24px">
                    </td>
                    <td style="width: 203px; height: 24px">
                    </td>
                </tr>
                <tr>
                    <td style="height: 0px">
                    </td>
                    <td style="height: 0px">
                        <asp:Label ID="Label30" runat="server" CssClass="Label" Text="First Name"></asp:Label>
                    </td>
                    <td style="height: 0px">
                        :</td>
                    <td style="height: 0px">
                        <asp:Label ID="lblSpouseFirstName" runat="server" CssClass="Label"></asp:Label></td>
                    <td style="height: 0px">
                        <asp:Label ID="Label34" runat="server" CssClass="Label" Text="Middle Name"></asp:Label></td>
                    <td style="height: 0px">
                        :</td>
                    <td style="height: 0px">
                        <asp:Label ID="lblSpouseMiddleName" runat="server" CssClass="Label"></asp:Label></td>
                </tr>
                <tr>
                    <td style="height: 0px">
                    </td>
                    <td style="height: 0px">
                        <asp:Label ID="Label36" runat="server" CssClass="Label" Text="Last Name"></asp:Label></td>
                    <td style="height: 0px">
                        :</td>
                    <td style="height: 0px">
                        <asp:Label ID="lblSpouseLastName" runat="server" CssClass="Label"></asp:Label></td>
                    <td style="height: 0px">
                        <asp:Label ID="Label37" runat="server" CssClass="Label" Text="Maiden Name"></asp:Label></td>
                    <td style="height: 0px">
                        :</td>
                    <td style="height: 0px">
                        <asp:Label ID="lblSpouseMaidenName" runat="server" CssClass="Label"></asp:Label></td>
                </tr>
                <tr>
                    <td style="height: 0px">
                    </td>
                    <td style="height: 0px">
                        <asp:Label ID="Label35" runat="server" CssClass="Label" Text="Date of Birth"></asp:Label></td>
                    <td style="height: 0px">
                        :</td>
                    <td style="height: 0px">
                        <asp:Label ID="lblSpouseDOB" runat="server" CssClass="Label"></asp:Label></td>
                    <td style="height: 0px">
                    </td>
                    <td style="height: 0px">
                    </td>
                    <td style="height: 0px">
                    </td>
                </tr>
                <tr>
                    <td style="height: 10px">
                    </td>
                    <td style="height: 10px">
                    </td>
                    <td style="height: 10px">
                    </td>
                    <td style="height: 10px">
                    </td>
                    <td style="height: 10px">
                    </td>
                    <td style="height: 10px">
                    </td>
                    <td style="height: 10px">
                    </td>
                </tr>
                <tr>
                    <td style="width: 10px; height: 24px">
                    </td>
                    <td style="width: 153px; height: 24px">
                        <asp:Label ID="Label48" runat="server" CssClass="Label" Text="Do you have any children?" Font-Bold="True"></asp:Label></td>
                    <td style="width: 7px; height: 24px">
                        :</td>
                    <td style="width: 240px; height: 24px">
                        <asp:CheckBox ID="chkHasChild1" runat="server" CssClass="Label" Text="Yes" Enabled="False" />
                        <asp:CheckBox ID="chkHasChild2" runat="server" CssClass="Label" Text="No" Enabled="False" /></td>
                    <td style="width: 155px; height: 24px">
                    </td>
                    <td style="width: 7px; height: 24px">
                    </td>
                    <td style="width: 203px; height: 24px">
                    </td>
                </tr>
                <tr>
                    <td style="height: 20px">
                    </td>
                    <td style="height: 20px">
                        <asp:Label ID="Label3" runat="server" CssClass="Label" Text="1. Dependant Name"></asp:Label></td>
                    <td style="height: 20px">
                        :</td>
                    <td style="height: 20px">
                        <asp:Label ID="lblDependantName1" runat="server" CssClass="Label"></asp:Label></td>
                    <td style="height: 20px">
                        <asp:Label ID="Label38" runat="server" CssClass="Label" Text="Relationship to Applicant"></asp:Label></td>
                    <td style="height: 20px">
                        :</td>
                    <td style="height: 20px">
                        <asp:Label ID="lblRelationship1" runat="server" CssClass="Label"></asp:Label></td>
                </tr>
                <tr>
                    <td style="height: 20px">
                    </td>
                    <td style="height: 20px">
                        <asp:Label ID="Label39" runat="server" CssClass="Label" Text="2. Dependant Name"></asp:Label></td>
                    <td style="height: 20px">
                        :</td>
                    <td style="height: 20px">
                        <asp:Label ID="lblDependantName2" runat="server" CssClass="Label"></asp:Label></td>
                    <td style="height: 20px">
                        <asp:Label ID="Label58" runat="server" CssClass="Label" Text="Relationship to Applicant"></asp:Label></td>
                    <td style="height: 20px">
                        :</td>
                    <td style="height: 20px">
                        <asp:Label ID="lblRelationship2" runat="server" CssClass="Label"></asp:Label></td>
                </tr>
                <tr>
                    <td style="height: 20px">
                    </td>
                    <td style="height: 20px">
                        <asp:Label ID="Label40" runat="server" CssClass="Label" Text="3. Dependant Name"></asp:Label></td>
                    <td style="height: 20px">
                        :</td>
                    <td style="height: 20px">
                        <asp:Label ID="lblDependantName3" runat="server" CssClass="Label"></asp:Label></td>
                    <td style="height: 20px">
                        <asp:Label ID="Label61" runat="server" CssClass="Label" Text="Relationship to Applicant"></asp:Label></td>
                    <td style="height: 20px">
                        :</td>
                    <td style="height: 20px">
                        <asp:Label ID="lblRelationship3" runat="server" CssClass="Label"></asp:Label></td>
                </tr>
                <tr>
                    <td style="height: 20px">
                    </td>
                    <td style="height: 20px">
                        <asp:Label ID="Label42" runat="server" CssClass="Label" Text="4. Dependant Name"></asp:Label></td>
                    <td style="height: 20px">
                        :</td>
                    <td style="height: 20px">
                        <asp:Label ID="lblDependantName4" runat="server" CssClass="Label"></asp:Label></td>
                    <td style="height: 20px">
                        <asp:Label ID="Label65" runat="server" CssClass="Label" Text="Relationship to Applicant"></asp:Label></td>
                    <td style="height: 20px">
                        :</td>
                    <td style="height: 20px">
                        <asp:Label ID="lblRelationship4" runat="server" CssClass="Label"></asp:Label></td>
                </tr>
                <tr>
                    <td style="height: 20px">
                    </td>
                    <td style="height: 20px">
                        <asp:Label ID="Label53" runat="server" CssClass="Label" Text="5. Dependant Name"></asp:Label></td>
                    <td style="height: 20px">
                        :</td>
                    <td style="height: 20px">
                        <asp:Label ID="lblDependantName5" runat="server" CssClass="Label"></asp:Label></td>
                    <td style="height: 20px">
                        <asp:Label ID="Label67" runat="server" CssClass="Label" Text="Relationship to Applicant"></asp:Label></td>
                    <td style="height: 20px">
                        :</td>
                    <td style="height: 20px">
                        <asp:Label ID="lblRelationship5" runat="server" CssClass="Label"></asp:Label></td>
                </tr>
                <tr>
                    <td style="height: 10px">
                    </td>
                    <td style="height: 10px">
                    </td>
                    <td style="height: 10px">
                    </td>
                    <td style="height: 10px">
                    </td>
                    <td style="height: 10px">
                    </td>
                    <td style="height: 10px">
                    </td>
                    <td style="height: 10px">
                    </td>
                </tr>
                <tr>
                    <td style="width: 10px; height: 11px">
                    </td>
                    <td colspan="3" style="height: 11px">
                        <asp:Label ID="Label70" runat="server" CssClass="Label" Text="Is Spouse traveling with you?"
                            Width="210px"></asp:Label>:
                        <asp:CheckBox ID="chkTravelWithSpouse1" runat="server" CssClass="Label" Text="Yes" Enabled="False" /><asp:CheckBox
                            ID="chkTravelWithSpouse2" runat="server" CssClass="Label" 
                            Text="No" Enabled="False" /></td>
                    <td style="width: 155px; height: 11px">
                    </td>
                    <td style="width: 7px; height: 11px">
                    </td>
                    <td style="width: 203px; height: 11px">
                    </td>
                </tr>
                <tr>
                    <td style="width: 10px; height: 11px">
                    </td>
                    <td colspan="3" style="height: 11px">
                        <asp:Label ID="Label71" runat="server" CssClass="Label" Text="Are Dependants traveling with you?"
                            Width="209px"></asp:Label>:&nbsp;<asp:CheckBox ID="chkTravelWithDependant1" runat="server"
                                CssClass="Label" Text="Yes" Enabled="False" /><asp:CheckBox ID="chkTravelWithDependant2" runat="server"
                                    CssClass="Label" Text="No" Enabled="False" /></td>
                    <td style="width: 155px; height: 11px">
                    </td>
                    <td style="width: 7px; height: 11px">
                    </td>
                    <td style="width: 203px; height: 11px">
                    </td>
                </tr>
                <tr>
                    <td style="height: 10px">
                    </td>
                    <td style="height: 10px">
                    </td>
                    <td style="height: 10px">
                    </td>
                    <td style="height: 10px">
                    </td>
                    <td style="height: 10px">
                    </td>
                    <td style="height: 10px">
                    </td>
                    <td style="height: 10px">
                    </td>
                </tr>
                <tr>
                    <td style="width: 10px; height: 24px">
                    </td>
                    <td style="width: 153px; height: 24px">
                        <asp:Label ID="Label44" runat="server" CssClass="Label" Font-Bold="True" Font-Overline="False"
                            Font-Underline="True" Width="80px">Father</asp:Label></td>
                    <td style="width: 7px; height: 24px">
                    </td>
                    <td style="width: 240px; height: 24px">
                    </td>
                    <td style="width: 155px; height: 24px">
                    </td>
                    <td style="width: 7px; height: 24px">
                    </td>
                    <td style="width: 203px; height: 24px">
                    </td>
                </tr>
                <tr>
                    <td style="height: 0px">
                    </td>
                    <td style="height: 0px">
                        <asp:Label ID="Label78" runat="server" CssClass="Label" Text="Last Name"></asp:Label></td>
                    <td style="height: 0px">
                        :</td>
                    <td style="height: 0px">
                        <asp:Label ID="lblFatherLastName" runat="server" CssClass="Label"></asp:Label></td>
                    <td style="height: 0px">
                        <asp:Label ID="Label74" runat="server" CssClass="Label" Text="Middle Name"></asp:Label></td>
                    <td style="height: 0px">
                        :</td>
                    <td style="height: 0px">
                        <asp:Label ID="lblFatherMiddleName" runat="server" CssClass="Label"></asp:Label></td>
                </tr>
                <tr>
                    <td style="height: 0px">
                    </td>
                    <td style="height: 0px">
                        <asp:Label ID="Label72" runat="server" CssClass="Label" Text="First Name"></asp:Label></td>
                    <td style="height: 0px">
                        :</td>
                    <td style="height: 0px">
                        <asp:Label ID="lblFatherFirstName" runat="server" CssClass="Label"></asp:Label></td>
                    <td style="height: 0px">
                        <asp:Label ID="Label84" runat="server" CssClass="Label" Text="Nationality"></asp:Label></td>
                    <td style="height: 0px">
                        :</td>
                    <td style="height: 0px">
                        <asp:Label ID="lblFatherNationality" runat="server" CssClass="Label"></asp:Label></td>
                </tr>
                <tr>
                    <td style="height: 10px">
                    </td>
                    <td style="height: 10px">
                    </td>
                    <td style="height: 10px">
                    </td>
                    <td style="height: 10px">
                    </td>
                    <td style="height: 10px">
                    </td>
                    <td style="height: 10px">
                    </td>
                    <td style="height: 10px">
                    </td>
                </tr>
                <tr>
                    <td style="width: 10px; height: 24px">
                    </td>
                    <td style="width: 153px; height: 24px">
                        <asp:Label ID="Label73" runat="server" CssClass="Label" Font-Bold="True" Font-Overline="False"
                            Font-Underline="True" Width="80px">Mother</asp:Label></td>
                    <td style="width: 7px; height: 24px">
                    </td>
                    <td style="width: 240px; height: 24px">
                    </td>
                    <td style="width: 155px; height: 24px">
                    </td>
                    <td style="width: 7px; height: 24px">
                    </td>
                    <td style="width: 203px; height: 24px">
                    </td>
                </tr>
                <tr>
                    <td style="height: 0px">
                    </td>
                    <td style="height: 0px">
                        <asp:Label ID="Label95" runat="server" CssClass="Label" Text="Last Name"></asp:Label></td>
                    <td style="height: 0px">
                        :</td>
                    <td style="height: 0px">
                        <asp:Label ID="lblMotherLastName" runat="server" CssClass="Label"></asp:Label></td>
                    <td style="height: 0px">
                        <asp:Label ID="Label88" runat="server" CssClass="Label" Text="Middle Name"></asp:Label></td>
                    <td style="height: 0px">
                        :</td>
                    <td style="height: 0px">
                        <asp:Label ID="lblMotherMiddleName" runat="server" CssClass="Label"></asp:Label></td>
                </tr>
                <tr>
                    <td style="height: 0px">
                    </td>
                    <td style="height: 0px">
                        <asp:Label ID="Label76" runat="server" CssClass="Label" Text="First Name"></asp:Label></td>
                    <td style="height: 0px">
                        :</td>
                    <td style="height: 0px">
                        <asp:Label ID="lblMotherFirstName" runat="server" CssClass="Label"></asp:Label></td>
                    <td style="height: 0px">
                        <asp:Label ID="Label97" runat="server" CssClass="Label" Text="Nationality"></asp:Label></td>
                    <td style="height: 0px">
                        :</td>
                    <td style="height: 0px">
                        <asp:Label ID="lblMotherNationality" runat="server" CssClass="Label"></asp:Label></td>
                </tr>
                <tr>
                    <td style="height: 10px">
                    </td>
                    <td style="height: 10px">
                    </td>
                    <td style="height: 10px">
                    </td>
                    <td style="height: 10px">
                    </td>
                    <td style="height: 10px">
                    </td>
                    <td style="height: 10px">
                    </td>
                    <td style="height: 10px">
                    </td>
                </tr>
                <tr>
                    <td style="width: 10px; height: 24px">
                    </td>
                    <td colspan="6" style="height: 24px">
                        <asp:Label ID="lblFamilyErr" runat="server" CssClass="Label" ForeColor="Red"></asp:Label></td>
                </tr>
         
        </table>      
            </asp:View>            
            <asp:View ID="View5" runat="server">
            <table id="Table7" runat="server" border="0" cellpadding="0" cellspacing="0" visible="true">
                <tr>
                    <td style="width: 10px; height: 10px">
                    </td>
                    <td colspan="6" style="height: 10px">
                    </td>
                </tr>
                <tr>
                    <td style="width: 10px; height: 19px">
                    </td>
                    <td colspan="6" style="height: 19px">
                        <asp:Label ID="Label91" runat="server" BackColor="#C6EFEF" CssClass="LabelHeadGreen"
                            Text="Travel Details" Width="760px"></asp:Label></td>
                </tr>
                <tr>
                    <td style="width: 10px; height: 10px">
                    </td>
                    <td colspan="6" style="height: 10px">
                    </td>
                </tr>
                <tr>
                    <td style="width: 10px; height: 10px">
                    </td>
                    <td style="width: 153px; height: 24px">
                        <asp:Label ID="Label111" runat="server" CssClass="Label" Text="Visit Purpose"></asp:Label></td>
                    <td style="width: 7px; height: 10px">
                        :</td>
                    <td style="width: 240px; height: 10px">
                        <asp:Label ID="lblVisitPurpose" runat="server" CssClass="Label"></asp:Label></td>
                    <td style="width: 155px; height: 10px">
                        </td>
                    <td style="width: 7px; height: 10px">
                        </td>
                    <td style="width: 203px; height: 10px">
                        </td>
                </tr>
                <tr>
                    <td style="width: 10px; height: 24px">
                    </td>
                    <td colspan="4" style="height: 24px">
                        <asp:Label ID="Label118" runat="server" CssClass="Label" Text="If other family member, provide relationship" Width="248px"></asp:Label>:
                        <asp:Label ID="lblOtherVisitPurpose" runat="server" CssClass="Label"></asp:Label></td>
                    <td style="width: 7px; height: 24px">
                    </td>
                    <td style="width: 203px; height: 24px">
                    </td>
                </tr>
                <tr>
                    <td style="width: 10px; height: 10px">
                    </td>
                    <td style="width: 153px; height: 24px">
                        <asp:Label ID="Label122" runat="server" CssClass="Label" Text="Intended Length of Stay"></asp:Label></td>
                    <td style="width: 7px; height: 10px">
                        :</td>
                    <td style="width: 240px; height: 10px">
                        <asp:Label ID="lblLengthOfStay" runat="server" CssClass="Label"></asp:Label></td>
                    <td style="width: 155px; height: 10px">
                        <asp:Label ID="Label116" runat="server" CssClass="Label" Text="Date of Arrival"></asp:Label></td>
                    <td style="width: 7px; height: 10px">
                        :</td>
                    <td style="width: 203px; height: 10px">
                        <asp:Label ID="lblArrivalDate" runat="server" CssClass="Label"></asp:Label></td>
                </tr>
                <tr>
                    <td style="height: 20px">
                    </td>
                    <td style="height: 20px">
                    </td>
                    <td style="height: 20px">
                    </td>
                    <td style="height: 20px">
                    </td>
                    <td style="height: 20px">
                    </td>
                    <td style="height: 20px">
                    </td>
                    <td style="height: 20px">
                    </td>
                </tr>
                <tr>
                    <td style="width: 10px; height: 10px">
                    </td>
                    <td style="width: 153px; height: 24px">
                        <asp:Label ID="Label127" runat="server" CssClass="Label" Text="Name of Person/Hotel"></asp:Label></td>
                    <td style="width: 7px; height: 10px">
                        :</td>
                    <td style="width: 240px; height: 10px">
                        <asp:Label ID="lblHotelName" runat="server" CssClass="Label"></asp:Label></td>
                    <td style="width: 155px; height: 10px">
                        </td>
                    <td style="width: 7px; height: 10px">
                        </td>
                    <td style="width: 203px; height: 10px">
                        </td>
                </tr>
                <tr>
                    <td style="width: 10px; height: 24px">
                    </td>
                    <td style="width: 153px; height: 24px">
                        <asp:Label ID="Label119" runat="server" CssClass="Label" Text="Address of Person/Hotel"></asp:Label></td>
                    <td style="width: 7px; height: 24px">
                        :</td>
                    <td style="height: 24px" colspan="4">
                        <asp:Label ID="lblHotelAddress" runat="server" CssClass="Label"></asp:Label></td>
                </tr>
                <tr>
                    <td style="width: 10px; height: 24px">
                    </td>
                    <td style="width: 153px; height: 24px">
                        <asp:Label ID="Label135" runat="server" CssClass="Label" Text="Telephone No. of Person/Hotel" Width="145px"></asp:Label></td>
                    <td style="width: 7px; height: 24px">
                        :</td>
                    <td style="width: 240px; height: 24px">
                        <asp:Label ID="lblHotelPhone" runat="server" CssClass="Label"></asp:Label></td>
                    <td style="width: 155px; height: 24px">
                    </td>
                    <td style="width: 7px; height: 24px">
                    </td>
                    <td style="width: 203px; height: 24px">
                    </td>
                </tr>
                <tr>
                    <td style="height: 20px">
                    </td>
                    <td style="height: 20px">
                        </td>
                    <td style="height: 20px">
                        </td>
                    <td style="height: 20px">
                        </td>
                    <td style="height: 20px">
                        </td>
                    <td style="height: 20px">
                        </td>
                    <td style="height: 20px">
                        </td>
                </tr>
                <tr>
                    <td style="width: 10px; height: 10px">
                    </td>
                    <td colspan="3" style="height: 10px">
                        <asp:Label ID="Label129" runat="server" CssClass="Label" Font-Bold="True" Font-Underline="True"
                            Text="Financial Details"></asp:Label></td>
                    <td style="width: 155px; height: 10px">
                    </td>
                    <td style="width: 7px; height: 10px">
                    </td>
                    <td style="width: 203px; height: 10px">
                    </td>
                </tr>
                <tr>
                    <td style="width: 10px; height: 10px">
                    </td>
                    <td colspan="3" style="height: 10px">
                        <asp:Label ID="Label143" runat="server" CssClass="Label" Text="Who is paying for your trip to the country?"></asp:Label></td>
                    <td style="width: 155px; height: 10px">
                    </td>
                    <td style="width: 7px; height: 10px">
                    </td>
                    <td style="width: 203px; height: 10px">
                    </td>
                </tr>
                <tr>
                    <td style="width: 10px; height: 10px">
                    </td>
                    <td style="height: 24px" colspan="3">
                        <asp:Label ID="lblTripSponsorBy" runat="server" CssClass="Label"></asp:Label></td>
                    <td style="width: 155px; height: 10px">
                        </td>
                    <td style="width: 7px; height: 10px">
                        </td>
                    <td style="width: 203px; height: 10px">
                        </td>
                </tr>
                <tr>
                    <td style="height: 20px">
                    </td>
                    <td style="height: 20px">
                    </td>
                    <td style="height: 20px">
                    </td>
                    <td style="height: 20px">
                    </td>
                    <td style="height: 20px">
                    </td>
                    <td style="height: 20px">
                    </td>
                    <td style="height: 20px">
                    </td>
                </tr>
                <tr>
                    <td style="width: 10px; height: 10px">
                    </td>
                    <td colspan="3" style="height: 24px">
                        <asp:Label ID="Label124" runat="server" CssClass="Label" Text="How much money is available for your stay?"></asp:Label></td>
                    <td style="width: 155px; height: 10px">
                    </td>
                    <td style="width: 7px; height: 10px">
                    </td>
                    <td style="width: 203px; height: 10px">
                    </td>
                </tr>
                <tr>
                    <td style="width: 10px; height: 10px">
                    </td>
                    <td colspan="3" style="height: 24px">
                        <asp:Label ID="lblTripMoney" runat="server" CssClass="Label"></asp:Label></td>
                    <td style="width: 155px; height: 10px">
                    </td>
                    <td style="width: 7px; height: 10px">
                    </td>
                    <td style="width: 203px; height: 10px">
                    </td>
                </tr>
                <tr>
                    <td style="height: 10px">
                    </td>
                    <td style="height: 10px">
                    </td>
                    <td style="height: 10px">
                    </td>
                    <td style="height: 10px">
                    </td>
                    <td style="height: 10px">
                    </td>
                    <td style="height: 10px">
                    </td>
                    <td style="height: 10px">
                    </td>
                </tr>
                <tr>
                    <td style="width: 10px; height: 10px">
                    </td>
                    <td colspan="6" style="height: 24px">
                        <asp:Label ID="Label151" runat="server" CssClass="Label" ForeColor="Red"></asp:Label></td>
                </tr>
         
        </table>      
            </asp:View>
            <asp:View ID="View6" runat="server">
            <table id="Table5" runat="server" border="0" cellpadding="0" cellspacing="0" visible="true">
                <tr>
                    <td style="width: 10px; height: 10px">
                    </td>
                    <td colspan="6" style="height: 10px">
                    </td>
                </tr>
                <tr>
                    <td style="width: 10px; height: 19px">
                    </td>
                    <td colspan="6" style="height: 19px">
                        <asp:Label ID="Label66" runat="server" BackColor="#C6EFEF" CssClass="LabelHeadGreen"
                            Text="Criminal Details" Width="760px"></asp:Label></td>
                </tr>
                <tr>
                    <td style="width: 10px; height: 10px">
                    </td>
                    <td colspan="6" style="height: 10px">
                    </td>
                </tr>
                <tr>
                    <td style="width: 10px; height: 24px">
                    </td>
                    <td style="height: 24px" colspan="4">
                        <asp:Label ID="Label68" runat="server" CssClass="Label" Text="Do you have any criminal convictions?"
                            Width="226px" Font-Bold="True"></asp:Label><asp:CheckBox ID="ChkCriminalConvictionInd1" runat="server" CssClass="Label"
                                Text="Yes" Enabled="False" />
                        <asp:CheckBox ID="ChkCriminalConvictionInd2" runat="server" CssClass="Label" Text="No" Enabled="False" /></td>
                    <td style="width: 7px; height: 24px">
                    </td>
                    <td style="width: 203px; height: 24px">
                    </td>
                </tr>
                <tr>
                    <td style="width: 10px; height: 10px">
                    </td>
                    <td style="width: 153px; height: 10px">
                        <asp:Label ID="Label82" runat="server" CssClass="Label" Text="1. Offence"></asp:Label>
                    </td>
                    <td style="width: 7px; height: 10px">
                        :</td>
                    <td style="width: 240px; height: 10px">
                        <asp:Label ID="lblOffence1" runat="server" CssClass="Label"></asp:Label></td>
                    <td style="width: 155px; height: 10px">
                        <asp:Label ID="Label94" runat="server" CssClass="Label" Text="Offence Date"></asp:Label>
                    </td>
                    <td style="width: 7px; height: 10px">
                        :</td>
                    <td style="width: 203px; height: 10px">
                        <asp:Label ID="lblOffenceDate1" runat="server" CssClass="Label"></asp:Label></td>
                </tr>
                <tr>
                    <td style="width: 10px; height: 10px">
                    </td>
                    <td style="width: 153px; height: 10px">
                        &nbsp;&nbsp;
                        <asp:Label ID="Label115" runat="server" CssClass="Label" Text="Place of Offence"></asp:Label></td>
                    <td style="width: 7px; height: 10px">
                        :</td>
                    <td style="width: 240px; height: 10px">
                        <asp:Label ID="lblOffencePlace1" runat="server" CssClass="Label"></asp:Label></td>
                    <td style="width: 155px; height: 10px">
                        <asp:Label ID="Label117" runat="server" CssClass="Label" Text="Penalty"></asp:Label></td>
                    <td style="width: 7px; height: 10px">
                        :</td>
                    <td style="width: 203px; height: 10px">
                        <asp:Label ID="lblOffencePenalty1" runat="server" CssClass="Label"></asp:Label></td>
                </tr>
                <tr>
                    <td style="height: 5px">
                    </td>
                    <td style="height: 5px">
                        </td>
                    <td style="height: 5px">
                        </td>
                    <td style="height: 5px">
                        </td>
                    <td style="height: 5px">
                    </td>
                    <td style="height: 5px">
                    </td>
                    <td style="height: 5px">
                    </td>
                </tr>
                <tr>
                    <td style="width: 10px; height: 10px">
                    </td>
                    <td style="width: 153px; height: 10px">
                        <asp:Label ID="Label75" runat="server" CssClass="Label" Text="2. Offence"></asp:Label>
                    </td>
                    <td style="width: 7px; height: 10px">
                        :</td>
                    <td style="width: 240px; height: 10px">
                        <asp:Label ID="lblOffence2" runat="server" CssClass="Label"></asp:Label></td>
                    <td style="width: 155px; height: 10px">
                        <asp:Label ID="Label80" runat="server" CssClass="Label" Text="Offence Date"></asp:Label>
                    </td>
                    <td style="width: 7px; height: 10px">
                        :</td>
                    <td style="width: 203px; height: 10px">
                        <asp:Label ID="lblOffenceDate2" runat="server" CssClass="Label"></asp:Label></td>
                </tr>
                <tr>
                    <td style="width: 10px; height: 10px">
                    </td>
                    <td style="width: 153px; height: 10px">
                        &nbsp;&nbsp;
                        <asp:Label ID="Label109" runat="server" CssClass="Label" Text="Place of Offence"></asp:Label></td>
                    <td style="width: 7px; height: 10px">
                        :</td>
                    <td style="width: 240px; height: 10px">
                        <asp:Label ID="lblOffencePlace2" runat="server" CssClass="Label"></asp:Label></td>
                    <td style="width: 155px; height: 10px">
                        <asp:Label ID="Label120" runat="server" CssClass="Label" Text="Penalty"></asp:Label></td>
                    <td style="width: 7px; height: 10px">
                        :</td>
                    <td style="width: 203px; height: 10px">
                        <asp:Label ID="lblOffencePenalty2" runat="server" CssClass="Label"></asp:Label></td>
                </tr>
            <tr>
                <td style="height: 5px">
                </td>
                <td style="height: 5px">
                </td>
                <td style="height: 5px">
                </td>
                <td style="height: 5px">
                </td>
                <td style="height: 5px">
                </td>
                <td style="height: 5px">
                </td>
                <td style="height: 5px">
                </td>
            </tr>
                <tr>
                    <td style="width: 10px; height: 10px">
                    </td>
                    <td style="width: 153px; height: 10px">
                        <asp:Label ID="Label123" runat="server" CssClass="Label" Text="3. Offence"></asp:Label>
                    </td>
                    <td style="width: 7px; height: 10px">
                        :</td>
                    <td style="width: 240px; height: 10px">
                        <asp:Label ID="lblOffence3" runat="server" CssClass="Label"></asp:Label></td>
                    <td style="width: 155px; height: 10px">
                        <asp:Label ID="Label126" runat="server" CssClass="Label" Text="Offence Date"></asp:Label>
                    </td>
                    <td style="width: 7px; height: 10px">
                        :</td>
                    <td style="width: 203px; height: 10px">
                        <asp:Label ID="lblOffenceDate3" runat="server" CssClass="Label"></asp:Label></td>
                </tr>
                <tr>
                    <td style="width: 10px; height: 10px">
                    </td>
                    <td style="width: 153px; height: 10px">
                        &nbsp;&nbsp;
                        <asp:Label ID="Label128" runat="server" CssClass="Label" Text="Place of Offence"></asp:Label></td>
                    <td style="width: 7px; height: 10px">
                        :</td>
                    <td style="width: 240px; height: 10px">
                        <asp:Label ID="lblOffencePlace3" runat="server" CssClass="Label"></asp:Label></td>
                    <td style="width: 155px; height: 10px">
                        <asp:Label ID="Label130" runat="server" CssClass="Label" Text="Penalty"></asp:Label></td>
                    <td style="width: 7px; height: 10px">
                        :</td>
                    <td style="width: 203px; height: 10px">
                        <asp:Label ID="lblOffencePenalty3" runat="server" CssClass="Label"></asp:Label></td>
                </tr>
                <tr>
                    <td style="height: 5px">
                    </td>
                    <td style="height: 5px">
                    </td>
                    <td style="height: 5px">
                    </td>
                    <td style="height: 5px">
                    </td>
                    <td style="height: 5px">
                    </td>
                    <td style="height: 5px">
                    </td>
                    <td style="height: 5px">
                    </td>
                </tr>
                <tr>
                    <td style="width: 10px; height: 10px">
                    </td>
                    <td style="width: 153px; height: 10px">
                        <asp:Label ID="Label132" runat="server" CssClass="Label" Text="4. Offence"></asp:Label>
                    </td>
                    <td style="width: 7px; height: 10px">
                        :</td>
                    <td style="width: 240px; height: 10px">
                        <asp:Label ID="lblOffence4" runat="server" CssClass="Label"></asp:Label></td>
                    <td style="width: 155px; height: 10px">
                        <asp:Label ID="Label134" runat="server" CssClass="Label" Text="Offence Date"></asp:Label>
                    </td>
                    <td style="width: 7px; height: 10px">
                        :</td>
                    <td style="width: 203px; height: 10px">
                        <asp:Label ID="lblOffenceDate4" runat="server" CssClass="Label"></asp:Label></td>
                </tr>
                <tr>
                    <td style="width: 10px; height: 10px">
                    </td>
                    <td style="width: 153px; height: 10px">
                        &nbsp;&nbsp;
                        <asp:Label ID="Label136" runat="server" CssClass="Label" Text="Place of Offence"></asp:Label></td>
                    <td style="width: 7px; height: 10px">
                        :</td>
                    <td style="width: 240px; height: 10px">
                        <asp:Label ID="lblOffencePlace4" runat="server" CssClass="Label"></asp:Label></td>
                    <td style="width: 155px; height: 10px">
                        <asp:Label ID="Label138" runat="server" CssClass="Label" Text="Penalty"></asp:Label></td>
                    <td style="width: 7px; height: 10px">
                        :</td>
                    <td style="width: 203px; height: 10px">
                        <asp:Label ID="lblOffencePenalty4" runat="server" CssClass="Label"></asp:Label></td>
                </tr>
                <tr>
                    <td style="height: 5px">
                    </td>
                    <td style="height: 5px">
                    </td>
                    <td style="height: 5px">
                    </td>
                    <td style="height: 5px">
                    </td>
                    <td style="height: 5px">
                    </td>
                    <td style="height: 5px">
                    </td>
                    <td style="height: 5px">
                    </td>
                </tr>
                <tr>
                    <td style="width: 10px; height: 10px">
                    </td>
                    <td style="width: 153px; height: 10px">
                        <asp:Label ID="Label140" runat="server" CssClass="Label" Text="5. Offence"></asp:Label>
                    </td>
                    <td style="width: 7px; height: 10px">
                        :</td>
                    <td style="width: 240px; height: 10px">
                        <asp:Label ID="lblOffence5" runat="server" CssClass="Label"></asp:Label></td>
                    <td style="width: 155px; height: 10px">
                        <asp:Label ID="Label142" runat="server" CssClass="Label" Text="Offence Date"></asp:Label>
                    </td>
                    <td style="width: 7px; height: 10px">
                        :</td>
                    <td style="width: 203px; height: 10px">
                        <asp:Label ID="lblOffenceDate5" runat="server" CssClass="Label"></asp:Label></td>
                </tr>
                <tr>
                    <td style="width: 10px; height: 10px">
                    </td>
                    <td style="width: 153px; height: 10px">
                        &nbsp;&nbsp;
                        <asp:Label ID="Label144" runat="server" CssClass="Label" Text="Place of Offence"></asp:Label></td>
                    <td style="width: 7px; height: 10px">
                        :</td>
                    <td style="width: 240px; height: 10px">
                        <asp:Label ID="lblOffencePlace5" runat="server" CssClass="Label"></asp:Label></td>
                    <td style="width: 155px; height: 10px">
                        <asp:Label ID="Label146" runat="server" CssClass="Label" Text="Penalty"></asp:Label></td>
                    <td style="width: 7px; height: 10px">
                        :</td>
                    <td style="width: 203px; height: 10px">
                        <asp:Label ID="lblOffencePenalty5" runat="server" CssClass="Label"></asp:Label></td>
                </tr>
                <tr>
                    <td style="height: 20px">
                    </td>
                    <td style="height: 20px">
                    </td>
                    <td style="height: 20px">
                    </td>
                    <td style="height: 20px">
                    </td>
                    <td style="height: 20px">
                    </td>
                    <td style="height: 20px">
                    </td>
                    <td style="height: 20px">
                    </td>
                </tr>
                <tr>
                    <td style="width: 10px; height: 24px">
                    </td>
                    <td colspan="6" style="height: 24px">
                        <asp:Label ID="Label77" runat="server" CssClass="Label" Text="Have you ever been involved in the commission, preparation, organization or support of acts of terrorism, either within or outside the country or have you ever been a member of any organization which has been involved in or advocated terrorism?"
                            Width="747px"></asp:Label></td>
                </tr>
                <tr>
                    <td style="width: 10px; height: 24px">
                    </td>
                    <td colspan="3" style="height: 24px">
                        <asp:CheckBox ID="chkTerrorismInd1" runat="server" CssClass="Label"
                                Text="Yes" Enabled="False" />&nbsp;
                        <asp:CheckBox ID="chkTerrorismInd2" runat="server" CssClass="Label" Text="No" Enabled="False" />&nbsp;
                        <asp:Label ID="Label86" runat="server" CssClass="Label" Font-Italic="True" Text="(If yes, please provide details)"></asp:Label></td>
                    <td style="width: 138px; height: 24px">
                    </td>
                    <td style="width: 7px; height: 24px">
                    </td>
                    <td style="width: 203px; height: 24px">
                    </td>
                </tr>
                <tr>
                    <td style="width: 10px; height: 24px">
                    </td>
                    <td colspan="6" style="height: 24px">
                        <asp:Label ID="lblTerrorismDesc" runat="server" CssClass="Label" Width="747px"></asp:Label></td>
                </tr>
                <tr>
                    <td style="height: 10px">
                    </td>
                    <td style="height: 10px">
                    </td>
                    <td style="height: 10px">
                    </td>
                    <td style="height: 10px">
                    </td>
                    <td style="height: 10px">
                    </td>
                    <td style="height: 10px">
                    </td>
                    <td style="height: 10px">
                    </td>
                </tr>
                <tr>
                    <td style="width: 10px; height: 24px">
                    </td>
                    <td colspan="6" style="height: 24px">
                        <asp:Label ID="Label121" runat="server" CssClass="Label" ForeColor="Red"></asp:Label></td>
                </tr>
         
        </table>      
            </asp:View>
            <asp:View ID="View7" runat="server">
            <table id="Table6" runat="server" border="0" cellpadding="0" cellspacing="0" visible="true">
                <tr>
                    <td style="width: 10px; height: 10px">
                        &nbsp;
                    </td>
                    <td colspan="6" style="height: 10px">
                    </td>
                </tr>
                <tr>
                    <td style="width: 10px; height: 19px">
                        &nbsp;&nbsp;
                    </td>
                    <td colspan="6" style="height: 19px">
                        <asp:Label ID="Label9" runat="server" BackColor="#C6EFEF" CssClass="LabelHeadGreen"
                            Text="Additional Details" Width="760px"></asp:Label></td>
                </tr>
                <tr>
                    <td style="height: 10px">
                    </td>
                    <td style="height: 10px">
                    </td>
                    <td style="height: 10px">
                    </td>
                    <td style="height: 10px">
                    </td>
                    <td style="height: 10px">
                    </td>
                    <td style="height: 10px">
                    </td>
                    <td style="height: 10px">
                    </td>
                </tr>
                <tr>
                    <td style="width: 10px; height: 10px">
                    </td>
                    <td colspan="3" style="height: 24px">
                        <asp:Label ID="Label8" runat="server" CssClass="Label" Text="Are any of the following persons in the country?" Font-Bold="True"></asp:Label></td>
                    <td style="width: 155px; height: 10px">
                    </td>
                    <td style="width: 7px; height: 10px">
                    </td>
                    <td style="width: 203px; height: 10px">
                    </td>
                </tr>
                <tr>
                    <td style="width: 10px; height: 10px">
                    </td>
                    <td style="width: 153px; height: 24px">
                        <asp:Label ID="Label31" runat="server" CssClass="Label" Text="1. Father"></asp:Label></td>
                    <td style="width: 7px; height: 10px">
                        :</td>
                    <td style="width: 240px; height: 10px"><asp:CheckBox ID="ChkFatherInBhsInd1" runat="server" CssClass="Label" Text="Yes" Enabled="False" /><asp:CheckBox ID="ChkFatherInBhsInd2" runat="server" CssClass="Label" Text="No" Enabled="False" /></td>
                    <td style="width: 155px; height: 10px">
                        <asp:Label ID="Label32" runat="server" CssClass="Label" Text="Residential Status"></asp:Label></td>
                    <td style="width: 7px; height: 10px">
                        :</td>
                    <td style="width: 203px; height: 10px">
                        <asp:Label ID="lblFatherResidentialStatus" runat="server" CssClass="Label"></asp:Label></td>
                </tr>
                <tr>
                    <td style="width: 10px; height: 10px">
                    </td>
                    <td style="width: 153px; height: 24px">
                        <asp:Label ID="Label43" runat="server" CssClass="Label" Text="2. Mother"></asp:Label></td>
                    <td style="width: 7px; height: 10px">
                        :</td>
                    <td style="width: 240px; height: 10px"><asp:CheckBox ID="ChkMotherInBhsInd1" runat="server" CssClass="Label" Text="Yes" Enabled="False" /><asp:CheckBox ID="ChkMotherInBhsInd2" runat="server" CssClass="Label" Text="No" Enabled="False" /></td>
                    <td style="width: 155px; height: 10px">
                        <asp:Label ID="Label47" runat="server" CssClass="Label" Text="Residential Status"></asp:Label></td>
                    <td style="width: 7px; height: 10px">
                        :</td>
                    <td style="width: 203px; height: 10px">
                        <asp:Label ID="lblMotherResidentialStatus" runat="server" CssClass="Label"></asp:Label></td>
                </tr>
                <tr>
                    <td style="width: 10px; height: 10px">
                    </td>
                    <td style="width: 153px; height: 24px">
                        <asp:Label ID="Label49" runat="server" CssClass="Label" Text="3. Spouse"></asp:Label></td>
                    <td style="width: 7px; height: 10px">
                        :</td>
                    <td style="width: 240px; height: 10px"><asp:CheckBox ID="ChkSpouseInBhsInd1" runat="server" CssClass="Label" Text="Yes" Enabled="False" /><asp:CheckBox ID="ChkSpouseInBhsInd2" runat="server" CssClass="Label" Text="No" Enabled="False" /></td>
                    <td style="width: 155px; height: 10px">
                        <asp:Label ID="Label50" runat="server" CssClass="Label" Text="Residential Status"></asp:Label></td>
                    <td style="width: 7px; height: 10px">
                        :</td>
                    <td style="width: 203px; height: 10px">
                        <asp:Label ID="lblSpouseResidentialStatus" runat="server" CssClass="Label"></asp:Label></td>
                </tr>
                <tr>
                    <td style="width: 10px; height: 10px">
                    </td>
                    <td style="width: 153px; height: 24px">
                        <asp:Label ID="Label51" runat="server" CssClass="Label" Text="4. Sibling/s"></asp:Label></td>
                    <td style="width: 7px; height: 10px">
                        :</td>
                    <td style="width: 240px; height: 10px"><asp:CheckBox ID="ChkSiblingInBhsInd1" runat="server" CssClass="Label" Text="Yes" Enabled="False" /><asp:CheckBox ID="ChkSiblingInBhsInd2" runat="server" CssClass="Label" Text="No" Enabled="False" /></td>
                    <td style="width: 155px; height: 10px">
                        <asp:Label ID="Label52" runat="server" CssClass="Label" Text="Residential Status"></asp:Label></td>
                    <td style="width: 7px; height: 10px">
                        :</td>
                    <td style="width: 203px; height: 10px">
                        <asp:Label ID="lblSiblingResidentialStatus" runat="server" CssClass="Label"></asp:Label></td>
                </tr>
                <tr>
                    <td style="width: 10px; height: 10px">
                    </td>
                    <td style="width: 153px; height: 24px">
                        <asp:Label ID="Label54" runat="server" CssClass="Label" Text="5. Children"></asp:Label></td>
                    <td style="width: 7px; height: 10px">
                        :</td>
                    <td style="width: 240px; height: 10px"><asp:CheckBox ID="ChkChildrenInBhsInd1" runat="server" CssClass="Label" Text="Yes" Enabled="False" /><asp:CheckBox ID="ChkChildrenInBhsInd2" runat="server" CssClass="Label" Text="No" Enabled="False" /></td>
                    <td style="width: 155px; height: 10px">
                        <asp:Label ID="Label55" runat="server" CssClass="Label" Text="Residential Status"></asp:Label></td>
                    <td style="width: 7px; height: 10px">
                        :</td>
                    <td style="width: 203px; height: 10px">
                        <asp:Label ID="lblChildrenResidentialStatus" runat="server" CssClass="Label"></asp:Label></td>
                </tr>
                <tr>
                    <td style="height: 10px">
                    </td>
                    <td style="height: 10px">
                    </td>
                    <td style="height: 10px">
                    </td>
                    <td style="height: 10px">
                    </td>
                    <td style="height: 10px">
                    </td>
                    <td style="height: 10px">
                    </td>
                    <td style="height: 10px">
                    </td>
                </tr>
                <tr>
                    <td style="height: 20px">
                    </td>
                    <td colspan="3" style="height: 20px">
                        <asp:Label ID="Label56" runat="server" CssClass="Label" Text="Have you ever visited the country?"
                            Width="217px"></asp:Label>
                        <asp:CheckBox ID="ChkVisitedBhsInd1" runat="server" CssClass="Label" Text="Yes" Enabled="False" />&nbsp;
                        <asp:CheckBox ID="ChkVisitedBhsInd2" runat="server" CssClass="Label" Text="No" Enabled="False" /></td>
                    <td style="height: 20px">
                    </td>
                    <td style="height: 20px">
                    </td>
                    <td style="height: 20px">
                    </td>
                </tr>
                <tr>
                    <td style="height: 20px">
                    </td>
                    <td style="height: 20px">
                        <asp:Label ID="Label57" runat="server" CssClass="Label" Text="Date of Last Visit"></asp:Label></td>
                    <td style="height: 20px">
                        :</td>
                    <td style="height: 20px">
                        <asp:Label ID="lblLastVisitDate" runat="server" CssClass="Label"></asp:Label></td>
                    <td style="height: 20px">
                    </td>
                    <td style="height: 20px">
                    </td>
                    <td style="height: 20px">
                    </td>
                </tr>
                <tr>
                    <td style="height: 10px">
                    </td>
                    <td style="height: 10px">
                    </td>
                    <td style="height: 10px">
                    </td>
                    <td style="height: 10px">
                    </td>
                    <td style="height: 10px">
                    </td>
                    <td style="height: 10px">
                    </td>
                    <td style="height: 10px">
                    </td>
                </tr>
                <tr>
                    <td style="height: 20px">
                    </td>
                    <td colspan="3" style="height: 20px">
                        <asp:Label ID="Label59" runat="server" CssClass="Label" Text="Have you ever applied for a Visa?"
                            Width="257px"></asp:Label><asp:CheckBox ID="ChkAppliedVisaInd1" runat="server" CssClass="Label"
                                Text="Yes" Enabled="False" />&nbsp;
                        <asp:CheckBox ID="ChkAppliedVisaInd2" runat="server" CssClass="Label" Text="No" Enabled="False" /></td>
                    <td style="height: 20px">
                    </td>
                    <td style="height: 20px">
                    </td>
                    <td style="height: 20px">
                    </td>
                </tr>
                <tr>
                    <td style="height: 20px">
                    </td>
                    <td style="height: 20px">
                        <asp:Label ID="Label60" runat="server" CssClass="Label" Text="Place"></asp:Label></td>
                    <td style="height: 20px">
                        :</td>
                    <td style="height: 20px">
                        <asp:Label ID="lblAppliedVisaPlace" runat="server" CssClass="Label"></asp:Label></td>
                    <td style="height: 20px">
                        <asp:Label ID="Label62" runat="server" CssClass="Label" Text="Date"></asp:Label></td>
                    <td style="height: 20px">
                        :</td>
                    <td style="height: 20px">
                        <asp:Label ID="lblAppliedVisaDate" runat="server" CssClass="Label"></asp:Label></td>
                </tr>
                <tr>
                    <td style="height: 10px">
                    </td>
                    <td style="height: 10px">
                    </td>
                    <td style="height: 10px">
                    </td>
                    <td style="height: 10px">
                    </td>
                    <td style="height: 10px">
                    </td>
                    <td style="height: 10px">
                    </td>
                    <td style="height: 10px">
                    </td>
                </tr>
                <tr>
                    <td style="height: 20px">
                    </td>
                    <td colspan="3" style="height: 20px">
                        <asp:Label ID="Label63" runat="server" CssClass="Label" Text="What was the outcome of your application?"
                            Width="257px"></asp:Label></td>
                    <td style="height: 20px">
                    </td>
                    <td style="height: 20px">
                    </td>
                    <td style="height: 20px">
                    </td>
                </tr>
                <tr>
                    <td style="height: 20px">
                    </td>
                    <td colspan="3" style="height: 20px">
                        <asp:CheckBox ID="ChkVisaOutcome1" runat="server" CssClass="Label" Text="Visa Granted" Enabled="False" />
                        &nbsp;&nbsp;
                        <asp:CheckBox ID="ChkVisaOutcome2" runat="server" CssClass="Label" Text="Visa Denied" Enabled="False" /></td>
                    <td style="height: 20px">
                    </td>
                    <td style="height: 20px">
                    </td>
                    <td style="height: 20px">
                    </td>
                </tr>
                <tr>
                    <td style="height: 10px">
                    </td>
                    <td style="height: 10px">
                    </td>
                    <td style="height: 10px">
                    </td>
                    <td style="height: 10px">
                    </td>
                    <td style="height: 10px">
                    </td>
                    <td style="height: 10px">
                    </td>
                    <td style="height: 10px">
                    </td>
                </tr>
                <tr>
                    <td style="width: 10px; height: 24px">
                    </td>
                    <td colspan="4" style="height: 24px">
                        <asp:Label ID="Label64" runat="server" CssClass="Label" Text="Have you ever been deported, remanded or required to leave the country?"
                            Width="432px"></asp:Label><asp:CheckBox ID="ChkDeportedInd1" runat="server" CssClass="Label"
                                Text="Yes" Enabled="False" />&nbsp;
                        <asp:CheckBox ID="ChkDeportedInd2" runat="server" CssClass="Label" Text="No" Enabled="False" /></td>
                    <td style="width: 7px; height: 24px">
                    </td>
                    <td style="width: 203px; height: 24px">
                    </td>
                </tr>
                <tr>
                    <td style="width: 10px; height: 10px">
                    </td>
                    <td colspan="6" style="height: 10px">
                    </td>
                </tr>
                <tr>
                    <td style="width: 10px; height: 24px">
                    </td>
                    <td style="height: 24px" colspan="6">
                        <asp:Label ID="lblAdditionalErr" runat="server" CssClass="Label" ForeColor="Red"></asp:Label></td>
                </tr>
         
        </table>      
            </asp:View>
            <asp:View ID="View8" runat="server">
                <table id="Table10" runat="server" border="0" cellpadding="0" cellspacing="0" visible="true">
                    <tr>
                        <td style="width: 10px; height: 10px">
                        </td>
                        <td colspan="6" style="height: 10px">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 10px; height: 19px">
                        </td>
                        <td colspan="6" style="height: 19px">
                            <asp:Label ID="Label10" runat="server" BackColor="#C6EFEF" CssClass="LabelHeadGreen"
                                Text="Scanned Documents" Width="760px"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="width: 10px; height: 10px">
                        </td>
                        <td colspan="6" style="height: 10px">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 10px; height: 24px">
                        </td>
                        <td colspan="6" style="height: 24px">
                        <div id="divScanDoc" runat="server" class="PanelDataGrid">
                            <asp:GridView ID="dgScanDocList" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                CellPadding="4" CssClass="Label" ForeColor="#333333" GridLines="None" Width="785px" OnPageIndexChanging="dgScanDocList_PageIndexChanging" OnRowCommand="dgScanDocList_RowCommand">
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                           <asp:ImageButton ID="ImageButton1" runat="server"  CommandArgument='<%#  Eval("ID")+"-"+Eval("SYSTEM") %>' CommandName="View"  CausesValidation="False" ImageUrl="~/images/viewImage.gif" AlternateText="View Document"/>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="SYSTEM">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSysten" runat="server" Text='<%# Eval("SYSTEM") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" />
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="DOCUMENT TYPE">
                                        <ItemStyle HorizontalAlign="Left" />
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblType" runat="server" Text='<%# Eval("ScannedDoc") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="PAGE NO">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblPageNo" runat="server" Text='<%# Eval("PageNo") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="DESCRIPTION">
                                        <ItemStyle HorizontalAlign="Left" />
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblDesc" runat="server" Text='<%# Eval("IMAGEDESC") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ENTRY TIME">
                                        <ItemStyle HorizontalAlign="Left" />
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblTime" runat="server" Text='<%# Eval("IMAGEENTRYTIME") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <RowStyle BackColor="#EFF3FB" VerticalAlign="Top" />
                                <EditRowStyle BackColor="#2461BF" VerticalAlign="Top" />
                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" VerticalAlign="Top" />
                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" HorizontalAlign="Left"
                                    VerticalAlign="Top" />
                                <AlternatingRowStyle BackColor="White" VerticalAlign="Top" />
                            </asp:GridView>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 10px; height: 24px">
                        </td>
                        <td style="width: 153px; height: 24px">
                        </td>
                        <td style="width: 7px; height: 24px">
                        </td>
                        <td colspan="4" style="height: 24px">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 10px; height: 24px">
                        </td>
                        <td style="height: 24px" colspan="6">
                            <asp:Label ID="lblScannedDocMsg" runat="server" CssClass="Label" ForeColor="Blue"></asp:Label><asp:Label
                                ID="lblScannedDocErr" runat="server" CssClass="Label" ForeColor="Red"></asp:Label></td>
                    </tr>
                </table>
            </asp:View>                        
            <asp:View ID="View9" runat="server">
                <table id="Table2" runat="server" border="0" cellpadding="0" cellspacing="0" visible="true">
                    <tr>
                        <td style="width: 10px; height: 10px">
                        </td>
                        <td colspan="6" style="height: 10px">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 10px; height: 19px">
                        </td>
                        <td colspan="6" style="height: 19px">
                            <asp:Label ID="Label11" runat="server" BackColor="#C6EFEF" CssClass="LabelHeadGreen"
                                Text="Approval History" Width="760px"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="width: 10px; height: 10px">
                        </td>
                        <td colspan="6" style="height: 10px">
                        </td>
                    </tr>
                  
                    <tr>
                        <td style="width: 10px; height: 24px">
                        </td>
                        <td style="height: 24px" colspan="6">
                        <div id="divApprovalHistory" runat="server" class="PanelDataGrid">
                            <asp:GridView ID="gvAppHistory" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                CellPadding="3" CssClass="Label" ForeColor="#333333" GridLines="None" Width="796px"                              
                                PageSize="5" OnPageIndexChanging="gvAppHistory_PageIndexChanging" OnRowCommand="gvAppHistory_RowCommand">
                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <Columns>
                                    <asp:BoundField DataField="ApprovalLevel" HeaderText="LEVEL" />
                                    <asp:BoundField DataField="AStageCode" HeaderText="STATUS" />
                                    <asp:BoundField DataField="DocType" HeaderText="VISA TYPE" />
                                    <asp:BoundField DataField="EntryType" HeaderText="ENTRY TYPE" />
                                    <asp:TemplateField HeaderText="INTERVIEW NOTE">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkButton2" runat="server" CommandArgument='<%# Eval("InterviewNote") %>'
                                                CommandName="Summary">
                                         View</asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ANNOTATION">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbAnnotation" runat="server" CommandArgument='<%# Eval("Annotation") %>'
                                                CommandName="Annotation">View</asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="REMARKS">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbRemarks" runat="server" CommandArgument='<%# Eval("Remark") %>'
                                                CommandName="Remark">View</asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="UpdateBy" HeaderText="UPDATED BY" />
                                    <asp:BoundField DataField="UpdateTime" HeaderText="UPDATED DATE" />
                                </Columns>
                                <RowStyle BackColor="#EFF3FB" VerticalAlign="Top" />
                                <EditRowStyle BackColor="#2461BF" VerticalAlign="Top" />
                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" VerticalAlign="Top" />
                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" HorizontalAlign="Left"
                                    VerticalAlign="Top" />
                                <AlternatingRowStyle BackColor="White" VerticalAlign="Top" />
                            </asp:GridView>
                        </div>
                        </td>
                    </tr>
                      <tr>
                        <td style="width: 10px; height: 24px">
                        </td>
                        <td colspan="6" style="height: 24px">
                            <asp:Label ID="lblAppHistoryMsg" runat="server" CssClass="Label" ForeColor="Blue"></asp:Label><asp:Label
                                ID="lblAppHistoryErr" runat="server" CssClass="Label" ForeColor="Red"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="width: 10px; height: 24px">
                        </td>
                        <td style="width: 153px; height: 24px">
                        </td>
                        <td style="width: 7px; height: 24px">
                        </td>
                        <td style="width: 240px; height: 24px">
                        </td>
                        <td style="width: 138px; height: 24px">
                        </td>
                        <td style="width: 7px; height: 24px">
                        </td>
                        <td style="width: 203px; height: 24px">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 10px; height: 24px">
                        </td>
                        <td colspan="6" style="height: 24px">
                            <table id="ViewHistory" runat="server" border="1" cellpadding="3" cellspacing="0"
                                style="border-left-color: gray; border-bottom-color: gray; border-top-style: solid;
                                border-top-color: gray; border-right-style: solid; border-left-style: solid;
                                border-right-color: gray; border-bottom-style: solid" visible="false">
                                <tr>
                                    <td style="width: 758px; height: 256px">
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblViewTitle" runat="server" CssClass="Label" Font-Bold="True" Font-Underline="True"
                                                        Text="Applicant Summary"></asp:Label></td>
                                                <td>
                                                </td>
                                                <td align="right">
                                                    <asp:LinkButton ID="lbClose" runat="server" CssClass="Label" Font-Bold="True" OnClick="lbClose_Click"
                                                        >Close</asp:LinkButton></td>
                                            </tr>
                                            <tr>
                                                <td colspan="3">
                                                    <asp:TextBox ID="txtViewAppSummary" runat="server" Height="204px" ReadOnly="True"
                                                        TextMode="MultiLine" Width="745px"></asp:TextBox></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>                    
                
                    
                    
                      <tr visible="false" runat="server" id="trPaymentHistory1">
                        <td style="width: 10px; height: 19px">
                        </td>
                        <td colspan="6" style="height: 19px">
                            <asp:Label ID="Label159" runat="server" BackColor="#C6EFEF" CssClass="LabelHeadGreen"
                                Text="Payment History" Width="760px"></asp:Label></td>
                    </tr>
                     <tr visible="false" runat="server" id="trPaymentHistory2">
                        <td style="width: 10px; height: 10px">
                        </td>
                        <td colspan="6" style="height: 10px">
                        <asp:Label ID="lblPaymentHistory" runat="server" CssClass="Label" ForeColor="Blue" Text="No data available"></asp:Label>
                        </td>
                    </tr>
                    <tr visible="false" runat="server" id="trPaymentHistory3">
                        <td style="width: 10px; height: 24px">
                        </td>
                        <td style="height: 24px" colspan="6">
                        <div id="divPayment" runat="server" class="PanelDataGrid">
                            <asp:GridView ID="dgPayment" runat="server" AutoGenerateColumns="False"
                            CellPadding="4" CssClass="Label" ForeColor="#333333" GridLines="None" 
                            Width="796px" AllowPaging="True" PageSize="5" OnPageIndexChanging="dgPayment_PageIndexChanging">
                            <Columns>
                                 <asp:TemplateField HeaderText="PAYMENT DATE">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblReceipt" runat="server" Text='<%# Eval("PAYMENTTIME") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="RECEIPT NO">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblType" runat="server" Text='<%# Eval("RECEIPTNO") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="PAYMENT METHOD">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblPageNo" runat="server" Text='<%# Eval("PAYMENTMETHOD") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="CARD NO/CHEQUE NO">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblDesc1" runat="server" Text='<%# Eval("CARDNO") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="AMOUNT ($)">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblDesc" runat="server" Text='<%# Eval("PAYMENTAMT") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="RECEIVED BY">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblTime" runat="server" Text='<%# Eval("PAYMENTRECVBY") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                  <asp:TemplateField HeaderText="AMOUNT CHANGED BY">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblTime" runat="server" Text='<%# Eval("AMOUNTCHANGEDBY") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="REMARKS">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblTime" runat="server" Text='<%# Eval("PAYMENTREMARK") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <RowStyle BackColor="#EFF3FB" VerticalAlign="Top"/>
                            <EditRowStyle BackColor="#2461BF" VerticalAlign="Top"/>
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" VerticalAlign="Top"/>
                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" VerticalAlign="Top" HorizontalAlign="Left"/>
                            <AlternatingRowStyle BackColor="White"  VerticalAlign="Top"/>
                     </asp:GridView>
                        </div>
                        </td>
                    </tr>
       <tr id="Tr6" runat="server">
           <td style="width: 10px; height: 19px">
           </td>
           <td colspan="6" style="height: 19px">
           </td>
       </tr>
                       <tr visible="false" runat="server" id="trIssuance1">
                        <td style="width: 10px; height: 19px">
                        </td>
                        <td colspan="6" style="height: 19px">
                            <asp:Label ID="Label160" runat="server" BackColor="#C6EFEF" CssClass="LabelHeadGreen"
                                Text="Third Party Issuance Details" Width="760px"></asp:Label></td>
                    </tr>
       <tr id="trIssuanceNoData" runat="server" visible="false">
           <td style="width: 10px; height: 19px">
           </td>
           <td colspan="6" style="height: 19px">
               <asp:Label ID="Label164" runat="server" CssClass="Label" ForeColor="Blue" Text="No data available"></asp:Label></td>
       </tr>
       <tr id="trIssuance2" runat="server" visible="false">
           <td style="width: 10px; height: 19px">
           </td>
           <td colspan="6" style="height: 19px">
               <table border="0" cellpadding="1" cellspacing="2">
                   <tr>
                       <td style="width: 104px; height: 21px;">
                           <asp:Label ID="Label165" runat="server" Text="Name" CssClass="Label"></asp:Label></td>
                       <td style="width: 9px; height: 21px;">
                           :</td>
                       <td style="width: 237px; height: 21px;">
                           <asp:Label ID="TP_NAME" runat="server" CssClass="Label"></asp:Label></td>
                       <td style="width: 127px; height: 21px;">
                           <asp:Label ID="Label172" runat="server" Text="Document No." CssClass="Label"></asp:Label></td>
                       <td style="width: 12px; height: 21px;">
                           :</td>
                       <td style="width: 252px; height: 21px;">
                           <asp:Label ID="TP_DOCNO" runat="server" CssClass="Label"></asp:Label></td>
                   </tr>
                   <tr>
                       <td style="width: 104px; height: 19px" valign="top">
                           <asp:Label ID="Label173" runat="server" Text="Phone No." CssClass="Label"></asp:Label></td>
                       <td style="width: 9px; height: 19px" valign="top">
                           :</td>
                       <td style="width: 237px; height: 19px" valign="top">
                           <asp:Label ID="TP_PHONE" runat="server" CssClass="Label"></asp:Label></td>
                       <td style="width: 127px; height: 19px" valign="top">
                           <asp:Label ID="Label174" runat="server" Text="Remarks" CssClass="Label"></asp:Label></td>
                       <td style="width: 12px; height: 19px" valign="top">
                           :</td>
                       <td style="width: 252px; height: 19px">
                           <asp:TextBox ID="TP_REMARKS" runat="server" ReadOnly="True" Rows="4" TextMode="MultiLine"
                               Width="240px" CssClass="Label"></asp:TextBox></td>
                   </tr>
               </table>
           </td>
       </tr>
       <tr id="Tr11" runat="server" visible="false">
           <td style="width: 10px; height: 19px">
           </td>
           <td colspan="6" style="height: 19px">
           </td>
       </tr>
                </table>
            </asp:View>
            <asp:View ID="View10" runat="server">
                <table id="Table9" runat="server" border="0" cellpadding="0" cellspacing="0" visible="true">
                    <tr>
                        <td style="width: 10px; height: 10px">
                        </td>
                        <td colspan="6" style="height: 10px">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 10px; height: 19px">
                        </td>
                        <td colspan="6" style="height: 19px">
                            <asp:Label ID="Label13" runat="server" BackColor="#C6EFEF" CssClass="LabelHeadGreen"
                                Text="Action" Width="760px"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="width: 10px; height: 10px">
                        </td>
                        <td colspan="6" style="height: 10px">
                            <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtAppDurationMonth"
                                ErrorMessage="Duration month must be in the range of 0 to 11" ForeColor="White"
                                MaximumValue="11" MinimumValue="0" Type="Integer"></asp:RangeValidator></td>
                    </tr>
                    <tr id="Tr1" runat="server">
                        <td style="width: 10px; height: 22px">
                        </td>
                        <td style="width: 146px; height: 22px" valign="middle">
                            <asp:Label ID="Label149" runat="server" CssClass="Label" Text="Watchlist Status"></asp:Label></td>
                        <td style="width: 1px; height: 22px" valign="top">
                            :</td>
                        <td colspan="4" style="width: 650px; height: 22px">
                                        <asp:Label ID="lblWLStatus" runat="server" BackColor="Red" CssClass="Label" Font-Bold="True"
                                            Text="On Watchlist" Width="217px"></asp:Label></td>
                    </tr>
                    <tr id="trInterviewNote" runat="server" >
                        <td style="width: 10px; height: 22px">
                        </td>
                        <td style="width: 146px; height: 22px" valign="top">
                            <asp:Label ID="Label317" runat="server" CssClass="Label" Text="Interview Notes"></asp:Label>
                            <asp:Label ID="Label18" runat="server" CssClass="Label" Font-Bold="False" ForeColor="Red"
                                Text="*"></asp:Label></td>
                        <td style="width: 1px; height: 22px" valign="top">
                            :</td>
                        <td colspan="4" style="width: 650px; height: 22px">
                            <asp:TextBox ID="txtInterviewNote" runat="server" Height="189px" MaxLength="1024" TextMode="MultiLine" CssClass="Label"
                                Width="486px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RFVAppSummary" runat="server" ControlToValidate="txtInterviewNote"
                                CssClass="Label" ErrorMessage="Interview Note is a mandatory field" ForeColor="White" Width="12px">*</asp:RequiredFieldValidator></td>
                    </tr>
                    <tr id="Tr2"  runat="server" >
                        <td style="width: 10px; height: 25px">
                        </td>
                        <td style="width: 146px; height: 25px" valign="middle">
                            <asp:Label ID="Label19" runat="server" CssClass="Label" Text="Approved Entry Type"></asp:Label>
                            <asp:Label ID="Label114" runat="server" CssClass="Label" Font-Bold="False" ForeColor="Red"
                                Text="*"></asp:Label></td>
                        <td style="width: 1px; height: 25px" valign="top">
                            :&nbsp;
                        </td>
                        <td colspan="4" style="width: 650px; height: 25px">
                            <asp:DropDownList ID="ddlEntryType" runat="server">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RFVDOIRecommendation" runat="server" ControlToValidate="ddlEntryType"
                                CssClass="Label" ErrorMessage="Entry Type is a mandatory field" ForeColor="White" Width="17px">*</asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtAppDurationWeek"
                                ErrorMessage="Duration week must be in the range of 0 to 5" ForeColor="White"
                                ValidationExpression="[0-5]" Width="295px"></asp:RegularExpressionValidator></td>
                    </tr>
                    <tr id="Tr3" runat="server" >
                        <td style="width: 10px; height: 25px">
                        </td>
                        <td style="width: 146px; height: 25px" valign="middle">
                            <asp:Label ID="Label87" runat="server" CssClass="Label" Text="Approved Visa Type"></asp:Label>
                            <asp:Label ID="Label112" runat="server" CssClass="Label" Font-Bold="False" ForeColor="Red"
                                Text="*"></asp:Label></td>
                        <td style="width: 1px; height: 25px" valign="top">
                            :</td>
                        <td colspan="4" style="width: 650px; height: 25px">
                            <asp:DropDownList ID="ddlDocType" runat="server" OnSelectedIndexChanged="ddlDocType_SelectedIndexChanged" AutoPostBack="True" >
                            </asp:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                ControlToValidate="ddlDocType" CssClass="Label" ErrorMessage="Visa Type is a mandatory field"
                                ForeColor="White" Width="17px">*</asp:RequiredFieldValidator>
                          </td>
                    </tr>
                    <tr id="trVisaClass" runat="server" visible="false" >
                        <td style="width: 10px; height: 25px">
                        </td>
                        <td style="width: 146px; height: 25px" valign="top">
                            <asp:Label ID="Label131" runat="server" CssClass="Label" Text="Approved Visa Class"></asp:Label>
                            <asp:Label ID="Label133" runat="server" CssClass="Label" Font-Bold="False" ForeColor="Red"
                                Text="*"></asp:Label>
                            </td>
                        <td style="width: 1px; height: 25px" valign="top">
                            :</td>
                        <td colspan="4" style="width: 650px; height: 25px">
                            <asp:CheckBoxList ID="ChkVisaClass" runat="server" CssClass="Label">
                            </asp:CheckBoxList></td>
                    </tr>
                    <tr id="Tr4" runat="server" >
                        <td style="width: 10px; height: 25px">
                        </td>
                        <td style="width: 146px; height: 25px" valign="middle">
                            <asp:Label ID="Label28" runat="server" CssClass="Label" Text="Validity Period"></asp:Label>
                            <asp:Label ID="Label33" runat="server" CssClass="Label" Font-Bold="False" ForeColor="Red"
                                Text="*"></asp:Label></td>
                        <td style="width: 1px; height: 25px" valign="top">
                            :</td>
                        <td colspan="4" style="width: 650px; height: 25px">
                            <asp:TextBox ID="txtAppDurationWeek" runat="server" Width="35px"></asp:TextBox>
                            <asp:Label ID="Label137" runat="server" CssClass="Label" Text="Week"></asp:Label>
                            <asp:TextBox ID="txtAppDurationMonth" runat="server"  Width="35px"></asp:TextBox>
                            <asp:Label ID="Label139" runat="server" CssClass="Label" Text="Month"></asp:Label>
                            <asp:TextBox ID="txtAppDurationYear" runat="server" Width="35px"></asp:TextBox>
                            <asp:Label ID="Label141" runat="server" CssClass="Label" Text="Year"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtAppDurationWeek"
                                CssClass="Label" ErrorMessage="Duration week is a mandatory field" ForeColor="White"
                                Width="12px">*</asp:RequiredFieldValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtAppDurationMonth"
                                CssClass="Label" ErrorMessage="Duration month is a mandatory field" ForeColor="White"
                                Width="12px">*</asp:RequiredFieldValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtAppDurationYear"
                                CssClass="Label" ErrorMessage="Duration year is a mandatory field" ForeColor="White"
                                Width="12px">*</asp:RequiredFieldValidator></td>
                    </tr>
                    <tr id="Tr5" runat="server" >
                 <td style="width: 10px; height: 22px">
                 </td>
                 <td style="width: 146px; height: 22px" valign="top">
                            <asp:Label ID="Label45" runat="server" CssClass="Label" Text="Remarks"></asp:Label>
                     <asp:Label ID="Label150" runat="server" CssClass="Label" Font-Bold="False" ForeColor="Red"
                         Text="*" Visible="False"></asp:Label></td>
                 <td style="width: 1px; height: 22px" valign="top">
                     :</td>
                 <td colspan="4" style="width: 650px; height: 22px">
                            <asp:TextBox ID="txtRemarks" runat="server" Height="55px" MaxLength="1024" TextMode="MultiLine" CssClass="Label"
                                Width="486px"></asp:TextBox>
                     <asp:RequiredFieldValidator ID="RFVRemarks" runat="server" ControlToValidate="txtRemarks"
                         CssClass="Label" Enabled="False" ErrorMessage="Remarks  is a mandatory field"
                         ForeColor="White" Width="17px">*</asp:RequiredFieldValidator>
                     <asp:CustomValidator ID="CustomValidator1" runat="server" ClientValidationFunction="CheckEmpty"
                         ControlToValidate="txtAppDurationWeek" CssClass="Label" ErrorMessage="Duration cannot be less than 1 week"
                         ForeColor="White">*</asp:CustomValidator></td>
             </tr>
                    <tr id="trAnnotation" runat="server" visible="false">
                        <td style="width: 10px; height: 22px">
                        </td>
                        <td style="width: 146px; height: 22px" valign="top">
                            <asp:Label ID="Label100" runat="server" CssClass="Label" Text="Annotation"></asp:Label></td>
                        <td style="width: 1px; height: 22px" valign="top">
                            :</td>
                        <td colspan="4" style="width: 650px; height: 22px">
                            <asp:TextBox ID="txtAnnotation" runat="server" MaxLength="20"
                                Width="486px"></asp:TextBox></td>
                    </tr>
                    <tr id="trAnnotation2" runat="server" visible="false">
                        <td style="width: 10px; height: 22px">
                        </td>
                        <td style="width: 146px; height: 22px" valign="top">
                           </td>
                        <td style="width: 1px; height: 22px" valign="top">
                            :</td>
                        <td colspan="4" style="width: 650px; height: 22px">
                            <asp:TextBox ID="txtAnnotation2" runat="server" MaxLength="20"
                                Width="486px"></asp:TextBox></td>
                    </tr>
                    <tr runat="server" id="trApprovalStatus1" >
                        <td style="width: 10px; height: 25px">
                        </td>
                        <td style="width: 146px; height: 25px" valign="middle">
                            <asp:Label ID="Label92" runat="server" CssClass="Label" Text="Approval Status"></asp:Label>
                            <asp:Label ID="Label145" runat="server" CssClass="Label" Font-Bold="False" ForeColor="Red"
                                Text="*"></asp:Label></td>
                        <td style="width: 1px; height: 25px" valign="top">
                            :</td>
                        <td colspan="4" style="width: 650px; height: 25px">
                            <asp:DropDownList ID="ddlApprovalStatus" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlApprovalStatus_SelectedIndexChanged" >
                                <asp:ListItem Value="">-SELECT-</asp:ListItem>
                                <asp:ListItem Value="EM4000">APPROVE</asp:ListItem>
                                <asp:ListItem Value="EM4002">DEFER</asp:ListItem>
                                <asp:ListItem Value="EM4001">REJECT</asp:ListItem>
                                <asp:ListItem Value="EM4003">SKIP</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlApprovalStatus"
                                CssClass="Label" ErrorMessage="Approval Status is a mandatory field" ForeColor="White"
                                Width="17px">*</asp:RequiredFieldValidator></td>
                    </tr>
                    <tr runat="server" id="trApprovalStatus2"  visible="false">
                        <td style="width: 10px; height: 25px">
                        </td>
                        <td style="width: 146px; height: 25px" valign="middle">
                            <asp:Label ID="Label106" runat="server" CssClass="Label" Text="Approval Status"></asp:Label>
                            <asp:Label ID="Label108" runat="server" CssClass="Label" Font-Bold="False" ForeColor="Red"
                                Text="*"></asp:Label></td>
                        <td style="width: 1px; height: 25px" valign="top">
                            :</td>
                        <td colspan="4" style="width: 650px; height: 25px">
                            <asp:DropDownList ID="ddlApprovalStatus2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlApprovalStatus2_SelectedIndexChanged" >
                                <asp:ListItem Value="">-SELECT-</asp:ListItem>
                                <asp:ListItem Value="EM4100">APPROVE</asp:ListItem>
                                <asp:ListItem Value="EM4102">DEFER</asp:ListItem>
                                <asp:ListItem Value="EM4101">REJECT</asp:ListItem>
                            </asp:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server"
                                ControlToValidate="ddlApprovalStatus2" CssClass="Label" ErrorMessage="Approval Status is a mandatory field"
                                ForeColor="White" Width="17px">*</asp:RequiredFieldValidator></td>
                    </tr>
                    <tr id="trRejectReason" runat="server" visible="false">
                        <td style="width: 10px; height: 25px">
                        </td>
                        <td style="width: 146px; height: 25px" valign="middle">
                            <asp:Label ID="Label147" runat="server" CssClass="Label" Text="Reject Reason"></asp:Label>
                            <asp:Label ID="Label148" runat="server" CssClass="Label" Font-Bold="False" ForeColor="Red"
                                Text="*"></asp:Label></td>
                        <td style="width: 1px; height: 25px" valign="top">
                            :</td>
                        <td style="width: 650px; height: 25px" colspan="4">
                        <asp:DropDownList ID="ddlRejectReason" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlRejectReason_SelectedIndexChanged" Width="493px" >
                        </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server"
                            ControlToValidate="ddlRejectReason" CssClass="Label" ErrorMessage="Reject Reason is a mandatory field"
                            ForeColor="White" Width="17px">*</asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td style="width: 10px; height: 8px">
                        </td>
                        <td style="width: 146px; height: 8px" valign="top">
                        </td>
                        <td style="width: 1px; height: 8px" valign="top">
                        </td>
                        <td colspan="4" style="width: 650px; height: 8px">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 10px; height: 6px">
                        </td>
                        <td style="width: 146px; height: 6px" valign="top">
                        </td>
                        <td style="width: 1px; height: 6px" valign="top">
                        </td>
                        <td colspan="4" style="height: 6px; width: 650px;">
                            <asp:Button ID="btnSubmit" runat="server" Text="Submit" Visible="True" OnClick="btnSubmit_Click"/>
                            <asp:Button ID="btn_DataEntry" runat="server" Text="Proceed to Data Entry>>" Visible="false" OnClick="btn_DataEntry_Click" Width="152px"/></td>
                    </tr>
                    <tr>
                        <td style="width: 10px; height: 10px">
                        </td>
                        <td style="width: 146px; height: 10px" valign="top">
                        </td>
                        <td style="width: 1px; height: 10px" valign="top">
                        </td>
                        <td colspan="4" style="height: 10px; width: 650px;">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 10px; height: 24px">
                        </td>
                        <td colspan="6" style="height: 24px" valign="top">
                            <asp:Label ID="lblStatusMsg" runat="server" CssClass="Label" ForeColor="Blue" Visible="False"></asp:Label>
                            <asp:Label ID="lblMsgUpdateDocType" runat="server" CssClass="Label" ForeColor="Blue" Visible="False" Text="You are changing from a fee-waived Visa to non-fee waived one. Please reject the application at final approval and re-enroll applicant in order to go through the payment module" Width="411px"></asp:Label>
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="Label" ShowMessageBox="True"
                                ShowSummary="False" />
                        </td>
                    </tr>
                </table>
            </asp:View>
        </asp:MultiView>
          <asp:HiddenField ID="stagecode" runat="server" />  
         <asp:HiddenField ID="HFLevel" runat="server" />  
         <asp:HiddenField ID="HFDocType" runat="server" />  
         <asp:HiddenField ID="HFIDPERSON" runat="server" />  
         <asp:HiddenField ID="DMSID" runat="server" />  
<script type="text/javascript">
        function CalPick(txtbox)
        {        
        var winObj = null;
        winObj = calendarPicker(txtbox);
        winObj.focus();
        }
        
            function LimitTextarea(field,  maxlimit) 
            {
	            if (document.getElementById(field).value.length > maxlimit) 
	            {
		            alert("Must not enter more than " + maxlimit + " characters"); 
		            // if too long...trim it!
		            document.getElementById(field).value = document.getElementById(field).value.substring(0, maxlimit);
		            document.getElementById(field).focus();
	            }
            } 
            function CheckEmpty(source, arguments)
            {
                var year = document.getElementById("ctl00_Content_txtAppDurationYear").value;
                var month = document.getElementById("ctl00_Content_txtAppDurationMonth").value;
                var week = document.getElementById("ctl00_Content_txtAppDurationWeek").value;
                
                                   
                if ((year == "0") && (month == "0") &&(week == "0"))
                        arguments.IsValid = false;                            
                else
                        arguments.IsValid = true;                        
            }   
           
           function confirmSubmit()
            {
               if (Page_ClientValidate())
                {
                   return confirm('Are you sure you want to submit this application?');
               }
           }  
        </script>        

</asp:Content>
