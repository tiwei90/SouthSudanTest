using EnrollmentIssuanceSite.EnrollManagementWS;
using EnrollmentIssuanceSite.Shared;
using System;
using System.IO;
using System.Xml;

namespace EnrollmentIssuanceSite
{
    public partial class ApplicationPart2 : System.Web.UI.Page
    {
        const int pageId = 4;

        protected void Page_Load(object sender, EventArgs e)
        {
            #region ***

            if (!Page.IsPostBack)
            {

                txtCompName.Value = Request.QueryString["PC"];

                string trans = Request.QueryString["sm"];
                if (Request.QueryString["done"] != null)
                {
                    string done = Request.QueryString["done"];
                    IsNew.Value = @Server.MapPath("") + Common.GetValue("xmlServerPath") + done + ".xml";
                    LoadXMLFile(IsNew.Value);
                }

            }

            #endregion
        }
        protected void btnBack_Click(object sender, EventArgs e)
        {
            #region ***
            try
            {
                //SaveIntoXmlFile(common.GetValue("xmlServerPath") + Request.QueryString["done"] + ".xml");
                Response.Redirect(Common.RedirectToPage(pageId - 4, Request.QueryString["sm"]) + "&arrow=2&done=" + Request.QueryString["done"] + "&PC=" + txtCompName.Value);
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                lblError.Visible = false;

            }
            #endregion
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            #region ***
            try
            {
                string fileName = @Server.MapPath("") + Common.GetValue("xmlServerPath") + Request.QueryString["done"] + ".xml";
                SaveIntoXmlFile(fileName);
                Response.Redirect(Common.RedirectToPage(pageId, Request.QueryString["sm"]) + "&arrow=" + Request.QueryString["arrow"] + "&done=" + Request.QueryString["done"] + "&PC=" + txtCompName.Value);

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
                XmlNode contact = xmlroot.SelectSingleNode("PAYLOAD/ENROLLMENT/CONTACT");
                XmlNode enProfile = xmlroot.SelectSingleNode("PAYLOAD/ENROLLMENT/ENROLPROFILE");
                XmlNode employment = xmlroot.SelectSingleNode("PAYLOAD/ENROLLMENT/EMPLOYMENT");

                XmlElement xmlEle = null;

                #region EMPLOYMENT

                #region EMPLOYERADDRESS
                if (employment.SelectSingleNode(EMPLOYERADDRESS.ID) == null)
                {
                    xmlEle = xmlDoc.CreateElement(EMPLOYERADDRESS.ID);
                    xmlEle.InnerText = EMPLOYERADDRESS.Text.ToUpper().Trim();
                    employment.InsertAfter(xmlEle, employment.LastChild);
                }
                else
                {
                    employment.SelectSingleNode(EMPLOYERADDRESS.ID).InnerText = EMPLOYERADDRESS.Text.ToUpper().Trim();
                }

                #endregion

                #region EMPLOYERNAME
                if (employment.SelectSingleNode(EMPLOYERNAME.ID) == null)
                {
                    xmlEle = xmlDoc.CreateElement(EMPLOYERNAME.ID);
                    xmlEle.InnerText = EMPLOYERNAME.Text.ToUpper().Trim();
                    employment.InsertAfter(xmlEle, employment.LastChild);
                }
                else
                {
                    employment.SelectSingleNode(EMPLOYERNAME.ID).InnerText = EMPLOYERNAME.Text.ToUpper().Trim();
                }
                #endregion

                #region EMPLOYERPHONE

                if (employment.SelectSingleNode(EMPLOYERPHONE.ID) == null)
                {
                    xmlEle = xmlDoc.CreateElement(EMPLOYERPHONE.ID);
                    xmlEle.InnerText = EMPLOYERPHONE.Text.ToUpper().Trim();
                    employment.InsertAfter(xmlEle, employment.LastChild);
                }
                else
                {
                    employment.SelectSingleNode(EMPLOYERPHONE.ID).InnerText = EMPLOYERPHONE.Text.ToUpper().Trim();
                }
                #endregion

                #region OCCUPATION

                if (employment.SelectSingleNode(OCCUPATION.ID) == null)
                {
                    xmlEle = xmlDoc.CreateElement(OCCUPATION.ID);
                    xmlEle.InnerText = OCCUPATION.Text.ToUpper().Trim();
                    employment.InsertAfter(xmlEle, employment.LastChild);
                }
                else
                {
                    employment.SelectSingleNode(OCCUPATION.ID).InnerText = OCCUPATION.Text.ToUpper().Trim();
                }
                #endregion

                #region YEARSEMPLOYED

                if (employment.SelectSingleNode(YEARSEMPLOYED.ID) == null)
                {
                    xmlEle = xmlDoc.CreateElement(YEARSEMPLOYED.ID);
                    xmlEle.InnerText = YEARSEMPLOYED.Text.Trim();
                    employment.InsertAfter(xmlEle, employment.LastChild);
                }
                else
                {
                    employment.SelectSingleNode(YEARSEMPLOYED.ID).InnerText = YEARSEMPLOYED.Text.Trim();
                }
                #endregion

                #region FORMEREMPLOYERADDRESS

                if (employment.SelectSingleNode(FORMEREMPLOYERADDRESS.ID) == null)
                {
                    xmlEle = xmlDoc.CreateElement(FORMEREMPLOYERADDRESS.ID);
                    xmlEle.InnerText = FORMEREMPLOYERADDRESS.Text.ToUpper().Trim();
                    employment.InsertAfter(xmlEle, employment.LastChild);
                }
                else
                {
                    employment.SelectSingleNode(FORMEREMPLOYERADDRESS.ID).InnerText = FORMEREMPLOYERADDRESS.Text.ToUpper().Trim();
                }
                #endregion

                #region FORMEREMPLOYERNAME
                if (employment.SelectSingleNode(FORMEREMPLOYERNAME.ID) == null)
                {
                    xmlEle = xmlDoc.CreateElement(FORMEREMPLOYERNAME.ID);
                    xmlEle.InnerText = FORMEREMPLOYERNAME.Text.ToUpper().Trim();
                    employment.InsertAfter(xmlEle, employment.LastChild);
                }
                else
                {
                    employment.SelectSingleNode(FORMEREMPLOYERNAME.ID).InnerText = FORMEREMPLOYERNAME.Text.ToUpper().Trim();
                }
                #endregion

                #region FORMEREMPLOYERPHONE

                if (employment.SelectSingleNode(FORMEREMPLOYERPHONE.ID) == null)
                {
                    xmlEle = xmlDoc.CreateElement(FORMEREMPLOYERPHONE.ID);
                    xmlEle.InnerText = FORMEREMPLOYERPHONE.Text.ToUpper().Trim();
                    employment.InsertAfter(xmlEle, employment.LastChild);
                }
                else
                {
                    employment.SelectSingleNode(FORMEREMPLOYERPHONE.ID).InnerText = FORMEREMPLOYERPHONE.Text.ToUpper().Trim();
                }
                #endregion

                #region FORMEROCCUPATION

                if (employment.SelectSingleNode(FORMEROCCUPATION.ID) == null)
                {
                    xmlEle = xmlDoc.CreateElement(FORMEROCCUPATION.ID);
                    xmlEle.InnerText = FORMEROCCUPATION.Text.ToUpper().Trim();
                    employment.InsertAfter(xmlEle, employment.LastChild);
                }
                else
                {
                    employment.SelectSingleNode(FORMEROCCUPATION.ID).InnerText = FORMEROCCUPATION.Text.ToUpper().Trim();
                }
                #endregion

                #region FORMERYEARSEMPLOYED

                if (employment.SelectSingleNode(FORMERYEARSEMPLOYED.ID) == null)
                {
                    xmlEle = xmlDoc.CreateElement(FORMERYEARSEMPLOYED.ID);
                    xmlEle.InnerText = FORMERYEARSEMPLOYED.Text.ToUpper().Trim();
                    employment.InsertAfter(xmlEle, employment.LastChild);
                }
                else
                {
                    employment.SelectSingleNode(FORMERYEARSEMPLOYED.ID).InnerText = FORMERYEARSEMPLOYED.Text.ToUpper().Trim();
                }
                #endregion

                #endregion

                #region CONTACT

                #region PRESENTADDRESS

                if (contact.SelectSingleNode(PRESENTADDRESS.ID) == null)
                {
                    xmlEle = xmlDoc.CreateElement(PRESENTADDRESS.ID);
                    xmlEle.InnerText = PRESENTADDRESS.Text.ToUpper().Trim();
                    contact.InsertAfter(xmlEle, contact.LastChild);
                }
                else
                {
                    contact.SelectSingleNode(PRESENTADDRESS.ID).InnerText = PRESENTADDRESS.Text.ToUpper().Trim();
                }
                #endregion

                #region PERMANENTADDRESS

                if (contact.SelectSingleNode(PERMANENTADDRESS.ID) == null)
                {
                    xmlEle = xmlDoc.CreateElement(PERMANENTADDRESS.ID);
                    xmlEle.InnerText = PERMANENTADDRESS.Text.ToUpper().Trim();
                    contact.InsertAfter(xmlEle, contact.LastChild);
                }
                else
                {
                    contact.SelectSingleNode(PERMANENTADDRESS.ID).InnerText = PERMANENTADDRESS.Text.ToUpper().Trim();
                }
                #endregion

                #region MOBILE

                if (contact.SelectSingleNode(MOBILE.ID) == null)
                {
                    xmlEle = xmlDoc.CreateElement(MOBILE.ID);
                    xmlEle.InnerText = MOBILE.Text.ToUpper().Trim();
                    contact.InsertAfter(xmlEle, contact.LastChild);
                }
                else
                {
                    contact.SelectSingleNode(MOBILE.ID).InnerText = MOBILE.Text.ToUpper().Trim();
                }
                #endregion 

                #region FAX

                if (contact.SelectSingleNode(FAX.ID) == null)
                {
                    xmlEle = xmlDoc.CreateElement(FAX.ID);
                    xmlEle.InnerText = FAX.Text.ToUpper().Trim();
                    contact.InsertAfter(xmlEle, contact.LastChild);
                }
                else
                {
                    contact.SelectSingleNode(FAX.ID).InnerText = FAX.Text.ToUpper().Trim();
                }
                #endregion 

                #region PHONEWORK

                if (contact.SelectSingleNode(PHONEWORK.ID) == null)
                {
                    xmlEle = xmlDoc.CreateElement(PHONEWORK.ID);
                    xmlEle.InnerText = PHONEWORK.Text.ToUpper().Trim();
                    contact.InsertAfter(xmlEle, contact.LastChild);
                }
                else
                {
                    contact.SelectSingleNode(PHONEWORK.ID).InnerText = PHONEWORK.Text.ToUpper().Trim();
                }
                #endregion 

                #region PHONEHOME

                if (contact.SelectSingleNode(PHONEHOME.ID) == null)
                {
                    xmlEle = xmlDoc.CreateElement(PHONEHOME.ID);
                    xmlEle.InnerText = PHONEHOME.Text.ToUpper().Trim();
                    contact.InsertAfter(xmlEle, contact.LastChild);
                }
                else
                {
                    contact.SelectSingleNode(PHONEHOME.ID).InnerText = PHONEHOME.Text.ToUpper().Trim();
                }
                #endregion 

                #region EMAIL

                if (contact.SelectSingleNode(EMAIL.ID) == null)
                {
                    xmlEle = xmlDoc.CreateElement(EMAIL.ID);
                    xmlEle.InnerText = EMAIL.Text.Trim();
                    contact.InsertAfter(xmlEle, contact.LastChild);
                }
                else
                {
                    contact.SelectSingleNode(EMAIL.ID).InnerText = EMAIL.Text.Trim();
                }
                #endregion 
                #endregion

                #region EMERGENCY CONTACT

                #region EGCONTACTADDRESS
                if (contact.SelectSingleNode(EGCONTACTADDRESS.ID) == null)
                {
                    xmlEle = xmlDoc.CreateElement(EGCONTACTADDRESS.ID);
                    xmlEle.InnerText = EGCONTACTADDRESS.Text.ToUpper().Trim();
                    contact.InsertAfter(xmlEle, contact.LastChild);
                }
                else
                {
                    contact.SelectSingleNode(EGCONTACTADDRESS.ID).InnerText = EGCONTACTADDRESS.Text.ToUpper().Trim();
                }
                #endregion

                #region EGCONTACTNAME
                if (contact.SelectSingleNode(EGCONTACTNAME.ID) == null)
                {
                    xmlEle = xmlDoc.CreateElement(EGCONTACTNAME.ID);
                    xmlEle.InnerText = EGCONTACTNAME.Text.ToUpper().Trim();
                    contact.InsertAfter(xmlEle, contact.LastChild);
                }
                else
                {
                    contact.SelectSingleNode(EGCONTACTNAME.ID).InnerText = EGCONTACTNAME.Text.ToUpper().Trim();
                }
                #endregion

                #region EGCONTACTPHONE
                if (contact.SelectSingleNode(EGCONTACTPHONE.ID) == null)
                {
                    xmlEle = xmlDoc.CreateElement(EGCONTACTPHONE.ID);
                    xmlEle.InnerText = EGCONTACTPHONE.Text.ToUpper().Trim();
                    contact.InsertAfter(xmlEle, contact.LastChild);
                }
                else
                {
                    contact.SelectSingleNode(EGCONTACTPHONE.ID).InnerText = EGCONTACTPHONE.Text.ToUpper().Trim();
                }
                #endregion

                #region EGCONTACTRELATIONSHIP
                if (contact.SelectSingleNode(EGCONTACTRELATIONSHIP.ID) == null)
                {
                    xmlEle = xmlDoc.CreateElement(EGCONTACTRELATIONSHIP.ID);
                    xmlEle.InnerText = EGCONTACTRELATIONSHIP.Text.ToUpper().Trim();
                    contact.InsertAfter(xmlEle, contact.LastChild);
                }
                else
                {
                    contact.SelectSingleNode(EGCONTACTRELATIONSHIP.ID).InnerText = EGCONTACTRELATIONSHIP.Text.ToUpper().Trim();
                }
                #endregion
                #endregion

                #region partdone

                if (Convert.ToInt32(enrollment.SelectSingleNode("partdone").InnerText) <= pageId)
                {
                    enrollment.SelectSingleNode("partdone").InnerText = pageId.ToString();
                }

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
                    XmlNode contact = xmlRoot.SelectSingleNode("PAYLOAD/ENROLLMENT/CONTACT");
                    XmlNode enProfile = xmlRoot.SelectSingleNode("PAYLOAD/ENROLLMENT/ENROLPROFILE");
                    XmlNode employ = xmlRoot.SelectSingleNode("PAYLOAD/ENROLLMENT/EMPLOYMENT");
                    int partdone = Convert.ToInt32(enrollment.SelectSingleNode("partdone").InnerText);
                    DOCTYPE.Value = enProfile.SelectSingleNode("DOCTYPE").InnerText;
                    FORMNO.Value = enProfile.SelectSingleNode("FORMNO").InnerText;
                    #region APPREASON

                    APPREASON.Value = enProfile.SelectSingleNode("APPREASON").InnerText;

                    #endregion

                    #region to get existing data for renewal/replacement/reapplication

                    string IDPerson = enProfile.SelectSingleNode("IDPERSON").InnerText;
                    string appreason = enProfile.SelectSingleNode("APPREASON").InnerText;

                    if (IDPerson != string.Empty && partdone < pageId)
                    {
                        GetContactDetails(IDPerson);
                    }
                    #endregion

                    #region If enrol this page before, retrieve back the data from xml file

                    if (partdone >= pageId)
                    {
                        #region PRESENT

                        OCCUPATION.Text = employ.SelectSingleNode("OCCUPATION").InnerText;
                        EMPLOYERADDRESS.Text = employ.SelectSingleNode("EMPLOYERADDRESS").InnerText;
                        EMPLOYERNAME.Text = employ.SelectSingleNode("EMPLOYERNAME").InnerText;
                        EMPLOYERPHONE.Text = employ.SelectSingleNode("EMPLOYERPHONE").InnerText;
                        YEARSEMPLOYED.Text = employ.SelectSingleNode("YEARSEMPLOYED").InnerText;

                        #endregion

                        #region FORMER

                        FORMEREMPLOYERADDRESS.Text = employ.SelectSingleNode("FORMEREMPLOYERADDRESS").InnerText;
                        FORMEREMPLOYERNAME.Text = employ.SelectSingleNode("FORMEREMPLOYERNAME").InnerText;
                        FORMEREMPLOYERPHONE.Text = employ.SelectSingleNode(" FORMEREMPLOYERPHONE").InnerText;
                        FORMEROCCUPATION.Text = employ.SelectSingleNode("FORMEROCCUPATION").InnerText;
                        FORMERYEARSEMPLOYED.Text = employ.SelectSingleNode("FORMERYEARSEMPLOYED").InnerText;

                        #endregion

                        #region CONTACT

                        PERMANENTADDRESS.Text = contact.SelectSingleNode("PERMANENTADDRESS").InnerText;
                        PRESENTADDRESS.Text = contact.SelectSingleNode("PRESENTADDRESS").InnerText;
                        MOBILE.Text = contact.SelectSingleNode("MOBILE").InnerText;
                        FAX.Text = contact.SelectSingleNode("FAX").InnerText;
                        PHONEHOME.Text = contact.SelectSingleNode("PHONEHOME").InnerText;
                        PHONEWORK.Text = contact.SelectSingleNode("PHONEWORK").InnerText;
                        EMAIL.Text = contact.SelectSingleNode("EMAIL").InnerText;


                        #endregion

                        #region EMERGENCY CONTACT

                        EGCONTACTRELATIONSHIP.Text = contact.SelectSingleNode("EGCONTACTRELATIONSHIP").InnerText;
                        EGCONTACTPHONE.Text = contact.SelectSingleNode("EGCONTACTPHONE").InnerText;
                        EGCONTACTNAME.Text = contact.SelectSingleNode("EGCONTACTNAME").InnerText;
                        EGCONTACTADDRESS.Text = contact.SelectSingleNode("EGCONTACTADDRESS").InnerText;
                        #endregion
                    }

                    #endregion
                }
                else

                    Response.Redirect("Logon.aspx");

            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                lblError.Visible = true;
            }

