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
    public partial class ApplicationPart1 : System.Web.UI.Page
    {
        const int pageId = 1;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.BIRTHDATE.Text = Request[this.BIRTHDATE.UniqueID];
            this.PASSPORTDOI.Text = Request[this.PASSPORTDOI.UniqueID];
            this.PASSPORTDOE.Text = Request[this.PASSPORTDOE.UniqueID];
            this.txtColDate.Text = Request[this.txtColDate.UniqueID];
            this.DOB.Text = Request[this.DOB.UniqueID];

            #region ***
            if (!Page.IsPostBack)
            {
                #region lookup list
                GetDocType();
                GetEntryType();
                GetAppReason();
                #endregion

                #region get Country & Nationality
                if (Request.QueryString["PC"] != null)
                {
                    txtCompName.Value = Request.QueryString["PC"];
                    getCountryList();
                    getNationality();
                }
                #endregion

                #region Initialize DD
                DDDefaultValue();
                #endregion

                trans.Value = Request.QueryString["sm"];
                if (Request.QueryString["done"] != null)
                {
                    string done = Request.QueryString["done"];
                    IsNew.Value = @Server.MapPath("") + Common.GetValue("xmlServerPath") + done + ".xml";
                    LoadXMLFile(IsNew.Value);
                }
                else
                {

                    CheckAppReason(trans.Value);
                    #region Show Photo if it is external application
                    if (trans.Value == Common.GetValue("ExternalDEStage"))
                    {
                        tbPhoto.Visible = true;
                        trPhoto1.Visible = true;
                        trPhoto2.Visible = true;
                        trPhoto3.Visible = true;
                        lblPhoto.Visible = true;
                        lblAstPhoto.Visible = true;
                        trColDate.Visible = false;
                    }
                    #endregion
                }
            }
            #endregion
        }

        private void DDDefaultValue()
        {
            #region ***       
            TITLE.Items.Insert(0, new ListItem("-SELECT-", ""));
            rbSearch.Items.Insert(0, new ListItem("-SELECT-", ""));
            APPREASONEXTERNAL.Items.Insert(0, new ListItem("-SELECT-", ""));

            #endregion
        }
        private void GetDocType()
        {
            #region ***
            try
            {

                #region calling web service
                DALMService look = new DALMService();
                RequestDataTypeSelectDocType reqData = new RequestDataTypeSelectDocType();

                reqData.ActionDescription = "Get DocType";
                reqData.PermissionCode = Common.DOCTYPECODE;
                reqData.SessionKey = Common.GetCookie(this.Page, "sessionKey");


                #endregion

                #region response the request
                ResponseDataTypeSelectDocType responseData = look.SelectDocTypeList(reqData);

                string statusCode = responseData.StatusCode;
                string statusMsg = responseData.StatusMessage;
                #endregion

                #region bind data in dd
                if (statusCode == "0")
                {
                    ViewState["data"] = responseData.ResultList;
                    DataSet Ds = (DataSet)ViewState["data"];
                    DOCTYPE.DataSource = Ds.Tables[0];
                    DOCTYPE.DataValueField = "DocType";
                    DOCTYPE.DataTextField = "Description";
                    DOCTYPE.DataBind();
                    DOCTYPE.Items.Insert(0, new ListItem("-SELECT-", ""));

                }
                else
                {
                    lblError.Visible = true;
                    lblError.Text = statusMsg;
                }
                #endregion
            }
            catch (Exception ex)
            {
                lblError.Visible = true;
                lblError.Text = ex.Message;
            }
            #endregion

        }
        private void GetAppReason()
        {
            #region ***
            try
            {

                #region calling web service
                DALMService look = new DALMService();
                RequestDataTypeSelectAppReason reqData = new RequestDataTypeSelectAppReason();

                reqData.ActionDescription = "Get AppReason";
                reqData.PermissionCode = Common.GetValue("SelectAppReason");
                reqData.SessionKey = Common.GetCookie(this.Page, "sessionKey");


                #endregion

                #region response the request
                ResponseDataTypeSelectAppReason responseData = look.SelectAppReasonList(reqData);

                string statusCode = responseData.StatusCode;
                string statusMsg = responseData.StatusMessage;
                #endregion

                #region bind data in dd
                if (statusCode == "0")
                {
                    ViewState["data"] = responseData.ResultList;
                    DataSet Ds = (DataSet)ViewState["data"];
                    APPREASON.DataSource = Ds.Tables[0];
                    APPREASON.DataValueField = "AppReason";
                    APPREASON.DataTextField = "Description";
                    APPREASON.DataBind();
                    APPREASON.Items.Insert(0, new ListItem("-SELECT-", ""));

                }
                else
                {
                    lblError.Visible = true;
                    lblError.Text = statusMsg;
                }
                #endregion
            }
            catch (Exception ex)
            {
                lblError.Visible = true;
                lblError.Text = ex.Message;
            }
            #endregion

        }
        private void GetEntryType()
        {
            #region ***
            try
            {
                #region calling web service
                DALMService look = new DALMService();
                RequestDataTypeSelectEntryType reqData = new RequestDataTypeSelectEntryType();

                reqData.ActionDescription = "Get EntryType";
                reqData.PermissionCode = Common.GetValue("SelectEntryType");
                reqData.SessionKey = Common.GetCookie(this.Page, "sessionKey");

                #endregion

                #region response the request
                ResponseDataTypeSelectEntryType responseData = look.SelectLookupEntryTypeList(reqData);

                string statusCode = responseData.StatusCode;
                string statusMsg = responseData.StatusMessage;
                #endregion

                #region bind data in dd
                if (statusCode == "0")
                {
                    DataSet Ds = (DataSet)responseData.ResultList;
                    SUBDOCTYPE.DataSource = Ds.Tables[0];
                    SUBDOCTYPE.DataValueField = "EntryType";
                    SUBDOCTYPE.DataTextField = "Description";
                    SUBDOCTYPE.DataBind();
                    SUBDOCTYPE.Items.Insert(0, new ListItem("-SELECT-", ""));
                }
                else
                {
                    lblError.Visible = true;
                    lblError.Text = statusMsg;
                }
                #endregion
            }
            catch (Exception ex)
            {
                lblError.Visible = true;
                lblError.Text = ex.Message;
            }
            #endregion

        }
        private void CheckAppReason(string reason)
        {
            #region ***

            switch (reason)
            {
                case "1":
                    SetTableVisibility(false, false, false, false, true);
                    APPREASONEXTERNAL.Visible = false;
                    APPREASON.Visible = true;
                    APPREASON.SelectedValue = trans.Value;
                    RFVAppExternal.Visible = false;
                    rbSearch.Items.Insert(2, new ListItem("NAME & DATE OF BIRTH", "5"));
                    break;
                case "4":
                    SetTableVisibility(false, false, false, false, true);
                    APPREASONEXTERNAL.Visible = true;
                    RFVAppExternal.Visible = true;
                    APPREASON.Visible = false;
                    rbSearch.Items.Insert(2, new ListItem("NAME & DATE OF BIRTH", "5"));
                    rbSearch.Items.Remove(rbSearch.Items[3]);
                    break;
                case "2":
                    SetTableVisibility(false, false, false, false, true);
                    rbMode.Enabled = false;
                    rbMode.SelectedValue = "2";
                    trNewAppID.Visible = false;
                    trSearch.Visible = true;
                    fly.Text = "Visa Renewal - Personal Information";
                    APPREASON.SelectedValue = trans.Value;
                    rbSearch.Items.Insert(2, new ListItem("NAME, DATE OF BIRTH & COUNTRY OF BIRTH", "5"));
                    DisableControl(false);
                    DOCTYPE.Enabled = true;
                    break;
                default:
                    Response.Redirect("Logon.aspx");
                    break;
            }


            #endregion
        }
        private void SetTableVisibility(bool tablePInfo, bool tablePassport, bool tableButton, bool tableWP, bool tableFormNo)
        {
            #region ***
            tbPInfo.Visible = tablePInfo;
            tbPassport.Visible = tablePassport;
            tbButton.Visible = tableButton;
            tbVisaInfo.Visible = tableWP;
            //tbOldDocNo.Visible = tableOldDoc;
            tbFormNo.Visible = tableFormNo;

            #endregion
        }
        private void CheckPagePurpose()
        {
            #region ***

            if (purpose.Value != "0")
            {
                tbVisaInfo.Visible = true;
                tbFormNo.Visible = true;
                tbPInfo.Visible = true;
                tbPassport.Visible = true;
                tbButton.Visible = true;
                trMode.Visible = false;
                lblHeadTitle.Text = "Application ID";

            }
            #endregion

            #region check enrollment type       

            if (trans.Value == Common.COMPLETEENROLECODE || trans.Value == Common.UPDATEPROFILECODE || trans.Value == Common.GetValue("ExternalDEStage"))
            {

                DOCTYPE.Enabled = false;
                SUBDOCTYPE.Enabled = false;
                trColDate.Visible = false;
                tbPhoto.Visible = true;
                trPhoto1.Visible = true;
                trPhoto2.Visible = true;
                trPhoto3.Visible = true;
                lblPhoto.Visible = true;
                lblAstPhoto.Visible = true;
                btnRead.Visible = false;

            }
            else if (trans.Value == Common.UPDATEPROFILEENROLCODE && (STAGECODE.Text == "EM1000" || STAGECODE.Text == "EM2001"))
            {
                DOCTYPE.Enabled = true;
                SUBDOCTYPE.Enabled = true;
                trColDate.Visible = false;
                btnRead.Visible = false;

            }
            else if (trans.Value == Common.UPDATEPROFILEENROLCODE && (STAGECODE.Text != "EM1000") && (STAGECODE.Text != "EM2001"))
            {
                DOCTYPE.Enabled = false;
                SUBDOCTYPE.Enabled = false;
                trColDate.Visible = false;
                btnRead.Visible = false;
            }
            else
            {
                DOCTYPE.Enabled = true;
            }
            #endregion
        }
        protected void btnGenFormNo_Click(object sender, EventArgs e)
        {
            GetApplicationID();

        }
        private void GetApplicationID()
        {
            #region get application ID
            try
            {
                EMService en = new EMService();
                RequestDataTypeGetApplicationID reqData = new RequestDataTypeGetApplicationID();
                reqData.PermissionCode = Common.GETAPPLICATIONID;
                reqData.SessionKey = Common.GetCookie(this.Page, "sessionKey");
                reqData.ActionDescription = "Get Enrollment ID";


                ResponseDataTypeGetApplicationID getData = en.GetApplicationID(reqData);
                FORMNO.Text = getData.NewApplicationID;
                string statuscode = getData.StatusCode;
                string statusmsg = getData.StatusMessage;

                if (statuscode == "0")
                {
                    btnGenFormNo.Visible = false;
                    lblFormNoError.Visible = false;
                    rbMode.Enabled = false;
                    #region get country                
                    if (NATIONALITY.Items.Count < 1) getNationality();
                    if (BIRTHCOUNTRY.Items.Count < 1) getCountryList();
                    #endregion
                    if (trans.Value == "1" || trans.Value == "4")
                        SetTableVisibility(true, true, true, true, true);

                    txtColDate.Text = System.DateTime.Now.AddDays(2).Date.ToString("dd/MM/yyyy");

                    trValSummaryTop.Visible = false;
                }
                else
                {
                    trErrorMsg.Visible = true;
                    btnGenFormNo.Visible = true;
                    Common.WriteLog(@Server.MapPath("") + Common.GetValue("logPath"), statusmsg);
                    lblFormNoError.Text = "Failed to generate new enrollment ID";
                    trValSummaryTop.Visible = true;

                }

            }

            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
            //SetTableVisibility(true, true, true);

            #endregion 
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            #region ***
            try
            {
                if (IsNew.Value == string.Empty)//Partial enroll stage
                {
                    CreateNewXmlFile();
                }
                UpdataExistingXmlFile(IsNew.Value);
                #region Submit Partial/Update Profile
                if (trans.Value == "1" || trans.Value == "2")
                {
                    bool result = SubmitPartial(IsNew.Value, APPREASON.SelectedValue);
                    if (result)
                    {
                        Response.Redirect("CollectionSummary.aspx?arrow=" + Request.QueryString["arrow"] + "&sm=" + Request.QueryString["sm"] + "&done=" + FORMNO.Text + Request.QueryString["sm"] + "&PC=" + txtCompName.Value.Trim());
                    }
                }
                else if (trans.Value == "4" && Request.QueryString["done"] == null)//Partial Enrol External App
                {
                    bool result = SubmitPartial(IsNew.Value, APPREASONEXTERNAL.SelectedValue);
                    if (result)
                        Response.Redirect(Common.RedirectToPage(pageId + 2, Request.QueryString["sm"]) + "&arrow=" + Request.QueryString["arrow"] + "&done=" + FORMNO.Text + Request.QueryString["sm"] + "&PC=" + txtCompName.Value.Trim());
                }
                else if (trans.Value == Common.GetValue("UpdateProfileEnroll"))
                    UpdateProfile();
                else
                    Response.Redirect(Common.RedirectToPage(pageId + 2, Request.QueryString["sm"]) + "&arrow=" + Request.QueryString["arrow"] + "&done=" + FORMNO.Text + Request.QueryString["sm"] + "&PC=" + txtCompName.Value.Trim());

                #endregion

            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                lblError.Visible = true;

            }
            #endregion
        }
        private void CreateNewXmlFile()
        {
            #region ***

            #region Construct xml string
            StringBuilder requestXmlStr = new StringBuilder();

            #region VISWEBREQUEST XML
            //VISWEBREQUEST
            requestXmlStr.Append("<?xml version='1.0' encoding='utf-8' ?>");
            requestXmlStr.Append("<VISWEBREQUEST>");
            requestXmlStr.Append("<PERMISSIONCODE>");
            requestXmlStr.Append(Common.PARTIALENROL);
            requestXmlStr.Append("</PERMISSIONCODE>");
            requestXmlStr.Append("<ACTIONDESCRIPTION>");
            requestXmlStr.Append("Partial Enrol");
            requestXmlStr.Append("</ACTIONDESCRIPTION>");
            //Transaction time
            requestXmlStr.Append("<TRANSACTIONDATETIME></TRANSACTIONDATETIME>");
            #region PAYLOAD
            //PAYLOAD
            requestXmlStr.Append("<PAYLOAD>");

            #region ENROLLMENT
            requestXmlStr.Append("<ENROLLMENT>");
            requestXmlStr.Append("<partdone>0</partdone>");
            requestXmlStr.Append("<ENROLPROFILE>");
            requestXmlStr.Append("<PAYMENTSKIPPED>0</PAYMENTSKIPPED>");
            requestXmlStr.Append("<PRIORITY>");
            requestXmlStr.Append(Common.PRIORITY);
            requestXmlStr.Append("</PRIORITY>");
            requestXmlStr.Append("<APPREASON>");
            if (trans.Value == Common.GetValue("EXTERNAL"))
                requestXmlStr.Append(APPREASONEXTERNAL.SelectedValue);
            else
                requestXmlStr.Append(APPREASON.SelectedValue);
            requestXmlStr.Append("</APPREASON>");
            requestXmlStr.Append("</ENROLPROFILE>");
            requestXmlStr.Append("<MAIN>");
            requestXmlStr.Append("</MAIN>");
            requestXmlStr.Append("<EMPLOYMENT></EMPLOYMENT>");
            requestXmlStr.Append("<CONTACT></CONTACT>");
            requestXmlStr.Append("<TRAVEL></TRAVEL>");
            requestXmlStr.Append("<FAMILY></FAMILY>");
            requestXmlStr.Append("<ADDITIONAL></ADDITIONAL>");
            requestXmlStr.Append("<BIO></BIO>");
            requestXmlStr.Append("<SCANNED></SCANNED>");
            requestXmlStr.Append("</ENROLLMENT>");
            #endregion

            requestXmlStr.Append("</PAYLOAD>");
            #endregion

            requestXmlStr.Append("</VISWEBREQUEST>");
            #endregion

            #endregion

            #region Save the temporary file at server side
            string fileName = @Server.MapPath("") + Common.GetValue("xmlServerPath") + FORMNO.Text + Request.QueryString["sm"] + ".xml";

            //Create xml writter
            XmlTextWriter xmlWriter = new XmlTextWriter(fileName, null);
            //Write the string into xml file
            xmlWriter.WriteRaw(requestXmlStr.ToString());
            xmlWriter.Flush();

            if (xmlWriter != null)
            {
                xmlWriter.Close();
            }

            IsNew.Value = fileName;
            #endregion

            #endregion
        }
        private void UpdataExistingXmlFile(string fileName)
        {
            #region ***
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(fileName);

            XmlNode xmlRoot = xmlDoc.DocumentElement;
            XmlNode enrollment = xmlRoot.SelectSingleNode("PAYLOAD/ENROLLMENT");
            XmlNode enProfile = xmlRoot.SelectSingleNode("PAYLOAD/ENROLLMENT/ENROLPROFILE");
            XmlNode main = xmlRoot.SelectSingleNode("PAYLOAD/ENROLLMENT/MAIN");
            XmlNode scan = xmlRoot.SelectSingleNode("PAYLOAD/ENROLLMENT/SCANNED");

            XmlElement xmlEle = null;

            #region Partdone
            //This section is to indicate that this page has been completed
            string pdone = enrollment.SelectSingleNode("partdone").InnerText;

            if (Convert.ToInt32(enrollment.SelectSingleNode("partdone").InnerText) <= pageId)
            {
                enrollment.SelectSingleNode("partdone").InnerText = pageId.ToString();
            }
            #endregion

            // Enroll Profile Section

            #region FORMNO
            if (enProfile.SelectSingleNode(FORMNO.ID) == null)
            {
                xmlEle = xmlDoc.CreateElement(FORMNO.ID);
                xmlEle.InnerText = FORMNO.Text;
                enProfile.InsertAfter(xmlEle, enProfile.LastChild);
            }
            else
            {
                enProfile.SelectSingleNode(FORMNO.ID).InnerText = FORMNO.Text;
            }
            #endregion

            #region DOCTYPE
            if (enProfile.SelectSingleNode(DOCTYPE.ID) == null)
            {
                xmlEle = xmlDoc.CreateElement(DOCTYPE.ID);
                xmlEle.InnerText = DOCTYPE.SelectedValue.ToUpper();
                enProfile.InsertAfter(xmlEle, enProfile.LastChild);
            }
            else
            {
                enProfile.SelectSingleNode(DOCTYPE.ID).InnerText = DOCTYPE.SelectedValue.ToUpper();
            }
            #endregion

            #region DOCTYPETXT
            if (enProfile.SelectSingleNode("DOCTYPETXT") == null)
            {
                xmlEle = xmlDoc.CreateElement("DOCTYPETXT");
                xmlEle.InnerText = DOCTYPE.SelectedItem.ToString().ToUpper();
                enProfile.InsertAfter(xmlEle, enProfile.LastChild);
            }
            else
            {
                enProfile.SelectSingleNode("DOCTYPETXT").InnerText = DOCTYPE.SelectedItem.ToString().ToUpper();
            }
            #endregion

            #region SUBDOCTYPE
            if (enProfile.SelectSingleNode(SUBDOCTYPE.ID) == null)
            {
                xmlEle = xmlDoc.CreateElement(SUBDOCTYPE.ID);
                xmlEle.InnerText = SUBDOCTYPE.SelectedValue.ToUpper();
                enProfile.InsertAfter(xmlEle, enProfile.LastChild);
            }
            else
            {
                enProfile.SelectSingleNode(SUBDOCTYPE.ID).InnerText = SUBDOCTYPE.SelectedValue.ToUpper();
            }
            #endregion

            #region SUBDOCTYPE TEXT
            if (enProfile.SelectSingleNode("SUBDOCTYPE2") == null)
            {
                xmlEle = xmlDoc.CreateElement("SUBDOCTYPE2");
                xmlEle.InnerText = SUBDOCTYPE.SelectedItem.ToString().ToUpper();
                enProfile.InsertAfter(xmlEle, enProfile.LastChild);
            }
            else
            {
                enProfile.SelectSingleNode("SUBDOCTYPE2").InnerText = SUBDOCTYPE.SelectedItem.ToString().ToUpper();
            }
            #endregion      

            #region APPROVEDDOCTYPE
            if (enProfile.SelectSingleNode("APPROVEDDOCTYPE") == null)
            {
                xmlEle = xmlDoc.CreateElement("APPROVEDDOCTYPE");
                xmlEle.InnerText = APPROVEDDOCTYPE.Text;
                enProfile.InsertAfter(xmlEle, enProfile.LastChild);
            }
            else
            {
                enProfile.SelectSingleNode("APPROVEDDOCTYPE").InnerText = APPROVEDDOCTYPE.Text;
            }
            #endregion

            #region APPROVEDSUBDOCTYPE
            if (enProfile.SelectSingleNode("APPROVEDSUBDOCTYPE") == null)
            {
                xmlEle = xmlDoc.CreateElement("APPROVEDSUBDOCTYPE");
                xmlEle.InnerText = APPROVEDSUBDOCTYPE.Text;
                enProfile.InsertAfter(xmlEle, enProfile.LastChild);
            }
            else
            {
                enProfile.SelectSingleNode("APPROVEDSUBDOCTYPE").InnerText = APPROVEDSUBDOCTYPE.Text;
            }
            #endregion      


            #region IDPERSON
            if (enProfile.SelectSingleNode(IDPERSON.ID) == null)
            {
                xmlEle = xmlDoc.CreateElement(IDPERSON.ID);
                xmlEle.InnerText = IDPERSON.Text.ToUpper();
                enProfile.InsertAfter(xmlEle, enProfile.LastChild);
            }
            #endregion

            #region COLDATE
            if (enProfile.SelectSingleNode("COLDATE") == null)
            {
                xmlEle = xmlDoc.CreateElement("COLDATE");
                xmlEle.InnerText = txtColDate.Text.Replace("/", "");
                enProfile.InsertAfter(xmlEle, enProfile.LastChild);
            }
            else
            {
                enProfile.SelectSingleNode("COLDATE").InnerText = txtColDate.Text.Replace("/", "");
            }
            #endregion
            // Main Section        

            #region SURNAME
            if (main.SelectSingleNode(SURNAME.ID) == null)
            {
                xmlEle = xmlDoc.CreateElement(SURNAME.ID);
                xmlEle.InnerText = SplitName(SURNAME.Text);
                main.InsertAfter(xmlEle, main.LastChild);
            }
            else
            {
                main.SelectSingleNode(SURNAME.ID).InnerText = SplitName(SURNAME.Text);
            }
            #endregion

            #region FIRSTNAME
            if (main.SelectSingleNode(FIRSTNAME.ID) == null)
            {
                xmlEle = xmlDoc.CreateElement(FIRSTNAME.ID);
                xmlEle.InnerText = SplitName(FIRSTNAME.Text);
                main.InsertAfter(xmlEle, main.LastChild);
            }
            else
            {
                main.SelectSingleNode(FIRSTNAME.ID).InnerText = SplitName(FIRSTNAME.Text);
            }
            #endregion

            #region MIDDLENAME
            if (main.SelectSingleNode(MIDDLENAME.ID) == null)
            {
                xmlEle = xmlDoc.CreateElement(MIDDLENAME.ID);
                xmlEle.InnerText = SplitName(MIDDLENAME.Text);
                main.InsertAfter(xmlEle, main.LastChild);
            }
            else
            {
                main.SelectSingleNode(MIDDLENAME.ID).InnerText = SplitName(MIDDLENAME.Text);
            }
            #endregion

            #region NATIONALINSURANCENO
            if (main.SelectSingleNode(NATIONALINSURANCENO.ID) == null)
            {
                xmlEle = xmlDoc.CreateElement(NATIONALINSURANCENO.ID);
                xmlEle.InnerText = NATIONALINSURANCENO.Text.Trim();
                main.InsertAfter(xmlEle, main.LastChild);
            }
            else
            {
                main.SelectSingleNode(NATIONALINSURANCENO.ID).InnerText = NATIONALINSURANCENO.Text.Trim();
            }
            #endregion


            #region SEX
            if (main.SelectSingleNode(SEX.ID) == null)
            {
                xmlEle = xmlDoc.CreateElement(SEX.ID);
                xmlEle.InnerText = SEX.SelectedValue.ToUpper();
                main.InsertAfter(xmlEle, main.LastChild);
            }
            else
            {
                main.SelectSingleNode(SEX.ID).InnerText = SEX.SelectedValue.ToUpper();
            }
            #endregion

            #region BIRTHDATE
            this.BIRTHDATE.Text = Request[this.BIRTHDATE.UniqueID];
            if (main.SelectSingleNode(BIRTHDATE.ID) == null)
            {
                xmlEle = xmlDoc.CreateElement(BIRTHDATE.ID);
                xmlEle.InnerText = BIRTHDATE.Text.Replace("/", "");
                main.InsertAfter(xmlEle, main.LastChild);
            }
            else
            {
                main.SelectSingleNode(BIRTHDATE.ID).InnerText = BIRTHDATE.Text.Replace("/", "");
            }
            #endregion

            #region BIRTHCOUNTRY CODE
            if (main.SelectSingleNode(BIRTHCOUNTRY.ID) == null)
            {
                xmlEle = xmlDoc.CreateElement(BIRTHCOUNTRY.ID);
                xmlEle.InnerText = BIRTHCOUNTRY.SelectedValue;
                main.InsertAfter(xmlEle, main.LastChild);
            }
            else
            {
                main.SelectSingleNode(BIRTHCOUNTRY.ID).InnerText = BIRTHCOUNTRY.SelectedValue;
            }
            #endregion

            #region BIRTHCOUNTRY
            if (main.SelectSingleNode("BIRTHCOUNTRY2") == null)
            {
                xmlEle = xmlDoc.CreateElement("BIRTHCOUNTRY2");
                xmlEle.InnerText = BIRTHCOUNTRY.SelectedItem.ToString();
                main.InsertAfter(xmlEle, main.LastChild);
            }
            else
            {
                main.SelectSingleNode("BIRTHCOUNTRY2").InnerText = BIRTHCOUNTRY.SelectedItem.ToString();
            }
            #endregion

            #region BIRTHPLACE
            if (main.SelectSingleNode("BIRTHPLACE") == null)
            {
                xmlEle = xmlDoc.CreateElement("BIRTHPLACE");
                xmlEle.InnerText = BIRTHPLACE.Text.ToUpper();
                main.InsertAfter(xmlEle, main.LastChild);
            }
            else
            {
                main.SelectSingleNode("BIRTHPLACE").InnerText = BIRTHPLACE.Text.ToUpper();
            }
            #endregion

            #region NATIONALITY CODE
            if (main.SelectSingleNode(NATIONALITY.ID) == null)
            {
                xmlEle = xmlDoc.CreateElement(NATIONALITY.ID);
                xmlEle.InnerText = NATIONALITY.SelectedValue;
                main.InsertAfter(xmlEle, main.LastChild);
            }
            else
            {
                main.SelectSingleNode(NATIONALITY.ID).InnerText = NATIONALITY.SelectedValue;
            }
            #endregion

            #region NATIONALITY
            if (main.SelectSingleNode("NATIONALITY2") == null)
            {
                xmlEle = xmlDoc.CreateElement("NATIONALITY2");
                xmlEle.InnerText = NATIONALITY.SelectedItem.ToString();
                main.InsertAfter(xmlEle, main.LastChild);
            }
            else
            {
                main.SelectSingleNode("NATIONALITY2").InnerText = NATIONALITY.SelectedItem.ToString();
            }
            #endregion

            #region TITLE
            if (main.SelectSingleNode(TITLE.ID) == null)
            {
                xmlEle = xmlDoc.CreateElement(TITLE.ID);
                xmlEle.InnerText = TITLE.SelectedValue.ToUpper();
                main.InsertAfter(xmlEle, main.LastChild);
            }
            else
            {
                main.SelectSingleNode(TITLE.ID).InnerText = TITLE.SelectedValue.ToUpper();
            }
            #endregion      

            //Passport
            #region PASSPORT NO
            if (main.SelectSingleNode(PASSPORTNO.ID) == null)
            {
                xmlEle = xmlDoc.CreateElement(PASSPORTNO.ID);
                xmlEle.InnerText = PASSPORTNO.Text.Trim().Replace(" ", "").ToUpper();
                main.InsertAfter(xmlEle, main.LastChild);
            }
            else
            {
                main.SelectSingleNode(PASSPORTNO.ID).InnerText = PASSPORTNO.Text.Trim().Replace(" ", "").ToUpper();
            }
            #endregion

            #region PASSPORT POI
            if (main.SelectSingleNode(PASSPORTPOI.ID) == null)
            {
                xmlEle = xmlDoc.CreateElement(PASSPORTPOI.ID);
                xmlEle.InnerText = PASSPORTPOI.Text.ToUpper();
                main.InsertAfter(xmlEle, main.LastChild);
            }
            else
            {
                main.SelectSingleNode(PASSPORTPOI.ID).InnerText = PASSPORTPOI.Text.ToUpper();
            }
            #endregion

            #region PASSPORT COI
            if (main.SelectSingleNode(PASSPORTCOI.ID) == null)
            {
                xmlEle = xmlDoc.CreateElement(PASSPORTCOI.ID);
                xmlEle.InnerText = PASSPORTCOI.SelectedValue;
                main.InsertAfter(xmlEle, main.LastChild);
            }
            else
            {
                main.SelectSingleNode(PASSPORTCOI.ID).InnerText = PASSPORTCOI.SelectedValue;
            }
            #endregion

            #region PASSPORT DOI
            if (main.SelectSingleNode(PASSPORTDOI.ID) == null)
            {
                xmlEle = xmlDoc.CreateElement(PASSPORTDOI.ID);
                xmlEle.InnerText = PASSPORTDOI.Text.Replace("/", "");
                main.InsertAfter(xmlEle, main.LastChild);
            }
            else
            {
                main.SelectSingleNode(PASSPORTDOI.ID).InnerText = PASSPORTDOI.Text.Replace("/", "");
            }
            #endregion

            #region PASSPORT DOE
            if (main.SelectSingleNode(PASSPORTDOE.ID) == null)
            {
                xmlEle = xmlDoc.CreateElement(PASSPORTDOE.ID);
                xmlEle.InnerText = PASSPORTDOE.Text.Replace("/", "");
                main.InsertAfter(xmlEle, main.LastChild);
            }
            else
            {
                main.SelectSingleNode(PASSPORTDOE.ID).InnerText = PASSPORTDOE.Text.Replace("/", "");
            }
            #endregion

            #region FACEIMAGE
            if (trans.Value == Common.COMPLETEENROLECODE || trans.Value == Common.UPDATEPROFILECODE || trans.Value == Common.GetValue("ExternalDEStage"))
            {
                #region FACEIMAGE
                if (scan.SelectSingleNode(FACEIMAGE.ID) == null)
                {

                    xmlEle = xmlDoc.CreateElement(FACEIMAGE.ID);
                    xmlEle.InnerText = FACEIMAGE.Text;
                    scan.InsertAfter(xmlEle, scan.LastChild);
                }
                else
                {

                    scan.SelectSingleNode(FACEIMAGE.ID).InnerText = FACEIMAGE.Text;
                }
                #endregion

                #region FACEIMAGEJ2K

                if (scan.SelectSingleNode(FACEIMAGEJ2K.ID) == null)
                {

                    xmlEle = xmlDoc.CreateElement(FACEIMAGEJ2K.ID);
                    xmlEle.InnerText = FACEIMAGEJ2K.Value;
                    scan.InsertAfter(xmlEle, scan.LastChild);
                }
                else
                {

                    scan.SelectSingleNode(FACEIMAGEJ2K.ID).InnerText = FACEIMAGEJ2K.Value;
                }
                #endregion
            }
            #endregion


            xmlDoc.Save(fileName);

            #endregion
        }
        private bool SubmitPartial(string fileName, string appreason)
        {
            #region partial


            int id = new int();


            #region call web service
            EMService pisservice = new EMService();
            RequestDataTypePartialEnrol partialen = new RequestDataTypePartialEnrol();
            #endregion

            #region send requested data
            partialen.SessionKey = Common.GetCookie(this.Page, "sessionKey");
            partialen.ActionDescription = "Partial Enrol";
            partialen.PermissionCode = Common.GetValue("PartialEnrolCode");

            #region enrol
            partialen.EnrolBy = Common.GetCookie(this.Page, "loginName").ToUpper();
            partialen.ApplicationID = FORMNO.Text;
            partialen.AppReason = Convert.ToInt32(appreason);
            partialen.DocType = DOCTYPE.SelectedValue;
            partialen.EntryType = SUBDOCTYPE.SelectedValue;
            partialen.EnrolLocationName = txtCompName.Value.Trim();
            partialen.Priority = 2;
            #endregion

            #region main      
            if (IDPERSON.Text != string.Empty)
                partialen.IDPerson = Convert.ToInt32(IDPERSON.Text);
            else
                partialen.IDPerson = id;

            partialen.NationalIDNo = NATIONALINSURANCENO.Text.Trim();
            partialen.Surname = SplitName(SURNAME.Text).ToUpper(); ;
            partialen.FirstName = SplitName(FIRSTNAME.Text).ToUpper(); ;
            partialen.MiddleName = SplitName(MIDDLENAME.Text).ToUpper(); ;
            partialen.BirthCountry = BIRTHCOUNTRY.SelectedValue;
            partialen.BirthDate = BIRTHDATE.Text.Replace("/", "");
            partialen.Nationality = NATIONALITY.SelectedValue;
            partialen.Sex = SEX.SelectedValue;
            partialen.Title = TITLE.SelectedValue;
            partialen.BirthPlace = BIRTHPLACE.Text.Trim().ToUpper();



            #endregion

            #region Passport
            partialen.PassportCOI = PASSPORTCOI.SelectedValue;
            partialen.PassportDOE = PASSPORTDOE.Text.Replace("/", "");
            partialen.PassportNo = PASSPORTNO.Text.Trim().Replace(" ", "").ToUpper();
            partialen.PassportPOI = PASSPORTPOI.Text.Trim().ToUpper();
            partialen.PassportDOI = PASSPORTDOI.Text.Replace("/", "");
            #endregion

            if (trans.Value == Common.GetValue("EXTERNAL"))
                partialen.CollectionDate = string.Empty;
            else
                partialen.CollectionDate = txtColDate.Text.Replace("/", "");


            #endregion

            #region response

            ResponseDataTypePartialEnrol responseEnrol = pisservice.PartialEnrol(partialen);

            string statusCode = responseEnrol.StatusCode;
            string statusMsg = responseEnrol.StatusMessage;
            #endregion

            #region display status

            Common.WriteLog(@Server.MapPath("") + Common.GetValue("logPath"), "********Enrollment*********");
            Common.WriteLog(@Server.MapPath("") + Common.GetValue("logPath"), "Application ID : " + FORMNO.Text);
            Common.WriteLog(@Server.MapPath("") + Common.GetValue("logPath"), "Application Reason : " + appreason);
            Common.WriteLog(@Server.MapPath("") + Common.GetValue("logPath"), "Result : " + statusCode + " - " + statusMsg);
            Common.WriteLog(@Server.MapPath("") + Common.GetValue("logPath"), "************END***********");

            if (statusCode != "0")
            {
                lblError.Visible = true;
                lblError.Text = statusMsg;
                return false;
            }
            else
                return true;

            #endregion



            #endregion
        }
        private void LoadXMLFile(string fileName)
        {
            #region ***
            try
            {
                if (File.Exists(fileName))
                {
                    btnGenFormNo.Visible = false;
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.Load(fileName);

                    XmlNode xmlRoot = xmlDoc.DocumentElement;
                    XmlNode enrollment = xmlRoot.SelectSingleNode("PAYLOAD/ENROLLMENT");
                    XmlNode enProfile = xmlRoot.SelectSingleNode("PAYLOAD/ENROLLMENT/ENROLPROFILE");
                    XmlNode main = xmlRoot.SelectSingleNode("PAYLOAD/ENROLLMENT/MAIN");
                    XmlNode scan = xmlRoot.SelectSingleNode("PAYLOAD/ENROLLMENT/SCANNED");
                    int partdone = Convert.ToInt32(enrollment.SelectSingleNode("partdone").InnerText);
                    purpose.Value = partdone.ToString();

                    IDPERSON.Text = enProfile.SelectSingleNode(IDPERSON.ID).InnerText;

                    #region If enrol this page before, retrieve back the data from xml file
                    if (partdone >= pageId)
                    {
                        //ENROLL PROFILE
                        FORMNO.Text = enProfile.SelectSingleNode(FORMNO.ID).InnerText;
                        //DOCTYPE.SelectedValue = enProfile.SelectSingleNode(DOCTYPE.ID).InnerText;
                        DOCTYPE1.Value = enProfile.SelectSingleNode(DOCTYPE.ID).InnerText;

                        if (enProfile.SelectSingleNode("APPROVEDSUBDOCTYPE") != null)
                        {
                            if (enProfile.SelectSingleNode("APPROVEDSUBDOCTYPE").InnerText != string.Empty)
                                APPROVEDSUBDOCTYPE.Text = enProfile.SelectSingleNode("APPROVEDSUBDOCTYPE").InnerText;
                            else
                                APPROVEDSUBDOCTYPE.Text = "-";
                        }

                        SUBDOCTYPE.SelectedValue = enProfile.SelectSingleNode(SUBDOCTYPE.ID).InnerText;
                        DOCTYPE.SelectedValue = enProfile.SelectSingleNode(DOCTYPE.ID).InnerText;

                        if (enProfile.SelectSingleNode("APPROVEDDOCTYPE") != null)
                        {
                            if (enProfile.SelectSingleNode("APPROVEDDOCTYPE").InnerText != string.Empty)
                                APPROVEDDOCTYPE.Text = enProfile.SelectSingleNode("APPROVEDDOCTYPE").InnerText;
                            else
                                APPROVEDDOCTYPE.Text = "-";
                        }

                        COLDATE.Text = enProfile.SelectSingleNode(COLDATE.ID).InnerText;



                        //MAIN PROFILE
                        TITLE.Text = main.SelectSingleNode(TITLE.ID).InnerText;
                        SURNAME.Text = main.SelectSingleNode(SURNAME.ID).InnerText;
                        FIRSTNAME.Text = main.SelectSingleNode(FIRSTNAME.ID).InnerText;
                        MIDDLENAME.Text = main.SelectSingleNode(MIDDLENAME.ID).InnerText;
                        SEX.SelectedValue = main.SelectSingleNode(SEX.ID).InnerText;
                        BIRTHDATE.Text = Common.DayMonthYearDisplay(main.SelectSingleNode(BIRTHDATE.ID).InnerText);
                        BIRTHCOUNTRY.SelectedValue = main.SelectSingleNode(BIRTHCOUNTRY.ID).InnerText;
                        BIRTHPLACE.Text = main.SelectSingleNode(BIRTHPLACE.ID).InnerText;
                        NATIONALINSURANCENO.Text = main.SelectSingleNode(NATIONALINSURANCENO.ID).InnerText;

                        #region Nationality
                        if (main.SelectSingleNode(NATIONALITY.ID).InnerText != string.Empty)
                        {
                            NATIONALITY.SelectedValue = main.SelectSingleNode(NATIONALITY.ID).InnerText;
                        }
                        else
                        {
                            NATIONALITY.SelectedValue = "";
                        }
                        #endregion

                        PASSPORTNO.Text = main.SelectSingleNode(PASSPORTNO.ID).InnerText;
                        PASSPORTPOI.Text = main.SelectSingleNode(PASSPORTPOI.ID).InnerText;
                        PASSPORTCOI.Text = main.SelectSingleNode(PASSPORTCOI.ID).InnerText;
                        PASSPORTDOI.Text = Common.DayMonthYearDisplay(main.SelectSingleNode(PASSPORTDOI.ID).InnerText);
                        PASSPORTDOE.Text = Common.DayMonthYearDisplay(main.SelectSingleNode(PASSPORTDOE.ID).InnerText);

                        #region APPREASON

                        APPREASONCODE.Text = enProfile.SelectSingleNode(APPREASON.ID).InnerText;
                        APPREASON.SelectedValue = enProfile.SelectSingleNode(APPREASON.ID).InnerText;

                        #endregion

                        if (enProfile.SelectSingleNode("STAGECODE") != null)
                            STAGECODE.Text = enProfile.SelectSingleNode("STAGECODE").InnerText;

                        if (scan.SelectSingleNode(FACEIMAGE.ID) != null)
                        {
                            #region FACE IMAGE
                            string msg2 = string.Empty;
                            byte[] binData2 = null;
                            FACEIMAGE.Text = scan.SelectSingleNode(FACEIMAGE.ID).InnerText;
                            FACEIMAGEJ2K.Value = scan.SelectSingleNode(FACEIMAGEJ2K.ID).InnerText;
                            bool HasPhoto = Common.DecodeBase64toImage(FACEIMAGE.Text, out msg2, out binData2);
                            if (HasPhoto)
                            {
                                string outputFile = @Server.MapPath("") + Common.GetValue("ImgServerPath") + msg2;
                                imgPhoto.ImageUrl = Common.GetImgUrl(binData2, outputFile, msg2);
                            }
                            else
                            {
                                imgPhoto.ImageUrl = Common.ImgDefaultUrl;
                            }
                            #endregion
                        }

                        #region Allow to update personal info regardless of appreason using update profile enrol
                        if (APPREASON.SelectedValue == "2" && (trans.Value == Common.UPDATEPROFILEENROLCODE || trans.Value == Common.UPDATEPROFILECODE))
                            DisableControl(true);
                        else if (APPREASON.SelectedValue == "2" && trans.Value != Common.UPDATEPROFILEENROLCODE && trans.Value != Common.UPDATEPROFILECODE)
                            DisableControl(false);
                        #endregion


                    }
                    #endregion

                    CheckPagePurpose();
                    trValSummaryTop.Visible = false;
                }
                else
                {
                    Response.Redirect("Logon.aspx");
                }
            }
            catch (Exception ex)
            {
                //SetLabelVisibility(false, true, false);
                lblError.Text = ex.Message;
                Common.WriteLog(@Server.MapPath("") + Common.GetValue("logPath"), "Create XML - " + ex.Message);
            }
            #endregion
        }
        private void DisableControl(bool state)
        {
            #region ***        
            BIRTHCOUNTRY.Enabled = state;
            BIRTHPLACE.Enabled = state;
            btn_Cal.Visible = state;
            imgClearDOB.Visible = state;
            DOCTYPE.Enabled = state;
            NATIONALITY.Enabled = state;

            #endregion
        }

        private void getNationality()
        {
            #region ***
            try
            {
                #region connecting to web service
                EMService enrol = new EMService();
                RequestDataTypeSelectCountry reqData = new RequestDataTypeSelectCountry();

                reqData.ActionDescription = "Get Nationality";
                reqData.SessionKey = Common.GetCookie(this.Page, "sessionKey");
                reqData.EnrolLocationName = txtCompName.Value.Trim();
                reqData.PermissionCode = Common.GETCOUNTRY;
                reqData.SortBy = Convert.ToChar("2");

                #endregion

                #region response
                ResponseDataTypeSelectCountry responseData = enrol.GetCountryList(reqData);

                string statusCode = responseData.StatusCode;
                string statusMsg = responseData.StatusMessage;
                #endregion

                #region analize result
                if (statusCode == "0")
                {

                    DataSet ds = (DataSet)responseData.ResultList;
                    #region NATIONALITY
                    DataRow[] dr = ds.Tables[0].Select(null, "Nationality", DataViewRowState.CurrentRows);
                    for (int i = 0; i < dr.Length; i++)
                    {
                        ListItem li = new ListItem(dr[i]["Nationality"].ToString() + " - " + dr[i]["Code"], dr[i]["Code"].ToString());
                        NATIONALITY.Items.Add(li);
                    }
                    NATIONALITY.Items.Insert(0, new ListItem("-SELECT-", ""));
                    #endregion
                }
                else
                {
                    lblError.Text = statusMsg;
                    lblError.Visible = true;
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
                        BIRTHCOUNTRY.Items.Add(li);
                        ListItem li2 = new ListItem(dr1[i]["Name"].ToString() + " - " + dr1[i]["Code"], dr1[i]["Code"].ToString());
                        PASSPORTCOI.Items.Add(li2);
                        ListItem li3 = new ListItem(dr1[i]["Name"].ToString() + " - " + dr1[i]["Code"], dr1[i]["Code"].ToString());
                        DDPASSPORTPOI.Items.Add(li2);


                    }
                    BIRTHCOUNTRY.Items.Insert(0, new ListItem("-SELECT-", ""));
                    PASSPORTCOI.Items.Insert(0, new ListItem("-SELECT-", ""));
                    DDPASSPORTPOI.Items.Insert(0, new ListItem("-SELECT-", ""));

                    #endregion
                }
                else
                {
                    lblError.Text = statusMsg;
                    lblError.Visible = true;
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
        protected void btnGetOldDoc_Click(object sender, EventArgs e)
        {
            lblDocNoError.Visible = false;
            if (rbSearch.SelectedValue == "2")
                SearchByPassportNo(OLDDOCNO.Text.Trim(), DDPASSPORTPOI.SelectedValue);
            else if (rbSearch.SelectedValue == "3")
                GetExistingData(rbSearch.SelectedValue, OLDDOCNO.Text.Trim(), string.Empty, string.Empty, string.Empty);
            else
                SearchByName();
        }
        private void SearchByName()
        {
            #region request Applicant Record By Name
            string sDOB = string.Empty;
            if (DOB.Text != string.Empty) sDOB = DOB.Text.Replace("/", "");
            try
            {
                #region calling web service
                EMService enrol = new EMService();
                RequestDataTypeQueryByName reqData = new RequestDataTypeQueryByName();

                reqData.ActionDescription = "Get Details By Name";
                reqData.SessionKey = Common.GetCookie(this.Page, "sessionKey");
                reqData.LocationName = txtCompName.Value.Trim();
                reqData.PermissionCode = Common.GetValue("QueryByNameCode");
                reqData.Surname = sSurname.Text.Trim();
                reqData.FirstName = sMiddleName.Text.Trim();
                reqData.MiddleName = sMiddleName.Text.Trim();
                reqData.BirthDate = sDOB;
                reqData.BirthCountry = DDPASSPORTPOI.SelectedValue;

                ResponseDataTypeQueryByName responseData = enrol.QueryByName(reqData);
                #endregion

                #region response from web service
                string statusCode = responseData.StatusCode;
                string statusMsg = responseData.StatusMessage;


                if (statusCode != "0")
                {
                    throw new Exception(statusMsg);
                }
                else
                {
                    ViewState["data"] = responseData.ResultList;
                    FilterDG();
                }
                #endregion
            }
            catch (Exception ex)
            {
                lblDocNoError.Text = ex.Message;
                lblDocNoError.Visible = true;
                Common.WriteLog(@Server.MapPath("") + Common.GetValue("logPath"), "Query by Name - " + ex.Message);
            }
            #endregion
        }
        private void FilterDG()
        {

            #region Filter Row
            DataSet ds = (DataSet)ViewState["data"];
            DataView dv = new DataView(ds.Tables[0]);

            if (trans.Value == "1")
                dv.RowFilter = Common.GetValue("NewEnrollQuery");
            else if (trans.Value == "2")
                dv.RowFilter = Common.GetValue("RenewalQuery");
            else if (trans.Value == "4")
                dv.RowFilter = Common.GetValue("ExternalQuery");

            #endregion

            #region display data if there is record match
            int i = dv.Count;
            if (i == 0)
            {
                lblDocNoError.Text = "Record is not available!";
                lblDocNoError.Visible = true;
                trDG.Visible = false;
            }
            else
            {
                lblDocNoError.Visible = false;
                trDG.Visible = true;
                dgByName.DataSource = dv;
                dgByName.PageIndex = 0;
                dgByName.DataBind();
            }
            #endregion
        }
        private void GetExistingData(string SearchMode, string DocNo, string AppID, string PassportNo, string PassportCOI)
        {
            #region request Applicant Record by Doc No, AppID, PassportNo, PassportCOI

            #region Write Log
            Common.WriteLog(@Server.MapPath("") + Common.GetValue("logPath"), "********Get Existing Data*********");
            Common.WriteLog(@Server.MapPath("") + Common.GetValue("logPath"), "Search By : " + rbSearch.SelectedItem.ToString());
            Common.WriteLog(@Server.MapPath("") + Common.GetValue("logPath"), "Passport No : " + PassportNo);
            Common.WriteLog(@Server.MapPath("") + Common.GetValue("logPath"), "PassportCOI : " + PassportCOI);
            Common.WriteLog(@Server.MapPath("") + Common.GetValue("logPath"), "Document No : " + DocNo);
            Common.WriteLog(@Server.MapPath("") + Common.GetValue("logPath"), "Application No : " + AppID);
            #endregion

            bool appStatus = false;
            try
            {
                EMService enrol = new EMService();
                RequestDataTypeGetDetails reqData = new RequestDataTypeGetDetails();

                reqData.ActionDescription = "Get Details";
                reqData.SessionKey = Common.GetCookie(this.Page, "sessionKey");
                reqData.EnrolLocationName = txtCompName.Value.Trim();
                reqData.SearchType = SearchMode;
                reqData.PermissionCode = Common.GetValue("GetDetailsPermissionCode");
                reqData.ApplicationID = AppID;
                reqData.DocNo = DocNo;
                reqData.PassportNo = PassportNo;
                reqData.PassportCOI = PassportCOI;

                ResponseDataTypeGetDetails responseData = enrol.GetDetails(reqData);

                string statusCode = responseData.StatusCode;
                string statusMsg = responseData.StatusMessage;


                #region display result
                if (statusCode == "0")
                {
                    string stage = responseData.StageCode.Substring(0, 6);
                    string appreason = responseData.AppReason.Substring(0, 1);

                    Common.WriteLog(@Server.MapPath("") + Common.GetValue("logPath"), "Result : " + statusCode + "-" + statusMsg);
                    Common.WriteLog(@Server.MapPath("") + Common.GetValue("logPath"), "Old Application Stage : " + stage);


                    if (trans.Value == "2")
                        appStatus = CheckActiveDoc(responseData.IDPerson.ToString());

                    else if (((stage == "EM4101" || stage == "EM6002") && trans.Value == "1") || ((stage == "EM4101" || stage == "EM5100") && trans.Value == "4" && (appreason == Common.GetValue("ExternalSponsored") || appreason == Common.GetValue("ExternalUnSponsored"))))
                        appStatus = true;

                    else
                    {
                        lblDocNoError.Text = "Record is not available!";
                        lblDocNoError.Visible = true;
                    }

                    Common.WriteLog(@Server.MapPath("") + Common.GetValue("logPath"), "New Application Status : " + appStatus);

                    if (appStatus)
                    {
                        #region Set Row & Table Visibility
                        SetTableVisibility(true, true, true, true, true);
                        SetRowVisibility(false, false, false, false, false, false, false);
                        trSearch.Visible = false;
                        rbMode.Enabled = false;
                        trDG.Visible = false;
                        trNewAppID.Visible = true;
                        #endregion

                        #region MAIN PROFILE
                        IDPERSON.Text = responseData.IDPerson.ToString();
                        SURNAME.Text = responseData.Surname;
                        FIRSTNAME.Text = responseData.FirstName;
                        MIDDLENAME.Text = responseData.MiddleName;
                        SEX.SelectedValue = responseData.Sex;
                        BIRTHPLACE.Text = responseData.BirthPlace;
                        BIRTHCOUNTRY.SelectedValue = responseData.BirthCountry.Substring(0, 3);
                        STAGECODE.Text = responseData.StageCode;
                        BIRTHDATE.Text = Convert.ToDateTime(responseData.BirthDate).ToString("dd/MM/yyyy");
                        TITLE.SelectedValue = responseData.Title;
                        if (trans.Value != Common.GetValue("ExternalDEStage"))
                        {
                            if (responseData.DocType != string.Empty)
                            {
                                string[] DT = responseData.DocType.ToString().Split(new char[] { '-' });
                                DOCTYPE.Text = DT[0].ToString().Trim();
                            }
                            if (responseData.EntryType != string.Empty)
                            {
                                string[] ET = responseData.EntryType.ToString().Split(new char[] { '-' });
                                SUBDOCTYPE.Text = ET[0].ToString().Trim();
                            }
                        }

                        PASSPORTDOE.Text = Convert.ToDateTime(responseData.PassportDOE).ToString("dd/MM/yyyy");
                        PASSPORTDOI.Text = Convert.ToDateTime(responseData.PassportDOI).ToString("dd/MM/yyyy");
                        PASSPORTNO.Text = responseData.PassportNo;
                        PASSPORTPOI.Text = responseData.PassportPOI;
                        PASSPORTCOI.Text = responseData.PassportCOI.Substring(0, 3);
                        NATIONALITY.Text = responseData.Nationality.Substring(0, 3);
                        NATIONALINSURANCENO.Text = responseData.NationalIDNo;

                        #endregion

                        txtColDate.Text = System.DateTime.Now.AddDays(2).Date.ToString("dd/MM/yyyy");
                    }

                    Common.WriteLog(@Server.MapPath("") + Common.GetValue("logPath"), "****************END***************");

                }
                else
                    throw new Exception(statusMsg);
                #endregion
            }
            catch (Exception ex)
            {
                lblDocNoError.Text = ex.Message;
                lblDocNoError.Visible = true;
                Common.WriteLog(@Server.MapPath("") + Common.GetValue("logPath"), "Result - " + ex.Message);
                Common.WriteLog(@Server.MapPath("") + Common.GetValue("logPath"), "****************END***************");
            }

            #endregion
        }
        private void HideTable()
        {
            #region ***
            SetTableVisibility(false, false, false, false, false);
            btnGetOldDoc.Visible = true;
            OLDDOCNO.Enabled = true;
            //trOldDocError.Visible = true; 
            #endregion
        }
        private void RetrieveApplicantData(ResponseDataTypeGetDetails getData)
        {
            #region
            /*
        
        DOCTYPE.SelectedValue = getData.DocType.Substring(0, 2);
        IDPERSON.Text = getData.IDPerson.ToString();

        if (getData.SubType != string.Empty)
        {
            string[] Sub = getData.SubType.ToString().Split(new char[] { '-' });
            GetSubDocType(getData.DocType.Substring(0, 2));
            SUBDOCTYPE.SelectedValue = Sub[0].ToString().Trim();           

            if (getData.CategoryType != string.Empty)
            {
                GetAppCategory(getData.DocType.Substring(0, 2), Sub[0].ToString().Trim());
                string[] Ct = getData.CategoryType.ToString().Split(new char[] { '-' });
                CATEGORYTYPE.SelectedValue = Ct[0].ToString().Trim();
            }
        }        
        TITLE.SelectedValue = getData.Title;
        SURNAME.Text = getData.Surname;
        FIRSTNAME.Text = getData.FirstName;
        MIDDLENAME.Text = getData.MiddleName;
        OTHERNAME.Text = getData.OtherName;
        BIRTHCOUNTRY.SelectedValue = getData.BirthCountry.Substring(0, 3);
        NATIONALITY.SelectedValue = getData.Nationality.Substring(0, 3);

        if (getData.BirthNationality != string.Empty)
            BIRTHNATIONALITY.SelectedValue = getData.BirthNationality.Substring(0, 3);
        if(getData.PrevNationality != string.Empty)
            PREVNATIONALITY.SelectedValue = getData.PrevNationality.Substring(0, 3);

        SEX.SelectedValue = getData.Sex;
        PASSPORTDOE.Text = Convert.ToDateTime(getData.PassportDOE.ToString()).ToString("dd/MM/yyyy");
        PASSPORTDOI.Text = Convert.ToDateTime(getData.PassportDOI.ToString()).ToString("dd/MM/yyyy");
        PASSPORTNO.Text = getData.PassportNo;
        PASSPORTPOI.Text = getData.PassportPOI;
        PASSPORTCOI.SelectedValue = getData.PassportCOI.Substring(0,3);
        BIRTHDATE.Text = Convert.ToDateTime(getData.BirthDate.ToString()).ToString("dd/MM/yyyy");
        BIRTHPLACE.Text = getData.BirthPlace;
        MARITALSTATUS.SelectedValue = getData.MaritalStatus;
        if(getData.NaturalizationDate != null)
            NATURALIZATIONDATE.Text = Convert.ToDateTime(getData.NaturalizationDate.ToString()).ToString("dd/MM/yyyy");
        RELIGIOUSDOMINATION.Text = getData.ReligiousDenomination;
        NATURALIZATIONPLACE.Text = getData.NaturalizationPlace;
        CheckDocType(getData.DocType.Substring(0, 2));
        WPYEARS.Text = getData.WorkPermitYearDuration.ToString();
        WPWEEKS.Text = getData.WorkPermitWeekDuration.ToString();
        WPMONTHS.Text = getData.WorkPermitMonthDuration.ToString();
        if(getData.CommencementDate != null)
            WORKDATECOMMENCEMENT.Text = Convert.ToDateTime(getData.CommencementDate.ToString()).ToString("dd/MM/yyyy");
        if (Request.QueryString["sm"] == "2")
            DisableRenewControl();
        else if (Request.QueryString["sm"] == "3")
            DisableReplaceControl();
        */
            #endregion        
        }
        private void DisableRenewControl()
        {
            #region ***

            BIRTHCOUNTRY.Enabled = false;
            BIRTHPLACE.Enabled = false;
            NATIONALITY.Enabled = false;
            btn_Cal.Visible = false;
            imgClearDOB.Visible = false;
            DOCTYPE.Enabled = false;

            #endregion
        }
        private string SplitName(string name)
        {
            #region
            if (name != string.Empty)
            {
                string[] strname = name.Split(new char[] { ' ' });
                string correctedName = string.Empty;
                if (strname.Length > 1)
                {
                    for (int i = 0; i < strname.Length; i++)
                    {
                        if (strname[i].ToString() == "-" || strname[i].ToString() == "'")
                        {
                            correctedName = correctedName.Trim() + strname[i].ToString();
                        }
                        else if (strname[i].ToString() != string.Empty && (strname[i].ToString().Substring((strname[i].ToString().Length - 1), 1) == "'" || strname[i].ToString().Substring((strname[i].ToString().Length - 1), 1) == "-"))
                        {
                            correctedName += strname[i].ToString(); // +strname[i + 1].ToString() + " ";                                              
                        }
                        else if (strname[i].ToString() != string.Empty && (strname[i].ToString().Substring(0, 1) == "'" || strname[i].ToString().Substring(0, 1) == "-"))
                        {
                            correctedName = correctedName.Trim() + strname[i].ToString();
                        }
                        else if (strname[i].ToString() != "")
                            correctedName += strname[i].ToString() + " ";
                    }
                }
                else
                {
                    correctedName = name;
                }

                #region Remove hyphen or (') at the back
                string final = correctedName.ToUpper().Trim();
                string trimfinal = final.Substring((final.Length - 1), 1);

                if (trimfinal == "-" || trimfinal == "'")
                    return final.Substring(0, (final.Length - 1));
                else
                    return final;
                #endregion
            }
            else
                return name;

            #endregion
        }

        protected void rbSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region ***

            ClearSearchField();
            switch (rbSearch.SelectedValue)
            {
                case "2":
                    lblSearch.Text = "Passport No";
                    lblCOI.Text = "Country of Issue";
                    RFVDDCOI.ErrorMessage = "Country of Issue is mandatory";
                    SetRowVisibility(true, false, false, false, false, true, true);
                    RFVNIC.ErrorMessage = "Please enter Passport No before pressing <Retrieve Applicant Data> button";
                    break;
                case "3":
                    lblSearch.Text = "Document No";
                    SetRowVisibility(true, false, false, false, false, true, false);
                    RFVNIC.ErrorMessage = "Please enter Document No before pressing <Retrieve Applicant Data> button";
                    break;
                case "5":
                    if (trans.Value == "2")
                    {
                        SetRowVisibility(false, true, true, true, true, true, true);
                        lblCOI.Text = "Country of Birth";
                        RFVDDCOI.ErrorMessage = "Country of Birth is mandatory";
                    }
                    else
                        SetRowVisibility(false, true, true, true, true, true, false);
                    break;
                default:
                    SetRowVisibility(false, false, false, false, false, false, false);
                    break;

            }
            #endregion
        }
        private void SetRowVisibility(bool NIC, bool Surname, bool FirstName, bool MiddleName, bool DOB, bool btn, bool COI)
        {
            #region ***
            trOldDocNo.Visible = NIC;
            trSurname.Visible = Surname;
            trFirstname.Visible = FirstName;
            trMiddleName.Visible = MiddleName;
            trBirthDate.Visible = DOB;
            trButton.Visible = btn;
            trCOI.Visible = COI;
            #endregion
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
            DataSet Ds = (DataSet)ViewState["data"];
            DataView dv = new DataView(Ds.Tables[0]);
            return dv;


            #endregion
        }
        protected void dgByName_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            #region select record
            if (e.CommandName == "Select")
            {
                string FORMNO = e.CommandArgument.ToString();
                GetExistingData("1", string.Empty, FORMNO, string.Empty, string.Empty);
                trDG.Visible = false;
            }
            #endregion
        }

        protected void rbMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearSearchField();
            if (rbMode.SelectedValue == "1")
            {
                trNewAppID.Visible = true;
                trSearch.Visible = false;
                SetRowVisibility(false, false, false, false, false, false, false);
            }
            else
            {
                rbSearch.SelectedIndex = -1;
                trNewAppID.Visible = false;
                trSearch.Visible = true;
                SetRowVisibility(false, false, false, false, false, false, false);
            }
        }
        private void ClearSearchField()
        {
            sSurname.Text = string.Empty;
            sMiddleName.Text = string.Empty;
            sFirstName.Text = string.Empty;
            DOB.Text = string.Empty;
            OLDDOCNO.Text = string.Empty;
            DDPASSPORTPOI.SelectedValue = string.Empty;
            trDG.Visible = false;
            lblDocNoError.Text = string.Empty;

        }
        private void UpdateProfile()
        {
            #region ***
            try
            {

                #region call web service
                EMService pisservice = new EMService();
                RequestDataTypePartialEnrol partialen = new RequestDataTypePartialEnrol();
                #endregion

                #region send requested data
                partialen.SessionKey = Common.GetCookie(this.Page, "sessionKey");
                partialen.ActionDescription = "Partial Enrol";
                partialen.PermissionCode = Common.GetValue("UPEnroll");

                #region enrol
                partialen.EnrolBy = Common.GetCookie(this.Page, "loginName").ToUpper();
                partialen.ApplicationID = FORMNO.Text;
                partialen.AppReason = Convert.ToInt32(APPREASON.SelectedValue);
                partialen.DocType = DOCTYPE.SelectedValue;
                partialen.EntryType = SUBDOCTYPE.SelectedValue;
                partialen.EnrolLocationName = txtCompName.Value.Trim();
                partialen.Priority = 2;
                #endregion

                #region main
                partialen.IDPerson = Convert.ToInt32(IDPERSON.Text);
                partialen.NationalIDNo = NATIONALINSURANCENO.Text.Trim();
                partialen.Surname = SplitName(SURNAME.Text).ToUpper(); ;
                partialen.FirstName = SplitName(FIRSTNAME.Text).ToUpper(); ;
                partialen.MiddleName = SplitName(MIDDLENAME.Text).ToUpper(); ;
                partialen.BirthCountry = BIRTHCOUNTRY.SelectedValue;
                partialen.BirthDate = BIRTHDATE.Text.Replace("/", "");
                partialen.Nationality = NATIONALITY.SelectedValue;
                partialen.Sex = SEX.SelectedValue;
                partialen.Title = TITLE.SelectedValue;
                partialen.BirthPlace = BIRTHPLACE.Text.Trim().ToUpper();



                #endregion

                #region Passport
                partialen.PassportCOI = PASSPORTCOI.SelectedValue;
                partialen.PassportDOE = PASSPORTDOE.Text.Replace("/", "");
                partialen.PassportNo = PASSPORTNO.Text.Trim().Replace(" ", "").ToUpper();
                partialen.PassportPOI = PASSPORTPOI.Text.Trim().ToUpper();
                partialen.PassportDOI = PASSPORTDOI.Text.Replace("/", "");
                #endregion

                if (APPREASON.SelectedValue == Common.GetValue("ExternalSponsored") || APPREASON.SelectedValue == Common.GetValue("ExternalUnSponsored"))
                    partialen.CollectionDate = string.Empty;
                else
                    partialen.CollectionDate = COLDATE.Text.Replace("/", "");



                #endregion

                #region response

                ResponseDataTypePartialEnrol responseEnrol = pisservice.UpdateProfileEnrol(partialen);

                string statusCode = responseEnrol.StatusCode;
                string statusMsg = responseEnrol.StatusMessage;
                #endregion

                #region display status
                if (statusCode != "0")
                    throw new Exception(statusMsg);
                else
                    Response.Redirect("CollectionSummary.aspx?arrow=" + Request.QueryString["arrow"] + "&sm=" + trans.Value + "&done=" + FORMNO.Text + trans.Value + "&PC=" + txtCompName.Value.Trim());



                #endregion
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                lblError.Visible = true;
                Common.WriteLog(@Server.MapPath("") + Common.GetValue("logPath"), "Update Profile Enrol - " + ex.Message);
            }
            #endregion
        }
        private void SearchByPassportNo(string pNo, string pCOI)
        {
            #region request Applicant Record By PassportNo

            try
            {
                #region calling web service
                EMService enrol = new EMService();
                RequestDataTypeQueryByPassport reqData = new RequestDataTypeQueryByPassport();

                reqData.ActionDescription = "Get Details By Passport No";
                reqData.SessionKey = Common.GetCookie(this.Page, "sessionKey");
                reqData.LocationName = txtCompName.Value.Trim();
                reqData.PermissionCode = Common.GetValue("QueryByPassportNo");
                reqData.PassportNo = pNo;
                reqData.PassportCOI = pCOI;

                ResponseDataTypeQueryByPassport responseData = enrol.QueryByPassport(reqData);
                #endregion

                #region response from web service
                string statusCode = responseData.StatusCode;
                string statusMsg = responseData.StatusMessage;


                if (statusCode != "0")
                {
                    throw new Exception(statusMsg);
                }
                else
                {
                    ViewState["data"] = responseData.ResultList;
                    FilterDG();
                }
                #endregion
            }
            catch (Exception ex)
            {
                lblDocNoError.Text = ex.Message;
                lblDocNoError.Visible = true;
                Common.WriteLog(@Server.MapPath("") + Common.GetValue("logPath"), "Query by Passport No - " + ex.Message);
            }
            #endregion
        }
        private bool CheckActiveDoc(string ID)
        {
            #region ***

            #region connecting to web service
            EMService enrol = new EMService();
            RequestDataTypeGetActiveDoc reqData = new RequestDataTypeGetActiveDoc();

            reqData.ActionDescription = "Get Active Doc";
            reqData.SessionKey = Common.GetCookie(this.Page, "sessionKey");
            reqData.EnrolLocationName = txtCompName.Value.Trim();
            reqData.IDPerson = Convert.ToInt32(ID);
            reqData.PermissionCode = Common.GetValue("GetActiveDoc");


            #endregion

            #region response
            ResponseDataTypeGetActiveDoc responseData = enrol.GetActiveDoc(reqData);

            string statusCode = responseData.StatusCode;
            string statusMsg = responseData.StatusMessage;
            #endregion

            #region analyze result
            if (statusCode == "0")
            {
                string query = string.Empty;
                bool docstatus = true;
                DataSet ds = responseData.ResultList;
                DataTable dt = ds.Tables[0];
                int count = dt.Rows.Count;
                if (count > 0)
                {
                    #region Check for active doc
                    for (int i = 0; i < count; i++)
                    {
                        if (dt.Rows[i]["STAGECODE"].ToString() != "EM6000")
                        {
                            lblDocNoError.Text = "Document renewal is not applicable. Application is already exist!";
                            lblDocNoError.Visible = true;
                            docstatus = false;
                            i = count;
                        }
                        else
                        {
                            docstatus = true;
                            lblDocNoError.Visible = false;
                        }
                    }
                    #endregion
                }
                return docstatus;
            }
            else
                return false;
            #endregion

            #endregion
        }
    }
}
