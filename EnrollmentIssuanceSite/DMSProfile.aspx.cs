using EnrollmentIssuanceSite.EnrollManagementWS;
using EnrollmentIssuanceSite.Shared;
using System;
using System.Data;
using System.Web.UI.WebControls;
using System.Xml;

namespace EnrollmentIssuanceSite
{
    public partial class DMSProfile : System.Web.UI.Page
    {
        const int pageId = 9;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                txtCompName.Value = Request.QueryString["PC"];

                if (Request.QueryString["DMSID"] != null)
                {
                    DMSID.Value = Request.QueryString["DMSID"];
                    string appID = Request.QueryString["done"];
                    FORMNO.Value = appID.Substring(0, appID.Length - 1);
                    LoadIDPerson();
                    LodScannedDocGrid();
                    ControlLinkButton();

                }
                else
                    Response.Redirect("CheckDMS.asp?sm=" + Request.QueryString["sm"] + "&arrow=" + Request.QueryString["arrow"] + "&done=" + Request.QueryString["done"] + "&PC=" + Request.QueryString["PC"]);
            }

        }

        protected void dgScanDocList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            #region Paging
            dgScanDocList.PageIndex = e.NewPageIndex;
            dgScanDocList.DataSource = BindGrid();
            dgScanDocList.DataBind();
            #endregion
        }
        private DataView BindGrid()
        {
            #region ***
            DataSet Ds = (DataSet)ViewState["CurrentData"];
            DataView dv = new DataView(Ds.Tables[0]);
            return dv;
            #endregion

        }
        protected void dgScanDocList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "View")
            {
                int ImgID = Convert.ToInt32(e.CommandArgument);
                ViewImage(ImgID);
            }
        }
        private void ViewImage(int ID)
        {
            // ANTU: Remove DMS
            return;

            //////#region ***

            //////try
            //////{
            //////    string msg = string.Empty;
            //////    byte[] binImage = null;
            //////    string url = string.Empty;
            //////    string outputFile = string.Empty;
            //////    string system = string.Empty;
            //////    string StatusCode = string.Empty;
            //////    string StatusMsg = string.Empty;

            //////    #region connecting to web service
            //////    DMS.DMSService dms = new DMS.DMSService();
            //////    DMS.RequestDataTypeOutSearchScannedDoc reqData = new DMS.RequestDataTypeOutSearchScannedDoc();
            //////    reqData.ActionDescription = "Search scanned doc";
            //////    reqData.PermissionCode = common.GetValue("DMSSearchScannedDocByImageID");
            //////    reqData.ImageID = Convert.ToInt32(ID);

            //////    DMS.ResponseDataTypeOutSearchScannedDoc responseData = dms.DMSSearchScannedDocByImageID(reqData);
            //////    #endregion

            //////    #region response
            //////    StatusCode = responseData.StatusCode;
            //////    StatusMsg = responseData.StatusMessage;
            //////    #endregion

            //////    #region process
            //////    if (StatusCode == "0")
            //////    {
            //////        binImage = (byte[])responseData.ResultList.Tables[0].Rows[0]["IMAGE"];
            //////        #region
            //////        bool HasImage = common.DecodeBytetoImage(binImage, out msg);
            //////        if (HasImage)
            //////        {
            //////            outputFile = @Server.MapPath("") + common.GetValue("ImgServerPath") + msg;
            //////            url = common.GetImgUrl(binImage, outputFile, msg);
            //////        }
            //////        #endregion
            //////    }
            //////    #endregion

            //////    #region Pop Image in new window
            //////    System.Drawing.Image objImage = System.Drawing.Image.FromFile(outputFile);
            //////    int h = objImage.Height;
            //////    int w = objImage.Width;

            //////    string script = "<script type=\"text/javascript\">";
            //////    script += "var pp = window.open();";
            //////    script += "pp.document.writeln('<html><head><title>Scanned Image Preview</title></head>');";
            //////    script += "pp.document.writeln('<body>');";
            //////    script += "pp.document.writeln('<img alt=\"\" src=\"tempImg/";
            //////    script += msg;
            //////    script += "\"');";
            //////    //script += "pp.document.writeln('width=\"600\" height=\"700\">');";
            //////    script += "pp.document.writeln('height=\"";
            //////    script += h;
            //////    script += "\" width=\"";
            //////    script += w;
            //////    script += "\">');";
            //////    script += "pp.document.writeln('</body></html>');";
            //////    script += "</script>";
            //////    ClientScript.RegisterClientScriptBlock(GetType(), "ViewImage", script);
            //////    return;
            //////    #endregion
            //////}
            //////catch (Exception ex)
            //////{
            //////    lblError.Visible = true;
            //////    lblError.Text = ex.Message;
            //////}

            //////#endregion
        }


        private void LodScannedDocGrid()
        {
            // ANTU: Remove DMS
            return;

            //////#region Load Scan Document
            //////try
            //////{
            //////    #region connecting to web service
            //////    DMS.DMSService dms = new DMS.DMSService();
            //////    DMS.RequestDataTypeOutSearchScannedDoc reqData = new DMS.RequestDataTypeOutSearchScannedDoc();

            //////    reqData.ActionDescription = "Search scanned doc";
            //////    reqData.PermissionCode = common.GetValue("DMSSearchScannedDoc");
            //////    reqData.FileNumber = string.Empty;
            //////    reqData.DMSID = Convert.ToInt32(DMSID.Value);
            //////    reqData.DeptID = common.GetValue("DeptID");

            //////    DMS.ResponseDataTypeOutSearchScannedDoc responseData = dms.DMSSearchScannedDoc(reqData);
            //////    #endregion

            //////    #region response
            //////    string statusCode = responseData.StatusCode;
            //////    string statusMsg = responseData.StatusMessage;
            //////    #endregion

            //////    #region analyse result
            //////    if (statusCode == "0")
            //////    {
            //////        ViewState["CurrentData"] = null;               
            //////        DataSet ds = (DataSet)responseData.ResultList;               
            //////        GetProfile(ds);
            //////        if (ds.Tables[0].Rows[0]["ID"].ToString() != string.Empty)
            //////        {
            //////            ViewState["CurrentData"] = ds;
            //////            dgScanDocList.DataSource = ds.Tables[0];
            //////            dgScanDocList.DataBind();                    
            //////        }
            //////        else
            //////            DGborder.Visible = false;
            //////    }
            //////    else if (statusCode == "12.41.4.1" || statusCode == "12.41.4.2") //No record found
            //////    {
            //////        DGborder.Visible = false;
            //////        lblResult.Text = "No scanned document found for this profile";
            //////        lblResult.Visible = true;
            //////    }
            //////    else
            //////    {
            //////        DGborder.Visible = false;
            //////        common.WriteLog(@Server.MapPath("") + common.GetValue("logPath"), "Search DMS file profiles - " + statusMsg);
            //////        throw new Exception(statusMsg);
            //////    }
            //////    #endregion
            //////}
            //////catch (Exception ex)
            //////{
            //////    lblError.Text = ex.Message;
            //////    lblError.Visible = true;
            //////    common.WriteLog(@Server.MapPath("") + common.GetValue("logPath"), "Search DMS file profiles - " + ex.Message);
            //////}
            //////#endregion
        }
        private void GetProfile(DataSet ds)
        {
            #region Bind Info to textbox
            SURNAME.Text = ds.Tables[0].Rows[0]["SURNAME"].ToString();
            FIRSTNAME.Text = ds.Tables[0].Rows[0]["FIRSTNAME"].ToString();
            MIDDLENAME.Text = ds.Tables[0].Rows[0]["MIDDLENAME"].ToString();
            SEX.Text = ds.Tables[0].Rows[0]["SEX"].ToString() == "M" ? "MALE" : "FEMALE";
            NATIONALITY.Text = ds.Tables[0].Rows[0]["NATIONALITY"].ToString();
            BIRTHDATE.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["BIRTHDATE"].ToString()).ToString("dd/MM/yyyy");
            DEPTID.Value = ds.Tables[0].Rows[0]["DEPTID"].ToString();
            #endregion
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("CheckDMS.aspx?sm=" + Request.QueryString["sm"] + "&arrow=" + Request.QueryString["arrow"] + "&done=" + Request.QueryString["done"] + "&PC=" + txtCompName.Value);
        }
        private void LoadIDPerson()
        {
            #region Retrieve IDPerson from XML file
            try
            {
                string fileName = @Server.MapPath("") + Common.GetValue("xmlServerPath") + Request.QueryString["done"] + ".xml";
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(fileName);

                XmlNode root = xmlDoc.DocumentElement;
                XmlNode enprofile = root.SelectSingleNode("PAYLOAD/ENROLLMENT/ENROLPROFILE");

                if (enprofile.SelectSingleNode("IDPERSON").InnerText != string.Empty)
                    IDPERSON.Value = enprofile.SelectSingleNode("IDPERSON").InnerText;
                else
                    GetIDPerson();
            }
            catch (Exception ex)
            {
                lblError.Visible = true;
                lblError.Text = ex.Message;
            }
            #endregion
        }
        private void SavePartdone()
        {
            #region ***
            try
            {
                string fileName = @Server.MapPath("") + Common.GetValue("xmlServerPath") + Request.QueryString["done"] + ".xml";
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(fileName);

                XmlNode xmlRoot = xmlDoc.DocumentElement;
                XmlNode enrollment = xmlRoot.SelectSingleNode("PAYLOAD/ENROLLMENT");

                if (Convert.ToInt32(enrollment.SelectSingleNode("partdone").InnerText) <= pageId)
                {
                    enrollment.SelectSingleNode("partdone").InnerText = pageId.ToString();

                }

                xmlDoc.Save(fileName);
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                lblError.Visible = true;
            }
            #endregion
        }
        private bool CheckApplicationLink()
        {
            // ANTU: Remove DMS
            return false;

            //////#region Check if profiles has been linked

            //////#region connecting to web service
            //////DMS.DMSService dms = new DMS.DMSService();
            //////DMS.RequestDataTypeOutMasterLink reqData = new DMS.RequestDataTypeOutMasterLink();

            //////reqData.ActionDescription = "Search Master Link";
            //////reqData.PermissionCode = common.GetValue("DMSSearchMasterLink");
            //////reqData.DeptID = common.GetValue("DeptID");
            //////reqData.UserID = common.GetCookie(this.Page, "loginName");
            //////reqData.IDPerson = Convert.ToInt32(IDPERSON.Value);


            //////DMS.ResponseDataTypeOutMasterLink responseData = dms.OutSelectMasterLink(reqData);

            //////#endregion

            //////#region response
            //////string statusCode = responseData.StatusCode;
            //////string statusMsg = responseData.StatusMessage;
            //////#endregion

            //////#region analyse result
            //////if (statusCode == "0")
            //////    return true;
            //////else
            //////    return false;
            //////#endregion

            //////#endregion        
        }
        protected void btnLink_Click(object sender, EventArgs e)
        {
            CreateLink();
        }
        private void CreateLink()
        {
            // ANTU: Remove DMS
            return;

            //////#region Create Master Link
            //////try
            //////{
            //////    #region connecting to web service
            //////    DMS.DMSService dms = new DMS.DMSService();
            //////    DMS.RequestDataTypeOutMasterLink reqData = new DMS.RequestDataTypeOutMasterLink();

            //////    reqData.ActionDescription = "Create master link";
            //////    reqData.PermissionCode = common.GetValue("DMSCreateMasterLink");
            //////    reqData.DeptID = DEPTID.Value;
            //////    reqData.DMSID = Convert.ToInt32(DMSID.Value);
            //////    reqData.IDPerson = Convert.ToInt32(IDPERSON.Value);
            //////    reqData.UserID = common.GetCookie(this.Page, "loginName");

            //////    DMS.ResponseDataTypeOutMasterLink responseData = dms.OutCreateMasterLink(reqData);
            //////    #endregion

            //////    #region response
            //////    string statusCode = responseData.StatusCode;
            //////    string statusMsg = responseData.StatusMessage;
            //////    #endregion

            //////    #region analyse result

            //////    if (statusCode == "0")
            //////    {
            //////        SavePartdone();
            //////        Response.Redirect("ApplicationPart6.aspx?DeptID=" + DEPTID.Value + "&sm=" + Request.QueryString["sm"] + "&arrow=" + Request.QueryString["arrow"] + "&done=" + Request.QueryString["done"] + "&PC=" + txtCompName.Value);

            //////        string script = "<script type=\"text/javascript\">Link created;</script>";
            //////        ClientScript.RegisterClientScriptBlock(GetType(), "Message", script);
            //////    }
            //////    else
            //////        throw new Exception(statusMsg);

            //////    #endregion
            //////}
            //////catch (Exception ex)
            //////{
            //////    lblError.Text = ex.Message;
            //////    lblError.Visible = true;
            //////    common.WriteLog(@Server.MapPath("") + common.GetValue("logPath"), "Create Master Link - " + ex.Message);
            //////}
            //////#endregion
        }
        private void ControlLinkButton()
        {
            if (CheckApplicationLink())
                btnLink.Visible = false;
            else
            {
                if (Request.QueryString["LINK"].ToString() == "1")
                    btnLink.Visible = false;
                else
                    btnLink.Visible = true;
            }

        }
        private void GetIDPerson()
        {
            #region ***
            try
            {
                #region calling web service
                EMService contact = new EMService();
                RequestDataTypeGetDetails reqData = new RequestDataTypeGetDetails();

                reqData.ActionDescription = "Get Details";
                reqData.SessionKey = Common.GetCookie(this.Page, "sessionKey");
                reqData.EnrolLocationName = txtCompName.Value.Trim();
                reqData.PermissionCode = Common.GetValue("GetDetailsPermissionCode");
                reqData.ApplicationID = FORMNO.Value;
                reqData.SearchType = "1";
                reqData.DocNo = string.Empty;
                reqData.PassportCOI = string.Empty;
                reqData.PassportNo = string.Empty;


                ResponseDataTypeGetDetails responseData = contact.GetDetails(reqData);
                #endregion

                #region response from web service
                string statusCode = responseData.StatusCode;
                string statusMsg = responseData.StatusMessage;

                if (statusCode == "0")
                {
                    IDPERSON.Value = responseData.IDPerson.ToString();
                }
                else
                    throw new Exception(statusMsg);
                #endregion
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                lblError.Visible = true;
                Common.WriteLog(@Server.MapPath("") + Common.GetValue("logPath"), "Get Details: " + ex.Message);
            }

            #endregion
        }



    }
}
