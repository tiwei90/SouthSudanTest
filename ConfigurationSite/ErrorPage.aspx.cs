using ConfigurationSite.Shared;
using System;

public partial class usercontrol_ErrorPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["ms"] != null)
        {
            Label1.Text = common.logoutErrMsg;
        }
    }
    //private void checkLogout(object source, ElapsedEventArgs e)
    //{
    //    Response.Redirect("Default.aspx");
    //}
}
