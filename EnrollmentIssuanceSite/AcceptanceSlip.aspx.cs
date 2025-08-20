using EnrollmentIssuanceSite.EnrollManagementWS;
using EnrollmentIssuanceSite.Shared;
using System;

namespace EnrollmentIssuanceSite
{
    public partial class AcceptanceSlip : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                lblOfflineMsg.Visible = Convert.ToBoolean(Common.GetValue("OfflineMsg"));
                GetDetails();
                GetBranchName();
            }

        }
        private void GetDetails()
        {
            #region request Applicant Record AppID      
            try
            {
                #region calling web service
                EMService enrol = new EMService();
                RequestDataTypeGetDetails reqData = new RequestDataTypeGetDetails();

                reqData.ActionDescription = "Get Details";
                reqData.SessionKey = Common.GetCookie(this.Page, "sessionKey");
                reqData.EnrolLocationName = Request.QueryString["PC"];
                reqData.SearchType = "1";
                reqData.PermissionCode = Common.GetValue("GetDetailsPermissionCode");
                reqData.ApplicationID = Request.QueryString["done"];
                reqData.DocNo = string.Empty;
                reqData.PassportCOI = string.Empty;
                reqData.PassportNo = string.Empty;

                ResponseDataTypeGetDetails responseData = enrol.GetDetails(reqData);
                #endregion

                #region get result from web service
                string statusCode = responseData.StatusCode;
                string statusMsg = responseData.StatusMessage;
                #endregion

                #region analyze result

                if (statusCode == "0")
                {
                    SURNAME.Text = responseData.Surname;
                    FIRSTNAME.Text = responseData.FirstName;
                    MIDDLENAME.Text = responseData.MiddleName;
                    SEX.Text = (responseData.Sex == "F") ? "Female".ToUpper() : "Male".ToUpper();
                    BIRTHCOUNTRY.Text = responseData.BirthCountry;
                    NATIONALITY.Text = responseData.Nationality;
                    BIRTHDATE.Text = Convert.ToDateTime(responseData.BirthDate).ToString("dd/MM/yyyy");
                    BIRTHPLACE.Text = responseData.BirthPlace;
                    NATIONALINSURANCENO.Text = responseData.PassportNo;
                    EXPIRYDATE.Text = Convert.ToDateTime(responseData.PassportDOE).ToString("dd/MM/yyyy");

                    FORMNO.Text = responseData.ApplicationID;
                    DOCTYPE.Text = responseData.DocType;
                    SUBDOCTYPE.Text = responseData.EntryType;
                    ENROLDATE.Text = Convert.ToDateTime(responseData.EnrolTime).ToString("dd/MM/yyyy");
                    APPREASON.Text = responseData.AppReason;

                    COLDATE.Text = Convert.ToDateTime(responseData.CollectionDate).ToString("dd/MM/yyyy");

                }
                else
                    throw new Exception(statusMsg);
                #endregion
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                lblError.Visible = true;
                Common.WriteLog(@Server.MapPath("") + Common.GetValue("logPath"), "Get Details :" + ex.Message);
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
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("QueryReprint.aspx?sm=" + Request.QueryString["sm"] + "&arrow=" + Request.QueryString["arrow"] + "&PC=" + Request.QueryString["PC"]);
        }
        private void GetBranchName()
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
                reqData.EnrolLocationName = Request.QueryString["PC"];

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
                    Common.WriteLog(@Server.MapPath("") + Common.GetValue("logPath"), "Get Branch Name: " + statusCode + "-" + statusMsg);
                }
                #endregion
            }
            catch (Exception ex)
            {
                Common.WriteLog(@Server.MapPath("") + Common.GetValue("logPath"), "Get Branch Name: " + ex.Message);
            }
            #endregion
        }
    }
}
