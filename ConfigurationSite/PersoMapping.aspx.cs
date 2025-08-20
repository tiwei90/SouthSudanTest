using ConfigurationSite.DALMSWS;
using ConfigurationSite.Shared;
using System;
using System.Data;
using System.Web.UI.WebControls;

public partial class PersoMapping : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["UserSession"].Values["sessionKey"] == null) Response.Redirect(common.ErPage);

        lblMsg.Text = "";

        if (!Page.IsPostBack)
        {
            MV.SetActiveView(vSelect);
            BindGrid();
            BindBranch();
        }
    }

    private void BindGrid()
    {
        #region ***
        try
        {
            #region Call the webservices
            DALMService result = new DALMService();
            RequestDataTypeSelectAll bindData = new RequestDataTypeSelectAll();
            bindData.ActionDescription = "Perso Mapping - Select";
            bindData.SessionKey = Request.Cookies["UserSession"].Values["sessionKey"].ToString();
            bindData.PermissionCode = common.GetValue("SelectPersoMapping"); ;
            #endregion

            #region response
            ResponseDataTypeSelectAll getdata = result.SelectPersoMappingList(bindData);
            string StatusCode = getdata.StatusCode;
            string StatusMsg = getdata.StatusMessage;
            #endregion

            #region process
            if (StatusCode == "0")
            {
                ViewState["PersoMapping"] = getdata.ResultList;
                DataSet Ds = (DataSet)ViewState["PersoMapping"];
                gvPersoBranch.DataSource = Ds.Tables[0];
                gvPersoBranch.DataBind();
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

    private void BindBranch()
    {
        try
        {
            #region Call the webservices
            DALMService result = new DALMService();
            RequestDataTypeSelectBranch bindData = new RequestDataTypeSelectBranch();
            bindData.ActionDescription = "Branch - Select";
            bindData.SessionKey = Request.Cookies["UserSession"].Values["sessionKey"].ToString();
            bindData.PermissionCode = common.GetValue("SelectBranch"); ;
            #endregion

            #region response
            ResponseDataTypeSelectBranch getdata = result.SelectBranchList(bindData);
            string StatusCode = getdata.StatusCode;
            string StatusMsg = getdata.StatusMessage;
            #endregion

            #region process
            if (StatusCode == "0")
            {
                ddlEnrolBranch.DataSource = getdata.ResultList.Tables[0];
                ddlEnrolBranch.DataBind();
                ddlEnrolBranch.Items.Insert(0, new ListItem("-SELECT-", ""));

                ddlPersoBranch.DataSource = getdata.ResultList.Tables[0];
                ddlPersoBranch.DataBind();
                ddlPersoBranch.Items.Insert(0, new ListItem("-SELECT-", ""));

                ddlUPersoBranch.DataSource = getdata.ResultList.Tables[0];
                ddlUPersoBranch.DataBind();
                ddlUPersoBranch.Items.Insert(0, new ListItem("-SELECT-", ""));

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
    }

    protected void PageIndexChanging_Click(object sender, GridViewPageEventArgs e)
    {
        #region ***
        gvPersoBranch.PageIndex = e.NewPageIndex;
        gvPersoBranch.DataSource = (DataSet)ViewState["Branch"];
        gvPersoBranch.DataBind();
        lblErrMsg.Visible = false;
        #endregion
    }
    protected void gvPersoBranch_SelectedIndexChanged(object sender, EventArgs e)
    {
        #region ***
        lblUpErr.Visible = false;
        MV.SetActiveView(vUpdate);

        lblID.Text = gvPersoBranch.SelectedRow.Cells[0].Text;
        lblEnrolBranch.Text = gvPersoBranch.SelectedRow.Cells[1].Text;
        ddlUPersoBranch.SelectedValue = gvPersoBranch.SelectedRow.Cells[2].Text.Substring(0, gvPersoBranch.SelectedRow.Cells[2].Text.IndexOf('-')).Trim();

        ddlUPersoBranch.Focus();
        #endregion
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        #region ***
        clearAll();
        MV.SetActiveView(vInsert);
        ddlEnrolBranch.Focus();
        #endregion
    }

    private void clearAll()
    {
        #region ***
        ddlEnrolBranch.SelectedIndex = -1;
        ddlPersoBranch.SelectedIndex = -1;
        lblInErr.Visible = false;
        #endregion
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        #region ***
        try
        {
            #region Call the webservices
            DALMService host = new DALMService();
            RequestDataTypeIUDPersoMapping bindData = new RequestDataTypeIUDPersoMapping();
            bindData.ActionDescription = "Perso Mapping - Insert";
            bindData.SessionKey = Request.Cookies["UserSession"].Values["sessionKey"].ToString();
            bindData.PermissionCode = common.GetValue("InsertPersoMapping");
            bindData.EnrollBranch = ddlEnrolBranch.SelectedValue;
            bindData.PersoBranch = ddlPersoBranch.SelectedValue;
            bindData.EnrolLocationName = Request.Cookies["UserSession"].Values["PCName"].ToString();
            #endregion

            #region response
            ResponseDataTypeIUD result = host.InsertPersoMapping(bindData);
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
            DALMService host = new DALMService();
            RequestDataTypeIUDPersoMapping bindData = new RequestDataTypeIUDPersoMapping();
            bindData.ActionDescription = "Perso Mapping - Update";
            bindData.SessionKey = Request.Cookies["UserSession"].Values["sessionKey"].ToString();
            bindData.PermissionCode = common.GetValue("UpdateBranch");
            bindData.ID = Convert.ToInt32(lblID.Text);
            bindData.PersoBranch = ddlUPersoBranch.SelectedValue;
            bindData.EnrolLocationName = Request.Cookies["UserSession"].Values["PCName"].ToString();
            #endregion

            #region response
            ResponseDataTypeIUD result = host.UpdatePersoMapping(bindData);
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
