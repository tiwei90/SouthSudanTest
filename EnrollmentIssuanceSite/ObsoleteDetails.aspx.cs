using EnrollmentIssuanceSite.EnrollManagementWS;
using EnrollmentIssuanceSite.Shared;
using System;

namespace EnrollmentIssuanceSite
{
    public partial class ObsoleteDetails : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            #region ***

            if (!Page.IsPostBack)
            {

                txtCompName.Value = Request.QueryString["PC"];
                if (Request.QueryString["done"] != null)
                {
                    IsNew.Value = Request.QueryString["done"];
                    GetDetails(IsNew.Value);
                }
                string sm = Request.QueryString["sm"];

            }
            #endregion
        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            #region STATUS UPDATE
            //try
            //{
            //    #region calling web service
            //    enrollment.VISService enrol = new enrollment.VISService();
            //    enrollment.RequestDataTypeStatusUpdate reqData = new enrollment.RequestDataTypeStatusUpdate();

            //    reqData.PermissionCode = common.GetValue("ObsoleteDoc");
            //    reqData.ActionDescription = "Status Update";
            //    reqData.SessionKey = common.GetCookie(this.Page, "sessionKey");
            //    reqData.ApplicationID = IsNew.Value;
            //    reqData.EnrolLocationName = txtCompName.Value.Trim();

            //    reqData.StageCode = "EM7000";

            //    reqData.OldDocName = FIRSTNAME.Text + " " + MIDDLENAME.Text + " " + SURNAME.Text;
            //    reqData.OldDocNo = DOCNO.Text.ToUpper();
            //    reqData.OldDocPOI = DOCPOI.Text;
            //    #region OLDDOCDOI
            //    if (DOCDOI.Text != string.Empty)
            //    {
            //        reqData.OldDocDOI = DOCDOI.Text.Replace("/", "");
            //    }
            //    else
            //    {
            //        reqData.OldDocDOI = null;
            //    }
            //    #endregion

            //    reqData.OldDocLostCtry = string.Empty;
            //    reqData.OldDocLostPlace = string.Empty;
            //    reqData.OldDocLostDate = null;
            //    reqData.OtherOldDocLostPlace = string.Empty;               
            //    reqData.PoliceReportedInd = 0;
            //    reqData.PoliceReportSubmittedInd = 0;       

            //    reqData.PoliceReportSubmissionPlace = string.Empty;
            //    reqData.OtherPoliceReportSubmissionPlace = string.Empty;
            //    reqData.PoliceReportSubmissionDate = null;

            //    #endregion

            //    #region response
            //    enrollment.ResponseDataTypeStatusUpdate responseData = enrol.StatusUpdate(reqData);
            //    string statusCode = responseData.StatusCode;
            //    string statusMsg = responseData.StatusMessage;

            //    if (statusCode == "0")
            //    {
            //        lblResult.Visible = true;
            //        btnSave.Visible = false;

            //    }
            //    else
            //    {
            //        lblResult.Visible = true;
            //        lblResult.Text = statusMsg;
            //        btnSave.Visible = true;
            //    }
            //    #endregion
            //}
            //catch (Exception ex)
            //{
            //    lblResult.Text = ex.Message;
            //    lblResult.Visible = true;
            //}
            #endregion
        }
        protected void btnClearAll_Click(object sender, EventArgs e)
        {

        }

        private void GetDetails(string AppID)
        {
            #region request Applicant Record AppID
            try
            {
                #region calling web service
                EMService enrol = new EMService();
                RequestDataTypeGetDetails reqData = new RequestDataTypeGetDetails();

                reqData.ActionDescription = "Get Details";
                reqData.SessionKey = Common.GetCookie(this.Page, "sessionKey");
                reqData.EnrolLocationName = txtCompName.Value.Trim();
                reqData.SearchType = "1";
                reqData.PermissionCode = Common.GetValue("GetDetailsPermissionCode");
                reqData.ApplicationID = AppID;
                reqData.DocNo = string.Empty;
                reqData.PassportCOI = string.Empty;
                reqData.PassportNo = string.Empty;

                ResponseDataTypeGetDetails responseData = enrol.GetDetails(reqData);
                #endregion

                #region get result

                string statusCode = responseData.StatusCode;
                string statusMsg = responseData.StatusMessage;
                #endregion

                #region display result
                if (statusCode == "0")
                {
                    #region MAIN PROFILE
                    SURNAME.Text = responseData.Surname;
                    FIRSTNAME.Text = responseData.FirstName;
                    MIDDLENAME.Text = responseData.MiddleName;
                    SEX.Text = (responseData.Sex == "F") ? "Female".ToUpper() : "Male".ToUpper();
                    DOCTYPE.Text = responseData.DocType;
                    BIRTHPLACE.Text = responseData.BirthPlace;
                    NATIONALINSURANCENO.Text = responseData.NationalIDNo;


                    DOB.Text = Convert.ToDateTime(responseData.BirthDate).ToString("dd/MM/yyyy");
                    NATIONALITY.Text = responseData.Nationality;
                    BIRTHCOUNTRY.Text = responseData.BirthCountry;
                    #endregion

                    #region FACEIMAGE
                    if (responseData.FaceImage != null)
                    {
                        byte[] binData = responseData.FaceImage;
                        string msg = string.Empty;
                        bool HasPhoto = Common.DecodeBytetoImage(binData, out msg);
                        if (HasPhoto)
                        {
                            string outputFile = @Server.MapPath("") + Common.GetValue("ImgServerPath") + msg;
                            imgPhoto.ImageUrl = Common.GetImgUrl(binData, outputFile, msg);
                        }
                        else
                        {
                            imgPhoto.ImageUrl = Common.ImgDefaultUrl;
                        }
                    }
                    #endregion

                    #region Visa Details
                    DOCNO.Text = responseData.DocNo;
                    DOCDOE.Text = Convert.ToDateTime(responseData.DocExpiryDate).ToString("dd/MM/yyyy");
                    DOCDOI.Text = Convert.ToDateTime(responseData.DocIssueDate).ToString("dd/MM/yyyy");
                    ENTRYTYPE.Text = responseData.EntryType;
                    DOCTYPE.Text = responseData.DocType;
                    DOCPOI.Text = responseData.DocIssPlace;
                    #endregion

                    #region PASSPORT DETAILS
                    PASSPORTNO.Text = responseData.PassportNo;
                    PASSPORTCOI.Text = responseData.PassportCOI;
                    PASSPORTDOE.Text = Convert.ToDateTime(responseData.PassportDOE).ToString("dd/MM/yyyy");
                    PASSPORTDOI.Text = Convert.ToDateTime(responseData.PassportDOI).ToString("dd/MM/yyyy");
                    #endregion
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



    }
}
