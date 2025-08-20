using EnrollmentIssuanceSite.EnrollManagementWS;
using EnrollmentIssuanceSite.Shared;
using System;
using System.Data;
using System.IO;
using System.Web.UI.WebControls;
using System.Xml;

namespace EnrollmentIssuanceSite
{
    public partial class CheckDMS : System.Web.UI.Page
    {
        const int pageId = 8;
        protected void Page_Load(object sender, EventArgs e)
        {
            #region ***
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["done"] != null)
                {
                    txtCompName.Value = Request.QueryString["PC"];
                    string done = Request.QueryString["done"];
                    string filename = @Server.MapPath("") + Common.GetValue("xmlServerPath") + done + ".xml";
                    if (File.Exists(filename))
                    {
                        LoadXMLFile(filename);
                        if (IDPERSON.Value == string.Empty)
                            GetIDPerson();
                        CheckTransaction();
                        lblLinkDMSID.Text = CheckApplicationLink();
                    }
                    else
                    {
                        Response.Redirect("Logon.aspx");
                    }
                }

            }
            #endregion
        }
        private void CheckTransaction()
        {
            #region ***
            try
            {
                DataSet dsL = new DataSet();
                DataSet ds = new DataSet();
                string statusCode;
                string statusMsg;

                ds = CheckDMSByName(out statusCode, out statusMsg);
                if (statusCode == "0")
                {
                    DataSet dsLink = new DataSet();
                    DataTable dt = ds.Tables[0];

                    ViewState["DMSList"] = dt;

                    dgDMS.DataSource = dt;
                    dgDMS.DataBind();
                    trDG.Visible = true;
                }
                else
                {
                    lblError.Visible = true;
                    lblError.Text = "Document Management System : No possible matches found";
                    Common.WriteLog(@Server.MapPath("") + Common.GetValue("logPath"), "DMS: - " + statusMsg);

                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                lblError.Visible = true;
                Common.WriteLog(@Server.MapPath("") + Common.GetValue("logPath"), "DMS: - " + ex.Message);
            }
            #endregion
        }

        private DataSet CheckDMSByName(out string code, out string msg)
        {
            //ANTU: REMOVE DMS
            code = null;
            msg = null;
            return null;

            //////#region List all possible matches from DMS

            //////#region connecting to web service
            //////DMService dms = new DMService();
            //////RequestDataTypeOutSearchName reqData = new RequestDataTypeOutSearchName();

            //////reqData.ActionDescription = "Search by Name";
            //////reqData.PermissionCode = common.GetValue("DMSSearchByName");
            //////reqData.DeptID = common.GetValue("DeptID");
            //////reqData.Surname = SURNAME.Value;
            //////reqData.FirstName = FIRSTNAME.Value;
            //////reqData.MiddleName = MIDDLENAME.Value;
            //////reqData.Nationality = NATIONALITY.Value;
            //////reqData.BirthDate = BIRTHDATE.Value;
            //////reqData.BirthCountry = BIRTHCOUNTRY.Value;
            //////reqData.SearchType = string.Empty;

            //////ResponseDataTypeOutSearchName responseData = dms.DMSSearchName(reqData);

            //////#endregion

            //////#region response
            //////code = responseData.StatusCode;
            //////msg = responseData.StatusMessage;
            //////#endregion

            //////#region analyse result
            //////if (code == "0")
            //////    return responseData.ResultList;
            //////else
            //////    return null;

            //////#endregion

            //////#endregion
        }

        private void LoadXMLFile(string fileName)
        {
            #region ***
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(fileName);

                XmlNode xmlRoot = xmlDoc.DocumentElement;
                XmlNode enrollment = xmlRoot.SelectSingleNode("PAYLOAD/ENROLLMENT");
                XmlNode enProfile = xmlRoot.SelectSingleNode("PAYLOAD/ENROLLMENT/ENROLPROFILE");
                XmlNode main = xmlRoot.SelectSingleNode("PAYLOAD/ENROLLMENT/MAIN");

                FORMNO.Value = enProfile.SelectSingleNode("FORMNO").InnerText;
                DOCTYPE.Value = enProfile.SelectSingleNode("DOCTYPE").InnerText;
                IDPERSON.Value = enProfile.SelectSingleNode("IDPERSON").InnerText;
                SURNAME.Value = main.SelectSingleNode("SURNAME").InnerText;
                FIRSTNAME.Value = main.SelectSingleNode("FIRSTNAME").InnerText;
                MIDDLENAME.Value = main.SelectSingleNode("MIDDLENAME").InnerText;
                NATIONALITY.Value = main.SelectSingleNode("NATIONALITY").InnerText;
                BIRTHCOUNTRY.Value = main.SelectSingleNode("BIRTHCOUNTRY").InnerText;
                BIRTHDATE.Value = main.SelectSingleNode("BIRTHDATE").InnerText;

            }
            catch (Exception ex)
            {
                lblError.Visible = true;
                lblError.Text = ex.Message;
            }
            #endregion
        }


        protected void btnNext_Click(object sender, EventArgs e)
        {
            #region ***
            try
            {

                Response.Redirect(Common.RedirectToPage(pageId, Request.QueryString["sm"]) + "&done=" + Request.QueryString["done"] + "&arrow=" + Request.QueryString["arrow"] + "&PC=" + Request.QueryString["PC"]);
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                lblError.Visible = false;

            }
            #endregion
        }
        protected void btnBack_Click(object sender, EventArgs e)
        {
            #region ***
            try
            {
                Response.Redirect(Common.RedirectToPage(pageId - 2, Request.QueryString["sm"]) + "&done=" + Request.QueryString["done"] + "&arrow=" + Request.QueryString["arrow"] + "&PC=" + Request.QueryString["PC"]);
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                lblError.Visible = false;

            }
            #endregion
        }
        protected void dgDMS_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            #region Paging
            dgDMS.PageIndex = e.NewPageIndex;
            dgDMS.DataSource = BindGrid();
            dgDMS.DataBind();
            #endregion
        }
        private DataView BindGrid()
        {
            #region ***
            DataSet Ds = (DataSet)ViewState["DMSList"];
            DataView dv = new DataView(Ds.Tables[0]);
            return dv;
            #endregion

        }
        protected void dgDMS_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            #region select record
            if (e.CommandName == "View")
            {
                // get the DMSID of the clicked row
                string combinedstr = e.CommandArgument.ToString();
                string[] arrstr = combinedstr.Split(new char[] { '-' });
                string DMSID = arrstr[0].ToString().Trim();
                string Link = arrstr[1].ToString().Trim();

                // Redirect to the next page       
                Response.Redirect("DMSProfile.aspx?DMSID=" + DMSID + "&sm=" + Request.QueryString["sm"] + "&arrow=" + Request.QueryString["arrow"] + "&done=" + Request.QueryString["done"] + "&PC=" + txtCompName.Value + "&Link=" + Link);


            }
            #endregion
        }

        public bool FormatLinkStatus(object objStatus)
        {
            int Status = (int)objStatus;
            bool outStatus = false;

            if (Status == 0)
                outStatus = false;
            else if (Status == 1)
                outStatus = true;

            return outStatus;
        }

        private string CheckApplicationLink()
        {
            // ANTU: Remove DMS
            return null;

            //////string DMSID = string.Empty;

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
            //////{
            //////    DMSID = responseData.ResultList.Tables[0].Rows[0]["DMSID"].ToString();
            //////}
            //////#endregion

            //////#endregion
            //////return DMSID;
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
