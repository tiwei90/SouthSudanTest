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
    public partial class ApplicationPart3 : System.Web.UI.Page
    {
        const int pageId = 5;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.SPOUSEDOB.Text = Request[this.SPOUSEDOB.UniqueID];
            this.ARRIVALDATE.Text = Request[this.ARRIVALDATE.UniqueID];
            #region ***

            if (!Page.IsPostBack)
            {
                if (Request.QueryString["done"] != null)
                {

                    txtCompName.Value = Request.QueryString["PC"];
                    getCountryList();
                    getvisitpurpose();
                    string done = Request.QueryString["done"];
                    IsNew.Value = @Server.MapPath("") + Common.GetValue("xmlServerPath") + done + ".xml";
                    LoadXMLFile(IsNew.Value);
                    MARITALSTATUS.Items.Insert(0, new ListItem("-SELECT-", ""));

                }

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
                Response.Redirect(Common.RedirectToPage(pageId, Request.QueryString["sm"]) + "&arrow=" + Request.QueryString["arrow"] + "&done=" + Request.QueryString["done"] + "&PC=" + txtCompName.Value.Trim());

            }

            catch (Exception ex)
            {
                lblError.Visible = true;
                lblError.Text = ex.Message;
            }

            #endregion

        }
        protected void btnBack_Click(object sender, EventArgs e)
        {
            #region ***
            try
            {
                //SaveIntoXmlFile(common.GetValue("xmlServerPath") + Request.QueryString["done"] + ".xml");
                Response.Redirect(Common.RedirectToPage(pageId - 2, Request.QueryString["sm"]) + "&arrow=" + Request.QueryString["arrow"] + "&done=" + Request.QueryString["done"] + "&PC=" + txtCompName.Value.Trim());

            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                lblError.Visible = false;

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
                XmlNode travel = xmlroot.SelectSingleNode("PAYLOAD/ENROLLMENT/TRAVEL");
                XmlNode family = xmlroot.SelectSingleNode("PAYLOAD/ENROLLMENT/FAMILY");
                XmlNode enProfile = xmlroot.SelectSingleNode("PAYLOAD/ENROLLMENT/ENROLPROFILE");

                XmlElement xmlEle = null;

                #region partdone

                if (Convert.ToInt32(enrollment.SelectSingleNode("partdone").InnerText) <= pageId)
                {
                    enrollment.SelectSingleNode("partdone").InnerText = pageId.ToString();
                }

                #endregion

                #region TRAVEL DETAILS

                #region VISITPURPOSE
                if (travel.SelectSingleNode(VISITPURPOSE.ID) == null)
                {
                    xmlEle = xmlDoc.CreateElement(VISITPURPOSE.ID);
                    xmlEle.InnerText = VISITPURPOSE.SelectedValue;
                    travel.InsertAfter(xmlEle, travel.LastChild);
                }
                else
                {
                    travel.SelectSingleNode(VISITPURPOSE.ID).InnerText = VISITPURPOSE.SelectedValue;
                }

                #endregion

                #region OTHERVISITPURPOSE
                if (travel.SelectSingleNode(OTHERVISITPURPOSE.ID) == null)
                {
                    xmlEle = xmlDoc.CreateElement(OTHERVISITPURPOSE.ID);
                    xmlEle.InnerText = OTHERVISITPURPOSE.Text.Trim().ToUpper();
                    travel.InsertAfter(xmlEle, travel.LastChild);
                }
                else
                {
                    travel.SelectSingleNode(OTHERVISITPURPOSE.ID).InnerText = OTHERVISITPURPOSE.Text.Trim().ToUpper();
                }

                #endregion

                #region LENGTHOFSTAY
                if (travel.SelectSingleNode(LENGTHOFSTAY.ID) == null)
                {
                    xmlEle = xmlDoc.CreateElement(LENGTHOFSTAY.ID);
                    xmlEle.InnerText = LENGTHOFSTAY.Text.ToUpper();
                    travel.InsertAfter(xmlEle, travel.LastChild);
                }
                else
                {
                    travel.SelectSingleNode(LENGTHOFSTAY.ID).InnerText = LENGTHOFSTAY.Text.ToUpper();
                }

                #endregion

                #region ARRIVALDATE
                if (travel.SelectSingleNode(ARRIVALDATE.ID) == null)
                {
                    xmlEle = xmlDoc.CreateElement(ARRIVALDATE.ID);
                    xmlEle.InnerText = ARRIVALDATE.Text.Replace("/", "");
                    travel.InsertAfter(xmlEle, travel.LastChild);
                }
                else
                {
                    travel.SelectSingleNode(ARRIVALDATE.ID).InnerText = ARRIVALDATE.Text.Replace("/", "");
                }

                #endregion

                #region HOTELNAME
                if (travel.SelectSingleNode(HOTELNAME.ID) == null)
                {
                    xmlEle = xmlDoc.CreateElement(HOTELNAME.ID);
                    xmlEle.InnerText = HOTELNAME.Text.ToUpper().Trim();
                    travel.InsertAfter(xmlEle, travel.LastChild);
                }
                else
                {
                    travel.SelectSingleNode(HOTELNAME.ID).InnerText = HOTELNAME.Text.ToUpper().Trim();
                }

                #endregion

                #region HOTELADDRESS
                if (travel.SelectSingleNode(HOTELADDRESS.ID) == null)
                {
                    xmlEle = xmlDoc.CreateElement(HOTELADDRESS.ID);
                    xmlEle.InnerText = HOTELADDRESS.Text.ToUpper().Trim();
                    travel.InsertAfter(xmlEle, travel.LastChild);
                }
                else
                {
                    travel.SelectSingleNode(HOTELADDRESS.ID).InnerText = HOTELADDRESS.Text.ToUpper().Trim();
                }

                #endregion

                #region HOTELPHONE
                if (travel.SelectSingleNode(HOTELPHONE.ID) == null)
                {
                    xmlEle = xmlDoc.CreateElement(HOTELPHONE.ID);
                    xmlEle.InnerText = HOTELPHONE.Text.Trim();
                    travel.InsertAfter(xmlEle, travel.LastChild);
                }
                else
                {
                    travel.SelectSingleNode(HOTELPHONE.ID).InnerText = HOTELPHONE.Text.Trim();
                }

                #endregion 
                #endregion

                #region FAMILY
                #region MARITALSTATUS
                if (family.SelectSingleNode(MARITALSTATUS.ID) == null)
                {
                    xmlEle = xmlDoc.CreateElement(MARITALSTATUS.ID);
                    xmlEle.InnerText = MARITALSTATUS.SelectedValue;
                    family.InsertAfter(xmlEle, family.LastChild);
                }
                else
                {
                    family.SelectSingleNode(MARITALSTATUS.ID).InnerText = MARITALSTATUS.SelectedValue;
                }

                #endregion

                #region SPOUSEDOB
                if (family.SelectSingleNode(SPOUSEDOB.ID) == null)
                {
                    xmlEle = xmlDoc.CreateElement(SPOUSEDOB.ID);
                    xmlEle.InnerText = SPOUSEDOB.Text.Replace("/", "");
                    family.InsertAfter(xmlEle, family.LastChild);
                }
                else
                {
                    family.SelectSingleNode(SPOUSEDOB.ID).InnerText = SPOUSEDOB.Text.Replace("/", "");
                }

                #endregion

                #region SPOUSEFIRSTNAME
                if (family.SelectSingleNode(SPOUSEFIRSTNAME.ID) == null)
                {
                    xmlEle = xmlDoc.CreateElement(SPOUSEFIRSTNAME.ID);
                    xmlEle.InnerText = SPOUSEFIRSTNAME.Text.ToUpper().Trim();
                    family.InsertAfter(xmlEle, family.LastChild);
                }
                else
                {
                    family.SelectSingleNode(SPOUSEFIRSTNAME.ID).InnerText = SPOUSEFIRSTNAME.Text.Trim().ToUpper();
                }

                #endregion

                #region SPOUSELASTNAME
                if (family.SelectSingleNode(SPOUSELASTNAME.ID) == null)
                {
                    xmlEle = xmlDoc.CreateElement(SPOUSELASTNAME.ID);
                    xmlEle.InnerText = SPOUSELASTNAME.Text.ToUpper().Trim();
                    family.InsertAfter(xmlEle, family.LastChild);
                }
                else
                {
                    family.SelectSingleNode(SPOUSELASTNAME.ID).InnerText = SPOUSELASTNAME.Text.Trim().ToUpper();
                }

                #endregion

                #region SPOUSEMAIDENNAME
                if (family.SelectSingleNode(SPOUSEMAIDENNAME.ID) == null)
                {
                    xmlEle = xmlDoc.CreateElement(SPOUSEMAIDENNAME.ID);
                    xmlEle.InnerText = SPOUSEMAIDENNAME.Text.ToUpper().Trim();
                    family.InsertAfter(xmlEle, family.LastChild);
                }
                else
                {
                    family.SelectSingleNode(SPOUSEMAIDENNAME.ID).InnerText = SPOUSEMAIDENNAME.Text.Trim().ToUpper();
                }

                #endregion

                #region SPOUSEMIDDLENAME
                if (family.SelectSingleNode(SPOUSEMIDDLENAME.ID) == null)
                {
                    xmlEle = xmlDoc.CreateElement(SPOUSEMIDDLENAME.ID);
                    xmlEle.InnerText = SPOUSEMIDDLENAME.Text.ToUpper().Trim();
                    family.InsertAfter(xmlEle, family.LastChild);
                }
                else
                {
                    family.SelectSingleNode(SPOUSEMIDDLENAME.ID).InnerText = SPOUSEMIDDLENAME.Text.Trim().ToUpper();
                }

                #endregion

                #region HASCHILDIND
                if (family.SelectSingleNode(HASCHILDIND.ID) == null)
                {
                    xmlEle = xmlDoc.CreateElement(HASCHILDIND.ID);
                    xmlEle.InnerText = HASCHILDIND.SelectedValue;
                    family.InsertAfter(xmlEle, family.LastChild);
                }
                else
                {
                    family.SelectSingleNode(HASCHILDIND.ID).InnerText = HASCHILDIND.SelectedValue;
                }

                #endregion

                #region DEPENDANTNAME1
                if (family.SelectSingleNode(DEPENDANTNAME1.ID) == null)
                {
                    xmlEle = xmlDoc.CreateElement(DEPENDANTNAME1.ID);
                    xmlEle.InnerText = DEPENDANTNAME1.Text.ToUpper().Trim();
                    family.InsertAfter(xmlEle, family.LastChild);
                }
                else
                {
                    family.SelectSingleNode(DEPENDANTNAME1.ID).InnerText = DEPENDANTNAME1.Text.Trim().ToUpper();
                }

                #endregion

                #region DEPENDANTNAME2
                if (family.SelectSingleNode(DEPENDANTNAME2.ID) == null)
                {
                    xmlEle = xmlDoc.CreateElement(DEPENDANTNAME2.ID);
                    xmlEle.InnerText = DEPENDANTNAME2.Text.ToUpper().Trim();
                    family.InsertAfter(xmlEle, family.LastChild);
                }
                else
                {
                    family.SelectSingleNode(DEPENDANTNAME2.ID).InnerText = DEPENDANTNAME2.Text.Trim().ToUpper();
                }

                #endregion

                #region DEPENDANTNAME3
                if (family.SelectSingleNode(DEPENDANTNAME3.ID) == null)
                {
                    xmlEle = xmlDoc.CreateElement(DEPENDANTNAME3.ID);
                    xmlEle.InnerText = DEPENDANTNAME3.Text.ToUpper().Trim();
                    family.InsertAfter(xmlEle, family.LastChild);
                }
                else
                {
                    family.SelectSingleNode(DEPENDANTNAME3.ID).InnerText = DEPENDANTNAME3.Text.Trim().ToUpper();
                }

                #endregion

                #region DEPENDANTNAME4
                if (family.SelectSingleNode(DEPENDANTNAME4.ID) == null)
                {
                    xmlEle = xmlDoc.CreateElement(DEPENDANTNAME4.ID);
                    xmlEle.InnerText = DEPENDANTNAME4.Text.ToUpper().Trim();
                    family.InsertAfter(xmlEle, family.LastChild);
                }
                else
                {
                    family.SelectSingleNode(DEPENDANTNAME4.ID).InnerText = DEPENDANTNAME4.Text.Trim().ToUpper();
                }

                #endregion

                #region DEPENDANTNAME5
                if (family.SelectSingleNode(DEPENDANTNAME5.ID) == null)
                {
                    xmlEle = xmlDoc.CreateElement(DEPENDANTNAME5.ID);
                    xmlEle.InnerText = DEPENDANTNAME5.Text.ToUpper().Trim();
                    family.InsertAfter(xmlEle, family.LastChild);
                }
                else
                {
                    family.SelectSingleNode(DEPENDANTNAME5.ID).InnerText = DEPENDANTNAME5.Text.Trim().ToUpper();
                }

                #endregion

                #region RELATIONSHIP1
                if (family.SelectSingleNode(RELATIONSHIP1.ID) == null)
                {
                    xmlEle = xmlDoc.CreateElement(RELATIONSHIP1.ID);
                    xmlEle.InnerText = RELATIONSHIP1.Text.ToUpper().Trim();
                    family.InsertAfter(xmlEle, family.LastChild);
                }
                else
                {
                    family.SelectSingleNode(RELATIONSHIP1.ID).InnerText = RELATIONSHIP1.Text.Trim().ToUpper();
                }

                #endregion

                #region RELATIONSHIP2
                if (family.SelectSingleNode(RELATIONSHIP2.ID) == null)
                {
                    xmlEle = xmlDoc.CreateElement(RELATIONSHIP2.ID);
                    xmlEle.InnerText = RELATIONSHIP2.Text.ToUpper().Trim();
                    family.InsertAfter(xmlEle, family.LastChild);
                }
                else
                {
                    family.SelectSingleNode(RELATIONSHIP2.ID).InnerText = RELATIONSHIP2.Text.Trim().ToUpper();
                }

                #endregion

                #region RELATIONSHIP3
                if (family.SelectSingleNode(RELATIONSHIP3.ID) == null)
                {
                    xmlEle = xmlDoc.CreateElement(RELATIONSHIP3.ID);
                    xmlEle.InnerText = RELATIONSHIP3.Text.ToUpper().Trim();
                    family.InsertAfter(xmlEle, family.LastChild);
                }
                else
                {
                    family.SelectSingleNode(RELATIONSHIP3.ID).InnerText = RELATIONSHIP3.Text.Trim().ToUpper();
                }

                #endregion

                #region RELATIONSHIP4
                if (family.SelectSingleNode(RELATIONSHIP4.ID) == null)
                {
                    xmlEle = xmlDoc.CreateElement(RELATIONSHIP4.ID);
                    xmlEle.InnerText = RELATIONSHIP4.Text.ToUpper().Trim();
                    family.InsertAfter(xmlEle, family.LastChild);
                }
                else
                {
                    family.SelectSingleNode(RELATIONSHIP4.ID).InnerText = RELATIONSHIP4.Text.Trim().ToUpper();
                }

                #endregion

                #region RELATIONSHIP5
                if (family.SelectSingleNode(RELATIONSHIP5.ID) == null)
                {
                    xmlEle = xmlDoc.CreateElement(RELATIONSHIP5.ID);
                    xmlEle.InnerText = RELATIONSHIP5.Text.ToUpper().Trim();
                    family.InsertAfter(xmlEle, family.LastChild);
                }
                else
                {
                    family.SelectSingleNode(RELATIONSHIP5.ID).InnerText = RELATIONSHIP5.Text.Trim().ToUpper();
                }

                #endregion

                #region TRAVELWITHSPOUSEIND
                if (family.SelectSingleNode(TRAVELWITHSPOUSEIND.ID) == null)
                {
                    xmlEle = xmlDoc.CreateElement(TRAVELWITHSPOUSEIND.ID);
                    xmlEle.InnerText = TRAVELWITHSPOUSEIND.SelectedValue;
                    family.InsertAfter(xmlEle, family.LastChild);
                }
                else
                {
                    family.SelectSingleNode(TRAVELWITHSPOUSEIND.ID).InnerText = TRAVELWITHSPOUSEIND.SelectedValue;
                }

                #endregion

                #region TRAVELWITHDEPENDANTIND
                if (family.SelectSingleNode(TRAVELWITHDEPENDANTIND.ID) == null)
                {
                    xmlEle = xmlDoc.CreateElement(TRAVELWITHDEPENDANTIND.ID);
                    xmlEle.InnerText = TRAVELWITHDEPENDANTIND.SelectedValue;
                    family.InsertAfter(xmlEle, family.LastChild);
                }
                else
                {
                    family.SelectSingleNode(TRAVELWITHDEPENDANTIND.ID).InnerText = TRAVELWITHDEPENDANTIND.SelectedValue;
                }

                #endregion

                #region FATHERFIRSTNAME
                if (family.SelectSingleNode(FATHERFIRSTNAME.ID) == null)
                {
                    xmlEle = xmlDoc.CreateElement(FATHERFIRSTNAME.ID);
                    xmlEle.InnerText = FATHERFIRSTNAME.Text.ToUpper().Trim();
                    family.InsertAfter(xmlEle, family.LastChild);
                }
                else
                {
                    family.SelectSingleNode(FATHERFIRSTNAME.ID).InnerText = FATHERFIRSTNAME.Text.Trim().ToUpper();
                }

                #endregion

                #region FATHERLASTNAME
                if (family.SelectSingleNode(FATHERLASTNAME.ID) == null)
                {
                    xmlEle = xmlDoc.CreateElement(FATHERLASTNAME.ID);
                    xmlEle.InnerText = FATHERLASTNAME.Text.ToUpper().Trim();
                    family.InsertAfter(xmlEle, family.LastChild);
                }
                else
                {
                    family.SelectSingleNode(FATHERLASTNAME.ID).InnerText = FATHERLASTNAME.Text.Trim().ToUpper();
                }

                #endregion

                #region FATHERMIDDLENAME
                if (family.SelectSingleNode(FATHERMIDDLENAME.ID) == null)
                {
                    xmlEle = xmlDoc.CreateElement(FATHERMIDDLENAME.ID);
                    xmlEle.InnerText = FATHERMIDDLENAME.Text.ToUpper().Trim();
                    family.InsertAfter(xmlEle, family.LastChild);
                }
                else
                {
                    family.SelectSingleNode(FATHERMIDDLENAME.ID).InnerText = FATHERMIDDLENAME.Text.Trim().ToUpper();
                }

                #endregion

                #region FATHERNATIONALITY
                if (family.SelectSingleNode(FATHERNATIONALITY.ID) == null)
                {
                    xmlEle = xmlDoc.CreateElement(FATHERNATIONALITY.ID);
                    xmlEle.InnerText = FATHERNATIONALITY.SelectedValue;
                    family.InsertAfter(xmlEle, family.LastChild);
                }
                else
                {
                    family.SelectSingleNode(FATHERNATIONALITY.ID).InnerText = FATHERNATIONALITY.SelectedValue;
                }

                #endregion

                #region MOTHERFIRSTNAME
                if (family.SelectSingleNode(MOTHERFIRSTNAME.ID) == null)
                {
                    xmlEle = xmlDoc.CreateElement(MOTHERFIRSTNAME.ID);
                    xmlEle.InnerText = MOTHERFIRSTNAME.Text.ToUpper().Trim();
                    family.InsertAfter(xmlEle, family.LastChild);
                }
                else
                {
                    family.SelectSingleNode(MOTHERFIRSTNAME.ID).InnerText = MOTHERFIRSTNAME.Text.Trim().ToUpper();
                }

                #endregion

                #region MOTHERLASTNAME
                if (family.SelectSingleNode(MOTHERLASTNAME.ID) == null)
                {
                    xmlEle = xmlDoc.CreateElement(MOTHERLASTNAME.ID);
                    xmlEle.InnerText = MOTHERLASTNAME.Text.ToUpper().Trim();
                    family.InsertAfter(xmlEle, family.LastChild);
                }
                else
                {
                    family.SelectSingleNode(MOTHERLASTNAME.ID).InnerText = MOTHERLASTNAME.Text.Trim().ToUpper();
                }

                #endregion

                #region MOTHERMIDDLENAME
                if (family.SelectSingleNode(MOTHERMIDDLENAME.ID) == null)
                {
                    xmlEle = xmlDoc.CreateElement(MOTHERMIDDLENAME.ID);
                    xmlEle.InnerText = MOTHERMIDDLENAME.Text.ToUpper().Trim();
                    family.InsertAfter(xmlEle, family.LastChild);
                }
                else
                {
                    family.SelectSingleNode(MOTHERMIDDLENAME.ID).InnerText = MOTHERMIDDLENAME.Text.Trim().ToUpper();
                }

                #endregion

                #region MOTHERNATIONALITY
                if (family.SelectSingleNode(MOTHERNATIONALITY.ID) == null)
                {
                    xmlEle = xmlDoc.CreateElement(MOTHERNATIONALITY.ID);
                    xmlEle.InnerText = MOTHERNATIONALITY.SelectedValue;
                    family.InsertAfter(xmlEle, family.LastChild);
                }
                else
                {
                    family.SelectSingleNode(MOTHERNATIONALITY.ID).InnerText = MOTHERNATIONALITY.SelectedValue;
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
                    XmlNode family = xmlRoot.SelectSingleNode("PAYLOAD/ENROLLMENT/FAMILY");
                    XmlNode travel = xmlRoot.SelectSingleNode("PAYLOAD/ENROLLMENT/TRAVEL");
                    int partdone = Convert.ToInt32(enrollment.SelectSingleNode("partdone").InnerText);
                    DOCTYPE.Value = enProfile.SelectSingleNode("DOCTYPE").InnerText;

                    #region to get existing data for renewal/replacement/reapplication

                    string IDPerson = enProfile.SelectSingleNode("IDPERSON").InnerText;
                    string appreason = enProfile.SelectSingleNode("APPREASON").InnerText;
                    if (IDPerson != string.Empty && partdone < pageId)
                    {
                        GetFamilyTravelDetails(IDPerson);
                    }
                    #endregion

                    #region If enrol this page before, retrieve back the data from xml file

                    if (partdone >= pageId)
                    {
                        VISITPURPOSE.SelectedValue = travel.SelectSingleNode(VISITPURPOSE.ID).InnerText;
                        OTHERVISITPURPOSE.Text = travel.SelectSingleNode(OTHERVISITPURPOSE.ID).InnerText;
                        LENGTHOFSTAY.Text = travel.SelectSingleNode(LENGTHOFSTAY.ID).InnerText;
                        ARRIVALDATE.Text = Common.DayMonthYearDisplay(travel.SelectSingleNode(ARRIVALDATE.ID).InnerText);
                        HOTELADDRESS.Text = travel.SelectSingleNode(HOTELADDRESS.ID).InnerText;
                        HOTELNAME.Text = travel.SelectSingleNode(HOTELNAME.ID).InnerText;
                        HOTELPHONE.Text = travel.SelectSingleNode(HOTELPHONE.ID).InnerText;

                        MARITALSTATUS.SelectedValue = family.SelectSingleNode(MARITALSTATUS.ID).InnerText;
                        SPOUSEFIRSTNAME.Text = family.SelectSingleNode(SPOUSEFIRSTNAME.ID).InnerText;
                        SPOUSELASTNAME.Text = family.SelectSingleNode(SPOUSELASTNAME.ID).InnerText;
                        SPOUSEMAIDENNAME.Text = family.SelectSingleNode(SPOUSEMAIDENNAME.ID).InnerText;
                        SPOUSEMIDDLENAME.Text = family.SelectSingleNode(SPOUSEMIDDLENAME.ID).InnerText;
                        SPOUSEDOB.Text = Common.DayMonthYearDisplay(family.SelectSingleNode(SPOUSEDOB.ID).InnerText);

                        HASCHILDIND.SelectedValue = family.SelectSingleNode(HASCHILDIND.ID).InnerText;
                        DEPENDANTNAME1.Text = family.SelectSingleNode(DEPENDANTNAME1.ID).InnerText;
                        DEPENDANTNAME2.Text = family.SelectSingleNode(DEPENDANTNAME2.ID).InnerText;
                        DEPENDANTNAME3.Text = family.SelectSingleNode(DEPENDANTNAME3.ID).InnerText;
                        DEPENDANTNAME4.Text = family.SelectSingleNode(DEPENDANTNAME4.ID).InnerText;
                        DEPENDANTNAME5.Text = family.SelectSingleNode(DEPENDANTNAME5.ID).InnerText;

                        RELATIONSHIP1.Text = family.SelectSingleNode(RELATIONSHIP1.ID).InnerText;
                        RELATIONSHIP2.Text = family.SelectSingleNode(RELATIONSHIP2.ID).InnerText;
                        RELATIONSHIP3.Text = family.SelectSingleNode(RELATIONSHIP3.ID).InnerText;
                        RELATIONSHIP4.Text = family.SelectSingleNode(RELATIONSHIP4.ID).InnerText;
                        RELATIONSHIP5.Text = family.SelectSingleNode(RELATIONSHIP5.ID).InnerText;

                        TRAVELWITHDEPENDANTIND.SelectedValue = family.SelectSingleNode(TRAVELWITHDEPENDANTIND.ID).InnerText;
                        TRAVELWITHSPOUSEIND.SelectedValue = family.SelectSingleNode(TRAVELWITHSPOUSEIND.ID).InnerText;

                        FATHERFIRSTNAME.Text = family.SelectSingleNode(FATHERFIRSTNAME.ID).InnerText;
                        FATHERLASTNAME.Text = family.SelectSingleNode(FATHERLASTNAME.ID).InnerText;
                        FATHERMIDDLENAME.Text = family.SelectSingleNode(FATHERMIDDLENAME.ID).InnerText;
                        FATHERNATIONALITY.SelectedValue = family.SelectSingleNode(FATHERNATIONALITY.ID).InnerText;


                        MOTHERFIRSTNAME.Text = family.SelectSingleNode(MOTHERFIRSTNAME.ID).InnerText;
                        MOTHERLASTNAME.Text = family.SelectSingleNode(MOTHERLASTNAME.ID).InnerText;
                        MOTHERMIDDLENAME.Text = family.SelectSingleNode(MOTHERMIDDLENAME.ID).InnerText;
                        MOTHERNATIONALITY.SelectedValue = family.SelectSingleNode(MOTHERNATIONALITY.ID).InnerText;
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

        private void GetFamilyTravelDetails(string IDPerson)
        {
            #region ***
            try
            {
                #region calling web service
                EMService emp = new EMService();
                RequestDataTypeQueryByIDPerson reqData = new RequestDataTypeQueryByIDPerson();

                reqData.ActionDescription = "Query by ID Person";
                reqData.SessionKey = Common.GetCookie(this.Page, "sessionKey");
                reqData.EnrolLocationName = txtCompName.Value.Trim();
                reqData.PermissionCode = Common.GetValue("QueryByID");
                reqData.IDPerson = Convert.ToInt32(IDPerson);

                ResponseDataTypeQueryByIDPerson responseData = emp.QueryByIDPerson(reqData);
                #endregion

                #region response from web service
                string statusCode = responseData.StatusCode;
                string statusMsg = responseData.StatusMessage;

                if (statusCode == "0")
                {
                    LENGTHOFSTAY.Text = responseData.LengthOfStay;
                    if (responseData.ArrivalDate != null)
                        ARRIVALDATE.Text = Convert.ToDateTime(responseData.ArrivalDate).ToString("dd/MM/yyyy");

                    if (responseData.VisitPurpose != string.Empty)
                    {
                        string[] VP = responseData.VisitPurpose.ToString().Split(new char[] { '-' });
                        VISITPURPOSE.SelectedValue = VP[0].ToString().Trim();
                        OTHERVISITPURPOSE.Text = responseData.OtherVisitPurpose;
                    }
                    HOTELADDRESS.Text = responseData.HotelAddress;
                    HOTELNAME.Text = responseData.HotelName;
                    HOTELPHONE.Text = responseData.HotelPhone;

                    MARITALSTATUS.SelectedValue = responseData.MaritalStatus;


                    if (responseData.SpouseDOB != null)
                        SPOUSEDOB.Text = Convert.ToDateTime(responseData.SpouseDOB).ToString("dd/MM/yyy");
                    SPOUSEFIRSTNAME.Text = responseData.SpouseFirstName;
                    SPOUSELASTNAME.Text = responseData.SpouseLastName;
                    //SPOUSEMAIDENNAME.Text = responseData.spou
                    SPOUSEMIDDLENAME.Text = responseData.SpouseMiddleName;
                    HASCHILDIND.SelectedValue = responseData.HasChildInd;
                    TRAVELWITHSPOUSEIND.SelectedValue = responseData.TravelWithSpouseInd;
                    TRAVELWITHDEPENDANTIND.SelectedValue = responseData.TravelWithDependantInd;

                    MOTHERFIRSTNAME.Text = responseData.MotherFirstName;
                    MOTHERLASTNAME.Text = responseData.MotherLastName;
                    MOTHERMIDDLENAME.Text = responseData.MotherMiddleName;
                    if (responseData.MotherNationality != string.Empty)
                        MOTHERNATIONALITY.Text = responseData.MotherNationality.Substring(0, 3);

                    FATHERFIRSTNAME.Text = responseData.FatherFirstName;
                    FATHERLASTNAME.Text = responseData.FatherLastName;
                    FATHERMIDDLENAME.Text = responseData.FatherMiddleName;
                    if (responseData.FatherNationality != string.Empty)
                        FATHERNATIONALITY.Text = responseData.FatherNationality.Substring(0, 3);

                    DEPENDANTNAME1.Text = responseData.DependantName1;
                    DEPENDANTNAME2.Text = responseData.DependantName2;
                    DEPENDANTNAME3.Text = responseData.DependantName3;
                    DEPENDANTNAME4.Text = responseData.DependantName4;
                    DEPENDANTNAME5.Text = responseData.DependantName5;

                    RELATIONSHIP1.Text = responseData.Relationship1;
                    RELATIONSHIP2.Text = responseData.Relationship2;
                    RELATIONSHIP3.Text = responseData.Relationship3;
                    RELATIONSHIP4.Text = responseData.Relationship4;
                    RELATIONSHIP5.Text = responseData.Relationship5;
                }
                else
                {
                    throw new Exception(statusMsg);
                }
                #endregion
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                lblError.Visible = true;
                Common.WriteLog(@Server.MapPath("") + Common.GetValue("logPath"), "GetFamilyTravelDetails: " + ex.Message);
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
                    DataSet ds1 = (DataSet)responseData.ResultList;
                    #region NATIONALITY
                    DataRow[] dr1 = ds1.Tables[0].Select(null, "Nationality", DataViewRowState.CurrentRows);
                    for (int i = 0; i < dr1.Length; i++)
                    {
                        ListItem li = new ListItem(dr1[i]["Nationality"].ToString() + " - " + dr1[i]["Code"], dr1[i]["Code"].ToString());
                        FATHERNATIONALITY.Items.Add(li);
                        ListItem li2 = new ListItem(dr1[i]["Nationality"].ToString() + " - " + dr1[i]["Code"], dr1[i]["Code"].ToString());
                        MOTHERNATIONALITY.Items.Add(li2);


                    }
                    FATHERNATIONALITY.Items.Insert(0, new ListItem("-SELECT-", ""));
                    MOTHERNATIONALITY.Items.Insert(0, new ListItem("-SELECT-", ""));

                    #endregion
                }
                else
                {
                    throw new Exception(statusMsg);
                }
                #endregion
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                lblError.Visible = true;
                Common.WriteLog(@Server.MapPath("") + Common.GetValue("logPath"), "getCountryList(): " + ex.Message);

            }
            #endregion
        }
        private void getvisitpurpose()
        {
            #region ***
            try
            {
                #region calling web service
                DALMService look = new DALMService();
                RequestDataTypeSelectVisitPurpose reqData = new RequestDataTypeSelectVisitPurpose();

                reqData.ActionDescription = "Get Visit Purpose";
                reqData.PermissionCode = Common.GetValue("SelectVisitPurpose");
                reqData.SessionKey = Common.GetCookie(this.Page, "sessionKey");

                #endregion

                #region response the request
                ResponseDataTypeSelectVisitPurpose responseData = look.SelectLookupVisitPurposeList(reqData);

                string statusCode = responseData.StatusCode;
                string statusMsg = responseData.StatusMessage;
                #endregion

                #region bind data in dd
                if (statusCode == "0")
                {
                    DataSet Ds = (DataSet)responseData.ResultList;
                    VISITPURPOSE.DataSource = Ds.Tables[0];
                    VISITPURPOSE.DataValueField = "VisitPurpose";
                    VISITPURPOSE.DataTextField = "Description";
                    VISITPURPOSE.DataBind();
                    VISITPURPOSE.SelectedValue = "0";
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
                Common.WriteLog(@Server.MapPath("") + Common.GetValue("logPath"), "getvisitpurpose(): " + ex.Message);
            }
            #endregion
        }
    }
}
