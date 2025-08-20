using EnrollmentIssuanceSite.EnrollManagementWS;
using EnrollmentIssuanceSite.Shared;
using System;
using System.Data;
using System.Web.UI.WebControls;

namespace EnrollmentIssuanceSite
{
    public partial class QueryReprint : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.BIRTHDATE.Text = Request[this.BIRTHDATE.UniqueID];
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["PC"] != null)
                {
                    txtCompName.Value = Request.QueryString["PC"];
                    getCountryList();
                }
            }
        }
        protected void SEARCHBY_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region ***
            DDPASSPORTPOI.SelectedValue = string.Empty;
            Label31.Visible = true;
            switch (SEARCHBY.SelectedValue)
            {
                case "1":
                    lblName.Text = "Application ID";
                    SetRowVisibility(false, false, false, false, false, true, false, false);
                    RFVAppID.ErrorMessage = "Please enter Application ID before pressing the <SEARCH> button";
                    RFVAppID.Enabled = true;
                    SEARCHVALUE.Text = string.Empty;
                    break;
                case "2":
                    lblName.Text = "Passport No";
                    SetRowVisibility(false, false, false, false, false, true, false, true);
                    RFVAppID.ErrorMessage = "Please enter Passport No before pressing the <SEARCH> button";
                    RFVAppID.Enabled = true;
                    SEARCHVALUE.Text = string.Empty;
                    break;

                case "3":
                    lblName.Text = "Document No";
                    SetRowVisibility(false, false, false, false, false, true, false, false);
                    RFVAppID.ErrorMessage = "Please enter Document No before pressing the <SEARCH> button";
                    RFVAppID.Enabled = true;
                    SEARCHVALUE.Text = string.Empty;
                    break;
                case "4":
                    lblName.Text = "Surname";
                    SetRowVisibility(true, false, true, true, false, true, false, false);
                    RFVAppID.Enabled = false;
                    Label31.Visible = false;
                    SEARCHVALUE.Text = string.Empty;
                    break;
                default:
                    lblName.Text = "Search value";
                    SetRowVisibility(false, false, false, false, false, false, true, false);
                    SEARCHVALUE.Text = string.Empty;


                    break;
            }
            #endregion

        }
        private void SetRowVisibility(bool DOB, bool Info, bool First, bool Middle, bool DGrid, bool SearchVal, bool Clear, bool countryofbirth)
        {
            #region ***
            trDOB.Visible = DOB;
            tbInfo.Visible = Info;
            trFirstname.Visible = First;
            trMiddlename.Visible = Middle;
            tbDataGrid.Visible = DGrid;
            trSearchValue.Visible = SearchVal;
            trBirthCountry.Visible = countryofbirth;
            btnClear.Disabled = Clear;
            ClearControl();
            #endregion
        }
        private void ClearControl()
        {
            #region ***
            imgPhoto.ImageUrl = Common.ImgDefaultUrl;

            #endregion
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {

            #region search
            ClearControl();

            string searchVal = SplitName(SEARCHVALUE.Text.ToUpper().Trim());
            string firstname = SplitName(SEARCHFIRST.Text.ToUpper().Trim());
            string middlename = SplitName(SEARCHMIDDLE.Text.ToUpper().Trim());
            string country = DDPASSPORTPOI.SelectedValue;
            string DOB = BIRTHDATE.Text.Replace("/", "");

            if (SEARCHBY.SelectedValue == "4") // NAME
            {
                SEARCHBYNAME(SEARCHBY.SelectedValue, searchVal, firstname, middlename, DOB);
            }
            else if (SEARCHBY.SelectedValue == "1") // APPLICATION ID
            {
                SEARCH(SEARCHBY.SelectedValue, string.Empty, searchVal, string.Empty, string.Empty);
            }
            else if (SEARCHBY.SelectedValue == "2") // PASSPORTNO
            {
                SEARCH(SEARCHBY.SelectedValue, string.Empty, string.Empty, searchVal, country);
            }
            else if (SEARCHBY.SelectedValue == "3") // DOC NO
            {
                SEARCH(SEARCHBY.SelectedValue, searchVal, string.Empty, string.Empty, string.Empty);
            }

            #endregion
        }
        private void SEARCHBYNAME(string SearchMode, string SurName, string First, string Middle, string Birthdate)
        {
            tbInfo.Visible = false;
            #region request Applicant Record By Name
            try
            {
                #region calling web service
                EMService enrol = new EMService();
                RequestDataTypeQueryByName reqData = new RequestDataTypeQueryByName();

                reqData.ActionDescription = "Get Details By Name";
                reqData.SessionKey = Common.GetCookie(this.Page, "sessionKey");
                reqData.LocationName = txtCompName.Value.Trim();
                reqData.PermissionCode = Common.GetValue("QueryByNameCode");
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
                    lblMsgSearch.Text = statusMsg;
                    lblMsgSearch.Visible = true;
                    btnSearch.Visible = true;
                    tbDataGrid.Visible = false;
                    Common.WriteLog(@Server.MapPath("") + Common.GetValue("logPath"), statusMsg);
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
                        ViewState["data"] = responseData.ResultList;
                        FilterDG();

                    }
                }
                #endregion
            }
            catch (Exception ex)
            {
                lblSearchError.Text = "Unable to perfom Query by Name";
                lblSearchError.Visible = true;
                Common.WriteLog(@Server.MapPath("") + Common.GetValue("logPath"), "Query by Name - " + ex.Message);
            }
            #endregion
        }
        private void FilterDG()
        {
            #region ***
            DataSet ds = (DataSet)ViewState["data"];
            DataView dv = new DataView(ds.Tables[0]);
            dv.RowFilter = "(StageCode Not Like 'EM6000%') AND (StageCode Not Like 'EM6001%') AND (StageCode Not Like 'EM7000%')";

            if (dv.Count > 0)
            {
                lblMsgSearch.Visible = false;
                tbDataGrid.Visible = true;
                dgByName.DataSource = dv;
                dgByName.PageIndex = 0;
                dgByName.DataBind();
            }
            else
            {
                lblMsgSearch.Text = "Record is not available!";
                lblMsgSearch.Visible = true;
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
        protected void dgByName_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            #region Paging
            dgByName.PageIndex = e.NewPageIndex;
            dgByName.DataSource = BindGrid();
            dgByName.DataBind();
            tbInfo.Visible = false;
            #endregion

        }
        private DataView BindGrid()
        {
            #region ***
            DataSet Ds = (DataSet)ViewState["data"];
            DataView dv = new DataView(Ds.Tables[0]);
            dv.RowFilter = "(StageCode Not Like 'EM6000%') AND (StageCode Not Like 'EM6001%') AND (StageCode Not Like 'EM7000%')";
            return dv;
            #endregion

        }

        protected void dgByName_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            #region select record
            if (e.CommandName == "Select")
            {
                // get the FORMNO of the clicked row
                string FORMNO = e.CommandArgument.ToString();
                Response.Redirect("AcceptanceSlip.aspx?sm=" + Request.QueryString["sm"] + "&done=" + FORMNO + "&arrow=" + Request.QueryString["arrow"] + "&PC=" + txtCompName.Value);

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
                    Common.WriteLog(@Server.MapPath("") + Common.GetValue("logPath"), statusMsg);
                }
                #endregion
            }
            catch (Exception ex)
            {
                Common.WriteLog(@Server.MapPath("") + Common.GetValue("logPath"), "Get Country - " + ex.Message);
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
        private void SEARCH(string SearchMode, string DocNo, string AppID, string PassportNo, string PassportCOI)
        {
            #region request Applicant Record by Doc No, AppID, PassportNo, PassportCOI
            try
            {
                EMService enrol = new EMService();
                RequestDataTypeGetDetails reqData = new RequestDataTypeGetDetails();

                reqData.ActionDescription = "Get Details";
                reqData.SessionKey = Common.GetCookie(this.Page, "sessionKey");
                reqData.EnrolLocationName = txtCompName.Value.Trim();
                reqData.SearchType = SearchMode;
                reqData.PermissionCode = Common.GetValue("GetDetailsPermissionCode");
                reqData.ApplicationID = AppID;
                reqData.DocNo = DocNo;
                reqData.PassportNo = PassportNo;
                reqData.PassportCOI = PassportCOI;

                ResponseDataTypeGetDetails responseData = enrol.GetDetails(reqData);

                string statusCode = responseData.StatusCode;
                string statusMsg = responseData.StatusMessage;


                #region display result
                if (statusCode == "0")
                {
                    string stage = responseData.StageCode.Substring(0, 6);
                    if ((stage != "EM6000") && (stage != "EM7000") && (stage != "EM6001"))
                    {
                        FORMNO.Value = responseData.ApplicationID;
                        tbDataGrid.Visible = false;
                        lblMsgSearch.Visible = false;
                        Response.Redirect("AcceptanceSlip.aspx?sm=" + Request.QueryString["sm"] + "&done=" + FORMNO.Value + "&arrow=" + Request.QueryString["arrow"] + "&PC=" + txtCompName.Value);
                    }
                    else
                    {
                        lblMsgSearch.Visible = true;
                        lblMsgSearch.Text = "Record is not available!";
                    }


                }
                else
                    throw new Exception(statusMsg);
                #endregion
            }
            catch (Exception ex)
            {
                btnSearch.Visible = true;
                tbInfo.Visible = false;
                lblSearchError.Text = ex.Message;
                lblSearchError.Visible = true;
                Common.WriteLog(@Server.MapPath("") + Common.GetValue("logPath"), "Get Details - " + ex.Message);
            }

            #endregion
        }
        private string SplitName(string name)
        {
            #region
            if (name != string.Empty)
            {
                string[] strname = name.Split(new char[] { ' ' });
                string correctedName = string.Empty;
                if (strname.Length > 1)
                {
                    for (int i = 0; i < strname.Length; i++)
                    {
                        if (strname[i].ToString() == "-" || strname[i].ToString() == "'")
                        {
                            correctedName = correctedName.Trim() + strname[i].ToString();
                        }
                        else if (strname[i].ToString() != string.Empty && (strname[i].ToString().Substring((strname[i].ToString().Length - 1), 1) == "'" || strname[i].ToString().Substring((strname[i].ToString().Length - 1), 1) == "-"))
                        {
                            correctedName += strname[i].ToString(); // +strname[i + 1].ToString() + " ";                                              
                        }
                        else if (strname[i].ToString() != string.Empty && (strname[i].ToString().Substring(0, 1) == "'" || strname[i].ToString().Substring(0, 1) == "-"))
                        {
                            correctedName = correctedName.Trim() + strname[i].ToString();
                        }
                        else if (strname[i].ToString() != "")
                            correctedName += strname[i].ToString() + " ";
                    }
                }
                else
                {
                    correctedName = name;
                }
                return correctedName.Trim(); ;
            }
            else
                return name;

            #endregion
        }
    }
}
