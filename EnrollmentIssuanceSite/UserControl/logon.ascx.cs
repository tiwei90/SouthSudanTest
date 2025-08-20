using EnrollmentIssuanceSite.Shared;
using System;

namespace EnrollmentIssuanceSite.UserControl
{
    public partial class logon : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GetLoginInfo();
        }
        private void GetLoginInfo()
        {
            if (Common.GetCookie(this.Page, "sessionKey") == null)
            {
                Response.Redirect(Common.ErPage);
            }
            else
            {
                lbl_msg.Text = "Logged in since" + "&nbsp;" + Convert.ToDateTime(Common.GetCookie(this.Page, "loginTime").ToString()).ToString("dd/MM/yyyy hh:mm:tt");
                lbl_name.Text = "Logged in as " + Common.GetCookie(this.Page, "loginName").ToString().ToUpper();

            }
        }
    }
}
