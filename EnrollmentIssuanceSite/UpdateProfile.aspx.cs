using EnrollmentIssuanceSite.EnrollManagementWS;
using EnrollmentIssuanceSite.Shared;
using System;
using System.Data;
using System.Text;
using System.Web.UI.WebControls;
using System.Xml;

namespace EnrollmentIssuanceSite
{
    public partial class UpdateProfile : System.Web.UI.Page
    {
        private static string query;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.BIRTHDATE.Text = Request[this.BIRTHDATE.UniqueID];
            if (Request.QueryString["PC"] != null)
            {
                #region ***
                txtCompName.Value = Request.QueryString["PC"];
                getCountryList();
                SM.Value = Request.QueryString["sm"];
                if (SM.Value == Common.GetValue("UpdateProfileEnroll"))
                {
                    fly.Text = "Visa - Update Profile Enrollment";
                    query = Common.GetValue("UpdateEnrollQuery");
                }
                else
                {
                    fly.Text = "Visa - Update Profile Data Entry";
                    query = Common.GetValue("UpdateDEQuery");
                }
                #endregion
            }
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            #region search

            SearchType.Value = SEARCHBY.SelectedValue;
            string searchVal = SEARCHVALUE.Text.Trim();
            string firstname = SEARCHFIRST.Text.Trim().ToUpper();
            string middlename = SEARCHMIDDLE.Text.Trim().ToUpper();
            string DOB = BIRTHDATE.Text.Replace("/", "");
            string COI = BIRTHCOUNTRYDD.SelectedValue;
            FORMNO.Value = string.Empty;


            switch (SEARCHBY.SelectedValue)
            {
                case "1": // APPLICATION ID
                    SEARCH(SEARCHBY.SelectedValue, searchVal, string.Empty, string.Empty);
                    break;
                case "2":// PASSPORT NO
                    SEARCH(SEARCHBY.SelectedValue, string.Empty, searchVal, COI);
                    break;
                case "4":// NAME
                    SEARCHBYNAME(SEARCHBY.SelectedValue, searchVal, firstname, middlename, DOB);
                    break;
                default:
                    SetRowVisibility(false, false, false, false, false, false, true, false);
                    break;
            }

