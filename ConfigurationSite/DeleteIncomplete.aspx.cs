using ConfigurationSite.EMSWS;
using ConfigurationSite.Shared;
using System;
using System.IO;
using System.Web.UI.WebControls;

public partial class DeleteIncomplete : System.Web.UI.Page
{
    string TempFileDir = common.GetValue("xmlServerPath");

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["UserSession"].Values["sessionKey"] == null) Response.Redirect(common.ErPage);

        #region Request
        EMService webSvr = new EMService();
        RequestDataTypeGetPermission req = new RequestDataTypeGetPermission();
        req.PermissionCode = common.DELETEINCOMPLETE;
        req.ActionDescription = "Device Test";
        req.SessionKey = Request.Cookies["UserSession"].Values["sessionKey"].ToString();
        #endregion

        #region Response
        ResponseDataTypeGetPermission data = webSvr.GetPermission(req);
        string rslt = data.Result;
        #endregion

        #region change process
        if (rslt != "True")
        {
            Response.Redirect("ErrorPermission.aspx?sm=14");
        }
        #endregion

        btnDelete.Attributes.Add("onclick", "return confirmDelete();");

        if (!Page.IsPostBack)
            GetImcompleteFile();
    }

    private void GetImcompleteFile()
    {

        #region ***
        /* Transaction Type
         * 1 - New Enrollment
         * 2 - Renew
         * 3 - Replace
         * 4 - Emergency
         * 5 - Additional
         * 6 - Data Entry
         * 9 - Update Profile - Data Entry
         * A - Update Profile - Enrollment
         */

        try
        {
            string[] fileList = Directory.GetFiles(TempFileDir);
            foreach (string filename in fileList)
            {
                FileInfo fileInfo = new FileInfo(filename);
                ListItem li = new ListItem();

                string transactionType = fileInfo.Name.Substring(0, (fileInfo.Name.Length - fileInfo.Extension.Length));

                #region categorised incomplete enrollment according to group permisson
                if (transactionType.Substring(transactionType.Length - 1) == common.GetValue("CompleteEnrol"))
                {
                    li.Value = fileInfo.Name.Substring(0, (fileInfo.Name.Length - (fileInfo.Extension.Length)));
                    li.Text = fileInfo.Name.Substring(0, (fileInfo.Name.Length - (fileInfo.Extension.Length + 1)));
                    lstDataEntryFiles.Items.Add(li);
                }
                else if (transactionType.Substring(transactionType.Length - 1) == common.GetValue("UpdateProfileEntry") ||
                    transactionType.Substring(transactionType.Length - 1) == common.GetValue("UpdateProfileEnroll") ||
                    transactionType.Substring(transactionType.Length - 1) == common.GetValue("UpdateProfilePE"))
                {
                    li.Value = fileInfo.Name.Substring(0, (fileInfo.Name.Length - (fileInfo.Extension.Length)));
                    li.Text = fileInfo.Name.Substring(0, (fileInfo.Name.Length - (fileInfo.Extension.Length + 1)));
                    lstUpdateProfileFiles.Items.Add(li);
                }
                else
                {
                    li.Value = fileInfo.Name.Substring(0, (fileInfo.Name.Length - (fileInfo.Extension.Length)));
                    li.Text = fileInfo.Name.Substring(0, (fileInfo.Name.Length - (fileInfo.Extension.Length + 1)));
                    lstEnrolFiles.Items.Add(li);
                }

                #endregion
            }
        }
        catch (Exception ex)
        {
        }
        #endregion
    }

    #region Data Entry
    protected void btnSelectAllDataEntry_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < lstDataEntryFiles.Items.Count; ++i)
        {
            lstSelectedDataEntryFiles.Items.Add(lstDataEntryFiles.Items[i]);
        }
        lstDataEntryFiles.DataSource = "";
        lstDataEntryFiles.DataBind();

    }
    protected void btnSelectDataEntry_Click(object sender, EventArgs e)
    {
        if (lstDataEntryFiles.SelectedIndex > -1)
        {
            lstSelectedDataEntryFiles.SelectedIndex = -1;
            lstSelectedDataEntryFiles.Items.Add(lstDataEntryFiles.SelectedItem);
            lstDataEntryFiles.Items.RemoveAt(lstDataEntryFiles.SelectedIndex);
        }
    }
    protected void btnUnselectAllDataEntry_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < lstSelectedDataEntryFiles.Items.Count; ++i)
        {
            lstDataEntryFiles.Items.Add(lstSelectedDataEntryFiles.Items[i]);
        }
        lstSelectedDataEntryFiles.DataSource = "";
        lstSelectedDataEntryFiles.DataBind();
    }
    protected void btnUnselectDataEntry_Click(object sender, EventArgs e)
    {
        if (lstSelectedDataEntryFiles.SelectedIndex > -1)
        {
            lstDataEntryFiles.SelectedIndex = -1;
            lstDataEntryFiles.Items.Add(lstSelectedDataEntryFiles.SelectedItem);
            lstSelectedDataEntryFiles.Items.RemoveAt(lstSelectedDataEntryFiles.SelectedIndex);
        }
    }
    #endregion

    #region Enrollment
    protected void btnSelectAllEnrol_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < lstEnrolFiles.Items.Count; ++i)
        {
            lstSelectedEnrolFiles.Items.Add(lstEnrolFiles.Items[i]);
        }
        lstEnrolFiles.DataSource = "";
        lstEnrolFiles.DataBind();

    }
    protected void btnSelectEnrol_Click(object sender, EventArgs e)
    {
        if (lstEnrolFiles.SelectedIndex > -1)
        {
            lstSelectedEnrolFiles.SelectedIndex = -1;
            lstSelectedEnrolFiles.Items.Add(lstEnrolFiles.SelectedItem);
            lstEnrolFiles.Items.RemoveAt(lstEnrolFiles.SelectedIndex);
        }
    }
    protected void btnUnselectAllEnrol_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < lstSelectedEnrolFiles.Items.Count; ++i)
        {
            lstEnrolFiles.Items.Add(lstSelectedEnrolFiles.Items[i]);
        }
        lstSelectedEnrolFiles.DataSource = "";
        lstSelectedEnrolFiles.DataBind();

    }
    protected void btnUnselectEnrol_Click(object sender, EventArgs e)
    {
        if (lstSelectedEnrolFiles.SelectedIndex > -1)
        {
            lstEnrolFiles.SelectedIndex = -1;
            lstEnrolFiles.Items.Add(lstSelectedEnrolFiles.SelectedItem);
            lstSelectedEnrolFiles.Items.RemoveAt(lstSelectedEnrolFiles.SelectedIndex);
        }
    }
    #endregion

    #region Update Profile
    protected void btnSelectAllUpdateProfile_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < lstUpdateProfileFiles.Items.Count; ++i)
        {
            lstSelectedUpdateProfileFiles.Items.Add(lstUpdateProfileFiles.Items[i]);
        }
        lstUpdateProfileFiles.DataSource = "";
        lstUpdateProfileFiles.DataBind();
    }
    protected void btnSelectUpdateProfile_Click(object sender, EventArgs e)
    {
        if (lstUpdateProfileFiles.SelectedIndex > -1)
        {
            lstSelectedUpdateProfileFiles.SelectedIndex = -1;
            lstSelectedUpdateProfileFiles.Items.Add(lstUpdateProfileFiles.SelectedItem);
            lstUpdateProfileFiles.Items.RemoveAt(lstUpdateProfileFiles.SelectedIndex);
        }
    }
    protected void btnUnselectAllUpdateProfile_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < lstSelectedUpdateProfileFiles.Items.Count; ++i)
        {
            lstUpdateProfileFiles.Items.Add(lstSelectedUpdateProfileFiles.Items[i]);
        }
        lstSelectedUpdateProfileFiles.DataSource = "";
        lstSelectedUpdateProfileFiles.DataBind();

    }
    protected void btnUnselectUpdateProfile_Click(object sender, EventArgs e)
    {
        if (lstSelectedUpdateProfileFiles.SelectedIndex > -1)
        {
            lstUpdateProfileFiles.SelectedIndex = -1;
            lstUpdateProfileFiles.Items.Add(lstSelectedUpdateProfileFiles.SelectedItem);
            lstSelectedUpdateProfileFiles.Items.RemoveAt(lstSelectedUpdateProfileFiles.SelectedIndex);
        }
    }
    #endregion

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < lstSelectedEnrolFiles.Items.Count; ++i)
        {
            File.Delete(TempFileDir + "\\" + lstSelectedEnrolFiles.Items[i].Value + ".xml");
        }

        for (int i = 0; i < lstSelectedDataEntryFiles.Items.Count; ++i)
        {
            File.Delete(TempFileDir + "\\" + lstSelectedDataEntryFiles.Items[i].Value + ".xml");
        }

        for (int i = 0; i < lstSelectedUpdateProfileFiles.Items.Count; ++i)
        {
            File.Delete(TempFileDir + "\\" + lstUpdateProfileFiles.Items[i].Value + ".xml");
        }

        lblMsg.Text = "Files deleted";
        btnDelete.Enabled = false;
        PanelDataEntry.Enabled = false;
        PanelEnroll.Enabled = false;
        PanelUpdateProfile.Enabled = false;
    }
}
