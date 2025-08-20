<%@ Page MasterPageFile="~/iden.master" Language="C#" AutoEventWireup="true" Inherits="EnrollmentIssuanceSite.Query" Codebehind="Query.aspx.cs" %>
<asp:Content ContentPlaceHolderID="Content" runat="server">
<asp:Panel ID="Panel1" runat="server" Height="28px" BackImageUrl="./images/bg.gif"
        Width="100%">
        <asp:Label ID="fly" runat="server" Height="16px" CssClass="HeaderMainTitle" ForeColor="DimGray" BackColor="Transparent" Width="353px" >Visa - Enrollment Enquiry</asp:Label></asp:Panel>
        <input id="FORMNO" type="hidden" runat="server"/>
        <table id="tbQuery" cellspacing="2"  cellpadding="0" width="98%" border="0" runat="server" >
            <tr>
                <td style="width: 8px;"> </td>               
                <td colspan="3" >
                <div id="PnlSearch" runat="server" class="PanelSearch">
                <table style="width: 100%">
                    <tr>
                        <td style="width: 4px; height: 10px">
                        </td>
                        <td style="width: 143px; height: 10px">
                            <asp:Label ID="Label32" runat="server" CssClass="Label" ForeColor="Red" Text="* Mandatory Field"></asp:Label></td>
                        <td colspan="2" style="height: 10px">
                        </td>
                    </tr>
                <tr>               
                    <td style="height: 22px; width: 4px;">
                    </td>
                    <td style="height: 22px; width: 143px;">
                        <asp:Label ID="Label4" runat="server" CssClass="Label" Width="57px">Search by</asp:Label><asp:RequiredFieldValidator
                                ID="RequiredFieldValidator2" runat="server" ControlToValidate="SEARCHBY" CssClass="Label"
                                ErrorMessage="Please select search category before pressing the <SEARCH> button" ForeColor="White">*</asp:RequiredFieldValidator></td>
                    <td style="height: 22px;" colspan="2">
                    <asp:DropDownList ID="SEARCHBY" runat="server" AutoPostBack="True" OnSelectedIndexChanged="SEARCHBY_SelectedIndexChanged" Width="171px" CssClass="Label">
                        <asp:ListItem Value="">-SELECT-</asp:ListItem>
                        <asp:ListItem Value="1">APPLICATION ID</asp:ListItem>
                        <asp:ListItem Value="2">PASSPORT NO</asp:ListItem>
                        <asp:ListItem Value="3">DOCUMENT NO</asp:ListItem>                       
                        <asp:ListItem Value="4">NAME &amp; DATE OF BIRTH</asp:ListItem>                        
                    </asp:DropDownList></td>
               
                </tr>
                <tr id="trSearchValue" runat="server" visible="false">
                    <td style="height: 22px; width: 4px;">
                    </td>
                    <td style="height: 22px; width: 143px;">
                        <asp:Label ID="lblName" runat="server" CssClass="Label">Application ID</asp:Label><asp:Label
                            ID="Label31" runat="server" CssClass="Label" EnableViewState="False" ForeColor="Red">*</asp:Label></td>
                    <td style="height: 22px;" colspan="2">
                        <asp:TextBox ID="SEARCHVALUE" runat="server" Width="165px" EnableViewState="False"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RFVAppID" runat="server" ControlToValidate="SEARCHVALUE"
                            CssClass="Label" ErrorMessage="Please fill in Application ID" ForeColor="White">*</asp:RequiredFieldValidator></td>
                </tr>
                <tr runat="server" visible="false" id="trFirstname">
                    <td style="width: 4px; height: 22px">
                    </td>
                    <td style="width: 143px; height: 22px">
                        <asp:Label ID="Label15" runat="server" CssClass="Label" Width="63px">First Name</asp:Label>&nbsp;
                        <asp:CustomValidator ID="CustomValidator1" runat="server" ClientValidationFunction="CheckEmpty"
                            ControlToValidate="SEARCHFIRST" ErrorMessage="Please enter required data before pressing the <SEARCH> button"
                            ForeColor="White" OnServerValidate="CustomValidator1_ServerValidate" ValidateEmptyText="True">*</asp:CustomValidator></td>
                    <td colspan="2" style="height: 22px">
                        <asp:TextBox ID="SEARCHFIRST" runat="server" Width="165px" EnableViewState="False"></asp:TextBox></td>
                </tr>
                <tr runat="server" visible="false" id="trMiddlename">
                    <td style="width: 4px; height: 22px">
                    </td>
                    <td style="width: 143px; height: 22px">
                        <asp:Label ID="Label16" runat="server" CssClass="Label">Middle Name</asp:Label></td>
                    <td colspan="2" style="height: 22px">
                        <asp:TextBox ID="SEARCHMIDDLE" runat="server" Width="165px" EnableViewState="False"></asp:TextBox></td>
                </tr>
                <tr id="trDOB" runat="server" visible="false">
                    <td style="height: 22px; width: 4px;">
                    </td>
                    <td style="width: 143px; height: 22px">
                        <asp:Label ID="Label1" runat="server" CssClass="Label" Text="Date of Birth" Width="70px"></asp:Label>
                    </td>
                    <td colspan="2" style="height: 22px">
                        <asp:TextBox ID="BIRTHDATE" runat="server" ReadOnly="True" Width="164px"></asp:TextBox>
                        <asp:ImageButton ID="ImageButton6" runat="server" CausesValidation="False" ImageUrl="~/images/button.gif"
                            OnClientClick="CalPick('BIRTHDATE','X','Applicant Birthdate');return false;" /></td>
                 </tr>
                    <tr runat="server" visible="false" id="trBirthCountry">
                        <td style="width: 4px; height: 22px">
                        </td>
                        <td style="width: 143px; height: 22px">
                            <asp:Label ID="lblCountry" runat="server" CssClass="Label" Text="Country of Issue" Width="91px"></asp:Label><asp:Label
                                ID="Label27" runat="server" CssClass="Label" EnableViewState="False" ForeColor="Red">*</asp:Label>
                            <asp:RequiredFieldValidator ID="RFVCountry" runat="server" ControlToValidate="DDPASSPORTPOI"
                                CssClass="Label" ErrorMessage="Country of Issue is mandatory" ForeColor="White">*</asp:RequiredFieldValidator></td>
                        <td colspan="2" style="height: 22px">
                            <asp:DropDownList ID="DDPASSPORTPOI" runat="server" CssClass="Label" Width="272px">
                            </asp:DropDownList></td>
                    </tr>
                <tr>
                    <td style="height: 22px; width: 4px;">  </td>
                    <td style="width: 143px; height: 22px"><asp:TextBox ID="TextBox1" runat="server" Style="display:none; visibility:hidden;"></asp:TextBox>  </td>
                  
                    <td colspan="2" style="height: 22px">
                        <asp:Button ID="btnSearch" runat="server" Text="Search" TabIndex="-1" OnClick="btnSearch_Click"></asp:Button>
                        <input id="btnClear" runat="server" style="width: 63px" type="reset" value="Clear" /></td>
                                    
               </tr>
                    <tr>
                        <td style="width: 4px; height: 22px">
                        </td>
                        <td style="width: 143px; height: 22px">
                        </td>
                        <td colspan="2" style="height: 22px">
                            <asp:Label ID="lblMsgSearch" runat="server" CssClass="Label" EnableViewState="False"
                                ForeColor="Blue" Visible="False"></asp:Label><asp:Label ID="lblSearchError" runat="server" CssClass="Label" EnableViewState="False" ForeColor="Red"
                                Visible="False"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="width: 4px; height: 19px">
                        </td>
                        <td colspan="3" style="height: 19px">
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="Label" ShowMessageBox="True"
                                ShowSummary="False" />
                        </td>
                    </tr>
            </table>
            </div>
            </td>
        </tr>        
        </table>    
        <table id="tbDataGrid" cellspacing="2"  cellpadding="0" width="98%" border="0" runat="server" visible="false">
 
            <tr>
                <td style="width: 8px;"> </td>               
                <td colspan="3" >
                <div id="Div2" runat="server" class="PanelSearch">
                <table width="98%" border="0" cellspacing="2" cellpadding="0" id="Table1"  runat="server">
                    <tr>
                        <td style="width: 8px">
                        </td>
                        <td colspan="6">
                            <asp:GridView ID="dgByName" runat="server" AllowPaging="True" CellPadding="3" CssClass="DataGrid"
                                ForeColor="#333333" GridLines="None" PageSize="5" Width="785px" OnPageIndexChanging="dgByName_PageIndexChanging" AllowSorting="True" AutoGenerateColumns="False" OnRowCommand="dgByName_RowCommand" EnableViewState="true">
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
                                        <asp:Label ID="lblNationality" runat="server" Text='<%# Eval("Nationality") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" Width="70px" />
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
 <table id="tbInfo" cellspacing="2"  cellpadding="0" width="98%" border="0" runat="server" visible="false">
           
            <tr>
                <td style="height: 15px; width: 8px;">
                </td>
                <td colspan="3" style="height: 19px; background-color: #c6efef;">
                    &nbsp;
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
                        <td style="width: 132px">
                        </td>
                        <td style="width: 10px">
                        </td>
                        <td style="width: 288px">
                        </td>
                        <td style="width: 136px">
                        </td>
                        <td style="width: 9px">
                        </td>
                        <td>
                        </td>
                    </tr>
                   <tr>
                       <td style="width: 8px">
                       </td>
                       <td style="width: 132px">
                           <asp:Label ID="Label5" runat="server" CssClass="LabelHeadLine" Text="Application details"></asp:Label></td>
                       <td style="width: 10px">
                       </td>
                       <td style="width: 288px">
                       </td>
                       <td align="left" colspan="2" rowspan="1">
                       </td>
                       <td>
                       </td>
                   </tr>
                   <tr>
                       <td style="width: 8px">
                       </td>
                       <td style="width: 132px">
                           <asp:Label ID="Label2" runat="server" CssClass="Label" Text="Application ID"></asp:Label></td>
                       <td style="width: 10px">:
                       </td>
                       <td style="width: 288px">
                       <asp:Label ID="APPID" runat="server" CssClass="Label" Width="200px"></asp:Label></td>
                       <td align="left" colspan="2" rowspan="8" valign="top">
                            <asp:Image ID="imgPhoto" runat="server" BorderColor="Silver" BorderStyle="Solid"
                                BorderWidth="1px" CssClass="ImgBorder" Height="110px" ImageUrl="~/images/spacer.gif"
                                Visible="true" Width="80px"/></td>
                       <td>
                       </td>
                   </tr>
                    <tr>
                        <td style="width: 8px">
                        </td>
                        <td style="width: 132px">
                            <asp:Label ID="Label3" runat="server" CssClass="Label" Text="Application Status"></asp:Label></td>
                        <td style="width: 10px">
                            :</td>
                        <td style="width: 288px">
                            <asp:Label ID="STAGECODE" runat="server" CssClass="Label" Width="261px"></asp:Label></td>
                        <td>
                          </td>
                    </tr>           
                    <tr>
                        <td style="width: 8px">
                        </td>
                        <td style="width: 132px;">
                            <asp:Label ID="Label12" runat="server" CssClass="Label" Text="Applied Visa Type"></asp:Label></td>
                        <td style="width: 10px;">
                            :</td>
                        <td style="width: 288px;">
                            <asp:Label ID="DOCTYPE" runat="server" CssClass="Label" Width="172px"></asp:Label></td>
                        <td>
                            </td>
                    </tr>
                   <tr>
                       <td style="width: 8px">
                       </td>
                       <td style="width: 132px">
                           <asp:Label ID="Label24" runat="server" CssClass="Label" Text="Applied Entry Type"></asp:Label></td>
                       <td style="width: 10px">
                           :</td>
                       <td style="width: 288px">
                           <asp:Label ID="SUBDOCTYPE" runat="server" CssClass="Label" Width="180px"></asp:Label></td>
                       <td style="height: 9px">
                       </td>
                   </tr>
                   <tr>
                       <td style="width: 8px">
                       </td>
                       <td style="width: 132px">
                           <asp:Label ID="Label6" runat="server" CssClass="Label" Text="Approved Visa Type"></asp:Label></td>
                       <td style="width: 10px">
                           :</td>
                       <td style="width: 288px">
                           <asp:Label ID="APPROVEDDOCTYPE" runat="server" CssClass="Label" Width="172px"></asp:Label></td>
                       <td style="height: 9px">
                       </td>
                   </tr>
                   <tr>
                       <td style="width: 8px">
                       </td>
                       <td style="width: 132px">
                           <asp:Label ID="Label7" runat="server" CssClass="Label" Text="Approved Entry Type"></asp:Label></td>
                       <td style="width: 10px">
                           :</td>
                       <td style="width: 288px">
                           <asp:Label ID="APPROVEDENTRYTYPE" runat="server" CssClass="Label" Width="180px"></asp:Label></td>
                       <td style="height: 9px">
                       </td>
                   </tr>
       
        <tr id="trRejectReason" runat="server">
            <td style="width: 8px">
            </td>
            <td style="width: 132px">
                            <asp:Label ID="Label13" runat="server" CssClass="Label" Text="Purpose of Application" Width="141px"></asp:Label></td>
            <td style="width: 10px">
                :</td>
            <td style="width: 288px">
                            <asp:Label ID="APPREASON" runat="server" CssClass="Label" Width="172px"></asp:Label></td>
            <td>
            </td>
        </tr>
      
        <tr>
            <td style="width: 8px">
            </td>
            <td style="width: 132px">
                <asp:label id="Label8" runat="server" cssclass="Label" text="Date of Application"
                    width="141px"></asp:label>
            </td>
            <td style="width: 10px">
                :</td>
            <td style="width: 288px">
                <asp:label id="ENROLDATE" runat="server" cssclass="Label" width="172px"></asp:label>
            </td>
            <td>
            </td>
        </tr>
                   <tr>
                       <td style="width: 8px">
                       </td>
                       <td colspan="2">
                       </td>
                       <td style="width: 288px">
                       </td>
                       <td align="left" colspan="2" rowspan="1" valign="top">
                       </td>
                       <td align="left" colspan="2" rowspan="1" valign="top">
                       </td>
                       <td>
                       </td>
                   </tr>
                   <tr>
                       <td style="width: 8px; height: 19px">
                       </td>
                       <td style="width: 132px; height: 19px">
                           <asp:Label ID="Label9" runat="server" CssClass="LabelHeadLine" Text="Personal details"></asp:Label></td>
                       <td style="width: 10px; height: 19px">
                       </td>
                       <td style="width: 288px; height: 19px">
                       </td>
                       <td style="width: 136px; height: 19px">
                           <asp:Label ID="PassportTitle" runat="server" CssClass="LabelHeadLine" Text="Passport Details"></asp:Label></td>
                       <td style="width: 9px; height: 19px">
                       </td>
                       <td style="height: 19px">
                       </td>
                   </tr>
               
        <tr>
                        <td style="width: 8px; height: 19px">
                        </td>
                        <td style="width: 132px; height: 19px">
                            <asp:Label ID="Label10" runat="server" CssClass="Label" Text="Surname"></asp:Label></td>
                        <td style="width: 10px; height: 19px">
                            :</td>
                        <td style="width: 288px; height: 19px">
                           <asp:Label ID="SURNAME" runat="server" CssClass="Label" Width="172px"></asp:Label></td>
                        <td colspan="3" rowspan="5" valign="top">
                            <table border="0" cellpadding="0" cellspacing="2" style="width: 100%">
                                <tr id="trPassportNo" runat="server" visible="false">
                                    <td style="width: 22px; height: 19px">
                                        <asp:Label ID="Label14" runat="server" CssClass="Label" Text="Passport No" Width="81px"></asp:Label></td>
                                    <td style="width: 6px; height: 19px">
                                        :</td>
                                    <td style="width: 100px; height: 19px">
                                        <asp:Label ID="PASSPORTNO" runat="server" CssClass="Label" Width="244px"></asp:Label></td>
                                </tr>
                                <tr id="trPassportDOI" runat="server" visible="false">
                                    <td style="width: 22px">
                                        <asp:Label ID="Label17" runat="server" CssClass="Label" Text="Date of Issue" Width="91px"></asp:Label></td>
                                    <td style="width: 6px">
                                        :</td>
                                    <td style="width: 100px">
                                        <asp:Label ID="PASSPORTDOI" runat="server" CssClass="Label" Width="244px"></asp:Label></td>
                                </tr>
                                <tr id="trPassportDOE" runat="server" visible="false">
                                    <td style="width: 22px">
                                        <asp:Label ID="Label18" runat="server" CssClass="Label" Text="Date of Expiry" Width="91px"></asp:Label></td>
                                    <td style="width: 6px">
                                        :</td>
                                    <td style="width: 100px">
                                        <asp:Label ID="PASSPORTDOE" runat="server" CssClass="Label" Width="244px"></asp:Label></td>
                                </tr>
                                <tr id="trPassportCOI" runat="server" visible="false">
                                    <td style="width: 22px">
                                        <asp:Label ID="Label19" runat="server" CssClass="Label" Text="Country of Issue" Width="107px"></asp:Label></td>
                                    <td style="width: 6px">
                                        :</td>
                                    <td style="width: 100px">
                                        <asp:Label ID="PASSPORTCOI" runat="server" CssClass="Label" Width="244px"></asp:Label></td>
                                </tr>
                            </table>
                            </td>
        </tr>
        <tr>
                        <td style="width: 8px">
                        </td>
                        <td style="width: 132px">
                            <asp:Label ID="Label20" runat="server" CssClass="Label" Text="First Name"></asp:Label></td>
                        <td style="width: 10px">
                            :</td>
                        <td style="width: 288px">
                            <asp:Label ID="FIRSTNAME" runat="server" CssClass="Label" Width="172px"></asp:Label></td>
        </tr>
        <tr>
                        <td style="width: 8px">
                        </td>
                        <td style="width: 132px">
                            <asp:Label ID="Label21" runat="server" CssClass="Label" Text="Middle Name"></asp:Label></td>
                        <td style="width: 10px">
                            :</td>
                        <td style="width: 288px">
                            <asp:Label ID="MIDDLENAME" runat="server" CssClass="Label" Width="172px"></asp:Label></td>
        </tr>         
                   <tr>
                       <td style="width: 8px; height: 19px;">
                       </td>
                       <td style="width: 132px; height: 19px;">
                           <asp:Label ID="Label22" runat="server" CssClass="Label" Text="Date of Birth"></asp:Label></td>
                       <td style="width: 10px; height: 19px;">
                           :</td>
                       <td style="width: 288px; height: 19px;">
                           <asp:Label ID="DOB" runat="server" CssClass="Label" Width="172px"></asp:Label></td>
                   </tr>        
                   <tr>
                       <td style="width: 8px">
                       </td>
                       <td style="width: 132px">
                            <asp:Label ID="Label23" runat="server" CssClass="Label" Text="Sex"></asp:Label></td>
                       <td style="width: 10px">
                           :</td>
                       <td style="width: 288px">
                            <asp:Label ID="SEX" runat="server" CssClass="Label" Width="172px"></asp:Label></td>
                   </tr>
                   <tr>
                       <td style="width: 8px; height: 19px">
                       </td>
                       <td style="width: 132px; height: 19px">
                            <asp:Label ID="Label25" runat="server" CssClass="Label" Text="Place of Birth"></asp:Label></td>
                       <td style="width: 10px; height: 19px">
                           :</td>
                       <td style="width: 288px; height: 19px">
                            <asp:Label ID="BIRTHPLACE" runat="server" CssClass="Label" Width="172px"></asp:Label></td>
                       <td style="width: 136px; height: 19px">
                           <asp:Label ID="VisaTitle" runat="server" CssClass="LabelHeadLine" Text="Visa Details" Visible="false"></asp:Label></td>
                       <td style="width: 9px; height: 19px">
                           </td>
                       <td style="height: 19px">
                           </td>
                   </tr>
                   <tr>
                       <td style="width: 8px; height: 19px">
                       </td>
                       <td style="width: 132px; height: 19px">
                            <asp:Label ID="NationalityLbl" runat="server" CssClass="Label" Text="Nationality"></asp:Label></td>
                       <td style="width: 10px; height: 19px">
                           :</td>
                       <td style="width: 288px; height: 19px">
                            <asp:Label ID="NATIONALITY" runat="server" CssClass="Label" Width="172px"></asp:Label></td>
                       <td colspan="3" rowspan="5" valign="top">
                         <table border="0" cellpadding="0" cellspacing="2" style="width: 100%">
                                <tr id="trVisaNo" runat="server" visible="false">
                                    <td style="width: 22px; height: 19px">
                                        <asp:Label ID="Label26" runat="server" CssClass="Label" Text="Visa No" Width="81px"></asp:Label></td>
                                    <td style="width: 6px; height: 19px">
                                        :</td>
                                    <td style="width: 100px; height: 19px">
                                        <asp:Label ID="VISANO" runat="server" CssClass="Label" Width="244px"></asp:Label></td>
                                </tr>
                                <tr id="trVisaDOI" runat="server" visible="false">
                                    <td style="width: 22px">
                                        <asp:Label ID="Label28" runat="server" CssClass="Label" Text="Date of Issue" Width="91px"></asp:Label></td>
                                    <td style="width: 6px">
                                        :</td>
                                    <td style="width: 100px">
                                        <asp:Label ID="VISADOI" runat="server" CssClass="Label" Width="244px"></asp:Label></td>
                                </tr>
                                <tr id="trVisaDOE" runat="server" visible="false">
                                    <td style="width: 22px">
                                        <asp:Label ID="Label29" runat="server" CssClass="Label" Text="Date of Expiry" Width="91px"></asp:Label></td>
                                    <td style="width: 6px">
                                        :</td>
                                    <td style="width: 100px">
                                        <asp:Label ID="VISADOE" runat="server" CssClass="Label" Width="244px"></asp:Label></td>
                                </tr>
                                <tr id="trVisaPOI" runat="server" visible="false">
                                    <td style="width: 22px">
                                        <asp:Label ID="Label30" runat="server" CssClass="Label" Text="Place of Issue" Width="107px"></asp:Label></td>
                                    <td style="width: 6px">
                                        :</td>
                                    <td style="width: 100px">
                                        <asp:Label ID="VISAPOI" runat="server" CssClass="Label" Width="244px"></asp:Label></td>
                                </tr>
                            </table>
                       
                       
                       
                       </td>
                   </tr>
         
                
                   <tr>
                       <td style="width: 8px; height: 15px">
                       </td>
                       <td colspan="3">
                             </td>
                   </tr>
                   <tr>
                       <td style="width: 8px; height: 15px">
                       </td>
                       <td colspan="3">
                       </td>
                   </tr>
                   <tr>
                       <td style="width: 8px; height: 15px">
                       </td>
                       <td colspan="3">
                       </td>
                   </tr>
                   <tr>
                       <td style="width: 8px; height: 15px">
                       </td>
                       <td colspan="3">
                       </td>
                   </tr>
         <tr>
             <td style="width: 8px; height: 15px">
             </td>
             <td colspan="6">
                       
                           <asp:Label ID="lblResult" runat="server" CssClass="Label" Text="Transaction Completed!" ForeColor="Blue" Visible="False" EnableViewState="False"></asp:Label></td>
         </tr>
        <tr>
            <td style="width: 8px">
            </td>
            <td colspan="5">
                &nbsp;</td>
            
            <td>
            </td>
        </tr>
                </table>
                </div>
              </td>
          </tr>        
      </table>
       <asp:HiddenField ID="txtCompName" runat="server" />   
