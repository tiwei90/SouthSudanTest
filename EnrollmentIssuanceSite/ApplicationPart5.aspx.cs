using EnrollmentIssuanceSite.DALMWS;
using EnrollmentIssuanceSite.EnrollManagementWS;
using EnrollmentIssuanceSite.Shared;
using System;
using System.Data;
using System.IO;
using System.Xml;

namespace EnrollmentIssuanceSite
{
    public partial class ApplicationPart5 : System.Web.UI.Page
    {
        const int pageId = 7;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.APPLIEDVISADATE.Text = Request[this.APPLIEDVISADATE.UniqueID];
            this.LASTVISITDATE.Text = Request[this.LASTVISITDATE.UniqueID];

            if (!Page.IsPostBack)
            {
                #region ***

                if (!Page.IsPostBack)
                {
                    if (Request.QueryString["done"] != null)
                    {
                        txtCompName.Value = Request.QueryString["PC"];
                        GetResidentialStatus();
                        string done = Request.QueryString["done"];
                        IsNew.Value = @Server.MapPath("") + Common.GetValue("xmlServerPath") + done + ".xml";
                        LoadXMLFile(IsNew.Value);

                    }

                }
                #endregion
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            #region ***
            try
            {
                string fileName = @Server.MapPath("") + Common.GetValue("xmlServerPath") + Request.QueryString["done"] + ".xml";
                SaveIntoXmlFile(fileName);
                Response.Redirect(Common.RedirectToPage(pageId, Request.QueryString["sm"]) + "&arrow=" + Request.QueryString["arrow"] + "&done=" + Request.QueryString["done"] + "&PC=" + txtCompName.Value.Trim());

            }

            catch (Exception ex)
            {
                lblError.Visible = true;
                lblError.Text = ex.Message;
            }

            #endregion
        }
        private void SaveIntoXmlFile(string fileName)
        {
            #region ***

            try
            {

                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(fileName);

                XmlNode xmlroot = xmlDoc.DocumentElement;
                XmlNode enrollment = xmlroot.SelectSingleNode("PAYLOAD/ENROLLMENT");
                XmlNode additional = xmlroot.SelectSingleNode("PAYLOAD/ENROLLMENT/ADDITIONAL");
                XmlNode enProfile = xmlroot.SelectSingleNode("PAYLOAD/ENROLLMENT/ENROLPROFILE");

                XmlElement xmlEle = null;

                #region partdone

                if (Convert.ToInt32(enrollment.SelectSingleNode("partdone").InnerText) <= pageId)
                {
                    enrollment.SelectSingleNode("partdone").InnerText = pageId.ToString();
                }

                #endregion         

                #region ADDITIONAL DETAILS

                #region FATHERRESIDENTIALSTATUS
                if (additional.SelectSingleNode(FATHERRESIDENTIALSTATUS.ID) == null)
                {
                    xmlEle = xmlDoc.CreateElement(FATHERRESIDENTIALSTATUS.ID);
                    xmlEle.InnerText = FATHERRESIDENTIALSTATUS.SelectedValue;
                    additional.InsertAfter(xmlEle, additional.LastChild);
                }
                else
                {
                    additional.SelectSingleNode(FATHERRESIDENTIALSTATUS.ID).InnerText = FATHERRESIDENTIALSTATUS.SelectedValue;
                }

                #endregion

                #region MOTHERRESIDENTIALSTATUS
                if (additional.SelectSingleNode(MOTHERRESIDENTIALSTATUS.ID) == null)
                {
                    xmlEle = xmlDoc.CreateElement(MOTHERRESIDENTIALSTATUS.ID);
                    xmlEle.InnerText = MOTHERRESIDENTIALSTATUS.SelectedValue;
                    additional.InsertAfter(xmlEle, additional.LastChild);
                }
                else
                {
                    additional.SelectSingleNode(MOTHERRESIDENTIALSTATUS.ID).InnerText = MOTHERRESIDENTIALSTATUS.SelectedValue;
                }

                #endregion

                #region SPOUSERESIDENTIALSTATUS
                if (additional.SelectSingleNode(SPOUSERESIDENTIALSTATUS.ID) == null)
                {
                    xmlEle = xmlDoc.CreateElement(SPOUSERESIDENTIALSTATUS.ID);
                    xmlEle.InnerText = SPOUSERESIDENTIALSTATUS.SelectedValue;
                    additional.InsertAfter(xmlEle, additional.LastChild);
                }
                else
                {
                    additional.SelectSingleNode(SPOUSERESIDENTIALSTATUS.ID).InnerText = SPOUSERESIDENTIALSTATUS.SelectedValue;
                }

                #endregion

                #region SIBLINGRESIDENTIALSTATUS
                if (additional.SelectSingleNode(SIBLINGRESIDENTIALSTATUS.ID) == null)
                {
                    xmlEle = xmlDoc.CreateElement(SIBLINGRESIDENTIALSTATUS.ID);
                    xmlEle.InnerText = SIBLINGRESIDENTIALSTATUS.SelectedValue;
                    additional.InsertAfter(xmlEle, additional.LastChild);
                }
                else
                {
                    additional.SelectSingleNode(SIBLINGRESIDENTIALSTATUS.ID).InnerText = SIBLINGRESIDENTIALSTATUS.SelectedValue;
                }

                #endregion

                #region CHILDRENRESIDENTIALSTATUS
                if (additional.SelectSingleNode(CHILDRENRESIDENTIALSTATUS.ID) == null)
                {
                    xmlEle = xmlDoc.CreateElement(CHILDRENRESIDENTIALSTATUS.ID);
                    xmlEle.InnerText = CHILDRENRESIDENTIALSTATUS.SelectedValue;
                    additional.InsertAfter(xmlEle, additional.LastChild);
                }
                else
                {
                    additional.SelectSingleNode(CHILDRENRESIDENTIALSTATUS.ID).InnerText = CHILDRENRESIDENTIALSTATUS.SelectedValue;
                }

                #endregion

                #region FATHERINBHSIND
                if (additional.SelectSingleNode(FATHERINBHSIND.ID) == null)
                {
                    xmlEle = xmlDoc.CreateElement(FATHERINBHSIND.ID);
                    xmlEle.InnerText = (FATHERINBHSIND.Checked) ? "1" : "0";
                    additional.InsertAfter(xmlEle, additional.LastChild);
                }
                else
                {
                    additional.SelectSingleNode(FATHERINBHSIND.ID).InnerText = (FATHERINBHSIND.Checked) ? "1" : "0";
                }

                #endregion

                #region MOTHERINBHSIND
                if (additional.SelectSingleNode(MOTHERINBHSIND.ID) == null)
                {
                    xmlEle = xmlDoc.CreateElement(MOTHERINBHSIND.ID);
                    xmlEle.InnerText = (MOTHERINBHSIND.Checked) ? "1" : "0";
                    additional.InsertAfter(xmlEle, additional.LastChild);
                }
                else
                {
                    additional.SelectSingleNode(MOTHERINBHSIND.ID).InnerText = (MOTHERINBHSIND.Checked) ? "1" : "0";
                }

                #endregion

                #region SPOUSEINBHSIND
                if (additional.SelectSingleNode(SPOUSEINBHSIND.ID) == null)
                {
                    xmlEle = xmlDoc.CreateElement(SPOUSEINBHSIND.ID);
                    xmlEle.InnerText = (SPOUSEINBHSIND.Checked) ? "1" : "0";
                    additional.InsertAfter(xmlEle, additional.LastChild);
                }
                else
                {
                    additional.SelectSingleNode(SPOUSEINBHSIND.ID).InnerText = (SPOUSEINBHSIND.Checked) ? "1" : "0";
                }

                #endregion

                #region SIBLINGINBHSIND
                if (additional.SelectSingleNode(SIBLINGINBHSIND.ID) == null)
                {
                    xmlEle = xmlDoc.CreateElement(SIBLINGINBHSIND.ID);
                    xmlEle.InnerText = (SIBLINGINBHSIND.Checked) ? "1" : "0";
                    additional.InsertAfter(xmlEle, additional.LastChild);
                }
                else
                {
                    additional.SelectSingleNode(SIBLINGINBHSIND.ID).InnerText = (SIBLINGINBHSIND.Checked) ? "1" : "0";
                }

                #endregion

                #region CHILDRENINBHSIND
                if (additional.SelectSingleNode(CHILDRENINBHSIND.ID) == null)
                {
                    xmlEle = xmlDoc.CreateElement(CHILDRENINBHSIND.ID);
                    xmlEle.InnerText = (CHILDRENINBHSIND.Checked) ? "1" : "0";
                    additional.InsertAfter(xmlEle, additional.LastChild);
                }
                else
                {
                    additional.SelectSingleNode(CHILDRENINBHSIND.ID).InnerText = (CHILDRENINBHSIND.Checked) ? "1" : "0";
                }

                #endregion

                #region VISITEDBHSIND
                if (additional.SelectSingleNode(VISITEDBHSIND.ID) == null)
                {
                    xmlEle = xmlDoc.CreateElement(VISITEDBHSIND.ID);
                    xmlEle.InnerText = VISITEDBHSIND.SelectedValue;
                    additional.InsertAfter(xmlEle, additional.LastChild);
                }
                else
                {
                    additional.SelectSingleNode(VISITEDBHSIND.ID).InnerText = VISITEDBHSIND.SelectedValue;
                }

                #endregion

                #region LASTVISITDATE
                if (additional.SelectSingleNode(LASTVISITDATE.ID) == null)
                {
                    xmlEle = xmlDoc.CreateElement(LASTVISITDATE.ID);
                    xmlEle.InnerText = LASTVISITDATE.Text.Replace("/", "");
                    additional.InsertAfter(xmlEle, additional.LastChild);
                }
                else
                {
                    additional.SelectSingleNode(LASTVISITDATE.ID).InnerText = LASTVISITDATE.Text.Replace("/", "");
                }

                #endregion

                #region APPLIEDVISAIND
                if (additional.SelectSingleNode(APPLIEDVISAIND.ID) == null)
                {
                    xmlEle = xmlDoc.CreateElement(APPLIEDVISAIND.ID);
                    xmlEle.InnerText = APPLIEDVISAIND.SelectedValue;
                    additional.InsertAfter(xmlEle, additional.LastChild);
                }
                else
                {
                    additional.SelectSingleNode(APPLIEDVISAIND.ID).InnerText = APPLIEDVISAIND.SelectedValue;
                }

                #endregion

                #region APPLIEDVISADATE
                if (additional.SelectSingleNode(APPLIEDVISADATE.ID) == null)
                {
                    xmlEle = xmlDoc.CreateElement(APPLIEDVISADATE.ID);
                    xmlEle.InnerText = APPLIEDVISADATE.Text.Replace("/", "");
                    additional.InsertAfter(xmlEle, additional.LastChild);
                }
                else
                {
                    additional.SelectSingleNode(APPLIEDVISADATE.ID).InnerText = APPLIEDVISADATE.Text.Replace("/", "");
                }

                #endregion

                #region APPLIEDVISAPLACE
                if (additional.SelectSingleNode(APPLIEDVISAPLACE.ID) == null)
                {
                    xmlEle = xmlDoc.CreateElement(APPLIEDVISAPLACE.ID);
                    xmlEle.InnerText = APPLIEDVISAPLACE.Text.ToUpper().Trim();
                    additional.InsertAfter(xmlEle, additional.LastChild);
                }
                else
                {
                    additional.SelectSingleNode(APPLIEDVISAPLACE.ID).InnerText = APPLIEDVISAPLACE.Text.Trim().ToUpper();
                }

                #endregion

                #region VISAOUTCOME
                if (additional.SelectSingleNode(VISAOUTCOME.ID) == null)
                {
                    xmlEle = xmlDoc.CreateElement(VISAOUTCOME.ID);
                    xmlEle.InnerText = VISAOUTCOME.SelectedValue;
                    additional.InsertAfter(xmlEle, additional.LastChild);
                }
                else
                {
                    additional.SelectSingleNode(VISAOUTCOME.ID).InnerText = VISAOUTCOME.SelectedValue;
                }

                #endregion

                #region DEPORTEDIND
                if (additional.SelectSingleNode(DEPORTEDIND.ID) == null)
                {
                    xmlEle = xmlDoc.CreateElement(DEPORTEDIND.ID);
                    xmlEle.InnerText = DEPORTEDIND.SelectedValue;
                    additional.InsertAfter(xmlEle, additional.LastChild);
                }
                else
                {
                    additional.SelectSingleNode(DEPORTEDIND.ID).InnerText = DEPORTEDIND.SelectedValue;
                }

                #endregion
                #endregion

                xmlDoc.Save(fileName);

            }
            catch (Exception ex)
            {
                lblError.Visible = true;
                lblError.Text = ex.Message;
            }

            #endregion
        }
        private void GetResidentialStatus()
        {
            #region ***
            try
            {
                #region calling web service
                DALMService look = new DALMService();
                RequestDataTypeSelectResidentialStatus reqData = new RequestDataTypeSelectResidentialStatus();

                reqData.ActionDescription = "Get ResidentialStatus";
                reqData.PermissionCode = Common.GetValue("SelectResidentialStatus");
                reqData.SessionKey = Common.GetCookie(this.Page, "sessionKey");

                #endregion

                #region response the request
                ResponseDataTypeSelectResidentialStatus responseData = look.SelectLookupResidentialStatusList(reqData);

                string statusCode = responseData.StatusCode;
                string statusMsg = responseData.StatusMessage;
                #endregion

                #region bind data in dd
                if (statusCode == "0")
                {
                    DataSet Ds = (DataSet)responseData.ResultList;
                    FATHERRESIDENTIALSTATUS.DataSource = Ds.Tables[0];
                    FATHERRESIDENTIALSTATUS.DataValueField = "ResidentialStatus";
                    FATHERRESIDENTIALSTATUS.DataTextField = "Description";
                    FATHERRESIDENTIALSTATUS.DataBind();
                    FATHERRESIDENTIALSTATUS.SelectedValue = "6";
                    //FATHERRESIDENTIALSTATUS.Items.Insert(0, new ListItem("-SELECT-", ""));

                    DataSet Ds2 = (DataSet)responseData.ResultList;
                    MOTHERRESIDENTIALSTATUS.DataSource = Ds.Tables[0];
                    MOTHERRESIDENTIALSTATUS.DataValueField = "ResidentialStatus";
                    MOTHERRESIDENTIALSTATUS.DataTextField = "Description";
                    MOTHERRESIDENTIALSTATUS.DataBind();
                    MOTHERRESIDENTIALSTATUS.SelectedValue = "6";
                    //MOTHERRESIDENTIALSTATUS.Items.Insert(0, new ListItem("-SELECT-", ""));

                    DataSet Ds3 = (DataSet)responseData.ResultList;
                    SPOUSERESIDENTIALSTATUS.DataSource = Ds.Tables[0];
                    SPOUSERESIDENTIALSTATUS.DataValueField = "ResidentialStatus";
                    SPOUSERESIDENTIALSTATUS.DataTextField = "Description";
                    SPOUSERESIDENTIALSTATUS.DataBind();
                    SPOUSERESIDENTIALSTATUS.SelectedValue = "6";
                    //SPOUSERESIDENTIALSTATUS.Items.Insert(0, new ListItem("-SELECT-", ""));

                    DataSet Ds4 = (DataSet)responseData.ResultList;
                    SIBLINGRESIDENTIALSTATUS.DataSource = Ds.Tables[0];
                    SIBLINGRESIDENTIALSTATUS.DataValueField = "ResidentialStatus";
                    SIBLINGRESIDENTIALSTATUS.DataTextField = "Description";
                    SIBLINGRESIDENTIALSTATUS.DataBind();
                    SIBLINGRESIDENTIALSTATUS.SelectedValue = "6";
                    //SIBLINGRESIDENTIALSTATUS.Items.Insert(0, new ListItem("-SELECT-", ""));

                    DataSet Ds5 = (DataSet)responseData.ResultList;
                    CHILDRENRESIDENTIALSTATUS.DataSource = Ds.Tables[0];
                    CHILDRENRESIDENTIALSTATUS.DataValueField = "ResidentialStatus";
                    CHILDRENRESIDENTIALSTATUS.DataTextField = "Description";
                    CHILDRENRESIDENTIALSTATUS.DataBind();
                    CHILDRENRESIDENTIALSTATUS.SelectedValue = "6";
                    //CHILDRENRESIDENTIALSTATUS.Items.Insert(0, new ListItem("-SELECT-", ""));
                }
                else
                {
                    throw new Exception(statusMsg);
                }
                #endregion
            }
            catch (Exception ex)
            {
                lblError.Visible = true;
                lblError.Text = ex.Message;
                Common.WriteLog(@Server.MapPath("") + Common.GetValue("logPath"), "GetResidentialStatus(): " + ex.Message);

            }
            #endregion
        }
        private void LoadXMLFile(string fileName)
        {
            #region ***
            try
            {
                if (File.Exists(fileName))
                {
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.Load(fileName);

                    XmlNode xmlRoot = xmlDoc.DocumentElement;
                    XmlNode enrollment = xmlRoot.SelectSingleNode("PAYLOAD/ENROLLMENT");
                    XmlNode enProfile = xmlRoot.SelectSingleNode("PAYLOAD/ENROLLMENT/ENROLPROFILE");
                    XmlNode additional = xmlRoot.SelectSingleNode("PAYLOAD/ENROLLMENT/ADDITIONAL");
                    int partdone = Convert.ToInt32(enrollment.SelectSingleNode("partdone").InnerText);


                    #region to get existing data for renewal/replacement/reapplication

                    string IDPerson = enProfile.SelectSingleNode("IDPERSON").InnerText;
                    string appreason = enProfile.SelectSingleNode("APPREASON").InnerText;
                    if (IDPerson != string.Empty && partdone < pageId && appreason != "1")
                    {
                        GetAdditionalDetails(IDPerson);
                    }
                    #endregion

                    #region If enrol this page before, retrieve back the data from xml file

                    if (partdone >= pageId)
                    {

                        if (additional.SelectSingleNode(FATHERINBHSIND.ID).InnerText == "1")
                            FATHERINBHSIND.Checked = true;
                        if (additional.SelectSingleNode(MOTHERINBHSIND.ID).InnerText == "1")
                            MOTHERINBHSIND.Checked = true;
                        if (additional.SelectSingleNode(SPOUSEINBHSIND.ID).InnerText == "1")
                            SPOUSEINBHSIND.Checked = true;
                        if (additional.SelectSingleNode(SIBLINGINBHSIND.ID).InnerText == "1")
                            SIBLINGINBHSIND.Checked = true;
                        if (additional.SelectSingleNode(CHILDRENINBHSIND.ID).InnerText == "1")
                            CHILDRENINBHSIND.Checked = true;

                        FATHERRESIDENTIALSTATUS.SelectedValue = additional.SelectSingleNode(FATHERRESIDENTIALSTATUS.ID).InnerText;
                        MOTHERRESIDENTIALSTATUS.SelectedValue = additional.SelectSingleNode(MOTHERRESIDENTIALSTATUS.ID).InnerText;
                        SPOUSERESIDENTIALSTATUS.SelectedValue = additional.SelectSingleNode(SPOUSERESIDENTIALSTATUS.ID).InnerText;
                        SIBLINGRESIDENTIALSTATUS.SelectedValue = additional.SelectSingleNode(SIBLINGRESIDENTIALSTATUS.ID).InnerText;
                        CHILDRENRESIDENTIALSTATUS.SelectedValue = additional.SelectSingleNode(CHILDRENRESIDENTIALSTATUS.ID).InnerText;

                        VISITEDBHSIND.SelectedValue = additional.SelectSingleNode(VISITEDBHSIND.ID).InnerText;
                        LASTVISITDATE.Text = Common.DayMonthYearDisplay(additional.SelectSingleNode(LASTVISITDATE.ID).InnerText);
                        APPLIEDVISAIND.SelectedValue = additional.SelectSingleNode(APPLIEDVISAIND.ID).InnerText;
                        APPLIEDVISAPLACE.Text = additional.SelectSingleNode(APPLIEDVISAPLACE.ID).InnerText;
                        APPLIEDVISADATE.Text = Common.DayMonthYearDisplay(additional.SelectSingleNode(APPLIEDVISADATE.ID).InnerText);
                        VISAOUTCOME.SelectedValue = additional.SelectSingleNode(VISAOUTCOME.ID).InnerText;
                        DEPORTEDIND.SelectedValue = additional.SelectSingleNode(DEPORTEDIND.ID).InnerText;

                    }
                    #endregion
                }
                else
                {
                    Response.Redirect("Logon.aspx");
                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                lblError.Visible = true;
            }

            #endregion
        }
        protected void btnBack_Click(object sender, EventArgs e)
        {
            #region ***
            try
            {
                Response.Redirect(Common.RedirectToPage(pageId - 2, Request.QueryString["sm"]) + "&arrow=" + Request.QueryString["arrow"] + "&done=" + Request.QueryString["done"] + "&PC=" + txtCompName.Value.Trim());

            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                lblError.Visible = false;

            }
            #endregion
        }
        private void GetAdditionalDetails(string IDPerson)
        {
            #region ***
            try
            {
                #region calling web service
                EMService contact = new EMService();
                RequestDataTypeQueryByIDPerson reqData = new RequestDataTypeQueryByIDPerson();

                reqData.ActionDescription = "Query by ID Person";
                reqData.SessionKey = Common.GetCookie(this.Page, "sessionKey");
                reqData.EnrolLocationName = txtCompName.Value.Trim();
                reqData.PermissionCode = Common.GetValue("QueryByID");
                reqData.IDPerson = Convert.ToInt32(IDPerson);

                ResponseDataTypeQueryByIDPerson responseData = contact.QueryByIDPerson(reqData);
                #endregion

                #region response from web service
                string statusCode = responseData.StatusCode;
                string statusMsg = responseData.StatusMessage;

                if (statusCode == "0")
                {
                    VISITEDBHSIND.SelectedValue = responseData.VisitedBhsInd;
                    if (responseData.LastVisitDate != null)
                        LASTVISITDATE.Text = Convert.ToDateTime(responseData.LastVisitDate).ToString("dd/MM/yyyy");
                    DEPORTEDIND.SelectedValue = responseData.DeportedInd;
                    VISAOUTCOME.Text = responseData.VisaOutCome;
                    if (responseData.AppliedVisaDate != null)
                        APPLIEDVISADATE.Text = Convert.ToDateTime(responseData.AppliedVisaDate).ToString("dd/MM/yyyy");
                    APPLIEDVISAIND.SelectedValue = responseData.AppliedVisaInd;
                    APPLIEDVISAPLACE.Text = responseData.AppliedVisaPlace;

                    if (responseData.FatherInBHSInd == "1")
                        FATHERINBHSIND.Checked = true;
                    if (responseData.MotherInBHSInd == "1")
                        MOTHERINBHSIND.Checked = true;
                    if (responseData.SiblingInBHSInd == "1")
                        SIBLINGINBHSIND.Checked = true;
                    if (responseData.SpouseInBHSInd == "1")
                        SPOUSEINBHSIND.Checked = true;
                    if (responseData.ChildrenInBHSInd == "1")
                        CHILDRENINBHSIND.Checked = true;

                    if (responseData.FatherResidentialStatus != string.Empty)
                    {
                        string[] FS = responseData.FatherResidentialStatus.ToString().Split(new char[] { '-' });
                        FATHERRESIDENTIALSTATUS.SelectedValue = FS[0].ToString().Trim();
                    }
                    if (responseData.MotherResidentialStatus != string.Empty)
                    {
                        string[] MS = responseData.MotherResidentialStatus.ToString().Split(new char[] { '-' });
                        MOTHERRESIDENTIALSTATUS.SelectedValue = MS[0].ToString().Trim();
                    }
                    if (responseData.SiblingResidentialStatus != string.Empty)
                    {
                        string[] SS = responseData.SiblingResidentialStatus.ToString().Split(new char[] { '-' });
                        SIBLINGRESIDENTIALSTATUS.SelectedValue = SS[0].ToString().Trim();
                    }
                    if (responseData.ChildrenResidentialStatus != string.Empty)
                    {
                        string[] CS = responseData.ChildrenResidentialStatus.ToString().Split(new char[] { '-' });
                        CHILDRENRESIDENTIALSTATUS.SelectedValue = CS[0].ToString().Trim();
                    }
                    if (responseData.SpouseResidentialStatus != string.Empty)
                    {
                        string[] CS = responseData.SpouseResidentialStatus.ToString().Split(new char[] { '-' });
                        SPOUSERESIDENTIALSTATUS.SelectedValue = CS[0].ToString().Trim();
                    }


                }
                else
                    throw new Exception(statusMsg);
                #endregion
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                lblError.Visible = true;
                Common.WriteLog(@Server.MapPath("") + Common.GetValue("logPath"), "GetAdditionalDetails : " + ex.Message);
            }

            #endregion
        }
    }
}
