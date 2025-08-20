using ConfigurationSite.Shared;
using System;

public partial class logon : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        GetLoginInfo();
    }
    private void GetLoginInfo()
    {
        #region ***
        if (Request.Cookies["UserSession"].Values["sessionKey"] == null)
        {
            Response.Redirect(common.ErPage);
        }
        else
        {
            //string session=Request.Cookies["UserSession"].Values["sessionKey"].ToString();
            lbl_msg.Text = "Logged in since " + Request.Cookies["UserSession"].Values["loginTime"].ToString();
            lbl_name.Text = "Logged in as  " + Request.Cookies["UserSession"].Values["loginName"].ToString().ToUpper();

        }
        #endregion
    }
}
