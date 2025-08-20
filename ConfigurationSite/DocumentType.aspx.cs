using ConfigurationSite.DALMSWS;
using ConfigurationSite.Shared;
using System;
using System.Data;
using System.Web.UI.WebControls;

public partial class DocumentType : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["UserSession"].Values["sessionKey"] == null) Response.Redirect(common.ErPage);

        lblMsg.Text = "";

        if (!Page.IsPostBack)
        {
            MV.SetActiveView(vSelect);
            GetLayoutID();
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
            RequestDataTypeSelectDocType bindData = new RequestDataTypeSelectDocType();
            bindData.ActionDescription = "Document Type - Select";
            bindData.SessionKey = Request.Cookies["UserSession"].Values["sessionKey"].ToString();
            bindData.PermissionCode = "11.99.7";
            #endregion

            #region response
            ResponseDataTypeSelectDocType getdata = result.SelectDocTypeList(bindData);
            string StatusCode = getdata.StatusCode;
            string StatusMsg = getdata.StatusMessage;
            #endregion

            #region process
            if (StatusCode == "0")
            {
                ViewState["DocTypeList"] = getdata.ResultList;
                DataSet Ds = (DataSet)ViewState["DocTypeList"];
                gvDocType.DataSource = Ds.Tables[0];
                gvDocType.DataBind();
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
        gvDocType.PageIndex = e.NewPageIndex;
        gvDocType.DataSource = (DataSet)ViewState["DocTypeList"];
        gvDocType.DataBind();
        lblErrMsg.Visible = false;
        #endregion
    }
    protected void gvDocType_SelectedIndexChanged(object sender, EventArgs e)
    {
        #region ***
        try
        {
            lblUpErr.Visible = false;
            MV.SetActiveView(vUpdate);

            lblDocType.Text = gvDocType.SelectedRow.Cells[0].Text;
            txtUDesc.Text = gvDocType.SelectedRow.Cells[1].Text;

            if (gvDocType.SelectedRow.Cells[2].Text != "&nbsp;")
            {
                txtULayoutID.SelectedIndex = txtULayoutID.Items.IndexOf(txtULayoutID.Items.FindByText(gvDocType.SelectedRow.Cells[2].Text));
            }
            else
            {
                txtULayoutID.SelectedIndex = -1;
            }
            txtUDesc.Focus();
        }
        catch (Exception ex)
        {
            lblUpErr.Text = ex.Message;
            lblUpErr.Visible = true;
        }
        #endregion
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        #region ***
        try
        {
            GridViewRow row = ((LinkButton)sender).Parent.Parent as GridViewRow;
            gvDocType.SelectedIndex = row.RowIndex;

            #region Call the webservices
            DALMService host = new DALMService();
            RequestDataTypeIUDLookupDocType bindData = new RequestDataTypeIUDLookupDocType();
            bindData.ActionDescription = "Document Type - Delete";
            bindData.SessionKey = Request.Cookies["UserSession"].Values["sessionKey"].ToString();
            bindData.PermissionCode = "11.99.4";
            bindData.DocType = gvDocType.SelectedRow.Cells[0].Text;
            bindData.Desc = string.Empty;
            bindData.EnrolLocationName = Request.Cookies["UserSession"].Values["PCName"].ToString();
            #endregion

            #region response
            ResponseDataTypeIUD result = host.DeleteDocType(bindData);
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
        #region 
        try
        {
            MV.SetActiveView(vInsert);

            clearAll();

            txtDocType.Focus();
        }
        catch (Exception ex)
        {
            lblInErr.Text = ex.Message;
            lblInErr.Visible = true;
        }
        #endregion
    }

    private void clearAll()
    {
        #region ***
        txtDocType.Text = string.Empty;
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
            RequestDataTypeIUDLookupDocType bindData = new RequestDataTypeIUDLookupDocType();
            bindData.ActionDescription = "Document Type - Insert";
            bindData.SessionKey = Request.Cookies["UserSession"].Values["sessionKey"].ToString();
            bindData.PermissionCode = "11.99.1";
            bindData.DocType = txtDocType.Text;
            bindData.Desc = txtDesc.Text;
            bindData.LayoutID = 0;// Convert.ToInt32(txtLayoutID.Text);
            bindData.EnrolLocationName = Request.Cookies["UserSession"].Values["PCName"].ToString();
            #endregion

            #region response
            ResponseDataTypeIUD result = host.InsertDocType(bindData);
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
            RequestDataTypeIUDLookupDocType bindData = new RequestDataTypeIUDLookupDocType();
            bindData.ActionDescription = "Document Type - Update";
            bindData.SessionKey = Request.Cookies["UserSession"].Values["sessionKey"].ToString();
            bindData.PermissionCode = "11.99.3";
            bindData.DocType = lblDocType.Text;
            bindData.Desc = txtUDesc.Text;
            bindData.LayoutID = 0;// Convert.ToInt32(txtULayoutID.Text);
            bindData.EnrolLocationName = Request.Cookies["UserSession"].Values["PCName"].ToString();
            #endregion

            #region response
            ResponseDataTypeIUD result = host.UpdateDocType(bindData);
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

    private void GetLayoutID()
    {

        #region ***

        #region Call the webservices
        DALMService result = new DALMService();
        RequestDataTypeSelectLayoutID bindData = new RequestDataTypeSelectLayoutID();
        bindData.ActionDescription = "Layout ID - Select";
        bindData.SessionKey = Request.Cookies["UserSession"].Values["sessionKey"].ToString();
        bindData.PermissionCode = "17.40.7";
        bindData.Desc = string.Empty;
        bindData.EnrolLocationName = Request.Cookies["UserSession"].Values["PCName"].ToString();
        #endregion

        #region response
        ResponseDataTypeSelectLayoutID getdata = result.SelectLayoutID(bindData);
        string StatusCode = getdata.StatusCode;
        string StatusMsg = getdata.StatusMessage;
        #endregion

        #region process
        if (StatusCode == "0")
        {
            txtLayoutID.DataSource = getdata.ResultList;
            txtLayoutID.DataTextField = "Description";
            txtLayoutID.DataValueField = "LayoutID";
            txtLayoutID.DataBind();
            txtLayoutID.Items.Insert(0, new ListItem("-SELECT-", ""));

            txtULayoutID.DataSource = getdata.ResultList;
            txtULayoutID.DataTextField = "Description";
            txtULayoutID.DataValueField = "LayoutID";
            txtULayoutID.DataBind();
            txtULayoutID.Items.Insert(0, new ListItem("-SELECT-", ""));

        }
        else
        {
            throw new Exception((StatusMsg == string.Empty) ? common.UNBOUND : StatusMsg);
        }
        #endregion

        #endregion
    }

    protected void gvDocType_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[2].Text = txtLayoutID.Items.FindByValue(e.Row.Cells[2].Text).Text;
        }
    }
}
