using ConfigurationSite.Shared;
using System;
using System.Xml;

public partial class sidemenu : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["UserSession"].Values["sessionKey"] == null) Response.Redirect(common.ErPage);
        else
        {
            lblTime.Text = Request.Cookies["UserSession"].Values["loginTime"].ToString();
            lblUserName.Text = Request.Cookies["UserSession"].Values["loginName"].ToString().ToUpper();
        }

        #region Version
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(@Server.MapPath("") + "\\Version.xml");
        XmlNode xmlRoot = xmlDoc.DocumentElement;
        lblModule.Text = xmlRoot.SelectSingleNode("ModuleName").InnerText + " - " + xmlRoot.SelectSingleNode("VersionNo").InnerText;
        //lblVersion.Text = xmlRoot.SelectSingleNode("VersionNo").InnerText;
        #endregion
    }
}
