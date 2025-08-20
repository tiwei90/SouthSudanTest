<%@ Page MasterPageFile="~/iden.master" Language="C#" AutoEventWireup="true" Inherits="EnrollmentIssuanceSite.ApplicationPart1" Codebehind="ApplicationPart1.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
  <script type="text/javascript" src="inc/scan.js"></script>
  <script type="text/javascript" src="inc/passport.js"></script>

     <input id="IsNew" style="z-index: -5; left: 488px; width: 24px; position: absolute;
        top: 8px; height: 22px" type="hidden" runat="server" />
        <input id="trans" style="z-index: -5; left: 488px; width: 24px; position: absolute;
        top: 8px; height: 22px" type="hidden" runat="server" />
         <input id="purpose" style="z-index: -5; left: 488px; width: 24px; position: absolute;
        top: 8px; height: 22px" type="hidden" runat="server" />
        <input id="DOCTYPE1" style="z-index: -5; left: 488px; width: 24px; position: absolute;
        top: 8px; height: 22px" type="hidden" runat="server" />      
    
    <asp:Panel ID="Panel1" runat="server" Height="28px" BackImageUrl="./images/bg.gif" Width="100%">
        <asp:Label ID="fly" runat="server" Height="16px" CssClass="HeaderMainTitle" ForeColor="DimGray" BackColor="Transparent" Width="353px" >Visa - Personal Information</asp:Label></asp:Panel>
   <table id="tbFormNo" cellpadding="0" cellspacing="2" border="0" runat="server" style="width: 98%" visible="false">
        <tr>
            <td colspan="1" style="width: 8px;">
            </td>
            <td colspan="4" >
            </td>
        </tr>
        <tr>
            <td colspan="1" style=" width: 8px; height: 19px;">
            </td>
            <td style="background-color: #c6efef;height: 19px;" colspan="4">
                <asp:Label ID="lblHeadTitle" runat="server" CssClass="LabelHeadGreen" Text="Retrieve existing record"
                    Width="146px"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="1" style="width: 8px;">
            </td>
            <td colspan="4" >
                <asp:Label ID="Label39" runat="server" CssClass="Label" ForeColor="Red" Text="* Mandatory Field" Width="104px"></asp:Label>
                </td>
        </tr>       
          <tr id="trMode" runat="server" visible="true">
             <td style="width: 8px">
             </td>
             <td style="width: 141px">
                 <asp:Label ID="Label48" runat="server" CssClass="Label" Text="Application Mode" Width="95px"></asp:Label></td>
             <td colspan="3">
                 <asp:RadioButtonList ID="rbMode" runat="server" CssClass="Label" RepeatDirection="Horizontal" OnSelectedIndexChanged="rbMode_SelectedIndexChanged" AutoPostBack="True">
                     <asp:ListItem Selected="True" Value="1">Create New</asp:ListItem>
                     <asp:ListItem Value="2">Retrieve Existing Record</asp:ListItem>
                 </asp:RadioButtonList></td>
         </tr>
        <tr id="trSearch" runat="server" visible="false">
            <td style="width: 8px">
            </td>
            <td style="width: 150px">
                <asp:Label ID="Label22" runat="server" CssClass="Label" Text="Retrieved By" Width="71px"></asp:Label></td>
            <td colspan="3">
                &nbsp;<asp:DropDownList ID="rbSearch" runat="server" AutoPostBack="True"  CssClass="Label" OnSelectedIndexChanged="rbSearch_SelectedIndexChanged">                        
                        <asp:ListItem Value="2">PASSPORT NO</asp:ListItem>   
                        <asp:ListItem Value="3">DOCUMENT NO</asp:ListItem>                   
                       
                    </asp:DropDownList></td>
        </tr>
        <tr id="trOldDocNo" runat="server" visible="false">
            <td style="width: 8px;">
            </td>
            <td style="width: 150px;">
                <asp:Label ID="lblSearch" runat="server" CssClass="Label" Text="Document No"></asp:Label><asp:Label ID="Label30" runat="server" CssClass="Label"
                        ForeColor="Red" Text="*"></asp:Label></td>
            <td style="width: 190px;">
                &nbsp;<asp:TextBox ID="OLDDOCNO" runat="server" Width="168px" MaxLength="9" TabIndex="1"></asp:TextBox></td>
            <td  colspan="2">
                <asp:Button ID="Button1" runat="server" Text="Cancel" Width="82px" CausesValidation="False" Visible="false"/><asp:RequiredFieldValidator ID="RFVNIC"
                        runat="server" ControlToValidate="OLDDOCNO" CssClass="Label" ErrorMessage="Please enter Passport No/National Insurance No before pressing the <Retrieve Applicant Data> button" ForeColor="White">*</asp:RequiredFieldValidator></td>
        </tr>
        <tr runat="server" visible="false" id="trSurname">
            <td style="width: 8px">
            </td>
            <td style="width: 150px">
                <asp:Label ID="Label35" runat="server" CssClass="Label" Text="Surname" Width="54px"></asp:Label></td>
            <td style="width: 190px">
                &nbsp;<asp:TextBox ID="sSurname" runat="server" EnableViewState="False" Width="172px"></asp:TextBox></td>
            <td colspan="2">
            </td>
        </tr>
        <tr runat="server" visible="false" id="trFirstname">
            <td style="width: 8px">
            </td>
            <td style="width: 150px">
                <asp:Label ID="Label38" runat="server" CssClass="Label" Text="First Name" Width="63px"></asp:Label></td>
            <td style="width: 190px">
                &nbsp;<asp:TextBox ID="sFirstName" runat="server" EnableViewState="False" Width="172px"></asp:TextBox></td>
            <td colspan="2">
                <asp:CustomValidator ID="CustomValidator3" runat="server" ClientValidationFunction="CheckEmpty"
                    ControlToValidate="sSurname" ErrorMessage="Please enter required data before pressing the <Retrieve Applicant Data> button"
                    ForeColor="White" ValidateEmptyText="True">*</asp:CustomValidator></td>
        </tr>
        <tr runat="server" visible="false" id="trMiddleName">
            <td style="width: 8px">
            </td>
            <td style="width: 150px">
                <asp:Label ID="Label43" runat="server" CssClass="Label" Text="Middle Name" Width="75px"></asp:Label></td>
            <td style="width: 190px">
                &nbsp;<asp:TextBox ID="sMiddleName" runat="server" EnableViewState="False" Width="172px"></asp:TextBox></td>
            <td colspan="2">
            </td>
        </tr>
        <tr runat="server" visible="false" id="trBirthDate">
            <td style="width: 8px">
            </td>
            <td style="width: 150px">
                <asp:Label ID="Label44" runat="server" CssClass="Label" Text="Date of Birth" Width="70px"></asp:Label><asp:Label
                    ID="Label45" runat="server" CssClass="Label" ForeColor="Red" Text="*"></asp:Label></td>
            <td colspan="3">
                &nbsp;<asp:TextBox ID="DOB" runat="server" ReadOnly="True" Width="156px"></asp:TextBox><asp:ImageButton
                    ID="ImageButton6" runat="server" CausesValidation="False" ImageUrl="~/images/button.gif"
                    OnClientClick="CalPick('DOB','X','Applicant Birthdate');return false;" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="DOB"
                    CssClass="Label" ErrorMessage="Date of Birth is mandatory" ForeColor="White">*</asp:RequiredFieldValidator></td>
        </tr>
             <tr runat="server" visible="false" id="trCOI">
                 <td style="width: 8px">
                 </td>
                 <td style="width: 150px">
                     <asp:Label ID="lblCOI" runat="server" CssClass="Label" Text="Country of Issue" Width="91px"></asp:Label><asp:Label
                         ID="Label53" runat="server" CssClass="Label" ForeColor="Red" Text="*"></asp:Label></td>
                 <td colspan="3">
                     &nbsp;<asp:DropDownList ID="DDPASSPORTPOI" runat="server" CssClass="Label">
                     </asp:DropDownList>
                     <asp:RequiredFieldValidator ID="RFVDDCOI" runat="server" ControlToValidate="DDPASSPORTPOI"
                         CssClass="Label" ErrorMessage="Country of Issue is mandatory" ForeColor="White">*</asp:RequiredFieldValidator></td>
             </tr>
        <tr runat="server" visible="false" id="trButton">
            <td style="width: 8px">
            </td>
            <td style="width: 150px">
            </td>
            <td colspan="3">
                &nbsp;<asp:Button ID="btnGetOldDoc" runat="server" Text="Retrieve Applicant Data" OnClick="btnGetOldDoc_Click" Width="146px" /></td>
        </tr>             
        </table>
   <table id="trDG" cellpadding="0" cellspacing="2" border="0" runat="server" style="width: 98%" visible="false">
             <tr id="Tr2"  runat="server">
            <td style="width: 8px">
            </td>
            <td colspan="4">
             <div id="Div2" runat="server" class="PanelSearch">
                <table width="99%" border="0" cellspacing="2" cellpadding="0" id="Table1"  runat="server">
                    <tr>
                        <td style="width: 8px">
                        </td>
                        <td colspan="6">
                            <asp:GridView ID="dgByName" runat="server" AllowPaging="True" CellPadding="3" CssClass="DataGrid"
                                ForeColor="#333333" GridLines="None" PageSize="5" Width="780px" OnPageIndexChanging="dgByName_PageIndexChanging" AllowSorting="True" AutoGenerateColumns="False" OnRowCommand="dgByName_RowCommand" EnableViewState="true">
                                <Columns>
                                 <asp:TemplateField HeaderText="APPLICATION ID">
                                <ItemTemplate>
                                       <asp:LinkButton ID="LinkButton1"  CommandArgument='<%# Eval("FormNo") %>' CommandName="Select" runat="server" Text='<%# Eval("FormNo") %>' CausesValidation="False">
                                         </asp:LinkButton>
                                 </ItemTemplate>
                                     <ItemStyle Width="90px" />
                                     <HeaderStyle HorizontalAlign="Left" Width="95px" VerticalAlign="Top" />
                                 </asp:TemplateField>  
                                  <asp:TemplateField HeaderText="VISA TYPE">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPassportType" runat="server" Text='<%# Eval("DocType") %>'></asp:Label>
                                    </ItemTemplate>
                                     <ItemStyle Width="95px" />
                                     <HeaderStyle HorizontalAlign="Left" Width="95px" VerticalAlign="Top" />
                                </asp:TemplateField>  
                                 <asp:TemplateField HeaderText="PURPOSE OF APPLICATION">
                                    <ItemTemplate>
                                        <asp:Label ID="lblAppReason" runat="server" Text='<%# Eval("AppReason") %>'></asp:Label>
                                    </ItemTemplate>
                                     <ItemStyle Width="95px" />
                                     <HeaderStyle HorizontalAlign="Left" Width="95px" VerticalAlign="Top" />
                                </asp:TemplateField>                                                  
                                 <asp:TemplateField HeaderText="SURNAME">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSurname" runat="server" Text='<%# Eval("Surname") %>'></asp:Label>
                                    </ItemTemplate>
                                     <ItemStyle Width="95px" />
                                     <HeaderStyle HorizontalAlign="Left" Width="95px" VerticalAlign="Top" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="FIRST NAME">
                                    <ItemTemplate>
                                        <asp:Label ID="lblFirstName" runat="server" Text='<%# Eval("FirstName") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="95px" />
                                    <HeaderStyle HorizontalAlign="Left" Width="95px" VerticalAlign="Top" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="MIDDLE NAME">
                                    <ItemTemplate>
                                        <asp:Label ID="lblMiddleName" runat="server" Text='<%# Eval("MiddleName") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="90px" />
                                    <HeaderStyle HorizontalAlign="Left" Width="90px" VerticalAlign="Top" />
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="SEX">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSex" runat="server" Text='<%# Eval("Sex") %>'></asp:Label>
                                    </ItemTemplate>
                                     <ItemStyle HorizontalAlign="Center" Width="50px" />
                                     <HeaderStyle Width="50px" VerticalAlign="Top" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="DATE OF BIRTH">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDOB" runat="server" Text='<%# Eval("BirthDate") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="90px" />
                                    <HeaderStyle Width="90px" HorizontalAlign="Left" VerticalAlign="Top" />
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="NATIONALITY">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPriority" runat="server" Text='<%# Eval("Nationality") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="70px" />
                                    <HeaderStyle HorizontalAlign="Left" Width="70px" VerticalAlign="Top" />
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="APPLICATION STATUS">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPriority2" runat="server" Text='<%# Eval("StageCode") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="70px" />
                                    <HeaderStyle HorizontalAlign="Left" Width="70px" VerticalAlign="Top" />
                                </asp:TemplateField>
                                </Columns>
                                
                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <RowStyle BackColor="#EFF3FB" />
                                <EditRowStyle BackColor="#2461BF" />
                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <AlternatingRowStyle BackColor="White" />
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
                </div>
            
            
            </td>
        </tr>
        </table>   
   <table id="Table3" border="0" cellpadding="0" cellspacing="2"  visible="true" runat="server" style="width: 98%">
       
        <tr id="trNewAppID" runat="server" visible="true">
            <td style="width: 9px;">
            </td>
            <td style="width:113px;" colspan="2">
                <asp:Label ID="Label4" runat="server" CssClass="Label" Text="Application ID" Width="77px"></asp:Label><asp:Label
                    ID="Label33" runat="server" CssClass="Label" ForeColor="Red" Text="*"></asp:Label>
                </td>
            <td style="width: 180px;">
                <asp:TextBox ID="FORMNO" runat="server" Width="177px" ReadOnly="true" TabIndex="2"></asp:TextBox></td>
            <td style="width:138px" colspan="2">
                <asp:Button ID="btnGenFormNo" runat="server" Text="Generate" OnClick="btnGenFormNo_Click" Width="67px" TabIndex="9" CausesValidation="False" /></td>
            <td colspan="1" style="width:276px" >
            </td>
        </tr>
        <tr id="trErrorMsg" runat="server" visible="false">
            <td style="width: 9px; ">
            </td>
            <td colspan="6">
            <asp:Label ID="lblFormNoError" runat="server" CssClass="Label" ForeColor="Red" Width="380px"></asp:Label>
            </td>
        </tr>
        <tr id="Tr1" runat="server">
                 <td style="width: 9px">
                 </td>                 
                <td colspan="6">
                     <asp:Label ID="lblDocNoError" runat="server" CssClass="Label" ForeColor="Blue" Visible="False"
                         Width="592px"></asp:Label></td>
             </tr>
        <tr runat="server" visible="true" id="trValSummaryTop">
            <td style="width: 9px;">
            </td>
            <td colspan="6">
                &nbsp;</td>
        </tr>
    </table>
  
      <table id="tbVisaInfo" cellpadding="0" cellspacing="2" border="0" visible="false" runat="server" width="98%">
        <tr>
            <td style="width: 10px; height: 19px;">
            </td>
            <td colspan="4" style="height: 19px; background-color: #c6efef">
                <asp:Label ID="Label1" runat="server" CssClass="LabelHeadGreen" Text="Visa Application Details"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;
           </td>
        </tr>
        
       <tr>
           <td style="width: 10px; height: 16px">
           </td>
           <td colspan="2" style="height: 16px">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="NATIONALITY"
                    CssClass="Label" ErrorMessage="Nationality is mandatory field" ForeColor="White">*</asp:RequiredFieldValidator><asp:RequiredFieldValidator
                        ID="RequiredFieldValidator7" runat="server" ControlToValidate="FORMNO" CssClass="Label"
                        ErrorMessage="Application ID is mandatory field" ForeColor="White">*</asp:RequiredFieldValidator><asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="DOCTYPE"
                    CssClass="Label" ErrorMessage="Visa type is mandatory field" ForeColor="White">*</asp:RequiredFieldValidator></td>
           <td style="width: 97px; height: 16px">
           </td>
           <td style="width: 276px; height: 16px">
               <asp:Label ID="lblPhoto" runat="server" CssClass="LabelHeadLine" Text="Photograph" Visible="False"></asp:Label>
               <asp:Label ID="lblAstPhoto" runat="server" CssClass="Label" ForeColor="Red" Text="*" Visible="False"></asp:Label></td>
       </tr>
       <tr>
           <td style="width: 10px; height: 16px">
           </td>
           <td style="width: 138px; height: 16px">
                <asp:Label ID="Label5" runat="server" CssClass="Label" Text="Purpose of application"></asp:Label><asp:Label
                    ID="Label9" runat="server" CssClass="Label" ForeColor="Red" Text="*"></asp:Label></td>
           <td style="width: 240px; height: 16px">
           <asp:DropDownList ID="APPREASON" runat="server" CssClass="Label" Width="252px" TabIndex="2" Enabled="false">
           </asp:DropDownList>
           <asp:DropDownList ID="APPREASONEXTERNAL" runat="server" CssClass="Label" Width="252px" TabIndex="2" Visible="false">
                        <asp:ListItem Value="4">EXTERNAL APPLICATION - UNSPONSORED</asp:ListItem>   
                        <asp:ListItem Value="5">EXTERNAL APPLICATION - SPONSORED</asp:ListItem>  
           </asp:DropDownList>
           </td>
           <td style="width: 97px; height: 16px">
               &nbsp;<asp:RequiredFieldValidator ID="RFVAppExternal" runat="server" ControlToValidate="APPREASONEXTERNAL"
                   CssClass="Label" ErrorMessage="Purpose of Application is mandatory field" ForeColor="White"
                   Visible="False">*</asp:RequiredFieldValidator></td>
           <td style="width: 276px;" rowspan="7" valign="top">
               <table border="0" cellpadding="0" cellspacing="0" style="width: 100%" runat="server" visible="false" id="tbPhoto">
                   <tr>
                       <td rowspan="7" style="width: 89px" valign="top">
                           <asp:Image ID="imgPhoto" runat="server" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1px"
                               Height="111px" ImageUrl="~/images/spacer.gif" Width="88px" /></td>
                       <td colspan="2" style="height: 19px" valign="top">
                            <input id="btnScanPhoto" runat="server" name="btnCapture" onclick="CapturePhoto('Photo','imgPhoto','FACEIMAGE','FACEIMAGEJ2K')"
                                style="width: 108px; height: 24px" type="button" value="Scan Photograph" visible="true" /></td>
                   </tr>
                   <tr>
                       <td style="width: 59px; height: 19px">
                           <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="FACEIMAGE"
                               CssClass="Label" ErrorMessage="Photo is mandatory field" ForeColor="White">*</asp:RequiredFieldValidator></td>
                       <td style="width: 100px; height: 19px">
                       </td>
                   </tr>
                   <tr>
                       <td colspan="2"> </td>
                   </tr>
                   <tr>
                       <td style="width: 59px">
                       </td>
                       <td style="width: 100px">
                       </td>
                   </tr>
                   <tr>
                       <td style="width: 59px">
                       </td>
                       <td style="width: 100px">
                       </td>
                   </tr>
                   <tr>
                       <td style="width: 59px">
                       </td>
                       <td style="width: 100px">
                       </td>
                   </tr>
                   <tr>
                       <td style="width: 59px">
                       </td>
                       <td style="width: 100px">
                       </td>
                   </tr>
               </table>
           </td>
       </tr>
        <tr>
            <td style="width: 10px; height: 16px">
            </td>
            <td style="width: 138px; height: 16px">
                <asp:Label ID="Label3" runat="server" CssClass="Label" Text="Applied Visa Type" Width="98px"></asp:Label><asp:Label
                    ID="Label24" runat="server" CssClass="Label" ForeColor="Red" Text="*"></asp:Label></td>
            <td style="width: 240px; height: 16px">
                <asp:DropDownList ID="DOCTYPE" runat="server" CssClass="Label" Width="180px" TabIndex="2">
                </asp:DropDownList></td>
            <td style="width: 97px; height: 16px">
                </td>
        </tr>
       <tr>
           <td style="width: 10px;height: 10px;">
           </td>
           <td style="width: 138px;height: 10px;">
               <asp:Label ID="Label41" runat="server" CssClass="Label" Text="Applied Entry Type"
                   Width="101px"></asp:Label><asp:Label ID="Label42" runat="server" CssClass="Label"
                       ForeColor="Red" Text="*"></asp:Label></td>
           <td style="height: 10px;" colspan="2">
           <asp:DropDownList ID="SUBDOCTYPE" runat="server" CssClass="Label" Width="180px" TabIndex="3" >
           </asp:DropDownList>
               <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="SUBDOCTYPE"
                   CssClass="Label" ErrorMessage="Entry type is mandatory field" ForeColor="White">*</asp:RequiredFieldValidator></td>
       </tr>
       <tr id= "trColDate" runat="server" visible= "true">
           <td style="width: 10px; height: 10px">
           </td>
           <td style="width: 138px; height: 10px">
               <asp:Label ID="Label6" runat="server" CssClass="Label" Text="Collection Date" Width="88px"></asp:Label></td>
           <td colspan="2" style="height: 10px">
               <asp:TextBox ID="txtColDate" runat="server" Width="151px"></asp:TextBox><asp:ImageButton
                   ID="btnCal" runat="server" CausesValidation="False" ImageUrl="~/images/button.gif"
                   OnClientClick="CalPick('txtColDate','L','Collection date');return false;" /></td>
       </tr>
       <tr runat="server" id="trPhoto2" visible="false">
           <td style="width: 10px; height: 10px">
           </td>
           <td style="width: 138px; height: 10px">
               <asp:Label ID="Label37" runat="server" CssClass="Label" Text="Approved Visa Type"
                   Width="131px"></asp:Label></td>
           <td colspan="2" style="height: 10px">
               <asp:Label ID="APPROVEDDOCTYPE" runat="server" CssClass="Label" Width="131px">-</asp:Label></td>
       </tr>
       <tr runat="server" id="trPhoto1" visible="false">
           <td style="width: 10px; height: 10px">
           </td>
           <td style="width: 138px; height: 10px">
               <asp:Label ID="Label40" runat="server" CssClass="Label" Text="Approved Entry Type"
                   Width="133px"></asp:Label></td>
           <td colspan="2" style="height: 10px">
               <asp:Label ID="APPROVEDSUBDOCTYPE" runat="server" CssClass="Label" Width="131px">-</asp:Label></td>
       </tr>
       <tr runat="server" visible="false" id="trPhoto3">
           <td style="width: 10px; height: 10px">
           </td>
           <td style="width: 138px; height: 10px">
           </td>
           <td colspan="2" style="height: 10px">
           </td>
       </tr>
     
        </table>     
    <table id="tbPInfo" cellpadding="0" cellspacing="2" border="0" runat="server" visible="false" width="98%">
        <tr>
            <td colspan="1" style="width: 10px;">
            </td>
            <td colspan="4">
            </td>
        </tr>
        <tr>
            <td colspan="1" style="height: 19px;">
            </td>
            <td style="height: 19px; background-color: #c6efef;" colspan="4">
                <asp:Label ID="Label2" runat="server" CssClass="LabelHeadGreen" Text="Personal Details"
                    Width="139px"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="1" style="width: 10px">
            </td>
            <td colspan="4"> </td>
        </tr>
        <tr>
            <td style="width: 10px;">
            </td>
            <td style="width: 152px;">
                <asp:Label ID="Label29" runat="server" CssClass="Label" Text="Title" Width="26px"></asp:Label><asp:Label
                    ID="Label34" runat="server" CssClass="Label" ForeColor="Red" Text="*"></asp:Label><asp:CustomValidator
                        ID="CustomValidator1" runat="server" ClientValidationFunction="ClientValidate"
                        ControlToValidate="TITLE" CssClass="Label" ErrorMessage="Sex and Title do not match" ForeColor="White">*</asp:CustomValidator><asp:RequiredFieldValidator
                            ID="RequiredFieldValidator5" runat="server" ControlToValidate="TITLE" CssClass="Label"
                            ErrorMessage="Title is mandatory field" ForeColor="White">*</asp:RequiredFieldValidator></td>
            <td style="width: 219px;">
                  <asp:DropDownList ID="TITLE" runat="server"  CssClass="Label" Width="180px" TabIndex="10">
                    <asp:ListItem Value="MR">MR</asp:ListItem>
                    <asp:ListItem Value="MRS">MRS</asp:ListItem>
                    <asp:ListItem Value="MISS">MISS</asp:ListItem>
                    <asp:ListItem Value="DR">DR</asp:ListItem>
            </asp:DropDownList>
            </td>
          
              
            <td style="width: 138px;">
                <asp:Label ID="Label36" runat="server" CssClass="Label" Text="National ID No"
                    Width="124px"></asp:Label></td>
            <td style="width: 203px;">
                <asp:TextBox ID="NATIONALINSURANCENO" runat="server" MaxLength="30" Width="175px" TabIndex="18"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="NATIONALINSURANCENO" CssClass="Label" ErrorMessage="National ID - Only alphanumerics are allowed" ForeColor="White" ValidationExpression="([A-Z]|[a-z]|[0-9]){1,30}">*</asp:RegularExpressionValidator>
                </td>
        </tr>
        <tr>
            <td style="width: 10px">
            </td>
            <td style="width: 152px">
               <asp:Label ID="Label14" runat="server" Text="Surname" CssClass="Label" Width="55px"></asp:Label><asp:Label ID="Label18" runat="server" CssClass="Label" ForeColor="Red" Text="*"></asp:Label><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="SURNAME"
                    CssClass="Label" ErrorMessage="Surname is mandatory field" ForeColor="White">*</asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="SURNAME"
                    CssClass="Label" ErrorMessage="Surname- Only alphabet is allowed" ValidationExpression="([a-z]|[A-Z]|[-']|\s){1,30}" ForeColor="White">*</asp:RegularExpressionValidator></td>
            <td style="width: 219px">
                <asp:TextBox ID="SURNAME" runat="server" MaxLength="30" Width="175px" TabIndex="11"></asp:TextBox></td>
            <td style="width: 138px">
                <asp:Label ID="Label11" runat="server" CssClass="Label" Text="Date of Birth" Width="69px"></asp:Label><asp:Label
                    ID="Label25" runat="server" CssClass="Label" ForeColor="Red" Text="*"></asp:Label><asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="BIRTHDATE"
                    CssClass="Label" ErrorMessage="Date of Birth is mandatory field" ForeColor="White">*</asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Date of birth format is (yyyy/mm/dd)"
                    ControlToValidate="BIRTHDATE" CssClass="Label" ValidationExpression="(0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[012])/(19|20)\d\d" ForeColor="White">*</asp:RegularExpressionValidator></td>
            <td style="width: 203px">
                <asp:TextBox ID="BIRTHDATE" runat="server" Width="148px" ReadOnly="True" TabIndex="16"></asp:TextBox><asp:ImageButton ID="btn_Cal" OnClientClick="DOBClick();return false;" runat="server"
                    ImageUrl="~/images/button.gif" CausesValidation="False" TabIndex="19" /><img id="imgClearDOB" alt="" onclick="Clear('BIRTHDATE');return false;" src="images/icon_clear.gif" style="cursor: hand" runat="server" /></td>
        </tr>
        <tr>
            <td style="width: 10px; height: 17px;">
            </td>
            <td style="width: 152px; height: 17px;">
                <asp:Label ID="Label15" runat="server" Text="First Name" CssClass="Label" Width="64px"></asp:Label><asp:Label
                    ID="Label10" runat="server" CssClass="Label" ForeColor="Red" Text="*"></asp:Label><asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="FIRSTNAME"
                    CssClass="Label" ErrorMessage="Firstname - Only alphabet is allowed" ValidationExpression="([a-z]|[A-Z]|[-']|\s){1,30}" ForeColor="White">*</asp:RegularExpressionValidator><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="FIRSTNAME"
                    CssClass="Label" ErrorMessage="Firstname is mandatory field" ForeColor="White">*</asp:RequiredFieldValidator></td>
            <td style="width: 219px; height: 17px;">
                <asp:TextBox ID="FIRSTNAME" runat="server" MaxLength="30" Width="175px" TabIndex="12"></asp:TextBox></td>
            <td style="width: 138px; height: 17px;">
                <asp:Label ID="Label12" runat="server" CssClass="Label" Text="Country of Birth" Width="87px"></asp:Label><asp:Label
                    ID="Label23" runat="server" CssClass="Label" ForeColor="Red" Text="*"></asp:Label><asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="BIRTHCOUNTRY"
                    CssClass="Label" ErrorMessage="Country of Birth is mandatory field" ForeColor="White">*</asp:RequiredFieldValidator></td>
            <td style="width: 203px; height: 17px;">
                <asp:DropDownList ID="BIRTHCOUNTRY" runat="server" CssClass="Label" Width="280px" TabIndex="20">                    
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td style="width: 10px; height: 13px;">
            </td>
            <td style="width: 152px; height: 13px;" valign="middle">
                <asp:Label ID="Label16" runat="server" CssClass="Label" Text="Middle Name" Width="77px"></asp:Label><asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="MIDDLENAME"
                    CssClass="Label" ErrorMessage="Middle name- Only alphabet is allowed" ValidationExpression="([a-z]|[A-Z]|[-']|\s){1,30}" ForeColor="White">*</asp:RegularExpressionValidator></td>
            <td style="width: 219px; height: 13px;">
                <asp:TextBox ID="MIDDLENAME" runat="server" Width="175px" MaxLength="30" TabIndex="13"></asp:TextBox></td>
            <td style="width: 138px; height: 13px;">
                <asp:Label ID="Label47" runat="server" CssClass="Label" Text="Place of Birth" Width="75px"></asp:Label><asp:Label
                    ID="Label51" runat="server" CssClass="Label" ForeColor="Red" Text="*"></asp:Label><asp:RegularExpressionValidator ID="RegularExpressionValidator13" runat="server"
                    ControlToValidate="BIRTHPLACE" CssClass="Label" ErrorMessage="Place of birth - Only alphanumeric are allowed"
                    ForeColor="White" ValidationExpression="([a-z]|[A-Z]|[0-9]|[-'/,]|\s){1,100}">*</asp:RegularExpressionValidator><asp:RequiredFieldValidator
                            ID="RequiredFieldValidator11" runat="server" ControlToValidate="BIRTHPLACE" CssClass="Label"
                            ErrorMessage="Place of birth is mandatory field" ForeColor="White">*</asp:RequiredFieldValidator></td>
            <td colspan="2" style="width: 276px; height: 13px;">
                <asp:TextBox ID="BIRTHPLACE" runat="server" MaxLength="30" TabIndex="21" Width="272px"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 10px">
            </td>
            <td style="width: 152px" valign="middle">
                <asp:Label ID="Label17" runat="server" CssClass="Label" Text="Sex" Width="24px"></asp:Label><asp:Label
                    ID="Label13" runat="server" CssClass="Label" ForeColor="Red" Text="*"></asp:Label><asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="SEX"
                    CssClass="Label" ErrorMessage="Sex is mandatory field" ForeColor="White">*</asp:RequiredFieldValidator></td>
            <td style="width: 219px">
                <asp:RadioButtonList ID="SEX" runat="server" CssClass="Label" RepeatDirection="Horizontal" TabIndex="14">
                    <asp:ListItem Value="M">Male</asp:ListItem>
                    <asp:ListItem Value="F">Female</asp:ListItem>
                </asp:RadioButtonList></td>
            <td style="width: 138px">
                <asp:Label ID="lblBirthNationality" runat="server" CssClass="Label" Text="Nationality" Width="61px"></asp:Label><asp:Label
                    ID="Label19" runat="server" CssClass="Label" ForeColor="Red" Text="*"></asp:Label></td>
            <td colspan="2" style="width: 276px">
                <asp:DropDownList ID="NATIONALITY" runat="server" CssClass="Label" Width="280px" TabIndex="22">
                   
                </asp:DropDownList></td>
        </tr>        
    </table>
    <table id="tbPassport" cellpadding="0" cellspacing="2" border="0" visible="false" runat="server" width="98%">
        <tr>
            <td style="width: 10px; height: 10px">
            </td>
            <td colspan="4" style="height: 10px">
            </td>
        </tr>
        <tr>
            <td style="width: 10px; height: 19px;">
            </td>
            <td colspan="4" style="height: 19px; background-color: #c6efef">
                <asp:Label ID="Label31" runat="server" CssClass="LabelHeadGreen" Text="Passport Details"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 10px; height: 1px">
            </td>
            <td colspan="4" style="height: 1px">
            </td>
        </tr>
        <tr>
            <td style="width: 10px; height: 16px">
            </td>
            <td style="width: 140px; height: 16px">
                <asp:Label ID="Label20" runat="server" CssClass="Label" Text="Passport No" Width="71px"></asp:Label><asp:Label
                    ID="Label26" runat="server" CssClass="Label" ForeColor="Red" Text="*"></asp:Label><asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="PASSPORTNO"
                    CssClass="Label" ErrorMessage="Passport no  is mandatory field" ForeColor="White">*</asp:RequiredFieldValidator></td>
            <td style="width: 210px; height: 16px">
                <asp:TextBox ID="PASSPORTNO" runat="server" MaxLength="9" Width="175px" TabIndex="26"></asp:TextBox>
                <asp:RegularExpressionValidator
                    ID="RegularExpressionValidator11" runat="server" ControlToValidate="PASSPORTNO"
                    CssClass="Label" ErrorMessage="Passport No - Only alphanumerics are allowed"
                    ForeColor="White" ValidationExpression="([A-Z]|[a-z]|[0-9]){1,100}">*</asp:RegularExpressionValidator>
                
                </td>
            <td style="width: 138px; height: 16px">
                <asp:Label ID="Label21" runat="server" CssClass="Label" Text="Place of issue" Width="80px"></asp:Label><asp:Label
                    ID="Label27" runat="server" CssClass="Label" ForeColor="Red" Text="*"></asp:Label><asp:RequiredFieldValidator
                        ID="RequiredFieldValidator12" runat="server" ControlToValidate="PASSPORTPOI"
                        CssClass="Label" ErrorMessage="Place of issue  is mandatory field" ForeColor="White">*</asp:RequiredFieldValidator></td>
            <td style="width: 276px; height: 16px">
                <asp:TextBox ID="PASSPORTPOI" runat="server" MaxLength="50" Width="175px" TabIndex="28"></asp:TextBox>
               <asp:RegularExpressionValidator
                    ID="RegularExpressionValidator12" runat="server" ControlToValidate="PASSPORTPOI"
                    CssClass="Label" ErrorMessage="Place of issue - Some special characters are NOT allowed"
                    ForeColor="White" ValidationExpression="([A-Z]|[a-z]|[-@#/.,&quot;':\]|[0-9]|\s){1,100}">*</asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr valign="middle">
            <td style="width: 10px;">
            </td>
            <td style="width: 140px;">
                <asp:Label ID="Label7" runat="server" CssClass="Label" Text="Date of Issue" Width="75px"></asp:Label><asp:Label ID="Label28" runat="server" CssClass="Label" ForeColor="Red" Text="*"></asp:Label><asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="PASSPORTDOI"
                    CssClass="Label" ErrorMessage="Date of issue is mandatory field" ForeColor="White">*</asp:RequiredFieldValidator></td>
            <td style="width: 210px;">
                <asp:TextBox ID="PASSPORTDOI" runat="server" MaxLength="4" Width="148px" ReadOnly="True"></asp:TextBox><asp:ImageButton ID="ImageButton3" OnClientClick="CalPick('PASSPORTDOI','B','Date of issue');return false;" runat="server"
                    CausesValidation="False" ImageUrl="~/images/button.gif" TabIndex="27" /><img alt="" onclick="Clear('PASSPORTDOI');return false;" src="images/icon_clear.gif"
                    style="cursor: hand" /></td>
            <td style="width: 138px;">
                <asp:Label ID="Label8" runat="server" CssClass="Label" Text="Country of issue" Width="90px"></asp:Label><asp:Label
                    ID="Label32" runat="server" CssClass="Label" ForeColor="Red" Text="*"></asp:Label><asp:RequiredFieldValidator
                        ID="RequiredFieldValidator8" runat="server" ControlToValidate="PASSPORTCOI" CssClass="Label"
                        ErrorMessage="Country of issue  is mandatory field" ForeColor="White">*</asp:RequiredFieldValidator></td>
            <td style="width: 276px;">
                <asp:DropDownList ID="PASSPORTCOI" runat="server" CssClass="Label" TabIndex="29"
                    Width="280px">
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td style="width: 10px; height: 24px;">
            </td>
            <td style="width: 140px; height: 24px;" valign="middle">
                <asp:Label ID="Label55" runat="server" CssClass="Label" Text="Date of Expiry" Width="77px"></asp:Label><asp:Label ID="Label56" runat="server" CssClass="Label" ForeColor="Red" Text="*"></asp:Label><asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="PASSPORTDOE"
                    CssClass="Label" ErrorMessage="Date of Expiry is  mandatory field" ForeColor="White">*</asp:RequiredFieldValidator></td>
            <td style="width: 210px; height: 24px;">
                <asp:TextBox ID="PASSPORTDOE" runat="server" Width="148px" MaxLength="50" ReadOnly="True"></asp:TextBox><asp:ImageButton ID="ImageButton1" OnClientClick="CalPick('PASSPORTDOE','L','Date of expiry');return false;" runat="server"
                    CausesValidation="False" ImageUrl="~/images/button.gif" TabIndex="27" /><img alt="" onclick="Clear('PASSPORTDOE');return false;" src="images/icon_clear.gif"
                    style="cursor: hand" /></td>
            <td style="width: 138px; height: 24px;">
                </td>
            <td style="width: 276px; height: 24px;">
                </td>
        </tr>
        <tr>
            <td style="width: 10px; height: 24px">
            </td>
            <td style="width: 140px; height: 24px" valign="middle">
            </td>
            <td style="width: 210px; height: 24px">
            </td>
            <td style="width: 138px; height: 24px">
            </td>
            <td style="width: 276px; height: 24px">
            </td>
        </tr>
       
    </table>
    <table id="tbButton" cellspacing="0" cellpadding="0" runat="server" visible="false" border="0">
        <tr>
            <td style="height: 10px">
            </td>
            <td>               
                <asp:Label ID="lblError" runat="server" CssClass="Label" ForeColor="Red" Visible="False">* Please take note that every field must be filled.</asp:Label>
                <asp:Label ID="lblSuccess" runat="server" CssClass="Label" ForeColor="Blue" Visible="False"></asp:Label>
                </td>
        </tr>
        <tr>
            <td style="width: 10px">
            </td>
            <td style="width: 818px">
                <input onclick="ReadEPP_Click();" id="btnRead" type="button" value="Read Passport" runat="server" visible="true" />&nbsp;
                <asp:Button ID="btnSave" runat="server" CssClass="Button" OnClick="btnSave_Click"
                    TabIndex="30" Text="Save &amp; Next" Width="104px" />
                    &nbsp;<asp:Button ID="btnReset"  runat="server" CssClass="Button" Width="104px" Text="Reset" CausesValidation="False" Visible="False"></asp:Button>
                       
                        </td>
        </tr>
    </table>
    <table id="tbError" cellspacing="0" cellpadding="0" runat="server" border="0">
         <tr>
            <td >
            </td>
            <td>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="Label" ShowMessageBox="True"
                    ShowSummary="False" />
                &nbsp;
                </td>
        </tr>
   </table>
 <asp:HiddenField ID="txtCompName" runat="server" /> 
 <asp:HiddenField ID="FACEIMAGEJ2K" runat="server" /> 
 <div style="z-index: 101; left: -122px; visibility: hidden; width: 100px; position: absolute;
        top: 429px; height: 100px">
    <asp:TextBox ID="IDPERSON" runat="server" Width="32px"></asp:TextBox>  
    <asp:TextBox ID="APPREASONCODE" runat="server" Width="32px"></asp:TextBox>
    <asp:TextBox ID="STAGECODE" runat="server" Width="32px"></asp:TextBox>   
    <asp:TextBox ID="FACEIMAGE" runat="server" Width="32px"></asp:TextBox> 
    <asp:TextBox ID="COLDATE" runat="server" Width="32px"></asp:TextBox>  
   
   
 </div>
  
   
 
