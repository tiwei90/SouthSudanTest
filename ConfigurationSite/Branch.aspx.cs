using ConfigurationSite.DALMSWS;
using ConfigurationSite.IdentityManagementWS;
using ConfigurationSite.Shared;
using System;
using System.Data;
using System.IO;
using System.Web.UI.WebControls;
using System.Xml;

public partial class Branch : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["UserSession"].Values["sessionKey"] == null) Response.Redirect(common.ErPage);

        lblMsg.Text = "";

        if (!Page.IsPostBack)
        {
            MV.SetActiveView(vSelect);
            BindGrid();
            BindCountry();
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
            bindData.ActionDescription = "Branch - Select";
            bindData.SessionKey = Request.Cookies["UserSession"].Values["sessionKey"].ToString();
            bindData.PermissionCode = common.GetValue("SelectBranchWithCountry"); ;
            #endregion

            #region response
            ResponseDataTypeSelectAll getdata = result.SelectBranch(bindData);
            string StatusCode = getdata.StatusCode;
            string StatusMsg = getdata.StatusMessage;
            #endregion

            #region process
            if (StatusCode == "0")
            {
                ViewState["Branch"] = getdata.ResultList;
                DataSet Ds = (DataSet)ViewState["Branch"];
                gvBranch.DataSource = Ds.Tables[0];
                gvBranch.DataBind();
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

    private void BindCountry()
    {
        try
        {
            #region Call the webservices

            ConfigurationSite.EMSWS.EMService ems = new ConfigurationSite.EMSWS.EMService();
            ConfigurationSite.EMSWS.RequestDataTypeSelectCountry bindData = new ConfigurationSite.EMSWS.RequestDataTypeSelectCountry();
            bindData.ActionDescription = "Country - Select";
            bindData.EnrolLocationName = Request.Cookies["UserSession"].Values["PCName"].ToString();
            bindData.SessionKey = Request.Cookies["UserSession"].Values["sessionKey"].ToString();
            bindData.PermissionCode = common.GetValue("SelectCountry"); ;
            bindData.SortBy = '1';
            #endregion

            #region response
            ConfigurationSite.EMSWS.ResponseDataTypeSelectCountry getdata = ems.GetCountryList(bindData);
            string StatusCode = getdata.StatusCode;
            string StatusMsg = getdata.StatusMessage;
            #endregion

            #region process
            if (StatusCode == "0")
            {
                ddlCountry.DataSource = getdata.ResultList.Tables[0];
                ddlCountry.DataBind();
                lblErrMsg.Visible = false;

                ddlCountry.Items.Insert(0, new ListItem("-SELECT-", ""));

                HiddenCountry.DataSource = getdata.ResultList.Tables[0];
                HiddenCountry.DataBind();
                HiddenCountry.Items.Insert(0, new ListItem("-SELECT-", ""));
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

    private void BindState(string CountryID)
    {
        try
        {
            #region write XML
            XmlDocument xmlDoc = new XmlDocument();

            xmlDoc.AppendChild(xmlDoc.CreateElement("VISWEBREQUEST"));

            XmlElement xmlRoot = xmlDoc.DocumentElement;
            XmlElement xmlWebRequest;
            XmlElement xmlPayload;
            XmlText xmlText;

            xmlWebRequest = xmlDoc.CreateElement("", "PERMISSIONCODE", "");
            xmlText = xmlDoc.CreateTextNode(common.GetValue("SelectState"));
            xmlWebRequest.AppendChild(xmlText);
            xmlRoot.AppendChild(xmlWebRequest);

            xmlWebRequest = xmlDoc.CreateElement("", "ACTIONDESCRIPTION", "");
            xmlText = xmlDoc.CreateTextNode("State - Select All");
            xmlWebRequest.AppendChild(xmlText);
            xmlRoot.AppendChild(xmlWebRequest);

            xmlWebRequest = xmlDoc.CreateElement("", "TRANSACTIONDATETIME", "");
            xmlText = xmlDoc.CreateTextNode(System.DateTime.Now.ToString("yyyyMMddHHmmssfff"));
            xmlWebRequest.AppendChild(xmlText);
            xmlRoot.AppendChild(xmlWebRequest);

            xmlWebRequest = xmlDoc.CreateElement("", "PAYLOAD", "");

            #region PAYLOAD
            xmlPayload = xmlDoc.CreateElement("", "SESSIONKEY", "");
            xmlText = xmlDoc.CreateTextNode(Request.Cookies["UserSession"].Values["sessionKey"].ToString());
            xmlPayload.AppendChild(xmlText);
            xmlWebRequest.AppendChild(xmlPayload);
            #endregion

            xmlRoot.AppendChild(xmlWebRequest);
            #endregion

            #region Call Web Service
            IMService idenWebSvr = new IMService();

            string resResult = idenWebSvr.IdentityManagementRequest(xmlDoc.InnerXml);
            #endregion

            #region Load Data Grid
            XmlDocument doc = new XmlDocument();

            doc.LoadXml(resResult);

            XmlNode xmlResRoot = doc.DocumentElement;

            string statusCode = xmlResRoot.SelectSingleNode("STATUS").FirstChild.InnerText;
            string statusMsg = xmlResRoot.SelectSingleNode("STATUS").LastChild.InnerText;

            if (statusCode == "0")
            {
                string data = xmlResRoot.SelectSingleNode("PAYLOAD").InnerXml;

                DataSet ds = new DataSet();
                StringReader stream = new StringReader(data);

                ds.ReadXml(stream);
                if (ds.Tables.Count < 1)
                {
                    lblInErr.Text = "No Record Found";

                    return;
                }

                DataView dv = new DataView(ds.Tables[0]);

                #region Assign The Value "|" Back To Value "&"

                DataColumn dc = new DataColumn();

                dc.DataType = System.Type.GetType("System.String");

                dv.Table.Columns.Add(dc);
                dv.RowFilter = "Obsolete = 'false' and CountryID = '" + CountryID + "'";

                foreach (DataRow dr in dv.Table.Rows)
                {
                    dr["Name"] = dr["Name"].ToString().Replace("|", "&").ToUpper();
                    dr["StateCode"] = dr["StateCode"].ToString().Replace("|", "&").ToUpper();
                }

                #endregion

                ddlState.DataSource = dv;
                ddlState.DataBind();

                ddlState.Items.Insert(0, new ListItem("-SELECT-", ""));

                ddlState.Enabled = true;
            }
            else
            {
                ddlState.Enabled = false;
                throw new Exception(statusMsg);
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
        gvBranch.PageIndex = e.NewPageIndex;
        gvBranch.DataSource = (DataSet)ViewState["Branch"];
        gvBranch.DataBind();
        lblErrMsg.Visible = false;
        #endregion
    }
    protected void gvBranch_SelectedIndexChanged(object sender, EventArgs e)
    {
        #region ***
        lblUpErr.Visible = false;
        MV.SetActiveView(vUpdate);

        lblCountry.Text = gvBranch.SelectedRow.Cells[0].Text;
        lblState.Text = gvBranch.SelectedRow.Cells[1].Text;
        lblBranchCode.Text = gvBranch.SelectedRow.Cells[2].Text;
        txtUBranchName.Text = gvBranch.SelectedRow.Cells[3].Text;
        txtUProcessDays.Text = gvBranch.SelectedRow.Cells[4].Text;
        txtUBranchName.Focus();
        #endregion
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        #region ***
        try
        {
            GridViewRow row = ((LinkButton)sender).Parent.Parent as GridViewRow;
            gvBranch.SelectedIndex = row.RowIndex;

            #region Call the webservices
            DALMService host = new DALMService();
            RequestDataTypeIUDBranch bindData = new RequestDataTypeIUDBranch();
            bindData.ActionDescription = "Branch - Delete";
            bindData.SessionKey = Request.Cookies["UserSession"].Values["sessionKey"].ToString();
            bindData.PermissionCode = common.GetValue("DeleteBranch");

            bindData.BranchCode = gvBranch.SelectedRow.Cells[2].Text;

            bindData.EnrolLocationName = Request.Cookies["UserSession"].Values["PCName"].ToString();
            #endregion

            #region response
            ResponseDataTypeIUD result = host.DeleteBranch(bindData);
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
        ddlCountry.Focus();
        #endregion
    }

    private void clearAll()
    {
        #region ***
        ddlCountry.SelectedIndex = -1;
        ddlState.SelectedIndex = -1;
        txtBranchName.Text = string.Empty;
        txtBranchCode.Text = string.Empty;
        txtProcessDays.Text = string.Empty;
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
            RequestDataTypeIUDBranch bindData = new RequestDataTypeIUDBranch();
            bindData.ActionDescription = "Branch - Insert";
            bindData.SessionKey = Request.Cookies["UserSession"].Values["sessionKey"].ToString();
            bindData.PermissionCode = common.GetValue("InsertBranch");
            bindData.StateCode = ddlState.SelectedValue;
            bindData.BranchCode = txtBranchCode.Text.Trim();
            bindData.BranchName = txtBranchName.Text.Trim();
            bindData.ProcessDays = Convert.ToInt32(txtProcessDays.Text);
            bindData.EnrolLocationName = Request.Cookies["UserSession"].Values["PCName"].ToString();
            HiddenCountry.SelectedIndex = ddlCountry.SelectedIndex;
            bindData.CountryCode = HiddenCountry.SelectedValue;
            #endregion

            #region response
            ResponseDataTypeIUD result = host.InsertBranch(bindData);
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
            RequestDataTypeIUDBranch bindData = new RequestDataTypeIUDBranch();
            bindData.ActionDescription = "Branch - Update";
            bindData.SessionKey = Request.Cookies["UserSession"].Values["sessionKey"].ToString();
            bindData.PermissionCode = common.GetValue("UpdateBranch");
            bindData.BranchCode = lblBranchCode.Text.Trim();
            bindData.BranchName = txtUBranchName.Text.Trim();
            bindData.ProcessDays = Convert.ToInt32(txtUProcessDays.Text);
            bindData.EnrolLocationName = Request.Cookies["UserSession"].Values["PCName"].ToString();
            #endregion

            #region response
            ResponseDataTypeIUD result = host.UpdateBranch(bindData);
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
    protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindState(ddlCountry.SelectedValue.ToString());
    }
}
