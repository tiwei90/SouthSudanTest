<%@ Page Language="C#" MasterPageFile="~/iden.master" AutoEventWireup="true"
    Inherits="DocumentType" Codebehind="DocumentType.aspx.cs" %>

<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="Server">
    <asp:Panel ID="Panel1" runat="server" BackImageUrl="./images/bg.gif" Height="24px"
        Width="100%">
        <asp:Label ID="fly" runat="server" BackColor="Transparent" CssClass="HeaderMainTitle"
            Height="16px" Width="353px">Visa - Document Type </asp:Label></asp:Panel>
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
                            <asp:Label ID="Label3" runat="server" Text="List of Document Types" CssClass="LabelHeadGreen"
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
                            <asp:GridView ID="gvDocType" runat="server" AllowPaging="True" CellPadding="3" CssClass="Label"
                                ForeColor="#333333" GridLines="None" PageSize="5" 
                                OnPageIndexChanging="PageIndexChanging_Click"  
                                 OnSelectedIndexChanged="gvDocType_SelectedIndexChanged" AutoGenerateColumns="False" Width="781px" OnRowDataBound="gvDocType_RowDataBound">
                                <PagerSettings FirstPageText="&lt;&lt;" PreviousPageText="Previous" NextPageText="Next"
                                    LastPageText="&gt;&gt;"></PagerSettings>
                                <Columns>
                                    <asp:BoundField DataField="DOCTYPE" HeaderText="DOCUMENT TYPE" />
                                    <asp:BoundField DataField="DESCRIPTION" HeaderText="DESCRIPTION" />
                                    <asp:BoundField DataField="LAYOUTID" HeaderText="LAYOUT" Visible="False" />
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
                            <asp:Label ID="lblErrMsg" runat="server" CssClass="ErrLabel" Text="Label" Visible="False"></asp:Label><asp:Label
                                ID="lblMsg" runat="server" CssClass="Label" ForeColor="Blue" Text="Label"></asp:Label></td>
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
                        &nbsp;</td>
                    <td class="Title" style="width: 1px; height: 1px">
                    </td>
                </tr>
                <tr>
                    <td style="width: 5px; height: 20px">
                    </td>
                    <td style="height: 20px; background-color: #c6efef;" class="Title" colspan="1">
                        <asp:Label ID="Label1" runat="server" Width="300px" Text="Insert New Document Type"
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
                                        <asp:Label ID="Label6" runat="server" CssClass="Label" Text="Document Type"></asp:Label>
                                        <asp:Label ID="Label4" runat="server" CssClass="Label" Font-Bold="False" ForeColor="Red"
                                            Text="*"></asp:Label></td>
                                    <td style="width: 10px; height: 19px">
                                        :</td>
                                    <td style="width: 690px; height: 19px">
                                    <asp:TextBox ID="txtDocType" MaxLength="2" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtDocType"
                                        CssClass="Label" Display="Dynamic" ErrorMessage="Document Type is a mandatory field"
                                        ValidationGroup="Insert" ForeColor="White">*</asp:RequiredFieldValidator></td>
                                </tr>
                                <tr>
                                    <td style="height: 19px">
                                    </td>
                                    <td style="width: 10px; height: 19px">
                                    </td>
                                    <td style="height: 19px">
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top">
                                        <asp:Label ID="Label11" runat="server" CssClass="Label" Text="Description"></asp:Label>
                                        <asp:Label ID="Label2" runat="server" CssClass="Label" Font-Bold="False" ForeColor="Red"
                                            Text="*"></asp:Label></td>
                                    <td style="width: 10px" valign="top">
                                        :</td>
                                    <td>
                                        <asp:TextBox ID="txtDesc" runat="server" MaxLength="30" Width="250px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtDesc"
                                        CssClass="Label" Display="Dynamic" ErrorMessage="Description is a mandatory field"
                                        ValidationGroup="Insert" ForeColor="White">*</asp:RequiredFieldValidator></td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td style="width: 10px">
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr id="InsLayoutID" runat="server" visible="false"> 
                                    <td>
                                        <asp:Label ID="Label12" runat="server" CssClass="Label" Text="Layout ID"></asp:Label>
                                        <asp:Label ID="Label5" runat="server" CssClass="Label" Font-Bold="False" ForeColor="Red"
                                            Text="*"></asp:Label></td>
                                    <td style="width: 10px">
                                        :</td>
                                    <td>
                                        <asp:DropDownList ID="txtLayoutID" runat="server" AppendDataBoundItems="True" AutoPostBack="True">
                                        </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtLayoutID"
                                        CssClass="Label" Display="Dynamic" ErrorMessage="Layout ID is a mandatory field"
                                        ValidationGroup="Insert" ForeColor="White">*</asp:RequiredFieldValidator></td>
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
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="Label" ValidationGroup="Insert">
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
                    <td style="height: 3px">
                    </td>
                    <td style="width: 1px; height: 3px">
                    </td>
                    <td style="width: 1px; height: 3px">
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
                    <td style="width: 5px; height: 20px">
                    </td>
                    <td style="height: 20px; background-color: #c6efef;" class="Title" colspan="1">
                        <asp:Label ID="Label15" runat="server" Width="300px" Text="Update Document Type"
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
                        <table style="width: 800px" id="TABLE5" cellspacing="0" cellpadding="0" border="0"
                            runat="server">
                            <tbody>
                                <tr>
                                    <td style="width: 150px; height: 19px">
                                        <asp:Label ID="Label7" runat="server" Text="Document Type" CssClass="Label"></asp:Label>&nbsp;</td>
                                    <td style="width: 10px; height: 19px">
                                        :</td>
                                    <td style="width: 640px; height: 19px">
                                        <asp:Label ID="lblDocType" CssClass="Label" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="height: 19px">
                                    </td>
                                    <td style="width: 10px; height: 19px">
                                    </td>
                                    <td style="height: 19px">
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top">
                                        <asp:Label ID="Label8" runat="server" Text="Description" CssClass="Label"></asp:Label>
                                        <asp:Label ID="Label13" runat="server" CssClass="Label" Font-Bold="False" ForeColor="Red"
                                            Text="*"></asp:Label></td>
                                    <td style="width: 10px" valign="top">
                                        :</td>
                                    <td>
                                        <asp:TextBox ID="txtUDesc" runat="server" MaxLength="30" Width="250px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" CssClass="Label"
                                            ErrorMessage="Description is a mandatory field" ValidationGroup="Update" ControlToValidate="txtUDesc"
                                            Display="Dynamic" ForeColor="White">*</asp:RequiredFieldValidator></td>
                                </tr>
                                <tr>
                                    <td style="width: 90px">
                                    </td>
                                    <td style="width: 10px">
                                    </td>
                                    <td style="width: 386px">
                                    </td>
                                </tr>
                                <tr id="UpdLayoutID" runat="server" visible="false">
                                    <td style="width: 90px">
                                        <asp:Label ID="Label10" runat="server" Text="Layout ID" CssClass="Label"></asp:Label>
                                        <asp:Label ID="Label14" runat="server" CssClass="Label" Font-Bold="False" ForeColor="Red"
                                            Text="*"></asp:Label></td>
                                    <td style="width: 10px">
                                        :</td>
                                    <td style="width: 386px">
                                        <asp:DropDownList ID="txtULayoutID" runat="server" AppendDataBoundItems="True" AutoPostBack="True"></asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" CssClass="Label"
                                            ErrorMessage="Layout ID is a mandatory field" ValidationGroup="Update" ControlToValidate="txtULayoutID"
                                            Display="Dynamic" ForeColor="White">*</asp:RequiredFieldValidator></td>
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
                        <asp:Label ID="lblUpErr" runat="server" Text="Label" CssClass="ErrLabel" Visible="False"></asp:Label><asp:ValidationSummary
                            ID="ValidationSummary2" runat="server" CssClass="Label" ValidationGroup="Update" ShowMessageBox="True" ShowSummary="False">
                        </asp:ValidationSummary>
                    </td>
                    <td style="height: 10px">
                    </td>
                </tr>
                <tr>
                    <td>
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
                    <td style="height: 10px">
                    </td>
                    <td style="width: 1px; height: 10px">
                    </td>
                    <td style="width: 1px; height: 10px">
                    </td>
                </tr>
            </table>
        </asp:View>
    </asp:MultiView>
    <asp:HiddenField ID="txtCompName" runat="server" />

    <script type="text/javascript">
    GetPcName();
    </script>

</asp:Content>
