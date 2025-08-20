<%@ Page MasterPageFile="~/iden.master" Language="C#" AutoEventWireup="true" Inherits="EnrollmentIssuanceSite.PaymentDetails" Codebehind="PaymentDetails.aspx.cs" %>

<asp:Content ContentPlaceHolderID="Content" runat="server">
<input id="APPID" style="z-index: -5; left: 488px; width: 24px; position: absolute;
        top: 8px; height: 22px" type="hidden" runat="server" />    
<script src="inc/common.js" type="text/javascript"></script>
<asp:Panel ID="Panel1" runat="server" Height="28px" BackImageUrl="./images/bg.gif"
        Width="100%">
        <asp:Label ID="fly" runat="server" Height="16px" CssClass="HeaderMainTitle" ForeColor="DimGray" BackColor="Transparent" Width="353px" >E-ID - Payment Details</asp:Label></asp:Panel>
 <table id="tbInfo" cellspacing="2"  cellpadding="0" width="98%" border="0" runat="server">
           
            <tr>
                <td style="height: 15px; width: 8px;">
                </td>
                <td colspan="3" style="height: 19px; background-color: #c6efef;">
                    &nbsp;&nbsp;
                    <asp:Label ID="Label11" runat="server" CssClass="LabelHeadGreen" Text="Applicant Information"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 8px;"> </td>               
                <td colspan="3" >
                <div id="Div1" runat="server" class="PanelSearch">
               <table width="98%" border="0" cellspacing="2" cellpadding="0" id="tbInfo2"  runat="server">
                    <tr>
                        <td style="width: 8px">
                        </td>
                        <td style="width: 146px">
                            <asp:Label ID="Label3" runat="server" CssClass="Label" ForeColor="Red" Text="* Mandatory field"
                                Width="95px"></asp:Label></td>
                        <td style="width: 10px">
                        </td>
                        <td style="width: 288px">
                        </td>
                        <td style="width: 149px">
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
                           <asp:Label ID="Label5" runat="server" CssClass="LabelHeadLine" Text="Application details"></asp:Label></td>
                       <td style="width: 288px">
                           </td>
                       <td align="left" colspan="2" rowspan="1" valign="top">
                           </td>
                       <td>
                       </td>
                   </tr>
                   <tr>
                       <td style="width: 8px; height: 19px">
                       </td>
                       <td style="width: 146px; height: 19px">
                           <asp:Label ID="lblapp" runat="server" CssClass="Label" Text="Application ID"></asp:Label></td>
                       <td style="width: 10px; height: 19px">
                           :</td>
                       <td style="width: 288px; height: 19px">
                           <asp:Label ID="FORMNO" runat="server" CssClass="Label" Width="129px"></asp:Label></td>
                       <td style="width: 149px; height: 19px">
                           <asp:Label ID="lblapptype" runat="server" CssClass="Label" Text="Visa Type"></asp:Label></td>
                       <td style="width: 9px; height: 19px">
                           :</td>
                       <td style="height: 19px">
                           <asp:Label ID="DOCTYPE" runat="server" CssClass="Label" Width="195px"></asp:Label></td>
                   </tr>
                   <tr>
                       <td style="width: 8px; height: 19px">
                       </td>
                       <td style="width: 146px; height: 19px">
                           <asp:Label ID="Label1" runat="server" CssClass="Label" Text="Application Reason"></asp:Label></td>
                       <td style="width: 10px; height: 19px">
                           :</td>
                       <td style="width: 288px; height: 19px">
                           <asp:Label ID="APPREASON" runat="server" CssClass="Label" Width="263px"></asp:Label></td>
                       <td style="width: 149px; height: 19px">
                           <asp:Label ID="Label15" runat="server" CssClass="Label" Text="Entry Type"></asp:Label></td>
                       <td style="width: 9px; height: 19px">
                           :</td>
                       <td style="height: 19px">
                           <asp:Label ID="ENTRY" runat="server" CssClass="Label" Width="195px"></asp:Label></td>
                   </tr>
                   <tr >
                       <td style="width: 8px; height: 19px">
                       </td>
                       <td style="width: 146px; height: 19px">
                           </td>
                       <td style="width: 10px; height: 19px">
                           </td>
                       <td style="width: 288px; height: 19px">
                           </td>
                       <td style="width: 149px; height: 19px">
                           </td>
                       <td style="width: 9px; height: 19px">
                           </td>
                       <td style="height: 19px">
                           </td>
                   </tr>
                   <tr>
                       <td style="width: 8px; height: 19px">
                       </td>
                       <td style="width: 146px; height: 19px">
                           <asp:Label ID="Label4" runat="server" CssClass="LabelHeadLine" Text="Payment details"></asp:Label></td>
                       <td style="width: 10px; height: 19px">
                           </td>
                       <td style="width: 288px; height: 19px">
                           </td>
                       <td style="width: 149px; height: 19px">
                       </td>
                       <td style="width: 9px; height: 19px">
                       </td>
                       <td style="height: 19px">
                       </td>
                   </tr>
                   <tr>
                       <td style="width: 8px; height: 19px">
                       </td>
                       <td style="width: 146px; height: 19px">
                           <asp:Label ID="Label14" runat="server" CssClass="Label" Text="Receipt No" Width="68px"></asp:Label><asp:Label
                               ID="Label6" runat="server" CssClass="Label" ForeColor="Red" Text="*"></asp:Label></td>
                       <td style="width: 10px; height: 19px">
                           :</td>
                       <td style="width: 288px; height: 19px">
                           <asp:TextBox ID="txtReceiptNo" runat="server" CssClass="Label" Width="176px" MaxLength="15"></asp:TextBox><asp:RequiredFieldValidator ID="RFVReceiptNo" runat="server" ControlToValidate="txtReceiptNo"
                               CssClass="Label" ErrorMessage="Receipt No is a mandatory field" ForeColor="White">*</asp:RequiredFieldValidator></td>
                       <td style="width: 149px; height: 19px">
                           </td>
                       <td style="width: 9px; height: 19px">
                           </td>
                       <td style="height: 19px">
                           </td>
                   </tr>
                   <tr>
                       <td style="width: 8px; height: 19px">
                       </td>
                       <td style="width: 146px; height: 19px">
                           <asp:Label ID="Label13" runat="server" CssClass="Label" Text="Payment Method" Width="93px"></asp:Label><asp:Label
                               ID="Label22" runat="server" CssClass="Label" ForeColor="Red" Text="*"></asp:Label></td>
                       <td style="width: 10px; height: 19px">
                           :</td>
                       <td style="width: 288px; height: 19px">
                           <asp:DropDownList ID="PAYMENTMETHOD" runat="server" AutoPostBack="True" CssClass="Label" OnSelectedIndexChanged="PAYMENTMETHOD_SelectedIndexChanged">
                       </asp:DropDownList><asp:RequiredFieldValidator ID="RFVPayMethod" runat="server" ControlToValidate="PAYMENTMETHOD"
                               CssClass="Label" ErrorMessage="Payment method is a mandatory field" ForeColor="White">*</asp:RequiredFieldValidator></td>
                       <td style="width: 149px; height: 19px">
                           </td>
                       <td style="width: 9px; height: 19px">
                           </td>
                       <td style="height: 19px">
                           </td>
                   </tr>
                   <tr  id="trCreditCard" runat="server" visible="false">
                       <td style="width: 8px; height: 19px">
                       </td>
                       <td style="width: 146px; height: 19px">
                           <asp:Label ID="lblCardNo" runat="server" CssClass="Label" Text="Credit Card No"></asp:Label><asp:Label ID="Label12" runat="server" CssClass="Label" ForeColor="Red" Text="*"></asp:Label></td>
                       <td style="width: 10px; height: 19px">
                           :</td>
                       <td style="width: 288px; height: 19px">
                           <asp:TextBox ID="CARDNO" runat="server" CssClass="Label"
                               Width="176px" MaxLength="20"></asp:TextBox><asp:RequiredFieldValidator ID="RFVCardNo" runat="server" ControlToValidate="CARDNO"
                               CssClass="Label" Enabled="False" ErrorMessage="Card Number is a mandatory field"
                               ForeColor="White">*</asp:RequiredFieldValidator></td>
                       <td style="width: 149px; height: 19px">
                           </td>
                       <td style="width: 9px; height: 19px">
                           </td>
                       <td style="height: 19px">
                           </td>
                   </tr>
                   <tr id="trOtherPayMethod" runat="server" visible="false">
                       <td style="width: 8px; height: 19px">
                       </td>
                       <td style="width: 146px; height: 19px">
                           <asp:Label ID="Label20" runat="server" CssClass="Label" Text="Please specify"></asp:Label><asp:Label ID="Label23" runat="server" CssClass="Label" ForeColor="Red" Text="*"></asp:Label></td>
                       <td style="width: 10px; height: 19px">
                           :</td>
                       <td style="width: 288px; height: 19px">
                           <asp:TextBox ID="OTHERMETHOD" runat="server" CssClass="Label" Width="176px" MaxLength="20"></asp:TextBox><asp:RequiredFieldValidator ID="RFVOtherMethod" runat="server" ControlToValidate="OTHERMETHOD"
                               CssClass="Label" Enabled="False" ErrorMessage="Please specify is a mandatory field"
                               ForeColor="White">*</asp:RequiredFieldValidator></td>
                       <td style="width: 149px; height: 19px">
                       </td>
                       <td style="width: 9px; height: 19px">
                       </td>
                       <td style="height: 19px">
                           &nbsp;</td>
                   </tr>
                   <tr>
                       <td style="width: 8px; height: 19px">
                       </td>
                       <td style="width: 146px; height: 19px">
                           <asp:Label ID="Label31" runat="server" CssClass="Label" Text="Amount" Width="47px"></asp:Label></td>
                       <td style="width: 10px; height: 19px">
                           :</td>
                       <td style="width: 288px; height: 19px">
                           <asp:TextBox ID="txtAmount" runat="server" ReadOnly="True" Width="115px"></asp:TextBox>
                           <asp:Button ID="btnChange" runat="server" CausesValidation="False" CssClass="Label"
                               Height="25px" OnClick="btnChange_Click" Text="Change" Width="66px" /></td>
                       <td style="width: 149px; height: 19px">
                       </td>
                       <td style="width: 9px; height: 19px">
                       </td>
                       <td style="height: 19px">
                       </td>
                   </tr>
                   <tr id="trRemarks" runat="server" visible="false">
                       <td style="width: 8px; height: 19px">
                       </td>
                       <td style="width: 146px; height: 19px" valign="top">
                           <asp:Label ID="lbldj" runat="server" CssClass="Label" Text="Remarks"></asp:Label></td>
                       <td style="width: 10px; height: 19px">
                       </td>
                       <td style="width: 288px; height: 19px">
                           <asp:TextBox ID="txtRemarks" runat="server" CssClass="Label" MaxLength="1000" ReadOnly="True"
                               Rows="5" TextMode="MultiLine" Width="235px"></asp:TextBox></td>
                       <td style="width: 149px; height: 19px">
                       </td>
                       <td style="width: 9px; height: 19px">
                       </td>
                       <td style="height: 19px">
                       </td>
                   </tr>
                   <tr>
                       <td style="width: 8px; height: 19px">
                       </td>
                       <td style="width: 146px; height: 19px">
                       </td>
                       <td style="width: 10px; height: 19px">
                       </td>
                       <td colspan="3" style="height: 19px">
                                 <asp:Panel id="PanelLogin" runat="server" Width="300px" Visible="False" BackColor="AliceBlue" BorderColor="SteelBlue" BorderStyle="Ridge">
                                <table cellspacing="0" cellpadding="0" style="width: 300px"><tbody><tr><td style="WIDTH: 215px" colspan="1">
        &nbsp;<asp:Label ID="Label10" runat="server" CssClass="Label" Text="User Name"
            Width="67px"></asp:Label><asp:Label ID="Label30" runat="server" CssClass="Label"
                ForeColor="Red" Text="*"></asp:Label>
                        </td>
        <td style="WIDTH: 35px">
            :</td>
        <td style="WIDTH: 394px">
            <asp:TextBox ID="txtsuperid" runat="server" Width="142px"></asp:TextBox><asp:RequiredFieldValidator
                ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtsuperid" CssClass="Label"
                ErrorMessage="User name is a mandatory field" ForeColor="White">*</asp:RequiredFieldValidator></td>
    </tr>
        <tr>
            <td style="WIDTH: 215px">
                &nbsp;<asp:Label ID="lbllogin" runat="server" CssClass="Label" ForeColor="Black"
                    Text="Password" Width="62px"></asp:Label><asp:Label ID="Label32" runat="server" CssClass="Label"
                        ForeColor="Red" Text="*"></asp:Label>
            </td>
            <td style="WIDTH: 35px">
                :</td>
            <td style="WIDTH: 394px">
                <asp:TextBox ID="txtlogin" runat="server" TextMode="Password" Width="142px"></asp:TextBox><asp:RequiredFieldValidator
                    ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtlogin" CssClass="Label"
                    ErrorMessage="Password is a mandatory field" ForeColor="White">*</asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="WIDTH: 215px; height: 25px;">
            </td>
            <td style="WIDTH: 35px; height: 25px;">
            </td>
            <td style="WIDTH: 394px; height: 25px;">
                <asp:Button ID="btnloginsuper" runat="server" OnClick="btnloginsuper_Click"
                    Text="Login" Height="25px" CssClass="Label" />
                <asp:Button ID="btnCancel" runat="server" CausesValidation="False" OnClick="btnCancel_Click"
                        Text="Cancel" Width="49px" Height="25px" CssClass="Label" UseSubmitBehavior="False" /></td>
        </tr>
                            <tr>
                                <td colspan="3" style="height: 23px">
                                    &nbsp;<asp:Label ID="lblLoginError" runat="server" CssClass="Label" ForeColor="Red"
                                        Visible="False"></asp:Label></td>
                            </tr>
    </tbody>
    </table>
    </asp:Panel>
                         <asp:Panel id="PanelRevised" runat="server" Width="400px" Visible="False" BackColor="AliceBlue" BorderColor="SteelBlue" BorderStyle="Ridge">
                        <table cellspacing="0" cellpadding="0" style="width: 400px">
                            <tbody>
                                <tr id="RevisedBy" visible="false" runat="server">
                                    <td style="WIDTH: 150px" colspan="1">
                                        &nbsp;<asp:Label ID="Label24" runat="server" CssClass="Label" Text="User  Name"
                                            Width="67px"></asp:Label></td>
                                    <td style="WIDTH: 17px">
                                        :</td>
                                    <td style="WIDTH: 389px">
                                        <asp:TextBox ID="txtreviseID" runat="server" Width="150px" ReadOnly="True"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td style="WIDTH: 150px; height: 24px;">
                                        &nbsp;<asp:Label ID="Label25" runat="server" CssClass="Label" ForeColor="Black" Text="New Amount"
                                            Width="71px"></asp:Label><asp:Label ID="Label29" runat="server" CssClass="Label"
                                                ForeColor="Red" Text="*"></asp:Label></td>
                                    <td style="WIDTH: 17px; height: 24px;">
                                        :</td>
                                    <td style="WIDTH: 389px; height: 24px;">
                                        <asp:TextBox ID="txtrevisedamount" runat="server" Width="150px"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtrevisedamount"
                                            ErrorMessage="Please enter numeric value" ValidationExpression="(\d){1,99}" ForeColor="White">*</asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtrevisedamount"
                                            CssClass="Label" ErrorMessage="New amount is a mandatory field" ForeColor="White">*</asp:RequiredFieldValidator></td>
                                </tr>
                                <tr>
                                    <td style="width: 150px; height: 66px" valign="top">
                                        &nbsp;<asp:Label ID="Label26" runat="server" CssClass="Label" ForeColor="Black" Text="Remarks"
                                            Width="50px"></asp:Label></td>
                                    <td style="width: 17px; height: 66px" valign="top">
                                        :</td>
                                    <td style="width: 389px; height: 66px;">
                                        <asp:TextBox ID="txtrevisedremarks" runat="server" TextMode="MultiLine" Width="231px" Rows="4" MaxLength="1000" CssClass="Label"></asp:TextBox></td>
                                </tr>
                                <tr><td style="WIDTH: 150px; height: 23px;"></td><td style="WIDTH: 17px; height: 23px;"></td><td style="WIDTH: 389px;">
                                    <asp:Button id="updaterevise" onclick="updaterevise_Click" runat="server" Width="49px" Text="Submit" Height="25px" CssClass="Label"></asp:Button>
                                    <asp:Button ID="btncancel2" runat="server" CausesValidation="False" CssClass="Label"
                                        Height="25px" OnClick="btncacel2_Click" Text="Cancel" Width="49px" /></td></tr></tbody></table></asp:Panel>
                       </td>
                       <td style="height: 19px">
                       </td>
                   </tr>
                   <tr>
                       <td style="width: 8px; height: 19px">
                       </td>
                       <td colspan="6" style="height: 19px">
                       
                           <asp:Label ID="lblResult" runat="server" CssClass="Label" Text="Transaction Completed!" ForeColor="Blue" Visible="False" EnableViewState="False"></asp:Label><asp:Label
                               ID="lblError" runat="server" CssClass="Label" EnableViewState="False" ForeColor="Red"
                               Visible="False"></asp:Label></td>
                   </tr>
                   <tr>
                       <td style="width: 8px; height: 19px">
                       </td>
                       <td colspan="6" style="height: 19px">
                           <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Submit" CausesValidation="true" />
                           <asp:Button ID="btnClearAll" runat="server" CausesValidation="False"
                                   CssClass="Label" Height="25px"  Text="Clear" Width="66px" OnClick="btnClearAll_Click" />
                                   <asp:Button ID="btn_PreApproval" runat="server" OnClick="btn_PreApproval_Click" Text="Proceed to Pre-Approval >>" CausesValidation="false" Width="167px" Visible="false" /><asp:Button ID="btn_Approval" runat="server" OnClick="btn_Approval_Click" Text="Proceed to Approval >>" CausesValidation="false" Width="151px" Visible="false" /></td>
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
                       <td style="width: 146px; height: 19px">
                           <asp:Label ID="Label2" runat="server" CssClass="LabelHeadLine" Text="Personal details"></asp:Label></td>
                       <td style="width: 10px; height: 19px">
                       </td>
                       <td style="width: 288px; height: 19px">
                       </td>
                       <td style="height: 19px" colspan="3">
                           </td>
                   </tr>
               
        <tr>
                        <td style="width: 8px; height: 11px">
                        </td>
                        <td style="width: 146px; height: 11px">
                            <asp:Label ID="Label7" runat="server" CssClass="Label" Text="Surname"></asp:Label></td>
                        <td style="width: 10px; height: 11px">
                            :</td>
                        <td style="width: 288px; height: 11px">
                           <asp:Label ID="SURNAME" runat="server" CssClass="Label" Width="172px"></asp:Label></td>
                        <td colspan="3" rowspan="3" valign="top">
                            </td>
        </tr>
        <tr>
                        <td style="width: 8px">
                        </td>
                        <td style="width: 146px">
                            <asp:Label ID="Label8" runat="server" CssClass="Label" Text="First Name"></asp:Label></td>
                        <td style="width: 10px">
                            :</td>
                        <td style="width: 288px">
                            <asp:Label ID="FIRSTNAME" runat="server" CssClass="Label" Width="172px"></asp:Label></td>
        </tr>
        <tr>
                        <td style="width: 8px">
                        </td>
                        <td style="width: 146px">
                            <asp:Label ID="Label17" runat="server" CssClass="Label" Text="Middle Name"></asp:Label></td>
                        <td style="width: 10px">
                            :</td>
                        <td style="width: 288px">
                            <asp:Label ID="MIDDLENAME" runat="server" CssClass="Label" Width="172px"></asp:Label></td>
        </tr>         
                   <tr>
                       <td style="width: 8px; height: 19px;">
                       </td>
                       <td style="width: 146px; height: 19px;">
                           <asp:Label ID="Label19" runat="server" CssClass="Label" Text="Date of Birth"></asp:Label></td>
                       <td style="width: 10px; height: 19px;">
                           :</td>
                       <td style="width: 288px; height: 19px;">
                           <asp:Label ID="DOB" runat="server" CssClass="Label" Width="172px"></asp:Label></td>
                       <td style="width: 149px; height: 19px;">
                       </td>
                       <td style="width: 9px; height: 19px;">
                       </td>
                       <td style="height: 19px">
                       </td>
                   </tr>        
                   <tr>
                       <td style="width: 8px; height: 19px;">
                       </td>
                       <td style="width: 146px; height: 19px;">
                            <asp:Label ID="Label9" runat="server" CssClass="Label" Text="Sex"></asp:Label></td>
                       <td style="width: 10px; height: 19px;">
                           :</td>
                       <td style="width: 288px; height: 19px;">
                            <asp:Label ID="SEX" runat="server" CssClass="Label" Width="172px"></asp:Label></td>
                       <td style="width: 149px; height: 19px;">
                       </td>
                       <td style="width: 9px; height: 19px;">
                       </td>
                       <td style="height: 19px">
                       </td>
                   </tr>
                   <tr>
                       <td style="width: 8px; height: 19px">
                       </td>
                       <td style="width: 146px; height: 19px">
                            <asp:Label ID="Label18" runat="server" CssClass="Label" Text="Country of Birth"></asp:Label></td>
                       <td style="width: 10px; height: 19px">
                           :</td>
                       <td style="width: 288px; height: 19px">
                            <asp:Label ID="BIRTHCOUNTRY" runat="server" CssClass="Label" Width="172px"></asp:Label></td>
                       <td style="width: 149px; height: 19px">
                       </td>
                       <td style="width: 9px; height: 19px">
                       </td>
                       <td style="height: 19px">
                       </td>
                   </tr>
                   <tr>
                       <td style="width: 8px; height: 19px">
                       </td>
                       <td style="width: 146px; height: 19px">
                           <asp:Label ID="Label27" runat="server" CssClass="Label" Text="Nationality"></asp:Label></td>
                       <td style="width: 10px; height: 19px">
                           :</td>
                       <td style="width: 288px; height: 19px">
                           <asp:Label ID="NATIONALITY" runat="server" CssClass="Label" Width="172px"></asp:Label></td>
                       <td style="width: 149px; height: 19px">
                       </td>
                       <td style="width: 9px; height: 19px">
                       </td>
                       <td style="height: 19px">
                       </td>
                   </tr>
         <tr>
             <td style="width: 8px; height: 15px">
             </td>
             <td colspan="6">
                       
                           </td>
         </tr>
                </table>
                </div>
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="Label" ShowMessageBox="True"
                        ShowSummary="False" />
              </td>
          </tr>        
      </table>
      <asp:HiddenField ID="txtCompName" runat="server" />              &nbsp;
   
<script type="text/javascript">
function Login()
{
        var winObj = null;
        winObj = WinOpen();
        winObj.focus();
}
</script>
</asp:Content>