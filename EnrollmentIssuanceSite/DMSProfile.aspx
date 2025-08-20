<%@ Page Language="C#" MasterPageFile="~/iden.master" AutoEventWireup="true" Inherits="EnrollmentIssuanceSite.DMSProfile" Codebehind="DMSProfile.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
<asp:Panel ID="Panel1" runat="server" Height="28px" BackImageUrl="./images/bg.gif"
        Width="100%">
        <asp:Label ID="fly" runat="server" Height="16px" CssClass="HeaderMainTitle" ForeColor="DimGray" BackColor="Transparent" Width="353px" >Visa - DMS Profile Information</asp:Label></asp:Panel>
         <table style="width: 98%" border="0" cellpadding="0" cellspacing="2" id="tbPresentAdd">
        
        <tr>
            <td style="width: 6px; height: 18px;" >
            </td>           
            <td colspan="6" style="height: 18px; background-color: #c6efef;">
                <asp:Label ID="Label4" runat="server" CssClass="LabelHeadGreen" Text="Personal Details"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 6px">
            </td>
            <td colspan="6">
            </td>
        </tr>
      
        <tr>
            <td style="width: 6px;">
            </td>
            <td style="width: 128px" valign="top">
                <asp:Label ID="Label1" runat="server" CssClass="Label" Text="Surname" Width="105px"></asp:Label></td>
            <td style="width: 8px;" valign="top">
                :</td>
            <td style="width: 185px;">
                <asp:Label ID="SURNAME" runat="server" CssClass="Label" Width="215px"></asp:Label></td>
            <td style="width: 114px;">
                <asp:Label ID="Label11" runat="server" CssClass="Label" Text="Sex"></asp:Label></td>
            <td style="width: 7px">
                :</td>
            <td style="width: 203px; ">
                <asp:Label ID="SEX" runat="server" CssClass="Label" Width="215px"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 6px; height: 24px;">
            </td>
            <td style="width: 128px; height: 24px">
                <asp:Label ID="Label3" runat="server" Text="First Name" CssClass="Label" Width="65px"></asp:Label></td>
            <td style="width: 8px; height: 24px;">
                :</td>
            <td style="width: 185px; height: 24px;">
                <asp:Label ID="FIRSTNAME" runat="server" CssClass="Label" Width="214px"></asp:Label></td>
            <td style="width: 114px; height: 24px;">
                <asp:Label ID="Label21" runat="server" CssClass="Label" Text="Date of Birth" Width="72px"></asp:Label>
                </td>
            <td style="width: 7px; height: 24px">
                :</td>
            <td style="width: 203px; height: 24px;">
                <asp:Label ID="BIRTHDATE" runat="server" CssClass="Label" Width="215px"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 6px">
            </td>
            <td style="width: 128px">
                <asp:Label ID="Label2" runat="server" Text="Middle Name" CssClass="Label" Width="78px"></asp:Label></td>
            <td style="width: 8px">
                :</td>
            <td style="width: 185px">
                <asp:Label ID="MIDDLENAME" runat="server" CssClass="Label" Width="215px"></asp:Label></td>
            <td style="width: 114px">
                <asp:Label ID="Label20" runat="server" CssClass="Label" Text="Nationality"></asp:Label>
                </td>
            <td style="width: 7px">
                :</td>
            <td style="width: 203px">
                <asp:Label ID="NATIONALITY" runat="server" CssClass="Label" Width="105px"></asp:Label></td>
        </tr>
             <tr>
                 <td style="width: 6px">
                 </td>
                 <td style="width: 128px">
                 </td>
                 <td style="width: 8px">
                 </td>
                 <td style="width: 185px">
                 </td>
                 <td style="width: 114px">
                 </td>
                 <td style="width: 7px">
                 </td>
                 <td style="width: 203px">
                 </td>
             </tr>
             <tr>
                 <td style="width: 6px">
                 </td>
                 <td colspan="6">
                     <asp:Label ID="lblError" runat="server" CssClass="Label" EnableViewState="False"
                         ForeColor="Red" Visible="False" Width="404px"></asp:Label></td>
             </tr>
             <tr>
            <td style="width: 6px; height: 18px;" >
            </td>           
            <td colspan="6" style="height: 18px; background-color: #c6efef;">
                <asp:Label ID="Label5" runat="server" CssClass="LabelHeadGreen" Text="DMS - Document Files"></asp:Label></td>
        </tr>
    </table>
      <table id="tbDataGrid" cellspacing="2"  cellpadding="0" width="98%" border="0" runat="server" visible="true">
 
            <tr>
                <td style="width: 8px;"> </td>               
                <td colspan="3" >
                <div id="DGborder" runat="server" class="PanelSearch">
                <table width="98%" border="0" cellspacing="2" cellpadding="0" id="Table1"  runat="server">
                    <tr>
                        <td style="width: 8px">
                        </td>
                        <td colspan="6">
                           <asp:GridView ID="dgScanDocList" runat="server" AutoGenerateColumns="False" CellPadding="2"
            ForeColor="#333333" GridLines="None" BorderStyle="None" CssClass="DataGrid" OnRowCommand="dgScanDocList_RowCommand" Width="785px" AllowPaging="True" OnPageIndexChanging="dgScanDocList_PageIndexChanging">
                                <Columns>
                                 
                                 <asp:TemplateField>
                                    <ItemTemplate>
                                       <asp:ImageButton ID="ImageButton1" runat="server"  CommandArgument='<%# Eval("ID") %>' CommandName="View"  CausesValidation="False" ImageUrl="~/images/viewImage.gif" AlternateText="View"/>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" Width="30px" VerticalAlign="Top" />
                                     <ItemStyle HorizontalAlign="Center" Width="30px" />
                                 </asp:TemplateField> 
                                
                                 <asp:TemplateField HeaderText="DOCUMENT TYPE">
                                    <ItemTemplate>
                                        <asp:Label ID="lblType" runat="server" Text='<%# Eval("ScannedDoc") %>'></asp:Label>
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
                                 <asp:TemplateField HeaderText="PAGE NO">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPageNo" runat="server" Text='<%# Eval("PageNo") %>'></asp:Label>
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
                                                      
                </table>
                </div>
              </td>
             
          </tr> 
           <tr>
                <td style="width: 8px">
                </td>
                <td colspan="3">
                  
                    </td>
        </tr>    
         
      </table>
      <table>
          <tr>
              <td style="width: 2px">
              </td>
              <td>
                  <asp:Label ID="lblResult" runat="server" CssClass="Label" EnableViewState="False"
                         ForeColor="Blue" Visible="False" Width="388px"></asp:Label></td>
          </tr>
         <tr>
                <td style="width: 2px">
                </td>
                <td>
                    <asp:Button ID="btnBack" runat="server" OnClick="btnBack_Click" Text="Back" />
                    <asp:Button
                        ID="btnLink" runat="server" OnClick="btnLink_Click" Text="Create Link" Width="77px" />
                    </td>
        </tr>     
      </table>
      <asp:HiddenField ID="txtCompName" runat="server" />  
       <asp:HiddenField ID="IDPERSON" runat="server" /> 
       <asp:HiddenField ID="DEPTID" runat="server" />  
        <asp:HiddenField ID="DMSID" runat="server" /> 
        <asp:HiddenField ID="FORMNO" runat="server" /> 
<script type="text/javascript">

GetPcName();
</script>
</asp:Content>