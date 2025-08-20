using EnrollmentIssuanceSite.DALMWS;
using EnrollmentIssuanceSite.EnrollManagementWS;
using EnrollmentIssuanceSite.Shared;
using System;
using System.Data;
using System.IO;
using System.Text;
using System.Web.UI.WebControls;
using System.Xml;

namespace EnrollmentIssuanceSite
{
    public partial class Search : System.Web.UI.Page
    {
        const int pageId = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.BIRTHDATE.Text = Request[this.BIRTHDATE.UniqueID];
            btnSearch.Focus();

            #region check permission
            if (Common.GetCookie(this.Page, "GroupPermission") != null)
            {

                string GroupPermission = Common.GetCookie(this.Page, "GroupPermission");
                if ((GroupPermission == "001" || GroupPermission == "101" || GroupPermission == "100") && Request.QueryString["sm"] == "0")
                {
                    Common.logoutErrMsg = "You are not authorized to view this page. Please login again to proceed.";
                    Response.Redirect("ErrorPage.aspx?ms=9");
                }
            }
            #endregion

            #region ***
            if (!Page.IsPostBack)
            {
                txtCompName.Value = Request.QueryString["PC"];
                SelectCountryList();
                SelectBranchList();
                string type = Request.QueryString["sm"];
                string arrow = Request.QueryString["arrow"];
                if (type == "11")
                {
                    GetImcompleteFile();
                    tbIncomplete.Visible = true;
                    tbQuery.Visible = false;
                    if (arrow == "2")
                    {
                        fly.Text = "Visa - Resume Data Entry";
                        btnSearch2.Text = "Resume Data Entry";
                    }
                }
                else if (type == "7")
                {
                    GetImcompleteFile();
                    tbIncomplete.Visible = true;
                    tbQuery.Visible = false;
                    fly.Text = "Visa- Resume Enrollment";

                }
                else if (Request.QueryString["sm"] == "0")
                {

                    tbIncomplete.Visible = false;
                    tbQuery.Visible = true;
                    fly.Text = "Visa - Data Entry";
                }
            }
            #endregion

        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            SearchCategory();
        }
        private void SearchCategory()
        {
            #region search

            SearchType.Value = SEARCHBY.SelectedValue;
            string searchVal = SEARCHVALUE.Text.Trim().ToUpper();
            string firstname = SEARCHFIRST.Text.Trim().ToUpper();
            string middlename = SEARCHMIDDLE.Text.Trim().ToUpper();
            string DOB = string.Empty;
            if (BIRTHDATE.Text != string.Empty)
                DOB = BIRTHDATE.Text.Replace("/", "");

            switch (SEARCHBY.SelectedValue)
            {
                case "1": // APPLICATION ID
                    SEARCH(SEARCHBY.SelectedValue, string.Empty, searchVal, string.Empty, string.Empty);
                    break;
                case "2":// PASSPORT NO
                    SEARCH(SEARCHBY.SelectedValue, string.Empty, string.Empty, searchVal, PASSPORTPOI.SelectedValue);
                    break;
                case "4":// NAME
                    SEARCHBYNAME(SEARCHBY.SelectedValue, searchVal, firstname, middlename, DOB);
                    break;
                case "5": // BRANCH
                    SEARCHBYBRANCH(DDBRANCH.SelectedValue);
                    break;

                default:
                    SetRowVisibility(false, false, false, false, false, false, true, false, false);
                    break;
            }

            #endregion
        }
        private void SEARCHBYNAME(string searchVal, string SurName, string First, string Middle, string Birthdate)
        {
            #region request Applicant Record By Name
            tbInfo.Visible = false;
            try
            {

                #region calling web service
                EMService enrol = new EMService();
                RequestDataTypeQueryByName reqData = new RequestDataTypeQueryByName();
                #endregion

                #region request data
                reqData.ActionDescription = "Query by Name";
                reqData.SessionKey = Common.GetCookie(this.Page, "sessionKey");
                reqData.LocationName = txtCompName.Value.Trim();
                reqData.PermissionCode = Common.GetValue("QueryByNameCode");
                reqData.Surname = SurName;
                reqData.FirstName = First;
                reqData.MiddleName = Middle;
                reqData.BirthDate = Birthdate;

                ResponseDataTypeQueryByName responseData = enrol.QueryByName(reqData);
                #endregion

                #region get result
                string statusCode = responseData.StatusCode;
                string statusMsg = responseData.StatusMessage;

                #endregion

                #region analize result

                if (statusCode != "0")
                {

                    lblSearchError.Text = statusMsg;
                    lblSearchError.Visible = true;
                    btnSearch.Visible = true;
                    btn_Submit.Visible = false;

                }
                else
                {
                    int i = responseData.ResultList.Tables[0].Rows.Count;
                    if (i == 0)
                    {
                        lblMsgSearch.Text = Common.NORECORD;
                        lblMsgSearch.Visible = true;
                        tbdgInfo.Visible = false;
                    }
                    else
                    {

                        ViewState["DataByName"] = responseData.ResultList;
                        FilterDG();
                    }
                }
                #endregion

            }
            catch (Exception ex)
            {
                lblSearchError.Text = ex.Message;
                lblSearchError.Visible = true;
            }

            #endregion
        }

