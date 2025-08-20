<%@ Control Language="C#" AutoEventWireup="true" Inherits="EnrollmentIssuanceSite.UserControl.Sidemenu" Codebehind="sidemenu.ascx.cs" %>

<script type="text/javascript" src="inc/common.js"></script>
<script type="text/javascript" src="inc/CSJSRequestObject.js"></script>

<div class="SideMenuP1">
    <table id="tbLoginInfo" style="z-index: 100; height: 88px" cellspacing="1" cellpadding="1" width="130" border="0">
        <!--Login Info-->
        <tr>
            <td id="tdLogin" align="left" class="HeaderPanel" style="background-image: url(./images/background_parentselected.gif)">
                Login Information
            </td>
        </tr>
        <tr>
            <td class="showPanel" id="tdpnLogin" style="vertical-align: top" align="left">
                <asp:Panel CssClass="PanelMenu" ID="PanelLoginInfo" runat="server">
                    &nbsp;
                    <asp:Label ID="Label1" runat="server" Font-Size="12px" Font-Names="Arial" ForeColor="DimGray"
                        CssClass="label" Font-Bold="True">Logged in as :</asp:Label><br />
                    &nbsp;
                    <asp:Label ID="lblUserName" runat="server" ForeColor="SaddleBrown" CssClass="Label">UserName</asp:Label><br />
                    &nbsp;
                    <asp:Label ID="lblLogin" runat="server" Font-Size="12px" Font-Names="Arial" ForeColor="DimGray"
                        CssClass="Label" Font-Bold="True">Logged in since :</asp:Label><br />
                    &nbsp;
                    <asp:Label ID="lblTime" runat="server" ForeColor="SaddleBrown" CssClass="Label"></asp:Label>
                </asp:Panel>
            </td>
        </tr>
    </table>
    <!--Enrollment table-->
    <table id="tbEnrollHeader" style="width: 155px;" cellspacing="0" cellpadding="0" border="0">
        <tr>
            <td id="td21" align="left" class="HeaderPanel" style="background-image: url(./images/background_parentselected.gif)">
                Menu
            </td>
        </tr>
    </table>
    <table id="tbEnroll" style="z-index: 101" cellspacing="1" cellpadding="1" width="150"  border="0">
        <tr id="trNewApplication" runat="server" visible="true">
            <td id="td10" style="vertical-align: top" align="left">                
                 <div id="Div3" runat="server" class="PanelMenu">
                    <table id="Table4" style="z-index: 101" cellspacing="1" cellpadding="1" width="150"
                        border="0">
                        <tr>
                            <td class="HeaderTitle" onmouseover="cursor_pointer();" onclick="SubHeaderClick('tbNewApp');"
                                onmouseout="cursor_clear(); " style="width: 148px">
                                &nbsp;New Application</td>
                        </tr>
                    </table>                    
                    <table id="tbNewApp" cellspacing="0" cellpadding="0" border="0">
                        <tr>
                            <td class="tdImgArrowHidden" id="imgHl14" style="width: 15px">
                                <img alt="" src="./images/childselected.gif" /></td>
                            <td style="width: 90px" class="BottomLine">
                                <asp:HyperLink ID="HLNewApp" CssClass="url" runat="server" Width="105px">New Visa</asp:HyperLink></td>
                        </tr>                      
                        
                        <tr>
                            <td class="tdImgArrowHidden" id="Td11" style="width: 15px; height:5px" valign="top">
                                </td>
                            <td style="width: 90px"></td>
                        </tr>
                    </table>
                </div>
           </td>
        </tr>    
        <tr id="trReplace" runat="server" visible="true">
            <td id="td6" style="vertical-align: top" align="left">                
                 <div id="Div4" runat="server" class="PanelMenu">
                    <table id="Table5" style="z-index: 101" cellspacing="1" cellpadding="1" width="150"
                        border="0">
                        <tr>
                            <td class="HeaderTitle" onmouseover="cursor_pointer();" onclick="SubHeaderClick('tbReplace');"
                                onmouseout="cursor_clear(); " style="width: 148px">
                                &nbsp;Renewal</td>
                        </tr>
                    </table>
                    <table id="tbReplace" cellspacing="0" cellpadding="0" border="0">
                        <tr>
                            <td class="tdImgArrowHidden" id="imgHl18" style="width: 15px">
                                <img alt="" src="./images/childselected.gif" /></td>
                            <td style="width: 90px" class="BottomLine">
                                <asp:HyperLink ID="HLRenew" CssClass="url" runat="server" Width="110px">Renew Visa</asp:HyperLink></td>
                        </tr>                                      
                        
                        <tr>
                            <td class="tdImgArrowHidden" id="Td14" style="width: 15px; height:5px" valign="top">
                                </td>
                            <td style="width: 90px"></td>
                        </tr>
                    </table>
                </div>
           </td>
        </tr>
        <tr id="trDataEntry" runat="server" visible="false">
            <td id="tdpnlEnroll" style="vertical-align: top; width: 157px;" align="left">                
                 <div id="PnlEnroll" runat="server" class="PanelMenu">
                    <table id="tbSearchHeader" style="z-index: 101" cellspacing="1" cellpadding="1" width="150"
                        border="0">
                        <tr>
                            <td class="HeaderTitle" onmouseover="cursor_pointer();" onclick="SubHeaderClick('tbSearchList');"
                                onmouseout="cursor_clear(); " style="width: 148px">
                                &nbsp;Data Entry</td>
                        </tr>
                    </table>
                    <table id="tbSearchList" cellspacing="0" cellpadding="0" border="0">
                        <tr>
                            <td class="tdImgArrowHidden" id="imgHl0" style="width: 15px">
                                <img alt="" src="./images/childselected.gif" /></td>
                            <td style="width: 90px" class="BottomLine">
                                <asp:HyperLink ID="HLPartial" CssClass="url" runat="server" NavigateUrl="" Width="105px">Start Data Entry</asp:HyperLink></td>
                        </tr>  
                          <tr>
                            <td class="tdImgArrowHidden" id="imgHl40" style="width: 15px">
                                <img alt="" src="./images/childselected.gif" /></td>
                            <td style="width: 90px" class="BottomLine">
                                <asp:HyperLink ID="HLExternal" CssClass="url" runat="server" Width="110px">External Application</asp:HyperLink></td>
                        </tr>                        
                        <tr>
                            <td class="tdImgArrowHidden" id="imgHl99" style="width: 15px; height:5px" valign="top">
                                <img alt="" src="./images/spacer.gif" /></td>
                            <td style="width: 90px"></td>
                        </tr>
                    </table>
                </div>
           </td>
        </tr>
        <tr id="trResumeDataEntry" runat="server" visible="false">
            <td id="td9" style="vertical-align: top; width: 157px;" align="left">                
                 <div id="Div2" runat="server" class="PanelMenu">
                    <table id="Table2" style="z-index: 101" cellspacing="1" cellpadding="1" width="150"
                        border="0">
                        <tr>
                            <td class="HeaderTitle" onmouseover="cursor_pointer();" onclick="SubHeaderClick('tbResumeDE');"
                                onmouseout="cursor_clear(); " style="width: 148px; height: 25px;">
                                &nbsp;Search</td>
                        </tr>
                    </table>
                    <table id="tbResumeDE" cellspacing="0" cellpadding="0" border="0">
                        <tr>
                            <td class="tdImgArrowHidden" id="imgHl2" style="width: 15px">
                                <img alt="" src="./images/childselected.gif" /></td>
                            <td style="width: 90px" class="BottomLine">
                                <asp:HyperLink ID="HLResumeDE" CssClass="url" runat="server" NavigateUrl="" Width="113px">Resume Data Entry</asp:HyperLink></td>
                        </tr>                        
                        
                        <tr>
                            <td class="tdImgArrowHidden" id="Td7" style="width: 15px; height:5px" valign="top">
                                </td>
                            <td style="width: 90px"></td>
                        </tr>
                    </table>
                </div>
           </td>
        </tr>
        
         <tr id="trUpdateProfile" runat="server" visible="true">
            <td id="td15" style="vertical-align: top; width: 157px;" align="left">                
                 <div id="Div9" runat="server" class="PanelMenu">
                    <table id="Table9" style="z-index: 101" cellspacing="1" cellpadding="1" width="150"
                        border="0">
                        <tr>
                            <td class="HeaderTitle" onmouseover="cursor_pointer();" onclick="SubHeaderClick('tbUpdate');"
                                onmouseout="cursor_clear(); " style="width: 148px; height: 25px;">
                                &nbsp;Enrollment</td>
                        </tr>
                    </table>
                    <table id="tbUpdate" cellspacing="0" cellpadding="0" border="0">
                        <tr>
                            <td class="tdImgArrowHidden" id="imgHl20" style="width: 15px">
                                <img alt="" src="./images/childselected.gif" /></td>
                            <td style="width: 90px" class="BottomLine">
                                <asp:HyperLink ID="HLUpdateProfile" CssClass="url" runat="server" NavigateUrl="../UpdateProfile.aspx?sm=A&arrow=20" Width="105px">Update Profile</asp:HyperLink></td>
                        </tr> 
                        
                        <tr>
                            <td class="tdImgArrowHidden" id="Td18" style="width: 15px; height:5px" valign="top">
                                </td>
                            <td style="width: 90px"></td>
                        </tr>
                    </table>
                </div>
           </td>
        </tr>
       
        <tr id="trUpdateProfileDataEntry" runat="server" visible="true">
            <td id="td16" style="vertical-align: top" align="left">                
                 <div id="Div7" runat="server" class="PanelMenu">
                    <table id="Table8" style="z-index: 101" cellspacing="1" cellpadding="1" width="150"
                        border="0">
                        <tr>
                            <td class="HeaderTitle" onmouseover="cursor_pointer();" onclick="SubHeaderClick('tbUpdateDE');"
                                onmouseout="cursor_clear(); " style="width: 148px">
                                &nbsp;Data Entry</td>
                        </tr>
                    </table>
                    <table id="tbUpdateDE" cellspacing="0" cellpadding="0" border="0">
                        <tr>
                            <td class="tdImgArrowHidden" id="imgHl23" style="width: 15px">
                                <img alt="" src="./images/childselected.gif" /></td>
                            <td style="width: 90px" class="BottomLine">
                                <asp:HyperLink ID="HLUpdateDE" CssClass="url" runat="server" NavigateUrl="" Width="105px">Update Profile</asp:HyperLink></td>
                        </tr>
                                                                    
                        
                        <tr>
                            <td class="tdImgArrowHidden" id="Td17" style="width: 15px; height:5px" valign="top">
                                </td>
                            <td style="width: 90px"></td>
                        </tr>
                    </table>
                </div>
           </td>
        </tr>
        <tr id="trResume" runat="server" visible="false">
            <td id="td3" style="vertical-align: top" align="left">                
                 <div id="Div5" runat="server" class="PanelMenu">
                    <table id="Table6" style="z-index: 101" cellspacing="1" cellpadding="1" width="150"
                        border="0">
                        <tr>
                            <td class="HeaderTitle" onmouseover="cursor_pointer();" onclick="SubHeaderClick('tbSearch');"
                                onmouseout="cursor_clear(); " style="width: 148px">
                                Payment</td>
                        </tr>
                    </table>
                    <table id="tbSearch" cellspacing="0" cellpadding="0" border="0">
                       
                        <tr>
                            <td class="tdImgArrowHidden" id="imgHl21" style="width: 15px">
                                <img alt="" src="./images/childselected.gif" /></td>
                            <td style="width: 90px" class="BottomLine">
                                <asp:HyperLink ID="HLResumeEnrol" CssClass="url" runat="server" Width="113px">Pending Payment</asp:HyperLink></td>
                        </tr>                         
                        <tr>
                            <td class="tdImgArrowHidden" id="Td12" style="width: 15px; height:5px" valign="top">
                                <img alt="" src="./images/spacer.gif" /></td>
                            <td style="width: 90px"></td>
                        </tr>
                    </table>
                </div>
           </td>
        </tr>
        <tr id="trApplicantInfo" runat="server" visible="false">
            <td id="tdApplicantInfo" style="vertical-align: top" align="left">
                <div id="PnlApplicantInfo" runat="server" class="PanelMenu">
                    <table id="tbApplicantTitle" style="z-index: 101" cellspacing="1" cellpadding="1" width="150"
                        border="0">
                        <tr>
                            <td class="HeaderTitle" onmouseover="cursor_pointer();" onclick="SubHeaderClick('tbApplicantInfo');"
                                onmouseout="cursor_clear(); " style="width: 148px">
                                &nbsp;Applicant Information</td>
                        </tr>
                    </table>
                    <table id="tbApplicantInfo" cellspacing="0" cellpadding="0" border="0">
                        <tr id="tbAppPart1" runat="server">
                            <td class="tdImgArrow" id="imgHl3" style="width: 15px">
                                <img alt="" src="./images/childselected.gif" /></td>
                            <td style="width: 90px" class="BottomLine">
                                <asp:HyperLink ID="PInfo" CssClass="url" runat="server" Width="105px" Enabled="False">Personal Info</asp:HyperLink></td>
                        </tr>
                        <tr id="tbSignature" runat="server">
                            <td class="tdImgArrow" id="imgHl4" style="width: 15px">
                                <img alt="" src="./images/childselected.gif" /></td>
                            <td style="width: 90px" class="BottomLine">
                                <asp:HyperLink ID="signature" CssClass="url" runat="server" Width="105px" Enabled="False">Visa Payment</asp:HyperLink></td>
                        </tr>
                        <tr id="tbFingerprint" runat="server">
                            <td class="tdImgArrow" id="imgHl5" style="width: 15px">
                                <img alt="" src="./images/childselected.gif" /></td>
                            <td style="width: 90px" class="BottomLine">
                               <asp:HyperLink ID="fingerprint" CssClass="url" runat="server" Width="105px" Enabled="False">Fingerprint</asp:HyperLink></td>
                        </tr>
                        <tr id="tbAppPart2" runat="server" visible="false">
                            <td class="tdImgArrow" id="imgHl6" style="width: 15px">
                                <img alt="" src="./images/childselected.gif" /></td>
                            <td style="width: 90px" class="BottomLine">
                                <asp:HyperLink ID="contact" CssClass="url" runat="server" Width="105px" Enabled="False">Contact  & Employment Details</asp:HyperLink></td>
                        </tr>
                        <tr id="tbAppPart3" runat="server" visible="false">
                            <td class="tdImgArrow" id="imgHl7" style="width: 15px">
                                <img alt="" src="./images/childselected.gif" /></td>
                            <td style="width: 90px" class="BottomLine">
                                <asp:HyperLink ID="family" CssClass="url" runat="server" Width="105px" Enabled="False">Family & Travel Details</asp:HyperLink></td>
                        </tr>
                        <tr id="tbAppPart4" runat="server" visible="false">
                            <td class="tdImgArrow" id="imgHl8" style="width: 15px">
                                <img alt="" src="./images/childselected.gif" /></td>
                            <td style="width: 90px" class="BottomLine">
                                <asp:HyperLink ID="criminal" CssClass="url" runat="server" Width="105px" Enabled="False">Financial & Criminal Details</asp:HyperLink></td>
                        </tr>  
                         <tr id="tbAppPart5" runat="server" visible="false"> 
                            <td class="tdImgArrow" id="Td1" style="width: 15px">
                                <img alt="" src="./images/childselected.gif" /></td>
                            <td style="width: 90px" class="BottomLine">
                                <asp:HyperLink ID="additional" CssClass="url" runat="server" Width="105px" Enabled="False">Additional Details</asp:HyperLink></td>
                        </tr>                   
                        <tr id="tbAppPart6" runat="server" visible="false"> 
                            <td class="tdImgArrow" id="imgHl9" style="width: 15px">
                                <img alt="" src="./images/childselected.gif" /></td>
                            <td style="width: 90px" class="BottomLine">
                                <asp:HyperLink ID="doc" CssClass="url" runat="server" Width="105px" Enabled="False">Supporting Document</asp:HyperLink></td>
                        </tr>
                       
                        <tr>
                            <td class="tdImgArrowHidden" id="Td4" style="width: 15px; height:19px">
                               </td>
                           <td style="width: 90px; height: 19px;">
                                </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
        <tr id="trQuery" runat="server" visible="false">
            <td id="td2" style="vertical-align: top" align="left">
                <div id="Div1" runat="server" class="PanelMenu">
                    <table id="Table1" style="z-index: 101" cellspacing="1" cellpadding="1" width="150"
                        border="0">
                        <tr>
                            <td class="HeaderTitle" onmouseover="cursor_pointer();" onclick="SubHeaderClick('tbQuery');"
                                onmouseout="cursor_clear(); " style="width: 148px">
                                &nbsp;Query</td>
                        </tr>
                    </table>
                    <table id="tbQuery" cellspacing="0" cellpadding="0" border="0">
                        <tr>
                            <td class="tdImgArrowHidden" id="imgHl61" style="width: 15px">
                                <img alt="" src="./images/childselected.gif" /></td>
                            <td style="width: 90px" class="BottomLine">
                                <asp:HyperLink ID="HLQuery" CssClass="url" runat="server" NavigateUrl="" Width="105px">Enrollment Enquiry</asp:HyperLink></td>
                        </tr>                       
                          <tr>
                            <td class="tdImgArrowHidden" id="imgHl64" style="width: 15px">
                                <img alt="" src="./images/childselected.gif" /></td>
                            <td style="width: 90px" class="BottomLine">
                                <asp:HyperLink ID="HLReprint" CssClass="url" runat="server" NavigateUrl="" Width="113px">Reprint Auxiliary Receipt</asp:HyperLink></td>
                        </tr>  
                         <tr>
                            <td class="tdImgArrowHidden" id="imgHl63" style="width: 15px">
                                <img alt="" src="./images/childselected.gif" /></td>
                            <td style="width: 90px" class="BottomLine">
                                <asp:HyperLink ID="HLReadEID" CssClass="url" runat="server" Width="113px">Read Visa</asp:HyperLink></td>
                        </tr>                       
                         <tr>
                            <td class="tdImgArrowHidden" id="Td5" style="width: 15px; height:5px">
                                </td>
                            <td style="width: 90px">
                                </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
         <tr id="trApproval" runat="server" visible="false">
            <td id="td13" style="vertical-align: top" align="left">
                <div id="Div6" runat="server" class="PanelMenu">
                    <table id="Table7" style="z-index: 101" cellspacing="1" cellpadding="1" width="150"
                        border="0">
                        <tr>
                            <td class="HeaderTitle" onmouseover="cursor_pointer();" onclick="SubHeaderClick('tbApproval');"
                                onmouseout="cursor_clear(); " style="width: 148px">
                                &nbsp;Approval</td>
                        </tr>
                    </table>
                    <table id="tbApproval" cellspacing="0" cellpadding="0" border="0">
                    <asp:Panel ID="trPreApp" runat="server" visible="false">
                        <tr>
                            <td class="tdImgArrowHidden" id="imgHl31" style="width: 15px">
                                <img alt="" src="./images/childselected.gif" /></td>
                            <td style="width: 90px" class="BottomLine">
                                <asp:HyperLink ID="HyperLink1" CssClass="url" runat="server" Width="105px" NavigateUrl="~/QueryApproval.aspx?sm=31&arrow=31&level=1">Pre-Approval</asp:HyperLink></td>
                        </tr>
                    </asp:Panel>
                      <asp:Panel ID="trFinalApp" runat="server" visible="false">
                         <tr>
                            <td class="tdImgArrowHidden" id="imgHl32" style="width: 15px">
                                <img alt="" src="./images/childselected.gif" /></td>
                            <td style="width: 90px" class="BottomLine">
                                <asp:HyperLink ID="HyperLink2" CssClass="url" runat="server" Width="113px" NavigateUrl="~/QueryApproval.aspx?sm=31&arrow=32&level=2">Final Approval</asp:HyperLink></td>
                        </tr> 
                      
                         <tr>
                            <td class="tdImgArrowHidden" id="imgHl33" style="width: 15px">
                                <img alt="" src="./images/childselected.gif" /></td>
                            <td style="width: 90px" class="BottomLine">
                                <asp:HyperLink ID="HyperLink3" CssClass="url" runat="server" Width="113px" NavigateUrl="~/QueryApproval.aspx?sm=31&arrow=33&level=5">Update Approval</asp:HyperLink></td>
                        </tr> 
                      </asp:Panel>
                      <asp:Panel ID="trViewProfile" runat="server" visible="false">
                        <tr>
                            <td class="tdImgArrowHidden" id="imgHl34" style="width: 15px">
                                <img alt="" src="./images/childselected.gif" /></td>
                            <td style="width: 90px" class="BottomLine">
                                <asp:HyperLink ID="HyperLink4" CssClass="url" runat="server" Width="113px" NavigateUrl="~/QueryView.aspx?sm=31&arrow=34&level=0">View Profile</asp:HyperLink></td>
                        </tr> 
                         </asp:Panel>
                                     
                         <tr>
                            <td class="tdImgArrowHidden" id="Td19" style="width: 15px; height:5px">
                                </td>
                            <td style="width: 90px">
                                </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
         <tr id="trIssuance" runat="server" visible="false">
            <td id="td8" style="vertical-align: top" align="left">
                <div id="Div8" runat="server" class="PanelMenu">
                    <table id="Table3" style="z-index: 101" cellspacing="1" cellpadding="1" width="150"
                        border="0">
                        <tr>
                            <td class="HeaderTitle" onmouseover="cursor_pointer();" onclick="SubHeaderClick('tbissuance');"
                                onmouseout="cursor_clear(); " style="width: 148px">
                                &nbsp;Issuance</td>
                        </tr>
                    </table>
                    <table id="tbissuance" cellspacing="0" cellpadding="0" border="0">
                        <tr>
                            <td class="tdImgArrowHidden" id="imgHl71" style="width: 15px">
                                <img alt="" src="./images/childselected.gif" /></td>
                            <td style="width: 90px" class="BottomLine">
                                <asp:HyperLink ID="HLIssuance" CssClass="url" runat="server" NavigateUrl="" Width="105px">Pending Issuance</asp:HyperLink></td>
                        </tr>
                         <tr>
                            <td class="tdImgArrowHidden" id="imgHl72" style="width: 15px">
                                <img alt="" src="./images/childselected.gif" /></td>
                            <td style="width: 90px" class="BottomLine">
                                <asp:HyperLink ID="HLQueryIssuance" CssClass="url" runat="server" NavigateUrl="" Width="105px">Query</asp:HyperLink></td>
                        </tr>
                        
                                     
                         <tr>
                            <td class="tdImgArrowHidden" id="Td22" style="width: 15px; height:5px">
                                </td>
                            <td style="width: 90px">
                                </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
        
    <tr id="version">
    <td>
        <table border="0" cellpadding="1" cellspacing="1" width="150">
        <tr>
        <td><asp:Label ID="lblModule" runat="server" CssClass="VersionLable" Text="" Width="150px"></asp:Label></td>
        </tr>
        </table>
    </td>
    </tr>    
    </table>    
    
     <script type="text/javascript">
   //Request.QueryString features is taken from CSJSRequestObject.js
    var n = Request.QueryString("arrow");   
    var id = "imgHl"+ n;
	document.getElementById(id).className="tdImgArrowShow";
    </script> 
</div>
<input id="IsNew" style="z-index: -5; left: 488px; width: 24px; position: absolute;
        top: 8px; height: 22px" type="hidden" runat="server" />
<input id="DOCTYPE" style="z-index: -5; left: 488px; width: 24px; position: absolute;
        top: 8px; height: 22px" type="hidden" runat="server" />
  



