<%@ Page MasterPageFile="~/iden.master" Language="C#" AutoEventWireup="true" Inherits="EnrollmentIssuanceSite.ApplicationPart3" Codebehind="ApplicationPart3.aspx.cs" %>

<asp:Content ContentPlaceHolderID="Content" runat="server">
<asp:Panel ID="Panel1" runat="server" Height="28px" BackImageUrl="./images/bg.gif"
        Width="100%">
        <asp:Label ID="fly" runat="server" Height="16px" CssClass="HeaderMainTitle" ForeColor="DimGray" BackColor="Transparent" Width="353px" >E-ID - Travel & Family Details</asp:Label></asp:Panel>
        <input id="IsNew" type="hidden" runat="server" />
        <input id="APPREASON" type="hidden" runat="server" />
        <input id="DOCTYPE" type="hidden" runat="server" />  
    <table style="width: 98%" border="0" cellpadding="0" cellspacing="2" id="tbTravelWP" runat="server" >
        
        <tr>
            <td style="width: 6px" >
            </td>
            <td colspan="4" style="height: 19px; background-color: #c6efef;">
                <asp:Label ID="Label23" runat="server" CssClass="LabelHeadGreen" Text="Travel Details"></asp:Label></td>
        </tr>
        <tr>
            <td>
            </td>
            <td style="width: 157px" >
            </td>
            <td style="width: 233px" >
            </td>
            <td style="width: 160px" >
            </td>
            <td >
            </td>
        </tr>
        <tr>
            <td style="height: 24px;">
            </td>
            <td style="height: 24px; width: 157px;">
                <asp:Label ID="Label26" runat="server" Text="Length of Stay" CssClass="Label" Width="83px"></asp:Label></td>
            <td style="height: 24px; width: 233px;">
                <asp:TextBox ID="LENGTHOFSTAY" runat="server" MaxLength="20" TabIndex="1" Width="200px"></asp:TextBox></td>
            <td style="height: 24px; width: 160px;">
                <asp:Label ID="Label6" runat="server" CssClass="Label" Text="Name of Person/Hotel"
                    Width="124px"></asp:Label></td>
            <td style="height: 24px;">
                <asp:TextBox ID="HOTELNAME" runat="server" MaxLength="100" TabIndex="5" Width="205px"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 6px">
            </td>
            <td style="width: 157px" >
                <asp:Label ID="Label25" runat="server" Text="Date of Arrival" CssClass="Label" Width="134px"></asp:Label></td>
            <td style="width: 233px" >
                <asp:TextBox ID="ARRIVALDATE" runat="server" MaxLength="25" Width="154px" ReadOnly="True"></asp:TextBox><asp:ImageButton
                    ID="ImageButton3" runat="server" CausesValidation="False" ImageUrl="~/images/button.gif"
                    OnClientClick="CalPick('ARRIVALDATE','L','Date of Arrival');return false;" TabIndex="2" /><img id="imgClearDOB" runat="server" alt="" onclick="Clear('ARRIVALDATE');return false;"
                    src="images/icon_clear.gif" style="cursor: hand" /></td>
            <td style="width: 160px" >
                <asp:Label ID="Label8" runat="server" CssClass="Label" Text="Phone No. of Person/Hotel"
                    Width="111px"></asp:Label></td>
            <td  valign="top">
                <asp:TextBox ID="HOTELPHONE" runat="server" MaxLength="15" TabIndex="6" Width="205px"></asp:TextBox></td>
        </tr>
        <tr id="trShortTermWP" runat="server">
            <td style="width: 6px">
            </td>
            <td valign="top" style="width: 157px" >
                <asp:Label ID="Label24" runat="server" CssClass="Label" Text="Purpose of Visit" Width="119px"></asp:Label></td>
            <td  valign="top" style="width: 233px">
                <asp:DropDownList ID="VISITPURPOSE" runat="server" CssClass="Label" Width="210px" TabIndex="3" OnClick="return ShowOtherVisitPurpose();" >                   
                </asp:DropDownList>
                <asp:TextBox ID="OTHERVISITPURPOSE" runat="server" MaxLength="50" TabIndex="4" Width="200px"></asp:TextBox></td>
            <td  valign="top" style="width: 160px">
                <asp:Label ID="Label7" runat="server" CssClass="Label" Text="Address of Person/Hotel"
                    Width="122px"></asp:Label></td>
            <td>
                <asp:TextBox ID="HOTELADDRESS" runat="server" MaxLength="200" Rows="4" TabIndex="7" TextMode="MultiLine"
                    Width="208px" CssClass="Label"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 6px">
            </td>
            <td style="width: 157px" valign="top">
                </td>
            <td style="width: 233px" valign="top">
                </td>
            <td style="width: 160px" valign="top">
            </td>
            <td>
            </td>
        </tr>
    </table>
     <table style="width: 98%" border="0" cellpadding="0" cellspacing="2" id="Table1" runat="server" >
        
        <tr>
            <td style="width: 6px" >
            </td>
            <td colspan="4" style="height: 19px; background-color: #c6efef;">
                <asp:Label ID="Label3" runat="server" CssClass="LabelHeadGreen" Text="Marriage Info"
                    Width="119px"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 6px">
            </td>
            <td colspan="2">
                </td>
            <td style="width: 160px" >
            </td>
            <td >
            </td>
        </tr>
        <tr>
            <td style="width: 6px; height: 24px;">
            </td>
            <td style=" height: 24px; width: 156px;">
                <asp:Label ID="Label2" runat="server" CssClass="Label" Text="Marital Status" Width="119px"></asp:Label>
                </td>
            <td style="height: 24px; width: 234px;">
                <asp:DropDownList ID="MARITALSTATUS" runat="server" CssClass="Label" Width="210px" TabIndex="8">                                       
                    <asp:ListItem Value="1">SINGLE</asp:ListItem>
                    <asp:ListItem Value="2">MARRIED</asp:ListItem>
                    <asp:ListItem Value="4">DIVORCED</asp:ListItem>
                    <asp:ListItem Value="5">WIDOWED</asp:ListItem>
                    <asp:ListItem Value="3">SEPERATED</asp:ListItem>
                    <asp:ListItem Value="12">COMMON LAW</asp:ListItem>
                </asp:DropDownList></td>
            <td style=" height: 24px; width: 160px;">
                 <asp:Label ID="Label14" runat="server" CssClass="Label" Text="Spouse's Maiden Name"
                     Width="134px"></asp:Label></td>
            <td style=" height: 24px;">
                 <asp:TextBox ID="SPOUSEMAIDENNAME" runat="server" MaxLength="30" TabIndex="12" Width="200px"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 6px">
            </td>
            <td style="width: 156px">
                <asp:Label ID="Label4" runat="server" Text="Spouse's Surname" CssClass="Label" Width="106px"></asp:Label></td>
            <td style="width: 234px">
                <asp:TextBox ID="SPOUSELASTNAME" runat="server" MaxLength="30" Width="200px" TabIndex="9"></asp:TextBox>
                </td>
            <td style="width: 160px" >
                <asp:Label ID="Label9" runat="server" CssClass="Label" Text="Date of Birth" Width="89px"></asp:Label></td>
            <td  valign="top">
                <asp:TextBox ID="SPOUSEDOB" runat="server" MaxLength="25" Width="154px" ReadOnly="True"></asp:TextBox><asp:ImageButton
                    ID="btn_Cal" runat="server" CausesValidation="False" ImageUrl="~/images/button.gif"
                    OnClientClick="DOBClick();return false;" TabIndex="13" /><img id="img1" runat="server" alt="" onclick="Clear('WPARRIVALDATE');return false;"
                    src="images/icon_clear.gif" style="cursor: hand" /></td>
        </tr>
         <tr>
             <td style="width: 6px">
             </td>
             <td style="width: 156px" >
                 <asp:Label ID="Label12" runat="server" CssClass="Label" Text="Spouse's First Name"
                     Width="119px"></asp:Label></td>
             <td style="width: 234px" >
                 <asp:TextBox ID="SPOUSEFIRSTNAME" runat="server" MaxLength="30" TabIndex="10" Width="200px"></asp:TextBox></td>
             <td style="width: 160px" >
                <asp:Label ID="Label11" runat="server" CssClass="Label" Text="Has Children?" Width="89px"></asp:Label></td>
             <td  valign="top">
                <asp:RadioButtonList ID="HASCHILDIND" runat="server" CssClass="Label" RepeatDirection="Horizontal"
                    TabIndex="14">
                    <asp:ListItem Value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="0" Selected="True">No</asp:ListItem>
                </asp:RadioButtonList></td>
         </tr>
         <tr>
             <td style=" height: 24px">
             </td>
             <td style=" height: 24px; width: 156px;">
                 <asp:Label ID="Label13" runat="server" CssClass="Label" Text="Spouse's Middle Name"
                     Width="129px"></asp:Label></td>
             <td style=" height: 24px; width: 234px;">
                 <asp:TextBox ID="SPOUSEMIDDLENAME" runat="server" MaxLength="30" TabIndex="11" Width="200px"></asp:TextBox></td>
             <td style=" height: 24px; width: 160px;">
                 <asp:Label ID="Label15" runat="server" CssClass="Label" Text="Travelling with Spouse?"
                     Width="134px"></asp:Label></td>
             <td style=" height: 24px" valign="top">
                 <asp:RadioButtonList ID="TRAVELWITHSPOUSEIND" runat="server" CssClass="Label" RepeatDirection="Horizontal"
                     TabIndex="15">
                     <asp:ListItem Value="1">Yes</asp:ListItem>
                     <asp:ListItem Value="0" Selected="True">No</asp:ListItem>
                 </asp:RadioButtonList></td>
         </tr>
        <tr >
            <td style="width: 6px">
            </td>
            <td  style="width: 156px" >
                </td>
            <td  style="width: 234px">
                </td>
            <td  style="width: 160px">
                </td>
            <td >
                </td>
        </tr>
        </table>
    
       <table style="width: 98%" border="0" cellpadding="0" cellspacing="2" id="Table3" runat="server" >
        <tr>
            <td style="width: 6px">
            </td>
            <td style="height: 19px; background-color: #c6efef;" colspan="4">
                <asp:Label ID="Label27" runat="server" CssClass="LabelHeadGreen" Text="Parents Info"
                    Width="119px"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 6px; height: 24px;">
            </td>
            <td style="width: 139px; height: 24px;">
                <asp:Label ID="Label28" runat="server" CssClass="Label" Text="Father's Surname" Width="119px"></asp:Label>
                </td>
            <td style="width: 208px; height: 24px;">
                <asp:TextBox ID="FATHERLASTNAME" runat="server" MaxLength="30" TabIndex="16" Width="200px"></asp:TextBox></td>
            <td style="width: 111px; height: 24px;">
                <asp:Label ID="Label29" runat="server" CssClass="Label" Text="Mother's Surname"
                    Width="112px"></asp:Label></td>
            <td style="width: 203px; height: 24px;">
                <asp:TextBox ID="MOTHERLASTNAME" runat="server" MaxLength="30" TabIndex="20" Width="205px"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 6px">
            </td>
            <td style="width: 139px">
                <asp:Label ID="Label30" runat="server" Text="Father's First Name" CssClass="Label" Width="121px"></asp:Label></td>
            <td style="width: 208px">
                <asp:TextBox ID="FATHERFIRSTNAME" runat="server" MaxLength="30" Width="200px" TabIndex="17"></asp:TextBox></td>
            <td style="width: 111px">
                <asp:Label ID="Label31" runat="server" CssClass="Label" Text="Mother's First Name"
                    Width="128px"></asp:Label></td>
            <td style="width: 203px" valign="top">
                <asp:TextBox ID="MOTHERFIRSTNAME" runat="server" MaxLength="30" TabIndex="21" Width="205px"></asp:TextBox></td>
        </tr>
        <tr id="tr10" runat="server">
            <td style="width: 6px">
            </td>
            <td style="width: 139px" valign="top" >
                <asp:Label ID="Label32" runat="server" Text="Father's Middle Name" CssClass="Label" Width="136px"></asp:Label></td>
            <td style="width: 208px" valign="top">
                <asp:TextBox ID="FATHERMIDDLENAME" runat="server" MaxLength="30" TabIndex="18" Width="200px"></asp:TextBox></td>
            <td style="width: 111px" valign="top">
                <asp:Label ID="Label33" runat="server" CssClass="Label" Text="Mother's Middle Name"
                    Width="143px"></asp:Label></td>
            <td style="width: 203px">
                <asp:TextBox ID="MOTHERMIDDLENAME" runat="server" MaxLength="30" TabIndex="22" Width="205px"></asp:TextBox></td>
        </tr>
           <tr id="Tr11" runat="server">
               <td style="width: 6px">
               </td>
               <td style="width: 139px" valign="top">
                   <asp:Label ID="Label34" runat="server" CssClass="Label" Text="Father's Nationality"
                       Width="136px"></asp:Label></td>
               <td style="width: 208px" valign="top">
                   <asp:DropDownList ID="FATHERNATIONALITY" runat="server" CssClass="Label" TabIndex="19"
                       Width="206px">
                   </asp:DropDownList></td>
               <td style="width: 111px" valign="top">
                   <asp:Label ID="Label35" runat="server" CssClass="Label" Text="Mother's Nationality"
                       Width="136px"></asp:Label></td>
               <td style="width: 203px">
                   <asp:DropDownList ID="MOTHERNATIONALITY" runat="server" CssClass="Label" TabIndex="23"
                       Width="211px">
                   </asp:DropDownList></td>
           </tr>
    </table>
        <table style="width: 98%" border="0" cellpadding="0" cellspacing="2" id="Table2" runat="server" >
         <tr id="Tr2" runat="server">
             <td style="width: 6px">
             </td>
             <td valign="top" colspan="4" style="height: 19px; background-color: #c6efef">
                 <asp:Label ID="Label5" runat="server" CssClass="LabelHeadGreen" Text="Dependants Info"
                     Width="119px"></asp:Label></td>
         </tr>
         <tr id="Tr3" runat="server">
             <td style="width: 6px;">
             </td>
             <td valign="top" colspan="4" >
             </td>
         </tr>
            <tr id="Tr1" runat="server">
                <td style="width: 6px; height: 19px">
                </td>
                <td colspan="2" style="height: 19px" valign="top">
                    <asp:Label ID="Label22" runat="server" CssClass="Label" Text="Travelling with Dependants?"
                        Width="159px"></asp:Label>
                </td>
                <td colspan="2" style="width: 173px; height: 19px" valign="top">
                    <asp:RadioButtonList ID="TRAVELWITHDEPENDANTIND" runat="server" CssClass="Label" RepeatDirection="Horizontal"
                     TabIndex="24">
                        <asp:ListItem Value="1">Yes</asp:ListItem>
                        <asp:ListItem Value="0" Selected="True">No</asp:ListItem>
                    </asp:RadioButtonList></td>
            </tr>
         <tr runat="server" id="Tr4">
             <td style="width: 6px; height: 19px;">
             </td>
             <td style="width: 2px; height: 19px;" valign="top">
             </td>
             <td style="width: 216px; height: 19px;" valign="top">
                 <asp:Label ID="Label16" runat="server" CssClass="LabelHeadLine" Text="Full Name"
                     Width="119px"></asp:Label></td>
             <td style="height: 19px; width: 173px;" valign="top" colspan="2">
                 <asp:Label ID="Label17" runat="server" CssClass="LabelHeadLine" Text="Relationship to Applicant"
                     Width="152px"></asp:Label><asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="FATHERLASTNAME"
                       CssClass="Label" ErrorMessage="Father's Surname - Only alphabet is allowed" ForeColor="White"
                       ValidationExpression="([a-z]|[A-Z]|[-']|\s){1,30}">*</asp:RegularExpressionValidator></td>
         </tr>
         <tr runat="server" id="Tr5">
             <td style="width: 6px; height: 19px;">
             </td>
             <td style="width: 2px; height: 19px;" valign="top">
                 <asp:Label ID="Label10" runat="server" CssClass="Label" Text="1." Width="12px"></asp:Label></td>
             <td style="height: 19px; width: 216px;" valign="top">
                 <asp:TextBox ID="DEPENDANTNAME1" runat="server" MaxLength="100" TabIndex="25" Width="200px"></asp:TextBox>&nbsp;</td>
             <td style="height: 19px;" valign="top" colspan="2">
                 <asp:TextBox ID="RELATIONSHIP1" runat="server" MaxLength="20" TabIndex="26" Width="200px"></asp:TextBox>
                 <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="DEPENDANTNAME1"
                     CssClass="Label" ErrorMessage="Dependant 1 name - Only alphabet is allowed" ForeColor="White"
                     ValidationExpression="([a-z]|[A-Z]|[-']|\s){1,100}">*</asp:RegularExpressionValidator>
                 <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="FATHERFIRSTNAME"
                       CssClass="Label" ErrorMessage="Father's first name - Only alphabet is allowed"
                       ForeColor="White" ValidationExpression="([a-z]|[A-Z]|[-']|\s){1,30}">*</asp:RegularExpressionValidator>
                 <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="MOTHERMIDDLENAME"
                       CssClass="Label" ErrorMessage="Mother's middle name - Only alphabet is allowed"
                       ForeColor="White" ValidationExpression="([a-z]|[A-Z]|[-']|\s){1,30}">*</asp:RegularExpressionValidator>
                 <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="MOTHERLASTNAME"
                       CssClass="Label" ErrorMessage="Mother's Surname - Only alphabet is allowed" ForeColor="White"
                       ValidationExpression="([a-z]|[A-Z]|[-']|\s){1,30}">*</asp:RegularExpressionValidator>
                 <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="MOTHERFIRSTNAME"
                       CssClass="Label" ErrorMessage="Mother's first name - Only alphabet is allowed"
                       ForeColor="White" ValidationExpression="([a-z]|[A-Z]|[-']|\s){1,30}">*</asp:RegularExpressionValidator>
                 <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="FATHERMIDDLENAME"
                       CssClass="Label" ErrorMessage="Father's middle name - Only alphabet is allowed"
                       ForeColor="White" ValidationExpression="([a-z]|[A-Z]|[-']|\s){1,30}">*</asp:RegularExpressionValidator></td>
         </tr>
         <tr runat="server" id="Tr6">
             <td style="width: 6px">
             </td>
             <td  valign="top">
                 <asp:Label ID="Label18" runat="server" CssClass="Label" Text="2." Width="12px"></asp:Label></td>
             <td  valign="top" style="width: 216px">
                 <asp:TextBox ID="DEPENDANTNAME2" runat="server" MaxLength="20" TabIndex="27" Width="200px"></asp:TextBox></td>
             <td valign="top" colspan="2">
                 <asp:TextBox ID="RELATIONSHIP2" runat="server" MaxLength="20" TabIndex="28" Width="200px"></asp:TextBox></td>
         </tr>
         <tr runat="server" id="Tr7">
             <td style="width: 6px">
             </td>
             <td  valign="top">
                 <asp:Label ID="Label19" runat="server" CssClass="Label" Text="3." Width="12px"></asp:Label></td>
             <td  valign="top" style="width: 216px">
                 <asp:TextBox ID="DEPENDANTNAME3" runat="server" MaxLength="20" TabIndex="29" Width="200px"></asp:TextBox></td>
             <td valign="top" colspan="2">
                 <asp:TextBox ID="RELATIONSHIP3" runat="server" MaxLength="20" TabIndex="30" Width="200px"></asp:TextBox></td>
         </tr>
         <tr runat="server" id="Tr8">
             <td style="width: 6px">
             </td>
             <td style="width: 2px" valign="top">
                 <asp:Label ID="Label20" runat="server" CssClass="Label" Text="4." Width="12px"></asp:Label></td>
             <td valign="top" style="width: 216px">
                 <asp:TextBox ID="DEPENDANTNAME4" runat="server" MaxLength="20" TabIndex="31" Width="200px"></asp:TextBox></td>
             <td valign="top" colspan="2">
                 <asp:TextBox ID="RELATIONSHIP4" runat="server" MaxLength="20" TabIndex="32" Width="200px"></asp:TextBox></td>
         </tr>
            <tr id="Tr9" runat="server">
                <td style="width: 6px">
                </td>
                <td style="width: 2px" valign="top">
                    <asp:Label ID="Label21" runat="server" CssClass="Label" Text="5." Width="12px"></asp:Label></td>
                <td  valign="top" style="width: 216px">
                    <asp:TextBox ID="DEPENDANTNAME5" runat="server" MaxLength="20" TabIndex="23" Width="200px" AutoCompleteType="Disabled"></asp:TextBox></td>
                <td colspan="2" valign="top">
                    <asp:TextBox ID="RELATIONSHIP5" runat="server" MaxLength="20" TabIndex="23" Width="200px"></asp:TextBox></td>
            </tr>
            <tr id="Tr13" runat="server">
                <td style="width: 6px">
                </td>
                <td colspan="2" valign="top">
                    </td>
                <td colspan="2" valign="top" style="width: 173px">
                    </td>
            </tr>
            <tr id="Tr12" runat="server">
                <td style="width: 6px">
                </td>
                <td colspan="2" valign="top">
                </td>
                <td colspan="2" style="width: 173px" valign="top">
                </td>
            </tr>
    </table>
