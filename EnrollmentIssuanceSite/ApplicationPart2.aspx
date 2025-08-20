<%@ Page MasterPageFile="~/iden.master" Language="C#" AutoEventWireup="true" Inherits="EnrollmentIssuanceSite.ApplicationPart2" Codebehind="ApplicationPart2.aspx.cs" %>

<asp:Content ContentPlaceHolderID="Content" runat="server">
<asp:Panel ID="Panel1" runat="server" Height="28px" BackImageUrl="./images/bg.gif"
        Width="100%">
        <asp:Label ID="fly" runat="server" Height="16px" CssClass="HeaderMainTitle" ForeColor="DimGray" BackColor="Transparent" Width="353px" >Visa - Contact & Employment Details</asp:Label></asp:Panel>
        <input id="IsNew" type="hidden" runat="server" />
        <input id="APPREASON" type="hidden" runat="server" />
         <input id="DOCTYPE" type="hidden" runat="server" />
          <input id="FORMNO" type="hidden" runat="server" />
    <table style="width: 98%" border="0" cellpadding="0" cellspacing="2" id="tbPresentAdd">
        
        <tr>
            <td style="width: 6px; height: 18px;" >
            </td>
            <td colspan="4" style="height: 18px; background-color: #c6efef;">
                <asp:Label ID="Label4" runat="server" CssClass="LabelHeadGreen" Text="Contact Details"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 6px; ">
            </td>
            <td style="width: 126px; ">
            </td>
            <td style="width: 181px; ">
            </td>
            <td colspan="2" >
            </td>
        </tr>
      
        <tr>
            <td style="width: 6px;">
            </td>
            <td style="width: 126px;" valign="top">
                <asp:Label ID="Label1" runat="server" CssClass="Label" Text="Present Address" Width="105px"></asp:Label>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator12" runat="server"
                    ControlToValidate="PRESENTADDRESS" CssClass="Label" ErrorMessage="Present Address : Some special characters are NOT allowed"
                    ForeColor="White" ValidationExpression="([A-Z]|[a-z]|[-@#/.,&quot;':\]|[0-9]|\s){1,200}">*</asp:RegularExpressionValidator></td>
            <td style="width: 181px;">
                <asp:TextBox ID="PRESENTADDRESS" runat="server" MaxLength="200" Width="200px" TabIndex="1" Rows="5" TextMode="MultiLine" CssClass="Label" onkeypress="return textboxMultilineMaxNumber(this,200)"  onpaste="return doPaste(this,200)"></asp:TextBox></td>
            <td style="width: 125px;" valign="top">
                <asp:Label ID="Label2" runat="server" CssClass="Label" Text="Permanent Address"
                    Width="112px"></asp:Label>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="PERMANENTADDRESS"
                    CssClass="Label" ErrorMessage="Permanent Address: Some special characters are NOT allowed"
                    ForeColor="White" ValidationExpression="([A-Z]|[a-z]|[-@#/.,&quot;':\]|[0-9]|\s){1,200}">*</asp:RegularExpressionValidator></td>
            <td style="width: 203px; ">
                <asp:TextBox ID="PERMANENTADDRESS" runat="server" MaxLength="200" Rows="5" TabIndex="5" TextMode="MultiLine"
                    Width="200px" CssClass="Label" onkeypress="return textboxMultilineMaxNumber(this,200)"  onpaste="return doPaste(this,200)"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 6px; height: 24px;">
            </td>
            <td style="width: 126px; height: 24px;">
                <asp:Label ID="Label3" runat="server" CssClass="Label" Text="Mobile Telephone"></asp:Label>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator15" runat="server"
                    ControlToValidate="MOBILE" CssClass="Label" ErrorMessage="Mobile Phone: Only numeric and hyphen are allowed"
                    ForeColor="White" ValidationExpression="([-]|[0-9]|\s){1,50}">*</asp:RegularExpressionValidator></td>
            <td style="width: 181px; height: 24px;">
                <asp:TextBox ID="MOBILE" runat="server" MaxLength="20" TabIndex="2" Width="200px"></asp:TextBox></td>
            <td style="width: 125px; height: 24px;">
                <asp:Label ID="Label20" runat="server" CssClass="Label" Text="Email"></asp:Label><asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="EMAIL"
                    CssClass="Label" ErrorMessage="Email format is xx@xx.xxx" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator></td>
            <td style="width: 203px; height: 24px;">
                <asp:TextBox ID="EMAIL" runat="server" MaxLength="50" Width="200px" TabIndex="6"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 6px; height: 24px;">
            </td>
            <td style="width: 126px; height: 24px;">
                <asp:Label ID="Label19" runat="server" CssClass="Label" Text="Telephone"></asp:Label><asp:Label ID="Label30" runat="server" CssClass="Label" Font-Italic="True" Text="(Home)"></asp:Label><asp:RegularExpressionValidator
                    ID="RegularExpressionValidator6" runat="server" ControlToValidate="PHONEHOME"
                    CssClass="Label" ErrorMessage="Telephone (Home): Only numeric and hyphen are allowed"
                    ForeColor="White" ValidationExpression="([-]|[0-9]|\s){1,50}">*</asp:RegularExpressionValidator></td>
            <td style="width: 181px; height: 24px;">
                <asp:TextBox ID="PHONEHOME" runat="server" MaxLength="50" TabIndex="3" Width="200px"></asp:TextBox></td>
            <td style="width: 125px; height: 24px;">
                <asp:Label ID="Label5" runat="server" CssClass="Label" Text="Fax"></asp:Label>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="FAX"
                    CssClass="Label" ErrorMessage="Fax : Only numeric and hyphen are allowed" ForeColor="White"
                    ValidationExpression="([-]|[0-9]|\s){1,50}">*</asp:RegularExpressionValidator></td>
            <td style="width: 203px; height: 24px;">
                <asp:TextBox ID="FAX" runat="server" MaxLength="50" TabIndex="7" Width="200px"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 6px">
            </td>
            <td style="width: 126px">
                <asp:Label ID="Label29" runat="server" CssClass="Label" Text="Telephone"></asp:Label><asp:Label ID="Label31" runat="server" CssClass="Label" Font-Italic="True" Text="(Work)"></asp:Label><asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="PHONEWORK"
                    CssClass="Label" ErrorMessage="Telephone(Work): Only numeric and hyphen are allowed"
                    ForeColor="White" ValidationExpression="([-]|[0-9]|\s){1,50}">*</asp:RegularExpressionValidator></td>
            <td style="width: 181px">
                <asp:TextBox ID="PHONEWORK" runat="server" MaxLength="50" Width="200px" TabIndex="4"></asp:TextBox></td>
            <td style="width: 125px">
                &nbsp;</td>
            <td style="width: 203px">
                </td>
        </tr>
        <tr>
            <td style="width: 6px; height: 19px">
            </td>
            <td colspan="4" style="height: 18px; background-color: #c6efef">
                <asp:Label ID="Label6" runat="server" CssClass="LabelHeadGreen" Text="Emergency Contact Details"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 6px">
            </td>
            <td style="width: 126px">
            </td>
            <td style="width: 181px">
            </td>
            <td style="width: 125px">
            </td>
            <td style="width: 203px">
            </td>
        </tr>
        <tr>
            <td style="width: 6px">
            </td>
            <td style="width: 126px">
                <asp:Label ID="Label7" runat="server" CssClass="Label" Text="Name"></asp:Label>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator18" runat="server"
                    ControlToValidate="EGCONTACTNAME" CssClass="Label" ErrorMessage="Emergency Contact: Name - Some special characters are NOT allowed"
                    ForeColor="White" ValidationExpression="([A-Z]|[a-z]|[-@#/.,&quot;':\]|[0-9]|\s){1,50}">*</asp:RegularExpressionValidator></td>
            <td style="width: 181px">
                <asp:TextBox ID="EGCONTACTNAME" runat="server" MaxLength="50" TabIndex="8" Width="200px"></asp:TextBox></td>
            <td style="width: 125px">
                <asp:Label ID="Label23" runat="server" CssClass="Label" Text="Relationship" Width="71px"></asp:Label>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator20" runat="server"
                    ControlToValidate="EGCONTACTRELATIONSHIP" CssClass="Label" ErrorMessage="Emergency Contact : Relationship - Some special characters are NOT allowed"
                    ForeColor="White" ValidationExpression="([A-Z]|[a-z]|[-@#/.,&quot;':\]|[0-9]|\s){1,25}">*</asp:RegularExpressionValidator></td>
            <td style="width: 203px">
                <asp:TextBox ID="EGCONTACTRELATIONSHIP" runat="server" MaxLength="25" TabIndex="10" Width="200px"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 6px">
            </td>
            <td style="width: 126px" valign="top">
                <asp:Label ID="Label8" runat="server" CssClass="Label" Text="Address"></asp:Label>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator19" runat="server"
                    ControlToValidate="EGCONTACTADDRESS" CssClass="Label" ErrorMessage="Emergency Contact : Address - Some special characters are NOT allowed"
                    ForeColor="White" ValidationExpression="([A-Z]|[a-z]|[-@#/.,&quot;':\]|[0-9]|\s){1,200}">*</asp:RegularExpressionValidator></td>
            <td style="width: 181px">
                <asp:TextBox ID="EGCONTACTADDRESS" runat="server" CssClass="Label" MaxLength="200" Rows="5"
                    TabIndex="9" TextMode="MultiLine" Width="200px" onkeypress="return textboxMultilineMaxNumber(this,200)"  onpaste="return doPaste(this,200)"></asp:TextBox></td>
            <td style="width: 125px" valign="top">
                <asp:Label ID="Label24" runat="server" CssClass="Label" Text="Telephone"></asp:Label>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator21" runat="server"
                    ControlToValidate="EGCONTACTPHONE" CssClass="Label" ErrorMessage="Emergency Contact : Phone No - Only numeric and hyphen are allowed"
                    ForeColor="White" ValidationExpression="([-]|[0-9]|\s){1,50}">*</asp:RegularExpressionValidator></td>
            <td style="width: 203px" valign="top">
                <asp:TextBox ID="EGCONTACTPHONE" runat="server" MaxLength="20" TabIndex="11" Width="200px"></asp:TextBox></td>
        </tr>
    </table>
   
     <table id="tbBhsEmployer" cellpadding="0" cellspacing="2" border="0" visible="true" runat="server" width="98%">
        <tr>
            <td style="width: 12px; height: 19px;">
            </td>
            <td colspan="4" style="height: 19px; background-color: #c6efef">
                <asp:Label ID="Label9" runat="server" CssClass="LabelHeadGreen" Text="Employment Details "></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 12px; height: 1px">
            </td>
            <td colspan="4" style="height: 1px">
            </td>
        </tr>
        <tr>
            <td style="width: 12px; height: 16px">
            </td>
            <td colspan="2" style="height: 16px">
                <asp:Label ID="Label10" runat="server" CssClass="LabelHeadLine" Text="Present Employment"></asp:Label></td>
            <td colspan="2" style="height: 16px">
                <asp:Label ID="Label11" runat="server" CssClass="LabelHeadLine" Text="Former Employment"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 12px; height: 16px">
            </td>
            <td style="width: 223px; height: 16px">
                <asp:Label ID="Label12" runat="server" CssClass="Label" Text="Occupation"></asp:Label>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator11" runat="server"
                    ControlToValidate="OCCUPATION" CssClass="Label" ErrorMessage="Occupation : Some special characters are NOT allowed"
                    ForeColor="White" ValidationExpression="([A-Z]|[a-z]|[-@#/.,&quot;':\]|[0-9]|\s){1,25}">*</asp:RegularExpressionValidator></td>
            <td style="width: 269px; height: 16px">
                <asp:TextBox ID="OCCUPATION" runat="server" MaxLength="25" Width="200px" TabIndex="12"></asp:TextBox></td>
            <td style="width: 201px; height: 16px">
                <asp:Label ID="Label13" runat="server" CssClass="Label" Text="Occupation" Width="89px"></asp:Label>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="FORMEROCCUPATION"
                    CssClass="Label" ErrorMessage="Former Occupation : Some special characters are NOT allowed"
                    ForeColor="White" ValidationExpression="([A-Z]|[a-z]|[-@#/.,&quot;':\]|[0-9]|\s){1,25}">*</asp:RegularExpressionValidator></td>
            <td style="width: 276px; height: 16px">
                <asp:TextBox ID="FORMEROCCUPATION" runat="server" MaxLength="25" TabIndex="17" Width="200px"></asp:TextBox></td>
        </tr>
        <tr valign="middle">
            <td style="width: 12px;">
            </td>
            <td style="width: 223px;">
                <asp:Label ID="Label14" runat="server" CssClass="Label" Text="No. of Years Employed"></asp:Label>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator17" runat="server"
                    ControlToValidate="YEARSEMPLOYED" CssClass="Label" ErrorMessage="Present Employment: No. of years of employed -  Only numerics allowed"
                    ForeColor="White" ValidationExpression="([0-9]|\s){1,50}">*</asp:RegularExpressionValidator>
                </td>
            <td style="width: 269px;">
                <asp:TextBox ID="YEARSEMPLOYED" runat="server" MaxLength="3" Width="200px" TabIndex="13"></asp:TextBox></td>
            <td style="width: 201px;">
                <asp:Label ID="Label15" runat="server" CssClass="Label" Text="No. of Years Employed"></asp:Label>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="FORMERYEARSEMPLOYED"
                    CssClass="Label" ErrorMessage="Former Employment:No. of Years of Employed - Only numeric allowed"
                    ForeColor="White" ValidationExpression="([0-9]|\s){1,100}">*</asp:RegularExpressionValidator></td>
            <td style="width: 276px;">
            <asp:TextBox ID="FORMERYEARSEMPLOYED" runat="server" MaxLength="25" Width="200px" TabIndex="18"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 12px; height: 24px;">
            </td>
            <td style="width: 223px; height: 24px;" valign="middle">
                <asp:Label ID="Label16" runat="server" CssClass="Label" Text="Employer's Name"></asp:Label>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ControlToValidate="EMPLOYERNAME"
                    CssClass="Label" ErrorMessage="Present Employment:Employer's Name- Some special characters are NOT allowed"
                    ForeColor="White" ValidationExpression="([A-Z]|[a-z]|[-@#/.,&quot;':\]|[0-9]|\s){1,50}">*</asp:RegularExpressionValidator></td>
            <td style="width: 269px; height: 24px;">
                <asp:TextBox ID="EMPLOYERNAME" runat="server" MaxLength="50" Width="200px" TabIndex="14"></asp:TextBox></td>
            <td style="width: 201px; height: 24px;">
                <asp:Label ID="Label17" runat="server" CssClass="Label" Text="Employer's Name"></asp:Label><asp:RegularExpressionValidator
                    ID="RegularExpressionValidator9" runat="server" ControlToValidate="FORMEREMPLOYERNAME"
                    CssClass="Label" ErrorMessage="Former Employment:Employer's Name - Some special characters are NOT allowed"
                    ForeColor="White" ValidationExpression="([A-Z]|[a-z]|[-@#/.,&quot;':\]|[0-9]|\s){1,50}">*</asp:RegularExpressionValidator></td>
            <td style="width: 276px; height: 24px;">
            <asp:TextBox ID="FORMEREMPLOYERNAME" runat="server" MaxLength="50" Width="200px" TabIndex="19"></asp:TextBox>
                </td>
        </tr>
    <tr>
        <td style="width: 12px; height: 24px">
        </td>
        <td style="width: 223px; height: 24px" valign="middle">
            <asp:Label ID="Label18" runat="server" CssClass="Label" Text="Employer's Phone No"></asp:Label>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator16" runat="server" ControlToValidate="EMPLOYERPHONE"
                CssClass="Label" ErrorMessage="Present Employment: Phone No - Only numeric and hyphen are allowed"
                ForeColor="White" ValidationExpression="([-]|[0-9]|\s){1,50}">*</asp:RegularExpressionValidator></td>
        <td style="width: 269px; height: 24px">
            <asp:TextBox ID="EMPLOYERPHONE" runat="server" MaxLength="20" Width="200px" TabIndex="15"></asp:TextBox></td>
        <td style="width: 201px; height: 24px">
            <asp:Label ID="Label21" runat="server" CssClass="Label" Text="Employer's Phone No"></asp:Label>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator10" runat="server" ControlToValidate="FORMEREMPLOYERPHONE"
                CssClass="Label" ErrorMessage="Former Employment:Phone No - Only numeric and hyphen are allowed"
                ForeColor="White" ValidationExpression="([-]|[0-9]|\s){1,20}">*</asp:RegularExpressionValidator></td>
        <td style="width: 276px; height: 24px">
            <asp:TextBox ID="FORMEREMPLOYERPHONE" runat="server" MaxLength="20" Width="200px" TabIndex="20"></asp:TextBox>
            </td>
    </tr>
    <tr>
        <td style="width: 12px; height: 24px" valign="top">
        </td>
        <td style="width: 223px; height: 24px" valign="top">
                <asp:Label ID="Label22" runat="server" CssClass="Label" Text="Employer's Address"></asp:Label>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator13" runat="server" ControlToValidate="EMPLOYERADDRESS"
                CssClass="Label" ErrorMessage="Present Employment:Employer's Address - Some special characters are NOT allowed"
                ForeColor="White" ValidationExpression="([A-Z]|[a-z]|[-@#/.,&quot;':\]|[0-9]|\s){1,200}">*</asp:RegularExpressionValidator></td>
        <td style="width: 269px; height: 24px" valign="top">
                <asp:TextBox ID="EMPLOYERADDRESS" runat="server" MaxLength="200" Width="200px" TabIndex="16" Rows="5" TextMode="MultiLine" CssClass="Label" onkeypress="return textboxMultilineMaxNumber(this,200)"  onpaste="return doPaste(this,200)"></asp:TextBox></td>
        <td style="width: 201px; height: 24px" valign="top">
            <asp:Label ID="Label27" runat="server" CssClass="Label" Text="Employer's Address"></asp:Label>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator14" runat="server" ControlToValidate="FORMEREMPLOYERADDRESS"
                CssClass="Label" ErrorMessage="Former Employment:Employer's Address - Some special characters are NOT allowed"
                ForeColor="White" ValidationExpression="([A-Z]|[a-z]|[-@#/.,&quot;':\]|[0-9]|\s){1,200}">*</asp:RegularExpressionValidator></td>
        <td style="width: 276px; height: 24px" valign="top">
            <asp:TextBox ID="FORMEREMPLOYERADDRESS" runat="server" MaxLength="200" Rows="5" TabIndex="21" TextMode="MultiLine"
                Width="200px" CssClass="Label" onkeypress="return textboxMultilineMaxNumber(this,200)"  onpaste="return doPaste(this,200)"></asp:TextBox></td>
    </tr>
    <tr>
        <td style="width: 12px; height: 24px">
        </td>
        <td style="width: 223px; height: 24px" valign="middle">
            &nbsp;</td>
        <td style="width: 269px; height: 24px">
                </td>
        <td style="width: 201px; height: 24px">
            &nbsp;</td>
        <td style="width: 276px; height: 24px">
        </td>
    </tr>
