<%@ Page Language="C#" MasterPageFile="~/iden.master" AutoEventWireup="true"
    Inherits="ConfigLocation" Codebehind="ConfigLocation.aspx.cs" %>

<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="Server">
    <asp:Panel ID="Panel1" runat="server" BackImageUrl="./images/bg.gif" Height="28px"
        Width="100%">
        <asp:Label ID="fly" runat="server" BackColor="Transparent" CssClass="HeaderMainTitle"
            Height="16px" Width="353px">Visa - Location Configuration</asp:Label></asp:Panel>
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
                            <asp:Label ID="Label3" runat="server" Text="List of Location Configurations" CssClass="LabelHeadGreen"
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
                            <asp:GridView ID="gvConfigLocation" runat="server" AllowPaging="True" CellPadding="3" CssClass="Label"
                                ForeColor="#333333" GridLines="None" 
                                OnPageIndexChanging="PageIndexChanging_Click"  
                                 OnSelectedIndexChanged="gvConfigLocation_SelectedIndexChanged" AutoGenerateColumns="False" Width="781px">
                                <PagerSettings FirstPageText="&lt;&lt;" PreviousPageText="Previous" NextPageText="Next"
                                    LastPageText="&gt;&gt;"></PagerSettings>
                                <Columns>
                                    <asp:BoundField DataField="LOCATIONID" HeaderText="LOCATION ID" />
                                    <asp:BoundField DataField="LOCATIONNAME" HeaderText="LOCATION NAME" />
                                    <asp:BoundField DataField="ISENROLLMENT" HeaderText="ENROLLMENT" />
                                    <asp:BoundField DataField="ISPAYMENT" HeaderText="PAYMENT" />
                                    <asp:BoundField DataField="ISAPPROVAL" HeaderText="APPROVAL" />
                                    <asp:BoundField DataField="ISISSUANCE" HeaderText="ISSUANCE" />
                                    <asp:BoundField DataField="OTHERCOUNTER1" HeaderText="OTHER COUNTER 1" />
                                    <asp:BoundField DataField="OTHERCOUNTER2" HeaderText="OTHER COUNTER 2" />
                                    <asp:BoundField DataField="OTHERCOUNTER3" HeaderText="OTHER COUNTER 3" />
                                    <asp:BoundField DataField="OTHERCOUNTER4" HeaderText="OTHER COUNTER 4" />
                                    <asp:BoundField DataField="OTHERCOUNTER5" HeaderText="OTHER COUNTER 5" />
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
                                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"  HorizontalAlign="Left" VerticalAlign="Top" />
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
                        <asp:Label ID="Label1" runat="server" Width="300px" Text="Insert New Location Configuration"
                            CssClass="LabelHeadGreen"></asp:Label></td>
                    <td class="Title" colspan="1" style="height: 20px">
                        &nbsp;&nbsp;</td>
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
                        <table style="width: 800px" id="Table6" cellspacing="0" cellpadding="0" border="0"
                            runat="server">
                            <tbody>
                                <tr>
                                    <td style="width: 250px; height: 19px">
                                        <asp:Label ID="Label6" runat="server" CssClass="Label" Text="Location Name"></asp:Label>
                                        <asp:Label ID="Label9" runat="server" CssClass="Label" Font-Bold="False" ForeColor="Red"
                                            Text="*"></asp:Label></td>
                                    <td style="width: 10px; height: 19px">
                                        :</td>
                                    <td style="height: 19px" colspan="4">
                                        <asp:DropDownList ID="ddlLocationName" runat="server" DataTextField="Name" DataValueField="ID">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlLocationName"
                                            CssClass="Label" Display="Dynamic" ErrorMessage="Location Name is a mandatory field"
                                            ForeColor="White" ValidationGroup="Insert">*</asp:RequiredFieldValidator></td>
                                </tr>
                                <tr>
                                    <td style="width: 250px; height: 19px">
                                    </td>
                                    <td style="width: 10px; height: 19px">
                                    </td>
                                    <td style="width: 592px; height: 19px">
                                    </td>
                                    <td style="width: 250px; height: 19px">
                                    </td>
                                    <td style="height: 19px">
                                    </td>
                                    <td style="width: 640px; height: 19px">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 250px; height: 19px">
                                        <asp:Label ID="Label4" runat="server" CssClass="Label" Text="Enrollment"></asp:Label>
                                        </td>
                                    <td style="width: 10px; height: 19px">
                                        :</td>
                                    <td style="width: 592px; height: 19px">
                                        <asp:CheckBox ID="chkEnrollment" runat="server" /></td>
                                    <td style="width: 250px; height: 19px">
                                        <asp:Label ID="Label10" runat="server" CssClass="Label" Text="Payment"></asp:Label>
                                        </td>
                                    <td style="height: 19px">
                                        :&nbsp;
                                    </td>
                                    <td style="width: 640px; height: 19px">
                                        <asp:CheckBox ID="chkPayment" runat="server" /></td>
                                </tr>
                                <tr>
                                    <td style="width: 250px; height: 19px">
                                    </td>
                                    <td style="width: 10px; height: 19px">
                                    </td>
                                    <td style="width: 592px; height: 19px">
                                    </td>
                                    <td style="width: 250px; height: 19px">
                                    </td>
                                    <td style="height: 19px">
                                    </td>
                                    <td style="width: 640px; height: 19px">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 250px; height: 19px">
                                        <asp:Label ID="Label12" runat="server" CssClass="Label" Text="Approval"></asp:Label>
                                        </td>
                                    <td style="width: 10px; height: 19px">
                                        :</td>
                                    <td style="width: 592px; height: 19px">
                                        <asp:CheckBox ID="chkApproval" runat="server" /></td>
                                    <td style="width: 250px; height: 19px">
                                        <asp:Label ID="Label14" runat="server" CssClass="Label" Text="Issuance"></asp:Label>
                                        </td>
                                    <td style="height: 19px">
                                        :</td>
                                    <td style="width: 640px; height: 19px">
                                        <asp:CheckBox ID="chkIssuance" runat="server" /></td>
                                </tr>
                                <tr>
                                    <td style="width: 250px; height: 19px">
                                    </td>
                                    <td style="width: 10px; height: 19px">
                                    </td>
                                    <td style="width: 592px; height: 19px">
                                    </td>
                                    <td style="width: 250px; height: 19px">
                                    </td>
                                    <td style="height: 19px">
                                    </td>
                                    <td style="width: 640px; height: 19px">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 250px; height: 19px">
                                        <asp:Label ID="Label17" runat="server" CssClass="Label" Text="Other Counter 1"></asp:Label>
                                        </td>
                                    <td style="width: 10px; height: 19px">
                                        :</td>
                                    <td style="width: 592px; height: 19px">
                                        <asp:CheckBox ID="chkCounter1" runat="server" /></td>
                                    <td style="width: 250px; height: 19px">
                                        <asp:Label ID="Label21" runat="server" CssClass="Label" Text="Other Counter 2"></asp:Label>
                                        </td>
                                    <td style="height: 19px">
                                        :</td>
                                    <td style="width: 640px; height: 19px">
                                        <asp:CheckBox ID="chkCounter2" runat="server" /></td>
                                </tr>
                                <tr>
                                    <td style="width: 250px; height: 19px">
                                    </td>
                                    <td style="width: 10px; height: 19px">
                                    </td>
                                    <td style="width: 592px; height: 19px">
                                    </td>
                                    <td style="width: 250px; height: 19px">
                                    </td>
                                    <td style="height: 19px">
                                    </td>
                                    <td style="width: 640px; height: 19px">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 250px; height: 19px">
                                        <asp:Label ID="Label23" runat="server" CssClass="Label" Text="Other Counter 3"></asp:Label>
                                        </td>
                                    <td style="width: 10px; height: 19px">
                                        :</td>
                                    <td style="width: 592px; height: 19px">
                                        <asp:CheckBox ID="chkCounter3" runat="server" /></td>
                                    <td style="width: 250px; height: 19px">
                                        <asp:Label ID="Label25" runat="server" CssClass="Label" Text="Other Counter 4"></asp:Label>
                                        </td>
                                    <td style="height: 19px">
                                        :</td>
                                    <td style="width: 640px; height: 19px">
                                        <asp:CheckBox ID="chkCounter4" runat="server" /></td>
                                </tr>
                                <tr>
                                    <td style="width: 250px; height: 19px">
                                    </td>
                                    <td style="width: 10px; height: 19px">
                                    </td>
                                    <td style="width: 592px; height: 19px">
                                    </td>
                                    <td style="width: 250px; height: 19px">
                                    </td>
                                    <td style="height: 19px">
                                    </td>
                                    <td style="width: 640px; height: 19px">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 250px; height: 19px">
                                        <asp:Label ID="Label27" runat="server" CssClass="Label" Text="Other Counter 5"></asp:Label>
                                        </td>
                                    <td style="width: 10px; height: 19px">
                                        :</td>
                                    <td style="width: 592px; height: 19px">
                                        <asp:CheckBox ID="chkCounter5" runat="server" /></td>
                                    <td style="width: 250px; height: 19px">
                                    </td>
                                    <td style="height: 19px">
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
                        <asp:Label ID="lblInErr" runat="server" Text="Label" CssClass="ErrLabel" Visible="false"></asp:Label>
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="Label" ValidationGroup="Insert" ShowMessageBox="True" ShowSummary="False">
                        </asp:ValidationSummary>
                    </td>
                    <td style="height: 10px">
                    </td>
                </tr>
                <tr>
                    <td style="width: 5px">
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
                    <td style="height: 4px; width: 5px;">
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
                        <asp:Label ID="Label5" runat="server" Width="300px" Text="Update Location Configuration"
                            CssClass="LabelHeadGreen"></asp:Label></td>
                    <td class="Title" colspan="1" style="height: 14px">
                        &nbsp;</td>
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
                        <table style="width: 800px" id="Table2" cellspacing="0" cellpadding="0" border="0"
                            runat="server">
                            <tbody>
                                <tr>
                                    <td style="width: 250px; height: 19px">
                                        <asp:Label ID="Label2" runat="server" CssClass="Label" Text="Location ID"></asp:Label></td>
                                    <td style="width: 10px; color: #000000; height: 19px">
                                        :</td>
                                    <td colspan="4" style="height: 19px">
                                        <asp:Label ID="lblLocationID" runat="server" CssClass="Label"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="width: 250px; height: 19px">
                                    </td>
                                    <td style="width: 10px; color: #000000; height: 19px">
                                    </td>
                                    <td colspan="4" style="height: 19px">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 250px; height: 19px">
                                        <asp:Label ID="Label29" runat="server" CssClass="Label" Text="Location Name"></asp:Label>
                                        </td>
                                    <td style="width: 10px; height: 19px; color: #000000;">
                                        :</td>
                                    <td style="height: 19px" colspan="4">
                                        <asp:Label ID="lblLocationName" runat="server" CssClass="Label"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="width: 250px; height: 19px">
                                    </td>
                                    <td style="width: 10px; height: 19px">
                                    </td>
                                    <td style="width: 592px; height: 19px">
                                    </td>
                                    <td style="width: 250px; height: 19px">
                                    </td>
                                    <td style="height: 19px">
                                    </td>
                                    <td style="width: 640px; height: 19px">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 250px; height: 19px">
                                        <asp:Label ID="Label31" runat="server" CssClass="Label" Text="Enrollment"></asp:Label>
                                        </td>
                                    <td style="width: 10px; height: 19px">
                                        :</td>
                                    <td style="width: 592px; height: 19px">
                                        <asp:CheckBox ID="chkUEnrollment" runat="server" /></td>
                                    <td style="width: 250px; height: 19px">
                                        <asp:Label ID="Label33" runat="server" CssClass="Label" Text="Payment"></asp:Label>
                                        </td>
                                    <td style="height: 19px">
                                        :&nbsp;
                                    </td>
                                    <td style="width: 640px; height: 19px">
                                        <asp:CheckBox ID="chkUPayment" runat="server" /></td>
                                </tr>
                                <tr>
                                    <td style="width: 250px; height: 19px">
                                    </td>
                                    <td style="width: 10px; height: 19px">
                                    </td>
                                    <td style="width: 592px; height: 19px">
                                    </td>
                                    <td style="width: 250px; height: 19px">
                                    </td>
                                    <td style="height: 19px">
                                    </td>
                                    <td style="width: 640px; height: 19px">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 250px; height: 19px">
                                        <asp:Label ID="Label35" runat="server" CssClass="Label" Text="Approval"></asp:Label>
                                        </td>
                                    <td style="width: 10px; height: 19px">
                                        :</td>
                                    <td style="width: 592px; height: 19px">
                                        <asp:CheckBox ID="chkUApproval" runat="server" /></td>
                                    <td style="width: 250px; height: 19px">
                                        <asp:Label ID="Label37" runat="server" CssClass="Label" Text="Issuance"></asp:Label>
                                        </td>
                                    <td style="height: 19px">
                                        :</td>
                                    <td style="width: 640px; height: 19px">
                                        <asp:CheckBox ID="chkUIssuance" runat="server" /></td>
                                </tr>
                                <tr>
                                    <td style="width: 250px; height: 19px">
                                    </td>
                                    <td style="width: 10px; height: 19px">
                                    </td>
                                    <td style="width: 592px; height: 19px">
                                    </td>
                                    <td style="width: 250px; height: 19px">
                                    </td>
                                    <td style="height: 19px">
                                    </td>
                                    <td style="width: 640px; height: 19px">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 250px; height: 19px">
                                        <asp:Label ID="Label39" runat="server" CssClass="Label" Text="Other Counter 1"></asp:Label>
                                        </td>
                                    <td style="width: 10px; height: 19px">
                                        :</td>
                                    <td style="width: 592px; height: 19px">
                                        <asp:CheckBox ID="chkUCounter1" runat="server" /></td>
                                    <td style="width: 250px; height: 19px">
                                        <asp:Label ID="Label41" runat="server" CssClass="Label" Text="Other Counter 2"></asp:Label>
                                        </td>
                                    <td style="height: 19px">
                                        :</td>
                                    <td style="width: 640px; height: 19px">
                                        <asp:CheckBox ID="chkUCounter2" runat="server" /></td>
                                </tr>
                                <tr>
                                    <td style="width: 250px; height: 19px">
                                    </td>
                                    <td style="width: 10px; height: 19px">
                                    </td>
                                    <td style="width: 592px; height: 19px">
                                    </td>
                                    <td style="width: 250px; height: 19px">
                                    </td>
                                    <td style="height: 19px">
                                    </td>
                                    <td style="width: 640px; height: 19px">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 250px; height: 19px">
                                        <asp:Label ID="Label43" runat="server" CssClass="Label" Text="Other Counter 3"></asp:Label>
                                        </td>
                                    <td style="width: 10px; height: 19px">
                                        :</td>
                                    <td style="width: 592px; height: 19px">
                                        <asp:CheckBox ID="chkUCounter3" runat="server" /></td>
                                    <td style="width: 250px; height: 19px">
                                        <asp:Label ID="Label45" runat="server" CssClass="Label" Text="Other Counter 4"></asp:Label>
                                        </td>
                                    <td style="height: 19px">
                                        :</td>
                                    <td style="width: 640px; height: 19px">
                                        <asp:CheckBox ID="chkUCounter4" runat="server" /></td>
                                </tr>
                                <tr>
                                    <td style="width: 250px; height: 19px">
                                    </td>
                                    <td style="width: 10px; height: 19px">
                                    </td>
                                    <td style="width: 592px; height: 19px">
                                    </td>
                                    <td style="width: 250px; height: 19px">
                                    </td>
                                    <td style="height: 19px">
                                    </td>
                                    <td style="width: 640px; height: 19px">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 250px; height: 19px">
                                        <asp:Label ID="Label47" runat="server" CssClass="Label" Text="Other Counter 5"></asp:Label>
                                        </td>
                                    <td style="width: 10px; height: 19px">
                                        :</td>
                                    <td style="width: 592px; height: 19px">
                                        <asp:CheckBox ID="chkUCounter5" runat="server" /></td>
                                    <td style="width: 250px; height: 19px">
                                    </td>
                                    <td style="height: 19px">
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
</asp:Content>