<script type="text/javascript">
function CalPick(txtbox, status, text)
{
     var winObj = null; 
     winObj =  calendarPicker(txtbox, status, text);
     winObj.focus();
}


function Clear()
{
  
    var src = document.getElementById("ctl00_Content_SEARCHBY").value;
   

    if (src != "")
    {
          document.getElementById("ctl00_Content_SEARCHBY").value = "";
    }
    
    
    if (src == "4")
    {
        document.getElementById("ctl00_Content_SEARCHVALUE").value = "";
        document.getElementById("ctl00_Content_SEARCHFIRST").value = "";
        document.getElementById("ctl00_Content_SEARCHMIDDLE").value = "";
        document.getElementById("ctl00_Content_SEARCHBY").value = "";
    }
    else if(src == "1" || src == "2" || src == "3")
    {
        document.getElementById("ctl00_Content_SEARCHVALUE").value = "";
        
    }
    else if (src == "5")
    {
        document.getElementById("ctl00_Content_SEARCHVALUE").value = "";
        document.getElementById("ctl00_Content_SEARCHFIRST").value = "";
        document.getElementById("ctl00_Content_SEARCHMIDDLE").value = "";
        document.getElementById("ctl00_Content_SEARCHBY").value = "";
        document.getElementById("ctl00_Content_BIRTHDATE").value = "";
    }
    else
    {
        document.getElementById("ctl00_Content_SEARCHVALUE").value = "";
    }

}
function CheckEmpty(source, args)
{
    var firstname = document.getElementById("ctl00_Content_SEARCHFIRST").value;
    var surname = document.getElementById("ctl00_Content_SEARCHVALUE").value;
    var middlename = document.getElementById("ctl00_Content_SEARCHMIDDLE").value; 
   
    
    middlename = ValidatorTrim(middlename);
    firstname = ValidatorTrim(firstname);
    surname = ValidatorTrim(surname);
    
    if ((firstname.length > 0) || (middlename.length > 0) ||(surname.length > 0))
            args.IsValid = true;
    else
            args.IsValid = false;
        
}
GetPcName();
</script>


</asp:Content>

