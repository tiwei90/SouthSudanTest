<%@ Page MasterPageFile="~/iden.master" Language="C#" AutoEventWireup="true" Inherits="EnrollmentIssuanceSite.ApplicationPart5" Codebehind="ApplicationPart5.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
<asp:Panel ID="Panel1" runat="server" Height="28px" BackImageUrl="./images/bg.gif"
        Width="100%"><asp:Label ID="fly" runat="server" Height="16px" CssClass="HeaderMainTitle" ForeColor="DimGray" BackColor="Transparent" Width="353px" >Visa - Additional Details</asp:Label></asp:Panel>
          <input id="IsNew" type="hidden" runat="server" />
          
           <table style="width: 98%" border="0" cellpadding="0" cellspacing="2" id="tbTravelWP" runat="server" >
        
        <tr>
            <td style="width: 8px" >
            </td>
            <td colspan="4" style="height: 19px; background-color: #c6efef;">
                <asp:Label ID="Label14" runat="server" CssClass="LabelHeadGreen" Text="Additional Details"></asp:Label></td>
        </tr>
           <tr>
            <td style=" width: 8px;">
            </td>
            <td style=" width: 185px;">
                <asp:Label ID="Label1" runat="server" CssClass="Label" Text="Applicant has visited the country"
                     Width="140px"></asp:Label></td>
            <td style=" width: 210px;">
                 <asp:RadioButtonList ID="VISITEDBHSIND" runat="server" CssClass="Label" RepeatDirection="Horizontal" TabIndex="1">
                     <asp:ListItem Value="1">Yes</asp:ListItem>
                     <asp:ListItem Value="0" Selected="True">No</asp:ListItem>
                 </asp:RadioButtonList></td>
            <td style=" width: 171px;">
                 <asp:Label ID="Label3" runat="server" CssClass="Label" Text="Applicant has applied for Visa before?"
                     Width="141px"></asp:Label></td>
            <td >
                 <asp:RadioButtonList ID="APPLIEDVISAIND" runat="server" CssClass="Label"  RepeatDirection="Horizontal" TabIndex="4">
                     <asp:ListItem Value="1">Yes</asp:ListItem>
                     <asp:ListItem Value="0" Selected="True">No</asp:ListItem>
                 </asp:RadioButtonList></td>
        </tr>
           <tr>
               <td style="width: 8px;">
               </td>
               <td style="width: 185px; ">
             <asp:Label ID="Label2" runat="server" CssClass="Label" Text="Date of Last Visit"
                 Width="107px"></asp:Label></td>
               <td style="width: 210px; ">
             <asp:TextBox ID="LASTVISITDATE" runat="server" MaxLength="25" ReadOnly="True" Width="126px"></asp:TextBox><asp:ImageButton
                 ID="ImageButton5" runat="server" CausesValidation="False" ImageUrl="~/images/button.gif"
                 OnClientClick="CalPick('LASTVISITDATE','B','Last visit date');return false;" TabIndex="2" /><img
                     id="Img5" runat="server" alt="" onclick="Clear('LASTVISITDATE');return false;" src="images/icon_clear.gif"
                     style="cursor: hand" /></td>
               <td style="width: 171px; height: 24px">
             <asp:Label ID="Label4" runat="server" CssClass="Label" Text="When?" Width="107px"></asp:Label></td>
               <td >
             <asp:TextBox ID="APPLIEDVISADATE" runat="server" MaxLength="25" ReadOnly="True" Width="115px"></asp:TextBox><asp:ImageButton
                 ID="ImageButton1" runat="server" CausesValidation="False" ImageUrl="~/images/button.gif"
                 OnClientClick="CalPick('APPLIEDVISADATE','B','Visa applied date');return false;" TabIndex="5" /><img
                     id="Img1" runat="server" alt="" onclick="Clear('APPLIEDVISADATE');return false;" src="images/icon_clear.gif"
                     style="cursor: hand" /></td>
           </tr>
           <tr>
               <td style="width: 8px;">
               </td>
               <td style="width: 185px; ">
             <asp:Label ID="Label7" runat="server" CssClass="Label" Text="Applicant has been deported, remanded or required to leave the country"
                 Width="163px"></asp:Label></td>
               <td style="width: 210px; height: 24px">
             <asp:RadioButtonList ID="DEPORTEDIND" runat="server" CssClass="Label" RepeatDirection="Horizontal" TabIndex="3">
                 <asp:ListItem Value="1">Yes</asp:ListItem>
                 <asp:ListItem Value="0" Selected="True">No</asp:ListItem>
             </asp:RadioButtonList></td>
               <td style="width: 171px; height: 24px">
             <asp:Label ID="Label5" runat="server" CssClass="Label" Text="Where?" Width="107px"></asp:Label></td>
               <td style="height: 24px">
             <asp:TextBox ID="APPLIEDVISAPLACE" runat="server" MaxLength="200" TabIndex="6" Width="179px"></asp:TextBox></td>
           </tr>
           <tr>
               <td style="width: 8px;">
               </td>
               <td style="width: 185px; ">
               </td>
               <td style="width: 210px;">
               </td>
               <td style="width: 171px; ">
             <asp:Label ID="Label6" runat="server" CssClass="Label" Text="Application outcome"
                 Width="130px"></asp:Label></td>
               <td style="height: 24px">
             <asp:RadioButtonList ID="VISAOUTCOME" runat="server" CssClass="Label" RepeatDirection="Horizontal" TabIndex="7">
                 <asp:ListItem Value="1">Visa Granted</asp:ListItem>
                 <asp:ListItem Value="0">Visa Denied</asp:ListItem>
             </asp:RadioButtonList></td>
           </tr>
        <tr>
            <td style="width: 8px">
            </td>
            <td colspan="2" >
                &nbsp;<asp:Label ID="Label17" runat="server" CssClass="Label" Text="Persons in the country:"
                    Width="154px"></asp:Label></td>
            <td style="width: 171px" >
            </td>
            <td >
            </td>
        </tr>
               <tr>
                   <td style="width: 8px">
                   </td>
                   <td style="width: 185px">
                   </td>
                   <td style="width: 210px">
                   </td>
                   <td style="width: 171px">
                   </td>
                   <td>
                   </td>
               </tr>
               <tr>
                   <td style="width: 8px">
                   </td>
                   <td style="width: 185px">
                             <asp:Label ID="Label15" runat="server" CssClass="LabelHeadLine" Text="Relative"></asp:Label></td>
                   <td style="width: 210px">
                <asp:Label ID="Label16" runat="server" CssClass="LabelHeadLine" Text="Residential Status" Width="122px"></asp:Label></td>
                   <td style="width: 171px">
                   </td>
                   <td>
                   </td>
               </tr>
               <tr>
                   <td style="width: 8px">
                   </td>
                   <td style="width: 185px">
                <asp:CheckBox ID="FATHERINBHSIND" runat="server" CssClass="Label" Text="Father" TabIndex="8" /></td>
                   <td style="width: 210px">
                <asp:DropDownList ID="FATHERRESIDENTIALSTATUS" runat="server" TabIndex="9">
                </asp:DropDownList><asp:CustomValidator ID="CustomValidator1" runat="server" ClientValidationFunction="CheckFather"
                    ControlToValidate="FATHERRESIDENTIALSTATUS" ErrorMessage="Person in the country: Father - Please ensure that both Father and Residential Status are selected"
                    ForeColor="White" ValidateEmptyText="True">*</asp:CustomValidator></td>
                   <td style="width: 171px">
                   </td>
                   <td>
                   </td>
               </tr>
               <tr>
                   <td style="width: 8px">
                   </td>
                   <td style="width: 185px">
                             <asp:CheckBox ID="MOTHERINBHSIND" runat="server" CssClass="Label" Text="Mother" TabIndex="10" /></td>
                   <td style="width: 210px">
                             <asp:DropDownList ID="MOTHERRESIDENTIALSTATUS" runat="server" TabIndex="11">
            </asp:DropDownList><asp:CustomValidator ID="CustomValidator5" runat="server" ClientValidationFunction="CheckMother"
                    ControlToValidate="MOTHERRESIDENTIALSTATUS" ErrorMessage="Person in the country: Mother - Please ensure that both Mother and Residential Status are selected"
                    ForeColor="White" ValidateEmptyText="True">*</asp:CustomValidator></td>
                   <td style="width: 171px">
                   </td>
                   <td>
                   </td>
               </tr>
        <tr>
            <td style=" width: 8px; height: 22px;">
            </td>
            <td style=" width: 185px; height: 22px;">
                 <asp:CheckBox ID="SPOUSEINBHSIND" runat="server" CssClass="Label" Text="Spouse" TabIndex="12" /></td>
            <td style=" width: 210px; height: 22px;">
                 <asp:DropDownList ID="SPOUSERESIDENTIALSTATUS" runat="server" TabIndex="13">
                 </asp:DropDownList><asp:CustomValidator ID="CustomValidator2" runat="server" ClientValidationFunction="CheckSpouse"
                     ControlToValidate="SPOUSERESIDENTIALSTATUS" ErrorMessage="Person in the country: Spouse - Please ensure that both Spouse and Residential Status are selected"
                     ForeColor="White" ValidateEmptyText="True">*</asp:CustomValidator></td>
            <td style=" width: 171px; height: 22px;">
                </td>
            <td style="height: 22px">
                </td>
        </tr>
               <tr>
                   <td style="width: 8px">
                   </td>
                   <td style="width: 185px">
                 <asp:CheckBox ID="SIBLINGINBHSIND" runat="server" CssClass="Label" Text="Sibling(s)" Width="80px" TabIndex="14" /></td>
                   <td style="width: 210px">
                 <asp:DropDownList ID="SIBLINGRESIDENTIALSTATUS" runat="server" TabIndex="15">
                 </asp:DropDownList><asp:CustomValidator ID="CustomValidator3" runat="server" ClientValidationFunction="CheckSibling"
                     ControlToValidate="SIBLINGRESIDENTIALSTATUS" ErrorMessage="Person in the country: Sibling(s) - Please ensure that both Sibling(s) and Residential Status are selected"
                     ForeColor="White" ValidateEmptyText="True">*</asp:CustomValidator></td>
                   <td style="width: 171px">
                   </td>
                   <td>
                   </td>
               </tr>
               <tr>
                   <td style="width: 8px">
                   </td>
                   <td style="width: 185px">
                 <asp:CheckBox ID="CHILDRENINBHSIND" runat="server" CssClass="Label" Text="Children" TabIndex="16" /></td>
                   <td style="width: 210px">
                 <asp:DropDownList ID="CHILDRENRESIDENTIALSTATUS" runat="server" TabIndex="17">
                 </asp:DropDownList><asp:CustomValidator ID="CustomValidator4" runat="server" ClientValidationFunction="CheckChild"
                     ControlToValidate="CHILDRENRESIDENTIALSTATUS" ErrorMessage="Person in the country: Children - Please ensure that both Children and Residential Status are selected"
                     ForeColor="White" ValidateEmptyText="True">*</asp:CustomValidator></td>
                   <td style="width: 171px">
                   </td>
                   <td>
                   </td>
               </tr>
               <tr>
                   <td style="width: 8px; ">
                   </td>
                   <td style="width: 185px;">
                   </td>
                   <td style="width: 210px;">
                   </td>
                   <td style="width: 171px;">
                   </td>
                   <td >
                   </td>
               </tr>
               <tr>
                   <td style="width: 8px; ">
                   </td>
                   <td style="width: 185px;">
                   </td>
                   <td style="width: 210px;">
                   </td>
                   <td style="width: 171px;">
                   </td>
                   <td >
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