            #endregion
        }
        private void SetRowVisibility(bool DOB, bool Info, bool First, bool Middle, bool DGrid, bool SearchValue, bool Clear, bool Birth)
        {
            #region ***
            trDOB.Visible = DOB;
            tbInfo.Visible = Info;
            trFirstname.Visible = First;
            trMiddlename.Visible = Middle;
            tbDataGrid.Visible = DGrid;
            trSearchValue.Visible = SearchValue;
            btnClear.Disabled = Clear;
            trBirthCountry.Visible = Birth;
            #endregion
        }
        protected void SEARCHBY_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchVisibility(SEARCHBY.SelectedValue);
        }
        protected void dgByName_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            #region Paging
            dgByName.PageIndex = e.NewPageIndex;
            dgByName.DataSource = BindGrid();
            dgByName.DataBind();
            #endregion
        }
        private DataView BindGrid()
        {
            #region ***
            DataSet Ds = (DataSet)ViewState["DataByName"];
            DataView dv = new DataView(Ds.Tables[0]);
            dv.RowFilter = query;
            return dv;
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
        private void SearchVisibility(string type)
        {
            #region ***
            SEARCHVALUE.Text = string.Empty;
            BIRTHCOUNTRYDD.SelectedValue = string.Empty;

            switch (type)
            {
                case "1":// Application ID
                    lblName.Text = "Application ID";
                    SetRowVisibility(false, false, false, false, false, true, false, false);
                    RFVAppID.Enabled = true;
                    RFVAppID.ErrorMessage = "Please enter Application ID before pressing the <SEARCH> button";
                    break;
                case "2":// Passport
                    lblName.Text = "Passport No";
                    SetRowVisibility(false, false, false, false, false, true, false, true);
                    RFVAppID.Enabled = true;
                    RFVAppID.ErrorMessage = "Please enter Passport No before pressing the <SEARCH> button";
                    break;
                case "4":// Name & DOB
                    lblName.Text = "Surname";
                    SetRowVisibility(true, false, true, true, false, true, false, false);
                    RFVAppID.Enabled = false;
                    break;
                default:
                    SetRowVisibility(false, false, false, false, false, false, false, false);
                    SEARCHBY.SelectedValue = "";
                    break;
            }
            #endregion
        }
        private void SEARCH(string SearchMode, string AppID, string PassportNo, string COI)
        {
            #region request Applicant Record by Doc No, AppID, Passport No
            tbDataGrid.Visible = false;
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
                reqData.DocNo = string.Empty;
                reqData.PassportNo = PassportNo;
                reqData.PassportCOI = COI;

                ResponseDataTypeGetDetails responseData = enrol.GetDetails(reqData);
                #endregion

                #region get result

                string statusCode = responseData.StatusCode;
                string statusMsg = responseData.StatusMessage;
                #endregion

                #region display result
                if (statusCode == "0")
                {
                    bool status = false;
                    string alphaCode = responseData.StageCode.Substring(0, 2);
                    string scode = responseData.StageCode.Substring(0, 6);

                    #region Return data according to type of update profile perform
                    if (SM.Value == Common.GetValue("UpdateProfileEntry"))
                    {
                        if ((scode != "PM2000") && (scode != "PM1000") && (scode != "EM6000") && (scode != "EM6002") && (scode != "EM7000") && (scode != "EM1000") && (scode != "EM2000") && (scode != "EM2001") && (scode != "EM4000") && (scode != "EM4001") && (scode != "EM4002") && (scode != "EM4003"))
                            status = true;
                    }
                    else
                    {
                        if ((scode != "PM2000") && (scode != "PM1000") && (scode != "EM6000") && (scode != "EM6002") && (scode != "EM7000"))
                            status = true;
                    }

                    #endregion

                    if (status)
                    {
                        if (FORMNO.Value != string.Empty)
                        {
                            #region display applicant info
                            tbInfo.Visible = true;
                            ENROLTIME.Text = Convert.ToDateTime(responseData.EnrolTime).ToString("dd/MM/yyyy");
                            SURNAME.Text = responseData.Surname;
                            FIRSTNAME.Text = responseData.FirstName;
                            MIDDLENAME.Text = responseData.MiddleName;
                            SEX.Text = (responseData.Sex == "F") ? "Female".ToUpper() : "Male".ToUpper();

                            BIRTHCOUNTRY.Text = responseData.BirthCountry;
                            BIRTHPLACE.Text = responseData.BirthPlace;
                            NATIONALITY.Text = responseData.Nationality;
                            PASSPORTNO.Text = responseData.PassportNo;

                            FORMNO.Value = responseData.ApplicationID;
                            APPID.Text = responseData.ApplicationID; ;
                            STAGECODE.Text = responseData.StageCode;
                            DOCTYPE.Text = responseData.DocType;
                            SUBTYPE.Text = responseData.EntryType;
                            APPREASON.Text = responseData.AppReason;
                            #endregion
                        }
                        else
                        {
                            FORMNO.Value = responseData.ApplicationID;
                            CreateXMLAndRedirect();
                        }
                    }
                    else
                    {
                        lblMsgSearch.Text = "Record is not available to be updated";
                        lblMsgSearch.Visible = true;
                        tbInfo.Visible = false;
                    }
                }
                else
                {
                    lblSearchError.Text = statusMsg;
                    lblSearchError.Visible = true;
                    btnSearch.Visible = true;
                    tbInfo.Visible = false;
                }
                #endregion
            }
            catch (Exception ex)
            {
                lblSearchError.Visible = true;
                lblSearchError.Text = ex.Message;
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
                reqData.ActionDescription = "Get Details By Name";
                reqData.SessionKey = Common.GetCookie(this.Page, "sessionKey");
                reqData.LocationName = txtCompName.Value.Trim();
                reqData.PermissionCode = Common.GetValue("QueryByName");
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
                    tbDataGrid.Visible = false;
                }
                else
                {
                    ViewState["DataByName"] = responseData.ResultList;
                    DataSet ds = (DataSet)ViewState["DataByName"];
                    DataView dv = new DataView(ds.Tables[0]);
                    dv.RowFilter = query;


                    #region display data if there is record match
                    int i = dv.Count;
                    if (i == 0)
                    {
                        lblMsgSearch.Text = "Record is not available to be updated.";
                        lblMsgSearch.Visible = true;
                        tbDataGrid.Visible = false;
                    }
                    else
                    {
                        tbDataGrid.Visible = true;
                        dgByName.DataSource = dv;
                        dgByName.PageIndex = 0;
                        dgByName.DataBind();
                    }
                    #endregion

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
        protected void btn_Cancel_Click(object sender, EventArgs e)
        {
            SearchVisibility("99");
        }
        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            #region ***
            try
            {
                CreateXMLAndRedirect();

            }
            catch (Exception ex)
            {
                lblSearchError.Text = ex.Message;
                lblSearchError.Visible = true;
            }
            #endregion
        }
        protected void dgByName_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            #region select record
            if (e.CommandName == "Select")
            {
                // get the FORMNO of the clicked row           
                FORMNO.Value = e.CommandArgument.ToString();
                SEARCH("1", FORMNO.Value, string.Empty, string.Empty);
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
                    requestXmlStr.Append("Update Profile");
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
                    if (SM.Value == Common.GetValue("UpdateProfileEntry"))
                        requestXmlStr.Append("<partdone>9</partdone>");
                    else
                        requestXmlStr.Append("<partdone>1</partdone>");


                    #region ENROL PROFILE
                    requestXmlStr.Append("<ENROLPROFILE>");
                    requestXmlStr.Append("<PRIORITY>");
                    requestXmlStr.Append(responseData.Priority.ToString());
                    requestXmlStr.Append("</PRIORITY>");

                    #region DOCTYPE
                    requestXmlStr.Append("<DOCTYPETXT>");
                    requestXmlStr.Append(responseData.DocType);
                    requestXmlStr.Append("</DOCTYPETXT>");
                    requestXmlStr.Append("<DOCTYPE>");
                    if (responseData.DocType != string.Empty)
                    {
                        string[] DT = responseData.DocType.ToString().Split(new char[] { '-' });
                        requestXmlStr.Append(DT[0].ToString().Trim());
                    }
                    requestXmlStr.Append("</DOCTYPE>");
                    #endregion

                    #region ENTRYTYPE
                    requestXmlStr.Append("<SUBDOCTYPE2>");
                    requestXmlStr.Append(responseData.EntryType);
                    requestXmlStr.Append("</SUBDOCTYPE2>");
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
                    requestXmlStr.Append("<STAGECODE>");
                    requestXmlStr.Append(responseData.StageCode.Substring(0, 6));
                    requestXmlStr.Append("</STAGECODE>");
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
                    requestXmlStr.Append("<NATIONALITY2>");
                    requestXmlStr.Append(responseData.Nationality);
                    requestXmlStr.Append("</NATIONALITY2>");
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
                    requestXmlStr.Append("<BIRTHCOUNTRY2>");
                    requestXmlStr.Append(responseData.BirthCountry);
                    requestXmlStr.Append("</BIRTHCOUNTRY2>");
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

                    #region Proceed only if this is update profile data entry                

                    #region FACEIMAGE
                    requestXmlStr.Append("<SCANNED>");
                    if (responseData.FaceImage != null)
                    {
                        requestXmlStr.Append("<FACEIMAGE>");
                        requestXmlStr.Append(System.Convert.ToBase64String(responseData.FaceImage));
                        requestXmlStr.Append("</FACEIMAGE>");
                        requestXmlStr.Append("<FACEIMAGEJ2K>");
                        requestXmlStr.Append(System.Convert.ToBase64String(responseData.FaceImageJ2K));
                        requestXmlStr.Append("</FACEIMAGEJ2K>");
                    }
                    requestXmlStr.Append("</SCANNED>");
                    #endregion

                    if (SM.Value == Common.GetValue("UpdateProfileEntry"))
                    {

                        #region EMPLOYMENT
                        requestXmlStr.Append("<EMPLOYMENT>");
                        requestXmlStr.Append("<EMPLOYERADDRESS>");
                        requestXmlStr.Append(responseData.EmployerAddress);
                        requestXmlStr.Append("</EMPLOYERADDRESS>");
                        requestXmlStr.Append("<EMPLOYERNAME>");
                        requestXmlStr.Append(responseData.EmployerName);
                        requestXmlStr.Append("</EMPLOYERNAME>");
                        requestXmlStr.Append("<EMPLOYERPHONE>");
                        requestXmlStr.Append(responseData.EmployerPhone);
                        requestXmlStr.Append("</EMPLOYERPHONE>");
                        requestXmlStr.Append("<OCCUPATION>");
                        requestXmlStr.Append(responseData.Occupation);
                        requestXmlStr.Append("</OCCUPATION>");
                        requestXmlStr.Append("<YEARSEMPLOYED>");
                        requestXmlStr.Append(responseData.YearsEmployed);
                        requestXmlStr.Append("</YEARSEMPLOYED>");

                        requestXmlStr.Append("<FORMEREMPLOYERADDRESS>");
                        requestXmlStr.Append(responseData.FormerEmployerAddress);
                        requestXmlStr.Append("</FORMEREMPLOYERADDRESS>");
                        requestXmlStr.Append("<FORMEREMPLOYERNAME>");
                        requestXmlStr.Append(responseData.FormerEmployerName);
                        requestXmlStr.Append("</FORMEREMPLOYERNAME>");
                        requestXmlStr.Append("<FORMEREMPLOYERPHONE>");
                        requestXmlStr.Append(responseData.FormerEmployerPhone);
                        requestXmlStr.Append("</FORMEREMPLOYERPHONE>");
                        requestXmlStr.Append("<FORMEROCCUPATION>");
                        requestXmlStr.Append(responseData.FormerOccupation);
                        requestXmlStr.Append("</FORMEROCCUPATION>");
                        requestXmlStr.Append("<FORMERYEARSEMPLOYED>");
                        requestXmlStr.Append(responseData.FormerYearsEmployed);
                        requestXmlStr.Append("</FORMERYEARSEMPLOYED>");



                        requestXmlStr.Append("</EMPLOYMENT>");
                        #endregion

                        #region CONTACT
                        requestXmlStr.Append("<CONTACT>");
                        requestXmlStr.Append("<PRESENTADDRESS>");
                        requestXmlStr.Append(responseData.PresentAddress);
                        requestXmlStr.Append("</PRESENTADDRESS>");
                        requestXmlStr.Append("<PERMANENTADDRESS>");
                        requestXmlStr.Append(responseData.PermanentAddress);
                        requestXmlStr.Append("</PERMANENTADDRESS>");
                        requestXmlStr.Append("<MOBILE>");
                        requestXmlStr.Append(responseData.Mobile);
                        requestXmlStr.Append("</MOBILE>");
                        requestXmlStr.Append("<FAX>");
                        requestXmlStr.Append(responseData.Fax);
                        requestXmlStr.Append("</FAX>");
                        requestXmlStr.Append("<PHONEWORK>");
                        requestXmlStr.Append(responseData.PhoneWork);
                        requestXmlStr.Append("</PHONEWORK>");
                        requestXmlStr.Append("<PHONEHOME>");
                        requestXmlStr.Append(responseData.PhoneHome);
                        requestXmlStr.Append("</PHONEHOME>");
                        requestXmlStr.Append("<EMAIL>");
                        requestXmlStr.Append(responseData.Email);
                        requestXmlStr.Append("</EMAIL>");
                        requestXmlStr.Append("<EGCONTACTADDRESS>");
                        requestXmlStr.Append(responseData.EGContactAddress);
                        requestXmlStr.Append("</EGCONTACTADDRESS>");
                        requestXmlStr.Append("<EGCONTACTNAME>");
                        requestXmlStr.Append(responseData.EGContactName);
                        requestXmlStr.Append("</EGCONTACTNAME>");
                        requestXmlStr.Append("<EGCONTACTPHONE>");
                        requestXmlStr.Append(responseData.EGContactPhone);
                        requestXmlStr.Append("</EGCONTACTPHONE>");
                        requestXmlStr.Append("<EGCONTACTRELATIONSHIP>");
                        requestXmlStr.Append(responseData.EGContactRelationship);
                        requestXmlStr.Append("</EGCONTACTRELATIONSHIP>");
                        requestXmlStr.Append("</CONTACT>");
                        #endregion

                        #region TRAVEL
                        requestXmlStr.Append("<TRAVEL>");
                        requestXmlStr.Append("<VISITPURPOSE>");
                        if (responseData.VisitPurpose != string.Empty)
                        {
                            string[] VP = responseData.VisitPurpose.ToString().Split(new char[] { '-' });
                            requestXmlStr.Append(VP[0].ToString().Trim());
                        }
                        requestXmlStr.Append("</VISITPURPOSE>");
                        requestXmlStr.Append("<OTHERVISITPURPOSE>");
                        requestXmlStr.Append(responseData.OtherVisitPurpose);
                        requestXmlStr.Append("</OTHERVISITPURPOSE>");
                        requestXmlStr.Append("<LENGTHOFSTAY>");
                        requestXmlStr.Append(responseData.LengthOfStay);
                        requestXmlStr.Append("</LENGTHOFSTAY>");
                        requestXmlStr.Append("<ARRIVALDATE>");
                        if (responseData.ArrivalDate != null) requestXmlStr.Append(Convert.ToDateTime(responseData.ArrivalDate).ToString("ddMMyyy"));
                        requestXmlStr.Append("</ARRIVALDATE>");
                        requestXmlStr.Append("<HOTELNAME>");
                        requestXmlStr.Append(responseData.HotelName);
                        requestXmlStr.Append("</HOTELNAME>");
                        requestXmlStr.Append("<HOTELADDRESS>");
                        requestXmlStr.Append(responseData.HotelAddress);
                        requestXmlStr.Append("</HOTELADDRESS>");
                        requestXmlStr.Append("<HOTELPHONE>");
                        requestXmlStr.Append(responseData.HotelPhone);
                        requestXmlStr.Append("</HOTELPHONE>");
                        requestXmlStr.Append("</TRAVEL>");
                        #endregion

                        #region FAMILY
                        requestXmlStr.Append("<FAMILY>");
                        requestXmlStr.Append("<MARITALSTATUS>");
                        if (responseData.MaritalStatus != string.Empty)
                        {
                            string[] M = responseData.MaritalStatus.ToString().Split(new char[] { '-' });
                            requestXmlStr.Append(M[0].ToString().Trim());
                        }
                        requestXmlStr.Append("</MARITALSTATUS>");
                        requestXmlStr.Append("<SPOUSEDOB>");
                        if (responseData.SpouseDOB != null) requestXmlStr.Append(Convert.ToDateTime(responseData.SpouseDOB).ToString("ddMMyyyy"));
                        requestXmlStr.Append("</SPOUSEDOB>");
                        requestXmlStr.Append("<SPOUSEFIRSTNAME>");
                        requestXmlStr.Append(responseData.SpouseFirstName);
                        requestXmlStr.Append("</SPOUSEFIRSTNAME>");
                        requestXmlStr.Append("<SPOUSELASTNAME>");
                        requestXmlStr.Append(responseData.SpouseLastName);
                        requestXmlStr.Append("</SPOUSELASTNAME>");
                        requestXmlStr.Append("<SPOUSEMAIDENNAME>");
                        requestXmlStr.Append(responseData.SpouseMaidenName);
                        requestXmlStr.Append("</SPOUSEMAIDENNAME>");
                        requestXmlStr.Append("<SPOUSEMIDDLENAME>");
                        requestXmlStr.Append(responseData.SpouseMiddleName);
                        requestXmlStr.Append("</SPOUSEMIDDLENAME>");
                        requestXmlStr.Append("<HASCHILDIND>");
                        requestXmlStr.Append(responseData.HasChildInd);
                        requestXmlStr.Append("</HASCHILDIND>");

                        requestXmlStr.Append("<DEPENDANTNAME1>");
                        requestXmlStr.Append(responseData.DependantName1);
                        requestXmlStr.Append("</DEPENDANTNAME1>");
                        requestXmlStr.Append("<DEPENDANTNAME2>");
                        requestXmlStr.Append(responseData.DependantName2);
                        requestXmlStr.Append("</DEPENDANTNAME2>");
                        requestXmlStr.Append("<DEPENDANTNAME3>");
                        requestXmlStr.Append(responseData.DependantName3);
                        requestXmlStr.Append("</DEPENDANTNAME3>");
                        requestXmlStr.Append("<DEPENDANTNAME4>");
                        requestXmlStr.Append(responseData.DependantName4);
                        requestXmlStr.Append("</DEPENDANTNAME4>");
                        requestXmlStr.Append("<DEPENDANTNAME5>");
                        requestXmlStr.Append(responseData.DependantName5);
                        requestXmlStr.Append("</DEPENDANTNAME5>");

                        requestXmlStr.Append("<RELATIONSHIP1>");
                        requestXmlStr.Append(responseData.Relationship1);
                        requestXmlStr.Append("</RELATIONSHIP1>");
                        requestXmlStr.Append("<RELATIONSHIP2>");
                        requestXmlStr.Append(responseData.Relationship2);
                        requestXmlStr.Append("</RELATIONSHIP2>");
                        requestXmlStr.Append("<RELATIONSHIP3>");
                        requestXmlStr.Append(responseData.Relationship3);
                        requestXmlStr.Append("</RELATIONSHIP3>");
                        requestXmlStr.Append("<RELATIONSHIP4>");
                        requestXmlStr.Append(responseData.Relationship4);
                        requestXmlStr.Append("</RELATIONSHIP4>");
                        requestXmlStr.Append("<RELATIONSHIP5>");
                        requestXmlStr.Append(responseData.Relationship5);
                        requestXmlStr.Append("</RELATIONSHIP5>");

                        requestXmlStr.Append("<TRAVELWITHSPOUSEIND>");
                        requestXmlStr.Append(responseData.TravelWithSpouseInd);
                        requestXmlStr.Append("</TRAVELWITHSPOUSEIND>");
                        requestXmlStr.Append("<TRAVELWITHDEPENDANTIND>");
                        requestXmlStr.Append(responseData.TravelWithDependantInd);
                        requestXmlStr.Append("</TRAVELWITHDEPENDANTIND>");
                        requestXmlStr.Append("<FATHERFIRSTNAME>");
                        requestXmlStr.Append(responseData.FatherFirstName);
                        requestXmlStr.Append("</FATHERFIRSTNAME>");
                        requestXmlStr.Append("<FATHERLASTNAME>");
                        requestXmlStr.Append(responseData.FatherLastName);
                        requestXmlStr.Append("</FATHERLASTNAME>");
                        requestXmlStr.Append("<FATHERMIDDLENAME>");
                        requestXmlStr.Append(responseData.FatherMiddleName);
                        requestXmlStr.Append("</FATHERMIDDLENAME>");
                        requestXmlStr.Append("<FATHERNATIONALITY>");
                        if (responseData.FatherNationality != string.Empty) requestXmlStr.Append(responseData.FatherNationality.Substring(0, 3));
                        requestXmlStr.Append("</FATHERNATIONALITY>");
                        requestXmlStr.Append("<MOTHERFIRSTNAME>");
                        requestXmlStr.Append(responseData.MotherFirstName);
                        requestXmlStr.Append("</MOTHERFIRSTNAME>");
                        requestXmlStr.Append("<MOTHERLASTNAME>");
                        requestXmlStr.Append(responseData.MotherLastName);
                        requestXmlStr.Append("</MOTHERLASTNAME>");
                        requestXmlStr.Append("<MOTHERMIDDLENAME>");
                        requestXmlStr.Append(responseData.MotherMiddleName);
                        requestXmlStr.Append("</MOTHERMIDDLENAME>");
                        requestXmlStr.Append("<MOTHERNATIONALITY>");
                        if (responseData.MotherNationality != string.Empty) requestXmlStr.Append(responseData.MotherNationality.Substring(0, 3));
                        requestXmlStr.Append("</MOTHERNATIONALITY>");
                        requestXmlStr.Append("</FAMILY>");
                        #endregion

                        #region FINANCIAL DETAILS
                        requestXmlStr.Append("<ADDITIONAL>");

                        requestXmlStr.Append("<TRIPMONEY>");
                        requestXmlStr.Append(responseData.TripMoney);
                        requestXmlStr.Append("</TRIPMONEY>");
                        requestXmlStr.Append("<TRIPSPONSORBY>");
                        requestXmlStr.Append(responseData.TripSponsorBy);
                        requestXmlStr.Append("</TRIPSPONSORBY>");
                        #endregion

                        #region CRIMINAL DETAILS
                        requestXmlStr.Append("<CRIMINALCONVICTIONIND>");
                        requestXmlStr.Append(responseData.CriminalConvictionInd);
                        requestXmlStr.Append("</CRIMINALCONVICTIONIND>");

                        requestXmlStr.Append("<OFFENCE1>");
                        requestXmlStr.Append(responseData.Offence1);
                        requestXmlStr.Append("</OFFENCE1>");
                        requestXmlStr.Append("<OFFENCE2>");
                        requestXmlStr.Append(responseData.Offence2);
                        requestXmlStr.Append("</OFFENCE2>");
                        requestXmlStr.Append("<OFFENCE3>");
                        requestXmlStr.Append(responseData.Offence3);
                        requestXmlStr.Append("</OFFENCE3>");
                        requestXmlStr.Append("<OFFENCE4>");
                        requestXmlStr.Append(responseData.Offence4);
                        requestXmlStr.Append("</OFFENCE4>");
                        requestXmlStr.Append("<OFFENCE5>");
                        requestXmlStr.Append(responseData.Offence5);
                        requestXmlStr.Append("</OFFENCE5>");

                        requestXmlStr.Append("<OFFENCEDATE1>");
                        if (responseData.OffenceDate1 != null) requestXmlStr.Append(responseData.OffenceDate1);
                        requestXmlStr.Append("</OFFENCEDATE1>");
                        requestXmlStr.Append("<OFFENCEDATE2>");
                        if (responseData.OffenceDate2 != null) requestXmlStr.Append(responseData.OffenceDate2);
                        requestXmlStr.Append("</OFFENCEDATE2>");
                        requestXmlStr.Append("<OFFENCEDATE3>");
                        if (responseData.OffenceDate3 != null) requestXmlStr.Append(responseData.OffenceDate3);
                        requestXmlStr.Append("</OFFENCEDATE3>");
                        requestXmlStr.Append("<OFFENCEDATE4>");
                        if (responseData.OffenceDate4 != null) requestXmlStr.Append(responseData.OffenceDate4);
                        requestXmlStr.Append("</OFFENCEDATE4>");
                        requestXmlStr.Append("<OFFENCEDATE5>");
                        if (responseData.OffenceDate5 != null) requestXmlStr.Append(responseData.OffenceDate5);
                        requestXmlStr.Append("</OFFENCEDATE5>");

                        requestXmlStr.Append("<OFFENCEPENALTY1>");
                        requestXmlStr.Append(responseData.OffencePenalty1);
                        requestXmlStr.Append("</OFFENCEPENALTY1>");
                        requestXmlStr.Append("<OFFENCEPENALTY2>");
                        requestXmlStr.Append(responseData.OffencePenalty2);
                        requestXmlStr.Append("</OFFENCEPENALTY2>");
                        requestXmlStr.Append("<OFFENCEPENALTY3>");
                        requestXmlStr.Append(responseData.OffencePenalty3);
                        requestXmlStr.Append("</OFFENCEPENALTY3>");
                        requestXmlStr.Append("<OFFENCEPENALTY4>");
                        requestXmlStr.Append(responseData.OffencePenalty4);
                        requestXmlStr.Append("</OFFENCEPENALTY4>");
                        requestXmlStr.Append("<OFFENCEPENALTY5>");
                        requestXmlStr.Append(responseData.OffencePenalty5);
                        requestXmlStr.Append("</OFFENCEPENALTY5>");

                        requestXmlStr.Append("<OFFENCEPLACE1>");
                        requestXmlStr.Append(responseData.OffencePlace1);
                        requestXmlStr.Append("</OFFENCEPLACE1>");
                        requestXmlStr.Append("<OFFENCEPLACE2>");
                        requestXmlStr.Append(responseData.OffencePlace2);
                        requestXmlStr.Append("</OFFENCEPLACE2>");
                        requestXmlStr.Append("<OFFENCEPLACE3>");
                        requestXmlStr.Append(responseData.OffencePlace3);
                        requestXmlStr.Append("</OFFENCEPLACE3>");
                        requestXmlStr.Append("<OFFENCEPLACE4>");
                        requestXmlStr.Append(responseData.OffencePlace4);
                        requestXmlStr.Append("</OFFENCEPLACE4>");
                        requestXmlStr.Append("<OFFENCEPLACE5>");
                        requestXmlStr.Append(responseData.OffencePlace5);
                        requestXmlStr.Append("</OFFENCEPLACE5>");

                        requestXmlStr.Append("<TERRORISMIND>");
                        requestXmlStr.Append(responseData.TerrorismInd);
                        requestXmlStr.Append("</TERRORISMIND>");
                        requestXmlStr.Append("<TERRORISMDESC>");
                        requestXmlStr.Append(responseData.TerrorismDesc);
                        requestXmlStr.Append("</TERRORISMDESC>");

                        #endregion

                        #region ADDITIONAL DETAILS
                        requestXmlStr.Append("<FATHERRESIDENTIALSTATUS>");
                        if (responseData.FatherResidentialStatus != string.Empty)
                        {
                            string[] F = responseData.FatherResidentialStatus.ToString().Split(new char[] { '-' });
                            requestXmlStr.Append(F[0].ToString().Trim());
                        }
                        requestXmlStr.Append("</FATHERRESIDENTIALSTATUS>");
                        requestXmlStr.Append("<MOTHERRESIDENTIALSTATUS>");
                        if (responseData.MotherResidentialStatus != string.Empty)
                        {
                            string[] M = responseData.MotherResidentialStatus.ToString().Split(new char[] { '-' });
                            requestXmlStr.Append(M[0].ToString().Trim());
                        }
                        requestXmlStr.Append("</MOTHERRESIDENTIALSTATUS>");
                        requestXmlStr.Append("<SPOUSERESIDENTIALSTATUS>");
                        if (responseData.SpouseResidentialStatus != string.Empty)
                        {
                            string[] S = responseData.SpouseResidentialStatus.ToString().Split(new char[] { '-' });
                            requestXmlStr.Append(S[0].ToString().Trim());
                        }
                        requestXmlStr.Append("</SPOUSERESIDENTIALSTATUS>");
                        requestXmlStr.Append("<SIBLINGRESIDENTIALSTATUS>");
                        if (responseData.SiblingResidentialStatus != string.Empty)
                        {
                            string[] S = responseData.SiblingResidentialStatus.ToString().Split(new char[] { '-' });
                            requestXmlStr.Append(S[0].ToString().Trim());
                        }
                        requestXmlStr.Append("</SIBLINGRESIDENTIALSTATUS>");
                        requestXmlStr.Append("<CHILDRENRESIDENTIALSTATUS>");
                        if (responseData.ChildrenResidentialStatus != string.Empty)
                        {
                            string[] C = responseData.ChildrenResidentialStatus.ToString().Split(new char[] { '-' });
                            requestXmlStr.Append(C[0].ToString().Trim());
                        }
                        requestXmlStr.Append("</CHILDRENRESIDENTIALSTATUS>");
                        requestXmlStr.Append("<FATHERINBHSIND>");
                        requestXmlStr.Append(responseData.FatherInBHSInd);
                        requestXmlStr.Append("</FATHERINBHSIND>");
                        requestXmlStr.Append("<MOTHERINBHSIND>");
                        requestXmlStr.Append(responseData.MotherInBHSInd);
                        requestXmlStr.Append("</MOTHERINBHSIND>");
                        requestXmlStr.Append("<SPOUSEINBHSIND>");
                        requestXmlStr.Append(responseData.SpouseInBHSInd);
                        requestXmlStr.Append("</SPOUSEINBHSIND>");
                        requestXmlStr.Append("<SIBLINGINBHSIND>");
                        requestXmlStr.Append(responseData.SiblingInBHSInd);
                        requestXmlStr.Append("</SIBLINGINBHSIND>");
                        requestXmlStr.Append("<CHILDRENINBHSIND>");
                        requestXmlStr.Append(responseData.ChildrenInBHSInd);
                        requestXmlStr.Append("</CHILDRENINBHSIND>");
                        requestXmlStr.Append("<VISITEDBHSIND>");
                        requestXmlStr.Append(responseData.VisitedBhsInd);
                        requestXmlStr.Append("</VISITEDBHSIND>");
                        requestXmlStr.Append("<LASTVISITDATE>");
                        if (responseData.LastVisitDate != null) requestXmlStr.Append(Convert.ToDateTime(responseData.LastVisitDate).ToString("ddMMyyyy"));
                        requestXmlStr.Append("</LASTVISITDATE>");
                        requestXmlStr.Append("<APPLIEDVISAIND>");
                        requestXmlStr.Append(responseData.AppliedVisaInd);
                        requestXmlStr.Append("</APPLIEDVISAIND>");
                        requestXmlStr.Append("<APPLIEDVISADATE>");
                        if (responseData.AppliedVisaDate != null) requestXmlStr.Append(Convert.ToDateTime(responseData.AppliedVisaDate).ToString("ddMMyyyy"));
                        requestXmlStr.Append("</APPLIEDVISADATE>");
                        requestXmlStr.Append("<APPLIEDVISAPLACE>");
                        requestXmlStr.Append(responseData.AppliedVisaPlace);
                        requestXmlStr.Append("</APPLIEDVISAPLACE>");
                        requestXmlStr.Append("<VISAOUTCOME>");
                        requestXmlStr.Append(responseData.VisaOutCome);
                        requestXmlStr.Append("</VISAOUTCOME>");
                        requestXmlStr.Append("<DEPORTEDIND>");
                        requestXmlStr.Append(responseData.DeportedInd);
                        requestXmlStr.Append("</DEPORTEDIND>");
                        requestXmlStr.Append("</ADDITIONAL>");
                        #endregion
                    }
                    #endregion

                    requestXmlStr.Append("</ENROLLMENT>");
                    #endregion

                    #endregion

                    requestXmlStr.Append("</PAYLOAD>");
                    #endregion

                    requestXmlStr.Append("</VISWEBREQUEST>");
                    #endregion

                    #region Save the temporary file at server side
                    string fileName = @Server.MapPath("") + Common.GetValue("xmlServerPath") + FORMNO.Value + SM.Value + ".xml";

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

        private void getCountryList()
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
                reqData.PermissionCode = Common.GETCOUNTRY;
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
                        BIRTHCOUNTRYDD.Items.Add(li);
                    }
                    BIRTHCOUNTRYDD.Items.Insert(0, new ListItem("-SELECT-", ""));

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
            }
            #endregion
        }
        private void CreateXMLAndRedirect()
        {
            #region ***

            CreateXmlFile();
            Response.Redirect("ApplicationPart1.aspx?sm=" + SM.Value + "&done=" + FORMNO.Value + SM.Value + "&arrow=" + Request.QueryString["arrow"] + "&PC=" + txtCompName.Value);

            #endregion
        }

    }
}
