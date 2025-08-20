using System;

namespace EnrollmentIssuanceSite
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string[] cookies = Request.Cookies.AllKeys;

            foreach (string cookie in cookies)
            {
                Response.Cookies[cookie].Value = null;
                Response.Cookies[cookie].Expires = DateTime.Now.AddMonths(-1);
            }
        }
    }
}
