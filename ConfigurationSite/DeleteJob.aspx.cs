using ConfigurationSite.EMSWS;
using ConfigurationSite.Shared;
using System;

public partial class DeleteJob : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["UserSession"].Values["sessionKey"] == null) Response.Redirect(common.ErPage);

        btnDelete.Attributes.Add("onclick", "return confirmDelete();");

        txtAppID.Focus();
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string status = string.Empty;

        #region request 

        try
        {
            EMService enrol = new EMService();
            RequestDataTypeGetDetails reqData = new RequestDataTypeGetDetails();

            reqData.ActionDescription = "Get Details";
            reqData.SessionKey = Request.Cookies["UserSession"].Values["sessionKey"].ToString();
            reqData.EnrolLocationName = txtCompName.Value.Trim();
            reqData.SearchType = "1";
            reqData.PermissionCode = "12.23.4";
            reqData.ApplicationID = txtAppID.Text;
            reqData.PassportNo = "";
            reqData.PassportCOI = "";
            reqData.DocNo = "";

            ResponseDataTypeGetDetails responseData = enrol.GetDetails(reqData);

            string statusCode = responseData.StatusCode;
            string statusMsg = responseData.StatusMessage;


            #region display result
            if (statusCode == "0")
            {

                lblSearchError.Visible = false;
                tbInfo.Visible = true;
                btnDelete.Visible = true;

                lblAppReason.Text = responseData.AppReason.Substring(0, 1);
                lblIDPerson.Text = responseData.IDPerson.ToString();

                #region MAIN PROFILE
                SURNAME.Text = responseData.Surname;
                FIRSTNAME.Text = responseData.FirstName;
                MIDDLENAME.Text = responseData.MiddleName;

                SEX.Text = (responseData.Sex == "F") ? "Female".ToUpper() : "Male".ToUpper();

                BIRTHCOUNTRY.Text = responseData.BirthCountry;
                NATIONALITY.Text = responseData.Nationality;

                PASSPORTNO.Text = responseData.PassportNo;
                PASSPORTCOI.Text = responseData.PassportCOI;

                STAGECODE.Text = responseData.StageCode;
                DOCTYPE.Text = responseData.DocType;
                ENTRYTYPE.Text = responseData.EntryType;
                APPID.Text = responseData.ApplicationID;

                DOB.Text = common.DayMonthYearDisplay(common.DisplayDateFromDB(responseData.BirthDate.ToString()));
                #endregion

                #region FACEIMAGE
                if (responseData.FaceImage != null)
                {
                    byte[] binData = responseData.FaceImage;
                    string msg = string.Empty;
                    bool HasPhoto = common.DecodeBytetoImage(binData, out msg);
                    if (HasPhoto)
                    {
                        string outputFile = @Server.MapPath("") + common.GetValue("ImgServerPath") + msg;
                        imgPhoto.ImageUrl = common.GetImgUrl(binData, outputFile, msg);
                    }
                    else
                    {
                        imgPhoto.ImageUrl = common.ImgDefaultUrl;
                    }
                }
                else
                {
                    imgPhoto.ImageUrl = common.ImgDefaultUrl;
                }
                #endregion

                CheckAppReason(responseData.AppReason.ToString());

                status = STAGECODE.Text.Substring(0, 6);

                if (status.CompareTo("EM4100") >= 0 || lblAppReason.Text != "1")
                {
                    lblSearchError.Visible = true;
                    lblSearchError.Text = "Record not available for delete";
                    btnDelete.Visible = false;
                    trRemarks.Visible = false;
                }
                else
                {
                    trRemarks.Visible = true;
                    btnDelete.Visible = true;
                    btnDelete.Enabled = true;
                    txtRemarks.Enabled = true;
                    txtRemarks.Text = "";
                    lblSearchError.Visible = false;
                }
            }
            else
            {
                lblSearchError.Text = "No record found";
                lblSearchError.Visible = true;
                btnSearch.Visible = true;
                tbInfo.Visible = false;
                btnDelete.Visible = false;
                trRemarks.Visible = false;
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
            case "4":
                APPREASON.Text = "Emergency".ToUpper();
                break;
            case "5":
                APPREASON.Text = "Additional Passport".ToUpper();
                break;
            default:
                APPREASON.Text = string.Empty;
                break;
        }
        #endregion
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        string status = string.Empty;

        #region request

        try
        {
            EMService enrol = new EMService();
            RequestDataTypeDeleteJob reqData = new RequestDataTypeDeleteJob();

            reqData.PermissionCode = common.GetValue("DeleteApplication");
            reqData.ActionDescription = "Delete Job";
            reqData.SessionKey = Request.Cookies["UserSession"].Values["sessionKey"].ToString();
            reqData.EnrolLocationName = txtCompName.Value.Trim();
            reqData.ApplicationID = APPID.Text;
            reqData.AppReason = Convert.ToInt32(lblAppReason.Text);
            reqData.BirthDate = DOB.Text.Replace("/", "");
            reqData.Nationality = NATIONALITY.Text.Substring(0, 3).Trim();
            reqData.BirthCountry = BIRTHCOUNTRY.Text.Substring(0, 3).Trim();
            reqData.DeleteBy = Request.Cookies["UserSession"].Values["loginName"].ToString().ToUpper();
            reqData.DocType = DOCTYPE.Text.Substring(0, 2);
            if (string.IsNullOrEmpty(ENTRYTYPE.Text))
                reqData.EntryType = "";
            else
                reqData.EntryType = ENTRYTYPE.Text.Substring(0, 2).Trim();

            reqData.Surname = SURNAME.Text;
            reqData.FirstName = FIRSTNAME.Text;
            reqData.IDPerson = Convert.ToInt32(lblIDPerson.Text);
            reqData.MiddleName = MIDDLENAME.Text;
            reqData.PassportCOI = PASSPORTCOI.Text.Substring(0, 3).Trim();
            reqData.PassportNo = PASSPORTNO.Text;

            reqData.Remarks = txtRemarks.Text;

            reqData.StageCode = STAGECODE.Text.Substring(0, 6);

            ResponseDataTypeDeleteJob responseData = enrol.DeleteJob(reqData);

            string statusCode = responseData.StatusCode;
            string statusMsg = responseData.StatusMessage;


            #region display result
            if (statusCode == "0")
            {

                lblSearchError.Visible = true;
                lblSearchError.Text = "Record deleted successfully";
                txtRemarks.Enabled = false;
                btnDelete.Enabled = false;

            }
            else
            {
                lblSearchError.Visible = true;
                lblSearchError.Text = statusMsg;

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
}
