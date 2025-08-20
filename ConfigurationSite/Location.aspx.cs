using ConfigurationSite.DALMSWS;
using ConfigurationSite.Shared;
using System;
using System.Data;
using System.Web.UI.WebControls;
using System.Xml;

public partial class Location : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["UserSession"].Values["sessionKey"] == null) Response.Redirect(common.ErPage);

        lblMsg.Text = "";

        if (!Page.IsPostBack)
        {
            BindLocationType();
            BindBranchCode();
            MV.SetActiveView(vSelect);
            BindGrid();
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        #region ***
        clearAll();
        MV.SetActiveView(vInsert);
        txtName.Focus();
        #endregion
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        #region ***
        try
        {
            #region Call the webservices
            DALMService host = new DALMService();
            RequestDataTypeIUDLocation bindData = new RequestDataTypeIUDLocation();
            bindData.ActionDescription = "Location - Insert";
            bindData.SessionKey = Request.Cookies["UserSession"].Values["sessionKey"].ToString();
            bindData.PermissionCode = "18.42.1";
            bindData.Name = txtName.Text;
            bindData.LocationType = ddlType.SelectedValue;
            bindData.BranchCode = ddlBranch.SelectedValue;
            bindData.EnrolLocationName = Request.Cookies["UserSession"].Values["PCName"].ToString();
            #endregion

            #region response
            ResponseDataTypeIUD result = host.InsertLocation(bindData);
            string StatusCode = result.StatusCode;
            string StatusMsg = result.StatusMessage;
            #endregion

            #region process
            if (StatusCode == "0")
            {
                lblInErr.Visible = false;
                MV.SetActiveView(vSelect);
                BindGrid();
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
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        #region ***
        try
        {
            #region Call the webservices
            DALMService host = new DALMService();
            RequestDataTypeIUDLocation bindData = new RequestDataTypeIUDLocation();
            bindData.ActionDescription = "Location - Update";
            bindData.SessionKey = Request.Cookies["UserSession"].Values["sessionKey"].ToString();
            bindData.PermissionCode = "18.42.3";
            bindData.ID = Convert.ToInt64(lblID.Text);
            bindData.Name = txtUName.Text;
            bindData.LocationType = ddlUType.SelectedValue;
            bindData.BranchCode = ddlUBranch.SelectedValue;
            bindData.Obsolete = Convert.ToInt16(chkObosolete.Checked);
            bindData.EnrolLocationName = Request.Cookies["UserSession"].Values["PCName"].ToString();
            #endregion

            #region response
            ResponseDataTypeIUD result = host.UpdateLocation(bindData);
            string StatusCode = result.StatusCode;
            string StatusMsg = result.StatusMessage;
            #endregion

            #region process
            if (StatusCode == "0")
            {
                lblUpErr.Visible = false;
                MV.SetActiveView(vSelect);
                BindGrid();
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
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        #region ***
        clearAll();
        MV.SetActiveView(vSelect);
        BindGrid();
        #endregion
    }

    private void clearAll()
    {
        #region ***
        txtName.Text = string.Empty;
        ddlBranch.SelectedIndex = -1;
        ddlType.SelectedIndex = -1;
        lblInErr.Visible = false;
        #endregion
    }

    protected void PageIndexChanging_Click(object sender, GridViewPageEventArgs e)
    {
        #region ***
        gvLocation.PageIndex = e.NewPageIndex;
        gvLocation.DataSource = (DataSet)ViewState["CTModeList"];
        gvLocation.DataBind();
        lblErrMsg.Visible = false;
        #endregion
    }
    protected void gvLocation_SelectedIndexChanged(object sender, EventArgs e)
    {
        #region ***
        lblUpErr.Visible = false;
        MV.SetActiveView(vUpdate);
        lblID.Text = gvLocation.SelectedRow.Cells[0].Text;
        txtUName.Text = gvLocation.SelectedRow.Cells[1].Text;
        ddlUType.SelectedIndex = ddlUType.Items.IndexOf(ddlUType.Items.FindByText(gvLocation.SelectedRow.Cells[2].Text));
        ddlUBranch.SelectedIndex = ddlUBranch.Items.IndexOf(ddlUBranch.Items.FindByValue(gvLocation.SelectedRow.Cells[3].Text));
        chkObosolete.Checked = Convert.ToBoolean(gvLocation.SelectedRow.Cells[4].Text);
        txtUName.Focus();
        #endregion
    }

    private void BindGrid()
    {
        #region ***
        try
        {
            #region Call the webservices
            DALMService result = new DALMService();
            RequestDataTypeSelectLocation bindData = new RequestDataTypeSelectLocation();
            bindData.ActionDescription = "Location  - Select";
            bindData.SessionKey = Request.Cookies["UserSession"].Values["sessionKey"].ToString();
            bindData.PermissionCode = "18.42.7";
            #endregion

            #region response
            ResponseDataTypeSelectLocation getdata = result.SelectLocationList(bindData);
            string StatusCode = getdata.StatusCode;
            string StatusMsg = getdata.StatusMessage;
            #endregion

            #region process
            if (StatusCode == "0")
            {
                ViewState["CTModeList"] = getdata.ResultList;
                DataSet Ds = (DataSet)ViewState["CTModeList"];
                gvLocation.DataSource = Ds.Tables[0];
                gvLocation.DataBind();
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

    private void BindLocationType()
    {
        XmlDocument doc = new XmlDocument();
        doc.Load(Server.MapPath("LocationType.xml"));
        XmlNodeList nodeList = doc.SelectNodes("Location/Location");

        foreach (XmlNode node in nodeList)
        {
            ddlType.Items.Add(new ListItem(node.SelectSingleNode("Type").InnerText));
            ddlUType.Items.Add(new ListItem(node.SelectSingleNode("Type").InnerText));
        }
    }

    private void BindBranchCode()
    {
        #region ***
        try
        {
            #region Call the webservices
            DALMService result = new DALMService();
            RequestDataTypeSelectBranch bindData = new RequestDataTypeSelectBranch();
            bindData.ActionDescription = "Branch  - Select";
            bindData.SessionKey = Request.Cookies["UserSession"].Values["sessionKey"].ToString();
            bindData.PermissionCode = "11.115.7";
            #endregion

            #region response
            ResponseDataTypeSelectBranch getdata = result.SelectBranchList(bindData);
            string StatusCode = getdata.StatusCode;
            string StatusMsg = getdata.StatusMessage;
            #endregion

            #region process
            if (StatusCode == "0")
            {
                DataSet Ds = getdata.ResultList;
                ddlBranch.DataSource = Ds.Tables[0];
                ddlBranch.DataBind();

                ddlUBranch.DataSource = Ds.Tables[0];
                ddlUBranch.DataBind();
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
}
