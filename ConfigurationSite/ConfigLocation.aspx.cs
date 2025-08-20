using ConfigurationSite.DALMSWS;
using ConfigurationSite.Shared;
using System;
using System.Data;
using System.Web.UI.WebControls;

public partial class ConfigLocation : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["UserSession"].Values["sessionKey"] == null) Response.Redirect(common.ErPage);

        lblMsg.Text = "";

        if (!Page.IsPostBack)
        {
            MV.SetActiveView(vSelect);
            BindGrid();
            BindLocation();
        }
    }
    private void BindGrid()
    {
        #region ***
        try
        {
            #region Call the webservices
            DALMService result = new DALMService();
            RequestDataTypeSelectConfigLocation bindData = new RequestDataTypeSelectConfigLocation();
            bindData.ActionDescription = "ConfigLocation - Select";
            bindData.SessionKey = Request.Cookies["UserSession"].Values["sessionKey"].ToString();
            bindData.PermissionCode = common.GetValue("SelectConfigLocation");
            bindData.LocationName = Request.Cookies["UserSession"].Values["PCName"].ToString();
            #endregion

            #region response
            ResponseDataTypeSelectAll getdata = result.SelectAllConfigLocation(bindData);
            string StatusCode = getdata.StatusCode;
            string StatusMsg = getdata.StatusMessage;
            #endregion

            #region process
            if (StatusCode == "0")
            {
                ViewState["ConfigLocation"] = getdata.ResultList;
                DataSet Ds = (DataSet)ViewState["ConfigLocation"];
                gvConfigLocation.DataSource = Ds.Tables[0];
                gvConfigLocation.DataBind();
                lblErrMsg.Visible = false;
            }
            else
            {
                throw new Exception(StatusMsg);
            }
            #endregion
        }
        catch (Exception ex)
        {
            lblErrMsg.Visible = true;
            lblErrMsg.Text = ex.Message;

        }
        #endregion
    }

    private void BindLocation()
    {
        try
        {
            #region Call the webservices
            DALMService result = new DALMService();
            RequestDataTypeSelectLocation bindData = new RequestDataTypeSelectLocation();
            bindData.ActionDescription = "Location  - Select";
            bindData.SessionKey = Request.Cookies["UserSession"].Values["sessionKey"].ToString();
            bindData.PermissionCode = common.GetValue("SelectLocation");
            #endregion

            #region response
            ResponseDataTypeSelectLocation getdata = result.SelectLocationList(bindData);
            string StatusCode = getdata.StatusCode;
            string StatusMsg = getdata.StatusMessage;
            #endregion

            #region process
            if (StatusCode == "0")
            {
                ddlLocationName.DataSource = getdata.ResultList.Tables[0];
                ddlLocationName.DataBind();
                lblErrMsg.Visible = false;

                ddlLocationName.Items.Insert(0, new ListItem("-SELECT-", ""));
            }
            else
            {
                throw new Exception(StatusMsg);
            }
            #endregion
        }
        catch (Exception ex)
        {
            lblErrMsg.Visible = true;
            lblErrMsg.Text = ex.Message;
        }
    }

    protected void PageIndexChanging_Click(object sender, GridViewPageEventArgs e)
    {
        #region ***
        gvConfigLocation.PageIndex = e.NewPageIndex;
        gvConfigLocation.DataSource = (DataSet)ViewState["ConfigLocation"];
        gvConfigLocation.DataBind();
        lblErrMsg.Visible = false;
        #endregion
    }
    protected void gvConfigLocation_SelectedIndexChanged(object sender, EventArgs e)
    {
        #region ***
        lblUpErr.Visible = false;
        MV.SetActiveView(vUpdate);

        lblLocationID.Text = gvConfigLocation.SelectedRow.Cells[0].Text;
        lblLocationName.Text = gvConfigLocation.SelectedRow.Cells[1].Text;

        chkUEnrollment.Checked = Convert.ToBoolean(gvConfigLocation.SelectedRow.Cells[2].Text);
        chkUPayment.Checked = Convert.ToBoolean(gvConfigLocation.SelectedRow.Cells[3].Text);
        chkUApproval.Checked = Convert.ToBoolean(gvConfigLocation.SelectedRow.Cells[4].Text);
        chkUIssuance.Checked = Convert.ToBoolean(gvConfigLocation.SelectedRow.Cells[5].Text);

        chkUCounter1.Checked = Convert.ToBoolean(gvConfigLocation.SelectedRow.Cells[6].Text);
        chkUCounter2.Checked = Convert.ToBoolean(gvConfigLocation.SelectedRow.Cells[7].Text);
        chkUCounter3.Checked = Convert.ToBoolean(gvConfigLocation.SelectedRow.Cells[8].Text);
        chkUCounter4.Checked = Convert.ToBoolean(gvConfigLocation.SelectedRow.Cells[9].Text);
        chkUCounter5.Checked = Convert.ToBoolean(gvConfigLocation.SelectedRow.Cells[10].Text);

        chkUEnrollment.Focus();
        #endregion
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        #region ***
        try
        {
            GridViewRow row = ((LinkButton)sender).Parent.Parent as GridViewRow;
            gvConfigLocation.SelectedIndex = row.RowIndex;

            #region Call the webservices
            DALMService config = new DALMService();
            RequestDataTypeIUDConfigLocation bindData = new RequestDataTypeIUDConfigLocation();
            bindData.ActionDescription = "ConfigLocation - Delete";
            bindData.SessionKey = Request.Cookies["UserSession"].Values["sessionKey"].ToString();
            bindData.PermissionCode = common.GetValue("DeleteConfigLocation");
            bindData.LocationID = gvConfigLocation.SelectedRow.Cells[0].Text;

            bindData.EnrolLocationName = Request.Cookies["UserSession"].Values["PCName"].ToString();
            #endregion

            #region response
            ResponseDataTypeIUD result = config.DeleteConfigLocation(bindData);
            string StatusCode = result.StatusCode;
            string StatusMsg = result.StatusMessage;
            #endregion

            #region process
            if (StatusCode == "0")
            {
                lblErrMsg.Visible = false;
                MV.SetActiveView(vSelect);
                BindGrid();
                lblMsg.Text = common.DELETESUCC;
            }
            else
            {
                throw new Exception(StatusMsg);
            }
            #endregion
        }
        catch (Exception ex)
        {
            lblErrMsg.Visible = true;
            lblErrMsg.Text = ex.Message;

        }
        #endregion
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        #region ***
        clearAll();
        MV.SetActiveView(vInsert);
        //ddlCountry.Focus();
        #endregion
    }

    private void clearAll()
    {
        #region ***
        ddlLocationName.SelectedIndex = -1;

        chkEnrollment.Checked = false;
        chkPayment.Checked = false;
        chkApproval.Checked = false;
        chkIssuance.Checked = false;
        chkCounter1.Checked = false;
        chkCounter2.Checked = false;
        chkCounter3.Checked = false;
        chkCounter4.Checked = false;
        chkCounter5.Checked = false;

        lblInErr.Visible = false;
        #endregion
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        #region ***
        try
        {
            #region Call the webservices
            DALMService config = new DALMService();
            RequestDataTypeIUDConfigLocation bindData = new RequestDataTypeIUDConfigLocation();
            bindData.ActionDescription = "Branch - Insert";
            bindData.SessionKey = Request.Cookies["UserSession"].Values["sessionKey"].ToString();
            bindData.PermissionCode = common.GetValue("InsertConfigLocation");
            bindData.LocationID = ddlLocationName.SelectedValue;
            bindData.IsEnrollment = Convert.ToInt16(chkEnrollment.Checked);
            bindData.IsPayment = Convert.ToInt16(chkPayment.Checked);
            bindData.IsApproval = Convert.ToInt16(chkApproval.Checked);
            bindData.IsIssuance = Convert.ToInt16(chkIssuance.Checked);

            bindData.OtherCounter1 = Convert.ToInt16(chkCounter1.Checked);
            bindData.OtherCounter2 = Convert.ToInt16(chkCounter2.Checked);
            bindData.OtherCounter3 = Convert.ToInt16(chkCounter3.Checked);
            bindData.OtherCounter4 = Convert.ToInt16(chkCounter4.Checked);
            bindData.OtherCounter5 = Convert.ToInt16(chkCounter5.Checked);

            bindData.EnrolLocationName = Request.Cookies["UserSession"].Values["PCName"].ToString();
            #endregion

            #region response
            ResponseDataTypeIUD result = config.InsertConfigLocation(bindData);
            string StatusCode = result.StatusCode;
            string StatusMsg = result.StatusMessage;
            #endregion

            #region process
            if (StatusCode == "0")
            {
                lblInErr.Visible = false;
                MV.SetActiveView(vSelect);
                BindGrid();
                lblMsg.Text = common.INSERTSUCC;
            }
            else
            {
                throw new Exception(StatusMsg);
            }
            #endregion
        }
        catch (Exception ex)
        {
            lblInErr.Visible = true;
            lblInErr.Text = ex.Message;

        }
        #endregion
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        #region ***
        clearAll();
        MV.SetActiveView(vSelect);
        BindGrid();
        #endregion
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        #region ***
        try
        {
            #region Call the webservices
            DALMService config = new DALMService();
            RequestDataTypeIUDConfigLocation bindData = new RequestDataTypeIUDConfigLocation();
            bindData.ActionDescription = "ConfigLocation - Update";
            bindData.SessionKey = Request.Cookies["UserSession"].Values["sessionKey"].ToString();
            bindData.PermissionCode = common.GetValue("UpdateConfigLocation");
            bindData.LocationID = lblLocationID.Text;
            bindData.IsEnrollment = Convert.ToInt16(chkUEnrollment.Checked);
            bindData.IsPayment = Convert.ToInt16(chkUPayment.Checked);
            bindData.IsApproval = Convert.ToInt16(chkUApproval.Checked);
            bindData.IsIssuance = Convert.ToInt16(chkUIssuance.Checked);

            bindData.OtherCounter1 = Convert.ToInt16(chkUCounter1.Checked);
            bindData.OtherCounter2 = Convert.ToInt16(chkUCounter2.Checked);
            bindData.OtherCounter3 = Convert.ToInt16(chkUCounter3.Checked);
            bindData.OtherCounter4 = Convert.ToInt16(chkUCounter4.Checked);
            bindData.OtherCounter5 = Convert.ToInt16(chkUCounter5.Checked);

            bindData.EnrolLocationName = Request.Cookies["UserSession"].Values["PCName"].ToString();
            #endregion

            #region response
            ResponseDataTypeIUD result = config.UpdateConfigLocation(bindData);
            string StatusCode = result.StatusCode;
            string StatusMsg = result.StatusMessage;
            #endregion

            #region process
            if (StatusCode == "0")
            {
                lblUpErr.Visible = false;
                MV.SetActiveView(vSelect);
                BindGrid();
                lblMsg.Text = common.UPDATESUCC;
            }
            else
            {
                throw new Exception(StatusMsg);
            }
            #endregion
        }
        catch (Exception ex)
        {
            lblUpErr.Visible = true;
            lblUpErr.Text = ex.Message;

        }
        #endregion
    }

}
