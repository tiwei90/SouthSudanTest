<%@ Page MasterPageFile="~/iden.master" Language="C#" AutoEventWireup="true" Inherits="EnrollmentIssuanceSite.UpdateProfile" Codebehind="UpdateProfile.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
<asp:Panel ID="Panel1" runat="server" Height="28px" BackImageUrl="./images/bg.gif"
        Width="100%">
        <asp:Label ID="fly" runat="server" Height="16px" CssClass="HeaderMainTitle" ForeColor="DimGray" BackColor="Transparent" Width="353px" >E-ID - Update Profile</asp:Label></asp:Panel>
        <input id="FORMNO" type="hidden" runat="server"/>
        <input id="FORMNO2" type="hidden" runat="server"/>
         <input id="SearchType" type="hidden" runat="server"/>
        <input id="AppCatID" type="hidden" runat="server"/>
         <input id="APPTEMP" type="hidden" runat="server"/>
        <table id="tbQuery" cellspacing="2"  cellpadding="0" width="98%" border="0" runat="server">
            <tr>
                <td style="width: 8px;"> </td>               
                <td colspan="3" >
                <div id="PnlSearch" runat="server" class="PanelSearch">
                <table style="width: 100%">
                    <tr>
                        <td style="width: 8px; height: 10px">
                        </td>
                        <td style="width: 143px; height: 10px">
                            <asp:Label ID="Label32" runat="server" CssClass="Label" ForeColor="Red" Text="* Mandatory Field"></asp:Label></td>
                        <td colspan="2" style="height: 10px">
                        </td>
                    </tr>
                <tr>               
                    <td style="height: 22px; width: 8px;">
                    </td>
                    <td style="height: 22px; width: 143px;">
                        <asp:Label ID="Label4" runat="server" CssClass="Label" Width="58px">Search by</asp:Label><asp:Label
                            ID="Label31" runat="server" CssClass="Label" EnableViewState="False" ForeColor="Red">*</asp:Label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="SEARCHBY"
                            CssClass="Label" ErrorMessage="Please select search category before pressing the <SEARCH> button" ForeColor="White">*</asp:RequiredFieldValidator></td>
                    <td style="height: 22px;" colspan="2">
                    <asp:DropDownList ID="SEARCHBY" runat="server" AutoPostBack="True" OnSelectedIndexChanged="SEARCHBY_SelectedIndexChanged" Width="171px" CssClass="Label">
                        <asp:ListItem Value="">-SELECT-</asp:ListItem>
                        <asp:ListItem Value="1">APPLICATION ID</asp:ListItem>
                        <asp:ListItem Value="2">PASSPORT NO</asp:ListItem>
                        <asp:ListItem Value="4">NAME & DATE OF BIRTH</asp:ListItem>                       
                    </asp:DropDownList></td>
               
                </tr>
                <tr id="trSearchValue" runat="server" visible="false">
                    <td style="height: 22px; width: 8px;">
                    </td>
                    <td style="height: 22px; width: 143px;">
                        <asp:Label ID="lblName" runat="server" CssClass="Label" Width="79px">Application ID</asp:Label><asp:Label
                            ID="Label24" runat="server" CssClass="Label" EnableViewState="False" ForeColor="Red">*</asp:Label></td>
                    <td style="height: 22px;" colspan="2">
                        <asp:TextBox ID="SEARCHVALUE" runat="server" Width="165px" EnableViewState="False"></asp:TextBox>
                        <asp:RequiredFieldValidator
                            ID="RFVAppID" runat="server" ControlToValidate="SEARCHVALUE" CssClass="Label" ForeColor="White">*</asp:RequiredFieldValidator></td>
                </tr>
                <tr runat="server" visible="false" id="trFirstname">
                    <td style="width: 8px; height: 22px">
                    </td>
                    <td style="width: 143px; height: 22px">
                        <asp:Label ID="Label15" runat="server" CssClass="Label" Width="64px">First Name</asp:Label><asp:Label
                            ID="Label28" runat="server" CssClass="Label" EnableViewState="False" ForeColor="Red">*</asp:Label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="SEARCHFIRST"
                            CssClass="Label" ErrorMessage="First name is mandatory" ForeColor="White">*</asp:RequiredFieldValidator></td>
                    <td colspan="2" style="height: 22px">
                        <asp:TextBox ID="SEARCHFIRST" runat="server" Width="165px" EnableViewState="False"></asp:TextBox></td>
                </tr>
                <tr runat="server" visible="false" id="trMiddlename">
                    <td style="width: 8px; height: 22px">
                    </td>
                    <td style="width: 143px; height: 22px">
                        <asp:Label ID="Label16" runat="server" CssClass="Label">Middle Name</asp:Label></td>
                    <td colspan="2" style="height: 22px">
                        <asp:TextBox ID="SEARCHMIDDLE" runat="server" Width="165px" EnableViewState="False"></asp:TextBox></td>
                </tr>
                <tr id="trDOB" runat="server" visible="false">
                    <td style="height: 22px; width: 8px;">
                    </td>
                    <td style="width: 143px; height: 22px">
                        <asp:Label ID="Label1" runat="server" CssClass="Label" Text="Date of Birth" Width="70px"></asp:Label><asp:Label
                            ID="Label27" runat="server" CssClass="Label" EnableViewState="False" ForeColor="Red">*</asp:Label>
                        <asp:RequiredFieldValidator
                            ID="RequiredFieldValidator1" runat="server" ControlToValidate="BIRTHDATE" CssClass="Label"
                            ErrorMessage="Please select date of birth" ForeColor="White">*</asp:RequiredFieldValidator></td>
                    <td colspan="2" style="height: 22px">
                        <asp:TextBox ID="BIRTHDATE" runat="server" ReadOnly="True" Width="164px" EnableViewState="False"></asp:TextBox>
                        <asp:ImageButton ID="ImageButton6" runat="server" CausesValidation="False" ImageUrl="~/images/button.gif"
                            OnClientClick="CalPick('BIRTHDATE','X','Applicant Birthdate');return false;" /></td>
                </tr>
                  <tr id="trBirthCountry" runat="server" visible="false">
                    <td style="width: 8px; height: 21px">
                    </td>
                    <td style="width: 143px; height: 21px">
                        <asp:Label ID="Label22" runat="server" CssClass="Label" Text="Country of Issue" Width="90px"></asp:Label><asp:Label
                            ID="Label25" runat="server" CssClass="Label" EnableViewState="False" ForeColor="Red">*</asp:Label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="BIRTHCOUNTRYDD"
                            CssClass="Label" ErrorMessage="Country of issue is mandatory" ForeColor="White">*</asp:RequiredFieldValidator></td>
                    <td colspan="2" style="height: 21px">
                        <asp:DropDownList ID="BIRTHCOUNTRYDD" runat="server" CssClass="Label" Width="272px">
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td style=" width: 8px;">
                    </td>
                    <td style="width: 143px; ">
                        </td>
                    <td colspan="2"><asp:TextBox ID="TextBox1" runat="server" Style="display:none; visibility:hidden;"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="height: 22px; width: 8px;">  </td>
                    <td style="width: 143px; height: 22px">  </td>
                  
                    <td colspan="2" style="height: 22px">
                        <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click"></asp:Button>
                        <input id="btnClear" runat="server" type="button" value="Clear" tabindex="1" onclick="Clear();" causesvalidation="false" disabled="disabled" />
                        </td>                   
                                    
               </tr>
                    <tr>
                        <td style="width: 8px; height: 22px">
                        </td>
                        <td style="width: 143px; height: 22px">
                        </td>
                        <td colspan="2" style="height: 22px">
                        <asp:Label ID="lblMsgSearch" runat="server" CssClass="Label" ForeColor="Blue" Visible="False" EnableViewState="False"></asp:Label><asp:Label
                            ID="lblSearchError" runat="server" CssClass="Label" EnableViewState="False" ForeColor="Red"
                            Visible="False"></asp:Label></td>
                    </tr>
               <tr>
                    <td style="width: 8px; height: 19px;">
                    </td>
                    <td colspan="3" style="height: 19px">
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="Label" ShowMessageBox="True" ShowSummary="False" />
                        &nbsp;&nbsp;
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
                                  <asp:TemplateField HeaderText="DOCUMENT TYPE">
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
                    <asp:Label ID="Label2" runat="server" CssClass="LabelHeadGreen" Text="Applicant Information"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 8px;"> </td>               
                <td colspan="3">
                <div id="Div1" runat="server" class="PanelSearch">
               <table width="98%" border="0" cellspacing="2" cellpadding="0" id="Table2"  runat="server">
                    
                   <tr>
                       <td style="width: 128px">
                       </td>
                       <td colspan="2">
                           <asp:Label ID="Label14" runat="server" CssClass="LabelHeadLine" Text="Personal details"></asp:Label></td>
                       <td style="width: 288px">
                       </td>
                       <td align="left" colspan="2" rowspan="1" valign="top">
                           <asp:Label ID="Label3" runat="server" CssClass="LabelHeadLine" Text="Application details"></asp:Label></td>
                       <td>
                       </td>
                   </tr>
                   <tr>
                       <td style="width: 128px; height: 19px">
                       </td>
                       <td style="width: 146px; height: 19px">
                            <asp:Label ID="Label5" runat="server" CssClass="Label" Text="Surname"></asp:Label></td>
                       <td style="width: 10px; height: 19px">
                           :</td>
                       <td style="width: 288px; height: 19px">
                           <asp:Label ID="SURNAME" runat="server" CssClass="Label" Width="172px"></asp:Label></td>
                       <td style="width: 140px; height: 19px">
                            <asp:Label ID="Label6" runat="server" CssClass="Label" Text="Application ID" Width="99px"></asp:Label></td>
                       <td style="width: 9px; height: 19px">
                           :</td>
                       <td style="height: 19px">
                            <asp:Label ID="APPID" runat="server" CssClass="Label" Width="138px"></asp:Label></td>
                   </tr>
                   <tr>
                       <td style="width: 128px; height: 19px">
                       </td>
                       <td style="width: 146px; height: 19px">
                            <asp:Label ID="Label7" runat="server" CssClass="Label" Text="First Name"></asp:Label></td>
                       <td style="width: 10px; height: 19px">
                           :</td>
                       <td style="width: 288px; height: 19px">
                            <asp:Label ID="FIRSTNAME" runat="server" CssClass="Label" Width="172px"></asp:Label></td><td style="width: 140px; height: 19px">
                                <asp:Label ID="Label8" runat="server" CssClass="Label" Text="Application Status"
                                    Width="99px"></asp:Label></td>
                       <td style="width: 9px; height: 19px">
                           :</td><td style="height: 19px">
                               <asp:Label ID="STAGECODE" runat="server" CssClass="Label" Width="260px"></asp:Label></td>
                   </tr>
                   <tr>
                       <td style="width: 128px; height: 19px">
                       </td>
                       <td style="width: 146px; height: 19px">
                            <asp:Label ID="Label9" runat="server" CssClass="Label" Text="Middle Name" Width="73px"></asp:Label></td>
                       <td style="width: 10px; height: 19px">
                           :</td>
                       <td style="width: 288px; height: 19px">
                            <asp:Label ID="MIDDLENAME" runat="server" CssClass="Label" Width="172px"></asp:Label></td>
                       <td style="width: 140px; height: 19px">
                            <asp:Label ID="Label12" runat="server" CssClass="Label" Text="Document Type"></asp:Label></td>
                       <td style="width: 9px; height: 19px">
                           :</td>
                       <td style="height: 19px">
                            <asp:Label ID="DOCTYPE" runat="server" CssClass="Label" Width="188px"></asp:Label></td>
                   </tr>
                   <tr>
                       <td style="width: 128px; height: 19px">
                       </td>
                       <td style="width: 146px; height: 19px">
                            <asp:Label ID="Label10" runat="server" CssClass="Label" Text="Sex"></asp:Label></td>
                       <td style="width: 10px; height: 19px">
                           :</td>
                       <td style="width: 288px; height: 19px">
                            <asp:Label ID="SEX" runat="server" CssClass="Label" Width="172px"></asp:Label></td>
                       <td style="width: 140px; height: 19px">
                           <asp:Label ID="Label11" runat="server" CssClass="Label" Text="Document Sub Type"
                               Width="135px"></asp:Label></td>
                       <td style="width: 9px; height: 19px">
                           :</td>
                       <td style="height: 19px">
                           <asp:Label ID="SUBTYPE" runat="server" CssClass="Label" Width="255px"></asp:Label></td>
                   </tr>
                   <tr>
                       <td style="width: 128px; height: 19px">
                       </td>
                       <td style="width: 146px; height: 19px">
                            <asp:Label ID="Label13" runat="server" CssClass="Label" Text="Place of Birth"></asp:Label></td>
                       <td style="width: 10px; height: 19px">
                           :</td>
                       <td style="width: 288px; height: 19px">
                            <asp:Label ID="BIRTHPLACE" runat="server" CssClass="Label" Width="229px"></asp:Label></td>
                       <td style="width: 140px; height: 19px">
                            <asp:Label ID="Label17" runat="server" CssClass="Label" Text="Purpose of Application" Width="133px"></asp:Label></td>
                       <td style="width: 9px; height: 19px">:
                       </td>
                       <td style="height: 19px">
                            <asp:Label ID="APPREASON" runat="server" CssClass="Label" Width="200px"></asp:Label></td>
                   </tr>
                   <tr>
                       <td style="width: 128px; height: 19px">
                       </td>
                       <td style="width: 146px; height: 19px">
                           <asp:Label ID="Label19" runat="server" CssClass="Label" Text="Country of Birth"></asp:Label></td>
                       <td style="width: 10px; height: 19px">
                           :</td>
                       <td style="width: 288px; height: 19px">
                           <asp:Label ID="BIRTHCOUNTRY" runat="server" CssClass="Label" Width="226px"></asp:Label></td>
                       <td style="width: 140px; height: 19px">
                            <asp:Label ID="Label18" runat="server" Text="Date of Application" CssClass="Label"></asp:Label></td>
                       <td style="width: 9px; height: 19px">:
                       </td>
                       <td style="height: 19px">
                          <asp:Label ID="ENROLTIME" runat="server" CssClass="Label" Width="172px"></asp:Label></td>
                   </tr>
                   <tr>
                       <td style="width: 128px; height: 19px">
                       </td>
                       <td style="width: 146px; height: 19px">
                            <asp:Label ID="Label20" runat="server" CssClass="Label" Text="Nationality" Width="124px"></asp:Label></td>
                       <td style="width: 10px; height: 19px">
                           :</td>
                       <td style="width: 288px; height: 19px">
                           <asp:Label ID="NATIONALITY" runat="server" CssClass="Label" Width="225px"></asp:Label></td>
                       <td style="width: 140px; height: 19px">
                       </td>
                       <td style="width: 9px; height: 19px">
                       </td>
                       <td style="height: 19px">
                       </td>
                   </tr>
                   <tr>
                       <td style="width: 128px; height: 19px">
                       </td>
                       <td style="width: 146px; height: 19px">
                           <asp:Label ID="Label21" runat="server" CssClass="Label" Text="Passport No" Width="124px"></asp:Label></td>
                       <td style="width: 10px; height: 19px">
                           :</td>
                       <td style="width: 288px; height: 19px">
                            <asp:Label ID="PASSPORTNO" runat="server" CssClass="Label" Width="172px">-</asp:Label></td>
                       <td style="width: 140px; height: 19px">
                       </td>
                       <td style="width: 9px; height: 19px">
                       </td>
                       <td style="height: 19px">
                       </td>
                   </tr>
                   <tr>
                       <td style="width: 128px; height: 19px">
                       </td>
                       <td style="width: 146px; height: 19px">
                       </td>
                       <td style="width: 10px; height: 19px">
                       </td>
                       <td style="width: 288px; height: 19px">
                       </td>
                       <td style="width: 140px; height: 19px">
                       </td>
                       <td style="width: 9px; height: 19px">
                       </td>
                       <td style="height: 19px">
                       </td>
                   </tr>
                    <tr>
                       <td style="width: 128px; height: 19px">
                       </td>
                       <td colspan="3" style="height: 19px">
                        <asp:Button ID="btn_Submit" runat="server" Text="Update Profile" OnClick="btn_Submit_Click" Width="107px"></asp:Button>
                           <asp:Button ID="btn_Cancel" runat="server" OnClick="btn_Cancel_Click" Text="Cancel"
                               Width="107px" /></td>
                       <td style="width: 140px; height: 19px">
                       </td>
                       <td style="width: 9px; height: 19px">
                       </td>
                       <td style="height: 19px">
                       </td>
                   </tr>
                </table>
                </div>
                  
              </td>
          </tr>        
      </table>
       <table id="tbError" cellspacing="0" cellpadding="0" runat="server" border="0">
         <tr>
            <td >
            </td>
            <td>
               
                &nbsp;
                </td>
        </tr>
   </table>
      <asp:HiddenField ID="txtCompName" runat="server" />  
       <asp:HiddenField ID="SM" runat="server" />  
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