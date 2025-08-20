using System;
using System.Xml;

public partial class version : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(@Server.MapPath("") + "\\Version.xml");
        XmlNode xmlRoot = xmlDoc.DocumentElement;
        lblModule.Text = xmlRoot.SelectSingleNode("ModuleName").InnerText;
        lblVersion.Text = xmlRoot.SelectSingleNode("VersionNo").InnerText;
    }

}
