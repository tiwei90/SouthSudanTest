using EnrollmentIssuanceSite.DALMWS;
using EnrollmentIssuanceSite.EnrollManagementWS;
using EnrollmentIssuanceSite.Shared;
using System;
using System.Data;
using System.Web.UI.WebControls;

namespace EnrollmentIssuanceSite
{
    public partial class QueryApproval : System.Web.UI.Page
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
                SelectBranchList();

                lblsm.Text = Request.QueryString["sm"].ToString();
                HFLevel.Value = Request.QueryString["level"].ToString();



                if (HFLevel.Value == "1")
                {
                    fly.Text = "Visa - Search Pending Pre-approval";
                    lblQuery.Text = Common.GetValue("1stLevelQuery");
                }
                else if (HFLevel.Value == "2")
                {
                    fly.Text = "Visa - Search Pending Final Approval";
                    lblQuery.Text = Common.GetValue("2ndLevelQuery");
                }
                else if (HFLevel.Value == "5")
                {
                    fly.Text = "Visa - Update Approval";
                    lblQuery.Text = Common.GetValue("UpdateAppQuery");
                    btn_viewAll.Visible = false;
                }

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

        protected void dgByName_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string DocType = string.Empty;

            #region select record
            if (e.CommandName == "Select")
            {
                // get the FORMNO of the clicked row
                string FORMNO = e.CommandArgument.ToString();


                Response.Redirect("Approval.aspx?done=" + FORMNO + "&sm=" + lblsm.Text + "&PCName=" + txtCompName.Value + "&level=" + HFLevel.Value + "&arrow=" + Request.QueryString["arrow"]);
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
            dv.RowFilter = lblQuery.Text;
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
                    lblCountry.Text = "Country of Issue";
                    RequiredFieldValidator4.ErrorMessage = "Country of Issue is mandatory";
                    break;
                default:
                    lblName.Text = "Search value";
                    SetRowVisibility(false, false, false, false, false, false, false, false, false);
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
                int PermissionLevel = 0;

                if (HFLevel.Value == "1")
                    PermissionLevel = 8;
                else if (HFLevel.Value == "2")
                    PermissionLevel = 9;
                else if (HFLevel.Value == "5")
                    PermissionLevel = 6;


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
                reqData.PermissionLevel = PermissionLevel;

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
            DataSet ds = (DataSet)ViewState["DataFiltered"];
            DataView dv = new DataView(ds.Tables[0]);

            dv.RowFilter = lblQuery.Text;
            #endregion

            #region display data if there is record match
            int i = dv.Count;
            if (i == 0)
            {
                if (HFLevel.Value == "1")
                {
                    lblMsgSearch.Visible = true;
                    lblMsgSearch.Text = "Record is not available for pre-approval.";
                }
                else if (HFLevel.Value == "2")
                {
                    lblMsgSearch.Visible = true;
                    lblMsgSearch.Text = "Record is not available for final approval.";
                }
                else if (HFLevel.Value == "5")
                {
                    lblMsgSearch.Visible = true;
                    lblMsgSearch.Text = "Record is not available for update approval.";
                }


                lblMsgSearch.Visible = true;
                tbDataGrid.Visible = false;
            }
            else
            {
                dgByName.Visible = true;
                dgByName.DataSource = dv;
                dgByName.PageIndex = 0;
                dgByName.DataBind();
                tbDataGrid.Visible = true;
            }
            #endregion
        }
        private void SEARCH(string SearchMode, string NIS, string FileNo, string AppID, string PassportNo, string PassportCOI)
        {
            #region request Applicant Record by Doc No, AppID
            try
            {

                int PermissionLevel = 0;

                if (HFLevel.Value == "1")
                    PermissionLevel = 8;
                else if (HFLevel.Value == "2")
                    PermissionLevel = 9;
                else if (HFLevel.Value == "5")
                    PermissionLevel = 6;


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
                reqData.PermissionLevel = PermissionLevel;


                ResponseDataTypeGetDetailsByPermission responseData = payment.GetDetailsByPermission(reqData);
                #endregion

                #region get result

                string statusCode = responseData.StatusCode;
                string statusMsg = responseData.StatusMessage;

                #endregion

                #region display result
                if (statusCode == "0")
                {
                    string[] StageCode = new string[6];

                    if (HFLevel.Value == "1")
                    {
                        StageCode[0] = "EM2000";
                        StageCode[1] = "EM2001";
                        StageCode[2] = "EM4002";

                        lblMsgSearch.Text = "Record is not available for pre-approval.";
                    }
                    else if (HFLevel.Value == "2")
                    {
                        StageCode[0] = "EM3000";
                        StageCode[1] = "EM4102";
                        StageCode[2] = "EM3001"; // unsponsored
                        StageCode[3] = "EM2002"; //Sponsored Fee Received
                        StageCode[4] = "EM2003"; //Sponsored Fee Waived

                        lblMsgSearch.Text = "Record is not available for final approval.";
                    }
                    else if (HFLevel.Value == "5")
                    {
                        StageCode[0] = "EM5000";
                        StageCode[1] = "EM4101";
                        StageCode[2] = "EM5100";

                        lblMsgSearch.Text = "Record is not available for update approval.";
                    }

                    for (int i = 0; i < StageCode.Length; ++i)
                    {
                        if (responseData.StageCode.Substring(0, 6) == StageCode[i])
                        {
                            FORMNO.Value = responseData.ApplicationID;
                            tbDataGrid.Visible = false;
                            lblMsgSearch.Visible = false;

                            Response.Redirect("Approval.aspx?arrow=" + Request.QueryString["arrow"] + "&done=" + FORMNO.Value + "&sm=" + lblsm.Text + "&PCName=" + Common.GetCookie(this.Page, "PCName") + "&level=" + HFLevel.Value);
                        }
                        else
                        {
                            lblMsgSearch.Visible = true;
                        }
                    }
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
            else if (SEARCHBY.SelectedValue == "5") // BRANCH
            {
                SEARCHBYBRANCH(DDBRANCH.SelectedValue);
            }

            #endregion    
        }
        protected void btn_viewAll_Click(object sender, EventArgs e)
        {
            if (HFLevel.Value == "1")
            {
                #region LEVEL1

                try
                {
                    EMService Approve = new EMService();
                    RequestdataTypeSelectApproval01List app = new RequestdataTypeSelectApproval01List();
                    app.PermissionCode = Common.GetValue("GetApproval01List");
                    app.ActionDescription = "view all level 1";
                    app.SessionKey = Common.GetCookie(this.Page, "sessionKey");
                    app.EnrolLocationName = txtCompName.Value.Trim();

                    ResponseDataTypeSelectApproval01List getdata = Approve.SelectApproval01List(app);
                    string StatusCode = getdata.StatusCode;
                    string StatusMsg = getdata.StatusMessage;

                    if (StatusCode == "0")
                    {
                        dgByName.Visible = true;
                        dgByName.DataSource = getdata.ResultList.Tables[0];
                        dgByName.DataBind();
                        ViewState["DataFiltered"] = getdata.ResultList;
                        tbDataGrid.Visible = true;

                        if (getdata.ResultList.Tables[0].Rows.Count == 0)
                        {
                            lblSearchError.Visible = true;
                            lblSearchError.Text = "No data available";
                            tbDataGrid.Visible = false;
                        }
                    }
                    else
                    {
                        lblSearchError.Text = StatusMsg;
                        lblSearchError.Visible = true;
                        btnSearch.Visible = true;
                        tbDataGrid.Visible = false;

                        lblSearchError.Text = StatusMsg;
                    }
                }
                catch (Exception Ex)
                {
                    lblSearchError.Visible = true;
                    lblSearchError.Text = Ex.Message;
                    Common.WriteLog(@Server.MapPath("") + Common.GetValue("logPath"), "View All Records (btn_viewAll) - " + Ex.Message);
                }
                #endregion
            }
            else if (HFLevel.Value == "2")
            {
                #region LEVEL2

                try
                {
                    EMService pisservice = new EMService();
                    RequestdataTypeSelectApproval02List request = new RequestdataTypeSelectApproval02List();
                    request.SessionKey = Common.GetCookie(this.Page, "sessionKey");
                    request.ActionDescription = "Select List for Approval02";
                    request.PermissionCode = Common.GetValue("GetApproval02List");
                    request.EnrolLocationName = txtCompName.Value.Trim();

                    ResponseDataTypeSelectApproval02List response = pisservice.SelectApproval02List(request);
                    string StatusCode = response.StatusCode;
                    string StatusMsg = response.StatusMessage;

                    if (StatusCode == "0")
                    {
                        dgByName.Visible = true;
                        dgByName.DataSource = response.ResultList.Tables[0];
                        dgByName.DataBind();

                        ViewState["DataFiltered"] = response.ResultList;
                        tbDataGrid.Visible = true;

                        if (response.ResultList.Tables[0].Rows.Count == 0)
                        {
                            lblSearchError.Visible = true;
                            lblSearchError.Text = "No data available";
                            tbDataGrid.Visible = false;
                        }
                    }
                    else
                    {
                        lblSearchError.Text = StatusMsg;
                        lblSearchError.Visible = true;
                        btnSearch.Visible = true;
                        tbDataGrid.Visible = false;

                        lblSearchError.Text = StatusMsg;
                    }
                }
                catch (Exception Ex)
                {
                    lblSearchError.Visible = true;
                    lblSearchError.Text = Ex.Message;
                    Common.WriteLog(@Server.MapPath("") + Common.GetValue("logPath"), "View All Records (btn_viewAll) - " + Ex.Message);
                }
                #endregion
            }
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
                    throw new Exception(statusMsg);
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
                    throw new Exception(statusMsg);
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
        private void SEARCHBYBRANCH(string branchname)
        {
            #region request Applicant Record By Branch
            try
            {
                int PermissionLevel = 0;

                if (HFLevel.Value == "1")
                    PermissionLevel = 8;
                else if (HFLevel.Value == "2")
                    PermissionLevel = 9;
                else if (HFLevel.Value == "5")
                    PermissionLevel = 6;


                #region calling web service
                EMService enrol = new EMService();
                RequestDataTypeQueryByBranchWithPermission reqData = new RequestDataTypeQueryByBranchWithPermission();

                reqData.ActionDescription = "Get Details By Branch With Permission";
                reqData.SessionKey = Common.GetCookie(this.Page, "sessionKey");
                reqData.LocationName = txtCompName.Value.Trim();
                reqData.PermissionCode = Common.GetValue("QueryByBranch");
                reqData.BranchCode = branchname;
                reqData.PermissionLevel = PermissionLevel;

                ResponseDataTypeQueryByBranchWithPermission responseData = enrol.QueryByBranchWithPermission(reqData);
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
                        ViewState["DataFiltered"] = responseData.ResultList;
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

    }
}
