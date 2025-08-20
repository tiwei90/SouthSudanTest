using EnrollmentIssuanceSite.DALMWS;
using EnrollmentIssuanceSite.EnrollManagementWS;
using EnrollmentIssuanceSite.Shared;
using System;
using System.Data;
using System.Web.UI.WebControls;

namespace EnrollmentIssuanceSite
{
    public partial class QueryPayment : System.Web.UI.Page
    {
        private static string sm;
        private static string strQueryByName = "StageCode Like 'EM1000%' OR StageCode Like 'EM3002%'";

        protected void Page_Load(object sender, EventArgs e)
        {
            this.BIRTHDATE.Text = Request[this.BIRTHDATE.UniqueID];
            btnSearch.Focus();

            if (!Page.IsPostBack)
            {
                txtCompName.Value = Request.QueryString["PC"];
                SelectCountryList();
                SelectBranchList();
                sm = Request.QueryString["sm"];
            }
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
        protected void dgByName_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            #region select record
            if (e.CommandName == "Select")
            {
                // get the FORMNO of the clicked row
                string FORMNO = e.CommandArgument.ToString();
                // Redirect to another page           
                Response.Redirect("PaymentDetails.aspx?arrow=" + Request.QueryString["arrow"] + "&done=" + FORMNO + "&sm=" + sm + "&PC=" + txtCompName.Value);

            }
            #endregion
        }
        private DataView BindGrid()
        {
            #region ***
            DataSet Ds = (DataSet)ViewState["Data"];
            DataView dv = new DataView(Ds.Tables[0]);
            dv.RowFilter = strQueryByName;
            return dv;
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
        protected void SEARCHBY_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region ***
            ClearField();
            Label31.Visible = true;

            switch (SEARCHBY.SelectedValue)
            {
                case "1":
                    lblName.Text = "Application ID";
                    SetRowVisibility(false, false, false, false, false, true, true, false, false);
                    RFVAppID.ErrorMessage = "Please enter Application ID before pressing the <SEARCH> button";
                    RFVAppID.Enabled = true;
                    SEARCHVALUE.Text = string.Empty;
                    break;
                case "5":
                    SetRowVisibility(false, false, false, false, false, false, true, false, true);
                    break;
                case "4":
                    lblName.Text = "Surname";
                    SetRowVisibility(true, false, true, true, false, true, true, false, false);
                    RFVAppID.Enabled = false;
                    SEARCHVALUE.Text = string.Empty;
                    Label31.Visible = false;
                    break;
                case "2":
                    lblName.Text = "Passport No";
                    SetRowVisibility(false, false, false, false, false, true, true, true, false);
                    RFVAppID.ErrorMessage = "Passport Number is mandatory";
                    RFVAppID.Enabled = true;
                    SEARCHVALUE.Text = string.Empty;
                    BIRTHCOUNTRY.SelectedIndex = -1;
                    break;
                default:
                    lblName.Text = "Search value";
                    SetRowVisibility(false, false, false, false, false, false, false, false, false);
                    SEARCHVALUE.Text = string.Empty;
                    break;
            }
            #endregion

        }
        private void SetRowVisibility(bool DOB, bool Info, bool First, bool Middle, bool DGrid, bool SearchVal, bool Clear, bool countryofbirth, bool branch)
        {
            #region ***
            trDOB.Visible = DOB;
            trFirstname.Visible = First;
            trMiddlename.Visible = Middle;
            tbDataGrid.Visible = DGrid;
            trSearchValue.Visible = SearchVal;
            trBirthCountry.Visible = countryofbirth;
            btnClear.Enabled = Clear;
            trBranch.Visible = branch;
            #endregion
        }

