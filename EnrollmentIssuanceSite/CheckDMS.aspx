<%@ Page MasterPageFile="~/iden.master" Language="C#" AutoEventWireup="true" Inherits="EnrollmentIssuanceSite.CheckDMS" Codebehind="CheckDMS.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
<asp:Panel ID="Panel1" runat="server" Height="28px" BackImageUrl="./images/bg.gif" Width="100%">
<asp:Label ID="fly" runat="server" Height="16px" CssClass="HeaderMainTitle" ForeColor="DimGray" BackColor="Transparent" Width="353px" >Visa - Possible Match Profiles in DMS</asp:Label></asp:Panel>
 <input id="IDPERSON" type="hidden" runat="server"/> 
 <input id="FORMNO" type="hidden" runat="server"/> 
 <input id="DOCTYPE" type="hidden" runat="server"/> 
 <input id="SURNAME" type="hidden" runat="server"/> 
 <input id="FIRSTNAME" type="hidden" runat="server"/> 
 <input id="MIDDLENAME" type="hidden" runat="server"/> 
 <input id="NATIONALITY" type="hidden" runat="server"/> 
 <input id="BIRTHDATE" type="hidden" runat="server"/> 
 <input id="BIRTHCOUNTRY" type="hidden" runat="server"/> 
  <table id="tbDataGrid" cellspacing="2"  cellpadding="0" width="98%" border="0" runat="server" visible="true">
      <tr runat="server" >
          <td style="width: 8px">
          </td>
          <td colspan="3" style="height: 20px">
              &nbsp;</td>
      </tr>
 
            <tr runat="server" visible="false" id="trDG">
                <td style="width: 8px;"> </td>               
                <td colspan="3" >
                <div id="Div2" runat="server" class="PanelSearch">
                <table width="98%" border="0" cellspacing="2" cellpadding="0" id="tbDG">
                    <tr>
                        <td style="width: 8px">
                        </td>
                        <td colspan="6">
                            <asp:GridView ID="dgDMS" runat="server" AllowPaging="True" CellPadding="3" CssClass="DataGrid"
                                ForeColor="#333333" GridLines="None" PageSize="5" Width="785px" OnPageIndexChanging="dgDMS_PageIndexChanging" AllowSorting="True" AutoGenerateColumns="False" OnRowCommand="dgDMS_RowCommand">
                                <Columns>                                 
                                                                                                                   
                                 <asp:TemplateField>
                                    <ItemTemplate>
                                       <asp:Image ID="imgLink" runat="server" ImageUrl="~/images/link.JPG" Visible='<%# FormatLinkStatus(Eval("LINK")) %>'></asp:Image>                                        
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" Width="30px" VerticalAlign="Top" />
                                     <ItemStyle HorizontalAlign="Center" Width="30px" />
                                 </asp:TemplateField>    
                                <asp:TemplateField HeaderText="DMS ID">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDMS" runat="server" Text='<%# Eval("DMSID") %>'></asp:Label>
                                    </ItemTemplate>
                                     <ItemStyle Width="70px" />
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
                                <asp:TemplateField HeaderText="BIRTH COUNTRY">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCOB" runat="server" Text='<%# Eval("BirthCtry") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" Width="70px" />
                                    <HeaderStyle HorizontalAlign="Left" Width="70px" VerticalAlign="Top" />
                                </asp:TemplateField>                               
                                <asp:TemplateField HeaderText="NATIONALITY">
                                    <ItemTemplate>
                                        <asp:Label ID="lblNationality" runat="server" Text='<%# Eval("Nationality") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" Width="70px" />
                                    <HeaderStyle HorizontalAlign="Left" Width="70px" VerticalAlign="Top" />
                                </asp:TemplateField>    
                                <asp:TemplateField>
                                    <ItemTemplate>
                                       <asp:ImageButton ID="ImageButton1" runat="server"  CommandArgument='<%# Eval("DMSID")+"-"+Eval("LINK") %>' CommandName="View"  CausesValidation="False" ImageUrl="~/images/viewImage.gif" AlternateText="View"/>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" Width="30px" VerticalAlign="Top" />
                                     <ItemStyle HorizontalAlign="Center" Width="30px" />
                                 </asp:TemplateField>                            
                                </Columns>
                                
                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <RowStyle BackColor="#EFF3FB" HorizontalAlign="Left" />
                                <EditRowStyle BackColor="#2461BF" />
                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                                <AlternatingRowStyle BackColor="White" />
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 8px; height: 20px;">
                        </td>
                        <td colspan="6" style="height: 20px">
                            <asp:Label ID="Label1" runat="server" CssClass="Label" Text="Application Linked to : "></asp:Label>
                            <asp:Label ID="lblLinkDMSID" runat="server" CssClass="Label" Text="-"></asp:Label></td>
                    </tr>
                </table>
                </div>
              </td>
          </tr>        
      <tr>
          <td style="width: 8px">
          </td>
          <td colspan="3">
              <asp:Label ID="lblResult" runat="server" CssClass="Label" EnableViewState="False"
                  ForeColor="Blue" Visible="False" Width="276px"></asp:Label>
              <asp:Label ID="lblError" runat="server" CssClass="Label" EnableViewState="False" ForeColor="Red"
                  Visible="False" Width="368px"></asp:Label></td>
      </tr>
      <tr>
          <td style="width: 8px; height:10px">
          </td>
          <td colspan="3">
          </td>
      </tr>
      <tr>
          <td style="width: 8px">
          </td>
          <td colspan="3">
              <asp:Button ID="btnBack" runat="server" OnClick="btnBack_Click" Text=" Back" />
              <asp:Button ID="btnNext" runat="server" OnClick="btnNext_Click" Text="Scan Document" /></td>
      </tr>
      </table>    
<asp:HiddenField ID="txtCompName" runat="server" />  
<script type="text/javascript">

GetPcName();
</script>
</asp:Content>