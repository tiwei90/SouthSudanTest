using EnrollmentIssuanceSite.DALMWS;
using EnrollmentIssuanceSite.EnrollManagementWS;
using EnrollmentIssuanceSite.Shared;
using System;
using System.Data;
using System.Text;
using System.Web.UI.WebControls;
using System.Xml;

namespace EnrollmentIssuanceSite
{
    public partial class Approval : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Common.GetCookie(this.Page, "sessionKey") == null) Response.Redirect(Common.ErPage);

            if (!IsPostBack)
            {
                #region Assign value to variables
                lblCompName.Text = Common.GetCookie(this.Page, "PCName");
                lblAppID.Text = Request.QueryString["done"];
                HFLevel.Value = Request.QueryString["level"];
                #endregion

                #region Set visibility
                if (HFLevel.Value == "2")
                {
                    SetFieldVisibility();
                }
                #endregion           

                #region ***
                btnSubmit.Attributes.Add("onclick", "return confirmSubmit();");
                txtAppDurationWeek.Text = Common.GetValue("DefaultWeek");
                txtAppDurationMonth.Text = Common.GetValue("DefaultMonth");
                txtAppDurationYear.Text = Common.GetValue("DefaultYear");

                GetDocType();
                GetEntryType();
                GetRejectReason();

                GetApplicantDetails(lblAppID.Text);
                RetrieveApprovalHistory();

                if (CheckEISDMSLinkage())
                    LoadLinkedDocsGrid();
                else
                    LoadScanDocEISGrid();

                string GivenName = lblFName.Text + " " + lblMName.Text;

                PersonWLCheck(lblSurname.Text.Trim(),
                    GivenName.Trim(),
                    lblDOB.Text.Substring(6, 4) + lblDOB.Text.Substring(3, 2) + lblDOB.Text.Substring(0, 2),
                    lblNationality.Text.Substring(0, lblNationality.Text.ToString().IndexOf('-')));


                if (HFLevel.Value == "2") CheckAction();

                #endregion

                #region View Profile
                if (HFLevel.Value == "0")
                {
                    DisableInput();
                    trApp1.Visible = true;
                    trApp2.Visible = true;
                    trApp3.Visible = true;
                    trApp4.Visible = true;
                    trApp5.Visible = true;
                    trApp6.Visible = true;
                    trApp7.Visible = true;
                    GetPaymentHistory(lblAppID.Text);
                    trPaymentHistory1.Visible = true;
                    trPaymentHistory2.Visible = true;
                    trPaymentHistory3.Visible = true;
                    trIssuance1.Visible = true;
                    //SetDocumentDetailsVisibility();
                }
                #endregion


                SetDocumentDetailsVisibility();
            }
        }
        private void SetFieldVisibility()
        {
            trInterviewNote.Visible = false;
            trAnnotation.Visible = true;
            trAnnotation2.Visible = true;
            trApprovalStatus2.Visible = true;
            trApprovalStatus1.Visible = false;
        }

        protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
        {
            MultiView1.ActiveViewIndex = Int32.Parse(e.Item.Value);
        }

        #region Bind Data
        private void GetApplicantDetails(string formno)
        {
            #region request Applicant Record by AppID
            try
            {
                EMService enrol = new EMService();
                RequestDataTypeGetDetails reqData = new RequestDataTypeGetDetails();

                reqData.ActionDescription = "Get Details";
                reqData.SessionKey = Common.GetCookie(this.Page, "sessionKey").ToString();
                reqData.EnrolLocationName = lblCompName.Text;
                reqData.SearchType = "1";
                reqData.PermissionCode = Common.GetValue("GetDetailsPermissionCode");
                reqData.ApplicationID = formno;

                reqData.DocNo = string.Empty;
                reqData.PassportNo = string.Empty;
                reqData.PassportCOI = string.Empty;

                ResponseDataTypeGetDetails responseData = enrol.GetDetails(reqData);

                string statusCode = responseData.StatusCode;
                string statusMsg = responseData.StatusMessage;


                #region display result
                if (statusCode == "0")
                {
                    HFIDPERSON.Value = responseData.IDPerson.ToString();
                    if (responseData.DocType != string.Empty)
                    {
                        string[] DT = responseData.DocType.ToString().Split(new char[] { '-' });
                        HFDocType.Value = DT[0].ToString().Trim();
                    }
                    lblAppID.Text = responseData.ApplicationID;
                    lblAppType.Text = responseData.AppReason;
                    lblDocType.Text = responseData.DocType;
                    lblEntryType.Text = responseData.EntryType;
                    lblAppStatus.Text = responseData.StageCode;

                    lblIdPerson.Text = responseData.IDPerson.ToString();

                    ddlDocType.SelectedValue = responseData.DocType.Substring(0, responseData.DocType.ToString().IndexOf('-')).Trim();
                    ddlEntryType.SelectedValue = responseData.EntryType.ToString().Substring(0, responseData.EntryType.ToString().IndexOf('-')).Trim();

                    GetVisaClass();

                    #region FaceImage Binding
                    string msg = string.Empty;
                    //Get the photo's base64 string from xml
                    byte[] txtPhotoH = responseData.FaceImage;
                    //Create the picture by decode the base 64 into Image
                    bool HasPhoto = Common.DecodeBytetoImage(txtPhotoH, out msg);
                    //If Photo has been successfully create
                    if (HasPhoto)
                    {
                        string outputFile = @Server.MapPath("") + Common.GetValue("ImgServerPath") + msg;
                        //Link the image control to physical image path
                        imgPhoto.ImageUrl = Common.GetImgUrl(txtPhotoH, outputFile, msg);
                    }
                    else
                    {
                        imgPhoto.ImageUrl = Common.ImgDefaultUrl;
                    }
                    #endregion              

                    #region personal details binding
                    lblSurname.Text = responseData.Surname;
                    lblFName.Text = responseData.FirstName;
                    lblMName.Text = responseData.MiddleName;

                    lblSex.Text = responseData.Sex == "M" ? "MALE" : "FEMALE";
                    lblTitle.Text = responseData.Title;
                    if (responseData.BirthDate != null)
                        lblDOB.Text = Convert.ToDateTime(responseData.BirthDate).ToString("dd/MM/yyyy");
                    lblCOB.Text = responseData.BirthCountry;
                    lblPOB.Text = responseData.BirthPlace;

                    lblNationality.Text = responseData.Nationality;
                    lblNIDNo.Text = responseData.NationalIDNo;

                    lblPassportNo.Text = responseData.PassportNo;
                    lblPassportPOI.Text = responseData.PassportPOI;
                    lblPassportCOI.Text = responseData.PassportCOI;
                    if (responseData.PassportDOI != null)
                        lblPassportDOI.Text = Convert.ToDateTime(responseData.PassportDOI).ToString("dd/MM/yyyy");
                    if (responseData.PassportDOE != null)
                        lblPassportDOE.Text = Convert.ToDateTime(responseData.PassportDOE).ToString("dd/MM/yyyy");
                    //lblMaritalStatus.Text = BindMaritalStatusDesc(responseData.MaritalStatus);

                    #endregion

                    #region Contact
                    lblPresentAddress.Text = responseData.PresentAddress;
                    lblPermanentAddress.Text = responseData.PermanentAddress;

                    lblPhoneHome.Text = responseData.PhoneHome;
                    lblPhoneWork.Text = responseData.PhoneWork;

                    lblFax.Text = responseData.Fax;
                    lblMobile.Text = responseData.Mobile;
                    lblEmail.Text = responseData.Email;
                    #endregion

                    #region Employment
                    lblOccupation.Text = responseData.Occupation;
                    lblYearsEmployed.Text = responseData.YearsEmployed;
                    lblEmployerName.Text = responseData.EmployerName;
                    lblEmployerAddress.Text = responseData.EmployerAddress;
                    lblEmployerPhone.Text = responseData.EmployerPhone;

                    lblFormerOccupation.Text = responseData.FormerOccupation;
                    lblFormerYearsEmployed.Text = responseData.FormerYearsEmployed;
                    lblFormerEmployerName.Text = responseData.FormerEmployerName;
                    lblFormerEmployerAddress.Text = responseData.FormerEmployerAddress;
                    lblFormerEmployerPhone.Text = responseData.FormerEmployerPhone;
                    #endregion

                    #region Family
                    lblMaritalStatus.Text = responseData.MaritalStatus;
                    lblSpouseFirstName.Text = responseData.SpouseFirstName;
                    lblSpouseLastName.Text = responseData.SpouseLastName;
                    lblSpouseMiddleName.Text = responseData.SpouseMiddleName;
                    lblSpouseMaidenName.Text = responseData.SpouseMaidenName;
                    if (responseData.SpouseDOB != null)
                        lblSpouseDOB.Text = Convert.ToDateTime(responseData.SpouseDOB).ToString("dd/MM/yyyy");


                    if (responseData.HasChildInd == "1")
                    {
                        chkHasChild1.Checked = true;
                        chkHasChild2.Checked = false;
                    }
                    else
                    {
                        chkHasChild1.Checked = false;
                        chkHasChild2.Checked = true;
                    }

                    lblDependantName1.Text = responseData.DependantName1;
                    lblDependantName2.Text = responseData.DependantName2;
                    lblDependantName3.Text = responseData.DependantName3;
                    lblDependantName4.Text = responseData.DependantName4;
                    lblDependantName5.Text = responseData.DependantName5;

                    lblRelationship1.Text = responseData.Relationship1;
                    lblRelationship2.Text = responseData.Relationship2;
                    lblRelationship3.Text = responseData.Relationship3;
                    lblRelationship4.Text = responseData.Relationship4;
                    lblRelationship5.Text = responseData.Relationship5;

                    if (responseData.TravelWithSpouseInd == "1")
                    {
                        chkTravelWithSpouse1.Checked = true;
                        chkTravelWithSpouse2.Checked = false;
                    }
                    else
                    {
                        chkTravelWithSpouse1.Checked = false;
                        chkTravelWithSpouse2.Checked = true;
                    }

                    if (responseData.TravelWithDependantInd == "1")
                    {
                        chkTravelWithDependant1.Checked = true;
                        chkTravelWithDependant2.Checked = false;
                    }
                    else
                    {
                        chkTravelWithDependant1.Checked = false;
                        chkTravelWithDependant2.Checked = true;
                    }

                    lblFatherFirstName.Text = responseData.FatherFirstName;
                    lblFatherLastName.Text = responseData.FatherLastName;
                    lblFatherMiddleName.Text = responseData.FatherMiddleName;

                    lblFatherNationality.Text = responseData.FatherNationality;

                    lblMotherFirstName.Text = responseData.MotherFirstName;
                    lblMotherLastName.Text = responseData.MotherLastName;
                    lblMotherMiddleName.Text = responseData.MotherMiddleName;

                    lblMotherNationality.Text = responseData.MotherNationality;

                    #endregion

                    #region Travel
                    lblVisitPurpose.Text = responseData.VisitPurpose;
                    lblOtherVisitPurpose.Text = responseData.OtherVisitPurpose;
                    if (lblOtherVisitPurpose.Text.Trim().Length == 0)
                        lblOtherVisitPurpose.Text = "-";

                    lblLengthOfStay.Text = responseData.LengthOfStay;
                    if (responseData.ArrivalDate != null)
                        lblArrivalDate.Text = Convert.ToDateTime(responseData.ArrivalDate).ToString("dd/MM/yyyy");

                    lblHotelName.Text = responseData.HotelName;
                    lblHotelAddress.Text = responseData.HotelAddress;
                    lblHotelPhone.Text = responseData.HotelPhone;

                    lblTripSponsorBy.Text = responseData.TripSponsorBy;
                    if (lblTripSponsorBy.Text.Trim().Length == 0)
                        lblTripSponsorBy.Text = "-";

                    lblTripMoney.Text = responseData.TripMoney;
                    if (lblTripMoney.Text.Trim().Length == 0)
                        lblTripMoney.Text = "-";
                    #endregion

                    #region criminal
                    if (responseData.CriminalConvictionInd == "1")
                    {
                        ChkCriminalConvictionInd1.Checked = true;
                        ChkCriminalConvictionInd2.Checked = false;
                    }
                    else
                    {
                        ChkCriminalConvictionInd1.Checked = false;
                        ChkCriminalConvictionInd2.Checked = true;
                    }

                    lblOffence1.Text = responseData.Offence1;
                    lblOffence2.Text = responseData.Offence2;
                    lblOffence3.Text = responseData.Offence3;
                    lblOffence4.Text = responseData.Offence4;
                    lblOffence5.Text = responseData.Offence5;

                    if (responseData.OffenceDate1 != null)
                        lblOffenceDate1.Text = Convert.ToDateTime(responseData.OffenceDate1).ToString("dd/MM/yyyy");

                    if (responseData.OffenceDate2 != null)
                        lblOffenceDate2.Text = Convert.ToDateTime(responseData.OffenceDate2).ToString("dd/MM/yyyy");

                    if (responseData.OffenceDate3 != null)
                        lblOffenceDate3.Text = Convert.ToDateTime(responseData.OffenceDate3).ToString("dd/MM/yyyy");

                    if (responseData.OffenceDate4 != null)
                        lblOffenceDate4.Text = Convert.ToDateTime(responseData.OffenceDate4).ToString("dd/MM/yyyy");

                    if (responseData.OffenceDate5 != null)
                        lblOffenceDate5.Text = Convert.ToDateTime(responseData.OffenceDate5).ToString("dd/MM/yyyy");

                    lblOffencePlace1.Text = responseData.OffencePlace1;
                    lblOffencePlace2.Text = responseData.OffencePlace2;
                    lblOffencePlace3.Text = responseData.OffencePlace3;
                    lblOffencePlace4.Text = responseData.OffencePlace4;
                    lblOffencePlace5.Text = responseData.OffencePlace5;

                    lblOffencePenalty1.Text = responseData.OffencePenalty1;
                    lblOffencePenalty2.Text = responseData.OffencePenalty2;
                    lblOffencePenalty3.Text = responseData.OffencePenalty3;
                    lblOffencePenalty4.Text = responseData.OffencePenalty4;
                    lblOffencePenalty5.Text = responseData.OffencePenalty5;

                    if (responseData.TerrorismInd == "1")
                    {
                        chkTerrorismInd1.Checked = true;
                        chkTerrorismInd2.Checked = false;
                    }
                    else
                    {
                        chkTerrorismInd1.Checked = false;
                        chkTerrorismInd2.Checked = true;
                    }

                    lblTerrorismDesc.Text = responseData.TerrorismDesc;

                    #endregion

                    #region Additional
                    if (responseData.FatherInBHSInd == "1")
                    {
                        ChkFatherInBhsInd1.Checked = true;
                        ChkFatherInBhsInd2.Checked = false;
                    }
                    else
                    {
                        ChkFatherInBhsInd1.Checked = false;
                        ChkFatherInBhsInd2.Checked = true;
                    }

                    if (responseData.MotherInBHSInd == "1")
                    {
                        ChkMotherInBhsInd1.Checked = true;
                        ChkMotherInBhsInd2.Checked = false;
                    }
                    else
                    {
                        ChkMotherInBhsInd1.Checked = false;
                        ChkMotherInBhsInd2.Checked = true;
                    }

                    if (responseData.SpouseInBHSInd == "1")
                    {
                        ChkSpouseInBhsInd1.Checked = true;
                        ChkSpouseInBhsInd2.Checked = false;
                    }
                    else
                    {
                        ChkSpouseInBhsInd1.Checked = false;
                        ChkSpouseInBhsInd2.Checked = true;
                    }

                    if (responseData.SiblingInBHSInd == "1")
                    {
                        ChkSiblingInBhsInd1.Checked = true;
                        ChkSiblingInBhsInd2.Checked = false;
                    }
                    else
                    {
                        ChkSiblingInBhsInd1.Checked = false;
                        ChkSiblingInBhsInd2.Checked = true;
                    }

                    if (responseData.ChildrenInBHSInd == "1")
                    {
                        ChkChildrenInBhsInd1.Checked = true;
                        ChkChildrenInBhsInd2.Checked = false;
                    }
                    else
                    {
                        ChkChildrenInBhsInd1.Checked = false;
                        ChkChildrenInBhsInd2.Checked = true;
                    }

                    lblFatherResidentialStatus.Text = responseData.FatherResidentialStatus;
                    lblMotherResidentialStatus.Text = responseData.MotherResidentialStatus;
                    lblSpouseResidentialStatus.Text = responseData.SpouseResidentialStatus;
                    lblSiblingResidentialStatus.Text = responseData.SiblingResidentialStatus;
                    lblChildrenResidentialStatus.Text = responseData.ChildrenResidentialStatus;


                    if (responseData.VisitedBhsInd == "1")
                    {
                        ChkVisitedBhsInd1.Checked = true;
                        ChkVisitedBhsInd2.Checked = false;
                    }
                    else
                    {
                        ChkVisitedBhsInd1.Checked = false;
                        ChkVisitedBhsInd2.Checked = true;
                    }

                    if (responseData.LastVisitDate != null)
                        lblLastVisitDate.Text = Convert.ToDateTime(responseData.LastVisitDate).ToString("dd/MM/yyyy");

                    if (responseData.AppliedVisaInd == "1")
                    {
                        ChkAppliedVisaInd1.Checked = true;
                        ChkAppliedVisaInd2.Checked = false;
                    }
                    else
                    {
                        ChkAppliedVisaInd1.Checked = false;
                        ChkAppliedVisaInd2.Checked = true;
                    }

                    if (responseData.AppliedVisaDate != null)
                        lblAppliedVisaDate.Text = Convert.ToDateTime(responseData.AppliedVisaDate).ToString("dd/MM/yyyy");

                    lblAppliedVisaPlace.Text = responseData.AppliedVisaPlace;

                    if (responseData.VisaOutCome == "1")
                    {
                        ChkVisaOutcome1.Checked = true;
                        ChkVisaOutcome2.Checked = false;
                    }
                    else
                    {
                        ChkVisaOutcome1.Checked = false;
                        ChkVisaOutcome2.Checked = false;
                    }

                    if (responseData.DeportedInd == "1")
                    {
                        ChkDeportedInd1.Checked = true;
                        ChkDeportedInd2.Checked = false;
                    }
                    else
                    {
                        ChkDeportedInd1.Checked = false;
                        ChkDeportedInd2.Checked = true;
                    }
                    #endregion

                    #region View Profile
                    if (HFLevel.Value == "0")
                    {
                        VPDataEntryBy.Text = responseData.DataEntryBy;
                        if (responseData.DataEntryTime != null)
                            VPDataEntryDate.Text = Convert.ToDateTime(responseData.DataEntryTime).ToString("dd/MM/yyyy");
                        VPDocNo.Text = responseData.DocNo;
                        if (responseData.DocIssueDate != null)
                            VPDOI.Text = Convert.ToDateTime(responseData.DocIssueDate).ToString("dd/MM/yyyy");
                        if (responseData.DocExpiryDate != null)
                            VPDOE.Text = Convert.ToDateTime(responseData.DocExpiryDate).ToString("dd/MM/yyyy");
                        VPEnrolDate.Text = Convert.ToDateTime(responseData.EnrolTime).ToString("dd/MM/yyyy");
                        VPEnrolledBy.Text = responseData.EnrolBy;
                        VPIssuedBy.Text = responseData.IssueBy;
                        VPPOI.Text = responseData.DocIssPlace;
                        if (responseData.IssueTime != null)
                            VPIssuedDate.Text = Convert.ToDateTime(responseData.IssueTime).ToString("dd/MM/yyyy");

                        if (responseData.TP_Name != string.Empty)
                        {
                            trIssuance2.Visible = true;
                            TP_DOCNO.Text = responseData.TP_DocNo;
                            TP_NAME.Text = responseData.TP_Name;
                            TP_PHONE.Text = responseData.TP_Phone;
                            TP_REMARKS.Text = responseData.TP_Remarks;
                        }
                        else
                            trIssuanceNoData.Visible = true;
                    }
                    #endregion

                }
                else
                {
                    lblSearchError.Text = statusMsg;
                }
                #endregion
            }
            catch (Exception ex)
            {
                lblSearchError.Visible = true;
                lblSearchError.Text = ex.Message;
                Common.WriteLog(@Server.MapPath("") + Common.GetValue("logPath"), "Get Applicant Details (GetApplicantDetails) - " + ex.Message);
            }

            #endregion
        }
        private void RetrieveApprovalHistory()
        {
            #region ***
            try
            {
                #region Call the webservices
                EMService history = new EMService();
                RequestDataTypeSelectApprovalHistory req = new RequestDataTypeSelectApprovalHistory();
                req.ActionDescription = "Get Approval History";
                req.SessionKey = Common.GetCookie(this.Page, "sessionKey").ToString();
                req.EnrolLocationName = lblCompName.Text;
                req.PermissionCode = Common.GetValue("GetApprovaHistory");
                req.ApplicationID = lblAppID.Text;
                #endregion

                #region response
                ResponseDataTypeSelectApprovalHistory getdata = history.SelectApprovalHistoryList(req);
                string StatusCode = getdata.StatusCode;
                string StatusMsg = getdata.StatusMessage;
                #endregion

                #region process
                if (StatusCode == "0")
                {
                    #region
                    gvAppHistory.DataSource = getdata.ResultList.Tables[0];
                    gvAppHistory.DataBind();
                    ViewState["AppHistory"] = getdata.ResultList;
                    int i = getdata.ResultList.Tables[0].Rows.Count;
                    stagecode.Value = getdata.ResultList.Tables[0].Rows[i - 1]["ASTAGECODE"].ToString();

                    foreach (DataRow dr in getdata.ResultList.Tables[0].Rows)
                    {
                        #region ***
                        txtAppDurationYear.Text = dr["ValidYear"].ToString();
                        txtAppDurationMonth.Text = dr["ValidMonth"].ToString();
                        txtAppDurationWeek.Text = dr["ValidWeek"].ToString();

                        txtInterviewNote.Text = dr["InterviewNote"].ToString();

                        ddlDocType.SelectedValue = dr["DocType"].ToString().Substring(0, dr["DocType"].ToString().IndexOf('-')).Trim();
                        ddlEntryType.SelectedValue = dr["EntryType"].ToString().Substring(0, dr["EntryType"].ToString().IndexOf('-')).Trim();

                        int x = dr["Annotation"].ToString().Length;

                        if (x <= 20)
                            txtAnnotation.Text = dr["Annotation"].ToString().Trim();
                        else
                        {
                            txtAnnotation.Text = dr["Annotation"].ToString().Substring(0, 20);
                            txtAnnotation2.Text = dr["Annotation"].ToString().Substring(20);
                        }

                        if (dr["VisaClass1"] != null ||
                            dr["VisaClass2"] != null ||
                            dr["VisaClass3"] != null ||
                            dr["VisaClass4"] != null ||
                            dr["VisaClass5"] != null)
                        {
                            GetVisaClass();
                            foreach (ListItem li in ChkVisaClass.Items)
                            {

                                if ((li.Value.ToString() + " - " + li.Text.ToString()) == dr["VisaClass1"].ToString() ||
                                    (li.Value.ToString() + " - " + li.Text.ToString()) == dr["VisaClass2"].ToString() ||
                                    (li.Value.ToString() + " - " + li.Text.ToString()) == dr["VisaClass3"].ToString() ||
                                    (li.Value.ToString() + " - " + li.Text.ToString()) == dr["VisaClass4"].ToString() ||
                                    (li.Value.ToString() + " - " + li.Text.ToString()) == dr["VisaClass5"].ToString())
                                {
                                    li.Selected = true;
                                }
                            }
                        }


                        #endregion
                    }

                    #region Show the latest approval info for view profile
                    if (HFLevel.Value == "0" || HFLevel.Value == "5")
                    {
                        if (stagecode.Value.Substring(3, 1) == "0")//Pre-Approval
                        {
                            ddlApprovalStatus.SelectedValue = stagecode.Value.Substring(0, 6);
                        }
                        else // Final Approval
                        {
                            ddlApprovalStatus2.SelectedValue = stagecode.Value.Substring(0, 6);
                            SetFieldVisibility();
                            if (ddlApprovalStatus2.SelectedValue == "EM4101")
                            {
                                trRejectReason.Visible = true;
                                string reason = getdata.ResultList.Tables[0].Rows[i - 1]["REJECTREASON"].ToString();
                                string[] RR = reason.Split(new char[] { '-' });
                                ddlRejectReason.SelectedValue = RR[0].ToString().Trim();
                            }
                        }
                    }
                    #endregion

                    #endregion
                }
                else
                {
                    lblAppHistoryMsg.Visible = true;
                    lblAppHistoryMsg.Text = "No data available";
                    divApprovalHistory.Visible = false;
                    Common.WriteLog(@Server.MapPath("") + Common.GetValue("logPath"), "Search Approval History (RetrieveApprovalHistory) - " + StatusMsg);

                }
                #endregion
            }
            catch (Exception ex)
            {
                lblAppHistoryErr.Visible = true;
                lblAppHistoryErr.Text = ex.Message;
                Common.WriteLog(@Server.MapPath("") + Common.GetValue("logPath"), "Search Approval History (RetrieveApprovalHistory) - " + ex.Message);
            }
            #endregion
        }
        protected void RetrieveScannedDoc()
        {
            #region ***
            try
            {
                #region Call the webservices
                EMService test = new EMService();
                EnrollmentIssuanceSite.EnrollManagementWS.RequestDataTypeSelectScannedDoc chk = new EnrollmentIssuanceSite.EnrollManagementWS.RequestDataTypeSelectScannedDoc();
                chk.ActionDescription = "Get scanned Documents";
                chk.SessionKey = Common.GetCookie(this.Page, "sessionKey").ToString();
                chk.LocationName = lblCompName.Text;
                chk.PermissionCode = Common.GetValue("SelectScanDoc");
                chk.ApplicationID = lblAppID.Text;
                #endregion

                #region response
                EnrollmentIssuanceSite.EnrollManagementWS.ResponseDataTypeSelectScannedDoc getdata = test.GetScannedDocList(chk);
                string StatusCode = getdata.StatusCode;
                string StatusMsg = getdata.StatusMessage;
                #endregion

                #region process
                if (StatusCode == "0")
                {
                    int count = getdata.ResultList.Tables[0].Rows.Count;
                    if (count != 0)
                    {
                        dgScanDocList.DataSource = getdata.ResultList.Tables[0];
                        dgScanDocList.DataBind();
                        ViewState["ScannedDoc"] = getdata.ResultList;
                    }
                    else
                    {
                        lblScannedDocMsg.Text = "No data available";
                    }
                }
                else
                {
                    lblScannedDocMsg.Visible = true;
                    lblScannedDocMsg.Text = "No data available";
                }
                #endregion
            }
            catch (Exception ex)
            {
                lblScannedDocErr.Visible = true;
                lblScannedDocErr.Text = ex.Message;
                Common.WriteLog(@Server.MapPath("") + Common.GetValue("logPath"), "Search Scanned Doc (RetrieveScannedDoc) - " + ex.Message);
            }
            #endregion
        }
        #endregion

        #region Bind Lookup
        private void GetDocType()
        {
            try
            {
                #region Call the webservices
                DALMService DocType = new DALMService();
                RequestDataTypeSelectDocType bindddl = new RequestDataTypeSelectDocType();
                bindddl.ActionDescription = "select document type";
                bindddl.SessionKey = Common.GetCookie(this.Page, "sessionKey");
                bindddl.PermissionCode = Common.GetValue("GetDocTypeList");
                #endregion

                #region response
                ResponseDataTypeSelectDocType getdata = DocType.SelectDocTypeList(bindddl);
                string StatusCode = getdata.StatusCode;
                string StatusMsg = getdata.StatusMessage;
                #endregion

                #region process
                if (StatusCode == "0")
                {
                    DataSet ds = getdata.ResultList;

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ddlDocType.DataSource = ds.Tables[0];
                        ddlDocType.DataValueField = "DocType";
                        ddlDocType.DataTextField = "Description";
                        ddlDocType.DataBind();
                        ddlDocType.Items.Insert(0, new ListItem("-SELECT-", ""));

                        ddlDocType.SelectedIndex = -1;
                    }
                }
                else
                {
                    lblStatusMsg.Text = StatusMsg;
                    lblStatusMsg.Visible = true;
                }
                #endregion
            }
            catch (Exception ex)
            {
                Common.WriteLog(@Server.MapPath("") + Common.GetValue("logPath"), "GetDocType - " + ex.Message);
            }
        }
        private void GetEntryType()
        {
            try
            {
                #region Call the webservices
                DALMService EntryType = new DALMService();
                RequestDataTypeSelectEntryType bindddl = new RequestDataTypeSelectEntryType();
                bindddl.ActionDescription = "Select Entry Type";
                bindddl.SessionKey = Common.GetCookie(this.Page, "sessionKey");
                bindddl.PermissionCode = Common.GetValue("GetEntryType");
                #endregion

                #region response
                ResponseDataTypeSelectEntryType getdata = EntryType.SelectLookupEntryTypeList(bindddl);
                string StatusCode = getdata.StatusCode;
                string StatusMsg = getdata.StatusMessage;
                #endregion

                #region process
                if (StatusCode == "0")
                {
                    DataSet ds = getdata.ResultList;

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ddlEntryType.DataSource = ds.Tables[0];
                        ddlEntryType.DataValueField = "EntryType";
                        ddlEntryType.DataTextField = "Description";
                        ddlEntryType.DataBind();
                        ddlEntryType.Items.Insert(0, new ListItem("-SELECT-", ""));

                        ddlEntryType.SelectedIndex = -1;
                    }
                }
                else
                {
                    lblStatusMsg.Text = StatusMsg;
                    lblStatusMsg.Visible = true;
                }
                #endregion
            }
            catch (Exception ex)
            {
                Common.WriteLog(@Server.MapPath("") + Common.GetValue("logPath"), "GetEntryType - " + ex.Message);
            }
        }
        private void GetVisaClass()
        {
            try
            {
                #region Call the webservices
                DALMService VisaClass = new DALMService();
                RequestDataTypeSelectVisaClass bindddl = new RequestDataTypeSelectVisaClass();
                bindddl.ActionDescription = "select visa class";
                bindddl.SessionKey = Common.GetCookie(this.Page, "sessionKey");
                bindddl.PermissionCode = Common.GetValue("GetVisaClassList");
                bindddl.DocType = ddlDocType.SelectedValue;
                #endregion

                #region response
                ResponseDataTypeSelectVisaClass getdata = VisaClass.SelectVisaClass(bindddl);
                string StatusCode = getdata.StatusCode;
                string StatusMsg = getdata.StatusMessage;
                #endregion

                #region process
                if (StatusCode == "0")
                {
                    DataSet ds = getdata.ResultList;

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ChkVisaClass.DataSource = ds.Tables[0];
                        ChkVisaClass.DataValueField = "Class";
                        ChkVisaClass.DataTextField = "Description";
                        ChkVisaClass.DataBind();

                        trVisaClass.Visible = true;
                    }
                    else
                    {
                        ChkVisaClass.DataSource = "";
                        ChkVisaClass.DataBind();

                        trVisaClass.Visible = false;
                    }
                }
                else
                {
                    ChkVisaClass.DataSource = "";
                    ChkVisaClass.DataBind();
                    trVisaClass.Visible = false;
                }
                #endregion        
            }
            catch (Exception ex)
            {
                Common.WriteLog(@Server.MapPath("") + Common.GetValue("logPath"), "GetVisaClass - " + ex.Message);
            }
        }
        private void GetRejectReason()
        {
            try
            {
                #region Call the webservices
                DALMService RejectReason = new DALMService();
                RequestDataTypeSelectRejectReason bindddl = new RequestDataTypeSelectRejectReason();
                bindddl.ActionDescription = "select reject reason";
                bindddl.SessionKey = Common.GetCookie(this.Page, "sessionKey");
                bindddl.PermissionCode = Common.GetValue("GetRejectReason");
                #endregion

                #region response
                ResponseDataTypeSelectRejectReason getdata = RejectReason.SelectRejectReason(bindddl);
                string StatusCode = getdata.StatusCode;
                string StatusMsg = getdata.StatusMessage;
                #endregion

                #region process
                if (StatusCode == "0")
                {
                    DataSet ds = getdata.ResultList;

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ddlRejectReason.DataSource = ds.Tables[0];
                        ddlRejectReason.DataValueField = "RejectReasonCode";
                        ddlRejectReason.DataTextField = "Description";
                        ddlRejectReason.DataBind();
                        ddlRejectReason.Items.Insert(0, new ListItem("-SELECT-", ""));

                        ddlRejectReason.SelectedIndex = -1;
                    }
                }
                #endregion
            }
            catch (Exception ex)
            {
                Common.WriteLog(@Server.MapPath("") + Common.GetValue("logPath"), "GetRejectReason - " + ex.Message);
            }
        }
        #endregion

        protected void ddlDocType_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckDocType();
        }
        private void CheckDocType()
        {
            #region ***
            if (DisplayMsg())
            {
                string script = "<script type=\"text/javascript\">";
                script += "alert(\"";
                script += "You are changing from a fee-waived Visa to a non-fee waived one.\\nPlease reject the application at final approval and re-enroll applicant in order to go through the payment module!\");</script>";
                ClientScript.RegisterClientScriptBlock(GetType(), "Calendar_ChangeDate", script);
                if (HFLevel.Value == "1")
                {
                    ddlApprovalStatus.SelectedValue = "EM4001";
                    ddlApprovalStatus.Enabled = false;
                    ddlApprovalStatusAction();
                }
                else if (HFLevel.Value == "2" || HFLevel.Value == "5")
                {
                    ddlApprovalStatus2.SelectedValue = "EM4101";
                    ddlApprovalStatus2.Enabled = false;
                    ddlApprovalStatus2Action();
                }
                ChkVisaClass.DataSource = "";
                ChkVisaClass.DataBind();
                trVisaClass.Visible = false;
            }
            else
            {
                if (HFLevel.Value == "1")
                {
                    ddlApprovalStatus.SelectedIndex = -1;
                    ddlApprovalStatus.Enabled = true;
                    ddlApprovalStatusAction();
                }
                else if (HFLevel.Value == "2" || HFLevel.Value == "5")
                {
                    ddlApprovalStatus2.SelectedIndex = -1;
                    ddlApprovalStatus2.Enabled = true;
                    ddlApprovalStatus2Action();
                }
                GetVisaClass();
            }
            #endregion
        }
        private bool DisplayMsg()
        {
            string newDocType = ddlDocType.SelectedValue;
            if (HFDocType.Value == Common.GetValue("DIPLOMATIC") || HFDocType.Value == Common.GetValue("OFFICIAL"))
            {
                if (newDocType != Common.GetValue("DIPLOMATIC") && newDocType != Common.GetValue("OFFICIAL"))
                    return true;
                else
                    return false;
            }
            else
                return false;
        }
        private void CheckAction()
        {
            if (DisplayMsg())
            {
                ddlApprovalStatus2.SelectedValue = "EM4101";
                ddlApprovalStatus2.Enabled = false;
                ddlApprovalStatus2Action();
            }
        }
        protected void ddlApprovalStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlApprovalStatusAction();
        }
        private void ddlApprovalStatusAction()
        {
            #region ***
            if (ddlApprovalStatus.SelectedItem.Text == "REJECT")
            {
                trRejectReason.Visible = true;
                ddlRejectReason.SelectedIndex = -1;
            }
            else
            {
                trRejectReason.Visible = false;
                if (ddlApprovalStatus.SelectedItem.Text == "DEFER" ||
                    ddlApprovalStatus.SelectedItem.Text == "SKIP")
                {
                    Label150.Visible = true;
                    RFVRemarks.Enabled = true;
                }
                else
                {
                    Label150.Visible = false;
                    RFVRemarks.Enabled = false;
                }
            }
            #endregion
        }
        protected void ddlApprovalStatus2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlApprovalStatus2Action();
        }
        private void ddlApprovalStatus2Action()
        {
            #region ***
            ddlRejectReason.SelectedIndex = -1;
            if (ddlApprovalStatus2.SelectedItem.Text == "REJECT")
            {
                trRejectReason.Visible = true;
                if (lblAppType.Text.Substring(0, 1) != Common.GetValue("ExternalSponsored") && lblAppType.Text.Substring(0, 1) != Common.GetValue("ExternalUnSponsored"))
                {
                    if (stagecode.Value.Substring(0, 6) == "EM4000" || stagecode.Value.Substring(0, 6) == "EM4100")
                    {
                        Label150.Visible = true;
                        RFVRemarks.Enabled = true;
                    }
                    else
                    {
                        Label150.Visible = false;
                        RFVRemarks.Enabled = false;
                    }
                }
                else
                {
                    Label150.Visible = true;
                    RFVRemarks.Enabled = true;
                }

            }
            else
            {
                trRejectReason.Visible = false;
                if (ddlApprovalStatus2.SelectedItem.Text == "DEFER" ||
                    ddlApprovalStatus2.SelectedItem.Text == "SKIP")
                {
                    Label150.Visible = true;
                    RFVRemarks.Enabled = true;
                }
                else
                {
                    if (string.IsNullOrEmpty(stagecode.Value))
                    {
                        Label150.Visible = false;
                        RFVRemarks.Enabled = false;
                    }
                    else
                    {
                        if (stagecode.Value.Substring(0, 6) == "EM4001" || stagecode.Value.Substring(0, 6) == "EM4101")
                        {
                            Label150.Visible = true;
                            RFVRemarks.Enabled = true;
                        }
                        else
                        {
                            Label150.Visible = false;
                            RFVRemarks.Enabled = false;
                        }
                    }
                }
            }
            #endregion
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (trVisaClass.Visible == true)
            {
                if (VisaClassValidation() == false)
                    return;
            }

            try
            {
                #region Call the webservices
                EMService approval = new EMService();
                RequestDataTypeApproval app = new RequestDataTypeApproval();

                app.ActionDescription = "Approval";
                app.SessionKey = Common.GetCookie(this.Page, "sessionKey");
                app.PermissionCode = Common.GetValue("ApproveApp");
                app.EnrolLocationName = lblCompName.Text;

                if (HFLevel.Value == "1")
                {
                    app.StageCode = ddlApprovalStatus.SelectedValue;
                    app.ApprovalLevel = HFLevel.Value;
                }
                else if (HFLevel.Value == "2" || HFLevel.Value == "5")
                {
                    app.ApprovalLevel = "2";
                    app.StageCode = ddlApprovalStatus2.SelectedValue;
                }

                app.ApplicationID = lblAppID.Text;
                app.Annotation = txtAnnotation.Text.PadRight(20, ' ') + txtAnnotation2.Text;
                app.InterviewNote = txtInterviewNote.Text;
                app.RejectReason = ddlRejectReason.SelectedValue;
                app.Remark = txtRemarks.Text;
                app.ValidWeek = Convert.ToInt32(txtAppDurationWeek.Text);
                app.ValidMonth = Convert.ToInt32(txtAppDurationMonth.Text);
                app.ValidYear = Convert.ToInt32(txtAppDurationYear.Text);
                app.DocType = ddlDocType.SelectedValue;
                app.EntryType = ddlEntryType.SelectedValue;

                app.VisaClass1 = null;
                app.VisaClass2 = null;
                app.VisaClass3 = null;
                app.VisaClass4 = null;
                app.VisaClass5 = null;

                int i = 1;

                foreach (ListItem li in ChkVisaClass.Items)
                {
                    if (li.Selected == true)
                    {
                        switch (i)
                        {
                            case 1:
                                app.VisaClass1 = Convert.ToInt32(li.Value);
                                break;
                            case 2:
                                app.VisaClass2 = Convert.ToInt32(li.Value);
                                break;
                            case 3:
                                app.VisaClass3 = Convert.ToInt32(li.Value);
                                break;
                            case 4:
                                app.VisaClass4 = Convert.ToInt32(li.Value);
                                break;
                            case 5:
                                app.VisaClass5 = Convert.ToInt32(li.Value);
                                break;
                        }
                        i += 1;
                    }
                }
                #endregion

                #region response
                ResponseDataTypeApproval getdata = approval.Approve(app);
                string StatusCode = getdata.StatusCode;
                string StatusMsg = getdata.StatusMessage;

                lblStatusMsg.Visible = true;

                if (StatusCode == "0")
                {
                    lblStatusMsg.Text = "Application successfully submitted";
                    DisableInput();
                    if (HFLevel.Value == "1" && ddlApprovalStatus.SelectedValue != "EM4002")
                        CheckDataEntryPermission();
                }
                else
                {
                    lblStatusMsg.Text = StatusMsg;
                    Common.WriteLog(@Server.MapPath("") + Common.GetValue("logPath"), "btnSubmit - " + StatusMsg);
                }
                #endregion
            }
            catch (Exception ex)
            {
                lblStatusMsg.Visible = true;
                lblStatusMsg.Text = ex.Message;
                Common.WriteLog(@Server.MapPath("") + Common.GetValue("logPath"), "btnSubmit - " + ex.Message);
            }
        }

        private void DisableInput()
        {
            #region ***
            txtInterviewNote.Enabled = false;
            txtAnnotation.Enabled = false;
            txtAnnotation2.Enabled = false;
            txtRemarks.Enabled = false;
            txtAppDurationMonth.Enabled = false;
            txtAppDurationWeek.Enabled = false;
            txtAppDurationYear.Enabled = false;

            ddlApprovalStatus.Enabled = false;
            ddlApprovalStatus2.Enabled = false;
            ddlDocType.Enabled = false;
            ddlEntryType.Enabled = false;
            ddlRejectReason.Enabled = false;

            ChkVisaClass.Enabled = false;
            btnSubmit.Enabled = false;
            #endregion
        }

        #region Approval History
        protected void gvAppHistory_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Summary")
            {
                string input = e.CommandArgument.ToString().Trim();

                ViewHistory.Visible = true;
                lblViewTitle.Text = "Interview Note";
                txtViewAppSummary.Text = input;
            }
            else if (e.CommandName == "Annotation")
            {
                string input = e.CommandArgument.ToString().Trim();

                ViewHistory.Visible = true;
                lblViewTitle.Text = "Annotation";
                txtViewAppSummary.Text = input;
            }
            else if (e.CommandName == "Remark")
            {
                string input = e.CommandArgument.ToString().Trim();

                ViewHistory.Visible = true;
                lblViewTitle.Text = "Remark";
                txtViewAppSummary.Text = input;
            }
        }
        protected void gvAppHistory_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvAppHistory.PageIndex = e.NewPageIndex;
            DataSet Ds = (DataSet)ViewState["AppHistory"];
            DataView dv = new DataView(Ds.Tables[0]);

            gvAppHistory.DataSource = dv;
            gvAppHistory.DataBind();
        }
        protected void lbClose_Click(object sender, EventArgs e)
        {
            ViewHistory.Visible = false;
        }
        #endregion

        #region Scanned Doc
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
                #region Get image from EIS

                #region Call the webservices
                EMService test = new EMService();
                EnrollmentIssuanceSite.EnrollManagementWS.RequestDataTypeSelectScannedDoc req = new EnrollmentIssuanceSite.EnrollManagementWS.RequestDataTypeSelectScannedDoc();
                req.ActionDescription = "Get Select Scanned Doc by Image ID";
                req.SessionKey = Common.GetCookie(this.Page, "sessionKey").ToString();
                req.LocationName = lblCompName.Text;
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
            //////else if (system == "DMS")
            //////{
            //////    #region Get Image by ID - DMS
            //////    #region connecting to web service
            //////    DMService dms = new DMService();
            //////    EnrollmentIssuanceSite.DocumentManagementWS.RequestDataTypeOutSearchScannedDoc reqData = new EnrollmentIssuanceSite.DocumentManagementWS.RequestDataTypeOutSearchScannedDoc();
            //////    reqData.ActionDescription = "Search scanned doc";
            //////    reqData.PermissionCode = "12.41.4";
            //////    reqData.ImageID = Convert.ToInt32(ID);

            //////    DMS.ResponseDataTypeOutSearchScannedDoc responseData = dms.DMSSearchScannedDocByImageID(reqData);
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
            //////            outputFile = @Server.MapPath("") +  common.GetValue("ImgServerPath") + msg;
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
        protected void dgScanDocList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            #region ***
            if (e.CommandName == "Delete")
            {
                // get the Image ID of the clicked row
                int ImgID = Convert.ToInt32(e.CommandArgument);
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
        protected void dgScanDocList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DataSet Ds = (DataSet)ViewState["CurrentData"];
            DataView dv = new DataView(Ds.Tables[0]);

            dgScanDocList.PageIndex = e.NewPageIndex;
            dgScanDocList.DataSource = dv;
            dgScanDocList.DataBind();
            //panelSearchError.Visible = false;
        }
        #endregion

        private bool VisaClassValidation()
        {
            #region ***
            int i = 0;

            foreach (ListItem li in ChkVisaClass.Items)
            {
                if (li.Selected == true)
                    i += 1;
            }

            StringBuilder sb = new StringBuilder();

            if (i == 0)
            {
                sb.Append(@"<script language='javascript'>");
                sb.Append(@"alert('Please select at least one visa class');");
                sb.Append(@"</script>");

                ClientScript.RegisterClientScriptBlock(GetType(), "Message", sb.ToString());
                return false;
            }
            else if (i > 2)
            {
                sb.Append(@"<script language='javascript'>");
                sb.Append(@"alert('Please select maximum of 2 classes');");
                sb.Append(@"</script>");

                ClientScript.RegisterClientScriptBlock(GetType(), "Message", sb.ToString());
                return false;
            }
            return true;
            #endregion
        }
        protected void ChkVisaClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            VisaClassValidation();
        }

        private void PersonWLCheck(string Surname, string GivenName, string BirthDate, string Nationality)
        {
            // ANTU: Remove watchlist
            return;

            //////#region ***
            //////try
            //////{
            //////    #region write XML
            //////    XmlDocument xmlDoc = new XmlDocument();

            //////    xmlDoc.AppendChild(xmlDoc.CreateElement("VISWEBREQUEST"));

            //////    XmlElement xmlRoot = xmlDoc.DocumentElement;
            //////    XmlElement xmlWebRequest;
            //////    XmlElement xmlPayload;
            //////    XmlText xmlText;

            //////    xmlWebRequest = xmlDoc.CreateElement("", "PERMISSIONCODE", "");
            //////    xmlText = xmlDoc.CreateTextNode("22.98.2");
            //////    xmlWebRequest.AppendChild(xmlText);
            //////    xmlRoot.AppendChild(xmlWebRequest);

            //////    xmlWebRequest = xmlDoc.CreateElement("", "ACTIONDESCRIPTION", "");
            //////    xmlText = xmlDoc.CreateTextNode("PERSONBL-QUICKSEARCH");
            //////    xmlWebRequest.AppendChild(xmlText);
            //////    xmlRoot.AppendChild(xmlWebRequest);

            //////    xmlWebRequest = xmlDoc.CreateElement("", "TRANSACTIONDATETIME", "");
            //////    xmlText = xmlDoc.CreateTextNode(System.DateTime.Now.ToString("yyyyMMddHHmmssfff"));
            //////    xmlWebRequest.AppendChild(xmlText);
            //////    xmlRoot.AppendChild(xmlWebRequest);

            //////    xmlWebRequest = xmlDoc.CreateElement("", "PAYLOAD", "");
            //////    #region PAYLOAD
            //////    xmlPayload = xmlDoc.CreateElement("", "SURNAME", "");
            //////    xmlText = xmlDoc.CreateTextNode(Surname);
            //////    xmlPayload.AppendChild(xmlText);
            //////    xmlWebRequest.AppendChild(xmlPayload);

            //////    xmlPayload = xmlDoc.CreateElement("", "GIVENNAME", "");
            //////    xmlText = xmlDoc.CreateTextNode(GivenName);
            //////    xmlPayload.AppendChild(xmlText);
            //////    xmlWebRequest.AppendChild(xmlPayload);

            //////    xmlPayload = xmlDoc.CreateElement("", "BIRTHDATE", "");
            //////    xmlText = xmlDoc.CreateTextNode(BirthDate);
            //////    xmlPayload.AppendChild(xmlText);
            //////    xmlWebRequest.AppendChild(xmlPayload);

            //////    xmlPayload = xmlDoc.CreateElement("", "NATIONALITY", "");
            //////    xmlText = xmlDoc.CreateTextNode(Nationality.Trim());
            //////    xmlPayload.AppendChild(xmlText);
            //////    xmlWebRequest.AppendChild(xmlPayload);

            //////    xmlPayload = xmlDoc.CreateElement("", "PERSONBLCODE", "");
            //////    xmlWebRequest.AppendChild(xmlPayload);

            //////    xmlPayload = xmlDoc.CreateElement("", "USERID", "");
            //////    xmlText = xmlDoc.CreateTextNode(common.GetCookie(this.Page, "loginName").ToString());
            //////    xmlPayload.AppendChild(xmlText);
            //////    xmlWebRequest.AppendChild(xmlPayload);

            //////    xmlPayload = xmlDoc.CreateElement("", "BRANCHCODE", "");
            //////    xmlWebRequest.AppendChild(xmlPayload);

            //////    xmlPayload = xmlDoc.CreateElement("", "DEPTID", "");
            //////    xmlText = xmlDoc.CreateTextNode("MOF-V");
            //////    xmlPayload.AppendChild(xmlText);
            //////    xmlWebRequest.AppendChild(xmlPayload);

            //////    xmlPayload = xmlDoc.CreateElement("", "TXNSOURCE", "");
            //////    xmlText = xmlDoc.CreateTextNode("VIS");
            //////    xmlPayload.AppendChild(xmlText);
            //////    xmlWebRequest.AppendChild(xmlPayload);
            //////    #endregion

            //////    xmlRoot.AppendChild(xmlWebRequest);
            //////    #endregion

            //////    #region Call Web Service
            //////    Watchlist.WatchList wl = new Watchlist.WatchList();

            //////    string Response = wl.WatchListRequest(xmlDoc.InnerXml);
            //////    #endregion

            //////    XmlDocument xmlResponse = new XmlDocument();

            //////    xmlResponse.LoadXml(Response);

            //////    if (xmlResponse.SelectSingleNode("//STATUS/STATUSCODE").InnerText != "0")
            //////    {
            //////        lblWLStatus.Text = "Transaction Failed";
            //////        lblWLStatus.BackColor = System.Drawing.Color.Red;
            //////    }
            //////    else
            //////    {
            //////        if (Convert.ToInt32(xmlResponse.SelectSingleNode("//STATUS/RECCOUNT").InnerText) == 0)
            //////        {
            //////            lblWLStatus.Text = "CLEAR";
            //////            lblWLStatus.BackColor = System.Drawing.Color.LawnGreen;
            //////        }
            //////        else
            //////        {
            //////            lblWLStatus.Text = "HIT";
            //////            lblWLStatus.BackColor = System.Drawing.Color.Red;
            //////        }
            //////    }
            //////}
            //////catch (Exception ex)
            //////{
            //////    lblWLStatus.Text = "Transaction Failed";
            //////    lblWLStatus.BackColor = System.Drawing.Color.Red;
            //////    common.WriteLog(@Server.MapPath("") + common.GetValue("logPath"), "Person Watchlist - " + ex.Message);
            //////} 
            //////#endregion
        }

        protected void ddlRejectReason_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (HFLevel.Value == "1")
            {
                if (ddlRejectReason.SelectedItem.Text == "OTHER")
                {
                    Label150.Visible = true;
                    RFVRemarks.Enabled = true;
                }
                else
                {
                    Label150.Visible = false;
                    RFVRemarks.Enabled = false;
                }
            }

        }
        #region Set for Data ENtry
        private void CheckDataEntryPermission()
        {
            if (Common.GetCookie(this.Page, "ConfigLocation").Substring(0, 1) == "1" && Common.GetCookie(this.Page, "GroupPermission").Substring(1, 1) == "1")
                btn_DataEntry.Visible = true;
            else
                btn_DataEntry.Visible = false;
        }
        protected void btn_DataEntry_Click(object sender, EventArgs e)
        {
            CreateXmlFile();
            Response.Redirect("ApplicationPart1.aspx?sm=" + Common.COMPLETEENROLECODE + "&done=" + lblAppID.Text + Common.COMPLETEENROLECODE + "&arrow=0&PC=" + lblCompName.Text);
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
                reqData.EnrolLocationName = lblCompName.Text;
                reqData.SearchType = "1";
                reqData.ApplicationID = lblAppID.Text;
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
                    string fileName = @Server.MapPath("") + Common.GetValue("xmlServerPath") + lblAppID.Text + Common.COMPLETEENROLECODE + ".xml";

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
                    throw new Exception(statusMsg);
                }
            }
            catch (Exception ex)
            {
                Common.WriteLog(@Server.MapPath("") + Common.GetValue("logPath"), "Create XML - " + ex.Message);

            }
            #endregion
        }
        #endregion

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
                    dgScanDocList.Visible = false;
                }
                else
                {

                    ViewState["ScannedDoc"] = null;
                    ViewState["ScannedDoc"] = ds;
                    dgScanDocList.DataSource = ds.Tables[0];
                    dgScanDocList.DataBind();
                    dgScanDocList.Visible = true;
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
            #region Load Scan Document from EIS

            #region connecting to web service
            EMService enrol = new EMService();
            EnrollmentIssuanceSite.EnrollManagementWS.RequestDataTypeSelectScannedDoc reqData = new EnrollmentIssuanceSite.EnrollManagementWS.RequestDataTypeSelectScannedDoc();

            reqData.ActionDescription = "Get Scanned Doc List";
            reqData.PermissionCode = Common.GetValue("SelectScanDoc");
            reqData.SessionKey = Common.GetCookie(this.Page, "sessionKey");
            reqData.LocationName = lblCompName.Text;
            reqData.ApplicationID = lblAppID.Text;

            EnrollmentIssuanceSite.EnrollManagementWS.ResponseDataTypeSelectScannedDoc responseData = enrol.GetScannedDocList(reqData);
            #endregion

            #region response
            string statusCode = responseData.StatusCode;
            string statusMsg = responseData.StatusMessage;
            #endregion

            #region analyse result
            if (statusCode == "0")
            {

                DataColumn dc = new DataColumn("SYSTEM");
                responseData.ResultList.Tables[0].Columns.Add(dc);

                foreach (DataRow dr in responseData.ResultList.Tables[0].Rows)
                {
                    dr["SYSTEM"] = "VIS";
                }
                ViewState["ScannedDoc"] = responseData.ResultList;
                return responseData.ResultList;
            }
            else if (statusCode == "12.106.2.6")//No record found
            {
                return null;
            }
            else
                throw new Exception(responseData.StatusMessage);
            #endregion

            #endregion
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
                    divScanDoc.Visible = true;
                }
                else
                {
                    divScanDoc.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Common.WriteLog(@Server.MapPath("") + Common.GetValue("logPath"), "LoadScanDocEISGrid() - " + ex.Message);
            }

            #endregion
        }
        protected void GetPaymentHistory(string appid)
        {
            #region ***
            try
            {
                #region Call the webservices
                EMService ph = new EMService();
                EnrollmentIssuanceSite.EnrollManagementWS.RequestDataTypeSelectPaymentHistory chk = new EnrollmentIssuanceSite.EnrollManagementWS.RequestDataTypeSelectPaymentHistory();
                chk.ActionDescription = "Retrieve payment history";
                chk.SessionKey = Common.GetCookie(this.Page, "sessionKey").ToString();
                chk.ApplicationID = appid;
                chk.EnrolLocationName = lblCompName.Text;
                chk.PermissionCode = "12.57.2";
                #endregion

                #region response
                EnrollmentIssuanceSite.EnrollManagementWS.ResponseDataTypeSelectPaymentHistory getdata = ph.SelectPaymentHistory(chk);
                string StatusCode = getdata.StatusCode;
                string StatusMsg = getdata.StatusMessage;
                #endregion

                #region process

                if (StatusCode == "0")
                {
                    dgPayment.DataSource = getdata.ResultList.Tables[0];
                    dgPayment.DataBind();
                    ViewState["PaymentHistory"] = getdata.ResultList;
                    lblPaymentHistory.Visible = false;
                }
                else
                    throw new Exception(StatusMsg);
                #endregion
            }
            catch (Exception ex)
            {
                divPayment.Visible = false;
                lblPaymentHistory.Visible = true;
                Common.WriteLog(@Server.MapPath("") + Common.GetValue("logPath"), "Get Payment History - " + ex.Message);
            }
            #endregion
        }
        protected void dgPayment_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgPayment.PageIndex = e.NewPageIndex;
            DataSet Ds = (DataSet)ViewState["PaymentHistory"];
            DataView dv = new DataView(Ds.Tables[0]);

            dgPayment.DataSource = dv;
            dgPayment.DataBind();
        }
        private void SetDocumentDetailsVisibility()
        {
            try
            {
                //Document
                trDocPOI.Visible = Convert.ToBoolean(Common.GetValue("PDocPlaceOfIssue"));
                trDocNo.Visible = Convert.ToBoolean(Common.GetValue("PDocNo"));
                trDocDOI.Visible = Convert.ToBoolean(Common.GetValue("PDocDateOfIssue"));
                trDocDOE.Visible = Convert.ToBoolean(Common.GetValue("PDocDateOfExpiry"));

                //Passport
                PassportTitle.Visible = Convert.ToBoolean(Common.GetValue("PPassportTitle"));
                trPassportNo.Visible = Convert.ToBoolean(Common.GetValue("PPassportNo"));
                trPassportDate.Visible = Convert.ToBoolean(Common.GetValue("PDate"));
                trPassportPlace.Visible = Convert.ToBoolean(Common.GetValue("PPlace"));
            }
            catch (Exception ex)
            {
                Common.WriteLog(@Server.MapPath("") + Common.GetValue("logPath"), "View Profile:SetDocumentDetailsVisibility() - " + ex.Message);
            }


        }

    }
}