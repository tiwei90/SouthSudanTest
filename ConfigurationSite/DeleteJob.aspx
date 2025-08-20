<%@ Page Language="C#" MasterPageFile="~/iden.master" AutoEventWireup="true"
    Inherits="DeleteJob" Codebehind="DeleteJob.aspx.cs" %>

<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="Server" >
    <asp:Panel ID="Panel1" runat="server" BackImageUrl="./images/bg.gif" Height="24px"
        Width="100%">
        <asp:Label ID="fly" runat="server" BackColor="Transparent" CssClass="HeaderMainTitle"
            Height="16px" Width="353px">Visa - Delete Applicant & Application Profile </asp:Label></asp:Panel>
    <br />
    <table border="0">
    <tr><td style="padding-left:30px">
        <asp:Label ID="Label1" runat="server" Text="Application ID" CssClass="Label"></asp:Label>
        </td>
        <td style="width: 10px" >
            :</td>
        <td style="width: 637px">
    <asp:TextBox ID="txtAppID" runat="server" MaxLength="12"></asp:TextBox>&nbsp;
    <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" CausesValidation="False" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtAppID"
                    ErrorMessage="Document Number is a mandatory field" ForeColor="White"></asp:RequiredFieldValidator></td>
    </tr>
        <tr>
            <td>
            </td>
            <td style="width: 10px">
            </td>
            <td style="width: 637px">
            </td>
        </tr>
        <tr>
            <td>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="Label" ShowMessageBox="True"
                    ShowSummary="False" />
            </td>
            <td style="width: 10px">
            </td>
            <td style="width: 637px">
                <asp:Label ID="lblSearchError" runat="server" CssClass="Label" ForeColor="Blue"></asp:Label></td>
        </tr>
    <tr>
    <td></td>
        <td style="width: 10px">
        </td>
    <td style="width: 637px" >
        &nbsp;</td>
    </tr>
    </table>
    
    <table id="tbInfo" cellspacing="2"  cellpadding="0" width="98%" border="0" runat="server" visible="false">
           
            <tr>
                <td style="height: 15px; width: 8px;">
                </td>
                <td colspan="3" style="height: 19px; background-color: #c6efef;">
                    <asp:Label ID="Label11" runat="server" CssClass="LabelHeadGreen" Text="Applicant Information"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 8px;"> </td>               
                <td colspan="3" >
                <div id="Div1" runat="server" class="PanelSearch">
               <table width="98%" border="0" cellspacing="2" cellpadding="0" id="tbInfo2"  runat="server">
                    <tr>
                        <td style="width: 8px">
                        </td>
                        <td style="width: 132px">
                        </td>
                        <td style="width: 10px">
                        </td>
                        <td style="width: 288px">
                        </td>
                        <td style="width: 169px">
                        </td>
                        <td style="width: 9px">
                        </td>
                        <td>
                        </td>
                    </tr>
                   <tr>
                       <td style="width: 8px">
                       </td>
                       <td style="width: 132px">
                           <asp:Label ID="Label5" runat="server" CssClass="LabelHeadLine" Text="Application Details"></asp:Label></td>
                       <td style="width: 10px">
                       </td>
                       <td style="width: 288px">
                       </td>
                       <td align="left" colspan="2" rowspan="1">
                       </td>
                       <td>
                       </td>
                   </tr>
                   <tr>
                       <td style="width: 8px">
                       </td>
                       <td style="width: 132px">
                           <asp:Label ID="Label2" runat="server" CssClass="Label" Text="Application ID"></asp:Label></td>
                       <td style="width: 10px">:
                       </td>
                       <td style="width: 288px">
                       <asp:Label ID="APPID" runat="server" CssClass="Label" Width="200px"></asp:Label></td>
                       <td align="left" colspan="2" rowspan="6" valign="top">
                            <asp:Image ID="imgPhoto" runat="server" BorderColor="Silver" BorderStyle="Solid"
                                BorderWidth="1px" CssClass="ImgBorder" Height="110px" ImageUrl="~/images/NoImage.jpg"
                                Visible="true" Width="80px"/></td>
                       <td>
               <asp:Label ID="lblAppReason" runat="server" CssClass="Label" Width="172px" Visible="False"></asp:Label></td>
                   </tr>
                    <tr>
                        <td style="width: 8px">
                        </td>
                        <td style="width: 132px">
                            <asp:Label ID="Label3" runat="server" CssClass="Label" Text="Application Status"></asp:Label></td>
                        <td style="width: 10px">
                            :</td>
                        <td style="width: 288px">
                            <asp:Label ID="STAGECODE" runat="server" CssClass="Label" Width="261px"></asp:Label></td>
                        <td>
                <asp:Label ID="lblIDPerson" runat="server" CssClass="Label" Visible="False" Width="172px"></asp:Label></td>
                    </tr>           
                    <tr>
                        <td style="width: 8px">
                        </td>
                        <td style="width: 132px;">
                            <asp:Label ID="Label12" runat="server" CssClass="Label" Text="Document Type"></asp:Label></td>
                        <td style="width: 10px;">
                            :</td>
                        <td style="width: 288px;">
                            <asp:Label ID="DOCTYPE" runat="server" CssClass="Label" Width="172px"></asp:Label></td>
                        <td>
                            </td>
                    </tr>
        <tr>
            <td style="width: 8px;">
            </td>
            <td style="width: 132px;">
                <asp:Label ID="Label14" runat="server" CssClass="Label" Text="Entry Type"></asp:Label></td>
            <td style="width: 10px;">:
            </td>
            <td style="width: 288px">
                <asp:Label ID="ENTRYTYPE" runat="server" CssClass="Label" Width="172px"></asp:Label></td>
            <td style="height: 9px">
            </td>
        </tr>
       <tr >
           <td style="width: 8px">
           </td>
           <td style="width: 132px">
                            <asp:Label ID="Label13" runat="server" CssClass="Label" Text="Purpose of Application" Width="141px"></asp:Label></td>
           <td style="width: 10px">
               :</td>
           <td style="width: 288px">
                            <asp:Label ID="APPREASON" runat="server" CssClass="Label" Width="172px"></asp:Label></td>
           <td>
           </td>
       </tr>
        <tr>
            <td style="width: 8px">
            </td>
            <td style="width: 132px">
                </td>
            <td style="width: 10px">
                </td>
            <td style="width: 288px">
                </td>
            <td>
            </td>
        </tr>
                   <tr>
                       <td style="width: 8px; height: 8px;">
                       </td>
                       <td colspan="2" style="height: 8px">
                       </td>
                       <td style="width: 288px; height: 8px;">
                       </td>
                       <td align="left" colspan="2" rowspan="1" valign="top" style="height: 8px">
                       </td>
                       <td style="height: 8px">
                       </td>
                   </tr>
                   <tr>
                       <td style="width: 8px">
                       </td>
                       <td colspan="2">
                           <asp:Label ID="Label7" runat="server" CssClass="LabelHeadLine" Text="Personal Details"></asp:Label></td>
                       <td style="width: 288px">
                       </td>
                       <td align="left" colspan="2" rowspan="1" valign="top">
                           </td>
                       <td>
                       </td>
                   </tr>
               
        <tr>
                        <td style="width: 8px; height: 19px">
                        </td>
                        <td style="width: 132px; height: 19px">
                            <asp:Label ID="Label8" runat="server" CssClass="Label" Text="Surname"></asp:Label></td>
                        <td style="width: 10px; height: 19px">
                            :</td>
                        <td style="width: 288px; height: 19px">
                           <asp:Label ID="SURNAME" runat="server" CssClass="Label" Width="172px"></asp:Label></td>
                        <td style="width: 169px; height: 19px">
                            <asp:Label ID="Label9" runat="server" CssClass="Label" Text="First Name"></asp:Label></td>
                        <td style="width: 9px; height: 19px">
                            :</td>
                        <td style="height: 19px">
                            <asp:Label ID="FIRSTNAME" runat="server" CssClass="Label" Width="172px"></asp:Label></td>
        </tr>
        <tr>
                        <td style="width: 8px">
                        </td>
                        <td style="width: 132px">
                            <asp:Label ID="Label17" runat="server" CssClass="Label" Text="Middle Name"></asp:Label></td>
                        <td style="width: 10px">
                            :</td>
                        <td style="width: 288px">
                            <asp:Label ID="MIDDLENAME" runat="server" CssClass="Label" Width="172px"></asp:Label></td>
                        <td style="width: 169px">
                            <asp:Label ID="Label10" runat="server" CssClass="Label" Text="Sex"></asp:Label></td>
                        <td style="width: 9px">
                            :</td>
                        <td>
                            <asp:Label ID="SEX" runat="server" CssClass="Label" Width="172px"></asp:Label></td>
        </tr>
        <tr>
                        <td style="width: 8px; height: 19px;">
                        </td>
                        <td style="width: 132px; height: 19px;">
                           <asp:Label ID="Label19" runat="server" CssClass="Label" Text="Date of Birth"></asp:Label></td>
                        <td style="width: 10px; height: 19px;">
                            :</td>
                        <td style="width: 288px; height: 19px;">
                           <asp:Label ID="DOB" runat="server" CssClass="Label" Width="172px"></asp:Label></td>
                        <td style="width: 169px; height: 19px;">
                           <asp:Label ID="Label20" runat="server" CssClass="Label" Text="Country of Birth"></asp:Label></td>
                        <td style="width: 9px; height: 19px;">
                            :</td>
                        <td style="height: 19px">
                           <asp:Label ID="BIRTHCOUNTRY" runat="server" CssClass="Label" Width="172px"></asp:Label></td>
        </tr>         
                   <tr>
                       <td style="width: 8px; height: 1px;">
                       </td>
                       <td style="width: 132px; height: 1px;">
                           <asp:Label ID="Label4" runat="server" CssClass="Label" Text="Nationality"></asp:Label></td>
                       <td style="width: 10px; height: 1px;">
                           :</td>
                       <td style="width: 288px; height: 1px;">
                           <asp:Label ID="NATIONALITY" runat="server" CssClass="Label" Width="172px"></asp:Label></td>
                       <td style="width: 169px; height: 1px;">
                           <asp:Label ID="Label15" runat="server" CssClass="Label" Width="172px">Passport No</asp:Label></td>
                       <td style="width: 9px; height: 1px;">
                           :</td>
                       <td style="height: 1px">
                           <asp:Label ID="PASSPORTNO" runat="server" CssClass="Label" Width="172px"></asp:Label></td>
                   </tr>        
                   <tr>
                       <td style="width: 8px">
                       </td>
                       <td style="width: 132px">
                           <asp:Label ID="Label16" runat="server" CssClass="Label">Passport Issued Country</asp:Label></td>
                       <td style="width: 10px" valign="top">
                           :</td>
                       <td style="width: 288px" valign="top">
                           <asp:Label ID="PASSPORTCOI" runat="server" CssClass="Label" Width="172px"></asp:Label></td>
                       <td style="width: 169px">
                       </td>
                       <td style="width: 9px">
                       </td>
                       <td>
                       </td>
                   </tr>
                   <tr>
                       <td style="width: 8px; height: 19px">
                       </td>
                       <td style="width: 132px; height: 19px">
                            </td>
                       <td style="width: 10px; height: 19px">
                           </td>
                       <td style="width: 288px; height: 19px">
                            </td>
                       <td style="width: 169px; height: 19px">
                       </td>
                       <td style="width: 9px; height: 19px">
                       </td>
                       <td style="height: 19px">
                       </td>
                   </tr>
                   <tr runat="server" id="trRemarks" visible="false">
                       <td style="width: 8px; height: 19px">
                       </td>
                       <td style="width: 132px; height: 19px" valign="top">
                           <asp:Label ID="Label6" runat="server" CssClass="Label" Text="Remarks"></asp:Label>
                           <asp:Label ID="Label49" runat="server" CssClass="Label" ForeColor="Red" Text="*"></asp:Label></td>
                       <td style="width: 10px; height: 19px" valign="top">
                           :</td>
                       <td style="height: 19px" colspan="4">
                           <asp:TextBox ID="txtRemarks" runat="server" CssClass="Label" MaxLength="100" Rows="5"
                               TextMode="MultiLine" Width="532px"></asp:TextBox>
                           <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtRemarks"
                               CssClass="Label" ErrorMessage="Remarks is a mandatory field" ForeColor="White">*</asp:RequiredFieldValidator></td>
                   </tr>
         <tr>
             <td style="width: 8px; height: 15px">
             </td>
             <td colspan="6">
                       
                           </td>
         </tr>
        <tr>
            <td style="width: 8px">
            </td>
            <td colspan="5">
                <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" /></td>
            
            <td>
            </td>
        </tr>
                </table>
                </div>
              </td>
          </tr>        
      </table>
     <asp:HiddenField ID="txtCompName" runat="server" />
    <script type="text/javascript">
    GetPcName();
    
    function confirmDelete()
    {
        if (Page_ClientValidate())
        {
            return confirm('Are you sure you want to delete this application?');
        }
    }  
    </script>


</asp:Content>