<script type="text/javascript">
function CheckEmpty(source, args)
{
    var firstname = document.getElementById("ctl00_Content_sFirstName").value;
    var surname = document.getElementById("ctl00_Content_sSurname").value;
    var middlename = document.getElementById("ctl00_Content_sMiddleName").value;
    
    middlename = ValidatorTrim(middlename);
    firstname = ValidatorTrim(firstname);
    surname = ValidatorTrim(surname);
    
    if ((firstname.length > 0) || (middlename.length > 0) ||(surname.length > 0))
            args.IsValid = true;
    else
            args.IsValid = false;
        
}
function get_passportValue()
{
    var type = document.getElementById("ctl00_Content_DOCTYPE").value;
    return type;
}
    
function DOBClick()
{
     var a = get_passportValue();
     var winObj = null; 
     winObj = birthdayCalendarPicker("BIRTHDATE",a,document.getElementById("ctl00_Content_DOCTYPE").value,"N")
     winObj.focus();
   
}
function get_SEX_value()
{
    var sex_val;
for (var i=0; i < document.forms["aspnetForm"].ctl00$Content$SEX.length; i++)
   {
   if (document.forms["aspnetForm"].ctl00$Content$SEX[i].checked)
      {
        sex_val = document.forms["aspnetForm"].ctl00$Content$SEX[i].value;
      }
   }

   return sex_val;
}

 function ClientValidate(source, arguments)
   {
   var sexSelected = get_SEX_value();

      if (document.getElementById("ctl00_Content_TITLE").value=="MR"&&sexSelected=="F")
             arguments.IsValid=false;
      else if(document.getElementById("ctl00_Content_TITLE").value=="MRS"&&sexSelected=="M")
             arguments.IsValid=false;
      else if(document.getElementById("ctl00_Content_TITLE").value=="MISS"&&sexSelected=="M")
             arguments.IsValid=false;
      else
         arguments.IsValid=true;
   }
function CheckMaritalStatus(source, arguments)
{   

      if (document.getElementById("ctl00_Content_TITLE").value=="MRS"&&(document.getElementById("ctl00_Content_MARITALSTATUS").value=="1" ||document.getElementById("ctl00_Content_MARITALSTATUS").value== "3" || document.getElementById("ctl00_Content_MARITALSTATUS").value=="4"))
             arguments.IsValid=false;
      else if(document.getElementById("ctl00_Content_TITLE").value=="MISS"&&document.getElementById("ctl00_Content_MARITALSTATUS").value=="2")
             arguments.IsValid=false;      
      else
         arguments.IsValid=true;
 }
function CalPick(txtbox, status, text)
{
    
     var winObj = null; 
     winObj =  calendarPicker(txtbox, status, text);
     winObj.focus();
}

function Clear(datetxtbox)
{   
   var txtname = "ctl00_Content_"+datetxtbox;
   document.getElementById(txtname).value = "";
}

GetPcName();
</script>



</asp:Content>


