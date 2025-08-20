<%@ Page Language="C#" MasterPageFile="~/iden.master" AutoEventWireup="true"
    Inherits="PaymentMethod" Codebehind="PaymentMethod.aspx.cs" %>

<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="Server">
    <asp:Panel ID="Panel1" runat="server" BackImageUrl="./images/bg.gif" Height="24px"
        Width="100%">
        <asp:Label ID="fly" runat="server" BackColor="Transparent" CssClass="HeaderMainTitle"
            Height="16px" Width="353px">Visa - Payment Method </asp:Label></asp:Panel>
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
                            <asp:Label ID="Label3" runat="server" Text="List of Payment Methods" CssClass="LabelHeadGreen"
                                Width="340px"></asp:Label></td>
                        <td class="Title" style="height: 20px">
                            &nbsp;</td>
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
                            <asp:GridView ID="gvPMethod" runat="server" AllowPaging="True" CellPadding="3" CssClass="Label"
                                ForeColor="#333333" GridLines="None" PageSize="5" 
                                OnPageIndexChanging="PageIndexChanging_Click"  
                                 OnSelectedIndexChanged="gvPMethod_SelectedIndexChanged" AutoGenerateColumns="False" Width="781px">
                                <PagerSettings FirstPageText="&lt;&lt;" PreviousPageText="Previous" NextPageText="Next"
                                    LastPageText="&gt;&gt;"></PagerSettings>
                                <Columns>
                                    <asp:BoundField DataField="ID" HeaderText="ID" />
                                    <asp:BoundField DataField="PAYMENTMETHOD" HeaderText="PAYMENT METHOD" />
                                    <asp:BoundField DataField="DESCRIPTION" HeaderText="DESCRIPTION" />
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
                        <td style="height: 26px">
                        </td>
                        <td style="height: 26px">
                            <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="Insert" Width="100px" />&nbsp;</td>
                        <td style="height: 26px">
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
                    <td style="width: 803px; height: 15px" class="Title">
                        &nbsp;</td>
                    <td class="Title" style="width: 1px; height: 1px">
                    </td>
                </tr>
                <tr>
                    <td style="width: 5px; height: 20px">
                    </td>
                    <td style="height: 20px; background-color: #c6efef; width: 803px;" class="Title" colspan="1">
                        <asp:Label ID="Label1" runat="server" Width="300px" Text="Insert New Payment Method"
                            CssClass="LabelHeadGreen"></asp:Label></td>
                    <td class="Title" colspan="1" style="height: 20px">
                        &nbsp;&nbsp;</td>
                </tr>
                <tr>
                    <td style="height: 10px">
                    </td>
                    <td style="width: 803px; height: 10px">
                    </td>
                    <td style="width: 1px; height: 10px">
                    </td>
                </tr>
                <tr>
                    <td style="height: 10px">
                    </td>
                    <td style="height: 10px; width: 803px;">
                        <table id="Table6" runat="server" border="0" cellpadding="0" cellspacing="0"
                            style="width: 800px">
                            <tbody>
                                <tr>
                                    <td style="width: 170px; height: 19px">
                                        <asp:Label ID="Label6" runat="server" CssClass="Label" Text="ID" Width="14%"></asp:Label><asp:Label
                                            ID="Label7" runat="server" CssClass="Label" Font-Bold="False" ForeColor="Red"
                                            Text="*"></asp:Label></td>
                                    <td style="width: 10px; height: 19px">
                                        :</td>
                                    <td style="width: 640px; height: 19px">
                                        <asp:TextBox ID="txtID" runat="server"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtID"
                                            CssClass="Label" Display="Dynamic" ErrorMessage="ID - only numeric characters [0-9] allowed"
                                            ForeColor="White" ValidationExpression="(\d){1,99}" ValidationGroup="Insert">*</asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtID"
                                            CssClass="Label" Display="Dynamic" ErrorMessage="ID is a mandatory field" ForeColor="White"
                                            ValidationGroup="Insert">*</asp:RequiredFieldValidator></td>
                                </tr>
                                <tr>
                                    <td style="width: 170px; height: 19px">
                                    </td>
                                    <td style="width: 10px; height: 19px">
                                    </td>
                                    <td style="width: 640px; height: 19px">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 170px; height: 19px">
                                    <asp:Label ID="Label2" runat="server" Width="64%" Text="Payment Method" CssClass="Label"></asp:Label>
                                        <asp:Label ID="Label10" runat="server" CssClass="Label" Font-Bold="False" ForeColor="Red"
                                            Text="*"></asp:Label></td>
                                    <td style="width: 10px; height: 19px">
                                        :</td>
                                    <td style="width: 640px; height: 19px">
                                    <asp:TextBox ID="txtPMethod" runat="server"></asp:TextBox>&nbsp;
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" CssClass="Label"
                                        ErrorMessage="Payment Method - only numeric characters [0-9] allowed" ControlToValidate="txtPMethod"
                                        ValidationExpression="(\d){1,99}" ValidationGroup="Insert" Display="Dynamic" ForeColor="White">*</asp:RegularExpressionValidator>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPMethod"
                                        CssClass="Label" Display="Dynamic" ErrorMessage="Payment Method is a mandatory field"
                                        ValidationGroup="Insert" ForeColor="White">*</asp:RequiredFieldValidator></td>
                                </tr>
                                <tr>
                                    <td style="width: 150px; height: 19px">
                                    </td>
                                    <td style="width: 10px; height: 19px">
                                    </td>
                                    <td style="width: 640px; height: 19px">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 150px; height: 49px" valign="top">
                                        <asp:Label ID="Label12" runat="server" CssClass="Label" Text="Description"></asp:Label>
                                        <asp:Label ID="Label11" runat="server" CssClass="Label" Font-Bold="False" ForeColor="Red"
                                            Text="*"></asp:Label></td>
                                    <td style="width: 10px; height: 49px" valign="top">
                                        :</td>
                                    <td style="width: 640px; height: 49px">
                                        <asp:TextBox ID="txtDesc" runat="server" Height="41px" MaxLength="1024" TextMode="MultiLine"
                                            Width="553px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtDesc"
                                            CssClass="Label" Display="Dynamic" ErrorMessage="Description is a mandatory field"
                                            ForeColor="White" ValidationGroup="Insert">*</asp:RequiredFieldValidator></td>
                                </tr>
                                <tr>
                                    <td style="width: 150px; height: 15px" valign="top">
                                    </td>
                                    <td style="width: 10px; height: 15px" valign="top">
                                    </td>
                                    <td style="width: 640px; height: 15px">
                                    </td>
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
                    <td style="height: 10px; width: 803px;">
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
                    <td style="width: 803px">
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
                    <td style="width: 803px; height: 4px">
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
                    <td style="width: 803px; height: 15px" class="Title">
                        &nbsp;</td>
                    <td class="Title" style="width: 1px; height: 1px">
                    </td>
                </tr>
                <tr>
                    <td style="width: 5px; height: 20px">
                    </td>
                    <td style="height: 20px; background-color: #c6efef; width: 803px;" class="Title" colspan="1">
                        <asp:Label ID="Label5" runat="server" Width="300px" Text="Update Payment Method"
                            CssClass="LabelHeadGreen"></asp:Label></td>
                    <td class="Title" colspan="1" style="height: 20px">
                        &nbsp;&nbsp;</td>
                </tr>
                <tr>
                    <td style="height: 10px; width: 5px;">
                    </td>
                    <td style="width: 803px; height: 10px">
                    </td>
                    <td style="width: 1px; height: 10px">
                    </td>
                </tr>
                <tr>
                    <td style="height: 10px; width: 5px;">
                    </td>
                    <td style="height: 10px; width: 803px;">
                        <table id="Table2" runat="server" border="0" cellpadding="0" cellspacing="0"
                            style="width: 800px">
                            <tbody>
                                <tr>
                                    <td style="width: 170px; height: 19px">
                                        <asp:Label ID="Label4" runat="server" CssClass="Label" Text="Payment Method" Width="64%"></asp:Label>
                                    </td>
                                    <td style="width: 10px; height: 19px">
                                        :</td>
                                    <td style="width: 640px; height: 19px">
                                    <asp:Label ID="lblPMethod" CssClass="Label" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="width: 170px; height: 19px">
                                    </td>
                                    <td style="width: 10px; height: 19px">
                                    </td>
                                    <td style="width: 640px; height: 19px">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 170px; height: 19px">
                                        <asp:Label ID="Label8" runat="server" CssClass="Label" Text="ID"></asp:Label><asp:Label
                                            ID="Label9" runat="server" CssClass="Label" Font-Bold="False" ForeColor="Red"
                                            Text="*"></asp:Label></td>
                                    <td style="width: 10px; height: 19px">
                                        :</td>
                                    <td style="width: 640px; height: 19px">
                                        <asp:TextBox ID="txtUID" runat="server"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtUID"
                                            CssClass="Label" Display="Dynamic" ErrorMessage="ID - only numeric characters [0-9] allowed"
                                            ForeColor="White" ValidationExpression="(\d){1,99}" ValidationGroup="Update">*</asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtUID"
                                            CssClass="Label" Display="Dynamic" ErrorMessage="ID is a mandatory field" ForeColor="White"
                                            ValidationGroup="Update">*</asp:RequiredFieldValidator></td>
                                </tr>
                                <tr>
                                    <td style="width: 150px; height: 19px">
                                    </td>
                                    <td style="width: 10px; height: 19px">
                                    </td>
                                    <td style="width: 640px; height: 19px">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 150px; height: 49px" valign="top">
                                        <asp:Label ID="Label13" runat="server" CssClass="Label" Text="Description"></asp:Label>
                                        <asp:Label ID="Label14" runat="server" CssClass="Label" Font-Bold="False" ForeColor="Red"
                                            Text="*"></asp:Label></td>
                                    <td style="width: 10px; height: 49px" valign="top">
                                        :</td>
                                    <td style="width: 640px; height: 49px">
                                        <asp:TextBox ID="txtUDesc" runat="server" Height="41px" MaxLength="1024" TextMode="MultiLine"
                                            Width="553px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtUDesc"
                                            CssClass="Label" Display="Dynamic" ErrorMessage="Description is a mandatory field"
                                            ForeColor="White" ValidationGroup="Update">*</asp:RequiredFieldValidator></td>
                                </tr>
                                <tr>
                                    <td style="width: 150px; height: 15px" valign="top">
                                    </td>
                                    <td style="width: 10px; height: 15px" valign="top">
                                    </td>
                                    <td style="width: 640px; height: 15px">
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
                    <td style="height: 10px; width: 803px;">
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
                    <td style="width: 803px">
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
                    <td style="width: 803px; height: 10px">
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
