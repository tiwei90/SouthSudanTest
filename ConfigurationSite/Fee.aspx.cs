using ConfigurationSite.DALMSWS;
using ConfigurationSite.Shared;
using System;
using System.Data;
using System.Web.UI.WebControls;

public partial class Fee : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["UserSession"].Values["sessionKey"] == null) Response.Redirect(common.ErPage);

        lblMsg.Text = "";

        if (!Page.IsPostBack)
        {
            MV.SetActiveView(vSelect);
            BindGrid();
            BindEntryType();
        }
    }

    private void BindGrid()
    {
        #region ***
        try
        {
            #region Call the webservices
            DALMService result = new DALMService();
            RequestDataTypeSelectFees bindData = new RequestDataTypeSelectFees();
            bindData.ActionDescription = "Fee  - Select";
            bindData.SessionKey = Request.Cookies["UserSession"].Values["sessionKey"].ToString();
            bindData.PermissionCode = common.GetValue("SelectFee");
            #endregion

            #region response
            ResponseDataTypeSelectFees getdata = result.SelectFeesList(bindData);
            string StatusCode = getdata.StatusCode;
            string StatusMsg = getdata.StatusMessage;
            #endregion

            #region process
            if (StatusCode == "0")
            {
                ViewState["Fee"] = getdata.ResultList;
                DataSet Ds = (DataSet)ViewState["Fee"];
                gvFee.DataSource = Ds.Tables[0];
                gvFee.DataBind();
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

    private void BindEntryType()
    {
        #region ***
        try
        {
            #region Call the webservices
            DALMService result = new DALMService();
            RequestDataTypeSelectEntryType bindData = new RequestDataTypeSelectEntryType();
            bindData.ActionDescription = "Entry Type  - Select";
            bindData.SessionKey = Request.Cookies["UserSession"].Values["sessionKey"].ToString();
            bindData.PermissionCode = common.GetValue("SelectEntryType");
            #endregion

            #region response
            ResponseDataTypeSelectEntryType getdata = result.SelectLookupEntryTypeList(bindData);
            string StatusCode = getdata.StatusCode;
            string StatusMsg = getdata.StatusMessage;
            #endregion

            #region process
            if (StatusCode == "0")
            {
                DataSet Ds = (DataSet)getdata.ResultList;
                ddlEntryType.DataSource = Ds.Tables[0];
                ddlEntryType.DataBind();
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

    protected void PageIndexChanging_Click(object sender, GridViewPageEventArgs e)
    {
        #region ***
        gvFee.PageIndex = e.NewPageIndex;
        gvFee.DataSource = (DataSet)ViewState["Fee"];
        gvFee.DataBind();
        lblErrMsg.Visible = false;
        #endregion
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        #region ***
        try
        {
            GridViewRow row = ((LinkButton)sender).Parent.Parent as GridViewRow;
            gvFee.SelectedIndex = row.RowIndex;

            #region Call the webservices
            DALMService host = new DALMService();
            RequestDataTypeIUDLookupFees bindData = new RequestDataTypeIUDLookupFees();
            bindData.ActionDescription = "Fee - Delete";
            bindData.SessionKey = Request.Cookies["UserSession"].Values["sessionKey"].ToString();
            bindData.PermissionCode = common.GetValue("DeleteFee");
            bindData.ID = Convert.ToInt32(gvFee.SelectedRow.Cells[0].Text);
            bindData.EnrolLocationName = Request.Cookies["UserSession"].Values["PCName"].ToString();
            #endregion

            #region response
            ResponseDataTypeIUD result = host.DeleteFees(bindData);
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
                throw new Exception((StatusMsg == string.Empty) ? common.FAILED : StatusMsg);
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
        ddlEntryType.Focus();
        #endregion
    }

    private void clearAll()
    {
        #region ***
        ddlEntryType.SelectedIndex = -1;
        txtFee.Text = string.Empty;
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
            RequestDataTypeIUDLookupFees bindData = new RequestDataTypeIUDLookupFees();
            bindData.ActionDescription = "Fee - Insert";
            bindData.SessionKey = Request.Cookies["UserSession"].Values["sessionKey"].ToString();
            bindData.PermissionCode = common.GetValue("InsertFee");
            bindData.EntryType = ddlEntryType.SelectedValue;
            bindData.Fee = Convert.ToInt32(txtFee.Text);
            bindData.EnrolLocationName = Request.Cookies["UserSession"].Values["PCName"].ToString();
            #endregion

            #region response
            ResponseDataTypeIUD result = host.InsertFees(bindData);
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
                throw new Exception((StatusMsg == string.Empty) ? common.FAILED : StatusMsg);
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
            RequestDataTypeIUDLookupFees bindData = new RequestDataTypeIUDLookupFees();
            bindData.ActionDescription = "Fee - Update";
            bindData.SessionKey = Request.Cookies["UserSession"].Values["sessionKey"].ToString();
            bindData.PermissionCode = common.GetValue("UpdateFee");
            bindData.ID = Convert.ToInt32(lblID.Text);
            bindData.Fee = Convert.ToInt32(txtUFee.Text);
            bindData.EnrolLocationName = Request.Cookies["UserSession"].Values["PCName"].ToString();
            #endregion

            #region response
            ResponseDataTypeIUD result = host.UpdateFees(bindData);
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
                throw new Exception((StatusMsg == string.Empty) ? common.FAILED : StatusMsg);
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

    protected void gvFee_SelectedIndexChanged(object sender, EventArgs e)
    {
        #region ***
        lblUpErr.Visible = false;
        MV.SetActiveView(vUpdate);
        lblID.Text = gvFee.SelectedRow.Cells[0].Text;
        lblEntryType.Text = gvFee.SelectedRow.Cells[1].Text;
        txtUFee.Text = gvFee.SelectedRow.Cells[2].Text;
        txtUFee.Focus();
        #endregion
    }
}