        private void SEARCH(string SearchMode, string NIS, string AppID, string PassportNo, string POI)
        {
            #region request Applicant Record by NIS, Doc No, AppID

            tbdgInfo.Visible = false;
            try
            {

                #region calling web service
                EMService enrol = new EMService();
                RequestDataTypeGetDetails reqData = new RequestDataTypeGetDetails();

                reqData.ActionDescription = "Get Details";
                reqData.SessionKey = Common.GetCookie(this.Page, "sessionKey");
                reqData.EnrolLocationName = txtCompName.Value.Trim();
                reqData.SearchType = SearchMode;
                reqData.PermissionCode = Common.GetValue("GetDetailsPermissionCode");
                reqData.ApplicationID = AppID;
                reqData.PassportCOI = POI;
                reqData.PassportNo = PassportNo;
                reqData.DocNo = NIS;

                ResponseDataTypeGetDetails responseData = enrol.GetDetails(reqData);
                #endregion

                #region get result from web service
                string statusCode = responseData.StatusCode;
                string statusMsg = responseData.StatusMessage;
                #endregion

                #region analyze result

                if (statusCode == "0")
                {
                    //Display the search result message            

                    if (responseData.StageCode.Substring(0, 6) == "EM4000" || responseData.StageCode.Substring(0, 6) == "EM4001" || responseData.StageCode.Substring(0, 6) == "EM4003")
                    {

                        lblMsgSearch.Visible = false;
                        btnSearch.Visible = true;
                        btn_Submit.Visible = true;

                        #region display applicant info
                        tbInfo.Visible = true;
                        ENROLTIME.Text = Convert.ToDateTime(responseData.EnrolTime).ToString("dd/MM/yyyy");
                        SURNAME.Text = responseData.Surname;
                        FIRSTNAME.Text = responseData.FirstName;
                        MIDDLENAME.Text = responseData.MiddleName;
                        SEX.Text = (responseData.Sex == "F") ? "Female".ToUpper() : "Male".ToUpper();
                        BIRTHPLACE.Text = responseData.BirthPlace;


                        BIRTHCOUNTRY.Text = responseData.BirthCountry;

                        if (responseData.NationalIDNo == "")
                        {
                            NATIONALINSURANCENO.Text = "-";
                        }
                        else
                        {
                            NATIONALINSURANCENO.Text = responseData.NationalIDNo;
                        }

                        FORMNO.Value = responseData.ApplicationID;
                        APPID.Text = responseData.ApplicationID; ;
                        STAGECODE.Text = responseData.StageCode;
                        DOCTYPE.Text = responseData.DocType;
                        PRIORITY.Text = responseData.Priority.ToString();
                        APPREASON.Text = responseData.AppReason;

                        RedirectToMainPage();

                        #endregion
                    }
                    else
                    {
                        lblMsgSearch.Text = "Record is not available to be updated.";
                        lblMsgSearch.Visible = true;
                    }
                }
                else
                {
                    throw new Exception(statusMsg);
                }
                #endregion

            }
            catch (Exception ex)
            {
                lblSearchError.Text = ex.Message;
                lblSearchError.Visible = true;
                btnSearch.Visible = true;
                btn_Submit.Visible = false;
                tbInfo.Visible = false;
            }

            #endregion
        }
        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            RedirectToMainPage();
        }
        private void RedirectToMainPage()
        {
            #region ***
            try
            {
                CreateXmlFile();
                Response.Redirect("ApplicationPart1.aspx?sm=" + Common.COMPLETEENROLECODE + "&done=" + FORMNO.Value + Common.COMPLETEENROLECODE + "&arrow=" + Request.QueryString["arrow"] + "&PC=" + txtCompName.Value);

            }
            catch (Exception ex)
            {
                lblMsgSearch.Text = ex.Message;
                lblMsgSearch.Visible = true;
            }
            #endregion
        }
        private void CreateXmlFile()
        {
            #region ****

            try
            {
                #region connect webservice

                EMService enrol = new EMService();
                RequestDataTypeGetDetails reqData = new RequestDataTypeGetDetails();

                reqData.PermissionCode = Common.GetValue("GetDetailsPermissionCode");
                reqData.ActionDescription = "Get Details";
                reqData.SessionKey = Common.GetCookie(this.Page, "sessionKey");
                reqData.EnrolLocationName = txtCompName.Value.Trim();
                reqData.SearchType = "1";
                reqData.ApplicationID = FORMNO.Value;
                reqData.PassportNo = string.Empty;
                reqData.DocNo = string.Empty;
                reqData.PassportCOI = string.Empty;

                ResponseDataTypeGetDetails responseData = enrol.GetDetails(reqData);

                string statusCode = responseData.StatusCode;
                string statusMsg = responseData.StatusMessage;
                #endregion

                if (statusCode == "0")
                {


                    #region create xml
                    StringBuilder requestXmlStr = new StringBuilder();

                    #region VISWEBREQUEST XML
                    //VISWEBREQUEST
                    requestXmlStr.Append("<?xml version='1.0' encoding='utf-8' ?>");
                    requestXmlStr.Append("<VISWEBREQUEST>");
                    requestXmlStr.Append("<PERMISSIONCODE>");
                    requestXmlStr.Append("</PERMISSIONCODE>");
                    requestXmlStr.Append("<ACTIONDESCRIPTION>");
                    requestXmlStr.Append("Complete Enrol");
                    requestXmlStr.Append("</ACTIONDESCRIPTION>");
                    //Transaction time
                    requestXmlStr.Append("<TRANSACTIONDATETIME></TRANSACTIONDATETIME>");
                    #region PAYLOAD
                    //PAYLOAD
                    requestXmlStr.Append("<PAYLOAD>");
                    //Session key
                    requestXmlStr.Append("<SESSIONKEY></SESSIONKEY>");
                    //Identifier
                    requestXmlStr.Append("<IDENTIFIER>");
                    requestXmlStr.Append(Common.IDENTIFIER);
                    requestXmlStr.Append("</IDENTIFIER>");
                    #region ENROLLMENT
                    requestXmlStr.Append("<ENROLLMENT>");
                    requestXmlStr.Append("<partdone>1</partdone>");

                    #region ENROL PROFILE
                    requestXmlStr.Append("<ENROLPROFILE>");
                    requestXmlStr.Append("<PRIORITY>");
                    requestXmlStr.Append(responseData.Priority.ToString());
                    requestXmlStr.Append("</PRIORITY>");
                    #region DOCTYPE
                    requestXmlStr.Append("<DOCTYPE>");
                    if (responseData.DocType != string.Empty)
                    {
                        string[] DT = responseData.DocType.ToString().Split(new char[] { '-' });
                        requestXmlStr.Append(DT[0].ToString().Trim());
                    }
                    requestXmlStr.Append("</DOCTYPE>");
                    #endregion

                    #region ENTRYTYPE
                    requestXmlStr.Append("<SUBDOCTYPE>");
                    if (responseData.EntryType != string.Empty)
                    {
                        string[] ET = responseData.EntryType.ToString().Split(new char[] { '-' });
                        requestXmlStr.Append(ET[0].ToString().Trim());
                    }
                    requestXmlStr.Append("</SUBDOCTYPE>");
                    #endregion              

                    #region APPROVEDDOCTYPE
                    requestXmlStr.Append("<APPROVEDDOCTYPE>");
                    requestXmlStr.Append(responseData.ApprovedDocType);
                    requestXmlStr.Append("</APPROVEDDOCTYPE>");
                    #endregion

                    #region APPROVEDENTRYTYPE
                    requestXmlStr.Append("<APPROVEDSUBDOCTYPE>");
                    requestXmlStr.Append(responseData.ApprovedEntryType);
                    requestXmlStr.Append("</APPROVEDSUBDOCTYPE>");
                    #endregion              

                    requestXmlStr.Append("<NOFINGER>");
                    requestXmlStr.Append("</NOFINGER>");
                    requestXmlStr.Append("<APPREASON>");
                    requestXmlStr.Append(responseData.AppReason.Substring(0, 1));
                    requestXmlStr.Append("</APPREASON>");
                    requestXmlStr.Append("<FORMNO>");
                    requestXmlStr.Append(responseData.ApplicationID);
                    requestXmlStr.Append("</FORMNO>");
                    requestXmlStr.Append("<IDPERSON>");
                    requestXmlStr.Append(responseData.IDPerson.ToString());
                    requestXmlStr.Append("</IDPERSON>");
                    requestXmlStr.Append("<ENROLDATE>");
                    requestXmlStr.Append(Convert.ToDateTime(responseData.EnrolTime).ToString("ddMMyyyy"));
                    requestXmlStr.Append("</ENROLDATE>");
                    requestXmlStr.Append("<COLDATE>");
                    requestXmlStr.Append(Convert.ToDateTime(responseData.CollectionDate).ToString("ddMMyyyy"));
                    requestXmlStr.Append("</COLDATE>");
                    requestXmlStr.Append("</ENROLPROFILE>");
                    #endregion

                    #region MAIN
                    requestXmlStr.Append("<MAIN>");
                    requestXmlStr.Append("<IDPERSON>");
                    requestXmlStr.Append(responseData.IDPerson.ToString());
                    requestXmlStr.Append("</IDPERSON>");
                    requestXmlStr.Append("<NATIONALITY>");
                    requestXmlStr.Append(responseData.Nationality.Substring(0, 3));
                    requestXmlStr.Append("</NATIONALITY>");
                    requestXmlStr.Append("<NATIONALINSURANCENO>");
                    requestXmlStr.Append(responseData.NationalIDNo);
                    requestXmlStr.Append("</NATIONALINSURANCENO>");
                    requestXmlStr.Append("<SURNAME>");
                    requestXmlStr.Append(responseData.Surname);
                    requestXmlStr.Append("</SURNAME>");
                    requestXmlStr.Append("<FIRSTNAME>");
                    requestXmlStr.Append(responseData.FirstName);
                    requestXmlStr.Append("</FIRSTNAME>");
                    requestXmlStr.Append("<MIDDLENAME>");
                    requestXmlStr.Append(responseData.MiddleName);
                    requestXmlStr.Append("</MIDDLENAME>");
                    requestXmlStr.Append("<SEX>");
                    requestXmlStr.Append(responseData.Sex);
                    requestXmlStr.Append("</SEX>");
                    requestXmlStr.Append("<BIRTHDATE>");
                    requestXmlStr.Append(Convert.ToDateTime(responseData.BirthDate).ToString("ddMMyyyy"));
                    requestXmlStr.Append("</BIRTHDATE>");
                    requestXmlStr.Append("<BIRTHPLACE>");
                    requestXmlStr.Append(responseData.BirthPlace);
                    requestXmlStr.Append("</BIRTHPLACE>");
                    requestXmlStr.Append("<BIRTHCOUNTRY>");
                    requestXmlStr.Append(responseData.BirthCountry.Substring(0, 3));
                    requestXmlStr.Append("</BIRTHCOUNTRY>");
                    requestXmlStr.Append("<TITLE>");
                    requestXmlStr.Append(responseData.Title);
                    requestXmlStr.Append("</TITLE>");
                    requestXmlStr.Append("<PASSPORTNO>");
                    requestXmlStr.Append(responseData.PassportNo);
                    requestXmlStr.Append("</PASSPORTNO>");
                    requestXmlStr.Append("<PASSPORTPOI>");
                    requestXmlStr.Append(responseData.PassportPOI);
                    requestXmlStr.Append("</PASSPORTPOI>");
                    requestXmlStr.Append("<PASSPORTCOI>");
                    requestXmlStr.Append(responseData.PassportCOI.Substring(0, 3));
                    requestXmlStr.Append("</PASSPORTCOI>");
                    requestXmlStr.Append("<PASSPORTDOI>");
                    requestXmlStr.Append(Convert.ToDateTime(responseData.PassportDOI).ToString("ddMMyyyy"));
                    requestXmlStr.Append("</PASSPORTDOI>");
                    requestXmlStr.Append("<PASSPORTDOE>");
                    requestXmlStr.Append(Convert.ToDateTime(responseData.PassportDOE).ToString("ddMMyyyy"));
                    requestXmlStr.Append("</PASSPORTDOE>");

                    requestXmlStr.Append("</MAIN>");
                    #endregion

                    #region BIO
                    requestXmlStr.Append("<BIO>");
                    requestXmlStr.Append("</BIO>");


                    #endregion

                    requestXmlStr.Append("<SCANNED>");
                    requestXmlStr.Append("</SCANNED>");
                    requestXmlStr.Append("<CONTACT>");
                    requestXmlStr.Append("</CONTACT>");
                    requestXmlStr.Append("<EMPLOYMENT></EMPLOYMENT>");
                    requestXmlStr.Append("<TRAVEL></TRAVEL>");
                    requestXmlStr.Append("<FAMILY></FAMILY>");
                    requestXmlStr.Append("<ADDITIONAL></ADDITIONAL>");

                    requestXmlStr.Append("</ENROLLMENT>");
                    #endregion

                    #endregion

                    requestXmlStr.Append("</PAYLOAD>");
                    #endregion

                    requestXmlStr.Append("</VISWEBREQUEST>");
                    #endregion

                    #region Save the temporary file at server side
                    string fileName = @Server.MapPath("") + Common.GetValue("xmlServerPath") + FORMNO.Value + Common.COMPLETEENROLECODE + ".xml";
                    Common.WriteLog(@Server.MapPath("") + Common.GetValue("logPath"), "Create XML - " + fileName);
                    //Create xml writter
                    XmlTextWriter xmlWriter = new XmlTextWriter(fileName, null);

                    //Write the string into xml file
                    xmlWriter.WriteRaw(requestXmlStr.ToString());
                    xmlWriter.Flush();

                    if (xmlWriter != null)
                    {
                        xmlWriter.Close();
                    }

                    #endregion

                }
                else
                {
                    lblMsgSearch.Text = "Unable to create XML file";
                    lblMsgSearch.Visible = true;
                }
            }
            catch (Exception ex)
            {
                Common.WriteLog(@Server.MapPath("") + Common.GetValue("logPath"), "Create XML - " + ex.Message);
                lblMsgSearch.Text = ex.Message;
                lblMsgSearch.Visible = true;
            }
            #endregion
        }
        protected void SEARCHBY_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region ***

            SEARCHVALUE.Text = string.Empty;
            lblMsgSearch.Text = string.Empty;

            switch (SEARCHBY.SelectedValue)
            {
                case "1":// Application ID
                    lblName.Text = "Application ID";
                    SetRowVisibility(false, false, false, false, false, true, false, false, false);
                    RFVSearchValue.Enabled = true;
                    RFVSearchValue.ErrorMessage = "Please enter Application ID before pressing the <SEARCH> button";
                    break;
                case "2":// Passport No
                    lblName.Text = "Passport No";
                    SetRowVisibility(false, false, false, false, false, true, false, true, false);
                    RFVSearchValue.Enabled = true;
                    RFVSearchValue.ErrorMessage = "Please enter Passport No before pressing the <SEARCH> button";
                    break;
                case "5":// Branch                
                    SetRowVisibility(false, false, false, false, false, false, false, false, true);
                    break;
                case "4":// Name
                    lblName.Text = "Surname";
                    SetRowVisibility(true, false, true, true, false, true, false, false, false);
                    RFVSearchValue.Enabled = false;
                    break;
                default:
                    SetRowVisibility(false, false, false, false, false, false, true, false, false);
                    break;
            }
            #endregion

        }
        private void SetRowVisibility(bool DOB, bool Info, bool First, bool Middle, bool DGrid, bool SearchVal, bool Clear, bool POI, bool branch)
        {
            #region ***
            trDOB.Visible = DOB;
            tbInfo.Visible = Info;
            trFirstname.Visible = First;
            trMiddlename.Visible = Middle;
            tbdgInfo.Visible = DGrid;
            trSearchValue.Visible = SearchVal;
            btnClear.Disabled = Clear;
            trPOI.Visible = POI;
            trBranch.Visible = branch;

            #endregion
        }
        private void CheckAppReason(string purpose)
        {
            #region APPREASON
            switch (purpose)
            {
                case "1":
                    APPREASON.Text = "New Application".ToUpper();
                    break;
                case "2":
                    APPREASON.Text = "Renewal".ToUpper();
                    break;
                case "3":
                    APPREASON.Text = "Replacement".ToUpper();
                    break;
                default:
                    APPREASON.Text = string.Empty;
                    break;
            }
            #endregion
        }
        private void GetImcompleteFile()
        {

            #region ***
            /* Transaction Type
         * 1 - New Enrollment
         * 2 - Renew
         * 3 - Replace        
         * 6 - Data Entry
         * 4 - ExternalData Entry
         * 9 - Update Profile - Data Entry
         * A - Update Profile - Enrollment
         */

            try
            {
                string type = Request.QueryString["sm"];
                string arrow = Request.QueryString["arrow"];

                string[] fileList = Directory.GetFiles(@Server.MapPath("") + Common.GetValue("xmlServerPath"));
                foreach (string filename in fileList)
                {
                    FileInfo fileInfo = new FileInfo(filename);
                    ListItem li = new ListItem();

                    string transactionType = fileInfo.Name.Substring(0, (fileInfo.Name.Length - fileInfo.Extension.Length));

                    #region categorised incomplete enrollment according to group permisson
                    if (type == "11" && arrow == "2") // Data Entry
                    {
                        //if (transactionType.Substring(transactionType.Length - 1) == common.COMPLETEENROLECODE || transactionType.Substring(transactionType.Length - 1) == common.UPDATEPROFILECODE)
                        if (transactionType.Substring(transactionType.Length - 1) == Common.COMPLETEENROLECODE || transactionType.Substring(transactionType.Length - 1) == Common.GetValue("ExternalDEStage"))
                        {
                            li.Value = fileInfo.Name.Substring(0, (fileInfo.Name.Length - (fileInfo.Extension.Length)));
                            li.Text = fileInfo.Name.Substring(0, (fileInfo.Name.Length - (fileInfo.Extension.Length + 1)));
                            ddlfiles.Items.Add(li);
                        }
                    }
                    else if (type == "7" && arrow == "21")//Acceptance Clerk
                    {
                        if (transactionType.Substring(transactionType.Length - 1) != Common.COMPLETEENROLECODE && transactionType.Substring(transactionType.Length - 1) != Common.UPDATEPROFILECODE && transactionType.Substring(transactionType.Length - 1) != Common.UPDATEPROFILEENROLCODE && transactionType.Substring(transactionType.Length - 1) != Common.GetValue("ExternalDEStage"))
                        {
                            li.Value = fileInfo.Name.Substring(0, (fileInfo.Name.Length - (fileInfo.Extension.Length)));
                            li.Text = fileInfo.Name.Substring(0, (fileInfo.Name.Length - (fileInfo.Extension.Length + 1)));
                            ddlfiles.Items.Add(li);
                        }
                    }
                    #endregion
                }


                if (ddlfiles.Items.Count < 1)
                {
                    btnSearch2.Enabled = false;
                    lblMsgSearch2.Visible = true;
                    lblMsgSearch2.Text = "No record found.";
                    ddlfiles.Enabled = false;
                }
                else
                {
                    btnSearch.Enabled = true;
                    ddlfiles.Enabled = true;
                    lblMsgSearch2.Visible = false;
                    ddlfiles.Items.Insert(0, new ListItem("-SELECT-", ""));
                }
            }
            catch (Exception ex)
            {
                lblMsgSearch.Visible = true;
                lblMsgSearch.Text = ex.Message;
                Common.WriteLog(@Server.MapPath("") + Common.GetValue("logPath"), ex.Message);
            }
            #endregion
        }

        protected void btnSearch2_Click(object sender, EventArgs e)
        {
            #region ***

            string fileName = @Server.MapPath("") + Common.GetValue("xmlServerPath") + ddlfiles.SelectedValue + ".xml";
            string sm = ddlfiles.SelectedValue.Substring(ddlfiles.SelectedValue.Length - 1, 1);
            if (File.Exists(fileName))
            {
                Response.Redirect(Common.RedirectToPage(pageId, sm) + "&arrow=" + Request.QueryString["arrow"] + "&done=" + ddlfiles.SelectedValue + "&PC=" + txtCompName.Value);

            }
            else
            {
                lblMsgSearch2.Text = Common.FILENOTFOUND;
                lblMsgSearch2.Visible = true;
            }
            #endregion
        }

        private DataView BindGrid()
        {
            #region ***
            DataSet Ds = (DataSet)ViewState["DataByName"];
            DataView dv = new DataView(Ds.Tables[0]);
            dv.RowFilter = "StageCode Like 'EM4000%' OR StageCode Like 'EM4001%' OR StageCode Like 'EM4003%'";
            return dv;
            #endregion

        }
        protected void dgByName_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgByName.PageIndex = e.NewPageIndex;
            dgByName.DataSource = BindGrid();
            dgByName.DataBind();

        }

        protected void dgByName_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            #region ***
            try
            {
                if (e.CommandName == "Select")
                {
                    // get the FORMNO of the clicked row
                    FORMNO.Value = e.CommandArgument.ToString();
                    // Create XML
                    CreateXmlFile();
                    Response.Redirect("ApplicationPart1.aspx?sm=" + Common.COMPLETEENROLECODE + "&done=" + FORMNO.Value + Common.COMPLETEENROLECODE + "&arrow=" + Request.QueryString["arrow"] + "&PC=" + txtCompName.Value);


                }
            }
            catch (Exception ex)
            {
                lblSearchError.Text = ex.Message;
                lblSearchError.Visible = true;
            }
            #endregion
        }
        protected void btn_ViewAll_Click(object sender, EventArgs e)
        {
            #region***
            tbInfo.Visible = false;
            ViewAllDataEntry();
            #endregion
        }

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            #region ***
            if ((SEARCHFIRST.Text.Trim().Length > 0) || (SEARCHMIDDLE.Text.Trim().Length > 0) || (SEARCHVALUE.Text.Trim().Length > 0))
            {
                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
            }
            #endregion
        }
        private void ViewAllDataEntry()
        {
            #region request Data ENtry List    
            tbInfo.Visible = false;
            try
            {

                #region calling web service
                EMService enrol = new EMService();
                RequestDataTypeSelectDataEntryList reqData = new RequestDataTypeSelectDataEntryList();
                #endregion

                #region request data
                reqData.ActionDescription = "Select Data Entry";
                reqData.SessionKey = Common.GetCookie(this.Page, "sessionKey");
                reqData.EnrolLocationName = txtCompName.Value.Trim();
                reqData.PermissionCode = Common.GetValue("DataEntryListCode");


                ResponseDataTypeSelectDataEntryList responseData = enrol.SelectDataEntryList(reqData);
                #endregion

                #region get result
                string statusCode = responseData.StatusCode;
                string statusMsg = responseData.StatusMessage;

                #endregion

                #region analize result

                if (statusCode != "0")
                    throw new Exception(statusMsg);

                else
                {
                    int i = responseData.ResultList.Tables[0].Rows.Count;
                    if (i == 0)
                    {
                        throw new Exception(Common.NORECORD);
                    }
                    else
                    {
                        tbdgInfo.Visible = true;
                        ViewState["DataByName"] = responseData.ResultList;
                        dgByName.DataSource = responseData.ResultList.Tables[0];
                        dgByName.PageIndex = 0;
                        dgByName.DataBind();
                        btn_Submit.Visible = false;
                        lblMsgSearch.Visible = false;
                    }
                }
                #endregion

            }
            catch (Exception ex)
            {
                lblSearchError.Text = ex.Message;
                lblSearchError.Visible = true;
                tbdgInfo.Visible = false;
                Common.WriteLog(@Server.MapPath("") + Common.GetValue("logPath"), "Select Data Entry List - " + ex.Message);
            }
            #endregion
        }
        private void SelectCountryList()
        {
            #region ***
            try
            {
                #region connecting to web service
                EMService enrol = new EMService();
                RequestDataTypeSelectCountry reqData = new RequestDataTypeSelectCountry();

                reqData.ActionDescription = "Get Country";
                reqData.SessionKey = Common.GetCookie(this.Page, "sessionKey");
                reqData.EnrolLocationName = txtCompName.Value.Trim();
                reqData.PermissionCode = Common.GetValue("SelectCountry");
                reqData.SortBy = Convert.ToChar("1");

                #endregion

                #region response
                ResponseDataTypeSelectCountry responseData = enrol.GetCountryList(reqData);

                string statusCode = responseData.StatusCode;
                string statusMsg = responseData.StatusMessage;
                #endregion

                #region analize result
                if (statusCode == "0")
                {

                    DataSet ds1 = (DataSet)responseData.ResultList;
                    #region COUNTRY
                    DataRow[] dr1 = ds1.Tables[0].Select(null, "Name", DataViewRowState.CurrentRows);
                    for (int i = 0; i < dr1.Length; i++)
                    {
                        ListItem li = new ListItem(dr1[i]["Name"].ToString() + " - " + dr1[i]["Code"], dr1[i]["Code"].ToString());
                        PASSPORTPOI.Items.Add(li);
                    }
                    PASSPORTPOI.Items.Insert(0, new ListItem("-SELECT-", ""));

                    #endregion
                }
                else
                {
                    lblSearchError.Text = statusMsg;
                    lblSearchError.Visible = true;
                }
                #endregion
            }
            catch (Exception ex)
            {
                lblSearchError.Text = ex.Message;
                lblSearchError.Visible = true;
                Common.WriteLog(@Server.MapPath("") + Common.GetValue("logPath"), "Select Country List - " + ex.Message);
            }
            #endregion
        }
        private void SelectBranchList()
        {
            #region ***
            try
            {
                #region connecting to web service
                DALMService enrol = new DALMService();
                RequestDataTypeSelectBranch reqData = new RequestDataTypeSelectBranch();

                reqData.ActionDescription = "Get Branch List";
                reqData.SessionKey = Common.GetCookie(this.Page, "sessionKey");
                reqData.PermissionCode = Common.GetValue("SelectBranchList");

                #endregion

                #region response
                ResponseDataTypeSelectBranch responseData = enrol.SelectBranchList(reqData);

                string statusCode = responseData.StatusCode;
                string statusMsg = responseData.StatusMessage;
                #endregion

                #region analize result
                if (statusCode == "0")
                {


                    DataSet Ds = (DataSet)responseData.ResultList;
                    DDBRANCH.DataSource = Ds.Tables[0];
                    DDBRANCH.DataValueField = "BranchCode";
                    DDBRANCH.DataTextField = "BranchName";
                    DDBRANCH.DataBind();
                    DDBRANCH.Items.Insert(0, new ListItem("-SELECT-", ""));
                }
                else
                    throw new Exception();
                #endregion
            }
            catch (Exception ex)
            {
                lblSearchError.Text = ex.Message;
                lblSearchError.Visible = true;
                Common.WriteLog(@Server.MapPath("") + Common.GetValue("logPath"), "Select Branch List - " + ex.Message);
            }
            #endregion
        }
        private void SEARCHBYBRANCH(string branchname)
        {
            #region request Applicant Record By Branch
            try
            {
                #region calling web service
                EMService enrol = new EMService();
                RequestDataTypeQueryByBranch reqData = new RequestDataTypeQueryByBranch();

                reqData.ActionDescription = "Get Details By Branch";
                reqData.SessionKey = Common.GetCookie(this.Page, "sessionKey");
                reqData.LocationName = txtCompName.Value.Trim();
                reqData.PermissionCode = Common.GetValue("QueryByBranch");
                reqData.BranchCode = branchname;

                ResponseDataTypeQueryByBranch responseData = enrol.QueryByBranch(reqData);
                #endregion

                #region response from web service
                string statusCode = responseData.StatusCode;
                string statusMsg = responseData.StatusMessage;


                if (statusCode != "0")
                {
                    lblMsgSearch.Text = statusMsg;
                    lblMsgSearch.Visible = true;
                    btnSearch.Visible = true;
                    tbdgInfo.Visible = false;
                }
                else
                {
                    int i = responseData.ResultList.Tables[0].Rows.Count;
                    if (i == 0)
                    {
                        lblMsgSearch.Text = Common.NORECORD;
                        lblMsgSearch.Visible = true;
                        tbdgInfo.Visible = false;
                    }
                    else
                    {
                        lblMsgSearch.Visible = false;
                        tbdgInfo.Visible = true;
                        ViewState["DataByName"] = responseData.ResultList;
                        FilterDG();
                    }
                }
                #endregion
            }
            catch (Exception ex)
            {
                lblSearchError.Text = ex.Message;
                lblSearchError.Visible = true;
                tbdgInfo.Visible = false;
                Common.WriteLog(@Server.MapPath("") + Common.GetValue("logPath"), "Search By Branch- " + ex.Message);
            }
            #endregion
        }
        private void FilterDG()
        {
            DataSet ds = (DataSet)ViewState["DataByName"];
            DataView dv = new DataView(ds.Tables[0]);
            dv.RowFilter = "StageCode Like 'EM4000%' OR StageCode Like 'EM4001%' OR StageCode Like 'EM4003%'";

            #region display data if there is record match
            int x = dv.Count;
            if (x == 0)
            {
                lblMsgSearch.Text = "Record is not available to be updated.";
                lblMsgSearch.Visible = true;
                tbdgInfo.Visible = false;
            }
            else
            {
                dgByName.DataSource = dv;
                dgByName.PageIndex = 0;
                dgByName.DataBind();
                tbdgInfo.Visible = true;
                btn_Submit.Visible = false;
                lblMsgSearch.Visible = false;
            }
            #endregion
        }


    }
}
