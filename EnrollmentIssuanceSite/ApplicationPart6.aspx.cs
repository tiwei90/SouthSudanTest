using EnrollmentIssuanceSite.DALMWS;
using EnrollmentIssuanceSite.EnrollManagementWS;
using EnrollmentIssuanceSite.Shared;
using System;
using System.Data;
using System.IO;
using System.Web.UI.WebControls;
using System.Xml;

namespace EnrollmentIssuanceSite
{
    public partial class ApplicationPart6 : System.Web.UI.Page
    {
        const int pageId = 9;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                #region ***
                txtCompName.Value = Request.QueryString["PC"];
                SM.Value = Request.QueryString["sm"];
                if (Request.QueryString["done"] != null)
                {

                    string done = Request.QueryString["done"];
                    string filename = @Server.MapPath("") + Common.GetValue("xmlServerPath") + done + ".xml";
                    if (File.Exists(filename))
                    {
                        LoadIDPerson();
                        if (HFIDPERSON.Value == string.Empty)
                            GetIDPerson();

                        GetScanDocType();

                        if (CheckEISDMSLinkage())
                            LoadLinkedDocsGrid();
                        else
                            LoadScanDocEISGrid();

                    }
                    else
                    {
                        Response.Redirect("Logon.aspx");
                    }


                }
                #endregion
            }
        }
        private void LoadIDPerson()
        {
            #region ***
            try
            {
                string fileName = @Server.MapPath("") + Common.GetValue("xmlServerPath") + Request.QueryString["done"] + ".xml";
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(fileName);

                XmlNode root = xmlDoc.DocumentElement;
                XmlNode scan = root.SelectSingleNode("PAYLOAD/ENROLLMENT/SCANNED");
                XmlNode enProfile = root.SelectSingleNode("PAYLOAD/ENROLLMENT/ENROLPROFILE");

                HFIDPERSON.Value = enProfile.SelectSingleNode("IDPERSON").InnerText;
                FORMNO.Value = enProfile.SelectSingleNode("FORMNO").InnerText;

            }
            catch (Exception ex)
            {
                lblError.Visible = true;
                lblError.Text = ex.Message;
            }
            #endregion

        }
        private void GetScanDocType()
        {
            #region ***
            try
            {
                #region calling web service
                DALMService look = new DALMService();
                EnrollmentIssuanceSite.DALMWS.RequestDataTypeSelectScannedDoc reqData = new EnrollmentIssuanceSite.DALMWS.RequestDataTypeSelectScannedDoc();

                reqData.ActionDescription = "Select Scan Doc type";
                reqData.PermissionCode = Common.GetValue("SelectScanDocType");
                reqData.SessionKey = Common.GetCookie(this.Page, "sessionKey");
                #endregion

                #region response the request
                EnrollmentIssuanceSite.DALMWS.ResponseDataTypeSelectScannedDoc responseData = look.SelectScannedDocList(reqData);

                string statusCode = responseData.StatusCode;
                string statusMsg = responseData.StatusMessage;
                #endregion
                if (statusCode == "0")
                {

                    DataSet Ds = (DataSet)responseData.ResultList;
                    SCANNEDDOC.DataSource = Ds.Tables[0];
                    SCANNEDDOC.DataValueField = "ScannedDoc";
                    SCANNEDDOC.DataTextField = "Description";
                    SCANNEDDOC.DataBind();
                    SCANNEDDOC.Items.Insert(0, new ListItem("-SELECT-", ""));
                }
                else
                    throw new Exception(statusMsg);
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                lblError.Visible = true;
                Common.WriteLog(@Server.MapPath("") + Common.GetValue("logPath"), "GetScanDocType() : " + ex.Message);
            }
            #endregion

        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            #region ***
            try
            {
                string FORMNO = Request.QueryString["done"].Substring(0, (Request.QueryString["done"].Length - 1)); ;
                #region calling web service
                EMService enrolImage = new EMService();
                RequestDataTypeInsertScannedDoc reqData = new RequestDataTypeInsertScannedDoc();

                reqData.ActionDescription = "Enrol Scanned Doc";
                reqData.PermissionCode = Common.GetValue("InsertScanDoc");
                reqData.SessionKey = Common.GetCookie(this.Page, "sessionKey");
                reqData.ApplicationID = FORMNO;
                reqData.EnrolLocationName = txtCompName.Value.Trim();
                reqData.ImageDesc = DESC.Text.ToUpper();
                reqData.ScannedDoc = SCANNEDDOC.SelectedValue;
                reqData.ScannedImage = System.Convert.FromBase64String(SCANNEDIMAGE.Text);
                if (PAGENO.Text.ToString().Trim() != string.Empty)
                {
                    reqData.PageNo = Convert.ToInt32(PAGENO.Text.ToString());
                }
                else
                {
                    reqData.PageNo = 0;
                }
                #endregion

                #region response the request
                ResponseDataTypeInsertScannedDoc responseData = enrolImage.EnrolScannedDoc(reqData);

                string statusCode = responseData.StatusCode;
                string statusMsg = responseData.StatusMessage;
                if (statusCode != "0")
                {
                    lblError.Visible = true;
                    lblNote.Visible = false;
                    lblError.Text = statusMsg;

                }
                else
                {
                    if (DMSID.Value == string.Empty)
                        LoadScanDocEISGrid();
                    else
                        LoadLinkedDocsGrid();
                    lblNote.Visible = true;
                    lblError.Visible = false;
                    lblNote.Text = "Scanned document is saved. <br/>Please click 'Scan Document' button to scan other document";
                    SavePartdone();
                    PAGENO.Text = "";
                    DESC.Text = "";
                    SCANNEDIMAGE.Text = string.Empty;
                    SCANNEDDOC.SelectedValue = "";
                }


                #endregion
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                lblError.Visible = true;

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
                XmlNode enProfile = xmlRoot.SelectSingleNode("PAYLOAD/ENROLLMENT/ENROLPROFILE");
                XmlNode main = xmlRoot.SelectSingleNode("PAYLOAD/ENROLLMENT/MAIN");
                XmlElement xmlEle = null;

                if (Convert.ToInt32(enrollment.SelectSingleNode("partdone").InnerText) <= pageId)
                {
                    enrollment.SelectSingleNode("partdone").InnerText = pageId.ToString();
                }

                #region IDPERSON
                if (enProfile.SelectSingleNode("IDPERSON") == null)
                {
                    xmlEle = xmlDoc.CreateElement("IDPERSON");
                    xmlEle.InnerText = HFIDPERSON.Value;
                    enProfile.InsertAfter(xmlEle, enProfile.LastChild);
                }
                else
                    enProfile.SelectSingleNode("IDPERSON").InnerText = HFIDPERSON.Value;


                if (main.SelectSingleNode("IDPERSON") == null)
                {
                    xmlEle = xmlDoc.CreateElement("IDPERSON");
                    xmlEle.InnerText = HFIDPERSON.Value;
                    main.InsertAfter(xmlEle, main.LastChild);
                }
                #endregion

                xmlDoc.Save(fileName);
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                lblError.Visible = true;
                Common.WriteLog(@Server.MapPath("") + Common.GetValue("logPath"), "SaveXMLFile(ApplicationPart6) : " + ex.Message);
            }
            #endregion
        }
        protected void btn_Next_Click(object sender, EventArgs e)
        {
            SavePartdone();
            Response.Redirect(Common.RedirectToPage(pageId, Request.QueryString["sm"]) + "&done=" + Request.QueryString["done"] + "&arrow=" + Request.QueryString["arrow"] + "&PC=" + Request.QueryString["PC"]);
        }

        protected void dgScanDocList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            #region ***
            if (e.CommandName == "Delete")
            {
                // get the Image ID of the clicked row
                int ImgID = Convert.ToInt32(e.CommandArgument);
                // Delete the record 
                DeleteRecordByID(ImgID);

            }
            else if (e.CommandName == "View")
            {
                string combinedStr = e.CommandArgument.ToString();
                string[] arrStr = combinedStr.Split(new char[] { '-' });
                string ImgID = arrStr[0].ToString().Trim();
                string System = arrStr[1].ToString().Trim();
                ViewImage(ImgID, System);
            }
            #endregion
        }
        private void DeleteRecordByID(int ID)
        {
            #region ***
            try
            {
                #region calling web service
                EMService enrol = new EMService();
                RequestDataTypeDeleteScannedDoc reqData = new RequestDataTypeDeleteScannedDoc();

                reqData.ActionDescription = "Delete Scanned Doc";
                reqData.PermissionCode = Common.GetValue("DeleteScanDoc");
                reqData.SessionKey = Common.GetCookie(this.Page, "sessionKey");
                reqData.EnrolLocationName = txtCompName.Value.Trim();
                reqData.ImageID = ID;
                #endregion

                #region response the request
                ResponseDataTypeDeleteScannedDoc responseData = enrol.DeleteScannedDoc(reqData);

                string statusCode = responseData.StatusCode;
                string statusMsg = responseData.StatusMessage;

                if (statusCode == "0")
                {
                    lblResult.Visible = true;
                    lblResult.Text = "Scanned document image has been deleted";
                    if (DMSID.Value == string.Empty)
                        LoadScanDocEISGrid();
                    else
                        LoadLinkedDocsGrid();

                }
                else
                    throw new Exception(statusMsg);
                #endregion
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                lblError.Visible = true;
                Common.WriteLog(@Server.MapPath("") + Common.GetValue("logPath"), "DeleteScannedDoc - " + ex.Message);
            }
            #endregion
        }
        protected void btn_Back_Click(object sender, EventArgs e)
        {
            #region ***
            try
            {
                Response.Redirect(Common.RedirectToPage(pageId - 3, Request.QueryString["sm"]) + "&done=" + Request.QueryString["done"] + "&arrow=" + Request.QueryString["arrow"] + "&PC=" + Request.QueryString["PC"]);
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                lblError.Visible = false;

            }
            #endregion
        }
        private void ViewImage(string ID, string system)
        {
            string msg = string.Empty;
            byte[] binImage = null;
            string url = string.Empty;
            string StatusCode = string.Empty;
            string StatusMsg = string.Empty;
            string outputFile = string.Empty;

            if (system == "VIS")
            {
                #region Get image from VIS

                #region Call the webservices
                EMService test = new EMService();
                EnrollmentIssuanceSite.EnrollManagementWS.RequestDataTypeSelectScannedDoc req = new EnrollmentIssuanceSite.EnrollManagementWS.RequestDataTypeSelectScannedDoc();
                req.ActionDescription = "Get Select Scanned Doc by Image ID";
                req.SessionKey = Common.GetCookie(this.Page, "sessionKey").ToString();
                req.LocationName = txtCompName.Value;
                req.PermissionCode = Common.GetValue("SelectScannedDocByImageID");
                req.ImageID = Convert.ToInt32(ID);
                #endregion

                #region response
                EnrollmentIssuanceSite.EnrollManagementWS.ResponseDataTypeSelectScannedDoc getdata = test.GetScannedDocByImageID(req);
                StatusCode = getdata.StatusCode;
                StatusMsg = getdata.StatusMessage;
                #endregion

                #region process
                if (StatusCode == "0")
                {
                    binImage = (byte[])getdata.ResultList.Tables[0].Rows[0]["IMAGE"];
                    bool HasImage = Common.DecodeBytetoImage(binImage, out msg);
                    if (HasImage)
                    {
                        outputFile = @Server.MapPath("") + Common.GetValue("ImgServerPath") + msg;
                        url = Common.GetImgUrl(binImage, outputFile, msg);
                    }

                }
                #endregion

                #endregion
            }
            // ANTU:Remove DMS
            //////else if (system == "DMS")
            //////{
            //////    #region Get Image by ID - DMS
            //////    #region connecting to web service
            //////    DMService dms = new DMService();
            //////    RequestDataTypeOutSearchScannedDoc reqData = new RequestDataTypeOutSearchScannedDoc();
            //////    reqData.ActionDescription = "Search scanned doc";
            //////    reqData.PermissionCode = "12.41.4";
            //////    reqData.ImageID = Convert.ToInt32(ID);

            //////    ResponseDataTypeOutSearchScannedDoc responseData = dms.DMSSearchScannedDocByImageID(reqData);
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
            //////    #endregion
            //////}

            #region Show Image in new window
            System.Drawing.Image objImage = System.Drawing.Image.FromFile(outputFile);
            int h = objImage.Height;
            int w = objImage.Width;


            string script = "<script type=\"text/javascript\">";
            script += "var pp = window.open();";
            script += "pp.document.writeln('<html><head><title>Scanned Image Preview</title></head>');";
            script += "pp.document.writeln('<body>');";
            script += "pp.document.writeln('<img alt=\"\" src=\"tempImg/";
            script += msg;
            script += "\"');";
            //script += "pp.document.writeln('width=\"600\" height=\"700\">');";
            script += "pp.document.writeln('height=\"";
            script += h;
            script += "\" width=\"";
            script += w;
            script += "\">');";
            script += "pp.document.writeln('</body></html>');";
            script += "</script>";
            ClientScript.RegisterClientScriptBlock(GetType(), "ViewImage", script);
            return;
            #endregion

        }

        protected void dgScanDocList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgScanDocList.PageIndex = e.NewPageIndex;
            dgScanDocList.DataSource = BindGrid();
            dgScanDocList.DataBind();
        }
        private DataView BindGrid()
        {
            #region ***
            DataSet Ds = (DataSet)ViewState["ScannedDoc"];
            DataView dv = new DataView(Ds.Tables[0]);
            return dv;
            #endregion

        }

        protected void dgScanDocList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        private bool CheckEISDMSLinkage()
        {
            // ANTU: Remove DMS
            return false;

            //////#region Check if profiles has been linked

            //////#region connecting to web service
            //////DMS.DMSService dms = new DMS.DMSService();
            //////DMS.RequestDataTypeOutMasterLink reqData = new DMS.RequestDataTypeOutMasterLink();

            //////reqData.ActionDescription = "Search Master Link";
            //////reqData.PermissionCode = "12.44.2";
            //////reqData.DeptID = common.GetValue("DeptID");
            //////reqData.IDPerson = Convert.ToInt32(HFIDPERSON.Value);
            //////reqData.UserID = common.GetCookie(this, "loginName");

            //////DMS.ResponseDataTypeOutMasterLink responseData = dms.OutSelectMasterLink(reqData);

            //////#endregion

            //////#region response
            //////string statusCode = responseData.StatusCode;
            //////string statusMsg = responseData.StatusMessage;
            //////#endregion

            //////#region analyse result
            //////if (statusCode != "0")
            //////    return false;
            //////else
            //////{

            //////    DMSID.Value = responseData.ResultList.Tables[0].Rows[0]["DMSID"].ToString();
            //////    return true;
            //////}

            //////#endregion

            //////#endregion
        }

        private void LoadLinkedDocsGrid()
        {
            #region Load both scanned doc from DMS and EIS into datagrid
            try
            {
                DataSet ds = LinkedDocs();
                if (ds == null)
                {
                    tbDataGrid.Visible = false;
                }
                else
                {

                    ViewState["ScannedDoc"] = null;
                    ViewState["ScannedDoc"] = ds;
                    dgScanDocList.DataSource = ds.Tables[0];
                    dgScanDocList.DataBind();
                    tbDataGrid.Visible = true;
                }
            }
            catch (Exception ex)
            {
                Common.WriteLog(@Server.MapPath("") + Common.GetValue("logPath"), "LoadLinkedDocsGrid() - " + ex.Message);
            }
            #endregion
        }

        private DataSet LinkedDocs()
        {
            #region Merge dataset of scanned doc from EID and DMS
            DataSet ds1 = LoadScannedDocEIS();
            DataSet dsCombine = LoadScannedDocDMS();

            if (ds1 == null)
                return dsCombine;
            else if (dsCombine == null)
                return ds1;
            else
            {
                dsCombine.Merge(ds1);
                return dsCombine;
            }
            #endregion
        }

        private DataSet LoadScannedDocDMS()
        {
            // ANTU: Remove DMS
            return null;

            //////#region Load Scan Document from DMS

            //////#region connecting to web service
            //////DMS.DMSService dms = new DMS.DMSService();
            //////DMS.RequestDataTypeOutSearchScannedDoc reqData = new DMS.RequestDataTypeOutSearchScannedDoc();

            //////reqData.ActionDescription = "Search scanned doc";
            //////reqData.PermissionCode = "12.41.4";
            //////reqData.FileNumber = string.Empty;
            //////reqData.DMSID = Convert.ToInt32(DMSID.Value);
            //////reqData.DeptID = common.GetValue("DeptID");

            //////DMS.ResponseDataTypeOutSearchScannedDoc responseData = dms.DMSSearchScannedDoc(reqData);
            //////#endregion

            //////#region response
            //////string statusCode = responseData.StatusCode;
            //////string statusMsg = responseData.StatusMessage;
            //////#endregion

            //////#region analyse result
            //////if (statusCode == "0")
            //////{
            //////    if (responseData.ResultList.Tables[0].Rows[0]["ID"].ToString() == string.Empty)
            //////    {
            //////        return null;
            //////    }
            //////    else
            //////    {
            //////        DataColumn dc = new DataColumn("SYSTEM");
            //////        responseData.ResultList.Tables[0].Columns.Add(dc);
            //////        foreach (DataRow dr in responseData.ResultList.Tables[0].Rows)
            //////        {
            //////            dr["SYSTEM"] = "DMS";
            //////        }
            //////        return responseData.ResultList;
            //////    }
            //////}
            //////else if (statusCode == "12.41.4.1" || statusCode == "12.41.4.2") //No record found
            //////{
            //////    return null;
            //////}
            //////else
            //////    throw new Exception(responseData.StatusMessage);
            //////#endregion


            //////#endregion
        }

        private DataSet LoadScannedDocEIS()
        {
            // ANTU: Remove DMS
            return null;

            //////#region Load Scan Document from EIS

            //////#region connecting to web service
            //////EMService enrol = new EMService();
            //////RequestDataTypeSelectScannedDoc reqData = new RequestDataTypeSelectScannedDoc();

            //////reqData.ActionDescription = "Get Scanned Doc List";
            //////reqData.PermissionCode = common.GetValue("SelectScanDoc");
            //////reqData.SessionKey = common.GetCookie(this.Page, "sessionKey");
            //////reqData.LocationName = txtCompName.Value;
            //////reqData.ApplicationID = FORMNO.Value;

            //////EnrollManagementWS.ResponseDataTypeSelectScannedDoc responseData = enrol.GetScannedDocList(reqData);
            //////#endregion

            //////#region response
            //////string statusCode = responseData.StatusCode;
            //////string statusMsg = responseData.StatusMessage;
            //////#endregion

            //////#region analyse result
            //////if (statusCode == "0")
            //////{

            //////    DataColumn dc = new DataColumn("SYSTEM");
            //////    responseData.ResultList.Tables[0].Columns.Add(dc);

            //////    foreach (DataRow dr in responseData.ResultList.Tables[0].Rows)
            //////    {
            //////        dr["SYSTEM"] = "VIS";
            //////    }
            //////    ViewState["ScannedDoc"] = responseData.ResultList;
            //////    return responseData.ResultList;
            //////}
            //////else if (statusCode == "12.106.2.6")//No record found
            //////{
            //////    return null;
            //////}
            //////else
            //////    throw new Exception(responseData.StatusMessage);
            //////#endregion

            //////#endregion
        }

        private void LoadScanDocEISGrid()
        {
            #region ***
            try
            {
                DataSet ds = LoadScannedDocEIS();
                if (ds != null)
                {
                    dgScanDocList.DataSource = ds;
                    dgScanDocList.DataBind();
                    tbDataGrid.Visible = true;
                }
                else
                {
                    tbDataGrid.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Common.WriteLog(@Server.MapPath("") + Common.GetValue("logPath"), "LoadScanDocEISGrid() - " + ex.Message);
            }

            #endregion
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
                    HFIDPERSON.Value = responseData.IDPerson.ToString();
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
