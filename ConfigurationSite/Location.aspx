<%@ Page Language="C#" MasterPageFile="~/iden.master" AutoEventWireup="true"
    Inherits="Location" Codebehind="Location.aspx.cs" %>

<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="Server" >
    <asp:Panel ID="Panel1" runat="server" BackImageUrl="./images/bg.gif" Height="28px"
        Width="100%">
        <asp:Label ID="fly" runat="server" BackColor="Transparent" CssClass="HeaderMainTitle"
            Height="16px" Width="353px">Visa - Location</asp:Label></asp:Panel>
    
    <asp:MultiView ID="MV" runat="server">
        <asp:View ID="vSelect" runat="server">
            <table id="Table4" cellspacing="0" cellpadding="0" width="100%" border="0" runat="server">
                <tbody>
                    <tr>
                        <td style="width: 5px; height: 15px">
                            &nbsp;</td>
                        <td class="Title" style="height: 15px">
                            &nbsp;</td>
                        <td class="Title" style="height: 15px">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 5px; height: 20px;">
                        </td>
                        <td class="Title" style="height: 20px; background-color: #c6efef;">
                            <asp:Label ID="Label3" runat="server" Text="List of Locations" CssClass="LabelHeadGreen"
                                Width="157px"></asp:Label></td>
                        <td class="Title" style="height: 20px">
                            &nbsp;&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 193px">
                        </td>
                        <td style="height: 193px">
                        <div id="Div2" runat="server" class="PanelSearch" style="width:100%">
                        <table  border="0" cellspacing="2" cellpadding="0" id="tb"  runat="server">
                        <tr style="height:5px">
                            <td>
                            </td>
                            <td></td></tr>
                        <tr align="center">                        
                            <td align="center">
                                &nbsp;&nbsp;
                            </td>
                        <td align="center">                        
                            <asp:GridView ID="gvLocation" runat="server" AllowPaging="True" CellPadding="3" CssClass="Label"
                                ForeColor="#333333" GridLines="None" 
                                OnPageIndexChanging="PageIndexChanging_Click"  
                                 OnSelectedIndexChanged="gvLocation_SelectedIndexChanged" AutoGenerateColumns="False" Width="781px">
                                <PagerSettings FirstPageText="&lt;&lt;" PreviousPageText="Previous" NextPageText="Next"
                                    LastPageText="&gt;&gt;"></PagerSettings>
                                <Columns>
                                    <asp:BoundField DataField="ID" HeaderText="ID" />
                                    <asp:BoundField DataField="NAME" HeaderText="NAME" />
                                    <asp:BoundField DataField="LocationType" HeaderText="LOCATION TYPE" />
                                    <asp:BoundField DataField="BranchCode" HeaderText="BRANCH CODE" />
                                    <asp:BoundField DataField="Obsolete" HeaderText="OBSOLETE" />
                                    <asp:CommandField SelectText="Edit" ShowSelectButton="True" />                                    
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
                            <td></td></tr>
                        </table>
                            </div>
                        </td>
                        <td align="center" style="height: 193px">
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
                <tbody>
                    <tr>
                        <td style="width: 5px; height: 15px">
                        </td>
                        <td style="width: 1px; height: 1px" class="Title">
                        </td>
                        <td class="Title" style="width: 20px; height: 1px">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 5px; height: 20px">
                        </td>
                        <td style="height: 20px; background-color: #c6efef;" class="Title" colspan="1">
                            <asp:Label ID="Label1" runat="server" Width="300px" Text="Insert New Location Name"
                                CssClass="LabelHeadGreen"></asp:Label></td>
                        <td class="Title" colspan="1" style="height: 20px; width: 20px;">
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 10px">
                        </td>
                        <td style="width: 1px; height: 10px">
                        </td>
                        <td style="width: 20px; height: 10px">
                            &nbsp;&nbsp;
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
                                            <asp:Label ID="Label6" runat="server" CssClass="Label" Text="Location Name"></asp:Label>
                                            <asp:Label ID="Label11" runat="server" CssClass="Label" Font-Bold="False" ForeColor="Red"
                                                Text="*"></asp:Label></td>
                                        <td style="width: 9px; height: 19px">
                                            :</td>
                                        <td style="width: 640px; height: 19px">
                                            <asp:TextBox ID="txtName" runat="server"></asp:TextBox><asp:RequiredFieldValidator
                                                    ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtName"
                                                    CssClass="Label" Display="Dynamic" ErrorMessage="Location name is a mandatory field"
                                                    ValidationGroup="Insert">*</asp:RequiredFieldValidator>
                                            </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 150px; height: 19px">
                                            &nbsp;</td>
                                        <td style="width: 9px; height: 19px">
                                        </td>
                                        <td style="width: 640px; height: 19px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top">
                                            <asp:Label ID="Label10" runat="server" CssClass="Label" Text="Location Type"></asp:Label>
                                            <asp:Label ID="Label2" runat="server" CssClass="Label" Font-Bold="False" ForeColor="Red"
                                                Text="*"></asp:Label></td>
                                        <td style="width: 9px" valign="top">
                                            :</td>
                                        <td>
                                            <asp:DropDownList ID="ddlType" runat="server">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlType"
                                                CssClass="Label" Display="Dynamic" ErrorMessage="Location type is a mandatory field"
                                                ValidationGroup="Insert" ForeColor="White">*</asp:RequiredFieldValidator></td>
                                    </tr>
                                    <tr>
                                        <td valign="top" style="height: 19px">
                                        </td>
                                        <td style="width: 9px" valign="top">
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top">
                                            <asp:Label ID="Label9" runat="server" CssClass="Label" Text="Branch"></asp:Label>
                                            <asp:Label ID="Label12" runat="server" CssClass="Label" Font-Bold="False" ForeColor="Red"
                                                Text="*"></asp:Label></td>
                                        <td style="width: 9px" valign="top">
                                            :</td>
                                        <td>
                                            <asp:DropDownList ID="ddlBranch" runat="server" DataTextField="BranchName" DataValueField="BranchCode">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlBranch"
                                                CssClass="Label" Display="Dynamic" ErrorMessage="Branch is a mandatory field"
                                                ForeColor="White" ValidationGroup="Insert">*</asp:RequiredFieldValidator></td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                        <td style="height: 10px; width: 20px;">
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 10px">
                        </td>
                        <td style="height: 10px">
                            <asp:Label ID="lblInErr" runat="server" Text="Label" CssClass="ErrLabel" Visible="false"></asp:Label>
                            <asp:ValidationSummary    ID="ValidationSummary1" runat="server" CssClass="Label" ValidationGroup="Insert" ShowMessageBox="True" ShowSummary="False"/>
                        </td>
                        <td style="height: 10px; width: 20px;">
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
                        <td style="width: 20px">
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 4px">
                        </td>
                        <td style="width: 1px; height: 4px">
                        </td>
                        <td style="width: 20px; height: 4px">
                        </td>
                    </tr>
                </tbody>
            </table>
        </asp:View>
        <asp:View ID="vUpdate" runat="server">
            <table id="TABLE3" cellspacing="0" cellpadding="0" width="100%" border="0" runat="server">
                <tr>
                    <td style="width: 5px; height: 1px">
                    </td>
                    <td style="width: 808px; height: 1px" class="Title">
                    </td>
                    <td class="Title" style="width: 5px; height: 1px">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td style="width: 5px; height: 20px">
                    </td>
                    <td style="height: 20px; background-color: #c6efef; width: 808px;" class="Title" colspan="1">
                        <asp:Label ID="Label5" runat="server" Width="300px" Text="Update Location Name"
                            CssClass="LabelHeadGreen"></asp:Label></td>
                    <td class="Title" colspan="1" style="height: 20px; width: 5px;">
                        &nbsp;&nbsp;</td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td style="width: 808px;">
                    </td>
                    <td style="width: 5px;">
                    </td>
                </tr>
                <tr>
                    <td style="height: 10px">
                    </td>
                    <td style="height: 10px; width: 808px;">
                        <table style="width: 800px" id="TABLE5" cellspacing="0" cellpadding="0" border="0"
                            runat="server">
                            <tbody>
                                <tr>
                                    <td style="width: 150px; height: 19px">
                                        <asp:Label ID="Label16" runat="server" CssClass="Label" Text="ID"></asp:Label></td>
                                    <td style="width: 9px; height: 19px">
                                        :</td>
                                    <td style="width: 640px; height: 19px">
                                        <asp:Label ID="lblID" runat="server" CssClass="Label"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="width: 150px; height: 19px">
                                    </td>
                                    <td style="width: 9px; height: 19px">
                                    </td>
                                    <td style="width: 640px; height: 19px">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 150px; height: 19px">
                                        <asp:Label ID="Label7" runat="server" Text="Location Name" CssClass="Label"></asp:Label>
                                        <asp:Label ID="Label17" runat="server" CssClass="Label" Font-Bold="False" ForeColor="Red"
                                            Text="*"></asp:Label></td>
                                    <td style="width: 9px; height: 19px">
                                        :</td>
                                    <td style="width: 640px; height: 19px">
                                        <asp:TextBox ID="txtUName" runat="server"></asp:TextBox><asp:RequiredFieldValidator
                                            ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtUName" CssClass="Label"
                                            Display="Dynamic" ErrorMessage="Location name is a mandatory field" ValidationGroup="Insert">*</asp:RequiredFieldValidator></td>
                                </tr>
                                <tr>
                                    <td style="width: 125px; height: 19px">
                                        &nbsp;</td>
                                    <td style="width: 9px; height: 19px">
                                    </td>
                                    <td style="width: 450px; height: 19px">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 125px" valign="top">
                                        <asp:Label ID="Label8" runat="server" Text="Location Type" CssClass="Label"></asp:Label>
                                        <asp:Label ID="Label4" runat="server" CssClass="Label" Font-Bold="False" ForeColor="Red"
                                            Text="*"></asp:Label></td>
                                    <td style="width: 9px" valign="top">
                                        :</td>
                                    <td style="width: 450px">
                                        <asp:DropDownList ID="ddlUType" runat="server">
                                        </asp:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                                            ControlToValidate="ddlUType" CssClass="Label" Display="Dynamic" ErrorMessage="Location type is a mandatory field"
                                            ForeColor="White" ValidationGroup="Insert">*</asp:RequiredFieldValidator></td>
                                </tr>
                                <tr>
                                    <td style="width: 125px; height: 19px;" valign="top">
                                    </td>
                                    <td style="width: 9px" valign="top">
                                    </td>
                                    <td style="width: 450px">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 125px" valign="top">
                                        <asp:Label ID="Label13" runat="server" CssClass="Label" Text="Branch"></asp:Label>
                                        <asp:Label ID="Label14" runat="server" CssClass="Label" Font-Bold="False" ForeColor="Red"
                                            Text="*"></asp:Label></td>
                                    <td style="width: 9px" valign="top">
                                        :</td>
                                    <td style="width: 450px">
                                        <asp:DropDownList ID="ddlUBranch" runat="server" DataTextField="BranchName" DataValueField="BranchCode">
                                        </asp:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                                            ControlToValidate="ddlUBranch" CssClass="Label" Display="Dynamic" ErrorMessage="Branch is a mandatory field"
                                            ForeColor="White" ValidationGroup="Insert">*</asp:RequiredFieldValidator></td>
                                </tr>
                                <tr>
                                    <td style="width: 125px; height: 19px;" valign="top">
                                    </td>
                                    <td style="width: 9px" valign="top">
                                    </td>
                                    <td style="width: 450px">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 125px" valign="top">
                                        <asp:Label ID="Label15" runat="server" CssClass="Label" Text="Obsolete"></asp:Label></td>
                                    <td style="width: 9px" valign="top">
                                        :</td>
                                    <td style="width: 450px">
                                        <asp:CheckBox ID="chkObosolete" runat="server" /></td>
                                </tr>
                            </tbody>
                        </table>
                        &nbsp;</td>
                    <td style="height: 10px; width: 5px;">
                    </td>
                </tr>
                <tr>
                    <td style="height: 10px">
                    </td>
                    <td style="height: 10px; width: 808px;">
                        <asp:Label ID="lblUpErr" runat="server" Text="Label" CssClass="ErrLabel" Visible="False"></asp:Label><asp:ValidationSummary
                            ID="ValidationSummary2" runat="server" CssClass="Label" ValidationGroup="Update" ShowMessageBox="True" ShowSummary="False">
                        </asp:ValidationSummary>
                    </td>
                    <td style="height: 10px; width: 5px;">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td style="width: 808px">
                        <asp:Button ID="btnUpdate" OnClick="btnUpdate_Click" runat="server" Width="100px"
                            Text="Update" ValidationGroup="Update"></asp:Button>
                        <asp:Button ID="btnUpdateCancel" OnClick="btnCancel_Click" runat="server" Width="100px"
                            Text="Cancel" CausesValidation="False"></asp:Button></td>
                    <td style="width: 5px">
                    </td>
                </tr>
                <tr>
                    <td style="height: 10px">
                    </td>
                    <td style="width: 808px; height: 10px">
                    </td>
                    <td style="width: 5px; height: 10px">
                    </td>
                </tr>
            </table>
        </asp:View>
    </asp:MultiView>
</asp:Content>
