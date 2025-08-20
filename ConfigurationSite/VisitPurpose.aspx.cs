using ConfigurationSite.DALMSWS;
using ConfigurationSite.Shared;
using System;
using System.Data;
using System.Web.UI.WebControls;

public partial class VisitPurpose : System.Web.UI.Page
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
            RequestDataTypeSelectVisitPurpose bindData = new RequestDataTypeSelectVisitPurpose();
            bindData.ActionDescription = "Visit Purpose  - Select";
            bindData.SessionKey = Request.Cookies["UserSession"].Values["sessionKey"].ToString();
            bindData.PermissionCode = common.GetValue("SelectVisitPurpose");
            #endregion

            #region response
            ResponseDataTypeSelectVisitPurpose getdata = result.SelectLookupVisitPurposeList(bindData);
            string StatusCode = getdata.StatusCode;
            string StatusMsg = getdata.StatusMessage;
            #endregion

            #region process
            if (StatusCode == "0")
            {
                ViewState["VisitPurposeList"] = getdata.ResultList;
                DataSet Ds = (DataSet)ViewState["VisitPurposeList"];
                gvVisitPurpose.DataSource = Ds.Tables[0];
                gvVisitPurpose.DataBind();
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
        gvVisitPurpose.PageIndex = e.NewPageIndex;
        gvVisitPurpose.DataSource = (DataSet)ViewState["VisitPurposeList"];
        gvVisitPurpose.DataBind();
        lblErrMsg.Visible = false;
        #endregion
    }
    protected void gvVisitPurpose_SelectedIndexChanged(object sender, EventArgs e)
    {
        #region ***
        lblUpErr.Visible = false;
        MV.SetActiveView(vUpdate);
        lblVisitPurpose.Text = gvVisitPurpose.SelectedRow.Cells[0].Text;
        txtUDesc.Text = gvVisitPurpose.SelectedRow.Cells[1].Text;
        txtUDesc.Focus();
        #endregion
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        #region ***
        try
        {
            GridViewRow row = ((LinkButton)sender).Parent.Parent as GridViewRow;
            gvVisitPurpose.SelectedIndex = row.RowIndex;

            #region Call the webservices
            DALMService host = new DALMService();
            RequestDataTypeIUDVisitPurpose bindData = new RequestDataTypeIUDVisitPurpose();
            bindData.ActionDescription = "Visit Purpose - Delete";
            bindData.SessionKey = Request.Cookies["UserSession"].Values["sessionKey"].ToString();
            bindData.PermissionCode = common.GetValue("DeleteVisitPurpose");
            bindData.VisitPurpose = gvVisitPurpose.SelectedRow.Cells[0].Text;
            bindData.Desc = string.Empty;
            bindData.EnrolLocationName = Request.Cookies["UserSession"].Values["PCName"].ToString();
            #endregion

            #region response
            ResponseDataTypeIUD result = host.DeleteVisitPurpose(bindData);
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
        txtVisitPurpose.Focus();
        #endregion
    }

    private void clearAll()
    {
        #region ***
        txtVisitPurpose.Text = string.Empty;
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
            RequestDataTypeIUDVisitPurpose bindData = new RequestDataTypeIUDVisitPurpose();
            bindData.ActionDescription = "Visit Purpose - Insert";
            bindData.SessionKey = Request.Cookies["UserSession"].Values["sessionKey"].ToString();
            bindData.PermissionCode = common.GetValue("InsertVisitPurpose");
            bindData.VisitPurpose = txtVisitPurpose.Text;
            bindData.Desc = txtDesc.Text;
            bindData.EnrolLocationName = Request.Cookies["UserSession"].Values["PCName"].ToString();
            #endregion

            #region response
            ResponseDataTypeIUD result = host.InsertVisitPurpose(bindData);
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
            RequestDataTypeIUDVisitPurpose bindData = new RequestDataTypeIUDVisitPurpose();
            bindData.ActionDescription = "Visit Purpose - Update";
            bindData.SessionKey = Request.Cookies["UserSession"].Values["sessionKey"].ToString();
            bindData.PermissionCode = common.GetValue("UpdateVisitPurpose");
            bindData.VisitPurpose = lblVisitPurpose.Text;
            bindData.Desc = txtUDesc.Text;
            bindData.EnrolLocationName = Request.Cookies["UserSession"].Values["PCName"].ToString();
            #endregion

            #region response
            ResponseDataTypeIUD result = host.UpdateVisitPurpose(bindData);
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
