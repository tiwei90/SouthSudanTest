using EnrollmentIssuanceSite.Shared;
using System;
using System.Web.UI.HtmlControls;

namespace EnrollmentIssuanceSite
{
    public partial class UsercontrolErrorPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            switch (Request.QueryString["ms"])
            {
                case "7":
                    Label1.Text = "Permission Denied!";
                    break;
                case "8":
                    Label1.Text = "Location name does not exist!";
                    break;
                default:
                    Label1.Text = Common.logoutErrMsg;
                    break;
            }

        }
        private void SetRedirectLocation()
        {
            string actualPath = string.Empty;
            if (Common.GetCookie(this.Page, "System") != null && Common.GetCookie(this.Page, "System") == "Family")
                actualPath = Common.GetValue("FamilyDefault");
            else
                actualPath = "Default.aspx";

            HtmlMeta path = new HtmlMeta();
            path.Content = "2;URL=" + actualPath;
            path.HttpEquiv = "REFRESH";
            this.Page.Header.Controls.Add(path);
        }
    }
}
