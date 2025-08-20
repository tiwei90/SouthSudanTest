using EnrollmentIssuanceSite.EnrollManagementWS;
using EnrollmentIssuanceSite.Shared;
using System;
using System.IO;
using System.Xml;

namespace EnrollmentIssuanceSite
{
    public partial class CollectionSummary : System.Web.UI.Page
    {

        const int pageId = 3;

        protected void Page_Load(object sender, EventArgs e)
        {
            lblOfflineMsg.Visible = Convert.ToBoolean(Common.GetValue("OfflineMsg"));
            #region ***

            if (!Page.IsPostBack)
            {

                txtCompName.Value = Request.QueryString["PC"];
                string done = Request.QueryString["done"];
                SM.Value = Request.QueryString["sm"];
                IsNew.Value = @Server.MapPath("") + Common.GetValue("xmlServerPath") + done + ".xml";
                LoadXmlData(IsNew.Value);
                CheckEnrolType(SM.Value);
                getBranchName();


            }
            #endregion
        }
        private void LoadXmlData(string fileName)
        {
            #region ***
            try
            {
                if (File.Exists(fileName))
                {
                    #region ***
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.Load(fileName);

                    XmlNode root = xmlDoc.DocumentElement;
                    XmlNode enrollment = root.SelectSingleNode("PAYLOAD/ENROLLMENT");
                    XmlNode main = root.SelectSingleNode("PAYLOAD/ENROLLMENT/MAIN");
                    XmlNode enProfile = root.SelectSingleNode("PAYLOAD/ENROLLMENT/ENROLPROFILE");
                    XmlNode scan = root.SelectSingleNode("PAYLOAD/ENROLLMENT/SCANNED");

                    if (Request.QueryString["sm"] != Common.UPDATEPROFILECODE)
                        COLDATE.Text = Common.DayMonthYearDisplay(enProfile.SelectSingleNode("COLDATE").InnerText);

                    #region MAIN

                    NATIONALINSURANCENO.Text = main.SelectSingleNode("PASSPORTNO").InnerText;
                    EXPIRYDATE.Text = Common.DayMonthYearDisplay(main.SelectSingleNode("PASSPORTDOE").InnerText);


                    SURNAME.Text = main.SelectSingleNode(SURNAME.ID).InnerText;
                    FIRSTNAME.Text = main.SelectSingleNode(FIRSTNAME.ID).InnerText;
                    MIDDLENAME.Text = main.SelectSingleNode(MIDDLENAME.ID).InnerText;
                    BIRTHDATE.Text = Common.DayMonthYearDisplay(main.SelectSingleNode(BIRTHDATE.ID).InnerText);
                    BIRTHCOUNTRY.Text = main.SelectSingleNode("BIRTHCOUNTRY2").InnerText;
                    BIRTHPLACE.Text = main.SelectSingleNode("BIRTHPLACE").InnerText;

                    SEX.Text = (main.SelectSingleNode(SEX.ID).InnerText == "F") ?
                        "Female".ToUpper() : "Male".ToUpper();
                    if (main.SelectSingleNode("NATIONALITY2") == null)
                    {
                        NATIONALITY.Text = main.SelectSingleNode("NATIONALITY").InnerText;
                    }
                    else
                    {
                        NATIONALITY.Text = main.SelectSingleNode("NATIONALITY2").InnerText.ToUpper();
                    }


                    #endregion             

                    #region FACEIMAGE
                    if (scan.SelectSingleNode(FACEIMAGE.ID) != null)
                    {
                        #region show image
                        if (scan.SelectSingleNode(FACEIMAGE.ID).InnerText != string.Empty)
                        {
                            string msg1 = string.Empty;
                            byte[] binData = null;

                            bool HasPhoto = Common.DecodeBase64toImage(scan.SelectSingleNode(FACEIMAGE.ID).InnerText, out msg1, out binData);
                            if (HasPhoto)
                            {
                                string outputFile = @Server.MapPath("") + Common.GetValue("ImgServerPath") + msg1;
                                FACEIMAGE.ImageUrl = Common.GetImgUrl(binData, outputFile, msg1);
                            }
                            else
                            {
                                throw new Exception("Fail to decode photo image");
                            }
                        }
                        #endregion
                    }

                    #endregion

                    FORMNO.Text = enProfile.SelectSingleNode(FORMNO.ID).InnerText;

                    #region DOCTYPE & SUBDOCTYPE
                    DOCTYPEID.Value = enProfile.SelectSingleNode("DOCTYPE").InnerText;
                    DOCTYPE.Text = enProfile.SelectSingleNode("DOCTYPETXT").InnerText;
                    SUBDOCTYPE.Text = enProfile.SelectSingleNode("SUBDOCTYPE2").InnerText;


                    #endregion

                    #region APPREASON
                    APPREASONID.Value = enProfile.SelectSingleNode(APPREASON.ID).InnerText;
                    switch (enProfile.SelectSingleNode(APPREASON.ID).InnerText)
                    {
                        case "1":
                            APPREASON.Text = "NEW APPLICATION".ToUpper();
                            break;
                        case "2":
                            APPREASON.Text = "RENEWAL".ToUpper();
                            break;
                        case "3":
                            APPREASON.Text = "REPLACEMENT".ToUpper();
                            break;
                        case "4":
                            APPREASON.Text = "EXTERNAL APPLICATION - UNSPONSORED";
                            break;
                        case "5":
                            APPREASON.Text = "EXTERNAL APPLICATION- SPONSORED";
                            break;
                        default:
                            APPREASON.Text = string.Empty;
                            break;
                    }
                    #endregion


                    if (SM.Value == "6" || SM.Value == "A" || SM.Value == "9")
                    {
                        if (enProfile.SelectSingleNode("ENROLDATE") != null)
                            ENROLDATE.Text = Common.DayMonthYearDisplay(enProfile.SelectSingleNode("ENROLDATE").InnerText);
                    }
                    else
                        ENROLDATE.Text = DateTime.Now.ToString("dd/MM/yyyy");


                    ShowPhoto(enProfile.SelectSingleNode(DOCTYPE.ID).InnerText);
                    HideInfo(enProfile.SelectSingleNode(DOCTYPE.ID).InnerText);
                    #endregion
                }
                else
                    Response.Redirect("Logon.aspx");
            }

            catch (Exception ex)
            {
                lblError.Visible = true;
                lblError.Text = ex.Message;
            }

            #endregion
        }

