<%@ Page MasterPageFile="~/iden.master" Language="C#" AutoEventWireup="true" Inherits="EnrollmentIssuanceSite.CollectionSummary" Codebehind="CollectionSummary.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
 <script type="text/javascript" src="inc/common.js"></script>
 <script type="text/javascript" src="/inc/CSJSRequestObject.js"></script>
<script type="text/javascript">
function print()
{
    var n = document.getElementById('ctl00_Content_branch').value;   
    getPrint('tbPrint',n);
}
</script>


<asp:Panel ID="Panel1" runat="server" Height="28px" BackImageUrl="./images/bg.gif"
        Width="100%">
        <asp:Label ID="fly" runat="server" Height="16px" CssClass="HeaderMainTitle" ForeColor="DimGray" BackColor="Transparent" Width="353px" >Visa - Application Summary</asp:Label></asp:Panel>

<table id="tbPrint" cellspacing="0" cellpadding="0" border="0" width="100%">
            <tr>
                <td style="width: 390px;" valign="top">                    
                    <table id="Table2" cellpadding="0" cellspacing="0" border="0" style="width: 402px">
                        <tr>
                            <td style="width: 5px; height: 25px;">
                            </td>
                            <td style="height: 25px;" colspan="3">
                                <asp:Label ID="Label11" runat="server" CssClass="LabelHeadLine" Text="Applicant Details" Width="162px"></asp:Label></td>
                        </tr>
                       
                        <tr>
                            <td style="width: 5px">
                            </td>
                            <td style="width: 146px" >
                                <asp:Label ID="Label14" runat="server" CssClass="Label" Text="Surname" Width="153px"></asp:Label></td>
                            <td style="width: 6px">
                                :</td>
                            <td>
                                <asp:Label ID="SURNAME" runat="server" CssClass="Label" Width="229px"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="width: 5px; height: 19px;">
                            </td>
                            <td style="width: 146px; height: 19px;">
                                <asp:Label ID="Label15" runat="server" CssClass="Label" Text="First Name"></asp:Label></td>
                            <td style="width: 6px; height: 19px;">
                                :</td>
                            <td style="height: 19px">
                                <asp:Label ID="FIRSTNAME" runat="server" CssClass="Label" Width="230px"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="width: 5px">
                            </td>
                            <td style="width: 146px">
                                <asp:Label ID="Label16" runat="server" CssClass="Label" Text="Middle Name"></asp:Label></td>
                            <td style="width: 6px">
                                :</td>
                            <td>
                                <asp:Label ID="MIDDLENAME" runat="server" CssClass="Label" Width="232px"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="width: 5px">
                            </td>
                            <td style="width: 146px">
                                <asp:Label ID="Label17" runat="server" CssClass="Label" Text="Sex"></asp:Label></td>
                            <td style="width: 6px">
                                :</td>
                            <td>
                                <asp:Label ID="SEX" runat="server" CssClass="Label"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="width: 5px">
                            </td>
                            <td style="width: 146px">
                                <asp:Label ID="Label18" runat="server" CssClass="Label" Text="Date of Birth"></asp:Label></td>
                            <td style="width: 6px">
                                :</td>
                            <td>
                                <asp:Label ID="BIRTHDATE" runat="server" CssClass="Label"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="width: 5px">
                            </td>
                            <td style="width: 146px">
                                <asp:Label ID="lbl_birthplace" runat="server" CssClass="Label" Text="Place of Birth"></asp:Label></td>
                            <td style="width: 6px">
                                :</td>
                            <td>
                                <asp:Label ID="BIRTHPLACE" runat="server" CssClass="Label" Width="235px"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="width: 5px; height: 19px">
                            </td>
                            <td style="width: 146px; height: 19px">
                                <asp:Label ID="Label3" runat="server" CssClass="Label" Text="Country of Birth"></asp:Label></td>
                            <td style="width: 6px; height: 19px">
                                :</td>
                            <td style="height: 19px">
                                <asp:Label ID="BIRTHCOUNTRY" runat="server" CssClass="Label" Width="236px"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="width: 5px">
                            </td>
                            <td style="width: 146px">
                                <asp:Label ID="Label32" runat="server" CssClass="Label" Text="Nationality"></asp:Label></td>
                            <td style="width: 6px">
                                :</td>
                            <td>
                                <asp:Label ID="NATIONALITY" runat="server" CssClass="Label" Width="228px"></asp:Label></td>
                        </tr>
                        <tr id="trNIS" runat="server" visible="true">
                            <td style="width: 5px">
                            </td>
                            <td style="width: 146px">
                                <asp:label id="lbl_NIC" runat="server" cssclass="Label" text="Passport No"
                                    width="153px"></asp:label></td>
                            <td style="width: 6px">
                                :</td>
                            <td>
                                <asp:label id="NATIONALINSURANCENO" runat="server" cssclass="Label" Width="153px"></asp:label></td>
                        </tr>
                        <tr id="Tr1" runat="server" visible="true">
                            <td style="width: 5px">
                            </td>
                            <td style="width: 146px">
                                <asp:Label ID="Label2" runat="server" Text="Passport Expiry Date" CssClass="Label" Width="123px"></asp:Label></td>
                            <td style="width: 6px">
                                :</td>
                            <td>
                                <asp:Label ID="EXPIRYDATE" runat="server" CssClass="Label"></asp:Label></td>
                        </tr>
                     </table>                   
                </td>
                <td valign="top">
                    <table id="Table4" cellpadding="0" cellspacing="0" border="0">
                                             
                        <tr>
                            <td style="height: 25px">
                                <asp:Label ID="lblPhoto" runat="server" CssClass="LabelHeadLine" Text="Photograph" Visible="False"></asp:Label></td>
                            <td style="height: 25px">
                            </td>
                            <td style="width: 83px; height: 25px">
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Image ID="FACEIMAGE" runat="server" Height="100px" ImageUrl="~/Images/spacer.gif"
                                    Width="80px" CssClass="ImgBorder" BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" Visible="False" /></td>
                            <td>
                            </td>
                            <td style="width: 83px">
                            </td>
                        </tr>
                        
                        </table>
                 
                </td>
            </tr>
            <tr>
                <td colspan="2" style="height: 35px">
                    <hr />
                </td>
            </tr>
            <tr>
                <td  colspan="2">
                   
                    <table id="Table1" cellpadding="0" cellspacing="0" border="0">
                        <tr>
                            <td style="width: 5px; height: 25px;">
                            </td>
                            <td style="height: 25px;" colspan="3">
                                <asp:Label ID="Label4" runat="server" CssClass="LabelHeadLine" Text="Application Details" Width="162px"></asp:Label>
                                </td>
                        </tr>
                        <tr id="trDOA" runat="server">
                            <td style="width: 5px">
                            </td>
                            <td style="width: 146px">
                                <asp:Label ID="Label5" runat="server" CssClass="Label" Text="Date of Application"></asp:Label></td>
                            <td style="width: 6px">
                                :</td>
                            <td style="width: 237px">
                                <asp:Label ID="ENROLDATE" runat="server" CssClass="Label"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="width: 5px">
                            </td>
                            <td style="width: 146px" valign="top">
                                <asp:Label ID="Label8" runat="server" CssClass="Label" Text="Application ID" Width="153px"></asp:Label></td>
                            <td style="width: 6px" valign="top">
                                :</td>
                            <td style="width: 237px">
                                <asp:Label ID="FORMNO" runat="server" CssClass="Label"></asp:Label>
                                <asp:Label ID="lblOfflineMsg" runat="server" CssClass="LabelHeadLine" Font-Bold="True" Font-Italic="True" 
                                    Text="(This is a temporary offline ApplicationID and is not meant to be used for record searching/issuance)"
                                    Width="350px" Font-Underline="False"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="width: 5px">
                            </td>
                            <td style="width: 146px" >
                                <asp:Label ID="Label10" runat="server" CssClass="Label" Text="Visa Type"></asp:Label></td>
                            <td style="width: 6px">
                                :</td>
                            <td style="width: 237px">
                                <asp:Label ID="DOCTYPE" runat="server" CssClass="Label" Width="226px"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="width: 5px; height: 19px">
                            </td>
                            <td style="width: 146px; height: 19px">
                                <asp:Label ID="Label1" runat="server" CssClass="Label" Text="Entry Type"></asp:Label></td>
                            <td style="width: 6px; height: 19px">
                                :</td>
                            <td style="height: 19px; width: 237px;">
                                <asp:Label ID="SUBDOCTYPE" runat="server" CssClass="Label" Width="226px"></asp:Label></td>
                        </tr>
                        <tr id="trAppReason" runat="server" visible="true">
                            <td style="width: 5px">
                            </td>
                            <td style="width: 146px">
                                <asp:Label ID="Label12" runat="server" CssClass="Label" Text="Purpose of Application"
                                    Width="126px"></asp:Label></td>
                            <td style="width: 6px">
                                :</td>
                            <td style="width: 237px">
                                <asp:Label ID="APPREASON" runat="server" CssClass="Label" Width="320px"></asp:Label></td>
                        </tr>
                        <tr id="trColDate" runat="server" visible="false">
                            <td style="width: 5px; height: 25px;">
                            </td>
                            <td style="width: 146px; height: 25px;">
                                <asp:Label ID="Label9" runat="server" CssClass="Label" Text="Collection Date" Width="86px"></asp:Label></td>
                            <td style="width: 6px; height: 25px;">
                                :</td>
                            <td style="height: 25px; width: 237px;">
                               <asp:Label ID="COLDATE" runat="server" CssClass="Label" Visible="true"></asp:Label></td>
                        </tr>
                    </table>
                </td>
                <td>
                    
                
                
                </td>
            </tr>           
        
        </table>
        <table cellpadding="0" cellspacing="0" border="0" width="100%">
            <tr>
                <td style="width: 5px; height: 8px">
                </td>
                <td style="height: 8px">
                </td>
            </tr>
        
         <tr>
            <td style="height: 8px; width: 5px;">
            </td>
            <td style="height: 8px;">
                <asp:Label ID="lblError" runat="server" CssClass="Label" ForeColor="Red" Visible="False"></asp:Label><asp:Label ID="lblSuccess" runat="server" CssClass="Label" ForeColor="Blue" Visible="False">transaction Completed!</asp:Label></td>
        </tr>
         <tr>
         <td style="width: 5px; height: 19px;">
         </td>
         <td style="height: 19px">
             &nbsp;<asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="Label"
                 ShowMessageBox="True" ShowSummary="False" Width="236px" />
         </td>
     </tr>
         <tr>
            <td style="width: 5px; height: 24px;">
            </td>
            <td style="height: 24px">
                <asp:Button ID="btnBack" runat="server" CssClass="Button" Width="104px" Text="Back" Visible="false"
                    OnClick="btnBack_Click"></asp:Button>&nbsp;
                    <asp:Button ID="btn_Submit" runat="server" CssClass="Button" Width="104px" Text="Submit"
                    OnClick="btn_Submit_Click" ></asp:Button>                         
                    <input id="btnPrint" visible="false" runat="server" type="button" value="Print"
                    onclick="print();" style="width: 77px" />
                <asp:Button ID="btnPayment" runat="server" CssClass="Button" OnClick="btnPayment_Click"
                    Text="Proceed to Payment >>" Visible="False" Width="149px" />
                    <asp:Button ID="btnApproval" runat="server" CssClass="Button" OnClick="btnApproval_Click"
                    Text="Proceed to Approval >>" Visible="False" Width="149px" /></td>
        </tr>
         <tr>
            <td style="height: 50px; width: 5px;">
            </td>
            <td style="height: 50px">
            </td>
        </tr>
        </table>
      
       
      <asp:HiddenField ID="txtCompName" runat="server" />  
    
  <div style="z-index: 101; left: -122px; visibility: hidden; width: 100px; position: absolute;
        top: 429px; height: 100px">
    <asp:TextBox ID="branch" runat="server" Width="32px"></asp:TextBox></div>

    <input id="IsNew" runat="server" type="hidden" /> 
    <input id="APPREASONID" runat="server" type="hidden" />    
    <input id="partdone" runat="server" type="hidden" />
    <input id="DOCTYPEID" runat="server" type="hidden" />
     <input id="SM" runat="server" type="hidden" />
<script type="text/javascript">

function CalPick(txtbox, status, text)
{
     var winObj = null; 
     winObj =  calendarPicker(txtbox, status, text);
     winObj.focus();
}
GetPcName();
</script>
</asp:Content>