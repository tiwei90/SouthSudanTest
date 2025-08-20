<%@ Page MasterPageFile="~/iden.master" Language="C#" AutoEventWireup="true" Inherits="EnrollmentIssuanceSite.ObsoleteDetails" Codebehind="ObsoleteDetails.aspx.cs" %>

<asp:Content ContentPlaceHolderID="Content" runat="server">

<asp:Panel ID="Panel1" runat="server" Height="28px" BackImageUrl="./images/bg.gif"
        Width="100%">
        <asp:Label ID="fly" runat="server" Height="16px" CssClass="HeaderMainTitle" ForeColor="DimGray" BackColor="Transparent" Width="353px" >Visa - Obsolete Details</asp:Label></asp:Panel>
 <table id="tbInfo" cellspacing="2"  cellpadding="0" width="100%" border="0" runat="server">
           
            <tr>
                <td style="height: 15px; width: 8px;">
                </td>
                <td colspan="3" style="height: 19px; background-color: #c6efef;">
                    &nbsp;&nbsp;
                    <asp:Label ID="Label11" runat="server" CssClass="LabelHeadGreen" Text="Visa Holder Information"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 8px;"> </td>               
                <td colspan="3" >
                <div id="Div1" runat="server" class="PanelSearch">
               <table width="100%" border="0" cellspacing="2" cellpadding="0" id="tbInfo2"  runat="server">
                    <tr>
                        <td style="width: 8px">
                        </td>
                        <td style="width: 126px">
                            <asp:Label ID="Label3" runat="server" CssClass="Label" ForeColor="Red" Text="* Mandatory field"
                                Width="95px"></asp:Label></td>
                        <td style="width: 2px">
                        </td>
                        <td style="width: 250px">
                        </td>
                        <td style="width: 94px">
                        </td>
                        <td style="width: 9px">
                        </td>
                        <td>
                        </td>
                    </tr>
                   <tr>
                       <td style="width: 8px">
                       </td>
                       <td colspan="2">
                       </td>
                       <td style="width: 250px">
                       </td>
                       <td align="left" colspan="2" rowspan="1" valign="top">
                       </td>
                       <td>
                       </td>
                   </tr>
                   <tr>
                       <td style="width: 8px">
                       </td>
                       <td colspan="2">
                           <asp:Label ID="Label4" runat="server" CssClass="LabelHeadLine" Text="Obsolete Details"></asp:Label></td>
                       <td style="width: 250px">
                       </td>
                       <td align="left" colspan="2" rowspan="1" valign="top">
                           </td>
                       <td>
                       </td>
                   </tr>
                   <tr>
                       <td style="width: 8px; height: 19px">
                       </td>
                       <td style="width: 126px; height: 19px">
                           <asp:Label ID="Label14" runat="server" CssClass="Label" Text="Obsolete Reason" Width="97px"></asp:Label></td>
                       <td style="width: 2px; height: 19px">
                           :</td>
                       <td style="width: 250px; height: 19px">
                           <asp:Label ID="Label5" runat="server" CssClass="Label" Text="PASSPORT RENEWAL/REPLACEMENT" Width="220px"></asp:Label></td>
                       <td style="width: 94px; height: 19px">
                           </td>
                       <td style="width: 9px; height: 19px">
                           </td>
                       <td style="height: 19px">
                           </td>
                   </tr>
                   <tr>
                       <td style="width: 8px; height: 19px">
                       </td>
                       <td colspan="6" style="height: 19px">
                        
                       </td>
                   </tr>
                   
                   <tr>
                       <td style="width: 8px; height: 5px">
                       </td>
                       <td colspan="6" style="height: 5px">
                       
                           <asp:Label ID="lblResult" runat="server" CssClass="Label" Text="Passport has been made obsolete!" ForeColor="Blue" Visible="False" EnableViewState="False"></asp:Label><asp:Label
                               ID="lblError" runat="server" CssClass="Label" EnableViewState="False" ForeColor="Red"
                               Visible="False"></asp:Label></td>
                   </tr>
                   <tr>
                       <td style="width: 8px; height: 19px">
                       </td>
                       <td colspan="6" style="height: 19px">
                           <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Obsolete" CausesValidation="true" Width="99px" /></td>
                   </tr>
                   <tr>
                       <td style="width: 8px; height: 19px">
                       </td>
                       <td colspan="6" style="height: 19px"><hr/>
                       </td>
                   </tr>
                   <tr>
                       <td style="width: 8px; height: 19px">
                       </td>
                       <td style="width: 126px; height: 19px">
                           <asp:Label ID="Label2" runat="server" CssClass="LabelHeadLine" Text="Personal details"></asp:Label></td>
                       <td style="width: 2px; height: 19px">
                       </td>
                       <td style="width: 250px; height: 19px">
                       </td>
                       <td style="height: 19px" colspan="3">
                           <asp:Label ID="Label28" runat="server" CssClass="LabelHeadLine" Text="Photograph"></asp:Label></td>
                   </tr>
               
        <tr>
                        <td style="width: 8px; height: 11px">
                        </td>
                        <td style="width: 126px; height: 11px">
                            <asp:Label ID="Label7" runat="server" CssClass="Label" Text="Surname"></asp:Label></td>
                        <td style="width: 2px; height: 11px">
                            :</td>
                        <td style="width: 250px; height: 11px">
                           <asp:Label ID="SURNAME" runat="server" CssClass="Label" Width="172px"></asp:Label></td>
                        <td colspan="3" rowspan="5" valign="top">
                            <asp:Image ID="imgPhoto" runat="server" Height="97px" ImageUrl="~/images/spacer.gif"
                                Width="80px" BorderColor="#E0E0E0" /></td>
        </tr>
        <tr>
                        <td style="width: 8px">
                        </td>
                        <td style="width: 126px">
                            <asp:Label ID="Label8" runat="server" CssClass="Label" Text="First Name"></asp:Label></td>
                        <td style="width: 2px">
                            :</td>
                        <td style="width: 250px">
                            <asp:Label ID="FIRSTNAME" runat="server" CssClass="Label" Width="172px"></asp:Label></td>
        </tr>
        <tr>
                        <td style="width: 8px">
                        </td>
                        <td style="width: 126px">
                            <asp:Label ID="Label17" runat="server" CssClass="Label" Text="Middle Name"></asp:Label></td>
                        <td style="width: 2px">
                            :</td>
                        <td style="width: 250px">
                            <asp:Label ID="MIDDLENAME" runat="server" CssClass="Label" Width="172px"></asp:Label></td>
        </tr>         
                   <tr>
                       <td style="width: 8px; height: 19px;">
                       </td>
                       <td style="width: 126px; height: 19px;">
                           <asp:Label ID="Label19" runat="server" CssClass="Label" Text="Date of Birth"></asp:Label></td>
                       <td style="width: 2px; height: 19px;">
                           :</td>
                       <td style="width: 250px; height: 19px;">
                           <asp:Label ID="DOB" runat="server" CssClass="Label" Width="172px"></asp:Label></td>
                   </tr>        
                   <tr>
                       <td style="width: 8px; height: 19px;">
                       </td>
                       <td style="width: 126px; height: 19px;">
                            <asp:Label ID="Label9" runat="server" CssClass="Label" Text="Sex"></asp:Label></td>
                       <td style="width: 2px; height: 19px;">
                           :</td>
                       <td style="width: 250px; height: 19px;">
                            <asp:Label ID="SEX" runat="server" CssClass="Label" Width="172px"></asp:Label></td>
                   </tr>
                   <tr>
                       <td style="width: 8px; height: 19px">
                       </td>
                       <td style="width: 126px; height: 19px">
                            <asp:Label ID="Label18" runat="server" CssClass="Label" Text="Place of Birth"></asp:Label></td>
                       <td style="width: 2px; height: 19px">
                           :</td>
                       <td style="width: 250px; height: 19px">
                            <asp:Label ID="BIRTHPLACE" runat="server" CssClass="Label" Width="172px"></asp:Label></td>
                       <td style="height: 19px" colspan="3">
                           <asp:Label ID="Label6" runat="server" CssClass="LabelHeadLine" Text="Passport Details"></asp:Label></td>
                   </tr> 
                    <tr>
                       <td style="width: 8px; height: 19px">
                       </td>
                       <td style="width: 126px; height: 19px">
                            <asp:Label ID="Label34" runat="server" CssClass="Label" Text="Country of Birth"></asp:Label></td>
                       <td style="width: 2px; height: 19px">
                           :</td>
                       <td style="width: 250px; height: 19px">
                            <asp:Label ID="BIRTHCOUNTRY" runat="server" CssClass="Label" Width="172px"></asp:Label></td>
                       <td style="width: 94px; height: 19px">
                           <asp:Label ID="Label29" runat="server" CssClass="Label" Text="Passport No"></asp:Label></td>
                       <td style="width: 9px; height: 19px">
                           :</td>
                       <td style="height: 19px">
                           <asp:Label ID="PASSPORTNO" runat="server" CssClass="Label" Width="172px"></asp:Label></td>
                   </tr>                            
                   <tr>
                       <td style="width: 8px; height: 19px">
                       </td>
                       <td style="width: 126px; height: 19px">
                           <asp:Label ID="Label27" runat="server" CssClass="Label" Text="Nationality"></asp:Label></td>
                       <td style="width: 2px; height: 19px">
                           :</td>
                       <td style="width: 250px; height: 19px">
                           <asp:Label ID="NATIONALITY" runat="server" CssClass="Label" Width="172px"></asp:Label></td>
                       <td style="width: 94px; height: 19px">
                           <asp:Label ID="Label15" runat="server" CssClass="Label" Text="Country of Issue"></asp:Label></td>
                       <td style="width: 9px; height: 19px">
                           :</td>
                       <td style="height: 19px">
                           <asp:Label ID="PASSPORTCOI" runat="server" CssClass="Label" Width="172px"></asp:Label></td>
                   </tr>
                   <tr>
                       <td style="width: 8px; height: 19px">
                       </td>
                       <td style="width: 126px; height: 19px">
                            <asp:Label ID="Label10" runat="server" CssClass="Label" Text="National ID No"></asp:Label></td>
                       <td style="width: 2px; height: 19px">
                           :</td>
                       <td style="width: 250px; height: 19px">
                            <asp:Label ID="NATIONALINSURANCENO" runat="server" CssClass="Label" Width="172px"></asp:Label></td>
                       <td style="width: 94px; height: 19px">
                           <asp:Label ID="Label20" runat="server" CssClass="Label" Text="Date of Issue"></asp:Label></td>
                       <td style="width: 9px; height: 19px">
                           :</td>
                       <td style="height: 19px">
                           <asp:Label ID="PASSPORTDOI" runat="server" CssClass="Label" Width="172px"></asp:Label></td>
                   </tr>
                   <tr>
                       <td style="width: 8px; height: 19px">
                       </td>
                       <td style="width: 126px; height: 19px">
                       </td>
                       <td style="width: 2px; height: 19px">
                       </td>
                       <td style="width: 250px; height: 19px">
                       </td>
                       <td style="width: 94px; height: 19px">
                           <asp:Label ID="Label22" runat="server" CssClass="Label" Text="Date of Expiry"></asp:Label></td>
                       <td style="width: 9px; height: 19px">
                           :</td>
                       <td style="height: 19px">
                           <asp:Label ID="PASSPORTDOE" runat="server" CssClass="Label" Width="172px"></asp:Label></td>
                   </tr>
                   <tr>
                       <td style="width: 8px; height: 19px">
                       </td>
                       <td colspan="3" style="height: 19px">
                           <asp:Label ID="Label1" runat="server" CssClass="LabelHeadLine" Text="Visa Details"></asp:Label></td>
                       <td style="width: 94px; height: 19px">
                           </td>
                       <td style="width: 9px; height: 19px">
                           </td>
                       <td style="height: 19px">
                           </td>
                   </tr>
                   <tr>
                       <td style="width: 8px; height: 19px">
                       </td>
                       <td style="width: 126px; height: 19px">
                           <asp:Label ID="Label12" runat="server" CssClass="Label" Text="Document No"></asp:Label></td>
                       <td style="width: 2px; height: 19px">
                           :</td>
                       <td style="width: 250px; height: 19px">
                           <asp:Label ID="DOCNO" runat="server" CssClass="Label"></asp:Label></td>
                       <td style="width: 94px; height: 19px">
                       </td>
                       <td style="width: 9px; height: 19px">
                       </td>
                       <td style="height: 19px">
                       </td>
                   </tr>
                   <tr>
                       <td style="width: 8px; height: 19px">
                       </td>
                       <td style="width: 126px; height: 19px">
                           <asp:Label ID="Label23" runat="server" CssClass="Label" Text="Visa Type"></asp:Label></td>
                       <td style="width: 2px; height: 19px">
                           :</td>
                       <td style="width: 250px; height: 19px">
                           <asp:Label ID="DOCTYPE" runat="server" CssClass="Label"></asp:Label></td>
                       <td style="width: 94px; height: 19px">
                       </td>
                       <td style="width: 9px; height: 19px">
                       </td>
                       <td style="height: 19px">
                       </td>
                   </tr>
                   <tr>
                       <td style="width: 8px; height: 19px">
                       </td>
                       <td style="width: 126px; height: 19px">
                           <asp:Label ID="Label24" runat="server" CssClass="Label" Text="Entry Type"></asp:Label></td>
                       <td style="width: 2px; height: 19px">
                           :</td>
                       <td style="width: 250px; height: 19px">
                           <asp:Label ID="ENTRYTYPE" runat="server" CssClass="Label"></asp:Label></td>
                       <td style="width: 94px; height: 19px">
                       </td>
                       <td style="width: 9px; height: 19px">
                       </td>
                       <td style="height: 19px">
                       </td>
                   </tr>
                   <tr>
                       <td style="width: 8px; height: 19px">
                       </td>
                       <td style="width: 126px; height: 19px">
                           <asp:Label ID="Label13" runat="server" CssClass="Label" Text="Date of Issue"></asp:Label></td>
                       <td style="width: 2px; height: 19px">
                           :</td>
                       <td style="width: 250px; height: 19px">
                           <asp:Label ID="DOCDOI" runat="server" CssClass="Label" Width="172px"></asp:Label></td>
                       <td style="width: 94px; height: 19px">
                       </td>
                       <td style="width: 9px; height: 19px">
                       </td>
                       <td style="height: 19px">
                       </td>
                   </tr>
                   <tr>
                       <td style="width: 8px; height: 19px">
                       </td>
                       <td style="width: 126px; height: 19px">
                           <asp:Label ID="Label21" runat="server" CssClass="Label" Text="Date of Expiry"></asp:Label></td>
                       <td style="width: 2px; height: 19px">
                           :</td>
                       <td style="width: 250px; height: 19px">
                           <asp:Label ID="DOCDOE" runat="server" CssClass="Label" Width="172px"></asp:Label></td>
                       <td style="width: 94px; height: 19px">
                       </td>
                       <td style="width: 9px; height: 19px">
                       </td>
                       <td style="height: 19px">
                       </td>
                   </tr>
                   <tr>
                       <td style="width: 8px; height: 19px">
                       </td>
                       <td style="width: 126px; height: 19px">
                           <asp:Label ID="Label16" runat="server" CssClass="Label" Text="Place of Issue"></asp:Label></td>
                       <td style="width: 2px; height: 19px">
                           :</td>
                       <td style="width: 250px; height: 19px">
                           <asp:Label ID="DOCPOI" runat="server" CssClass="Label"></asp:Label></td>
                       <td style="width: 94px; height: 19px">
                       </td>
                       <td style="width: 9px; height: 19px">
                       </td>
                       <td style="height: 19px">
                       </td>
                   </tr>
                </table>
                </div>
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="Label" ShowMessageBox="True"
                        ShowSummary="False" />
              </td>
          </tr>        
      </table>
       <asp:HiddenField ID="txtCompName" runat="server" />  
       <asp:HiddenField ID="IsNew" runat="server" />  
<script type="text/javascript">
function CalPick(txtbox, status, text)
{
     var winObj = null; 
     winObj =  calendarPicker(txtbox, status, text);
     winObj.focus();
}
</script>


</asp:Content>