        private void ShowPhoto(string pType)
        {
            #region ***
            if (Request.QueryString["sm"] == Common.COMPLETEENROLECODE || Request.QueryString["sm"] == Common.UPDATEPROFILECODE || Request.QueryString["sm"] == Common.GetValue("ExternalDEStage"))
            {
                lblPhoto.Visible = true;
                FACEIMAGE.Visible = true;

            }
            else
            {
                lblPhoto.Visible = false;
                FACEIMAGE.Visible = false;

            }
            #endregion
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            #region ***
            try
            {
                string fileName = @Server.MapPath("") + Common.GetValue("xmlServerPath") + Request.QueryString["done"] + ".xml";
                if (Request.QueryString["sm"] == Common.COMPLETEENROLECODE || Request.QueryString["sm"] == Common.UPDATEPROFILECODE || Request.QueryString["sm"] == Common.GetValue("ExternalDEStage"))
                {
                    Response.Redirect(Common.RedirectToPage(pageId + 4, Request.QueryString["sm"]) + "&done=" + Request.QueryString["done"] + "&arrow=" + Request.QueryString["arrow"] + "&PC=" + Request.QueryString["PC"]);
                }
                else
                {
                    Response.Redirect(Common.RedirectToPage(pageId - 2, Request.QueryString["sm"]) + "&done=" + Request.QueryString["done"] + "&arrow=" + Request.QueryString["arrow"] + "&PC=" + Request.QueryString["PC"]);
                }

            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                lblError.Visible = false;

            }
            #endregion
        }

        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            #region ***
            try
            {

                if (SM.Value == Common.COMPLETEENROLECODE || SM.Value == Common.GetValue("ExternalDEStage"))
                {
                    SubmitComplete(IsNew.Value);

                }
                else if (SM.Value == Common.UPDATEPROFILECODE) //Data Entry
                {
                    UpdateProfile(IsNew.Value);
                }
                else
                {
                    //SubmitPartial(IsNew.Value);
                    ShowResult(IsNew.Value);
                }

            }
            catch (Exception ex)
            {
                lblError.Visible = true;
                lblError.Text = ex.Message;
            }
            #endregion
        }

        private void SubmitPartial(string fileName)
        {
            #region partial
            /*
        try
        {
            int id = new int();

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(fileName);

            XmlNode xmlRoot = xmlDoc.DocumentElement;
            XmlNode enrol = xmlRoot.SelectSingleNode("PAYLOAD/ENROLLMENT");
            XmlNode enProfile = xmlRoot.SelectSingleNode("PAYLOAD/ENROLLMENT/ENROLPROFILE");
            XmlNode bio = xmlRoot.SelectSingleNode("PAYLOAD/ENROLLMENT/BIO");
            XmlNode main = xmlRoot.SelectSingleNode("PAYLOAD/ENROLLMENT/MAIN");

            #region call web service
            enrollment.VISService pisservice = new enrollment.VISService();
            enrollment.RequestDataTypePartialEnrol partialen = new enrollment.RequestDataTypePartialEnrol();
            #endregion

            #region send requested data
            partialen.SessionKey = common.GetCookie(this.Page, "sessionKey");
            partialen.ActionDescription = "Partial Enrol";
            partialen.PermissionCode = common.GetValue("PartialEnrolCode");

            #region enrol
            partialen.EnrolBy = common.GetCookie(this.Page, "loginName");
            partialen.ApplicationID = enProfile.SelectSingleNode(FORMNO.ID).InnerText;
            partialen.AppReason = Convert.ToInt32(enProfile.SelectSingleNode("APPREASON").InnerText);
            partialen.DocType = enProfile.SelectSingleNode(DOCTYPE.ID).InnerText;
            partialen.EntryType = enProfile.SelectSingleNode(SUBDOCTYPE.ID).InnerText;
            partialen.EnrolLocationName = txtCompName.Value.Trim();
            partialen.Priority = Convert.ToInt32(enProfile.SelectSingleNode("PRIORITY").InnerText);
            #endregion

            #region main
            //if appreason = emergency or new application
            if (enProfile.SelectSingleNode(APPREASON.ID).InnerText == "1")
            {
                partialen.IDPerson = id;
            }
            else
            {
                partialen.IDPerson = Convert.ToInt32(enProfile.SelectSingleNode("IDPERSON").InnerText);
            }

            if (main.SelectSingleNode("NATIONALINSURANCENO").InnerText == string.Empty)
            {
                partialen.NationalIDNo = DBNull.Value.ToString();
            }
            else
            {
                partialen.NationalIDNo = main.SelectSingleNode("NATIONALINSURANCENO").InnerText;
            }

            partialen.Surname = main.SelectSingleNode("SURNAME").InnerText;
            partialen.FirstName = main.SelectSingleNode("FIRSTNAME").InnerText;
            partialen.MiddleName = main.SelectSingleNode("MIDDLENAME").InnerText;
            partialen.BirthCountry = main.SelectSingleNode("BIRTHCOUNTRY").InnerText;
            partialen.BirthDate = main.SelectSingleNode("BIRTHDATE").InnerText;
            partialen.Nationality = main.SelectSingleNode("NATIONALITY").InnerText;
            partialen.Sex = main.SelectSingleNode("SEX").InnerText;
            partialen.Title = main.SelectSingleNode("TITLE").InnerText;
            partialen.BirthPlace = main.SelectSingleNode("BIRTHPLACE").InnerText;


            #endregion

            #region bio

            partialen.Finger1Code = "L0";
            partialen.Finger1Reason = 1;
            partialen.Finger2Code = "R0";
            partialen.Finger2Reason = 1;
            partialen.SignReason = 1;

            byte[] F1Empty = new byte[0];
            partialen.Finger1Image = F1Empty;

            byte[] F2Empty = new byte[0];
            partialen.Finger2Image = F2Empty;           

            byte[] SignEmpty = new byte[0];
            partialen.SignImage = SignEmpty;
            
            #endregion

            #region Passport
            partialen.PassportCOI = main.SelectSingleNode("PASSPORTCOI").InnerText;
            partialen.PassportDOE = main.SelectSingleNode("PASSPORTDOE").InnerText;
            partialen.PassportNo = main.SelectSingleNode("PASSPORTNO").InnerText;
            partialen.PassportPOI = main.SelectSingleNode("PASSPORTPOI").InnerText;
            partialen.PassportDOI = main.SelectSingleNode("PASSPORTDOI").InnerText;
            #endregion

            partialen.CollectionDate = txtColDate.Text.Replace("/", "");


            #endregion

            #region response

            enrollment.ResponseDataTypePartialEnrol responseEnrol = pisservice.PartialEnrol(partialen);

            string statusCode = responseEnrol.StatusCode;
            string statusMsg = responseEnrol.StatusMessage;
            #endregion

            #region display status
            if (statusCode == "0")
                ShowResult(IsNew.Value);
            else
                throw new Exception(statusMsg);

            #endregion
        }
        catch (Exception ex)
        {
            lblError.Visible = true;
            lblError.Text = ex.Message;
        }
        */
            #endregion
        }

