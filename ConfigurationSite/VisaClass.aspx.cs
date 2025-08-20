using ConfigurationSite.DALMSWS;
using ConfigurationSite.Shared;
using System;
using System.Data;
using System.Web.UI.WebControls;

public partial class VisaClass : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["UserSession"].Values["sessionKey"] == null) Response.Redirect(common.ErPage);

        lblMsg.Text = "";

        if (!Page.IsPostBack)
        {
            MV.SetActiveView(vSelect);
            BindGrid();
            BindDocType();
        }
    }

    private void BindGrid()
    {
        #region ***
        try
        {
            #region Call the webservices
            DALMService result = new DALMService();
            RequestDataTypeSelectVisaClass bindData = new RequestDataTypeSelectVisaClass();
            bindData.ActionDescription = "Visa Class  - Select";
            bindData.SessionKey = Request.Cookies["UserSession"].Values["sessionKey"].ToString();
            bindData.PermissionCode = common.GetValue("SelectVisaClass");
            #endregion

            #region response
            ResponseDataTypeSelectVisaClass getdata = result.SelectLookupVisaClassList(bindData);
            string StatusCode = getdata.StatusCode;
            string StatusMsg = getdata.StatusMessage;
            #endregion

            #region process
            if (StatusCode == "0")
            {
                ViewState["VisaClass"] = getdata.ResultList;
                DataSet Ds = (DataSet)ViewState["VisaClass"];
                gvVisaClass.DataSource = Ds.Tables[0];
                gvVisaClass.DataBind();
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

    private void BindDocType()
    {
        #region ***
        try
        {
            #region Call the webservices
            DALMService result = new DALMService();
            RequestDataTypeSelectDocType bindData = new RequestDataTypeSelectDocType();
            bindData.ActionDescription = "Document Type  - Select";
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
                DataSet Ds = (DataSet)getdata.ResultList;
                ddlDocType.DataSource = Ds.Tables[0];
                ddlDocType.DataBind();
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
        gvVisaClass.PageIndex = e.NewPageIndex;
        gvVisaClass.DataSource = (DataSet)ViewState["VisaClass"];
        gvVisaClass.DataBind();
        lblErrMsg.Visible = false;
        #endregion
    }
    protected void gvVisaClass_SelectedIndexChanged(object sender, EventArgs e)
    {
        #region ***
        lblUpErr.Visible = false;
        MV.SetActiveView(vUpdate);
        lblDocType.Text = gvVisaClass.SelectedRow.Cells[0].Text;
        lblClass.Text = gvVisaClass.SelectedRow.Cells[1].Text;
        txtUDesc.Text = gvVisaClass.SelectedRow.Cells[2].Text;
        txtUDesc.Focus();
        #endregion
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        #region ***
        try
        {
            GridViewRow row = ((LinkButton)sender).Parent.Parent as GridViewRow;
            gvVisaClass.SelectedIndex = row.RowIndex;

            #region Call the webservices
            DALMService host = new DALMService();
            RequestDataTypeIUDVisaClass bindData = new RequestDataTypeIUDVisaClass();
            bindData.ActionDescription = "Visa Class - Delete";
            bindData.SessionKey = Request.Cookies["UserSession"].Values["sessionKey"].ToString();
            bindData.PermissionCode = common.GetValue("DeleteVisaClass");
            bindData.DocType = gvVisaClass.SelectedRow.Cells[0].Text.Substring(0, gvVisaClass.SelectedRow.Cells[0].Text.IndexOf('-')).Trim();
            bindData.Class = Convert.ToInt32(gvVisaClass.SelectedRow.Cells[1].Text);
            bindData.EnrolLocationName = Request.Cookies["UserSession"].Values["PCName"].ToString();
            #endregion

            #region response
            ResponseDataTypeIUD result = host.DeleteVisaClass(bindData);
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
        ddlDocType.Focus();
        #endregion
    }

    private void clearAll()
    {
        #region ***
        ddlDocType.SelectedIndex = -1;
        txtClass.Text = string.Empty;
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
            RequestDataTypeIUDVisaClass bindData = new RequestDataTypeIUDVisaClass();
            bindData.ActionDescription = "Visa Class - Insert";
            bindData.SessionKey = Request.Cookies["UserSession"].Values["sessionKey"].ToString();
            bindData.PermissionCode = common.GetValue("InsertVisaClass");
            bindData.DocType = ddlDocType.SelectedValue;
            bindData.Class = Convert.ToInt32(txtClass.Text);
            bindData.Desc = txtDesc.Text;
            bindData.EnrolLocationName = Request.Cookies["UserSession"].Values["PCName"].ToString();
            #endregion

            #region response
            ResponseDataTypeIUD result = host.InsertVisaClass(bindData);
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
            RequestDataTypeIUDVisaClass bindData = new RequestDataTypeIUDVisaClass();
            bindData.ActionDescription = "Visa Class - Update";
            bindData.SessionKey = Request.Cookies["UserSession"].Values["sessionKey"].ToString();
            bindData.PermissionCode = common.GetValue("UpdateVisaClass");
            bindData.DocType = lblDocType.Text.Substring(0, lblDocType.Text.IndexOf('-')).Trim();
            bindData.Class = Convert.ToInt32(lblClass.Text);
            bindData.Desc = txtUDesc.Text;
            bindData.EnrolLocationName = Request.Cookies["UserSession"].Values["PCName"].ToString();
            #endregion

            #region response
            ResponseDataTypeIUD result = host.UpdateVisaClass(bindData);
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
