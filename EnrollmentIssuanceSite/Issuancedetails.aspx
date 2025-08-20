<%@ Page MasterPageFile="~/Iden.master" Language="C#" AutoEventWireup="true" Inherits="EnrollmentIssuanceSite.Issuancedetails" Codebehind="Issuancedetails.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
 <script type="text/javascript" src="inc/common.js"></script>
 <script type="text/javascript" src="inc/MRZ.js"></script>    
 

 
    <div style="z-index: 101; left: -122px; visibility: hidden; width: 100px; position: absolute;
        top: 429px; height: 100px">    
    <asp:TextBox ID="ImageSrc" runat="server" Width="32px" ReadOnly="true"></asp:TextBox>
    <asp:TextBox ID="PassportResult" runat="server" Width="32px" ReadOnly="true"></asp:TextBox>    
   
    </div> 
    
      
    
    <input id="APPID" type="hidden" runat="server" />  
    <input id="IDPerson" type="hidden" runat="server" />  
     
     

<asp:Panel ID="Panel1" runat="server" Height="28px" BackImageUrl="./images/bg.gif"
        Width="100%">
        <asp:Label ID="fly" runat="server" Height="16px" CssClass="HeaderMainTitle" ForeColor="DimGray" BackColor="Transparent" Width="353px" >Visa - Visa Issuance Details</asp:Label></asp:Panel>
        <input id="FORMNO" type="hidden" runat="server"/>
         
           
    <table id="tbInfo" style="width: 637px; height: 370px;" onfocus="cursor_clear();" cellspacing="0"
        cellpadding="0" border="0" runat="server">
        <tr>
            <td style="width: 36064px; height: 5">
                &nbsp;&nbsp;
            </td>
            <td style="width: 160px; height: 5px" valign="middle">
            </td>
            <td style="width: 160px; height: 5px" valign="middle">
               <asp:Label ID="Label1" runat="server" CssClass="LabelHeadBlue" Font-Size="15px">Visa Information</asp:Label></td>
            <td style="width: 39px">
            </td>
        </tr>
    <tr>
        <td style="width: 36064px; height: 10px">
        </td>
        <td style="width: 160px; height: 10px">
        </td>
        <td style="width: 160px; height: 10px">
            <asp:Label ID="lblLeftFinger" runat="server" ForeColor="White"></asp:Label><asp:Label ID="lblRightFinger" runat="server" ForeColor="White"></asp:Label></td>
        <td style="height: 10px; width: 39px;">
        </td>
    </tr>
        <tr>
            <td style="width: 36064px; height: 19px">
            </td>
            <td style="width: 160px; height: 19px">
            </td>
            <td style="width: 160px; height: 19px;">
                <table border="0" cellpadding="0" cellspacing="0" style="width: 160px">
                    <tr>
                        <td style="width: 113px; height: 17px;">
                            <asp:Label ID="Label13" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="Small"
                                Width="371px">From Database</asp:Label></td>
                        <td style="width: 160px; height: 17px;">
                            <asp:Label ID="Label14" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="Small"
                                Width="308px">From Visa </asp:Label></td>
                    </tr>
                </table>
            </td>
            <td style="height: 19px; width: 39px;">
            </td>
        </tr>
        <tr>
            <td valign="middle" style="width: 36064px; height: auto;">
            </td>
            <td colspan="1" style="width: 609px; height: auto;" valign="top">
            </td>
            <td valign="top" colspan="3" style="width: 721px; height: auto;">
               
                        <table style="width: 608px" id="table2" cellspacing="0" cellpadding="0" width="608"
                            border="0">
                            <tbody>
                                <tr>
                                    <td style="width: 616px; height: 340px;" valign="top">
                                        <table style="width: 370px" id="table4" cellspacing="0" cellpadding="0"
                                            border="0">
                                            <tbody>
                                                <tr>
                                                    <td style="width: 96px; height: 24px">
                                                        <asp:Label ID="Label17" runat="server" CssClass="LabelHeadLine" Width="80px">Photograph</asp:Label></td>
                                                    <td style="width: 164px; height: 24px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 96px; height: 87px">
                                                        <asp:Image ID="imgPhoto" runat="server" CssClass="Img" Width="69px" Height="92px"
                                                            BorderStyle="None" ImageUrl="~/images/NoImage.JPG" BorderColor="White"></asp:Image></td>
                                                    <td style="width: 164px; height: 87px">
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                        <table id="Table1" border="0" cellpadding="0" cellspacing="0" style="width: 368px">
                                            <tr>
                                                <td style="width: 126px; height: 18px">
                                                </td>
                                                <td style="width: 5px; height: 18px">
                                                </td>
                                                <td style="height: 18px; width: 213px;">
                                                    <asp:Label ID="lblEnrolLoc" runat="server" CssClass="Label" Visible="False"></asp:Label>
                                                    <asp:Label ID="lblFormNo" runat="server" CssClass="Label" Visible="False"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 126px; height: 18px">
                                                    <asp:Label ID="Label4" runat="server" CssClass="LabelHead">Document Number</asp:Label></td>
                                                <td style="width: 5px; height: 18px">
                                                    :</td>
                                                <td style="height: 18px; width: 213px;">
                                                    <asp:TextBox ID="lblDocNo" runat="server" BorderStyle="None" ReadOnly="True" CssClass="Label" BorderColor="White"></asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 126px; height: 18px">
                                                    <asp:Label ID="Label3" runat="server" CssClass="LabelHead">Document Type</asp:Label></td>
                                                <td style="height: 18px; width: 5px;">
                                                    :</td>
                                                <td style="height: 18px; width: 213px;">
                                                    <asp:TextBox ID="lblDocType" runat="server" BorderStyle="None" ReadOnly="True" CssClass="Label" Width="184px" BorderColor="White"></asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 126px; height: 19px;">
                                                    <asp:Label ID="Label6" runat="server" CssClass="LabelHead">Surname</asp:Label></td>
                                                <td style="width: 5px; height: 19px;">
                                                    <font face="Arial">:</font></td>
                                                <td style="width: 213px; height: 19px;">
                                                    <asp:TextBox ID="lblSurname" runat="server" BorderStyle="None" ReadOnly="True" CssClass="Label" Width="228px" BorderColor="White"></asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 126px; height: 18px;">
                                                    <asp:Label ID="Label7" runat="server" CssClass="LabelHead">Given Names</asp:Label></td>
                                                <td style="width: 5px; height: 18px;">
                                                    <font face="Arial">:</font></td>
                                                <td style="height: 18px; width: 213px;">
                                                    <asp:TextBox ID="lblFName" runat="server" BorderStyle="None" Width="244px" CssClass="Label" BorderColor="Black"></asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 126px; height: 17px">
                                                    <asp:Label ID="Label11" runat="server" CssClass="LabelHead">Sex</asp:Label></td>
                                                <td style="height: 17px; width: 5px;">
                                                    <font face="Arial">:</font></td>
                                                <td style="height: 17px; width: 213px;">
                                                    <asp:TextBox ID="lblSex" runat="server" BorderStyle="None" ReadOnly="True" CssClass="Label" BorderColor="White"></asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 126px; height: 19px;">
                                                    <asp:Label ID="Label10" runat="server" CssClass="LabelHead">Date of Birth</asp:Label></td>
                                                <td style="width: 5px; height: 19px;">
                                                    <font face="Arial">:</font></td>
                                                <td style="width: 213px; height: 19px;">
                                                    <asp:TextBox ID="lblDOB" runat="server" BorderStyle="None" ReadOnly="True" CssClass="Label" BorderColor="White"></asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 126px; height: 20px;">
                                                    <asp:Label ID="Label9" runat="server" CssClass="LabelHead">Nationality</asp:Label></td>
                                                <td style="width: 5px; height: 20px;">
                                                    <font face="Arial">:</font></td>
                                                <td style="width: 213px; height: 20px;">
                                                    <asp:TextBox ID="lblNationality" runat="server" BorderStyle="None" ReadOnly="True" CssClass="Label" BorderColor="White"></asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 126px; height: 19px">
                                                    <asp:Label ID="Label5" runat="server" CssClass="LabelHead">Passport No</asp:Label></td>
                                                <td style="height: 19px; width: 5px;">
                                                    <font face="Arial">:</font></td>
                                                <td style="height: 19px; width: 213px;">
                                                    <asp:TextBox ID="lblPersonalNo" runat="server" BorderStyle="None" ReadOnly="True" CssClass="Label" BorderColor="White"></asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 126px; height: 19px">
                                                    <asp:Label ID="Label12" runat="server" CssClass="LabelHead">Date of Expiry</asp:Label></td>
                                                <td style="width: 5px; height: 19px">
                                                    :</td>
                                                <td style="width: 213px; height: 19px">
                                                    <asp:TextBox ID="lblDOE" runat="server" BorderStyle="None" ReadOnly="True" CssClass="Label" BorderColor="White"></asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 126px; height: 19px">
                                                </td>
                                                <td style="width: 5px; height: 19px">
                                                </td>
                                                <td style="width: 213px; height: 19px">
                                                    </td>
                                            </tr>
                                        </table>
                                                    </td>
                                    <td style="width: 342px; height: 340px;" valign="top" align="left">
                                        <table style="width: 259px" id="table6" cellspacing="0" cellpadding="0" width="259"
                                            border="0">
                                            <tbody>
                                                <tr>
                                                    <td style="width: 96px; height: 24px">
                                                        </td>
                                                    <td style="width: 164px; height: 24px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 96px; height: 77px">
                                                    <asp:Image ID="Image1" runat="server" CssClass="Img" Width="69px" Height="92px"
                                                            BorderStyle="None" ImageUrl="~/images/spacer.gif" BorderColor="White"></asp:Image></td>
                                                    <td style="width: 164px; height: 77px">
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                        <table id="Table8" border="0" cellpadding="0" cellspacing="0" width="300">
                                            <tr>
                                                <td style="width: 126px; height: 18px">
                                                </td>
                                                <td style="width: 5px; height: 18px">
                                                </td>
                                                <td style="height: 18px">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 126px; height: 18px">
                                                    <asp:Label ID="Label30" runat="server" CssClass="LabelHead">Document Number</asp:Label></td>
                                                <td style="width: 5px; height: 18px">
                                                    :</td>
                                                <td style="height: 18px">
                                                    <asp:TextBox ID="lblDocNo2" runat="server" BorderStyle="None" ReadOnly="True" CssClass="Label" BorderColor="White"></asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 126px; height: 18px">
                                                    <asp:Label ID="Label19" runat="server" CssClass="LabelHead">Document Type</asp:Label></td>
                                                <td style="height: 18px; width: 5px;">
                                                    :</td>
                                                <td style="height: 18px">
                                                    <asp:TextBox ID="lblDocType2" runat="server" BorderStyle="None" ReadOnly="True" Width="236px" CssClass="Label" BorderColor="White"></asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 126px">
                                                    <asp:Label ID="Label41" runat="server" CssClass="LabelHead">Surname</asp:Label></td>
                                                <td style="width: 5px">
                                                    <font face="Arial">:</font></td>
                                                <td>
                                                    <asp:TextBox ID="lblSurname2" runat="server" BorderStyle="None" ReadOnly="True" Width="244px" CssClass="Label" BorderColor="White"></asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 126px">
                                                    <asp:Label ID="Label44" runat="server" CssClass="LabelHead">Given Names</asp:Label></td>
                                                <td style="width: 5px">
                                                    <font face="Arial">:</font></td>
                                                <td>
                                                    <asp:TextBox ID="lblFName2" runat="server" BorderStyle="None" ReadOnly="True" Width="242px" CssClass="Label" BorderColor="White"></asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 126px; height: 17px">
                                                    <asp:Label ID="Label50" runat="server" CssClass="LabelHead">Sex</asp:Label></td>
                                                <td style="height: 17px; width: 5px;">
                                                    <font face="Arial">:</font></td>
                                                <td style="height: 17px">
                                                    <asp:TextBox ID="lblSex2" runat="server" BorderStyle="None" ReadOnly="True" CssClass="Label" BorderColor="White"></asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 126px; height: 19px;">
                                                    <asp:Label ID="Label52" runat="server" CssClass="LabelHead">Date of Birth</asp:Label></td>
                                                <td style="width: 5px; height: 19px;">
                                                    <font face="Arial">:</font></td>
                                                <td style="height: 19px">
                                                    <asp:TextBox ID="lblDOB2" runat="server" BorderStyle="None" ReadOnly="True" CssClass="Label" BorderColor="White"></asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 126px; height: 19px;">
                                                    <asp:Label ID="Label56" runat="server" CssClass="LabelHead">Nationality</asp:Label></td>
                                                <td style="width: 5px; height: 19px;">
                                                    <font face="Arial">:</font></td>
                                                <td style="height: 19px">
                                                    <asp:TextBox ID="lblNationality2" runat="server" BorderStyle="None" ReadOnly="True" CssClass="Label" BorderColor="White"></asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 126px; height: 19px">
                                                    <asp:Label ID="Label8" runat="server" CssClass="LabelHead" Width="125px">Passport No</asp:Label></td>
                                                <td style="height: 19px; width: 5px;">
                                                    <font face="Arial">:</font></td>
                                                <td style="height: 19px">
                                                    <asp:TextBox ID="lblPersonalNo2" runat="server" BorderStyle="None" ReadOnly="True" CssClass="Label" BorderColor="White"></asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 126px; height: 19px">
                                                    <asp:Label ID="Label58" runat="server" CssClass="LabelHead">Date of Expiry</asp:Label></td>
                                                <td style="width: 5px; height: 19px">
                                                    :</td>
                                                <td style="height: 19px">
                                                    <asp:TextBox ID="lblDOE2" runat="server" BorderStyle="None" ReadOnly="True" CssClass="Label" BorderColor="White"></asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 126px; height: 19px">
                                                </td>
                                                <td style="width: 5px; height: 19px">
                                                </td>
                                                <td style="height: 19px">
                                                </td>
                                            </tr>
                                        </table>
                                        </td>
                                </tr>
                            </tbody>
                        </table>
                   
                </td>
        </tr>
    </table>
    <table id="tbThirdParty" cellpadding="0" cellspacing="2" border="0" runat="server" style="width: 78%" visible="false">
        
        <tr>
            <td colspan="1" style=" width: 8px; height: 19px;">
            </td>
            <td style="background-color: #c6efef;height: 19px;" colspan="4">
                <asp:Label ID="Label32" runat="server" CssClass="LabelHeadGreen" Text="Third Party Details"
                    Width="146px"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="1" style="width: 8px;">
            </td>
            <td colspan="4" >
                <asp:Label ID="Label39" runat="server" CssClass="Label" ForeColor="Red" Text="* Mandatory Field" Width="121px"></asp:Label>
                </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 25px">
            </td>
            <td style="width: 134px; height: 25px">
            <asp:Label ID="Label2" runat="server" CssClass="Label" Text="Name" Width="37px"></asp:Label><asp:Label
                ID="Label34" runat="server" CssClass="Label" ForeColor="Red" Text="*"></asp:Label>
                </td>
            <td style="width: 275px; height: 25px">
                <asp:TextBox ID="THIRDNAME" runat="server" Width="210px" MaxLength="50"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RVFThirdName"
                        runat="server" ControlToValidate="THIRDNAME" CssClass="Label" ErrorMessage="Third party name is mandatory" ForeColor="White">*</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="THIRDNAME"
                    CssClass="Label" ErrorMessage="Name -Only alphabet is allowed" ForeColor="White"
                    ValidationExpression="([a-z]|[A-Z]|\s){1,30}">*</asp:RegularExpressionValidator></td>
            <td style="width: 148px; height: 25px">
            </td>
            <td style="height: 25px">
                </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 25px">
            </td>
            <td style="width: 134px; height: 25px">
                <asp:Label ID="Label15" runat="server" CssClass="Label" Text="Document Number" Width="108px"></asp:Label><asp:Label
                    ID="Label18" runat="server" CssClass="Label" ForeColor="Red" Text="*"></asp:Label></td>
            <td style="width: 275px; height: 25px">
                <asp:TextBox ID="THIRDDOCNO" runat="server" MaxLength="50" Width="211px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="THIRDDOCNO"
                    CssClass="Label" ErrorMessage="Document number is mandatory" ForeColor="White">*</asp:RequiredFieldValidator></td>
            <td colspan="2" style="height: 25px">
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 25px">
            </td>
            <td style="width: 134px; height: 25px">
                <asp:Label ID="Label31" runat="server" CssClass="Label" Text="Telephone Number"
                    Width="117px"></asp:Label></td>
            <td style="width: 275px; height: 25px">
                <asp:TextBox ID="THIRDTELNO" runat="server" Width="211px" MaxLength="50"></asp:TextBox></td>
            <td style="height: 25px" colspan="2">
                </td>
        </tr>        
         <tr>
             <td style="width: 8px; height: 25px">
             </td>
             <td style="width: 134px; height: 25px" valign="top">
                 <asp:Label ID="Label16" runat="server" CssClass="Label" Text="Remark" Width="99px"></asp:Label></td>
             <td style="width: 275px; height: 25px">
                 <asp:TextBox ID="THIRDREMARK" runat="server" CssClass="Label" Rows="3" TextMode="MultiLine"
                     Width="213px" MaxLength="50"></asp:TextBox></td>
             <td colspan="2" style="height: 25px">
             </td>
         </tr>
         <tr>
             <td style="width: 8px; height: 25px">
             </td>
             <td style="width: 134px; height: 25px">
             </td>
             <td style="width: 275px; height: 25px">
                <asp:Button ID="btnThirdIssue" runat="server" Text="Issue Visa" Width="109px" CausesValidation="True" OnClick="btnThirdIssue_Click" />
                 <asp:Button ID="btnCancelThirdIssue" runat="server" Text="Cancel" Width="109px" CausesValidation="False" OnClick="btnCancelThirdIssue_Click" /></td>
             <td colspan="2" style="height: 25px">
             </td>
         </tr>
        <tr>
            <td style="width: 8px; height: 25px">
            </td>
            <td style="width: 134px; height: 25px">
            </td>
            <td style="width: 275px; height: 25px">
                 <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="Label" ShowMessageBox="True"
                        ShowSummary="False" />
            </td>
            <td colspan="2" style="height: 25px">
            </td>
        </tr>
    </table>
     <table id="tbButtonPassport" cellpadding="0" cellspacing="2" border="0" runat="server" style="width: 80%" visible="true">
        <tr>
            <td colspan="1" style="width: 8px; height:10px">
            </td>
            <td colspan="4" >
                   
                <asp:Label ID="lblError" runat="server" CssClass="Label" ForeColor="Red" Visible="False"></asp:Label><asp:Label
                    ID="lblResult" runat="server" CssClass="Label" ForeColor="Blue" Visible="False"></asp:Label></td>
        </tr>
        <tr id="trButton" runat="server" visible="true">
            <td colspan="1" style=" width: 8px;">
            </td>
            <td colspan="4">
                    <input onclick="ReadMRZ_Click()" id="btnRead" type="button" value="Read MRZ"
                    runat="server" visible="true" style="width: 108px" />
                
                <asp:Button ID="btn3rdIssue" runat="server" Text="Third Party Issue" OnClick="btn3rdIssue_Click" Enabled="false" Width="116px" />&nbsp;
                <asp:Button ID="btnIssue" runat="server" CssClass="Button" Text="Issue" OnClick="btnIssue_Click" Enabled="false" Width="84px"></asp:Button>                
                <asp:Button ID="IssueFail" runat="server" Text="Reject" OnClick="IssueFail_Click" Width="84px" />&nbsp;                
                <asp:Button ID="btn_cancel" runat="server" Text="Cancel" Width="93px" CausesValidation="False" OnClick="btn_cancel_Click" />
                      
                      
            </td>
        </tr>
        <tr id="trButtonEG" runat="server" visible="false">
            <td style="width: 8px; height: 25px">
            </td>
            <td style="width: 134px; height: 25px">
            
            </td>
            <td style="width: 275px; height: 25px">
                &nbsp;
            </td>
            <td colspan="2" style="height: 25px">
            </td>
        </tr>
       </table>
       <table id="tbReject" cellpadding="0" cellspacing="2" border="0" runat="server"  style="width: 78%" visible="false">
            
            <tr>
                <td style="width: 5px; ">
                </td>
                <td colspan="3" style="height: 19px; background-color: #c6efef; width: 352px;">                    
                    <asp:Label ID="Label137" runat="server" CssClass="LabelHeadGreen" Text="Reject Issue Visa"
                        Width="146px"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 5px; ">
                </td>
                <td colspan="3" style="height: 8px; width: 352px;">                    
                    </td>
            </tr>
            <tr id="trLogin"  runat="server" visible="false">  
                <td style="width: 5px; height: 25px">
                </td>
                <td  colspan="3" style="height: 25px; width: 352px;" >           
                    <asp:Panel id="PanelLogin" runat="server" Width="300px" BackColor="AliceBlue" BorderColor="SteelBlue" BorderStyle="Ridge">
                    <table cellspacing="0" cellpadding="0" style="width: 300px"><tbody>
                        <tr>
                            <td colspan="1" style="width: 389px">
                            </td>
                            <td style="width: 35px">
                            </td>
                            <td style="width: 389px">
                            </td>
                        </tr>
                        <tr><td style="WIDTH: 389px; height: 30px;" colspan="1">
        &nbsp;<asp:Label ID="Label146" runat="server" CssClass="Label" Text="Supervisor ID"
            Width="78px"></asp:Label><asp:Label ID="Label147" runat="server" CssClass="Label"
                ForeColor="Red" Text="*"></asp:Label>
                        </td>
        <td style="WIDTH: 35px; height: 30px;">
            :</td>
        <td style="WIDTH: 389px; height: 30px;">
            <asp:TextBox ID="txtSuperID" runat="server" Width="122px" MaxLength="16"></asp:TextBox><asp:RequiredFieldValidator
                ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtsuperid" CssClass="Label"
                ErrorMessage="Supervisor login is a mandatory field" ForeColor="White">*</asp:RequiredFieldValidator></td>
    </tr>
        <tr>
            <td style="WIDTH: 389px; height: 30px;">
                &nbsp;<asp:Label ID="lbllogin" runat="server" CssClass="Label" ForeColor="Black"
                    Text="Password" Width="62px"></asp:Label><asp:Label ID="Label148" runat="server" CssClass="Label"
                        ForeColor="Red" Text="*"></asp:Label>
            </td>
            <td style="WIDTH: 35px; height: 30px;">
                :</td>
            <td style="WIDTH: 389px; height: 30px;">
                <asp:TextBox ID="txtSuperPassword" runat="server" TextMode="Password" Width="122px"></asp:TextBox><asp:RequiredFieldValidator
                    ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtSuperPassword" CssClass="Label"
                    ErrorMessage="Password is a mandatory field" ForeColor="White">*</asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="WIDTH: 389px; height: 30px;">
            </td>
            <td style="WIDTH: 35px; height: 30px;">
            </td>
            <td style="WIDTH: 389px; height: 30px;"><asp:Button ID="btnloginsuper" runat="server" Text="Login" OnClick="btnloginsuper_Click" Width="63px" />
                
                <asp:Button ID="btnCancelLogin" runat="server" CausesValidation="False" 
                        Text="Cancel" Width="63px" Height="25px" CssClass="Label" UseSubmitBehavior="False" OnClick="btnCancelLogin_Click" /></td>
        </tr>
                        <tr>
                            <td colspan="3" style="height: 23px">
                                <asp:ValidationSummary ID="ValidationSummary3" runat="server" CssClass="Label" ShowMessageBox="True"
                        ShowSummary="False" />
                            </td>
                        </tr>
                            <tr>
                                <td colspan="3" style="height: 23px">
                                    &nbsp;<asp:Label ID="lblLoginError" runat="server" CssClass="Label" ForeColor="Red"></asp:Label></td>
                            </tr>
    </tbody>
    </table>
    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td style="width: 5px; height: 25px">
                </td>
                <td colspan="3" style="width: 352px" >
                    <asp:Panel ID="PanelReject" runat="server" Visible="false">
                        <table id="Table5" cellpadding="0" cellspacing="2" border="0" runat="server" style="width: 98%" visible="true">
                        <tr>
                <td colspan="2" >
                    <asp:Label ID="Label139" runat="server" CssClass="Label" ForeColor="Red" Text="* Mandatory Field"
                        Width="121px"></asp:Label></td>
                <td style="width: 510px; ">
                </td>
                        </tr>
                            <tr>
                                <td style="width: 134px; height: 25px">
                                    <asp:Label ID="Label21" runat="server" CssClass="Label" Text="Action" Width="34px"></asp:Label>
                                    <asp:Label ID="Label22" runat="server" CssClass="Label" ForeColor="Red" Text="*"></asp:Label>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ACTIONCODE"
                                        CssClass="Label" ErrorMessage="Action is mandatory" ForeColor="White">*</asp:RequiredFieldValidator></td>
                                <td style="width: 12px; height: 25px">
                                    :</td>
                                <td style="width: 510px; height: 25px">
                                    <asp:RadioButtonList ID="ACTIONCODE" runat="server" CssClass="Label" RepeatDirection="Horizontal" TabIndex="14"  AutoPostBack="True" OnSelectedIndexChanged="ACTIONCODE_SelectedIndexChanged">
                                        <asp:ListItem Value="P">Re-Personalized</asp:ListItem>
                                        <asp:ListItem Value="N">No Action</asp:ListItem>
                                    </asp:RadioButtonList>
                                
                                
                                </td>
                            </tr>
            <tr>
                <td style="width: 134px; height: 25px">
                    <asp:Label ID="Label142" runat="server" CssClass="Label" Text="Reject Reason" Width="86px"></asp:Label><asp:Label
                        ID="lblAstReason" runat="server" CssClass="Label" ForeColor="Red" Text="*"></asp:Label></td>
                <td style="width: 12px; height: 25px">
                    :</td>
                <td style="width: 510px; height: 25px">
                    <asp:DropDownList ID="DDLRejectReason" runat="server" Enabled="False" Width="187px">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="DDLRejectReason"
                        CssClass="Label" ErrorMessage="Reject reason is mandatory" ForeColor="White">*</asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td style="width: 134px; height: 25px" valign="top">
                    <asp:Label ID="Label145" runat="server" CssClass="Label" Text="Remarks" Width="50px"></asp:Label>
                    <asp:Label ID="lblAstRemarks" runat="server" CssClass="Label" ForeColor="Red" Text="*"></asp:Label>
                    <asp:RequiredFieldValidator ID="RFVRemarks" runat="server" ControlToValidate="txtRejectRemark"
                        CssClass="Label" ErrorMessage="Remarks is mandatory" ForeColor="White">*</asp:RequiredFieldValidator></td>
                <td style="width: 12px; height: 25px" valign="top">
                    :</td>
                <td style="width: 510px; height: 25px">
                    <asp:TextBox ID="txtRejectRemark" runat="server" CssClass="Label" MaxLength="50" Rows="3"
                        TextMode="MultiLine" Width="400px"></asp:TextBox>
                    </td>
            </tr>
            <tr>
                <td style="width: 134px; height: 25px">
                </td>
                <td style="width: 12px; height: 25px">
                    &nbsp;</td>
                <td colspan="1" style="height: 25px; width: 510px;">
                    <asp:Button ID="btnRejectIssuance" runat="server" Text="Reject Issuance" Width="109px" CausesValidation="True" OnClick="btnRejectIssuance_Click"  />
                    &nbsp; 
                    <asp:Button ID="btnCancelReject" runat="server" Text="Cancel" Width="76px" CausesValidation="False" OnClick="btnCancelReject_Click"  /></td>
            </tr>
                            <tr>
                                <td colspan="3" style="height: 25px">
                                    <asp:Label ID="lblRejectErr" runat="server" CssClass="Label" ForeColor="Red" Visible="False"></asp:Label></td>
                            </tr>
            <tr>
                <td style="width: 134px; height: 25px">
                </td>
                <td style="width: 12px; height: 25px">
                    &nbsp;</td>
                <td colspan="1" style="height: 25px; width: 510px;">
                    <asp:ValidationSummary ID="ValidationSummary4" runat="server" CssClass="Label" ShowMessageBox="True"
                        ShowSummary="False" />
                </td>
            </tr>
                        </table>                        
                    </asp:Panel>
            </td>
            </tr>
        </table>
   
    <asp:HiddenField ID="txtCompName" runat="server" />  
    <asp:HiddenField ID="IssueStatus" runat="server" />  
    <asp:HiddenField ID="PhotoSrc" runat="server" />  
   
       



</asp:Content>