<table border="0" cellpadding="0" cellspacing="0" width="95%">
    <tr>
    <td style="width:4px"></td>
    
    <td> &nbsp;&nbsp;<asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="Label" ShowMessageBox="True"
                    ShowSummary="False" Width="236px" />
    <asp:Label ID="lblError" runat="server" CssClass="Label" ForeColor="Red" Visible="False" Width="304px">* Please take note that every field must be filled.</asp:Label>
    </td>
    
    
    </tr>
    <tr>
    <td style="width:4px">
   </td>    
    <td> &nbsp;&nbsp;<asp:Button ID="btnBack" runat="server" Text="Back" 
                            CausesValidation="false" OnClick="btnBack_Click" />&nbsp;<asp:Button ID="btnSave" runat="server" Width="96px" CssClass="Button" Text="Save &amp; Next" OnClick="btnSave_Click" TabIndex="29" ></asp:Button>&nbsp;
                           
                         </td>
    </tr>
    
    </table>

 <asp:HiddenField ID="txtCompName" runat="server" />  
 <script type="text/javascript">
 GetPcName();
ShowOtherVisitPurpose();
function Clear(datetxtbox)
{   
   var txtname = "ctl00_Content_"+datetxtbox;
   document.getElementById(txtname).value = "";
}
function CalPick(txtbox, status, text)
{
    
     var winObj = null; 
     winObj =  calendarPicker(txtbox, status, text)
     winObj.focus();
}
function DOBClick()
{     
     var winObj = null; 
     winObj = birthdayCalendarPicker("SPOUSEDOB","","N")
     winObj.focus();   
}
function ShowOtherVisitPurpose()
{
    if(document.getElementById("ctl00_Content_VISITPURPOSE").value == "15")   
         document.getElementById("ctl00_Content_OTHERVISITPURPOSE").style.display = "";    
    else
    {
         document.getElementById("ctl00_Content_OTHERVISITPURPOSE").style.display = "None"; 
         document.getElementById("ctl00_Content_OTHERVISITPURPOSE").value = "";
    }
      
}
 </script>

</asp:Content>