        private void SubmitComplete(string fileName)
        {
            #region complete

            try
            {

                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(fileName);

                XmlNode xmlRoot = xmlDoc.DocumentElement;
                XmlNode enrol = xmlRoot.SelectSingleNode("PAYLOAD/ENROLLMENT");
                XmlNode enProfile = xmlRoot.SelectSingleNode("PAYLOAD/ENROLLMENT/ENROLPROFILE");

                XmlNode main = xmlRoot.SelectSingleNode("PAYLOAD/ENROLLMENT/MAIN");
                XmlNode scan = xmlRoot.SelectSingleNode("PAYLOAD/ENROLLMENT/SCANNED");
                XmlNode contact = xmlRoot.SelectSingleNode("PAYLOAD/ENROLLMENT/CONTACT");
                XmlNode employ = xmlRoot.SelectSingleNode("PAYLOAD/ENROLLMENT/EMPLOYMENT");
                XmlNode family = xmlRoot.SelectSingleNode("PAYLOAD/ENROLLMENT/FAMILY");
                XmlNode travel = xmlRoot.SelectSingleNode("PAYLOAD/ENROLLMENT/TRAVEL");
                XmlNode additional = xmlRoot.SelectSingleNode("PAYLOAD/ENROLLMENT/ADDITIONAL");


                EMService pisservice = new EMService();
                RequestDataTypeDataEntry completeEn = new RequestDataTypeDataEntry();

                completeEn.SessionKey = Common.GetCookie(this.Page, "sessionKey");
                completeEn.ActionDescription = "Complete Enrol";
                completeEn.PermissionCode = Common.GetValue("CompleteEnrol");


                #region enrol- 10
                completeEn.ApplicationID = enProfile.SelectSingleNode(FORMNO.ID).InnerText;
                completeEn.AppReason = Convert.ToInt32(enProfile.SelectSingleNode("APPREASON").InnerText);
                completeEn.DocType = enProfile.SelectSingleNode("DOCTYPE").InnerText;
                completeEn.EntryType = enProfile.SelectSingleNode("SUBDOCTYPE").InnerText;
                completeEn.EnrolLocationName = txtCompName.Value.Trim();
                completeEn.Priority = Convert.ToInt32(enProfile.SelectSingleNode("PRIORITY").InnerText);
                completeEn.EnrolCompletedBy = Common.GetCookie(this.Page, "loginName");

                #endregion

                #region main- 15 
                completeEn.NationalIDNo = main.SelectSingleNode("NATIONALINSURANCENO").InnerText;
                completeEn.Surname = main.SelectSingleNode("SURNAME").InnerText;
                completeEn.FirstName = main.SelectSingleNode("FIRSTNAME").InnerText;
                completeEn.MiddleName = main.SelectSingleNode("MIDDLENAME").InnerText;
                completeEn.BirthCountry = main.SelectSingleNode("BIRTHCOUNTRY").InnerText;
                completeEn.BirthDate = main.SelectSingleNode("BIRTHDATE").InnerText;
                completeEn.Nationality = main.SelectSingleNode("NATIONALITY").InnerText;
                completeEn.Sex = main.SelectSingleNode("SEX").InnerText;
                completeEn.Title = main.SelectSingleNode("TITLE").InnerText;
                completeEn.BirthPlace = main.SelectSingleNode("BIRTHPLACE").InnerText;
                completeEn.PassportCOI = main.SelectSingleNode("PASSPORTCOI").InnerText;
                completeEn.PassportDOE = main.SelectSingleNode("PASSPORTDOE").InnerText;
                completeEn.PassportDOI = main.SelectSingleNode("PASSPORTDOI").InnerText;
                completeEn.PassportNo = main.SelectSingleNode("PASSPORTNO").InnerText;
                completeEn.PassportPOI = main.SelectSingleNode("PASSPORTPOI").InnerText;

                #endregion                      

                #region CONTACT - 7
                completeEn.PermanentAddress = contact.SelectSingleNode("PERMANENTADDRESS").InnerText;
                completeEn.PresentAddress = contact.SelectSingleNode("PRESENTADDRESS").InnerText;
                completeEn.PhoneHome = contact.SelectSingleNode("PHONEHOME").InnerText;
                completeEn.PhoneWork = contact.SelectSingleNode("PHONEWORK").InnerText;
                completeEn.Email = contact.SelectSingleNode("EMAIL").InnerText;
                completeEn.Fax = contact.SelectSingleNode("FAX").InnerText;
                completeEn.Mobile = contact.SelectSingleNode("MOBILE").InnerText;
                completeEn.EGContactAddress = contact.SelectSingleNode("EGCONTACTADDRESS").InnerText;
                completeEn.EGContactName = contact.SelectSingleNode("EGCONTACTNAME").InnerText;
                completeEn.EGContactPhone = contact.SelectSingleNode("EGCONTACTPHONE").InnerText;
                completeEn.EGContactRelationship = contact.SelectSingleNode("EGCONTACTRELATIONSHIP").InnerText;
                #endregion

                #region EMPLOYER-10
                completeEn.EmployerAddress = employ.SelectSingleNode("EMPLOYERADDRESS").InnerText;
                completeEn.EmployerName = employ.SelectSingleNode("EMPLOYERNAME").InnerText;
                completeEn.EmployerPhone = employ.SelectSingleNode("EMPLOYERPHONE").InnerText;
                if (employ.SelectSingleNode("YEARSEMPLOYED").InnerText != string.Empty)
                    completeEn.YearsEmployed = Convert.ToInt32(employ.SelectSingleNode("YEARSEMPLOYED").InnerText);
                else
                    completeEn.YearsEmployed = 0;
                completeEn.Occupation = employ.SelectSingleNode("OCCUPATION").InnerText;
                completeEn.FormerEmployerAddress = employ.SelectSingleNode("FORMEREMPLOYERADDRESS").InnerText;
                completeEn.FormerEmployerName = employ.SelectSingleNode("FORMEREMPLOYERNAME").InnerText;
                completeEn.FormerEmployerPhone = employ.SelectSingleNode("FORMEREMPLOYERPHONE").InnerText;
                if (employ.SelectSingleNode("FORMERYEARSEMPLOYED").InnerText != string.Empty)
                    completeEn.FormerYearsEmployed = Convert.ToInt32(employ.SelectSingleNode("FORMERYEARSEMPLOYED").InnerText);
                else
                    completeEn.FormerYearsEmployed = 0;
                completeEn.FormerOccupation = employ.SelectSingleNode("FORMEROCCUPATION").InnerText;

                #endregion

                #region FATHER - 4
                if (family.SelectSingleNode("MARITALSTATUS").InnerText != string.Empty)
                    completeEn.MaritalStatus = Convert.ToInt32(family.SelectSingleNode("MARITALSTATUS").InnerText);
                else
                    completeEn.MaritalStatus = 0;
                completeEn.FatherFirstName = family.SelectSingleNode("FATHERFIRSTNAME").InnerText;
                completeEn.FatherLastName = family.SelectSingleNode("FATHERLASTNAME").InnerText;
                completeEn.FatherMiddleName = family.SelectSingleNode("FATHERMIDDLENAME").InnerText;
                completeEn.FatherNationality = family.SelectSingleNode("FATHERNATIONALITY").InnerText;
                #endregion

                #region MOTHER -4
                completeEn.MotherLastName = family.SelectSingleNode("MOTHERLASTNAME").InnerText;
                completeEn.MotherMiddleName = family.SelectSingleNode("MOTHERMIDDLENAME").InnerText;
                completeEn.MotherFirstName = family.SelectSingleNode("MOTHERFIRSTNAME").InnerText;
                completeEn.MotherNationality = family.SelectSingleNode("MOTHERNATIONALITY").InnerText;
                #endregion

                #region SPOUSE - 7
                completeEn.SpouseLastName = family.SelectSingleNode("SPOUSELASTNAME").InnerText;
                completeEn.SpouseMiddleName = family.SelectSingleNode("SPOUSEMIDDLENAME").InnerText;
                completeEn.SpouseFirstName = family.SelectSingleNode("SPOUSEFIRSTNAME").InnerText;
                completeEn.SpouseMaidenName = family.SelectSingleNode("SPOUSEMAIDENNAME").InnerText;
                if (family.SelectSingleNode("SPOUSEDOB").InnerText == string.Empty)
                {
                    completeEn.SpouseDOB = null;
                }
                else
                {
                    completeEn.SpouseDOB = family.SelectSingleNode("SPOUSEDOB").InnerText;
                }
                if (family.SelectSingleNode("HASCHILDIND").InnerText != string.Empty)
                    completeEn.HasChildInd = Convert.ToInt32(family.SelectSingleNode("HASCHILDIND").InnerText);
                else
                    completeEn.HasChildInd = 0;

                if (family.SelectSingleNode("TRAVELWITHSPOUSEIND").InnerText != string.Empty)
                    completeEn.TravelWithSpouseInd = Convert.ToInt32(family.SelectSingleNode("TRAVELWITHSPOUSEIND").InnerText);
                else
                    completeEn.TravelWithSpouseInd = 0;

                #endregion

                #region DEPENDANT - 11
                completeEn.DependantName1 = family.SelectSingleNode("DEPENDANTNAME1").InnerText;
                completeEn.DependantName2 = family.SelectSingleNode("DEPENDANTNAME2").InnerText;
                completeEn.DependantName3 = family.SelectSingleNode("DEPENDANTNAME3").InnerText;
                completeEn.DependantName4 = family.SelectSingleNode("DEPENDANTNAME4").InnerText;
                completeEn.DependantName5 = family.SelectSingleNode("DEPENDANTNAME5").InnerText;

                completeEn.Relationship1 = family.SelectSingleNode("RELATIONSHIP1").InnerText;
                completeEn.Relationship2 = family.SelectSingleNode("RELATIONSHIP2").InnerText;
                completeEn.Relationship3 = family.SelectSingleNode("RELATIONSHIP3").InnerText;
                completeEn.Relationship4 = family.SelectSingleNode("RELATIONSHIP4").InnerText;
                completeEn.Relationship5 = family.SelectSingleNode("RELATIONSHIP5").InnerText;
                if (family.SelectSingleNode("TRAVELWITHDEPENDANTIND").InnerText != string.Empty)
                    completeEn.TravelWithDependantInd = Convert.ToInt32(family.SelectSingleNode("TRAVELWITHDEPENDANTIND").InnerText);
                else
                    completeEn.TravelWithDependantInd = 0;

                #endregion

                #region TRAVEL - 7

                completeEn.VisitPurpose = travel.SelectSingleNode("VISITPURPOSE").InnerText;
                completeEn.OtherVisitPurpose = travel.SelectSingleNode("OTHERVISITPURPOSE").InnerText;
                completeEn.LengthOfStay = travel.SelectSingleNode("LENGTHOFSTAY").InnerText;

                if (travel.SelectSingleNode("ARRIVALDATE").InnerText != string.Empty)
                    completeEn.ArrivalDate = travel.SelectSingleNode("ARRIVALDATE").InnerText;
                else
                    completeEn.ArrivalDate = null;

                completeEn.HotelAddress = travel.SelectSingleNode("HOTELADDRESS").InnerText;
                completeEn.HotelName = travel.SelectSingleNode("HOTELNAME").InnerText;
                completeEn.HotelPhone = travel.SelectSingleNode("HOTELPHONE").InnerText;
                completeEn.OtherVisitPurpose = travel.SelectSingleNode("OTHERVISITPURPOSE").InnerText;
                #endregion

                #region FINANCIAL - 2

                completeEn.TripMoney = additional.SelectSingleNode("TRIPMONEY").InnerText;
                completeEn.TripSponsorBy = additional.SelectSingleNode("TRIPSPONSORBY").InnerText;

                #endregion

                #region CRIMINAL - 23
                if (additional.SelectSingleNode("CRIMINALCONVICTIONIND").InnerText != string.Empty)
                    completeEn.CriminalConvictionInd = Convert.ToInt32(additional.SelectSingleNode("CRIMINALCONVICTIONIND").InnerText);
                else
                    completeEn.CriminalConvictionInd = 0;

                completeEn.Offence1 = additional.SelectSingleNode("OFFENCE1").InnerText;
                completeEn.Offence2 = additional.SelectSingleNode("OFFENCE2").InnerText;
                completeEn.Offence3 = additional.SelectSingleNode("OFFENCE3").InnerText;
                completeEn.Offence4 = additional.SelectSingleNode("OFFENCE4").InnerText;
                completeEn.Offence5 = additional.SelectSingleNode("OFFENCE5").InnerText;
                if (additional.SelectSingleNode("OFFENCEDATE1").InnerText != string.Empty)
                    completeEn.OffenceDate1 = additional.SelectSingleNode("OFFENCEDATE1").InnerText;
                else
                    completeEn.OffenceDate1 = null;

                if (additional.SelectSingleNode("OFFENCEDATE2").InnerText != string.Empty)
                    completeEn.OffenceDate2 = additional.SelectSingleNode("OFFENCEDATE2").InnerText;
                else
                    completeEn.OffenceDate2 = null;

                if (additional.SelectSingleNode("OFFENCEDATE3").InnerText != string.Empty)
                    completeEn.OffenceDate3 = additional.SelectSingleNode("OFFENCEDATE3").InnerText;
                else
                    completeEn.OffenceDate3 = null;

                if (additional.SelectSingleNode("OFFENCEDATE4").InnerText != string.Empty)
                    completeEn.OffenceDate4 = additional.SelectSingleNode("OFFENCEDATE4").InnerText;
                else
                    completeEn.OffenceDate4 = null;

                if (additional.SelectSingleNode("OFFENCEDATE5").InnerText != string.Empty)
                    completeEn.OffenceDate5 = additional.SelectSingleNode("OFFENCEDATE5").InnerText;
                else
                    completeEn.OffenceDate5 = null;

                completeEn.OffencePenalty1 = additional.SelectSingleNode("OFFENCEPENALTY1").InnerText;
                completeEn.OffencePenalty2 = additional.SelectSingleNode("OFFENCEPENALTY2").InnerText;
                completeEn.OffencePenalty3 = additional.SelectSingleNode("OFFENCEPENALTY3").InnerText;
                completeEn.OffencePenalty4 = additional.SelectSingleNode("OFFENCEPENALTY4").InnerText;
                completeEn.OffencePenalty5 = additional.SelectSingleNode("OFFENCEPENALTY5").InnerText;

                completeEn.OffencePlace1 = additional.SelectSingleNode("OFFENCEPLACE1").InnerText;
                completeEn.OffencePlace2 = additional.SelectSingleNode("OFFENCEPLACE2").InnerText;
                completeEn.OffencePlace3 = additional.SelectSingleNode("OFFENCEPLACE3").InnerText;
                completeEn.OffencePlace4 = additional.SelectSingleNode("OFFENCEPLACE4").InnerText;
                completeEn.OffencePlace5 = additional.SelectSingleNode("OFFENCEPLACE5").InnerText;

                completeEn.TerrorismDesc = additional.SelectSingleNode("TERRORISMDESC").InnerText;
                if (additional.SelectSingleNode("TERRORISMIND").InnerText != string.Empty)
                    completeEn.TerrorismInd = Convert.ToInt32(additional.SelectSingleNode("TERRORISMIND").InnerText);
                else
                    completeEn.TerrorismInd = 0;


                #endregion

                #region ADDITIONAL - 10

                completeEn.FatherResidentialStatus = additional.SelectSingleNode("FATHERRESIDENTIALSTATUS").InnerText;
                completeEn.MotherResidentialStatus = additional.SelectSingleNode("MOTHERRESIDENTIALSTATUS").InnerText;
                completeEn.SiblingResidentialStatus = additional.SelectSingleNode("SIBLINGRESIDENTIALSTATUS").InnerText;
                completeEn.ChildrenResidentialStatus = additional.SelectSingleNode("CHILDRENRESIDENTIALSTATUS").InnerText;
                completeEn.SpouseResidentialStatus = additional.SelectSingleNode("SPOUSERESIDENTIALSTATUS").InnerText;

                if (additional.SelectSingleNode("SPOUSEINBHSIND").InnerText != string.Empty)
                    completeEn.SpouseInBhsInd = Convert.ToInt32(additional.SelectSingleNode("SPOUSEINBHSIND").InnerText);
                else
                    completeEn.SpouseInBhsInd = 0;

                if (additional.SelectSingleNode("MOTHERINBHSIND").InnerText != string.Empty)
                    completeEn.MotherInBhsInd = Convert.ToInt32(additional.SelectSingleNode("MOTHERINBHSIND").InnerText);
                else
                    completeEn.MotherInBhsInd = 0;

                if (additional.SelectSingleNode("FATHERINBHSIND").InnerText != string.Empty)
                    completeEn.FatherInBhsInd = Convert.ToInt32(additional.SelectSingleNode("FATHERINBHSIND").InnerText);
                else
                    completeEn.FatherInBhsInd = 0;

                if (additional.SelectSingleNode("SIBLINGINBHSIND").InnerText != string.Empty)
                    completeEn.SiblingInBhsInd = Convert.ToInt32(additional.SelectSingleNode("SIBLINGINBHSIND").InnerText);
                else
                    completeEn.SiblingInBhsInd = 0;

                if (additional.SelectSingleNode("CHILDRENINBHSIND").InnerText != string.Empty)
                    completeEn.ChildrenInBhsInd = Convert.ToInt32(additional.SelectSingleNode("CHILDRENINBHSIND").InnerText);
                else
                    completeEn.ChildrenInBhsInd = 0;


                completeEn.AppliedVisaDate = additional.SelectSingleNode("APPLIEDVISADATE").InnerText;
                if (additional.SelectSingleNode("APPLIEDVISAIND").InnerText != string.Empty)
                    completeEn.AppliedVisaInd = Convert.ToInt32(additional.SelectSingleNode("APPLIEDVISAIND").InnerText);
                else
                    completeEn.AppliedVisaInd = 0;

                completeEn.AppliedVisaPlace = additional.SelectSingleNode("APPLIEDVISAPLACE").InnerText;
                if (additional.SelectSingleNode("VISITEDBHSIND").InnerText != string.Empty)
                    completeEn.VisitedBhsInd = Convert.ToInt32(additional.SelectSingleNode("VISITEDBHSIND").InnerText);
                else
                    completeEn.VisitedBhsInd = 0;

                completeEn.LastVisitDate = additional.SelectSingleNode("LASTVISITDATE").InnerText;
                completeEn.VisaOutcome = additional.SelectSingleNode("VISAOUTCOME").InnerText;
                if (additional.SelectSingleNode("DEPORTEDIND").InnerText != string.Empty)
                    completeEn.DeportedInd = Convert.ToInt32(additional.SelectSingleNode("DEPORTEDIND").InnerText);
                else
                    completeEn.DeportedInd = 0;
                #endregion          

                #region Photo - 7

                if (scan.SelectSingleNode("FACEIMAGE").InnerText != string.Empty)
                {
                    completeEn.FaceImage = System.Convert.FromBase64String(scan.SelectSingleNode("FACEIMAGE").InnerText);
                }
                else
                {
                    completeEn.FaceImage = null;
                }
                if (scan.SelectSingleNode("FACEIMAGEJ2K").InnerText != string.Empty)
                {
                    completeEn.FaceImageJ2K = System.Convert.FromBase64String(scan.SelectSingleNode("FACEIMAGEJ2K").InnerText);
                }
                else
                {
                    completeEn.FaceImageJ2K = null;
                }




                #endregion


                ResponseDataTypeDataEntry responseEnrol = pisservice.CompleteEnrol(completeEn);

                string statusCode = responseEnrol.StatusCode;
                string statusMsg = responseEnrol.StatusMessage;


                if (statusCode == "0")
                {
                    //Display the transaction completed message
                    File.Delete(fileName);
                    lblSuccess.Text = "Enrollment completed successfully!";
                    lblError.Visible = false;
                    lblSuccess.Visible = true;
                    btn_Submit.Visible = false;
                    btnPrint.Visible = false;
                    btnBack.Visible = false;

                    if (APPREASONID.Value == Common.GetValue("ExternalSponsored"))
                        CheckPaymentPermission();
                    else
                        CheckApprovalPermission();
                }

                else
                {
                    throw new Exception(statusMsg);

                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                lblError.Visible = true;
                Common.WriteLog(@Server.MapPath("") + Common.GetValue("logPath"), "Complete Data Entry: - " + ex.Message);
            }

            #endregion
        }
        private void CheckEnrolType(string type)
        {
            #region ***

            if (type == Common.COMPLETEENROLECODE || type == Common.UPDATEPROFILECODE || type == Common.GetValue("ExternalDEStage") || type == Common.GetValue("UpdateProfileEnroll"))
            {
                trColDate.Visible = false;
                btnBack.Visible = true;

            }
            else
            {
                trColDate.Visible = true;
            }
            if (type == "1" || type == "2")
            {
                ShowResult(IsNew.Value);
                CheckPaymentPermission();
            }
            else if (type == Common.GetValue("UpdateProfileEnroll"))
            {
                ShowResult(IsNew.Value);
                lblSuccess.Text = "Update profile completed successfully!";
                btnPrint.Visible = false;
            }
            #endregion
        }

        private void HideInfo(string pType)
        {
            #region***

            trNIS.Visible = true;
            trAppReason.Visible = true;


            #endregion
        }
        private void ShowResult(string fileName)
        {
            #region ***
            try
            {

                File.Delete(fileName);
                lblSuccess.Text = "Enrollment completed successfully! Please give the collection slip to the applicant.";
                lblError.Visible = false;
                lblSuccess.Visible = true;
                btn_Submit.Visible = false;
                btnPrint.Visible = true;
                btnBack.Visible = false;

            }
            catch (Exception ex)
            {
                lblError.Visible = true;
                lblError.Text = ex.Message;
            }

            #endregion
        }
        private void getBranchName()
        {
            #region ***
            try
            {

                #region calling web service
                EMService enrol = new EMService();
                RequestDataTypeGetBranchName reqData = new RequestDataTypeGetBranchName();

                reqData.ActionDescription = "Get Brach Name";
                reqData.PermissionCode = Common.GetValue("SelectBranch");
                reqData.SessionKey = Common.GetCookie(this.Page, "sessionKey");
                reqData.EnrolLocationName = txtCompName.Value;

                #endregion

                #region response the request
                ResponseDataTypeGetBranchName responseData = enrol.GetBranchName(reqData);

                string statusCode = responseData.StatusCode;
                string statusMsg = responseData.StatusMessage;

                if (statusCode == "0")
                {
                    branch.Text = responseData.BranchName;
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
                Common.WriteLog(@Server.MapPath("") + Common.GetValue("logPath"), "getBranchName(): - " + ex.Message);
            }
            #endregion
        }
        private void UpdateProfile(string fileName)
        {
            #region Update profile - data entry

            try
            {

                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(fileName);

                XmlNode xmlRoot = xmlDoc.DocumentElement;
                XmlNode enrol = xmlRoot.SelectSingleNode("PAYLOAD/ENROLLMENT");
                XmlNode enProfile = xmlRoot.SelectSingleNode("PAYLOAD/ENROLLMENT/ENROLPROFILE");
                XmlNode main = xmlRoot.SelectSingleNode("PAYLOAD/ENROLLMENT/MAIN");
                XmlNode scan = xmlRoot.SelectSingleNode("PAYLOAD/ENROLLMENT/SCANNED");
                XmlNode contact = xmlRoot.SelectSingleNode("PAYLOAD/ENROLLMENT/CONTACT");
                XmlNode employ = xmlRoot.SelectSingleNode("PAYLOAD/ENROLLMENT/EMPLOYMENT");
                XmlNode family = xmlRoot.SelectSingleNode("PAYLOAD/ENROLLMENT/FAMILY");
                XmlNode travel = xmlRoot.SelectSingleNode("PAYLOAD/ENROLLMENT/TRAVEL");
                XmlNode additional = xmlRoot.SelectSingleNode("PAYLOAD/ENROLLMENT/ADDITIONAL");


                EMService pisservice = new EMService();
                RequestDataTypeDataEntry completeEn = new RequestDataTypeDataEntry();

                completeEn.SessionKey = Common.GetCookie(this.Page, "sessionKey");
                completeEn.ActionDescription = "Update Profile Data Entry";
                completeEn.PermissionCode = Common.GetValue("UpdateProfile");


                #region enrol- 10
                completeEn.ApplicationID = enProfile.SelectSingleNode(FORMNO.ID).InnerText;
                completeEn.AppReason = Convert.ToInt32(enProfile.SelectSingleNode("APPREASON").InnerText);
                completeEn.DocType = enProfile.SelectSingleNode("DOCTYPE").InnerText;
                completeEn.EntryType = enProfile.SelectSingleNode("SUBDOCTYPE").InnerText;
                completeEn.EnrolLocationName = txtCompName.Value.Trim();
                completeEn.Priority = Convert.ToInt32(enProfile.SelectSingleNode("PRIORITY").InnerText);
                completeEn.EnrolCompletedBy = Common.GetCookie(this.Page, "loginName");

                #endregion

                #region main- 15
                completeEn.NationalIDNo = main.SelectSingleNode("NATIONALINSURANCENO").InnerText;
                completeEn.Surname = main.SelectSingleNode("SURNAME").InnerText;
                completeEn.FirstName = main.SelectSingleNode("FIRSTNAME").InnerText;
                completeEn.MiddleName = main.SelectSingleNode("MIDDLENAME").InnerText;
                completeEn.BirthCountry = main.SelectSingleNode("BIRTHCOUNTRY").InnerText;
                completeEn.BirthDate = main.SelectSingleNode("BIRTHDATE").InnerText;
                completeEn.Nationality = main.SelectSingleNode("NATIONALITY").InnerText;
                completeEn.Sex = main.SelectSingleNode("SEX").InnerText;
                completeEn.Title = main.SelectSingleNode("TITLE").InnerText;
                completeEn.BirthPlace = main.SelectSingleNode("BIRTHPLACE").InnerText;
                completeEn.PassportCOI = main.SelectSingleNode("PASSPORTCOI").InnerText;
                completeEn.PassportDOE = main.SelectSingleNode("PASSPORTDOE").InnerText;
                completeEn.PassportDOI = main.SelectSingleNode("PASSPORTDOI").InnerText;
                completeEn.PassportNo = main.SelectSingleNode("PASSPORTNO").InnerText;
                completeEn.PassportPOI = main.SelectSingleNode("PASSPORTPOI").InnerText;

                #endregion

                #region CONTACT - 7
                completeEn.PermanentAddress = contact.SelectSingleNode("PERMANENTADDRESS").InnerText;
                completeEn.PresentAddress = contact.SelectSingleNode("PRESENTADDRESS").InnerText;
                completeEn.PhoneHome = contact.SelectSingleNode("PHONEHOME").InnerText;
                completeEn.PhoneWork = contact.SelectSingleNode("PHONEWORK").InnerText;
                completeEn.Email = contact.SelectSingleNode("EMAIL").InnerText;
                completeEn.Fax = contact.SelectSingleNode("FAX").InnerText;
                completeEn.Mobile = contact.SelectSingleNode("MOBILE").InnerText;
                completeEn.EGContactAddress = contact.SelectSingleNode("EGCONTACTADDRESS").InnerText;
                completeEn.EGContactName = contact.SelectSingleNode("EGCONTACTNAME").InnerText;
                completeEn.EGContactPhone = contact.SelectSingleNode("EGCONTACTPHONE").InnerText;
                completeEn.EGContactRelationship = contact.SelectSingleNode("EGCONTACTRELATIONSHIP").InnerText;
                #endregion

                #region EMPLOYER-10
                completeEn.EmployerAddress = employ.SelectSingleNode("EMPLOYERADDRESS").InnerText;
                completeEn.EmployerName = employ.SelectSingleNode("EMPLOYERNAME").InnerText;
                completeEn.EmployerPhone = employ.SelectSingleNode("EMPLOYERPHONE").InnerText;
                if (employ.SelectSingleNode("YEARSEMPLOYED").InnerText != string.Empty)
                    completeEn.YearsEmployed = Convert.ToInt32(employ.SelectSingleNode("YEARSEMPLOYED").InnerText);
                else
                    completeEn.YearsEmployed = 0;
                completeEn.Occupation = employ.SelectSingleNode("OCCUPATION").InnerText;
                completeEn.FormerEmployerAddress = employ.SelectSingleNode("FORMEREMPLOYERADDRESS").InnerText;
                completeEn.FormerEmployerName = employ.SelectSingleNode("FORMEREMPLOYERNAME").InnerText;
                completeEn.FormerEmployerPhone = employ.SelectSingleNode("FORMEREMPLOYERPHONE").InnerText;
                if (employ.SelectSingleNode("FORMERYEARSEMPLOYED").InnerText != string.Empty)
                    completeEn.FormerYearsEmployed = Convert.ToInt32(employ.SelectSingleNode("FORMERYEARSEMPLOYED").InnerText);
                else
                    completeEn.FormerYearsEmployed = 0;
                completeEn.FormerOccupation = employ.SelectSingleNode("FORMEROCCUPATION").InnerText;

                #endregion

                #region FATHER - 4
                if (family.SelectSingleNode("MARITALSTATUS").InnerText != string.Empty)
                    completeEn.MaritalStatus = Convert.ToInt32(family.SelectSingleNode("MARITALSTATUS").InnerText);
                else
                    completeEn.MaritalStatus = 0;
                completeEn.FatherFirstName = family.SelectSingleNode("FATHERFIRSTNAME").InnerText;
                completeEn.FatherLastName = family.SelectSingleNode("FATHERLASTNAME").InnerText;
                completeEn.FatherMiddleName = family.SelectSingleNode("FATHERMIDDLENAME").InnerText;
                completeEn.FatherNationality = family.SelectSingleNode("FATHERNATIONALITY").InnerText;
                #endregion

                #region MOTHER -4
                completeEn.MotherLastName = family.SelectSingleNode("MOTHERLASTNAME").InnerText;
                completeEn.MotherMiddleName = family.SelectSingleNode("MOTHERMIDDLENAME").InnerText;
                completeEn.MotherFirstName = family.SelectSingleNode("MOTHERFIRSTNAME").InnerText;
                completeEn.MotherNationality = family.SelectSingleNode("MOTHERNATIONALITY").InnerText;
                #endregion

                #region SPOUSE - 7
                completeEn.SpouseLastName = family.SelectSingleNode("SPOUSELASTNAME").InnerText;
                completeEn.SpouseMiddleName = family.SelectSingleNode("SPOUSEMIDDLENAME").InnerText;
                completeEn.SpouseFirstName = family.SelectSingleNode("SPOUSEFIRSTNAME").InnerText;
                completeEn.SpouseMaidenName = family.SelectSingleNode("SPOUSEMAIDENNAME").InnerText;
                if (family.SelectSingleNode("SPOUSEDOB").InnerText == string.Empty)
                {
                    completeEn.SpouseDOB = null;
                }
                else
                {
                    completeEn.SpouseDOB = family.SelectSingleNode("SPOUSEDOB").InnerText;
                }
                if (family.SelectSingleNode("HASCHILDIND").InnerText != string.Empty)
                    completeEn.HasChildInd = Convert.ToInt32(family.SelectSingleNode("HASCHILDIND").InnerText);
                else
                    completeEn.HasChildInd = 0;

                if (family.SelectSingleNode("TRAVELWITHSPOUSEIND").InnerText != string.Empty)
                    completeEn.TravelWithSpouseInd = Convert.ToInt32(family.SelectSingleNode("TRAVELWITHSPOUSEIND").InnerText);
                else
                    completeEn.TravelWithSpouseInd = 0;

                #endregion

                #region DEPENDANT - 11
                completeEn.DependantName1 = family.SelectSingleNode("DEPENDANTNAME1").InnerText;
                completeEn.DependantName2 = family.SelectSingleNode("DEPENDANTNAME2").InnerText;
                completeEn.DependantName3 = family.SelectSingleNode("DEPENDANTNAME3").InnerText;
                completeEn.DependantName4 = family.SelectSingleNode("DEPENDANTNAME4").InnerText;
                completeEn.DependantName5 = family.SelectSingleNode("DEPENDANTNAME5").InnerText;

                completeEn.Relationship1 = family.SelectSingleNode("RELATIONSHIP1").InnerText;
                completeEn.Relationship2 = family.SelectSingleNode("RELATIONSHIP2").InnerText;
                completeEn.Relationship3 = family.SelectSingleNode("RELATIONSHIP3").InnerText;
                completeEn.Relationship4 = family.SelectSingleNode("RELATIONSHIP4").InnerText;
                completeEn.Relationship5 = family.SelectSingleNode("RELATIONSHIP5").InnerText;
                if (family.SelectSingleNode("TRAVELWITHDEPENDANTIND").InnerText != string.Empty)
                    completeEn.TravelWithDependantInd = Convert.ToInt32(family.SelectSingleNode("TRAVELWITHDEPENDANTIND").InnerText);
                else
                    completeEn.TravelWithDependantInd = 0;

                #endregion

                #region TRAVEL - 7

                completeEn.VisitPurpose = travel.SelectSingleNode("VISITPURPOSE").InnerText;
                completeEn.OtherVisitPurpose = travel.SelectSingleNode("OTHERVISITPURPOSE").InnerText;
                completeEn.LengthOfStay = travel.SelectSingleNode("LENGTHOFSTAY").InnerText;

                if (travel.SelectSingleNode("ARRIVALDATE").InnerText != string.Empty)
                    completeEn.ArrivalDate = travel.SelectSingleNode("ARRIVALDATE").InnerText;
                else
                    completeEn.ArrivalDate = null;

                completeEn.HotelAddress = travel.SelectSingleNode("HOTELADDRESS").InnerText;
                completeEn.HotelName = travel.SelectSingleNode("HOTELNAME").InnerText;
                completeEn.HotelPhone = travel.SelectSingleNode("HOTELPHONE").InnerText;
                completeEn.OtherVisitPurpose = travel.SelectSingleNode("OTHERVISITPURPOSE").InnerText;
                #endregion

                #region FINANCIAL - 2

                completeEn.TripMoney = additional.SelectSingleNode("TRIPMONEY").InnerText;
                completeEn.TripSponsorBy = additional.SelectSingleNode("TRIPSPONSORBY").InnerText;

                #endregion

                #region CRIMINAL - 23
                if (additional.SelectSingleNode("CRIMINALCONVICTIONIND").InnerText != string.Empty)
                    completeEn.CriminalConvictionInd = Convert.ToInt32(additional.SelectSingleNode("CRIMINALCONVICTIONIND").InnerText);
                else
                    completeEn.CriminalConvictionInd = 0;

                completeEn.Offence1 = additional.SelectSingleNode("OFFENCE1").InnerText;
                completeEn.Offence2 = additional.SelectSingleNode("OFFENCE2").InnerText;
                completeEn.Offence3 = additional.SelectSingleNode("OFFENCE3").InnerText;
                completeEn.Offence4 = additional.SelectSingleNode("OFFENCE4").InnerText;
                completeEn.Offence5 = additional.SelectSingleNode("OFFENCE5").InnerText;
                if (additional.SelectSingleNode("OFFENCEDATE1").InnerText != string.Empty)
                    completeEn.OffenceDate1 = additional.SelectSingleNode("OFFENCEDATE1").InnerText;
                else
                    completeEn.OffenceDate1 = null;

                if (additional.SelectSingleNode("OFFENCEDATE2").InnerText != string.Empty)
                    completeEn.OffenceDate2 = additional.SelectSingleNode("OFFENCEDATE2").InnerText;
                else
                    completeEn.OffenceDate2 = null;

                if (additional.SelectSingleNode("OFFENCEDATE3").InnerText != string.Empty)
                    completeEn.OffenceDate3 = additional.SelectSingleNode("OFFENCEDATE3").InnerText;
                else
                    completeEn.OffenceDate3 = null;

                if (additional.SelectSingleNode("OFFENCEDATE4").InnerText != string.Empty)
                    completeEn.OffenceDate4 = additional.SelectSingleNode("OFFENCEDATE4").InnerText;
                else
                    completeEn.OffenceDate4 = null;

                if (additional.SelectSingleNode("OFFENCEDATE5").InnerText != string.Empty)
                    completeEn.OffenceDate5 = additional.SelectSingleNode("OFFENCEDATE5").InnerText;
                else
                    completeEn.OffenceDate5 = null;

                completeEn.OffencePenalty1 = additional.SelectSingleNode("OFFENCEPENALTY1").InnerText;
                completeEn.OffencePenalty2 = additional.SelectSingleNode("OFFENCEPENALTY2").InnerText;
                completeEn.OffencePenalty3 = additional.SelectSingleNode("OFFENCEPENALTY3").InnerText;
                completeEn.OffencePenalty4 = additional.SelectSingleNode("OFFENCEPENALTY4").InnerText;
                completeEn.OffencePenalty5 = additional.SelectSingleNode("OFFENCEPENALTY5").InnerText;

                completeEn.OffencePlace1 = additional.SelectSingleNode("OFFENCEPLACE1").InnerText;
                completeEn.OffencePlace2 = additional.SelectSingleNode("OFFENCEPLACE2").InnerText;
                completeEn.OffencePlace3 = additional.SelectSingleNode("OFFENCEPLACE3").InnerText;
                completeEn.OffencePlace4 = additional.SelectSingleNode("OFFENCEPLACE4").InnerText;
                completeEn.OffencePlace5 = additional.SelectSingleNode("OFFENCEPLACE5").InnerText;

                completeEn.TerrorismDesc = additional.SelectSingleNode("TERRORISMDESC").InnerText;
                if (additional.SelectSingleNode("TERRORISMIND").InnerText != string.Empty)
                    completeEn.TerrorismInd = Convert.ToInt32(additional.SelectSingleNode("TERRORISMIND").InnerText);
                else
                    completeEn.TerrorismInd = 0;


                #endregion

                #region ADDITIONAL - 10

                completeEn.FatherResidentialStatus = additional.SelectSingleNode("FATHERRESIDENTIALSTATUS").InnerText;
                completeEn.MotherResidentialStatus = additional.SelectSingleNode("MOTHERRESIDENTIALSTATUS").InnerText;
                completeEn.SiblingResidentialStatus = additional.SelectSingleNode("SIBLINGRESIDENTIALSTATUS").InnerText;
                completeEn.ChildrenResidentialStatus = additional.SelectSingleNode("CHILDRENRESIDENTIALSTATUS").InnerText;
                completeEn.SpouseResidentialStatus = additional.SelectSingleNode("SPOUSERESIDENTIALSTATUS").InnerText;

                if (additional.SelectSingleNode("SPOUSEINBHSIND").InnerText != string.Empty)
                    completeEn.SpouseInBhsInd = Convert.ToInt32(additional.SelectSingleNode("SPOUSEINBHSIND").InnerText);
                else
                    completeEn.SpouseInBhsInd = 0;

                if (additional.SelectSingleNode("MOTHERINBHSIND").InnerText != string.Empty)
                    completeEn.MotherInBhsInd = Convert.ToInt32(additional.SelectSingleNode("MOTHERINBHSIND").InnerText);
                else
                    completeEn.MotherInBhsInd = 0;

                if (additional.SelectSingleNode("FATHERINBHSIND").InnerText != string.Empty)
                    completeEn.FatherInBhsInd = Convert.ToInt32(additional.SelectSingleNode("FATHERINBHSIND").InnerText);
                else
                    completeEn.FatherInBhsInd = 0;

                if (additional.SelectSingleNode("SIBLINGINBHSIND").InnerText != string.Empty)
                    completeEn.SiblingInBhsInd = Convert.ToInt32(additional.SelectSingleNode("SIBLINGINBHSIND").InnerText);
                else
                    completeEn.SiblingInBhsInd = 0;

                if (additional.SelectSingleNode("CHILDRENINBHSIND").InnerText != string.Empty)
                    completeEn.ChildrenInBhsInd = Convert.ToInt32(additional.SelectSingleNode("CHILDRENINBHSIND").InnerText);
                else
                    completeEn.ChildrenInBhsInd = 0;


                completeEn.AppliedVisaDate = additional.SelectSingleNode("APPLIEDVISADATE").InnerText;
                if (additional.SelectSingleNode("APPLIEDVISAIND").InnerText != string.Empty)
                    completeEn.AppliedVisaInd = Convert.ToInt32(additional.SelectSingleNode("APPLIEDVISAIND").InnerText);
                else
                    completeEn.AppliedVisaInd = 0;

                completeEn.AppliedVisaPlace = additional.SelectSingleNode("APPLIEDVISAPLACE").InnerText;
                if (additional.SelectSingleNode("VISITEDBHSIND").InnerText != string.Empty)
                    completeEn.VisitedBhsInd = Convert.ToInt32(additional.SelectSingleNode("VISITEDBHSIND").InnerText);
                else
                    completeEn.VisitedBhsInd = 0;

                completeEn.LastVisitDate = additional.SelectSingleNode("LASTVISITDATE").InnerText;
                completeEn.VisaOutcome = additional.SelectSingleNode("VISAOUTCOME").InnerText;
                if (additional.SelectSingleNode("DEPORTEDIND").InnerText != string.Empty)
                    completeEn.DeportedInd = Convert.ToInt32(additional.SelectSingleNode("DEPORTEDIND").InnerText);
                else
                    completeEn.DeportedInd = 0;
                #endregion

                #region Photo - 7

                if (scan.SelectSingleNode("FACEIMAGE").InnerText != string.Empty)
                {
                    completeEn.FaceImage = System.Convert.FromBase64String(scan.SelectSingleNode("FACEIMAGE").InnerText);
                }
                else
                {
                    completeEn.FaceImage = null;
                }
                if (scan.SelectSingleNode("FACEIMAGEJ2K").InnerText != string.Empty)
                {
                    completeEn.FaceImageJ2K = System.Convert.FromBase64String(scan.SelectSingleNode("FACEIMAGEJ2K").InnerText);
                }
                else
                {
                    completeEn.FaceImageJ2K = null;
                }




                #endregion         


                ResponseDataTypeDataEntry responseEnrol = pisservice.UpdateProfileDataEntry(completeEn);

                string statusCode = responseEnrol.StatusCode;
                string statusMsg = responseEnrol.StatusMessage;


                if (statusCode == "0")
                {
                    //Display the transaction completed message
                    File.Delete(fileName);
                    lblSuccess.Text = "Update profile completed successfully!";
                    lblError.Visible = false;
                    lblSuccess.Visible = true;
                    btn_Submit.Visible = false;
                    btnPrint.Visible = false;
                    btnBack.Visible = false;

                }
                else
                {
                    throw new Exception(statusMsg);
                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                lblError.Visible = true;
                Common.WriteLog(@Server.MapPath("") + Common.GetValue("logPath"), "UpdateProfile Data Entry: - " + ex.Message);
            }

            #endregion
        }
        #region Set Payment Button
        private void CheckPaymentPermission()
        {
            if (Common.GetCookie(this.Page, "ConfigLocation").Substring(1, 1) == "1" && Common.GetCookie(this.Page, "PaymentPermission") == "1")
            {
                string[] DocWaivedFee = Common.GetValue("DocWaivedFee").Split(',');

                btnPayment.Visible = true;
                foreach (string itm in DocWaivedFee)
                {
                    if (DOCTYPEID.Value == itm.Trim())
                    {
                        Common.SetCookie(this.Page, "PaymentWaived", "1");
                        btnPayment.Visible = false;
                        btnApproval.Visible = true;
                        return;
                    }
                }
            }
            else
            {
                Common.SetCookie(this.Page, "PaymentWaived", "0");
                btnPayment.Visible = false;
            }
        }

        protected void btnPayment_Click(object sender, EventArgs e)
        {
            Response.Redirect("PaymentDetails.aspx?arrow=21&sm=3" + "&done=" + FORMNO.Text + "&PC=" + txtCompName.Value);
        }
        #endregion

        #region Set Final Approval Button
        private void CheckApprovalPermission()
        {
            if (Common.GetCookie(this.Page, "ConfigLocation").Substring(2, 1) == "1" && Common.GetCookie(this.Page, "Permission").Substring(1, 1) == "1")
                btnApproval.Visible = true;
            else
                btnApproval.Visible = false;
        }

        protected void btnApproval_Click(object sender, EventArgs e)
        {
            if (Common.GetCookie(this.Page, "PaymentWaived") == "1" && (SM.Value == "1" || SM.Value == "2"))
            {
                //common.SetCookie(this.Page, "level", "1");            
                Response.Redirect("Approval.aspx?done=" + FORMNO.Text + "&sm=31&PCName=" + txtCompName.Value + "&level=1&arrow=31");
            }
            else
            {
                //common.SetCookie(this.Page, "level", "2");

                Response.Redirect("Approval.aspx?done=" + FORMNO.Text + "&sm=31&PCName=" + txtCompName.Value + "&level=2&arrow=32");
            }
        }
        #endregion
    }
}