</table>
        
    
   
    <br/>
    <table border="0" cellpadding="0" cellspacing="0" width="98%">
    <tr>
    <td style="width:4px">&nbsp</td>
     <td><asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="Label" ShowMessageBox="True"
                    ShowSummary="False" Width="236px" />
                <asp:Label ID="lblError" runat="server" CssClass="Label" ForeColor="Red" Visible="False" Width="304px">* Please take note that every field must be filled.</asp:Label>
                         </td> 
    </tr>
    <tr>
    <td style="width:4px">&nbsp</td>     
    <td> &nbsp;<asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click"
                            CausesValidation="false" />
                            <asp:Button ID="btnSave" runat="server" Width="96px" CssClass="Button" Text="Save &amp; Next" OnClick="btnSave_Click" TabIndex="26"></asp:Button>
                            <asp:Button ID="btnReset" runat="server" CssClass="Button" Text="Reset" CausesValidation="False"
                             Visible="false"></asp:Button>
                         </td>
    </tr>
    
    </table>
 <asp:HiddenField ID="txtCompName" runat="server" />  
 <asp:HiddenField ID="IDPERSON" runat="server" /> 
<script type="text/javascript">
function CalPick(txtbox, status, text)
{    
     var winObj = null; 
     winObj =  calendarPicker(txtbox, status, text)
     winObj.focus();
}
function Clear(datetxtbox)
{   
   var txtname = "ctl00_Content_"+datetxtbox;
   document.getElementById(txtname).value = "";
}
function textboxMultilineMaxNumber(txt,maxLen)
{
    try
    {
        if(txt.value.length > (maxLen-1))return false;
    }
    catch(e)
    {
    }
}
function doPaste(txt,maxLen)
{   
     var value = txt.value;
     if(maxLen)
     {
          event.returnValue = false;
          maxLength = parseInt(maxLen);
          var oTR = txt.document.selection.createRange();
          var iInsertLength = maxLen - value.length + oTR.text.length;
          var sData = window.clipboardData.getData("Text").substr(0,iInsertLength);
          oTR.text = sData;
     }
}
GetPcName();
</script>

</asp:Content>