        private void SEARCHBYNAME(string SearchMode, string SurName, string First, string Middle, string Birthdate)
        {
            #region request Applicant Record By Name
            try
            {
                #region calling web service
                EMService enrol = new EMService();
                RequestDataTypeQueryByName reqData = new RequestDataTypeQueryByName();

                reqData.ActionDescription = "Get Details By Name";
                reqData.SessionKey = Common.GetCookie(this.Page, "sessionKey");
                reqData.LocationName = txtCompName.Value.Trim();
                reqData.PermissionCode = Common.GetValue("QueryByName");
                reqData.Surname = SurName.Trim();
                reqData.FirstName = First.Trim();
                reqData.MiddleName = Middle.Trim();
                reqData.BirthDate = Birthdate;

                ResponseDataTypeQueryByName responseData = enrol.QueryByName(reqData);
                #endregion

                #region response from web service
                string statusCode = responseData.StatusCode;
                string statusMsg = responseData.StatusMessage;


                if (statusCode != "0")
                {
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
                        lblMsgSearch.Visible = false;
                        tbDataGrid.Visible = true;
                        ViewState["Data"] = responseData.ResultList;
                        FilterDG();
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
        private void FilterDG()
        {
            #region Filter Row
            DataSet ds = (DataSet)ViewState["Data"];
            DataView dv = new DataView(ds.Tables[0]);

            dv.RowFilter = strQueryByName;
            #endregion

            #region display data if there is record match
            int i = dv.Count;
            if (i == 0)
            {
                lblMsgSearch.Text = "Record is not available to make payment.";
                lblMsgSearch.Visible = true;
                tbDataGrid.Visible = false;
            }
            else
            {
                dgByName.DataSource = dv;
                dgByName.PageIndex = 0;
                dgByName.DataBind();
                tbDataGrid.Visible = true;
            }
            #endregion
        }
        private void SEARCH(string SearchMode, string NIS, string AppID, string PassportNo, string PassportCOI)
        {
            #region request Applicant Record by File No, AppID
            try
            {
                #region calling web service
                EMService payment = new EMService();
                RequestDataTypeGetDetails reqData = new RequestDataTypeGetDetails();

                reqData.ActionDescription = "Get Details";
                reqData.SessionKey = Common.GetCookie(this.Page, "sessionKey").ToString();
                reqData.EnrolLocationName = txtCompName.Value;
                reqData.PermissionCode = Common.GetValue("GetDetailsPermissionCode");
                reqData.SearchType = SearchMode;
                reqData.ApplicationID = AppID.Trim();
                reqData.DocNo = string.Empty;
                reqData.PassportNo = PassportNo.Trim();
                reqData.PassportCOI = PassportCOI;

                ResponseDataTypeGetDetails responseData = payment.GetDetails(reqData);
                #endregion

                #region get result

                string statusCode = responseData.StatusCode;
                string statusMsg = responseData.StatusMessage;

                #endregion

                #region display result
                if (statusCode == "0")
                {

                    #region check stage code before display record
                    if (responseData.StageCode.Substring(0, 6) == "EM1000" || responseData.StageCode.Substring(0, 6) == "EM3002")
                    {
                        FORMNO.Value = responseData.ApplicationID;
                        tbDataGrid.Visible = false;
                        lblMsgSearch.Visible = false;
                        Response.Redirect("PaymentDetails.aspx?arrow=" + Request.QueryString["arrow"] + "&done=" + FORMNO.Value + "&sm=" + sm + "&PC=" + txtCompName.Value);
                    }
                    else
                    {
                        lblMsgSearch.Visible = true;
                        lblMsgSearch.Text = "Record is not available to make payment";
                    }
                    #endregion 

                }
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
                Common.WriteLog(@Server.MapPath("") + Common.GetValue("logPath"), "Search (Search) - " + ex.Message);
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
            string DOB = string.Empty;
            if (BIRTHDATE.Text != string.Empty)
                DOB = BIRTHDATE.Text.Replace("/", "");

            if (SEARCHBY.SelectedValue == "4") // NAME
            {
                SEARCHBYNAME(SEARCHBY.SelectedValue, searchVal, firstname, middlename, DOB);
            }
            else if (SEARCHBY.SelectedValue == "1") // APPLICATION ID
            {
                SEARCH(SEARCHBY.SelectedValue, string.Empty, searchVal, string.Empty, string.Empty);
            }
            else if (SEARCHBY.SelectedValue == "5") // BRANCH
            {
                SEARCHBYBRANCH(DDBRANCH.SelectedValue);
            }
            else if (SEARCHBY.SelectedValue == "2") // PASSPORTNO
            {
                SEARCH(SEARCHBY.SelectedValue, string.Empty, string.Empty, searchVal, cob);
            }
            #endregion

        }
        protected void btn_viewAll_Click(object sender, EventArgs e)
        {
            #region***
            SEARCHBYNAME("4", string.Empty, string.Empty, string.Empty, string.Empty);
            #endregion
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
                reqData.EnrolLocationName = txtCompName.Value;
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
            DDBRANCH.SelectedIndex = -1;
        }
        private void SEARCHBYBRANCH(string branchname)
        {
            #region request Applicant Record By Branch
            try
            {
                #region calling web service
                EMService enrol = new EMService();
                RequestDataTypeQueryByBranch reqData = new RequestDataTypeQueryByBranch();

                reqData.ActionDescription = "Get Details By Branch";
                reqData.SessionKey = Common.GetCookie(this.Page, "sessionKey");
                reqData.LocationName = txtCompName.Value.Trim();
                reqData.PermissionCode = Common.GetValue("QueryByBranch");
                reqData.BranchCode = branchname;

                ResponseDataTypeQueryByBranch responseData = enrol.QueryByBranch(reqData);
                #endregion

                #region response from web service
                string statusCode = responseData.StatusCode;
                string statusMsg = responseData.StatusMessage;


                if (statusCode != "0")
                {
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
                        lblMsgSearch.Visible = false;
                        tbDataGrid.Visible = true;
                        ViewState["Data"] = responseData.ResultList;
                        FilterDG();
                    }
                }
                #endregion
            }
            catch (Exception ex)
            {
                lblSearchError.Text = ex.Message;
                lblSearchError.Visible = true;
                Common.WriteLog(@Server.MapPath("") + Common.GetValue("logPath"), "Search By Branch- " + ex.Message);
            }
            #endregion
        }
        private void SelectBranchList()
        {
            #region ***
            try
            {
                #region connecting to web service
                DALMService enrol = new DALMService();
                RequestDataTypeSelectBranch reqData = new RequestDataTypeSelectBranch();

                reqData.ActionDescription = "Get Branch List";
                reqData.SessionKey = Common.GetCookie(this.Page, "sessionKey");
                reqData.PermissionCode = Common.GetValue("SelectBranchList");

                #endregion

                #region response
                ResponseDataTypeSelectBranch responseData = enrol.SelectBranchList(reqData);

                string statusCode = responseData.StatusCode;
                string statusMsg = responseData.StatusMessage;
                #endregion

                #region analize result
                if (statusCode == "0")
                {


                    DataSet Ds = (DataSet)responseData.ResultList;
                    DDBRANCH.DataSource = Ds.Tables[0];
                    DDBRANCH.DataValueField = "BranchCode";
                    DDBRANCH.DataTextField = "BranchName";
                    DDBRANCH.DataBind();
                    DDBRANCH.Items.Insert(0, new ListItem("-SELECT-", ""));
                }
                else
                    throw new Exception();
                #endregion
            }
            catch (Exception ex)
            {
                lblSearchError.Text = ex.Message;
                lblSearchError.Visible = true;
                Common.WriteLog(@Server.MapPath("") + Common.GetValue("logPath"), "Select Branch List - " + ex.Message);
            }
            #endregion
        }

    }
}
