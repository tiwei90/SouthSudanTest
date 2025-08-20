<%@ Page Language="C#" MasterPageFile="~/iden.master" AutoEventWireup="true"
    Inherits="Branch" Codebehind="Branch.aspx.cs" %>

<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="Server">
    <asp:Panel ID="Panel1" runat="server" BackImageUrl="./images/bg.gif" Height="28px"
        Width="100%">
        <asp:Label ID="fly" runat="server" BackColor="Transparent" CssClass="HeaderMainTitle"
            Height="16px" Width="353px">Visa - Branch</asp:Label></asp:Panel>
    <asp:MultiView ID="MV" runat="server">
        <asp:View ID="vSelect" runat="server">
            <table id="Table4" cellspacing="0" cellpadding="0" width="100%" border="0" runat="server">
                <tbody>
                    <tr>
                        <td style="width: 5px; height: 10px">
                        </td>
                        <td class="Title" style="height: 10px">
                            &nbsp;</td>
                        <td class="Title" style="height: 10px">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 5px; height: 20px;">
                        </td>
                        <td class="Title" style="height: 20px; background-color: #c6efef;">
                            <asp:Label ID="Label3" runat="server" Text="List of Branches" CssClass="LabelHeadGreen"
                                Width="340px"></asp:Label></td>
                        <td class="Title" style="height: 20px">
                            &nbsp;&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="height: 10px">
                        </td>
                        <td style="height: 10px">
                            &nbsp;</td>
                        <td style="height: 10px">
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                        <div id="Div2" runat="server" class="PanelSearch" style="width:100%">
                        <table  border="0" cellspacing="2" cellpadding="0" id="tb"  runat="server">
                        <tr style="height:5px">
                            <td>
                            </td>
                            <td style="width: 782px"></td></tr>
                        <tr align="center">                        
                            <td align="center">
                                &nbsp;&nbsp;
                            </td>
                        <td align="center" style="width: 782px">                        
                            <asp:GridView ID="gvBranch" runat="server" AllowPaging="True" CellPadding="3" CssClass="Label"
                                ForeColor="#333333" GridLines="None" 
                                OnPageIndexChanging="PageIndexChanging_Click"  
                                 OnSelectedIndexChanged="gvBranch_SelectedIndexChanged" AutoGenerateColumns="False" Width="781px">
                                <PagerSettings FirstPageText="&lt;&lt;" PreviousPageText="Previous" NextPageText="Next"
                                    LastPageText="&gt;&gt;"></PagerSettings>
                                <Columns>
                                    <asp:BoundField DataField="COUNTRY" HeaderText="COUNTRY" />
                                    <asp:BoundField DataField="STATE" HeaderText="STATE" />
                                    <asp:BoundField DataField="BRANCHCODE" HeaderText="BRANCH CODE" />
                                    <asp:BoundField DataField="BRANCHNAME" HeaderText="BRANCH NAME" />
                                    <asp:BoundField DataField="ProcessDays" HeaderText="PROCESS DAYS" />
                                    <asp:CommandField SelectText="Edit" ShowSelectButton="True" />
                                    <asp:TemplateField ShowHeader="False">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btnDelete" runat="server" Text="Delete" OnClientClick="return ConfirmDelete()"
                                                OnClick="btnDelete_Click" CausesValidation="False" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <RowStyle BackColor="#EFF3FB" VerticalAlign="Top" HorizontalAlign="Left" />
                                <EditRowStyle BackColor="#2461BF" />
                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"  HorizontalAlign="Left" />
                                <AlternatingRowStyle BackColor="White" VerticalAlign="Top" HorizontalAlign="Left" />

                            </asp:GridView>
                        </td>
                        </tr>
                        <tr style="height:5px">
                            <td>
                            </td>
                            <td style="width: 782px"></td></tr>
                        </table>
                            </div>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 15px">
                        </td>
                        <td style="height: 15px">
                            <asp:Label ID="lblErrMsg" runat="server" CssClass="ErrLabel" Text="Label" Visible="False"></asp:Label><asp:Label ID="lblMsg" runat="server" CssClass="Label" Text="Label" ForeColor="Blue"></asp:Label></td>
                        <td style="height: 15px">
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="Insert" Width="100px" />&nbsp;</td>
                        <td>
                        </td>
                    </tr>
                </tbody>
            </table>
        </asp:View>
        <asp:View ID="vInsert" runat="server">
            <table id="TABLE1" cellspacing="0" cellpadding="0" width="100%" border="0" runat="server">
                <tr>
                    <td style="width: 5px; height: 1px">
                    </td>
                    <td style="width: 1px; height: 15px" class="Title">
                    </td>
                    <td class="Title" style="width: 1px; height: 1px">
                    </td>
                </tr>
                <tr>
                    <td style="width: 5px; height: 20px">
                    </td>
                    <td style="height: 20px; background-color: #c6efef;" class="Title" colspan="1">
                        <asp:Label ID="Label1" runat="server" Width="300px" Text="Insert New Branch"
                            CssClass="LabelHeadGreen"></asp:Label></td>
                    <td class="Title" colspan="1" style="height: 20px">
                        &nbsp;&nbsp;</td>
                </tr>
                <tr>
                    <td style="height: 10px">
                    </td>
                    <td style="width: 1px; height: 10px">
                    </td>
                    <td style="width: 1px; height: 10px">
                    </td>
                </tr>
                <tr>
                    <td style="height: 10px">
                    </td>
                    <td style="height: 10px">
                        <table style="width: 800px" id="Table6" cellspacing="0" cellpadding="0" border="0"
                            runat="server">
                            <tbody>
                                <tr>
                                    <td style="width: 150px; height: 19px">
                                        <asp:Label ID="Label6" runat="server" CssClass="Label" Text="Country"></asp:Label>
                                        <asp:Label ID="Label9" runat="server" CssClass="Label" Font-Bold="False" ForeColor="Red"
                                            Text="*"></asp:Label></td>
                                    <td style="width: 10px; height: 19px">
                                        :</td>
                                    <td style="width: 640px; height: 19px">
                                        <asp:DropDownList ID="ddlCountry" runat="server" DataTextField="Name" DataValueField="ID" AutoPostBack="True" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged">
                                        </asp:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlCountry"
                                        CssClass="Label" Display="Dynamic" ErrorMessage="Country is a mandatory field"
                                        ValidationGroup="Insert" ForeColor="White">*</asp:RequiredFieldValidator>
                                        <asp:DropDownList ID="HiddenCountry" runat="server" DataTextField="Name" DataValueField="Code" AutoPostBack="True" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged" Visible="False">
                                        </asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td style="width: 150px; height: 19px">
                                        &nbsp;</td>
                                    <td style="width: 10px; height: 19px">
                                    </td>
                                    <td style="width: 299px; height: 19px">
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top" style="width: 150px">
                                        <asp:Label ID="Label10" runat="server" CssClass="Label" Text="State"></asp:Label>
                                        <asp:Label ID="Label4" runat="server" CssClass="Label" Font-Bold="False" ForeColor="Red"
                                            Text="*"></asp:Label></td>
                                    <td style="width: 10px" valign="top">
                                        :</td>
                                    <td>
                                        <asp:DropDownList ID="ddlState" runat="server" DataTextField="Name" DataValueField="StateCode" Enabled="False">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlState"
                                        CssClass="Label" Display="Dynamic" ErrorMessage="State is a mandatory field"
                                        ValidationGroup="Insert" ForeColor="White">*</asp:RequiredFieldValidator></td>
                                </tr>
                                <tr>
                                    <td valign="top" style="height: 19px; width: 150px;">
                                    </td>
                                    <td style="width: 10px" valign="top">
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top" style="width: 150px">
                                        <asp:Label ID="Label11" runat="server" CssClass="Label" Text="Branch Code"></asp:Label>
                                        <asp:Label ID="Label12" runat="server" CssClass="Label" Font-Bold="False" ForeColor="Red"
                                            Text="*"></asp:Label></td>
                                    <td style="width: 10px" valign="top">
                                        :</td>
                                    <td>
                                        <asp:TextBox ID="txtBranchCode" runat="server" MaxLength="5"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtBranchCode"
                                            CssClass="Label" Display="Dynamic" ErrorMessage="Branch Code is a mandatory field"
                                            ForeColor="White" ValidationGroup="Insert">*</asp:RequiredFieldValidator></td>
                                </tr>
                                <tr>
                                    <td valign="top" style="height: 19px; width: 150px;">
                                    </td>
                                    <td style="width: 10px" valign="top">
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top" style="width: 150px">
                                        <asp:Label ID="Label13" runat="server" CssClass="Label" Text="Branch Name"></asp:Label>
                                        <asp:Label ID="Label14" runat="server" CssClass="Label" Font-Bold="False" ForeColor="Red"
                                            Text="*"></asp:Label></td>
                                    <td style="width: 10px" valign="top">
                                        :</td>
                                    <td>
                                        <asp:TextBox ID="txtBranchName" runat="server" MaxLength="50" Width="608px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtBranchName"
                                            CssClass="Label" Display="Dynamic" ErrorMessage="Branch Name is a mandatory field"
                                            ForeColor="White" ValidationGroup="Insert">*</asp:RequiredFieldValidator></td>
                                </tr>
                                <tr>
                                    <td style="width: 150px; height: 19px" valign="middle">
                                    </td>
                                    <td style="width: 10px; height: 19px" valign="top">
                                    </td>
                                    <td style="height: 19px">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 150px; height: 19px" valign="middle">
                                        <asp:Label ID="Label7" runat="server" CssClass="Label" Text="Process Days"></asp:Label>
                                        <asp:Label ID="Label15" runat="server" CssClass="Label" Font-Bold="False" ForeColor="Red"
                                            Text="*"></asp:Label></td>
                                    <td style="width: 10px; height: 19px" valign="top">
                                        :</td>
                                    <td style="height: 19px">
                                        <asp:TextBox ID="txtProcessDays" runat="server" MaxLength="5"></asp:TextBox><asp:RequiredFieldValidator
                                            ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtProcessDays"
                                            CssClass="Label" Display="Dynamic" ErrorMessage="Process days is a mandatory field"
                                            ForeColor="White" ValidationGroup="Insert">*</asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtProcessDays"
                                            CssClass="Label" Display="Dynamic" ErrorMessage="Process days - only numeric characters [0-9] allowed"
                                            ValidationExpression="(\d){1,99}" ValidationGroup="Insert">*</asp:RegularExpressionValidator></td>
                                </tr>
                            </tbody>
                        </table>
                    </td>
                    <td style="height: 10px">
                    </td>
                </tr>
                <tr>
                    <td style="height: 10px">
                    </td>
                    <td style="height: 10px">
                        <asp:Label ID="lblInErr" runat="server" Text="Label" CssClass="ErrLabel" Visible="false"></asp:Label>
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="Label" ValidationGroup="Insert" ShowMessageBox="True" ShowSummary="False">
                        </asp:ValidationSummary>
                    </td>
                    <td style="height: 10px">
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        <asp:Button ID="btnSubmit" OnClick="btnSubmit_Click" runat="server" Width="100px"
                            Text="Submit" ValidationGroup="Insert"></asp:Button>
                        <asp:Button ID="btnCancel" OnClick="btnCancel_Click" runat="server" Width="100px"
                            Text="Cancel" CausesValidation="False"></asp:Button></td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td style="height: 4px">
                    </td>
                    <td style="width: 1px; height: 4px">
                    </td>
                    <td style="width: 1px; height: 4px">
                    </td>
                </tr>
            </table>
        </asp:View>
        <asp:View ID="vUpdate" runat="server">
            <table id="TABLE3" cellspacing="0" cellpadding="0" width="100%" border="0" runat="server">
                <tr>
                    <td style="width: 5px; height: 1px">
                    </td>
                    <td style="width: 1px; height: 15px" class="Title">
                        &nbsp;</td>
                    <td class="Title" style="width: 1px; height: 1px">
                    </td>
                </tr>
                <tr>
                    <td style="width: 5px; height: 14px">
                    </td>
                    <td style="height: 14px; background-color: #c6efef;" class="Title" colspan="1">
                        <asp:Label ID="Label5" runat="server" Width="300px" Text="Update Branch"
                            CssClass="LabelHeadGreen"></asp:Label></td>
                    <td class="Title" colspan="1" style="height: 14px">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="height: 10px; width: 5px;">
                    </td>
                    <td style="width: 1px; height: 10px">
                    </td>
                    <td style="width: 1px; height: 10px">
                    </td>
                </tr>
                <tr>
                    <td style="height: 10px; width: 5px;">
                    </td>
                    <td style="height: 10px">
                        <table style="width: 800px" id="TABLE5" cellspacing="0" cellpadding="0" border="0"
                            runat="server">
                            <tbody>
                                <tr>
                                    <td style="width: 150px; height: 19px">
                                        <asp:Label ID="Label2" runat="server" CssClass="Label" Text="Country"></asp:Label>
                                        </td>
                                    <td style="width: 10px; height: 19px">
                                        :</td>
                                    <td style="width: 640px; height: 19px">
                                        <asp:Label ID="lblCountry" runat="server" CssClass="Label"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="width: 78px; height: 19px">
                                        &nbsp;</td>
                                    <td style="width: 10px; height: 19px">
                                    </td>
                                    <td style="width: 299px; height: 19px">
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top">
                                        <asp:Label ID="Label8" runat="server" CssClass="Label" Text="State"></asp:Label>
                                        </td>
                                    <td style="width: 10px" valign="top">
                                        :</td>
                                    <td>
                                        &nbsp;<asp:Label ID="lblState" runat="server" CssClass="Label"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td valign="top" style="height: 19px">
                                    </td>
                                    <td style="width: 10px" valign="top">
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top">
                                        <asp:Label ID="Label16" runat="server" CssClass="Label" Text="Branch Code"></asp:Label>
                                        </td>
                                    <td style="width: 10px" valign="top">
                                        :</td>
                                    <td>
                                        &nbsp;<asp:Label CssClass="Label" ID="lblBranchCode" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td valign="top" style="height: 19px">
                                    </td>
                                    <td style="width: 10px" valign="top">
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top">
                                        <asp:Label ID="Label18" runat="server" CssClass="Label" Text="Branch Name"></asp:Label>
                                        <asp:Label ID="Label19" runat="server" CssClass="Label" Font-Bold="False" ForeColor="Red"
                                            Text="*"></asp:Label></td>
                                    <td style="width: 10px" valign="top">
                                        :</td>
                                    <td>
                                        <asp:TextBox ID="txtUBranchName" runat="server" MaxLength="50" Width="608px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtBranchName"
                                            CssClass="Label" Display="Dynamic" ErrorMessage="Branch Name is a mandatory field"
                                            ForeColor="White" ValidationGroup="Insert">*</asp:RequiredFieldValidator></td>
                                </tr>
                                <tr>
                                    <td style="height: 19px" valign="middle">
                                    </td>
                                    <td style="width: 10px; height: 19px" valign="top">
                                    </td>
                                    <td style="height: 19px">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 19px" valign="middle">
                                        <asp:Label ID="Label17" runat="server" CssClass="Label" Text="Process Days"></asp:Label>
                                        <asp:Label ID="Label20" runat="server" CssClass="Label" Font-Bold="False" ForeColor="Red"
                                            Text="*"></asp:Label></td>
                                    <td style="width: 10px; height: 19px" valign="top">
                                        :</td>
                                    <td style="height: 19px">
                                        <asp:TextBox ID="txtUProcessDays" runat="server" MaxLength="5"></asp:TextBox><asp:RequiredFieldValidator
                                            ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtUProcessDays"
                                            CssClass="Label" Display="Dynamic" ErrorMessage="Process days is a mandatory field"
                                            ForeColor="White" ValidationGroup="Update">*</asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtUProcessDays"
                                            CssClass="Label" Display="Dynamic" ErrorMessage="Process days - only numeric characters [0-9] allowed"
                                            ValidationExpression="(\d){1,99}" ValidationGroup="Update">*</asp:RegularExpressionValidator></td>
                                </tr>
                                <tr>
                                    <td style="width: 150px; height: 19px">
                                    </td>
                                    <td style="width: 10px; height: 19px">
                                    </td>
                                    <td style="width: 640px; height: 19px">
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </td>
                    <td style="height: 10px">
                    </td>
                </tr>
                <tr>
                    <td style="height: 10px; width: 5px;">
                    </td>
                    <td style="height: 10px">
                        <asp:Label ID="lblUpErr" runat="server" Text="Label" CssClass="ErrLabel" Visible="False"></asp:Label><asp:ValidationSummary
                            ID="ValidationSummary2" runat="server" CssClass="Label" ValidationGroup="Update" ShowMessageBox="True" ShowSummary="False">
                        </asp:ValidationSummary>
                    </td>
                    <td style="height: 10px">
                    </td>
                </tr>
                <tr>
                    <td style="width: 5px">
                    </td>
                    <td>
                        <asp:Button ID="btnUpdate" OnClick="btnUpdate_Click" runat="server" Width="100px"
                            Text="Update" ValidationGroup="Update"></asp:Button>
                        <asp:Button ID="btnUpdateCancel" OnClick="btnCancel_Click" runat="server" Width="100px"
                            Text="Cancel" CausesValidation="False"></asp:Button></td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td style="height: 10px; width: 5px;">
                    </td>
                    <td style="width: 1px; height: 10px">
                    </td>
                    <td style="width: 1px; height: 10px">
                    </td>
                </tr>
            </table>
        </asp:View>
    </asp:MultiView>
</asp:Content>
