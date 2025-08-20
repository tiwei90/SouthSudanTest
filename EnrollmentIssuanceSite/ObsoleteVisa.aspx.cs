using EnrollmentIssuanceSite.EnrollManagementWS;
using EnrollmentIssuanceSite.Shared;
using System;
using System.Data;
using System.Web.UI.WebControls;

namespace EnrollmentIssuanceSite
{
    public partial class usercontrol_ObsoletePassport : System.Web.UI.Page
    {
        const string code = "EM6000";
        protected void Page_Load(object sender, EventArgs e)
        {
            this.BIRTHDATE.Text = Request[this.BIRTHDATE.UniqueID];
            btnSearch.Focus();
            if (!Page.IsPostBack)
            {
                txtCompName.Value = Request.QueryString["PC"];
                getCountryList();

            }
        }
        protected void SEARCHBY_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchVisibility(SEARCHBY.SelectedValue);
        }
        private void SetRowVisibility(bool DOB, bool First, bool Middle, bool DGrid, bool SearchValue, bool Clear, bool COI)
        {
            #region ***
            trDOB.Visible = DOB;
            trFirstname.Visible = First;
            trMiddlename.Visible = Middle;
            tbDataGrid.Visible = DGrid;
            trSearchValue.Visible = SearchValue;
            btnClear.Disabled = Clear;
            trCOI.Visible = COI;
            #endregion
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            #region search

            string searchVal = SEARCHVALUE.Text.Trim().ToUpper();
            string firstname = SEARCHFIRST.Text.Trim().ToUpper();
            string middlename = SEARCHMIDDLE.Text.Trim().ToUpper();
            string COI = DDPASSPORTPOI.SelectedValue;
            string DOB = string.Empty;
            if (BIRTHDATE.Text != string.Empty)
                DOB = BIRTHDATE.Text.Replace("/", "");

            if (SEARCHBY.SelectedValue == "4") // NAME
            {
                SEARCHBYNAME(SEARCHBY.SelectedValue, searchVal, firstname, middlename, DOB);
            }
            else if (SEARCHBY.SelectedValue == "2") // PASSPORTNO
            {
                SEARCH(SEARCHBY.SelectedValue, searchVal, string.Empty, COI, string.Empty);
            }
            else if (SEARCHBY.SelectedValue == "3") // DOC NO
            {
                SEARCH(SEARCHBY.SelectedValue, string.Empty, searchVal, COI, string.Empty);
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
                RequestDataTypeQueryByName reqData = new RequestDataTypeQueryByName();

                reqData.ActionDescription = "Get Details By Name";
                reqData.SessionKey = Common.GetCookie(this.Page, "sessionKey");
                reqData.LocationName = txtCompName.Value.Trim();
                reqData.PermissionCode = Common.GetValue("QueryByName");
                reqData.Surname = SurName;
                reqData.FirstName = First;
                reqData.MiddleName = Middle;
                reqData.BirthDate = Birthdate;

                ResponseDataTypeQueryByName responseData = enrol.QueryByName(reqData);
                #endregion

                #region response from web service
                string statusCode = responseData.StatusCode;
                string statusMsg = responseData.StatusMessage;

                if (statusCode != "0")
                {
                    lblSearchError.Text = statusMsg;
                    lblSearchError.Visible = true;
                    btnSearch.Visible = true;
                    tbDataGrid.Visible = false;

                }
                else
                {
                    ViewState["DataFiltered"] = responseData.ResultList;
                    FilterDG();
                }
                #endregion
            }
            catch (Exception ex)
            {
                lblSearchError.Text = ex.Message;
                lblSearchError.Visible = true;
            }
            #endregion
        }
        private void FilterDG()
        {
            #region Filter Row
            DataSet Ds = (DataSet)ViewState["DataFiltered"];
            DataView Dv = new DataView(Ds.Tables[0]);
            string query = "StageCode LIKE 'EM6000%'";
            Dv.RowFilter = query;
            #endregion

            #region display data if there is record match
            int i = Dv.Count;
            if (i == 0)
            {
                lblMsgSearch.Text = "Record is not available to obsolete.";
                lblMsgSearch.Visible = true;
                tbDataGrid.Visible = false;
            }
            else
            {
                #region display datagrid
                dgByName.DataSource = Dv;
                dgByName.PageIndex = 0;
                dgByName.DataBind();
                tbDataGrid.Visible = true;
                #endregion

            }
            #endregion

        }
        private void SEARCH(string SearchMode, string PassportNo, string DocNo, string COI, string APPID)
        {
            #region request Applicant Record by NIS, Doc No, AppID
            try
            {
                #region calling web service
                EMService enrol = new EMService();
                RequestDataTypeGetDetails reqData = new RequestDataTypeGetDetails();

                reqData.ActionDescription = "Get Details";
                reqData.SessionKey = Common.GetCookie(this.Page, "sessionKey");
                reqData.EnrolLocationName = txtCompName.Value.Trim();
                reqData.SearchType = SearchMode;
                reqData.PermissionCode = Common.GetValue("GetDetailsPermissionCode");
                reqData.ApplicationID = APPID;
                reqData.DocNo = DocNo;
                reqData.PassportNo = PassportNo;
                reqData.PassportCOI = COI;

                ResponseDataTypeGetDetails responseData = enrol.GetDetails(reqData);
                #endregion 

                #region get result

                string statusCode = responseData.StatusCode;
                string statusMsg = responseData.StatusMessage;
                #endregion

                #region display result
                if (statusCode == "0")
                {

                    if (responseData.StageCode.Substring(0, 6) == "EM6000")
                    {

                        FORMNO.Value = responseData.ApplicationID;
                        tbDataGrid.Visible = false;
                        Response.Redirect("ObsoleteDetails.aspx?sm=" + Request.QueryString["sm"] + "&arrow=" + Request.QueryString["arrow"] + "&PC=" + txtCompName.Value.Trim() + "&done=" + responseData.ApplicationID);

                    }
                    else
                    {
                        lblMsgSearch.Text = "Record is not available to obsolete";
                        lblMsgSearch.Visible = true;

                    }

                }

                else
                {
                    lblSearchError.Text = statusMsg;
                    lblSearchError.Visible = true;
                    btnSearch.Visible = true;


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

        protected void dgByName_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            #region select record
            if (e.CommandName == "Select")
            {
                // get the FORMNO of the clicked row
                string FORMNO = e.CommandArgument.ToString();
                // Update the record            
                SEARCH("1", string.Empty, string.Empty, string.Empty, FORMNO);

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
            string query = "StageCode Like 'EM6000%'";
            dv.RowFilter = query;
            return dv;
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


        private void SearchVisibility(string type)
        {
            #region ***
            DDPASSPORTPOI.SelectedValue = string.Empty;
            Label3.Visible = true;
            switch (type)
            {
                case "2":
                    lblName.Text = "Passport No";
                    SetRowVisibility(false, false, false, false, true, false, true);
                    RFVAppID.ErrorMessage = "Please enter Passport No before pressing the <SEARCH> button";
                    RFVAppID.Enabled = true;
                    SEARCHVALUE.Text = string.Empty;
                    break;
                case "3":
                    lblName.Text = "Document No";
                    SetRowVisibility(false, false, false, false, true, false, false);
                    RFVAppID.ErrorMessage = "Please enter Document No before pressing the <SEARCH> button";
                    RFVAppID.Enabled = true;
                    SEARCHVALUE.Text = string.Empty;
                    break;
                case "4":
                    lblName.Text = "Surname";
                    SetRowVisibility(true, true, true, false, true, false, false);
                    RFVAppID.Enabled = false;
                    Label3.Visible = false;
                    SEARCHVALUE.Text = string.Empty;
                    break;
                default:
                    lblName.Text = "Search by";
                    SetRowVisibility(false, false, false, false, false, true, false);

                    break;
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

                reqData.ActionDescription = "Get Country";
                reqData.SessionKey = Common.GetCookie(this.Page, "sessionKey");
                reqData.EnrolLocationName = txtCompName.Value.Trim();
                reqData.PermissionCode = Common.GETCOUNTRY;
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
                        DDPASSPORTPOI.Items.Add(li);
                    }
                    DDPASSPORTPOI.Items.Insert(0, new ListItem("-SELECT-", ""));

                    #endregion
                }
                else
                {
                    lblSearchError.Text = statusMsg;
                    lblSearchError.Visible = true;
                    Common.WriteLog(Common.GetValue("logPath"), statusMsg);
                }
                #endregion
            }
            catch (Exception ex)
            {
                Common.WriteLog(Common.GetValue("logPath"), "Get Country - " + ex.Message);
            }
            #endregion
        }


    }
}
