using EnrollmentIssuanceSite.EnrollManagementWS;
using EnrollmentIssuanceSite.Shared;
using System;
using System.IO;
using System.Xml;

namespace EnrollmentIssuanceSite
{
    public partial class ApplicationPart4 : System.Web.UI.Page
    {
        const int pageId = 6;
        protected void Page_Load(object sender, EventArgs e)
        {
            #region DATE
            this.OFFENCEDATE1.Text = Request[this.OFFENCEDATE1.UniqueID];
            this.OFFENCEDATE2.Text = Request[this.OFFENCEDATE2.UniqueID];
            this.OFFENCEDATE3.Text = Request[this.OFFENCEDATE3.UniqueID];
            this.OFFENCEDATE4.Text = Request[this.OFFENCEDATE4.UniqueID];
            this.OFFENCEDATE5.Text = Request[this.OFFENCEDATE5.UniqueID];
            #endregion

            #region ***

            if (!Page.IsPostBack)
            {
                if (Request.QueryString["done"] != null)
                {
                    txtCompName.Value = Request.QueryString["PC"];
                    string done = Request.QueryString["done"];
                    IsNew.Value = @Server.MapPath("") + Common.GetValue("xmlServerPath") + done + ".xml";
                    LoadXMLFile(IsNew.Value);

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
                XmlNode additional = xmlroot.SelectSingleNode("PAYLOAD/ENROLLMENT/ADDITIONAL");
                XmlNode enProfile = xmlroot.SelectSingleNode("PAYLOAD/ENROLLMENT/ENROLPROFILE");

                XmlElement xmlEle = null;

                #region partdone

                if (Convert.ToInt32(enrollment.SelectSingleNode("partdone").InnerText) <= pageId)
                {
                    enrollment.SelectSingleNode("partdone").InnerText = pageId.ToString();
                }

                #endregion

                #region FINANCIAL DETAILS

                #region TRIPMONEY
                if (additional.SelectSingleNode(TRIPMONEY.ID) == null)
                {
                    xmlEle = xmlDoc.CreateElement(TRIPMONEY.ID);
                    xmlEle.InnerText = TRIPMONEY.Text.ToUpper().Trim();
                    additional.InsertAfter(xmlEle, additional.LastChild);
                }
                else
                {
                    additional.SelectSingleNode(TRIPMONEY.ID).InnerText = TRIPMONEY.Text.ToUpper().Trim();
                }

                #endregion

                #region TRIPSPONSORBY
                if (additional.SelectSingleNode(TRIPSPONSORBY.ID) == null)
                {
                    xmlEle = xmlDoc.CreateElement(TRIPSPONSORBY.ID);
                    xmlEle.InnerText = TRIPSPONSORBY.Text.ToUpper().Trim();
                    additional.InsertAfter(xmlEle, additional.LastChild);
                }
                else
                {
                    additional.SelectSingleNode(TRIPSPONSORBY.ID).InnerText = TRIPSPONSORBY.Text.ToUpper().Trim();
                }

                #endregion
                #endregion 

                #region CRIMINAL DETAILS

                #region CRIMINALCONVICTIONIND
                if (additional.SelectSingleNode(CRIMINALCONVICTIONIND.ID) == null)
                {
                    xmlEle = xmlDoc.CreateElement(CRIMINALCONVICTIONIND.ID);
                    xmlEle.InnerText = CRIMINALCONVICTIONIND.SelectedValue;
                    additional.InsertAfter(xmlEle, additional.LastChild);
                }
                else
                {
                    additional.SelectSingleNode(CRIMINALCONVICTIONIND.ID).InnerText = CRIMINALCONVICTIONIND.SelectedValue;
                }

                #endregion

                #region OFFENCE1
                if (additional.SelectSingleNode(OFFENCE1.ID) == null)
                {
                    xmlEle = xmlDoc.CreateElement(OFFENCE1.ID);
                    xmlEle.InnerText = OFFENCE1.Text.ToUpper().Trim();
                    additional.InsertAfter(xmlEle, additional.LastChild);
                }
                else
                {
                    additional.SelectSingleNode(OFFENCE1.ID).InnerText = OFFENCE1.Text.ToUpper().Trim();
                }

                #endregion

                #region OFFENCE2
                if (additional.SelectSingleNode(OFFENCE2.ID) == null)
                {
                    xmlEle = xmlDoc.CreateElement(OFFENCE2.ID);
                    xmlEle.InnerText = OFFENCE2.Text.ToUpper().Trim();
                    additional.InsertAfter(xmlEle, additional.LastChild);
                }
                else
                {
                    additional.SelectSingleNode(OFFENCE2.ID).InnerText = OFFENCE2.Text.ToUpper().Trim();
                }

                #endregion

                #region OFFENCE3
                if (additional.SelectSingleNode(OFFENCE3.ID) == null)
                {
                    xmlEle = xmlDoc.CreateElement(OFFENCE3.ID);
                    xmlEle.InnerText = OFFENCE3.Text.ToUpper().Trim();
                    additional.InsertAfter(xmlEle, additional.LastChild);
                }
                else
                {
                    additional.SelectSingleNode(OFFENCE3.ID).InnerText = OFFENCE3.Text.ToUpper().Trim();
                }

                #endregion

                #region OFFENCE4
                if (additional.SelectSingleNode(OFFENCE4.ID) == null)
                {
                    xmlEle = xmlDoc.CreateElement(OFFENCE4.ID);
                    xmlEle.InnerText = OFFENCE4.Text.ToUpper().Trim();
                    additional.InsertAfter(xmlEle, additional.LastChild);
                }
                else
                {
                    additional.SelectSingleNode(OFFENCE4.ID).InnerText = OFFENCE4.Text.ToUpper().Trim();
                }

                #endregion

                #region OFFENCE5
                if (additional.SelectSingleNode(OFFENCE5.ID) == null)
                {
                    xmlEle = xmlDoc.CreateElement(OFFENCE5.ID);
                    xmlEle.InnerText = OFFENCE5.Text.ToUpper().Trim();
                    additional.InsertAfter(xmlEle, additional.LastChild);
                }
                else
                {
                    additional.SelectSingleNode(OFFENCE5.ID).InnerText = OFFENCE5.Text.ToUpper().Trim();
                }

                #endregion

                #region OFFENCEDATE1
                if (additional.SelectSingleNode(OFFENCEDATE1.ID) == null)
                {
                    xmlEle = xmlDoc.CreateElement(OFFENCEDATE1.ID);
                    xmlEle.InnerText = OFFENCEDATE1.Text.Replace("/", "");
                    additional.InsertAfter(xmlEle, additional.LastChild);
                }
                else
                {
                    additional.SelectSingleNode(OFFENCEDATE1.ID).InnerText = OFFENCEDATE1.Text.Replace("/", "");
                }

                #endregion

                #region OFFENCEDATE2
                if (additional.SelectSingleNode(OFFENCEDATE2.ID) == null)
                {
                    xmlEle = xmlDoc.CreateElement(OFFENCEDATE2.ID);
                    xmlEle.InnerText = OFFENCEDATE2.Text.Replace("/", "");
                    additional.InsertAfter(xmlEle, additional.LastChild);
                }
                else
                {
                    additional.SelectSingleNode(OFFENCEDATE2.ID).InnerText = OFFENCEDATE2.Text.Replace("/", "");
                }

                #endregion

                #region OFFENCEDATE3
                if (additional.SelectSingleNode(OFFENCEDATE3.ID) == null)
                {
                    xmlEle = xmlDoc.CreateElement(OFFENCEDATE3.ID);
                    xmlEle.InnerText = OFFENCEDATE3.Text.Replace("/", "");
                    additional.InsertAfter(xmlEle, additional.LastChild);
                }
                else
                {
                    additional.SelectSingleNode(OFFENCEDATE3.ID).InnerText = OFFENCEDATE3.Text.Replace("/", "");
                }

                #endregion

                #region OFFENCEDATE4
                if (additional.SelectSingleNode(OFFENCEDATE4.ID) == null)
                {
                    xmlEle = xmlDoc.CreateElement(OFFENCEDATE4.ID);
                    xmlEle.InnerText = OFFENCEDATE4.Text.Replace("/", "");
                    additional.InsertAfter(xmlEle, additional.LastChild);
                }
                else
                {
                    additional.SelectSingleNode(OFFENCEDATE4.ID).InnerText = OFFENCEDATE4.Text.Replace("/", "");
                }

                #endregion

                #region OFFENCEDATE5
                if (additional.SelectSingleNode(OFFENCEDATE5.ID) == null)
                {
                    xmlEle = xmlDoc.CreateElement(OFFENCEDATE5.ID);
                    xmlEle.InnerText = OFFENCEDATE5.Text.Replace("/", "");
                    additional.InsertAfter(xmlEle, additional.LastChild);
                }
                else
                {
                    additional.SelectSingleNode(OFFENCEDATE5.ID).InnerText = OFFENCEDATE5.Text.Replace("/", "");
                }

                #endregion

                #region OFFENCEPENALTY1
                if (additional.SelectSingleNode(OFFENCEPENALTY1.ID) == null)
                {
                    xmlEle = xmlDoc.CreateElement(OFFENCEPENALTY1.ID);
                    xmlEle.InnerText = OFFENCEPENALTY1.Text.ToUpper().Trim();
                    additional.InsertAfter(xmlEle, additional.LastChild);
                }
                else
                {
                    additional.SelectSingleNode(OFFENCEPENALTY1.ID).InnerText = OFFENCEPENALTY1.Text.ToUpper().Trim();
                }

                #endregion

                #region OFFENCEPENALTY2
                if (additional.SelectSingleNode(OFFENCEPENALTY2.ID) == null)
                {
                    xmlEle = xmlDoc.CreateElement(OFFENCEPENALTY2.ID);
                    xmlEle.InnerText = OFFENCEPENALTY2.Text.ToUpper().Trim();
                    additional.InsertAfter(xmlEle, additional.LastChild);
                }
                else
                {
                    additional.SelectSingleNode(OFFENCEPENALTY2.ID).InnerText = OFFENCEPENALTY2.Text.ToUpper().Trim();
                }

                #endregion

                #region OFFENCEPENALTY3
                if (additional.SelectSingleNode(OFFENCEPENALTY3.ID) == null)
                {
                    xmlEle = xmlDoc.CreateElement(OFFENCEPENALTY3.ID);
                    xmlEle.InnerText = OFFENCEPENALTY3.Text.ToUpper().Trim();
                    additional.InsertAfter(xmlEle, additional.LastChild);
                }
                else
                {
                    additional.SelectSingleNode(OFFENCEPENALTY3.ID).InnerText = OFFENCEPENALTY3.Text.ToUpper().Trim();
                }

                #endregion

                #region OFFENCEPENALTY4
                if (additional.SelectSingleNode(OFFENCEPENALTY4.ID) == null)
                {
                    xmlEle = xmlDoc.CreateElement(OFFENCEPENALTY4.ID);
                    xmlEle.InnerText = OFFENCEPENALTY4.Text.ToUpper().Trim();
                    additional.InsertAfter(xmlEle, additional.LastChild);
                }
                else
                {
                    additional.SelectSingleNode(OFFENCEPENALTY4.ID).InnerText = OFFENCEPENALTY4.Text.ToUpper().Trim();
                }

                #endregion

                #region OFFENCEPENALTY5
                if (additional.SelectSingleNode(OFFENCEPENALTY5.ID) == null)
                {
                    xmlEle = xmlDoc.CreateElement(OFFENCEPENALTY5.ID);
                    xmlEle.InnerText = OFFENCEPENALTY5.Text.ToUpper().Trim();
                    additional.InsertAfter(xmlEle, additional.LastChild);
                }
                else
                {
                    additional.SelectSingleNode(OFFENCEPENALTY5.ID).InnerText = OFFENCEPENALTY5.Text.ToUpper().Trim();
                }

                #endregion

                #region OFFENCEPLACE1
                if (additional.SelectSingleNode(OFFENCEPLACE1.ID) == null)
                {
                    xmlEle = xmlDoc.CreateElement(OFFENCEPLACE1.ID);
                    xmlEle.InnerText = OFFENCEPLACE1.Text.ToUpper().Trim();
                    additional.InsertAfter(xmlEle, additional.LastChild);
                }
                else
                {
                    additional.SelectSingleNode(OFFENCEPLACE1.ID).InnerText = OFFENCEPLACE1.Text.ToUpper().Trim();
                }

                #endregion

                #region OFFENCEPLACE2
                if (additional.SelectSingleNode(OFFENCEPLACE2.ID) == null)
                {
                    xmlEle = xmlDoc.CreateElement(OFFENCEPLACE2.ID);
                    xmlEle.InnerText = OFFENCEPLACE2.Text.ToUpper().Trim();
                    additional.InsertAfter(xmlEle, additional.LastChild);
                }
                else
                {
                    additional.SelectSingleNode(OFFENCEPLACE2.ID).InnerText = OFFENCEPLACE2.Text.ToUpper().Trim();
                }

                #endregion

                #region OFFENCEPLACE3
                if (additional.SelectSingleNode(OFFENCEPLACE3.ID) == null)
                {
                    xmlEle = xmlDoc.CreateElement(OFFENCEPLACE3.ID);
                    xmlEle.InnerText = OFFENCEPLACE3.Text.ToUpper().Trim();
                    additional.InsertAfter(xmlEle, additional.LastChild);
                }
                else
                {
                    additional.SelectSingleNode(OFFENCEPLACE3.ID).InnerText = OFFENCEPLACE3.Text.ToUpper().Trim();
                }

                #endregion

                #region OFFENCEPLACE4
                if (additional.SelectSingleNode(OFFENCEPLACE4.ID) == null)
                {
                    xmlEle = xmlDoc.CreateElement(OFFENCEPLACE4.ID);
                    xmlEle.InnerText = OFFENCEPLACE4.Text.ToUpper().Trim();
                    additional.InsertAfter(xmlEle, additional.LastChild);
                }
                else
                {
                    additional.SelectSingleNode(OFFENCEPLACE4.ID).InnerText = OFFENCEPLACE4.Text.ToUpper().Trim();
                }

                #endregion

                #region OFFENCEPLACE5
                if (additional.SelectSingleNode(OFFENCEPLACE5.ID) == null)
                {
                    xmlEle = xmlDoc.CreateElement(OFFENCEPLACE5.ID);
                    xmlEle.InnerText = OFFENCEPLACE5.Text.ToUpper().Trim();
                    additional.InsertAfter(xmlEle, additional.LastChild);
                }
                else
                {
                    additional.SelectSingleNode(OFFENCEPLACE5.ID).InnerText = OFFENCEPLACE5.Text.ToUpper().Trim();
                }

                #endregion

                #region TERRORISMDESC
                if (additional.SelectSingleNode(TERRORISMDESC.ID) == null)
                {
                    xmlEle = xmlDoc.CreateElement(TERRORISMDESC.ID);
                    xmlEle.InnerText = TERRORISMDESC.Text.ToUpper().Trim();
                    additional.InsertAfter(xmlEle, additional.LastChild);
                }
                else
                {
                    additional.SelectSingleNode(TERRORISMDESC.ID).InnerText = TERRORISMDESC.Text.ToUpper().Trim();
                }

                #endregion

                #region TERRORISMIND
                if (additional.SelectSingleNode(TERRORISMIND.ID) == null)
                {
                    xmlEle = xmlDoc.CreateElement(TERRORISMIND.ID);
                    xmlEle.InnerText = TERRORISMIND.SelectedValue;
                    additional.InsertAfter(xmlEle, additional.LastChild);
                }
                else
                {
                    additional.SelectSingleNode(TERRORISMIND.ID).InnerText = TERRORISMIND.SelectedValue;
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
                        TRIPMONEY.Text = additional.SelectSingleNode(TRIPMONEY.ID).InnerText;
                        TRIPSPONSORBY.Text = additional.SelectSingleNode(TRIPSPONSORBY.ID).InnerText;

                        CRIMINALCONVICTIONIND.SelectedValue = additional.SelectSingleNode(CRIMINALCONVICTIONIND.ID).InnerText;

                        OFFENCEDATE1.Text = Common.DayMonthYearDisplay(additional.SelectSingleNode(OFFENCEDATE1.ID).InnerText);
                        OFFENCEDATE2.Text = Common.DayMonthYearDisplay(additional.SelectSingleNode(OFFENCEDATE2.ID).InnerText);
                        OFFENCEDATE3.Text = Common.DayMonthYearDisplay(additional.SelectSingleNode(OFFENCEDATE3.ID).InnerText);
                        OFFENCEDATE4.Text = Common.DayMonthYearDisplay(additional.SelectSingleNode(OFFENCEDATE4.ID).InnerText);
                        OFFENCEDATE5.Text = Common.DayMonthYearDisplay(additional.SelectSingleNode(OFFENCEDATE5.ID).InnerText);

                        OFFENCE1.Text = additional.SelectSingleNode(OFFENCE1.ID).InnerText;
                        OFFENCE2.Text = additional.SelectSingleNode(OFFENCE2.ID).InnerText;
                        OFFENCE3.Text = additional.SelectSingleNode(OFFENCE3.ID).InnerText;
                        OFFENCE4.Text = additional.SelectSingleNode(OFFENCE4.ID).InnerText;
                        OFFENCE5.Text = additional.SelectSingleNode(OFFENCE5.ID).InnerText;

                        OFFENCEPENALTY1.Text = additional.SelectSingleNode(OFFENCEPENALTY1.ID).InnerText;
                        OFFENCEPENALTY2.Text = additional.SelectSingleNode(OFFENCEPENALTY2.ID).InnerText;
                        OFFENCEPENALTY3.Text = additional.SelectSingleNode(OFFENCEPENALTY3.ID).InnerText;
                        OFFENCEPENALTY4.Text = additional.SelectSingleNode(OFFENCEPENALTY4.ID).InnerText;
                        OFFENCEPENALTY5.Text = additional.SelectSingleNode(OFFENCEPENALTY5.ID).InnerText;

                        OFFENCEPLACE1.Text = additional.SelectSingleNode(OFFENCEPLACE1.ID).InnerText;
                        OFFENCEPLACE2.Text = additional.SelectSingleNode(OFFENCEPLACE2.ID).InnerText;
                        OFFENCEPLACE3.Text = additional.SelectSingleNode(OFFENCEPLACE3.ID).InnerText;
                        OFFENCEPLACE4.Text = additional.SelectSingleNode(OFFENCEPLACE4.ID).InnerText;
                        OFFENCEPLACE5.Text = additional.SelectSingleNode(OFFENCEPLACE5.ID).InnerText;

                        TERRORISMDESC.Text = additional.SelectSingleNode(TERRORISMDESC.ID).InnerText;
                        TERRORISMIND.SelectedValue = additional.SelectSingleNode(TERRORISMIND.ID).InnerText;



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
                    TRIPMONEY.Text = responseData.TripMoney;
                    TRIPSPONSORBY.Text = responseData.TripSponsorBy;
                    CRIMINALCONVICTIONIND.SelectedValue = responseData.CriminalConvictionInd;
                    OFFENCE1.Text = responseData.Offence1;
                    OFFENCE2.Text = responseData.Offence2;
                    OFFENCE3.Text = responseData.Offence3;
                    OFFENCE4.Text = responseData.Offence4;
                    OFFENCE5.Text = responseData.Offence5;

                    if (responseData.OffenceDate1 != null)
                        OFFENCEDATE1.Text = Convert.ToDateTime(responseData.OffenceDate1).ToString("dd/MM/yyyy");

                    if (responseData.OffenceDate2 != null)
                        OFFENCEDATE2.Text = Convert.ToDateTime(responseData.OffenceDate2).ToString("dd/MM/yyyy");

                    if (responseData.OffenceDate3 != null)
                        OFFENCEDATE3.Text = Convert.ToDateTime(responseData.OffenceDate3).ToString("dd/MM/yyyy");

                    if (responseData.OffenceDate4 != null)
                        OFFENCEDATE4.Text = Convert.ToDateTime(responseData.OffenceDate4).ToString("dd/MM/yyyy");

                    if (responseData.OffenceDate5 != null)
                        OFFENCEDATE5.Text = Convert.ToDateTime(responseData.OffenceDate5).ToString("dd/MM/yyyy");

                    OFFENCEPENALTY1.Text = responseData.OffencePenalty1;
                    OFFENCEPENALTY2.Text = responseData.OffencePenalty2;
                    OFFENCEPENALTY3.Text = responseData.OffencePenalty3;
                    OFFENCEPENALTY4.Text = responseData.OffencePenalty4;
                    OFFENCEPENALTY5.Text = responseData.OffencePenalty5;

                    OFFENCEPLACE1.Text = responseData.OffencePlace1;
                    OFFENCEPLACE2.Text = responseData.OffencePlace2;
                    OFFENCEPLACE3.Text = responseData.OffencePlace3;
                    OFFENCEPLACE4.Text = responseData.OffencePlace4;
                    OFFENCEPLACE5.Text = responseData.OffencePlace5;

                    TERRORISMDESC.Text = responseData.TerrorismDesc;
                    TERRORISMIND.SelectedValue = responseData.TerrorismInd;

                }
                else
                    throw new Exception(statusMsg);
                #endregion
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                lblError.Visible = true;
                Common.WriteLog(@Server.MapPath("") + Common.GetValue("logPath"), "Get Additional Details: " + ex.Message);
            }

            #endregion
        }
    }
}
