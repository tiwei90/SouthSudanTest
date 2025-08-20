<%@ Page MasterPageFile="~/iden.master" Language="C#" AutoEventWireup="true" Inherits="EnrollmentIssuanceSite.ApplicationPart4" Codebehind="ApplicationPart4.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
<asp:Panel ID="Panel1" runat="server" Height="28px" BackImageUrl="./images/bg.gif"
        Width="100%"><asp:Label ID="fly" runat="server" Height="16px" CssClass="HeaderMainTitle" ForeColor="DimGray" BackColor="Transparent" Width="353px" >Visa - Financial & Criminal Details</asp:Label></asp:Panel>
          <input id="IsNew" type="hidden" runat="server" />
<table style="width: 98%" border="0" cellpadding="0" cellspacing="2"  runat="server" >
        
        <tr>
            <td style="width: 6px" >
            </td>
            <td colspan="4" style="height: 19px; background-color: #c6efef;">
                <asp:Label ID="Label23" runat="server" CssClass="LabelHeadGreen" Text="Financial Details"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 6px">
            </td>
            <td style="width: 138px">
            </td>
            <td style="width: 191px">
            </td>
            <td style="width: 103px">
            </td>
            <td style="width: 203px">
            </td>
        </tr>
        <tr>
            <td style="width: 6px; height: 24px;">
            </td>
            <td style="height: 24px;" colspan="2">
                <asp:Label ID="Label24" runat="server" CssClass="Label" Text="Trip to the country is sponsored by :" Width="278px"></asp:Label>
                </td>
            <td colspan="2" style="height: 24px">
                <asp:Label ID="Label6" runat="server" CssClass="Label" Text="How much money is available for stay?"
                    Width="272px"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 6px">
            </td>
            <td colspan="2">
                <asp:TextBox ID="TRIPSPONSORBY" runat="server" MaxLength="100" TabIndex="1" Width="273px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator15" runat="server"
                    ControlToValidate="TRIPSPONSORBY" CssClass="Label" ErrorMessage=" Sponsored by - Some special characters are NOT allowed"
                    ForeColor="White" ValidationExpression="([A-Z]|[a-z]|[-@#/.,&quot;':\]|[0-9]|\s){1,100}">*</asp:RegularExpressionValidator></td>
            <td colspan="2">
                <asp:TextBox ID="TRIPMONEY" runat="server" MaxLength="100" TabIndex="2" Width="273px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TRIPMONEY"
                    CssClass="Label" ErrorMessage=" Money available for stay - Some special characters are NOT allowed"
                    ForeColor="White" ValidationExpression="([A-Z]|[a-z]|[$-@#/.,&quot;':\]|[0-9]|\s){1,100}">*</asp:RegularExpressionValidator></td>
        </tr>
      
    </table>
    
    <table style="width: 98%" border="0" cellpadding="0" cellspacing="2" id="Table1" runat="server" >
        
        <tr>
            <td style="width: 6px" >
            </td>
            <td colspan="4" style="height: 19px; background-color: #c6efef;">
                <asp:Label ID="Label1" runat="server" CssClass="LabelHeadGreen" Text="Criminal Details"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 6px">
            </td>
            <td style="width: 138px">
            </td>
            <td style="width: 191px">
            </td>
            <td style="width: 103px">
            </td>
            <td style="width: 203px">
            </td>
        </tr>
        <tr>
            <td style="width: 6px; height: 24px;">
            </td>
            <td style="width: 138px; height: 24px;">
                <asp:Label ID="Label2" runat="server" CssClass="Label" Text="Crimes Convicted?" Width="119px"></asp:Label>
                </td>
            <td style="width: 191px; height: 24px;">
                <asp:RadioButtonList ID="CRIMINALCONVICTIONIND" runat="server" CssClass="Label" RepeatDirection="Horizontal" OnClick="return ShowOffense();"  TabIndex="3">
                    <asp:ListItem Value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="0" Selected="True">No</asp:ListItem>
                </asp:RadioButtonList></td>
            <td style="width: 103px; height: 24px;">
                </td>
            <td style="width: 203px; height: 24px;">
                </td>
        </tr>
    </table>
     <table id="tbOffense" cellpadding="0" cellspacing="2" border="0" runat="server" width="98%">
        <tr>
            <td style="width: 8px; height: 10px">
            </td>
            <td colspan="6" style="height: 10px">
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="OFFENCEPLACE1"
                    CssClass="Label" ErrorMessage="Offense place 1 - Some special characters are NOT allowed"
                    ForeColor="White" ValidationExpression="([A-Z]|[a-z]|[-@#/.,&quot;':\]|[0-9]|\s){1,20}">*</asp:RegularExpressionValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="OFFENCEPLACE2"
                    CssClass="Label" ErrorMessage="Offense place 2 - Some special characters are NOT allowed"
                    ForeColor="White" ValidationExpression="([A-Z]|[a-z]|[-@#/.,&quot;':\]|[0-9]|\s){1,20}">*</asp:RegularExpressionValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="OFFENCEPLACE3"
                    CssClass="Label" ErrorMessage="Offense place 3 - Some special characters are NOT allowed"
                    ForeColor="White" ValidationExpression="([A-Z]|[a-z]|[-@#/.,&quot;':\]|[0-9]|\s){1,20}">*</asp:RegularExpressionValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="OFFENCEPLACE4"
                    CssClass="Label" ErrorMessage="Offense place 4 - Some special characters are NOT allowed"
                    ForeColor="White" ValidationExpression="([A-Z]|[a-z]|[-@#/.,&quot;':\]|[0-9]|\s){1,20}">*</asp:RegularExpressionValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="OFFENCEPLACE5"
                    CssClass="Label" ErrorMessage="Offense place 5 - Some special characters are NOT allowed"
                    ForeColor="White" ValidationExpression="([A-Z]|[a-z]|[-@#/.,&quot;':\]|[0-9]|\s){1,20}">*</asp:RegularExpressionValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="OFFENCE1"
                    CssClass="Label" ErrorMessage="Description of offense 1 - Some special characters are NOT allowed"
                    ForeColor="White" ValidationExpression="([A-Z]|[a-z]|[-@#/.,&quot;':\]|[0-9]|\s){1,200}">*</asp:RegularExpressionValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ControlToValidate="OFFENCE2"
                    CssClass="Label" ErrorMessage="Description of offense 2 - Some special characters are NOT allowed"
                    ForeColor="White" ValidationExpression="([A-Z]|[a-z]|[-@#/.,&quot;':\]|[0-9]|\s){1,200}">*</asp:RegularExpressionValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" ControlToValidate="OFFENCE3"
                    CssClass="Label" ErrorMessage="Description of offense 3 - Some special characters are NOT allowed"
                    ForeColor="White" ValidationExpression="([A-Z]|[a-z]|[-@#/.,&quot;':\]|[0-9]|\s){1,200}">*</asp:RegularExpressionValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator10" runat="server"
                    ControlToValidate="OFFENCE4" CssClass="Label" ErrorMessage="Description of offense 4 - Some special characters are NOT allowed"
                    ForeColor="White" ValidationExpression="([A-Z]|[a-z]|[-@#/.,&quot;':\]|[0-9]|\s){1,200}">*</asp:RegularExpressionValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator11" runat="server"
                    ControlToValidate="OFFENCE5" CssClass="Label" ErrorMessage="Description of offense 5 - Some special characters are NOT allowed"
                    ForeColor="White" ValidationExpression="([A-Z]|[a-z]|[-@#/.,&quot;':\]|[0-9]|\s){1,200}">*</asp:RegularExpressionValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator12" runat="server"
                    ControlToValidate="OFFENCEPENALTY1" CssClass="Label" ErrorMessage="Penalty 1 - Some special characters are NOT allowed"
                    ForeColor="White" ValidationExpression="([A-Z]|[a-z]|[-@#/.,&quot;':\]|[0-9]|\s){1,20}">*</asp:RegularExpressionValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator13" runat="server"
                    ControlToValidate="OFFENCEPENALTY2" CssClass="Label" ErrorMessage="Penalty 2 - Some special characters are NOT allowed"
                    ForeColor="White" ValidationExpression="([A-Z]|[a-z]|[-@#/.,&quot;':\]|[0-9]|\s){1,20}">*</asp:RegularExpressionValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator14" runat="server"
                    ControlToValidate="OFFENCEPENALTY3" CssClass="Label" ErrorMessage="Penalty 3 - Some special characters are NOT allowed"
                    ForeColor="White" ValidationExpression="([A-Z]|[a-z]|[-@#/.,&quot;':\]|[0-9]|\s){1,20}">*</asp:RegularExpressionValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator16" runat="server"
                    ControlToValidate="OFFENCEPENALTY4" CssClass="Label" ErrorMessage="Penalty 4 - Some special characters are NOT allowed"
                    ForeColor="White" ValidationExpression="([A-Z]|[a-z]|[-@#/.,&quot;':\]|[0-9]|\s){1,20}">*</asp:RegularExpressionValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator17" runat="server"
                    ControlToValidate="OFFENCEPENALTY5" CssClass="Label" ErrorMessage="Penalty 5 - Some special characters are NOT allowed"
                    ForeColor="White" ValidationExpression="([A-Z]|[a-z]|[-@#/.,&quot;':\]|[0-9]|\s){1,20}">*</asp:RegularExpressionValidator></td>
        </tr>
        <tr>
            <td style="width: 8px; height: 18px" align="left">
            </td>
            <td style="height: 18px" align="left">
            </td>
            <td style="height: 18px; width: 140px;" align="left">
                <asp:Label ID="Label9" runat="server" CssClass="LabelHeadLine" Text="Date of Offence"></asp:Label></td>
            <td style="height: 18px; width: 137px;" align="left">
                <asp:Label ID="Label10" runat="server" CssClass="LabelHeadLine" Text="Place of Offence"></asp:Label></td>
             <td style="height: 18px; width: 180px;" align="left">
                <asp:Label ID="lblPOB" runat="server" CssClass="LabelHeadLine" Text="Description of Offence"></asp:Label></td>
             <td style="height: 18px" align="left">
                <asp:Label ID="Label11" runat="server" CssClass="LabelHeadLine" Text="Penalty"></asp:Label></td>
           
           
        </tr>
        <tr>
            <td style="width: 8px">
            </td>
            <td>
                <asp:Label ID="Label7" runat="server" CssClass="Label" Text="1."></asp:Label></td>
            <td style="width: 140px">
                <asp:TextBox ID="OFFENCEDATE1" runat="server" MaxLength="25" ReadOnly="True" Width="85px"></asp:TextBox><asp:ImageButton
                    ID="ImageButton1" OnClientClick="CalPick('OFFENCEDATE1','B','Offense Date 1');return false;" runat="server" CausesValidation="False" ImageUrl="~/images/button.gif" TabIndex="4" /><img id="Img3" runat="server" alt="" onclick="Clear('OFFENCEDATE1');return false;"
                    src="images/icon_clear.gif" style="cursor: hand" /></td>
            <td style="width: 137px">
                <asp:TextBox ID="OFFENCEPLACE1" runat="server" MaxLength="20" TabIndex="5" Width="179px"></asp:TextBox></td>
            <td style="width: 180px">
                <asp:TextBox ID="OFFENCE1" runat="server" Width="200px" MaxLength="200" TabIndex="6"></asp:TextBox></td>
            <td>
                <asp:TextBox ID="OFFENCEPENALTY1" runat="server" MaxLength="20" TabIndex="23" Width="207px"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 8px">
            </td>
            <td>
                <asp:Label ID="Label4" runat="server" CssClass="Label" Text="2."></asp:Label></td>
            <td style="width: 140px">
                <asp:TextBox ID="OFFENCEDATE2" runat="server" MaxLength="25" ReadOnly="True" Width="85px"></asp:TextBox><asp:ImageButton
                    ID="ImageButton2" OnClientClick="CalPick('OFFENCEDATE2','B','Offense Date 2');return false;" runat="server" CausesValidation="False" ImageUrl="~/images/button.gif" TabIndex="7" /><img id="Img1" runat="server" alt="" onclick="Clear('OFFENCEDATE2');return false;"
                    src="images/icon_clear.gif" style="cursor: hand" /></td>
            <td style="width: 137px">
                <asp:TextBox ID="OFFENCEPLACE2" runat="server" MaxLength="20" TabIndex="8" Width="179px"></asp:TextBox></td>
            <td style="width: 180px">
                <asp:TextBox ID="OFFENCE2" runat="server" Width="200px" MaxLength="200" TabIndex="9"></asp:TextBox></td>
            <td>
                <asp:TextBox ID="OFFENCEPENALTY2" runat="server" MaxLength="20" TabIndex="23" Width="207px"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 8px">
            </td>
            <td>
                <asp:Label ID="Label3" runat="server" CssClass="Label" Text="3."></asp:Label></td>
            <td style="width: 140px">
                <asp:TextBox ID="OFFENCEDATE3" runat="server" MaxLength="25" ReadOnly="True" Width="85px"></asp:TextBox><asp:ImageButton
                    ID="ImageButton3" OnClientClick="CalPick('OFFENCEDATE3','B','Offense Date 3');return false;" runat="server" CausesValidation="False" ImageUrl="~/images/button.gif" TabIndex="10" /><img id="Img2" runat="server" alt="" onclick="Clear('OFFENCEDATE3');return false;"
                    src="images/icon_clear.gif" style="cursor: hand" /></td>
            <td style="width: 137px">
                <asp:TextBox ID="OFFENCEPLACE3" runat="server" MaxLength="20" TabIndex="11" Width="179px"></asp:TextBox></td>
            <td style="width: 180px">
                <asp:TextBox ID="OFFENCE3" runat="server" Width="200px" MaxLength="200" TabIndex="12"></asp:TextBox></td>
            <td>
                <asp:TextBox ID="OFFENCEPENALTY3" runat="server" MaxLength="20" TabIndex="23" Width="207px"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 8px">
            </td>
            <td>
                <asp:Label ID="Label5" runat="server" CssClass="Label" Text="4."></asp:Label></td>
            <td style="width: 140px">
                <asp:TextBox ID="OFFENCEDATE4" runat="server" MaxLength="25" ReadOnly="True" Width="85px"></asp:TextBox><asp:ImageButton
                    ID="ImageButton4" OnClientClick="CalPick('OFFENCEDATE4','B','Offense Date 4');return false;" runat="server" CausesValidation="False" ImageUrl="~/images/button.gif" TabIndex="13" /><img id="Img4" runat="server" alt="" onclick="Clear('OFFENCEDATE4');return false;"
                    src="images/icon_clear.gif" style="cursor: hand" /></td>
            <td style="width: 137px">
                <asp:TextBox ID="OFFENCEPLACE4" runat="server" MaxLength="20" TabIndex="14" Width="179px"></asp:TextBox></td>
            <td style="width: 180px">
                <asp:TextBox ID="OFFENCE4" runat="server" Width="200px" MaxLength="200" TabIndex="15"></asp:TextBox></td>
            <td>
                <asp:TextBox ID="OFFENCEPENALTY4" runat="server" MaxLength="20" TabIndex="23" Width="207px"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 8px">
            </td>
            <td>
                <asp:Label ID="Label8" runat="server" CssClass="Label" Text="5."></asp:Label></td>
            <td style="width: 140px">
                <asp:TextBox ID="OFFENCEDATE5" runat="server" MaxLength="25" ReadOnly="True" Width="85px"></asp:TextBox><asp:ImageButton
                    ID="ImageButton5" OnClientClick="CalPick('OFFENCEDATE5','B','Offense Date 5');return false;" runat="server" CausesValidation="False" ImageUrl="~/images/button.gif" TabIndex="16" /><img id="Img5" runat="server" alt="" onclick="Clear('CHILDDOB2');return false;"
                    src="images/icon_clear.gif" style="cursor: hand" /></td>
            <td style="width: 137px">
                <asp:TextBox ID="OFFENCEPLACE5" runat="server" MaxLength="200" TabIndex="17" Width="179px"></asp:TextBox></td>
            <td style="width: 180px">
                <asp:TextBox ID="OFFENCE5" runat="server" Width="200px" MaxLength="200" TabIndex="18"></asp:TextBox></td>
            <td>
                <asp:TextBox ID="OFFENCEPENALTY5" runat="server" MaxLength="20" TabIndex="23" Width="207px"></asp:TextBox></td>
        </tr>
      </table>
     <table style="width: 98%" border="0" cellpadding="0" cellspacing="2" id="tbTerrorism" runat="server" >
        <tr>
            <td style="width: 8px">
            </td>
            <td style="width: 138px">
            </td>
            <td style="width: 191px">
            </td>
            <td style="width: 103px">
            </td>
            <td style="width: 203px">
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 24px;">
            </td>
            <td style="height: 24px;" colspan="4">
                <asp:Label ID="Label13" runat="server" CssClass="Label" Text="Has applicant ever been involved in the commission, preparation, organization or support of acts of terrorism, either within or outside of the country or has applicant ever been a member of any organization which has been involved in or advocated terrorism?" Width="740px"></asp:Label>
                </td>
        </tr>
         <tr>
             <td style="width: 8px; height: 24px">
             </td>
             <td style="width: 138px; height: 24px">
                <asp:RadioButtonList ID="TERRORISMIND" runat="server" CssClass="Label" RepeatDirection="Horizontal" OnClick="return ShowTerror();" TabIndex="19">
                    <asp:ListItem Value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="0" Selected="True">No</asp:ListItem>
                </asp:RadioButtonList></td>
             <td style="width: 191px; height: 24px">
                </td>
             <td style="width: 103px; height: 24px">
             </td>
             <td style="width: 203px; height: 24px">
             </td>
         </tr>
         <tr id="trTitleTerror">
             <td style="width: 8px; height: 24px">
             </td>
             <td style="width: 138px; height: 24px">
                 <asp:Label ID="Label12" runat="server" CssClass="Label" Text="Please provide details"
                     Width="130px"></asp:Label></td>
             <td style="width: 191px; height: 24px">
             </td>
             <td style="width: 103px; height: 24px">
             </td>
             <td style="width: 203px; height: 24px">
             </td>
         </tr>
         <tr id="trTerror">
             <td style="width: 8px; height: 24px">
             </td>
             <td colspan="3" style="height: 24px">
                 <asp:TextBox ID="TERRORISMDESC" runat="server" MaxLength="200" Rows="5" TabIndex="20"
                     TextMode="MultiLine" Width="300px" onkeypress="return textboxMultilineMaxNumber(this,200)"  onpaste="return doPaste(this,200)" CssClass="Label"></asp:TextBox>
                 <asp:RegularExpressionValidator ID="RegularExpressionValidator18" runat="server"
                     ControlToValidate="TERRORISMDESC" CssClass="Label" ErrorMessage="Details of terrorism - Some special characters are NOT allowed"
                     ForeColor="White" ValidationExpression="([A-Z]|[a-z]|[-@#/.,&quot;':\]|[0-9]|\s){1,200}">*</asp:RegularExpressionValidator></td>
             <td style="width: 203px; height: 24px">
             </td>
         </tr>
    </table>
   
    <table border="0" cellpadding="0" cellspacing="0" width="95%">
    <tr>
    <td style="width:4px"></td>
    
    <td> &nbsp;&nbsp;<asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="Label" ShowMessageBox="True"
                    ShowSummary="False" Width="236px" DisplayMode="List" />
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

