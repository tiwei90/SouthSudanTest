<%@ Page MasterPageFile="~/iden.master" Language="C#" AutoEventWireup="true" Inherits="EnrollmentIssuanceSite.QueryApproval" Codebehind="QueryApproval.aspx.cs" %>

<asp:Content ContentPlaceHolderID="Content" runat="server">
<script src="inc/common.js" type="text/javascript"></script>
<asp:Panel ID="Panel1" runat="server" Height="28px" BackImageUrl="./images/bg.gif"
        Width="100%">
        <asp:Label ID="fly" runat="server" Height="16px" CssClass="HeaderMainTitle" ForeColor="DimGray" BackColor="Transparent" Width="353px" Text="Visa - Search Pending Approval" ></asp:Label></asp:Panel>
        <input id="FORMNO" type="hidden" runat="server"/>
        <table id="tbQuery" cellspacing="2"  cellpadding="0" width="98%" border="0" runat="server" >
            <tr>
                <td style="width: 8px;"> </td>               
                <td colspan="3" style="width: 919px;" >
                <div id="PnlSearch" runat="server" class="PanelSearch">
                <table style="width: 100%">
                    <tr>
                        <td style="width: 4px; height: 10px">
                        </td>
                        <td style="width: 143px; height: 10px">
                            <asp:Label ID="Label32" runat="server" CssClass="Label" ForeColor="Red" Text="* Mandatory Field"></asp:Label></td>
                        <td colspan="2" style="height: 10px; width: 755px;">
                        </td>
                    </tr>
                <tr>               
                    <td style="height: 22px; width: 4px;">
                    </td>
                    <td style="height: 22px; width: 143px;">
                        <asp:Label ID="Label4" runat="server" CssClass="Label" Width="57px">Search by</asp:Label><asp:RequiredFieldValidator
                                ID="RequiredFieldValidator2" runat="server" ControlToValidate="SEARCHBY" CssClass="Label"
                                ErrorMessage="Please select search category before pressing the <SEARCH> button" ForeColor="White">*</asp:RequiredFieldValidator></td>
                    <td style="height: 22px; width: 755px; color: #000000;" colspan="2">
                    <asp:DropDownList ID="SEARCHBY" runat="server" AutoPostBack="True" OnSelectedIndexChanged="SEARCHBY_SelectedIndexChanged" Width="171px" CssClass="Label">
                        <asp:ListItem Value="">-SELECT-</asp:ListItem>
                        <asp:ListItem Value="1">APPLICATION ID</asp:ListItem>
                        <asp:ListItem Value="2">PASSPORT</asp:ListItem>
                        <asp:ListItem Value="4">NAME & DATE OF BIRTH</asp:ListItem>   
                        <asp:ListItem Value="5">BRANCH</asp:ListItem>                       
                    </asp:DropDownList></td>
               
                </tr>
                <tr id="trSearchValue" runat="server" visible="false">
                    <td style="height: 22px; width: 4px;">
                    </td>
                    <td style="height: 22px; width: 143px;">
                        <asp:Label ID="lblName" runat="server" CssClass="Label">Application ID</asp:Label><asp:Label
                            ID="Label31" runat="server" CssClass="Label" EnableViewState="False" ForeColor="Red">*</asp:Label></td>
                    <td style="height: 22px; width: 755px;" colspan="2">
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
                    <td colspan="2" style="height: 22px; width: 755px;">
                        <asp:TextBox ID="SEARCHFIRST" runat="server" Width="165px" EnableViewState="False"></asp:TextBox></td>
                </tr>
                <tr runat="server" visible="false" id="trMiddlename">
                    <td style="width: 4px; height: 22px">
                    </td>
                    <td style="width: 143px; height: 22px">
                        <asp:Label ID="Label16" runat="server" CssClass="Label">Middle Name</asp:Label></td>
                    <td colspan="2" style="height: 22px; width: 755px;">
                        <asp:TextBox ID="SEARCHMIDDLE" runat="server" Width="165px" EnableViewState="False"></asp:TextBox></td>
                </tr>
                <tr id="trDOB" runat="server" visible="false">
                    <td style="height: 22px; width: 4px;">
                    </td>
                    <td style="width: 143px; height: 22px">
                        <asp:Label ID="Label1" runat="server" CssClass="Label" Text="Date of Birth" Width="70px"></asp:Label>
                    </td>
                    <td colspan="2" style="height: 22px; width: 755px;">
                        <asp:TextBox ID="BIRTHDATE" runat="server" ReadOnly="True" Width="164px"></asp:TextBox>
                        <asp:ImageButton ID="ImageButton6" runat="server" CausesValidation="False" ImageUrl="~/images/button.gif"
                            OnClientClick="CalPick('BIRTHDATE','X','Applicant Birthdate');return false;" /></td>
                 </tr>
                    <tr runat="server" visible="false" id="trBirthCountry">
                        <td style="width: 4px; height: 22px">
                        </td>
                        <td style="width: 143px; height: 22px">
                            <asp:Label ID="lblCountry" runat="server" CssClass="Label" Text="Country of Birth" Width="100px"></asp:Label><asp:Label
                                ID="Label27" runat="server" CssClass="Label" EnableViewState="False" ForeColor="Red">*</asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="BIRTHCOUNTRY"
                                CssClass="Label" ErrorMessage="Country of Birth is mandatory" ForeColor="White">*</asp:RequiredFieldValidator></td>
                        <td colspan="2" style="height: 22px; width: 755px;">
                            <asp:DropDownList ID="BIRTHCOUNTRY" runat="server" CssClass="Label">
                            </asp:DropDownList></td>
                    </tr>
                <tr runat="server" visible="false" id="trBranch">
                        <td style="width: 4px; height: 22px">
                        </td>
                        <td style="width: 143px; height: 22px">
                            <asp:Label ID="Label2" runat="server" CssClass="Label" Text="Branch" Width="39px"></asp:Label><asp:Label
                                ID="Label3" runat="server" CssClass="Label" EnableViewState="False" ForeColor="Red">*</asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="DDBRANCH"
                                CssClass="Label" ErrorMessage="Branch is mandatory" ForeColor="White">*</asp:RequiredFieldValidator></td>
                        <td colspan="2" style="height: 22px; width: 755px;">
                            <asp:DropDownList ID="DDBRANCH" runat="server" CssClass="Label">
                            </asp:DropDownList></td>
                    </tr>
                <tr>
                    <td style="height: 22px; width: 4px;">  </td>
                    <td style="width: 143px; height: 22px"><asp:TextBox ID="TextBox1" runat="server" Style="display:none; visibility:hidden;"></asp:TextBox>  </td>
                  
                    <td colspan="2" style="height: 22px; width: 755px;">
                        <asp:Button ID="btnSearch" runat="server" Text="Search" TabIndex="-1" OnClick="btnSearch_Click"></asp:Button>&nbsp;
                        <asp:Button ID="btnClear" runat="server" Text="Clear" CausesValidation="False" Enabled="False" OnClick="btnClear_Click" />&nbsp;
                        <asp:Button ID="btn_viewAll" runat="server" CausesValidation="False" OnClick="btn_viewAll_Click"
                            TabIndex="-1" Text="View All" />
                        <asp:Label ID="lblQuery" runat="server" Text="Label" Visible="False"></asp:Label>
                        <asp:Label ID="lblsm" runat="server" Text="Label" Visible="False"></asp:Label>&nbsp;
                    </td>
                                    
               </tr>
                    <tr>
                        <td style="width: 4px; height: 22px">
                        </td>
                        <td style="width: 143px; height: 22px">
                        </td>
                        <td colspan="2" style="height: 22px; width: 755px;">
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
                <table width="98%" border="0" cellspacing="2" cellpadding="0" id="tb"  runat="server">
                    <tr>
                        <td style="width: 8px">
                        </td>
                        <td colspan="6">
                            <asp:GridView ID="dgByName" runat="server" AllowPaging="True" CellPadding="3" CssClass="Label"
                                ForeColor="#333333" GridLines="None" PageSize="5" Width="785px" OnPageIndexChanging="dgByName_PageIndexChanging" AllowSorting="True" AutoGenerateColumns="False" OnRowCommand="dgByName_RowCommand">
                                <Columns>
                                 <asp:TemplateField HeaderText="APPLICATION ID">
                                <ItemTemplate>
                                       <asp:LinkButton ID="LinkButton1"  CommandArgument='<%# Eval("FormNo") %>' CommandName="Select" runat="server" Text='<%# Eval("FormNo") %>' CausesValidation="False">
                                         </asp:LinkButton>
                                 </ItemTemplate>
                                     <ItemStyle Width="90px" />
                                     <HeaderStyle HorizontalAlign="Left" Width="95px" VerticalAlign="Top" />
                                 </asp:TemplateField>  
                                    <asp:BoundField DataField="DocType" HeaderText="DOCUMENT TYPE">
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
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
                                 <asp:TemplateField HeaderText="DOCUMENT STATUS">
                                    <ItemTemplate>
                                        <asp:Label ID="Nationality" runat="server" Text='<%# Eval("StageCode") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" Width="70px" />
                                    <HeaderStyle HorizontalAlign="Left" Width="70px" VerticalAlign="Top" />
                                </asp:TemplateField>
                                </Columns>
                                
                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <RowStyle BackColor="#EFF3FB" VerticalAlign="Top" />
                                <EditRowStyle BackColor="#2461BF" />
                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <AlternatingRowStyle BackColor="White" VerticalAlign="Top" />
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
                </div>
              </td>
          </tr>        
      </table>    
      <asp:HiddenField ID="txtCompName" runat="server" />
      <asp:HiddenField ID="HFLevel" runat="server" />                 &nbsp;

    <script type="text/javascript">
        GetPcName();
    </script>   
<script type="text/javascript">
function CalPick(txtbox)
{
    var winObj = null;
    winObj = calendarPicker(txtbox);
    winObj.focus();
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
</script>  

</asp:Content>