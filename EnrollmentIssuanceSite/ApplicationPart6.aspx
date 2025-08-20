<%@ Page MasterPageFile="~/iden.master" Language="C#" AutoEventWireup="true" Inherits="EnrollmentIssuanceSite.ApplicationPart6" Codebehind="ApplicationPart6.aspx.cs" %>

<asp:Content ContentPlaceHolderID="Content" runat="server">
<script type="text/javascript" src="inc/scan.js"></script>
 <input id="IsNew" type="hidden" runat="server" />
<asp:Panel ID="Panel1" runat="server" Height="28px" BackImageUrl="./images/bg.gif"  Width="100%">
       
        <asp:Label ID="fly" runat="server" Height="16px" CssClass="HeaderMainTitle" ForeColor="DimGray" BackColor="Transparent" Width="250px" >Visa - Scan Supporting Document</asp:Label></asp:Panel>
    <table width="98%">
        <tr>
            <td style="width: 10px">
            </td>
            <td colspan="4" style="height: 19px;">
                </td>
        </tr>
        <tr>
            <td style="width: 10px">
            </td>
            <td style="width: 172px">
                <asp:Label ID="Label4" runat="server" CssClass="Label" Font-Bold="True" Font-Names="Arial"
                    Font-Size="13px" Width="103px">Scanned Image</asp:Label><asp:Label ID="Label28" runat="server"
                        CssClass="Label" ForeColor="Red" Text="*"></asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="SCANNEDIMAGE"
                    CssClass="Label" ErrorMessage="Scanned image is a mandatory field" ForeColor="White">*</asp:RequiredFieldValidator></td>
            <td colspan="3">
            </td>
        </tr>
        <tr>
            <td style="width: 10px">
            </td>
            <td rowspan="1" style="width: 172px" valign="top">
                        <asp:Image ID="IMAGEBOX" runat="server" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1px"
                            Height="194px" ImageUrl="./images/spacer.gif" Width="153px" /></td>
            <td colspan="3" valign="top">
                <table>
                    <tr>
                        <td style="width: 139px" valign="top">
                    <asp:Label ID="Label3" runat="server" Text="Type of Document" Width="103px" CssClass="Label"></asp:Label><asp:Label
                        ID="Label5" runat="server" CssClass="Label" ForeColor="Red" Text="*"></asp:Label><asp:RequiredFieldValidator
                            ID="RequiredFieldValidator1" runat="server" ControlToValidate="SCANNEDDOC" CssClass="Label"
                            ErrorMessage="Type of document is a mandatory field" ForeColor="White">*</asp:RequiredFieldValidator></td>
                        <td colspan="2">
                        <asp:DropDownList ID="SCANNEDDOC" runat="server" Width="314px" CssClass="Label" TabIndex="1">
                        </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td style="width: 139px" valign="top">
                            <asp:Label ID="Label2" runat="server" Text="Description" CssClass="Label"></asp:Label>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="DESC"
                                CssClass="Label" ErrorMessage="Document descriptions - Some special characters are NOT allowed"
                                ForeColor="White" ValidationExpression="([A-Z]|[a-z]|[-@#/.,&quot;':\]|[0-9]|\s){1,100}">*</asp:RegularExpressionValidator></td>
                        <td colspan="2">
                            <asp:TextBox ID="DESC" runat="server" TextMode="MultiLine" Rows="4" Width="309px" TabIndex="2" MaxLength="50" onkeypress="return textboxMultilineMaxNumber(this,50)" onpaste="return doPaste(this,50)" CssClass="Label"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="width: 139px">
                            <asp:Label ID="Label1" runat="server" Text="Page Number" CssClass="Label"></asp:Label>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="PAGENO"
                                CssClass="Label" ErrorMessage="Page Number - Only number is allowed" ValidationExpression="([0-9]|[1-9]|\d){1,9}" ForeColor="White">*</asp:RegularExpressionValidator></td>
                        <td colspan="2">
                            <asp:TextBox ID="PAGENO" runat="server" Width="165px" TabIndex="3"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="width: 139px">
                        </td>
                        <td colspan="2">
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="width: 10px">
            </td>
            <td rowspan="1" style="width: 172px" valign="top">
            </td>
            <td colspan="3">
                <asp:Label ID="lblError" runat="server" CssClass="Label" Visible="False" Width="386px" EnableViewState="False" ForeColor="Red"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 10px">
            </td>
            <td rowspan="1" style="width: 172px" valign="top">
            </td>
            <td colspan="3">
                <asp:Label ID="lblNote" runat="server" CssClass="Label" Visible="False"
                    Width="388px" EnableViewState="False" ForeColor="Blue"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 10px">
            </td>
            <td rowspan="1" style="width: 172px" valign="top">
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="Label" ShowMessageBox="True"
                    ShowSummary="False" />
            </td>
            <td colspan="3">
                <asp:Button ID="btn_Back" runat="server" Text="Back" OnClick="btn_Back_Click" CausesValidation="False" /><input onclick="CaptureImage('IMAGE1','IMAGEBOX','SCANNEDIMAGE')" id="btnScan" style="width: 133px; height: 24px"
                                type="button" value="Scan Document" runat="server" /><asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" TabIndex="4" /><asp:Button ID="btn_Next" runat="server" Text="Next" OnClick="btn_Next_Click" CausesValidation="False" /></td>
        </tr>
        <tr>
            <td style="width: 10px">
            </td>
            <td colspan="4">
                <hr/>
                        &nbsp;</td>
        </tr>
    </table>
    
    <table id="tbDataGrid" cellspacing="2"  cellpadding="0" width="98%" border="0" runat="server" visible="true">
 
            <tr>
                <td style="width: 8px;"> </td>               
                <td colspan="3" >
                <div id="Div2" runat="server" class="PanelSearch">
                <table width="98%" border="0" cellspacing="2" cellpadding="0" id="Table1"  runat="server">
                    <tr>
                        <td style="width: 8px">
                        </td>
                        <td colspan="6">
                           <asp:GridView ID="dgScanDocList" runat="server" AutoGenerateColumns="False" CellPadding="2"
            ForeColor="#333333" GridLines="None" BorderStyle="None" CssClass="DataGrid" OnRowCommand="dgScanDocList_RowCommand" Width="785px" OnRowDeleting="dgScanDocList_RowDeleting" AllowPaging="True" OnPageIndexChanging="dgScanDocList_PageIndexChanging" PageSize="5">
                                <Columns>
                                 <asp:TemplateField>
                                 <ItemTemplate>                                       
                                        <asp:ImageButton ID="ImageButton2" runat="server"  CommandArgument='<%# Eval("ID")%>' CommandName="Delete"  CausesValidation="False" ImageUrl="~/images/delete.gif" AlternateText="Delete Document" OnClientClick='return confirm("Are you sure you want to delete this entry?");'  Visible='<%# Eval("SYSTEM").ToString().TrimStart().TrimEnd()=="VIS"?true:false %>'/>
                                 </ItemTemplate>
                                 <ItemStyle HorizontalAlign="Left" />
                                 </asp:TemplateField>
                                 <asp:TemplateField>
                                    <ItemTemplate>                                      
                                        <asp:ImageButton ID="ImageButton1" runat="server"  CommandArgument='<%#  Eval("ID")+"-"+Eval("SYSTEM") %>' CommandName="View"  CausesValidation="False" ImageUrl="~/images/viewImage.gif" AlternateText="View Document"/>
                                    </ItemTemplate>
                                     <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                     <HeaderStyle HorizontalAlign="Center" />
                                 </asp:TemplateField> 
                                   <asp:TemplateField HeaderText="SYSTEM">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSysten" runat="server" Text='<%# Eval("SYSTEM") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" />
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                 <asp:TemplateField HeaderText="DOCUMENT TYPE">
                                    <ItemTemplate>
                                        <asp:Label ID="lblType" runat="server" Text='<%# Eval("ScannedDoc") %>'></asp:Label>
                                    </ItemTemplate>
                                     <ItemStyle HorizontalAlign="Left" />
                                     <HeaderStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="PAGE NO">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPageNo" runat="server" Text='<%# Eval("PageNo") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="DESCRIPTION">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDesc" runat="server" Text='<%# Eval("IMAGEDESC") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ENTRY TIME">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTime" runat="server" Text='<%# Eval("IMAGEENTRYTIME") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle HorizontalAlign="Left" />
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
                    <tr>
                        <td style="width: 8px">
                        </td>
                        <td colspan="6">
                            <asp:Label ID="lblResult" runat="server" CssClass="Label" EnableViewState="False"
                                ForeColor="Blue" Visible="False" Width="388px"></asp:Label>
                            </td>
                    </tr>
                </table>
                </div>
              </td>
          </tr>        
      </table>
       <asp:HiddenField ID="txtCompName" runat="server" />  
       <asp:HiddenField ID="HFIDPERSON" runat="server" /> 
       <asp:HiddenField ID="DMSID" runat="server" /> 
       <asp:HiddenField ID="FORMNO" runat="server" /> 
       <asp:HiddenField ID="SM" runat="server" /> 
    
    <div style="z-index: 101; left: -122px; visibility: hidden; width: 100px; position: absolute;
        top: 429px; height: 100px">
    <asp:TextBox ID="SCANNEDIMAGE" runat="server" Width="32px"></asp:TextBox></div>
<script type="text/javascript">
function textboxMultilineMaxNumber(txt,maxLen)
{
    try
    {
        if(txt.value.length > (maxLen-1))return false;
    }
    catch(e)
    {
    }
}
function doPaste(txt,maxLen)
{   
     var value = txt.value;
     if(maxLen)
     {
          event.returnValue = false;
          maxLength = parseInt(maxLen);
          var oTR = txt.document.selection.createRange();
          var iInsertLength = maxLen - value.length + oTR.text.length;
          var sData = window.clipboardData.getData("Text").substr(0,iInsertLength);
          oTR.text = sData;
     }
}
GetPcName();
</script>  
 
</asp:Content>