function CheckFather(source, args)
{   
    var fatherstatus = document.getElementById("ctl00_Content_FATHERRESIDENTIALSTATUS").value;
    if(document.getElementById("ctl00_Content_FATHERINBHSIND").checked && fatherstatus != "6")
        args.IsValid = true; 
    else if((!document.getElementById("ctl00_Content_FATHERINBHSIND").checked) && fatherstatus == "6")
        args.IsValid = true; 
    else 
        args.IsValid = false;    
}
function CheckMother(source, args)
{   
    var status = document.getElementById("ctl00_Content_MOTHERRESIDENTIALSTATUS").value;
    if(document.getElementById("ctl00_Content_MOTHERINBHSIND").checked && status != "6")
        args.IsValid = true; 
    else if((!document.getElementById("ctl00_Content_MOTHERINBHSIND").checked) && status == "6")
        args.IsValid = true; 
    else 
        args.IsValid = false;    
}
function CheckSpouse(source, args)
{   
    var spousestatus = document.getElementById("ctl00_Content_SPOUSERESIDENTIALSTATUS").value;
    if(document.getElementById("ctl00_Content_SPOUSEINBHSIND").checked && spousestatus != "6")
        args.IsValid = true; 
    else if((!document.getElementById("ctl00_Content_SPOUSEINBHSIND").checked) && spousestatus == "6")
        args.IsValid = true; 
    else 
        args.IsValid = false;    
}
function CheckSibling(source, args)
{   
    var status = document.getElementById("ctl00_Content_SIBLINGRESIDENTIALSTATUS").value;
    if(document.getElementById("ctl00_Content_SIBLINGINBHSIND").checked && status != "6")
        args.IsValid = true; 
    else if((!document.getElementById("ctl00_Content_SIBLINGINBHSIND").checked) && status == "6")
        args.IsValid = true; 
    else 
        args.IsValid = false;    
}
function CheckChild(source, args)
{   
    var status = document.getElementById("ctl00_Content_CHILDRENRESIDENTIALSTATUS").value;
    if(document.getElementById("ctl00_Content_CHILDRENINBHSIND").checked && status != "6")
        args.IsValid = true; 
    else if((!document.getElementById("ctl00_Content_CHILDRENINBHSIND").checked) && status == "6")
        args.IsValid = true; 
    else 
        args.IsValid = false;    
}
 GetPcName();
</script>
</asp:Content>