ShowOffense();
ShowTerror();
function ShowOffense()
{
    var crime = get_Criminal_Ind();
    if(crime == "1")  
    {        
        document.getElementById("ctl00_Content_tbOffense").style.display = "";              
    }
    else
    {      
       document.getElementById("ctl00_Content_tbOffense").style.display = "None";        
    }  
} 
function  get_Criminal_Ind()
{
   var Criminal_val;
   for (var i=0; i < document.forms["aspnetForm"].ctl00$Content$CRIMINALCONVICTIONIND.length; i++)
   {
      if (document.forms["aspnetForm"].ctl00$Content$CRIMINALCONVICTIONIND[i].checked)
      {
        Criminal_val = document.forms["aspnetForm"].ctl00$Content$CRIMINALCONVICTIONIND[i].value;
      }
   }

   return Criminal_val;
}
function ShowTerror()
{
    var terror = get_Terror_Ind();
    if(terror == "1")  
    {        
        document.getElementById("ctl00_Content_trTerror").style.display = "";
        document.getElementById("ctl00_Content_trTitleTerror").style.display = "";                
    }
    else
    {      
       document.getElementById("ctl00_Content_trTerror").style.display = "None"; 
       document.getElementById("ctl00_Content_trTitleTerror").style.display = "None"; 
       document.getElementById("ctl00_Content_TERRORISMDESC").value = "";           
    } 
   
} 
function get_Terror_Ind()
{
   var Terror_val;
   for (var i=0; i < document.forms["aspnetForm"].ctl00$Content$TERRORISMIND.length; i++)
   {
      if (document.forms["aspnetForm"].ctl00$Content$TERRORISMIND[i].checked)
      {
         Terror_val = document.forms["aspnetForm"].ctl00$Content$TERRORISMIND[i].value;
      }
   }

   return Terror_val;
}
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
function CheckFather(source, args)
{   
    var fatherstatus = document.getElementById("ctl00_Content_FATHERRESIDENTIALSTATUS").value;
    if(document.getElementById("ctl00_Content_FATHERINBHSIND").checked && fatherstatus != "")
        args.IsValid = true; 
    else if((!document.getElementById("ctl00_Content_FATHERINBHSIND").checked) && fatherstatus == "")
        args.IsValid = true; 
    else 
        args.IsValid = false;    
}
function CheckMother(source, args)
{   
    var status = document.getElementById("ctl00_Content_MOTHERRESIDENTIALSTATUS").value;
    if(document.getElementById("ctl00_Content_MOTHERINBHSIND").checked && status != "")
        args.IsValid = true; 
    else if((!document.getElementById("ctl00_Content_MOTHERINBHSIND").checked) && status == "")
        args.IsValid = true; 
    else 
        args.IsValid = false;    
}
function CheckSpouse(source, args)
{   
    var spousestatus = document.getElementById("ctl00_Content_SPOUSERESIDENTIALSTATUS").value;
    if(document.getElementById("ctl00_Content_SPOUSEINBHSIND").checked && spousestatus != "")
        args.IsValid = true; 
    else if((!document.getElementById("ctl00_Content_SPOUSEINBHSIND").checked) && spousestatus == "")
        args.IsValid = true; 
    else 
        args.IsValid = false;    
}
function CheckSibling(source, args)
{   
    var status = document.getElementById("ctl00_Content_SIBLINGRESIDENTIALSTATUS").value;
    if(document.getElementById("ctl00_Content_SIBLINGINBHSIND").checked && status != "")
        args.IsValid = true; 
    else if((!document.getElementById("ctl00_Content_SIBLINGINBHSIND").checked) && status == "")
        args.IsValid = true; 
    else 
        args.IsValid = false;    
}
function CheckChild(source, args)
{   
    var status = document.getElementById("ctl00_Content_CHILDRENRESIDENTIALSTATUS").value;
    if(document.getElementById("ctl00_Content_CHILDRENINBHSIND").checked && status != "")
        args.IsValid = true; 
    else if((!document.getElementById("ctl00_Content_CHILDRENINBHSIND").checked) && status == "")
        args.IsValid = true; 
    else 
        args.IsValid = false;    
}
 GetPcName();
</script>
</asp:Content>