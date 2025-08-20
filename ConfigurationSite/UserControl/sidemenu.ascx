<%@ Control Language="C#" AutoEventWireup="true" Inherits="sidemenu" Codebehind="sidemenu.ascx.cs" %>

<script type="text/javascript" src="inc/common.js"></script>
<script type="text/javascript" src="inc/CSJSRequestObject.js"></script>

<table class="headerLoginInfo" cellpadding="0" border="0" cellspacing="0" style="height: 1px">
    <!--Login Info-->
    <tr>
        <td align="left" style="background-image: url(./images/icon_home.gif); height: 33px; width: 155px; background-repeat: no-repeat;" valign="bottom">
            <asp:HyperLink ID="HyperLink0" runat="server" CssClass="HomePanel" Width="100%">Login Information</asp:HyperLink>
        </td>        
    </tr>
    <tr>
        <td class="showPanel" id="td3" style="vertical-align: top; width: 155px;" align="left">
            <asp:Panel CssClass="PanelMenu" ID="Panel1" runat="server">
                &nbsp;
                <asp:Label ID="Label2" runat="server" Font-Size="12px" Font-Names="Arial" ForeColor="DimGray"
                    CssClass="label" Font-Bold="True">Logged in as :</asp:Label><br />
                &nbsp;
                <asp:Label ID="lblUserName" runat="server" ForeColor="SaddleBrown" CssClass="Label">UserName</asp:Label><br />
                &nbsp;
                <asp:Label ID="Label4" runat="server" Font-Size="12px" Font-Names="Arial" ForeColor="DimGray"
                    CssClass="Label" Font-Bold="True">Logged in since :</asp:Label><br />
                &nbsp;
                <asp:Label ID="lblTime" runat="server" ForeColor="SaddleBrown" CssClass="Label"></asp:Label>
            </asp:Panel>
        </td>
    </tr>
    <tr>
        <td align="left" class="showPanel" style="vertical-align: top; width: 155px; height: 5px">
        </td>
    </tr>
    <tr>
        <td align="left" style="background-image: url(./images/icon_home.gif); height: 33px;
            width: 155px; background-repeat: no-repeat;" valign="bottom">
            <asp:HyperLink ID="HyperLink1" runat="server" CssClass="HomePanel" Width="100%">Menu</asp:HyperLink>
        </td>
    </tr>
    <tr>
        <td style="width: 155px">
            <table id="tbEnroll" style="z-index: 101" cellspacing="1" cellpadding="1" width="150"
                border="0">
                <tr>
                    <td align="left" style="vertical-align: top; height: 5px; width: 166px;">
                    </td>
                </tr>
                <tr>
                    <td id="tdpnlEnroll" style="vertical-align: top;  width: 166px;" align="left">
                        <div id="Div1" runat="server" class="PanelMenu" style="width: 156px">
                            <table id="Table1" style="z-index: 101; width: 156px;" cellspacing="1" cellpadding="1"
                                border="0">
                                <tr>
                                    <td class="HeaderTitle" onclick="SubHeaderClick('Table2');"onmouseover="cursor_pointer();"
                                        onmouseout="cursor_clear(); " style="width: 173px; height: 25px;">
                                        Lookup Table Maintenance</td>
                                </tr>
                            </table>
                            <table id="Table2" cellspacing="0" cellpadding="0" border="0">
                                <tr>
                                    <td class="tdImgArrowHidden" id="imgHl1" style="width: 15px; height: 20px;">
                                        <img alt="" src="./images/childselected.gif" id="im" /></td>
                                    <td style="height: 20px" class="bottomLine">
                                        <asp:HyperLink ID="HyperLink5" runat="server" CssClass="url" NavigateUrl="~/ApplicationReason.aspx?sm=1">Application Reason</asp:HyperLink></td>
                                </tr>
                                <tr>
                                    <td class="tdImgArrowHidden" style="width: 15px; height: 20px" id="imgHl4">
                                        <img alt="" src="./images/childselected.gif" id="Img2" /></td>
                                    <td class="bottomLine" style="height: 20px">
                                        <asp:HyperLink ID="HyperLink3" runat="server" CssClass="url" NavigateUrl="~/Branch.aspx?sm=4">Branch</asp:HyperLink></td>
                                </tr>
                                <tr>
                                    <td class="tdImgArrowHidden" style="width: 15px; height: 20px" id="imgHl2">
                                        <img alt="" src="./images/childselected.gif" id="Img6" /></td>
                                    <td style="height: 20px" class="bottomLine">
                                        <asp:HyperLink ID="HyperLink6" runat="server" CssClass="url" NavigateUrl="~/DocumentType.aspx?sm=2">Document Type</asp:HyperLink></td>
                                </tr>
                                <tr>
                                    <td class="tdImgArrowHidden" style="width: 15px; height: 20px" id="imgHl3">
                                        <img alt="" src="./images/childselected.gif" id="Img5" /></td>
                                    <td class="bottomLine" style="height: 20px">
                                        <asp:HyperLink ID="HyperLink4" runat="server" CssClass="url" NavigateUrl="~/EntryType.aspx?sm=3">Entry Type</asp:HyperLink></td>
                                </tr>
                                <tr>
                                    <td class="tdImgArrowHidden" style="width: 15px; height: 20px" id="imgHl15">
                                        <img alt="" src="./images/childselected.gif" id="Img3" /></td>
                                    <td class="bottomLine" style="height: 20px">
                                        <asp:HyperLink ID="HyperLink15" runat="server" CssClass="url" NavigateUrl="~/Fee.aspx?sm=15">Fee</asp:HyperLink></td>
                                </tr>
                                <tr>
                                    <td id="imgHl5" class="tdImgArrowHidden" style="width: 15px; height: 20px">
                                        <img alt="" src="./images/childselected.gif" id="Img9" /></td>
                                    <td style="height: 20px" class="bottomLine">
                                        <asp:HyperLink ID="HyperLink18" runat="server" CssClass="url" NavigateUrl="~/IssRejectReason.aspx?sm=5">Issuance Reject</asp:HyperLink></td>
                                </tr>
                                <tr>
                                    <td id="imgHl6" class="tdImgArrowHidden" style="width: 15px; height: 20px">
                                        <img alt="" src="./images/childselected.gif" id="Img10" /></td>
                                    <td style="height: 20px" class="bottomLine">
                                        <asp:HyperLink ID="HyperLink10" runat="server" CssClass="url" NavigateUrl="~/PaymentMethod.aspx?sm=6">Payment Method</asp:HyperLink></td>
                                </tr>
                                <tr>
                                    <td class="tdImgArrowHidden" style="width: 15px; height: 20px" id="imgHl8">
                                        <img alt="" src="./images/childselected.gif" id="Img11" /></td>
                                    <td style="height: 20px" class="bottomLine">
                                        <asp:HyperLink ID="HyperLink11" runat="server" CssClass="url" NavigateUrl="~/RejectReason.aspx?sm=8">Reject Reason</asp:HyperLink></td>
                                </tr>
                                <tr>
                                    <td class="tdImgArrowHidden" style="width: 15px; height: 20px" id="imgHl9">
                                        <img alt="" src="./images/childselected.gif" id="Img17" /></td>
                                    <td class="bottomLine" style="height: 20px">
                                        <asp:HyperLink ID="HyperLink9" runat="server" CssClass="url" NavigateUrl="~/ResidentialStatus.aspx?sm=9">Residential Status</asp:HyperLink></td>
                                </tr>
                                <tr>
                                    <td id="imgHl10" class="tdImgArrowHidden" style="width: 15px; height: 20px">
                                        <img alt="" src="./images/childselected.gif" id="Img12" /></td>
                                    <td style="height: 20px" class="bottomLine">
                                        <asp:HyperLink ID="HyperLink12" runat="server" CssClass="url" NavigateUrl="~/ScannedDocumentType.aspx?sm=10">Scanned Document</asp:HyperLink></td>
                                </tr>
                                <tr>
                                    <td id="imgHl12" class="tdImgArrowHidden" style="width: 15px; height: 20px">
                                        <img alt="" src="./images/childselected.gif" id="Img4" /></td>
                                    <td style="height: 20px" class="bottomLine">
                                        <asp:HyperLink ID="HyperLink16" runat="server" CssClass="url" NavigateUrl="~/VisaClass.aspx?sm=12">Visa Class</asp:HyperLink></td>
                                </tr>
                                <tr>
                                    <td id="imgHl13" class="tdImgArrowHidden" style="width: 15px; height: 20px">
                                        <img alt="" src="./images/childselected.gif" id="Img15" /></td>
                                    <td style="height: 20px" class="bottomLine">
                                        <asp:HyperLink ID="HyperLink20" runat="server" CssClass="url" NavigateUrl="~/VisitPurpose.aspx?sm=13">Visit Purpose</asp:HyperLink></td>
                                </tr>
                                <tr>
                                    <td id="imgHl14" class="tdImgArrowHidden" style="width: 15px; height: 20px">
                                        <img alt="" src="./images/childselected.gif" id="Img16" /></td>
                                    <td style="height: 20px" class="bottomLine">
                                        <asp:HyperLink ID="HyperLink19" runat="server" CssClass="url" NavigateUrl="~/Location.aspx?sm=14">Location</asp:HyperLink></td>
                                </tr>
                                <tr>
                                    <td id="imgHl16" class="tdImgArrowHidden" style="width: 15px; height: 20px">
                                        <img alt="" src="./images/childselected.gif" id="Img18" /></td>
                                    <td style="height: 20px" class="bottomLine">
                                        <asp:HyperLink ID="HyperLink21" runat="server" CssClass="url" NavigateUrl="~/ConfigLocation.aspx?sm=16">Location Configuration</asp:HyperLink></td>
                                </tr>
                                <tr>
                                    <td id="imgHl23" class="tdImgArrowHidden" style="width: 15px; height: 20px">
                                        <img alt="" src="./images/childselected.gif" id="Img19" /></td>
                                    <td style="height: 20px">
                                        <asp:HyperLink ID="HyperLink22" runat="server" CssClass="url" NavigateUrl="~/PersoMapping.aspx?sm=23">Production Branch Configuration</asp:HyperLink></td>
                                </tr>
                                <tr>
                                    <td class="tdImgArrowHidden" style="width: 15px; height: 10px">
                                    </td>
                                    <td style="height: 10px">
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </td>
                </tr>
            </table>
            <table id="Table3" style="z-index: 101" cellspacing="1" cellpadding="1" width="150"
                border="0">
                <tr>
                    <td align="left" style="vertical-align: top; height: 5px; width: 166px;">
                    </td>
                </tr>
                <tr>
                    <td id="td1" style="vertical-align: top; width: 166px;" align="left">
                        <div id="Div2" runat="server" class="PanelMenu" style="width: 156px">
                            <table id="Table4" style="z-index: 101; width: 156px;" cellspacing="1" cellpadding="1"
                                border="0">
                                <tr>
                                    <td class="HeaderTitle" onclick="SubHeaderClick('Table5');"onmouseover="cursor_pointer();"
                                        onmouseout="cursor_clear(); " style="width: 173px; height: 25px;">
                                        Delete Option</td>
                                </tr>
                            </table>
                            <table id="Table5" cellspacing="0" cellpadding="0" border="0" style="width: 151px" >
                                <tr>
                                    <td class="tdImgArrowHidden" id="imgHl20" style="width: 15px; height: 20px;">
                                        <img alt="" src="./images/childselected.gif" id="Img1" /></td>
                                    <td style="height: 20px; width: 75px;" class="bottomLine">
                                        <asp:HyperLink ID="HyperLink7" runat="server" CssClass="url" NavigateUrl="~/DeleteIncomplete.aspx?sm=20" Width="112px">Delete Incomplete Files</asp:HyperLink></td>
                                </tr>
                                <tr>
                                    <td id="imgHl21" class="tdImgArrowHidden" style="width: 15px; height: 10px"><img alt="" src="./images/childselected.gif" id="Img7" /></td>
                                    <td style="height: 10px; width: 75px;">
                                        <asp:HyperLink ID="HyperLink17" runat="server" CssClass="url" NavigateUrl="~/DeleteJob.aspx?sm=21">Delete Job</asp:HyperLink></td>
                                </tr>
                            </table>
                        </div>
                        <br />                        
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    
    <tr id="version">
    <td>
        <table border="0" cellpadding="1" cellspacing="1" width="150">
        <tr>
        <td><asp:Label ID="lblModule" runat="server" CssClass="VersionLable" Text="" Width="150px"></asp:Label></td>
        </tr>
        </table>
    </td>
    </tr>
</table>
    <script type="text/javascript">
   //Request.QueryString features is taken from CSJSRequestObject.js
    var n = Request.QueryString("sm");
    var id = "imgHl"+ n;
	document.getElementById(id).className="tdImgArrowShow";	
    </script>