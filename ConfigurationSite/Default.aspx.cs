using System;

public partial class Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.ExpiresAbsolute = DateTime.Now.AddDays(-1d);
        Response.Expires = -1500;
        Response.CacheControl = "no-cache";

        string s = "<SCRIPT type='text/javascript'>document.getElementById('Login1_txt_name').focus() </SCRIPT>";

        this.RegisterStartupScript("focus", s);

        string[] cookies = Request.Cookies.AllKeys;
        foreach (string cookie in cookies)
        {
            Response.Cookies[cookie].Expires = DateTime.Now.AddDays(-1);
        }
    }
}
