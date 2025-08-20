using ConfigurationSite.DALMSWS;
using ConfigurationSite.Shared;
using System;
using System.Data;
using System.Web.UI.WebControls;

public partial class PaymentMethod : System.Web.UI.Page
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
            RequestDataTypeSelectPaymentMethod bindData = new RequestDataTypeSelectPaymentMethod();
            bindData.ActionDescription = "Payment Method - Select";
            bindData.SessionKey = Request.Cookies["UserSession"].Values["sessionKey"].ToString();
            bindData.PermissionCode = "11.104.7";
            #endregion

            #region response
            ResponseDataTypeSelectPaymentMethod getdata = result.SelectPaymentMethodList(bindData);
            string StatusCode = getdata.StatusCode;
            string StatusMsg = getdata.StatusMessage;
            #endregion

            #region process
            if (StatusCode == "0")
            {
                ViewState["PMethod"] = getdata.ResultList;
                DataSet Ds = (DataSet)ViewState["PMethod"];
                gvPMethod.DataSource = Ds.Tables[0];
                gvPMethod.DataBind();
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
        gvPMethod.PageIndex = e.NewPageIndex;
        gvPMethod.DataSource = (DataSet)ViewState["PMethod"];
        gvPMethod.DataBind();
        lblErrMsg.Visible = false;
        #endregion
    }
    protected void gvPMethod_SelectedIndexChanged(object sender, EventArgs e)
    {
        #region ***
        lblUpErr.Visible = false;
        MV.SetActiveView(vUpdate);
        txtUID.Text = gvPMethod.SelectedRow.Cells[0].Text;
        lblPMethod.Text = gvPMethod.SelectedRow.Cells[1].Text;
        txtUDesc.Text = gvPMethod.SelectedRow.Cells[2].Text;
        txtUID.Focus();
        #endregion
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        #region ***
        try
        {
            GridViewRow row = ((LinkButton)sender).Parent.Parent as GridViewRow;
            gvPMethod.SelectedIndex = row.RowIndex;

            #region Call the webservices
            DALMService host = new DALMService();
            RequestDataTypeIUDPaymentMethod bindData = new RequestDataTypeIUDPaymentMethod();
            bindData.ActionDescription = "Payment Method - Delete";
            bindData.SessionKey = Request.Cookies["UserSession"].Values["sessionKey"].ToString();
            bindData.PermissionCode = "11.104.4";
            bindData.PaymentMethod = Convert.ToInt32(gvPMethod.SelectedRow.Cells[1].Text);
            bindData.Desc = string.Empty;
            bindData.EnrolLocationName = Request.Cookies["UserSession"].Values["PCName"].ToString();
            #endregion

            #region response
            ResponseDataTypeIUD result = host.DeletePaymentMethod(bindData);
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
        txtID.Focus();
        #endregion
    }

    private void clearAll()
    {
        #region ***
        txtID.Text = string.Empty;
        txtPMethod.Text = string.Empty;
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
            RequestDataTypeIUDPaymentMethod bindData = new RequestDataTypeIUDPaymentMethod();
            bindData.ActionDescription = "Payment Method - Insert";
            bindData.SessionKey = Request.Cookies["UserSession"].Values["sessionKey"].ToString();
            bindData.PermissionCode = "11.104.1";
            bindData.ID = Convert.ToInt32(txtID.Text);
            bindData.PaymentMethod = Convert.ToInt32(txtPMethod.Text);
            bindData.Desc = txtDesc.Text;
            bindData.EnrolLocationName = Request.Cookies["UserSession"].Values["PCName"].ToString();
            #endregion

            #region response
            ResponseDataTypeIUD result = host.InsertPaymentMethod(bindData);
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
        Response.Write("<Script language='javascript'>alert('11');</Script>");
        #region ***
        try
        {
            #region Call the webservices
            DALMService host = new DALMService();
            RequestDataTypeIUDPaymentMethod bindData = new RequestDataTypeIUDPaymentMethod();
            bindData.ActionDescription = "Payment Method - Update";
            bindData.SessionKey = Request.Cookies["UserSession"].Values["sessionKey"].ToString();
            bindData.PermissionCode = "11.104.3";
            bindData.PaymentMethod = Convert.ToInt32(lblPMethod.Text);
            bindData.Desc = txtUDesc.Text;
            bindData.ID = Convert.ToInt32(txtUID.Text);
            bindData.EnrolLocationName = Request.Cookies["UserSession"].Values["PCName"].ToString();
            #endregion
            Response.Write("<Script language='javascript'>alert('22');</Script>");
            #region response
            ResponseDataTypeIUD result = host.UpdatePaymentMethod(bindData);
            string StatusCode = result.StatusCode;
            string StatusMsg = result.StatusMessage;
            #endregion
            Response.Write("<Script language='javascript'>alert('33');</Script>");

            Response.Write("<Script language='javascript'>alert('" + StatusCode + "');</Script>");

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
                Response.Write("<Script language='javascript'>alert('AA');</Script>");
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
