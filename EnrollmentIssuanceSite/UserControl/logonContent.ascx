<%@ Control Language="C#" AutoEventWireup="true" Inherits="EnrollmentIssuanceSite.UserControl.LogonContent" Codebehind="logonContent.ascx.cs" %>

<div id="setupContent">
    <table  cellpadding="0" cellspacing="0" border="0" style="padding-left:10px">        
        <tr>
            <td style="width: 830px"  >        
            <asp:Menu ID="Menu1" runat="server" Orientation="Horizontal" 
        OnMenuItemClick="Menu1_MenuItemClick" 
        StaticMenuItemStyle-CssClass="tab"
        StaticSelectedStyle-CssClass="selectedTab"
        CssClass="tabs" style="left: 0px; top: 1px;" >
            <Items>
                <asp:MenuItem Text="Enrollment" Value="0"></asp:MenuItem>
                <asp:MenuItem Text="Payment" Value="1"></asp:MenuItem>
                <asp:MenuItem Text="Approval" Value="2"></asp:MenuItem>
                <asp:MenuItem Text="Issuance" Value="3" ></asp:MenuItem>              
            </Items>
            <StaticSelectedStyle BackColor="White" Font-Bold="True" ForeColor="#8080FF" />
        </asp:Menu>                        
        </td>
        </tr>
          <tr>
            <td style="width: 830px">
            <div class="TabContent">
               <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">        
                 <asp:View ID="View1" runat="server">                 
                        <table style="width: 100%;" border="0" cellspacing="2" cellpadding="1">
        <tr>
            <td style="width: 36px; height:15px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr id="trEnrolNew" visible="false" runat="server">
            <td style="width: 36px; height: 80px; padding-left:5px">
                <asp:ImageButton ID="btn_enrolNew" runat="server" ImageUrl="~/images/icon_enrolnew.gif"
                    OnClick="btn_enrolNew_Click" /></td>
            <td style="width: 100px; height: 80px;">
                <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="14px"
                    ForeColor="#346CBF" Text="Enroll New Visa" Width="201px"></asp:Label>
                <asp:Label ID="Label1"  CssClass="Label" runat="server" Text="This module allows the officer to enroll applicants for first time application. The officer will have to perform data entry of the applicant’s personal particulars from the Visa application form" Width="520px" Height="58px"></asp:Label></td>
        </tr>       
        <tr id="trRenew" visible="false" runat="server">
            <td style="padding-left: 5px; width: 36px; height: 80px">
                <asp:ImageButton ID="btn_renew" runat="server" ImageUrl="~/images/icon_renew.gif" OnClick="btn_renew_Click" /></td>
            <td style="width: 100px; height: 80px">
                <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="14px"
                    ForeColor="#346CBF" Text="Renew Visa" Width="190px"></asp:Label>
                <asp:Label ID="Label6" runat="server" Text="This module allows the officer to renew applicant’s Visa. The officer will have to retrieve applicant's existing profile and update where necessary" Width="518px" Height="58px" CssClass="Label"></asp:Label></td>
        </tr>
       
       <tr id="trDataEntry" runat="server" visible="false">
            <td style="padding-left: 5px; width: 36px; height: 80px">
                <asp:ImageButton ID="btn_DataEntry" runat="server" ImageUrl="~/images/icon_enrolnew.gif"
                    OnClick="btn_DataEntry_Click" /></td>
            <td style="width: 100px; height: 80px">
                <asp:Label ID="Label11" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="14px"
                    ForeColor="#346CBF" Text="Data Entry " Width="137px"></asp:Label><asp:Label ID="Label12"
                        runat="server" CssClass="Label" Height="58px" Text="This module allows the officer to keys in all the data of an application into the system. Besides that, the officer will have to scan applicant's photograph, application form and all the supporting documents."
                        Width="515px"></asp:Label></td>
        </tr>
      
        <tr id="trUpdate" visible="false" runat="server">
            <td style="padding-left: 5px; width: 36px; height: 80px">
                <asp:ImageButton ID="ImageButton4" runat="server" ImageUrl="~/images/update.gif"
                    OnClick="btn_UpdateProfile_Click" /></td>
            <td style="width: 100px; height: 80px">
                <asp:Label ID="Label13" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="14px"
                    ForeColor="#346CBF" Text="Update Profile " Width="137px"></asp:Label><asp:Label ID="Label14"
                        runat="server" CssClass="Label" Height="58px" Text="This module allows the officer to update applicant’s record, if it exists in the database, with the current information."
                        Width="515px"></asp:Label></td>
        </tr>
        <tr id="trQuery" visible="false" runat="server">
            <td style="padding-left: 5px; width: 36px; height: 80px">
                <asp:ImageButton ID="btn_Query" runat="server" ImageUrl="~/images/icon_query.gif"
                    OnClick="btn_Query_Click" /></td>
            <td style="width: 100px; height: 80px">
                <asp:Label ID="Label32" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="14px"
                    ForeColor="#346CBF" Text="Query" Width="61px"></asp:Label>
                <asp:Label ID="Label35"  CssClass="Label" runat="server" Text="This module allows the officer to reprint auxiliary receipt, read Visa as well as perform query for applicant's record using applicant’s Visa Number, Passport No, Name and Date of Birth" Height="56px" Width="514px"></asp:Label></td>
        </tr>
         <tr id="trReportEnrol" runat="server" visible="false">
                                <td style="padding-left: 5px; width: 36px; height: 80px">
                                    <asp:ImageButton ID="btn_Report" runat="server" ImageUrl="~/images/icon_report.gif"
                                        OnClick="btn_Report_Click" /></td>
                                <td style="width: 100px; height: 80px">
                                    <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="14px"
                                        ForeColor="#346CBF" Text="Report" Width="61px"></asp:Label><asp:Label ID="Label36"
                                            runat="server" CssClass="Label" Height="56px" Text="This module allows the officer to view and create the report"
                                            Width="514px"></asp:Label></td>
                            </tr>
         <tr id="trEnrolWarning" runat="server" visible="false">
                            <td style="width: 36px; height: 80px; padding-left:5px">
                                <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/images/icon_warning.gif"
                                     /></td>
                            <td style="width: 100px; height: 80px;">
                            <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="14px"
                     ForeColor="Red" Text="Sorry!  You have no permission to perform enrollment" Width="375px"></asp:Label>
                               </td>
                        </tr>
    </table>
                  </asp:View>
                 <asp:View ID="View2" runat="server">
                       <table style="width: 100%;" border="0" cellspacing="2" cellpadding="1">
                        <tr>
                            <td style="width: 36px; height:15px">
                            </td>
                            <td style="width: 100px">
                            </td>
                        </tr>
                        <tr id="trPayment" visible="false" runat="server">
                                <td style="padding-left: 5px; width: 36px; height: 80px">
                                    <asp:ImageButton ID="btn_payment" runat="server" OnClick="btn_payment_Click" ImageUrl="~/images/docPayment_icon.gif" />
                                    </td>
                                <td style="width: 100px; height: 80px">
                                    <asp:Label ID="Label7" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="14px"
                                        ForeColor="#346CBF" Text="Visa Payment" Width="194px"></asp:Label>
                                    <asp:Label ID="Label8" runat="server" Text="This module allows the officer to check the payment status of the applicant and subsequently collect payment if its have not been made." Width="508px" Height="58px" CssClass="Label"></asp:Label></td>
                            </tr>
                       
                        <tr id="trReportPayment" runat="server" visible="false">
                               <td style="padding-left: 5px; width: 36px; height: 80px">
                                   <asp:ImageButton ID="ImageButton6" runat="server" ImageUrl="~/images/icon_report.gif" OnClick="btn_Report_Click"/></td>
                               <td style="width: 100px; height: 80px">
                                <asp:Label ID="Label34" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="14px"
                                        ForeColor="#346CBF" Text="Report" Width="61px"></asp:Label><asp:Label ID="Label37"
                                            runat="server" CssClass="Label" Height="56px" Text="This module allows the officer to view and create the report"
                                            Width="514px"></asp:Label>
                               </td>
                           </tr>
                         <tr id="trPayWarning" runat="server" visible="false">
                            <td style="width: 36px; height: 80px; padding-left:5px">
                                <asp:ImageButton ID="ImageButton7" runat="server" ImageUrl="~/images/icon_warning.gif"
                                     /></td>
                            <td style="width: 100px; height: 80px;">
                            <asp:Label ID="Label38" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="14px"
                     ForeColor="Red" Text="Sorry!  You have no permission to perform payment" Width="375px"></asp:Label>
                               </td>
                        </tr>
                           
                    </table>
                    
                </asp:View>
                 <asp:View ID="View3" runat="server">
                         <table style="width: 100%;" border="0" cellspacing="2" cellpadding="1">
                            <tr>
                                <td style="width: 36px; height:15px">
                                </td>
                                <td style="width: 100px">
                                </td>
                            </tr>
                            <tr id="trFirst" visible="false" runat="server">
                                <td style="width: 36px; height: 80px; padding-left:5px">
                                    <asp:ImageButton ID="btn_First" runat="server" ImageUrl="~/images/icon_enrolnew.gif"
                                        OnClick="btn_First_Click" /></td>
                                <td style="width: 100px; height: 80px;">
                                    <asp:Label ID="Label15" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="14px"
                                        ForeColor="#346CBF" Text="Pre-Approval" Width="201px"></asp:Label><asp:Label
                                            ID="Label16" runat="server" CssClass="Label" Height="58px" Text="This module allows the officer to view the applications and log his or her interview notes. Subsequently, the officer can approve, reject or defer the application"
                                            Width="499px"></asp:Label></td>
                            </tr>       
                            <tr id="trSecond" visible="false" runat="server">
                                <td style="padding-left: 5px; width: 36px; height: 80px">
                                <asp:ImageButton ID="btn_Second" runat="server" ImageUrl="~/images/icon_enrolnew.gif"
                                        OnClick="btn_Second_Click" /></td>
                                <td style="width: 100px; height: 80px">
                                    <asp:Label ID="Label19" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="14px"
                                        ForeColor="#346CBF" Text="Final Approval" Width="171px"></asp:Label><asp:Label
                                            ID="Label20" runat="server" CssClass="Label" Height="58px" Text="This module allows the officer to review applications that are approved at pre-approval stage. Subsequently, the officer can approve, or reject the application"
                                            Width="496px"></asp:Label></td>
                            </tr>   
                            <tr id="trView" visible="false" runat="server">
                                <td style="padding-left: 5px; width: 36px; height: 80px">
                                    <asp:ImageButton ID="btn_View" runat="server" ImageUrl="~/images/icon_query.gif"
                                        OnClick="btn_View_Click" /></td>
                                <td style="width: 100px; height: 80px">
                                    <asp:Label ID="Label25" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="14px"
                                        ForeColor="#346CBF" Text="View Profile" Width="173px"></asp:Label><asp:Label ID="Label26"
                                            runat="server" CssClass="Label" Height="58px" Text="This module allows the officer to view applicant's profiles"
                                            Width="498px"></asp:Label></td>
                            </tr>
                             <tr id="trAppUpdate" runat="server" visible="false">
                                    <td style="padding-left: 5px; width: 36px; height: 80px">
                                        <asp:ImageButton ID="btn_AppUpdate" runat="server" ImageUrl="~/images/update.gif"
                                                                OnClick="btn_AppUpdate_Click" /></td>
                                    <td style="width: 100px; height: 80px">
                                        <asp:Label ID="Label29" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="14px"
                                            ForeColor="#346CBF" Text="Update Approval" Width="173px"></asp:Label><asp:Label ID="Label30"
                                                runat="server" CssClass="Label" Height="58px" Text="This module allows the officer to update final approval decision."
                                                Width="498px"></asp:Label></td>
                                </tr>
                                   <tr id="trReportApproval" runat="server" visible="false">
                                       <td style="padding-left: 5px; width: 36px; height: 80px">
                                           <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/images/icon_report.gif"
                                                                                            OnClick="btn_Report_Click"/></td>
                                       <td style="width: 100px; height: 80px">
                                        <asp:Label ID="Label31" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="14px"
                                                                    ForeColor="#346CBF" Text="Report" Width="61px"></asp:Label><asp:Label ID="Label39"
                                                                        runat="server" CssClass="Label" Height="56px" Text="This module allows the officer to view and create the report"
                                                                        Width="514px"></asp:Label>
                                       </td>
                                   </tr>
                                 <tr id="trAppWarning" runat="server" visible="false">
                                     <td style="padding-left: 5px; width: 36px; height: 80px">
                                         <asp:ImageButton ID="ImageButton8" runat="server" ImageUrl="~/images/icon_warning.gif"
                                                                                        OnClick="btn_AppUpdate_Click" /></td>
                                     <td style="width: 100px; height: 80px">
                                         <asp:Label ID="Label40" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="14px"
                                             ForeColor="Red" Text="Sorry!  You have no permission to perform approval" Width="371px"></asp:Label></td>
                                 </tr>
                           
                              
                            </table>           
                 
                 
                 </asp:View>
                 <asp:View ID="View4" runat="server">
                         <table style="width: 100%;" border="0" cellspacing="2" cellpadding="1">
                            <tr>
                                <td style="width: 36px; height:15px">
                                </td>
                                <td style="width: 100px">
                                </td>
                            </tr>
                         <tr id="trIssuance" runat="server" visible="false">
                            <td style="padding-left: 5px; width: 36px; height: 80px">
                                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/icon_renew.gif"
                                    OnClick="btn_Issuance_Click" /></td>
                            <td style="width: 100px; height: 80px">
                                <asp:Label ID="Label9" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="14px"
                                    ForeColor="#346CBF" Text="Visa Issuance" Width="137px"></asp:Label><asp:Label ID="Label10"
                                        runat="server" CssClass="Label" Height="58px" Text="This module allows the officer to check the issuance status of the application and subsequently issue the Visa if its ready."
                                        Width="515px"></asp:Label></td>
                              </tr>
                            <tr id="trReportIssuance" runat="server" visible="false">
                                <td style="padding-left: 5px; width: 36px; height: 80px">
                                <asp:ImageButton ID="ImageButton5" runat="server" ImageUrl="~/images/icon_report.gif" OnClick="btn_Report_Click"/></td>
                                <td style="width: 100px; height: 80px">
                                <asp:Label ID="Label33" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="14px"
                                                            ForeColor="#346CBF" Text="Report" Width="61px"></asp:Label><asp:Label ID="Label41"
                                                                runat="server" CssClass="Label" Height="56px" Text="This module allows the officer to view and create the report"
                                                                Width="514px"></asp:Label>
                                </td>
                            </tr>
                             <tr id="trIssueWarning" visible="false" runat="server">
                                <td style="width: 36px; height: 80px; padding-left:5px">
                                    <asp:ImageButton ID="ImageButton9" runat="server" ImageUrl="~/images/icon_warning.gif"/></td>                                       
                                <td style="width: 100px; height: 80px;">
                                <asp:Label ID="Label42" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="14px"
                     ForeColor="Red" Text="Sorry!  You have no permission to perform issuance" Width="375px"></asp:Label>
                                    </td>
                            </tr>    
                         </table>
                 
                 
                 </asp:View>
              
                        
               </asp:MultiView>   
           </div>
           </td>
        </tr>
        </table>
     <asp:HiddenField ID="txtCompName" runat="server" />      
</div>
<%--<script type="text/javascript">
       var ax = new ActiveXObject("WScript.Network");
        document.getElementById("LogonContent1_txtCompName").value =  ax.ComputerName;   
</script>--%>
