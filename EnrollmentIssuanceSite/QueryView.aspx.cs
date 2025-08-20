using EnrollmentIssuanceSite.EnrollManagementWS;
using EnrollmentIssuanceSite.Shared;
using System;
using System.Data;
using System.Web.UI.WebControls;

namespace EnrollmentIssuanceSite
{
    public partial class QueryView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            #region ***
            if (Common.GetCookie(this.Page, "sessionKey") == null) Response.Redirect(Common.ErPage);

            lblSearchError.Visible = false;
            lblSearchError.Text = string.Empty;

            this.BIRTHDATE.Text = Request[this.BIRTHDATE.UniqueID];
            btnSearch.Focus();


            if (!Page.IsPostBack)
            {
                SelectCountryList();

                lblsm.Text = Request.QueryString["sm"].ToString();
                HFLevel.Value = Request.QueryString["level"].ToString();
            }
            #endregion
        }

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            #region ***
            if ((SEARCHFIRST.Text.Trim().Length > 0) || (SEARCHMIDDLE.Text.Trim().Length > 0) || (SEARCHVALUE.Text.Trim().Length > 0))
            {
                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
            }
            #endregion
        }

        private void SetRowVisibility(bool DOB, bool Info, bool First, bool Middle, bool DGrid, bool SearchVal, bool Clear, bool countryofbirth)
        {
            #region ***
            trDOB.Visible = DOB;
            trFirstname.Visible = First;
            trMiddlename.Visible = Middle;
            tbDataGrid.Visible = DGrid;
            trSearchValue.Visible = SearchVal;
            trBirthCountry.Visible = countryofbirth;
            btnClear.Enabled = Clear;
            #endregion
        }

        protected void dgByName_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string DocType = string.Empty;

            #region select record
            if (e.CommandName == "Select")
            {
                // get the FORMNO of the clicked row
                string FORMNO = e.CommandArgument.ToString();

                Response.Redirect("Approval.aspx?done=" + FORMNO + "&sm=" + lblsm.Text + "&PCName=" + txtCompName.Value + "&level=" + Request.QueryString["level"].ToString() + "&arrow=" + Request.QueryString["arrow"]);
            }
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
            DataSet Ds = (DataSet)ViewState["DataFiltered"];
            DataView dv = new DataView(Ds.Tables[0]);
            return dv;
            #endregion

        }
        protected void SEARCHBY_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region ***
            ClearField();

            switch (SEARCHBY.SelectedValue)
            {
                case "1":
                    lblName.Text = "Application ID";
                    SetRowVisibility(false, false, false, false, false, true, true, false);
                    RFVAppID.ErrorMessage = "Please enter Application ID before pressing the <SEARCH> button";
                    RFVAppID.Enabled = true;
                    SEARCHVALUE.Text = string.Empty;
                    break;

                case "3":
                    lblName.Text = "Document No";
                    SetRowVisibility(false, false, false, false, false, true, true, false);
                    RFVAppID.ErrorMessage = "Please enter Document No before pressing the <SEARCH> button";
                    RFVAppID.Enabled = true;
                    SEARCHVALUE.Text = string.Empty;
                    break;
                case "4":
                    lblName.Text = "Surname";
                    SetRowVisibility(true, false, true, true, false, true, true, false);
                    RFVAppID.Enabled = false;
                    SEARCHVALUE.Text = string.Empty;
                    Label31.Visible = false;
                    break;
                case "2":
                    lblName.Text = "Passport No";
                    SetRowVisibility(false, false, false, false, false, true, true, true);
                    RFVAppID.ErrorMessage = "Passport Number is mandatory";
                    RFVAppID.Enabled = true;
                    SEARCHVALUE.Text = string.Empty;
                    BIRTHCOUNTRY.SelectedIndex = -1;
                    lblCountry.Text = "Country of Issue";
                    RequiredFieldValidator4.ErrorMessage = "Country of Issue is mandatory";
                    break;
                default:
                    lblName.Text = "Search value";
                    SetRowVisibility(false, false, false, false, false, false, false, false);
                    SEARCHVALUE.Text = string.Empty;


                    break;
            }
            #endregion

        }
        private void SEARCHBYNAME(string SearchMode, string SurName, string First, string Middle, string Birthdate)
        {
            #region request Applicant Record By Name
            try
            {
                #region calling web service
                EMService enrol = new EMService();
                RequestDataTypeQueryByNameWithPermission reqData = new RequestDataTypeQueryByNameWithPermission();

                reqData.ActionDescription = "Get Details By Name With Permission";
                reqData.SessionKey = Common.GetCookie(this.Page, "sessionKey");
                reqData.LocationName = txtCompName.Value.Trim();
                reqData.PermissionCode = Common.GetValue("QueryByNameCode");
                reqData.Surname = SurName.Trim();
                reqData.FirstName = First.Trim();
                reqData.MiddleName = Middle.Trim();
                reqData.BirthDate = Birthdate;
                reqData.PermissionLevel = 10; //Profile Viewer, 12.95.10

                ResponseDataTypeQueryByNameWithPermission responseData = enrol.QueryByNameWithPermission(reqData);
                #endregion

                #region response from web service
                string statusCode = responseData.StatusCode;
                string statusMsg = responseData.StatusMessage;


                if (statusCode != "0")
                {
                    //lblMsgSearch.Text = common.NORECORD;
                    lblMsgSearch.Text = statusMsg;
                    lblMsgSearch.Visible = true;
                    btnSearch.Visible = true;
                    tbDataGrid.Visible = false;
                }
                else
                {
                    int i = responseData.ResultList.Tables[0].Rows.Count;
                    if (i == 0)
                    {
                        lblMsgSearch.Text = Common.NORECORD;
                        lblMsgSearch.Visible = true;
                        tbDataGrid.Visible = false;
                    }
                    else
                    {
                        ViewState["DataFiltered"] = responseData.ResultList;
                        dgByName.Visible = true;
                        dgByName.DataSource = responseData.ResultList.Tables[0];
                        dgByName.PageIndex = 0;
                        dgByName.DataBind();
                        tbDataGrid.Visible = true;
                    }
                }
                #endregion
            }
            catch (Exception ex)
            {
                lblSearchError.Text = ex.Message;
                lblSearchError.Visible = true;
                Common.WriteLog(@Server.MapPath("") + Common.GetValue("logPath"), "Search By Name (SearchByName) - " + ex.Message);
            }
            #endregion
        }

        private void SEARCH(string SearchMode, string NIS, string FileNo, string AppID, string PassportNo, string PassportCOI)
        {
            #region request Applicant Record by Doc No, AppID
            try
            {
                #region calling web service
                EMService payment = new EMService();
                RequestDataTypeGetDetailsByPermission reqData = new RequestDataTypeGetDetailsByPermission();

                reqData.ActionDescription = "Get Details By Permission";
                reqData.SessionKey = Common.GetCookie(this.Page, "sessionKey");
                reqData.EnrolLocationName = txtCompName.Value;
                reqData.SearchType = SearchMode;
                reqData.PermissionCode = Common.GetValue("GetDetailsPermissionCode");
                reqData.ApplicationID = AppID.Trim();
                reqData.DocNo = string.Empty;
                reqData.PassportNo = PassportNo.Trim();
                reqData.PassportCOI = PassportCOI;
                reqData.PermissionLevel = 10; //Profile Viewer, 12.95.10

                ResponseDataTypeGetDetailsByPermission responseData = payment.GetDetailsByPermission(reqData);
                #endregion

                #region get result

                string statusCode = responseData.StatusCode;
                string statusMsg = responseData.StatusMessage;

                #endregion

                #region display result
                if (statusCode == "0")
                    Response.Redirect("Approval.aspx?arrow=" + Request.QueryString["arrow"] + "&done=" + responseData.ApplicationID + "&sm=" + lblsm.Text + "&PCName=" + Common.GetCookie(this.Page, "PCName") + "&level=" + HFLevel.Value);
                else
                {
                    lblSearchError.Text = statusMsg;
                    lblSearchError.Visible = true;
                    btnSearch.Visible = true;
                    tbDataGrid.Visible = false;
                }
                #endregion
            }
            catch (Exception ex)
            {
                lblSearchError.Visible = true;
                lblSearchError.Text = ex.Message;
                Common.WriteLog(@Server.MapPath("") + Common.GetValue("logPath"), "Search By Application ID, FIleNo (SEARCH) - " + ex.Message);
            }

            #endregion
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            #region search

            string searchVal = SEARCHVALUE.Text.ToUpper();
            string firstname = SEARCHFIRST.Text.ToUpper();
            string middlename = SEARCHMIDDLE.Text.ToUpper();
            string cob = BIRTHCOUNTRY.SelectedValue;
            string DOB = BIRTHDATE.Text.Replace("/", "");

            if (SEARCHBY.SelectedValue == "4") // NAME
            {
                SEARCHBYNAME(SEARCHBY.SelectedValue, searchVal, firstname, middlename, DOB);
            }
            else if (SEARCHBY.SelectedValue == "1") // APPLICATION ID
            {
                SEARCH(SEARCHBY.SelectedValue, string.Empty, string.Empty, searchVal, string.Empty, string.Empty);
            }
            else if (SEARCHBY.SelectedValue == "2") // PASSPORTNO
            {
                SEARCH(SEARCHBY.SelectedValue, string.Empty, searchVal, string.Empty, searchVal, cob);
            }

            #endregion
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            ClearField();
        }

        private void ClearField()
        {
            SEARCHVALUE.Text = string.Empty;
            SEARCHFIRST.Text = string.Empty;
            SEARCHMIDDLE.Text = string.Empty;
            BIRTHDATE.Text = string.Empty;
            BIRTHCOUNTRY.SelectedIndex = -1;
        }

        private void SelectCountryList()
        {
            #region ***
            try
            {
                #region connecting to web service
                EMService enrol = new EMService();
                RequestDataTypeSelectCountry reqData = new RequestDataTypeSelectCountry();

                reqData.ActionDescription = "Get Country";
                reqData.SessionKey = Common.GetCookie(this.Page, "sessionKey");
                reqData.EnrolLocationName = Common.GetCookie(this.Page, "PCName");
                reqData.PermissionCode = Common.GetValue("SelectCountry");
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
                    }
                    BIRTHCOUNTRY.Items.Insert(0, new ListItem("-SELECT-", ""));

                    #endregion
                }
                else
                {
                    lblSearchError.Text = statusMsg;
                    lblSearchError.Visible = true;
                }
                #endregion
            }
            catch (Exception ex)
            {
                lblSearchError.Text = ex.Message;
                lblSearchError.Visible = true;
                Common.WriteLog(@Server.MapPath("") + Common.GetValue("logPath"), "Select Country List(SelectCountryList) - " + ex.Message);
            }
            #endregion
        }
    }
}
