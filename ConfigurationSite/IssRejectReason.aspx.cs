using ConfigurationSite.DALMSWS;
using ConfigurationSite.Shared;
using System;
using System.Data;
using System.Web.UI.WebControls;

public partial class IssRejectReason : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["UserSession"].Values["sessionKey"] == null) Response.Redirect(common.ErPage);

        lblMsg.Text = "";

        if (!Page.IsPostBack)
        {
            MV.SetActiveView(vSelect);
            BindGrid();
        }
    }

    private void BindGrid()
    {
        #region ***
        try
        {
            #region Call the webservices
            DALMService result = new DALMService();
            RequestDataTypeSelectIssRejectReason bindData = new RequestDataTypeSelectIssRejectReason();
            bindData.ActionDescription = "Issuance Reject Reason - Select";
            bindData.SessionKey = Request.Cookies["UserSession"].Values["sessionKey"].ToString();
            bindData.PermissionCode = "11.120.7";
            #endregion

            #region response
            ResponseDataTypeSelectIssRejectReason getdata = result.SelectIssRejectReason(bindData);
            string StatusCode = getdata.StatusCode;
            string StatusMsg = getdata.StatusMessage;
            #endregion

            #region process
            if (StatusCode == "0")
            {
                ViewState["RejectReasons"] = getdata.ResultList;
                DataSet Ds = (DataSet)ViewState["RejectReasons"];
                gvRReason.DataSource = Ds.Tables[0];
                gvRReason.DataBind();
                lblErrMsg.Visible = false;
            }
            else
            {
                throw new Exception((StatusMsg == string.Empty) ? common.UNBOUND : StatusMsg);
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
        gvRReason.PageIndex = e.NewPageIndex;
        gvRReason.DataSource = (DataSet)ViewState["RejectReasons"];
        gvRReason.DataBind();
        lblErrMsg.Visible = false;
        #endregion
    }
    protected void gvRReason_SelectedIndexChanged(object sender, EventArgs e)
    {
        #region ***
        lblUpErr.Visible = false;
        MV.SetActiveView(vUpdate);
        lblRReason.Text = gvRReason.SelectedRow.Cells[1].Text;
        txtUDesc.Text = gvRReason.SelectedRow.Cells[2].Text;
        txtUDesc.Focus();
        #endregion
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        #region ***
        try
        {
            GridViewRow row = ((LinkButton)sender).Parent.Parent as GridViewRow;
            gvRReason.SelectedIndex = row.RowIndex;

            #region Call the webservices
            DALMService host = new DALMService();
            RequestDataTypeIUDIssRejectReason bindData = new RequestDataTypeIUDIssRejectReason();
            bindData.ActionDescription = "Issuance Reject Reason - Delete";
            bindData.SessionKey = Request.Cookies["UserSession"].Values["sessionKey"].ToString();
            bindData.PermissionCode = "11.120.4";
            bindData.RejectCode = gvRReason.SelectedRow.Cells[1].Text;
            bindData.Desc = string.Empty;
            bindData.EnrolLocationName = Request.Cookies["UserSession"].Values["PCName"].ToString();
            #endregion

            #region response
            ResponseDataTypeIUD result = host.DeleteIssRejectReason(bindData);
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
        txtRReason.Focus();
        #endregion
    }

    private void clearAll()
    {
        #region ***        
        txtRReason.Text = string.Empty;
        txtDesc.Text = string.Empty;
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
            RequestDataTypeIUDIssRejectReason bindData = new RequestDataTypeIUDIssRejectReason();
            bindData.ActionDescription = "Issuance Reject Reason - Insert";
            bindData.SessionKey = Request.Cookies["UserSession"].Values["sessionKey"].ToString();
            bindData.PermissionCode = "11.120.1";
            bindData.RejectCode = txtRReason.Text;
            bindData.Desc = txtDesc.Text;
            bindData.EnrolLocationName = Request.Cookies["UserSession"].Values["PCName"].ToString();
            #endregion

            #region response
            ResponseDataTypeIUD result = host.InsertIssRejectReason(bindData);
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
            RequestDataTypeIUDIssRejectReason bindData = new RequestDataTypeIUDIssRejectReason();
            bindData.ActionDescription = "IssuanceReject Reason - Update";
            bindData.SessionKey = Request.Cookies["UserSession"].Values["sessionKey"].ToString();
            bindData.PermissionCode = "11.120.3";
            bindData.RejectCode = lblRReason.Text;
            bindData.Desc = txtUDesc.Text;
            bindData.EnrolLocationName = Request.Cookies["UserSession"].Values["PCName"].ToString();
            #endregion

            #region response
            ResponseDataTypeIUD result = host.UpdateIssRejectReason(bindData);
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
}