            #endregion

        }

        private void GetContactDetails(string IDPerson)
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
                    EMAIL.Text = responseData.Email;
                    PRESENTADDRESS.Text = responseData.PresentAddress;
                    PERMANENTADDRESS.Text = responseData.PermanentAddress;
                    MOBILE.Text = responseData.Mobile;
                    PHONEHOME.Text = responseData.PhoneHome;
                    PHONEWORK.Text = responseData.PhoneWork;
                    FAX.Text = responseData.Fax;

                    OCCUPATION.Text = responseData.Occupation;
                    EMPLOYERADDRESS.Text = responseData.EmployerAddress;
                    EMPLOYERNAME.Text = responseData.EmployerName;
                    EMPLOYERPHONE.Text = responseData.EmployerPhone;
                    YEARSEMPLOYED.Text = responseData.YearsEmployed;

                    FORMEREMPLOYERADDRESS.Text = responseData.FormerEmployerAddress;
                    FORMEREMPLOYERNAME.Text = responseData.FormerEmployerName;
                    FORMEREMPLOYERPHONE.Text = responseData.FormerEmployerPhone;
                    FORMEROCCUPATION.Text = responseData.FormerOccupation;
                    FORMERYEARSEMPLOYED.Text = responseData.FormerYearsEmployed;

                    EGCONTACTADDRESS.Text = responseData.EGContactAddress;
                    EGCONTACTNAME.Text = responseData.EGContactName;
                    EGCONTACTPHONE.Text = responseData.EGContactPhone;
                    EGCONTACTRELATIONSHIP.Text = responseData.EGContactRelationship;
                }
                else
                    throw new Exception(statusMsg);
                #endregion 
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                lblError.Visible = true;
                Common.WriteLog(@Server.MapPath("") + Common.GetValue("logPath"), "Get Contact Details: " + ex.Message);
            }

            #endregion
        }


    }
}
