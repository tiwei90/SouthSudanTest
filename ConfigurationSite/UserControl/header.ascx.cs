using ConfigurationSite.AccessManagementWS;
using ConfigurationSite.Shared;
using System;
using System.Text;
using System.Xml;

public partial class inc_header : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.ExpiresAbsolute = DateTime.Now.AddDays(-1d);
        Response.Expires = -1500;
        Response.CacheControl = "no-cache";

        #region ***
        if (Request.Cookies["UserSession"].Values["sessionKey"] != null)
        {
            string session = Request.Cookies["UserSession"].Values["sessionKey"].ToString();

        }
        else
        {
            common.logoutErrMsg = "You have no right to view this page. Kindly login inorder to proceed.";
            Response.Redirect("ErrorPage.aspx?ms=5");
        }
        #endregion
    }
    protected void btnLogout_Click(object sender, EventArgs e)
    {

        common cm = new common();
        #region ***
        try
        {
            #region Form request xml
            //Form Logout request xml
            StringBuilder requestXmlStr = new StringBuilder();

            requestXmlStr.Append("<?xml version='1.0' encoding='utf-8' ?> ");
            requestXmlStr.Append("<VISWEBREQUEST>");
            requestXmlStr.Append("<PERMISSIONCODE>16.63.6</PERMISSIONCODE>");
            requestXmlStr.Append("<ACTIONDESCRIPTION>User - EndSession</ACTIONDESCRIPTION>");
            //Transaction time
            requestXmlStr.Append("<TRANSACTIONDATETIME>");
            requestXmlStr.Append(System.DateTime.Now.ToString("yyyyMMddHHmmssfff"));
            requestXmlStr.Append("</TRANSACTIONDATETIME>");
            requestXmlStr.Append("<PAYLOAD>");
            requestXmlStr.Append("<LOGINNAME></LOGINNAME>");
            requestXmlStr.Append("<PASSWORDHASH></PASSWORDHASH>");
            requestXmlStr.Append("<IPADDRESS></IPADDRESS>");
            //Session key
            requestXmlStr.Append("<SESSIONKEY>");
            requestXmlStr.Append(Request.Cookies["UserSession"].Values["sessionKey"].ToString());
            requestXmlStr.Append("</SESSIONKEY>");
            requestXmlStr.Append("</PAYLOAD>");
            requestXmlStr.Append("</VISWEBREQUEST>");
            #endregion            

            #region Call Web Service and Get Result
            AMService webRequest = new AMService();

            string resResult = webRequest.AccessManagementRequest(requestXmlStr.ToString());

            XmlDocument doc = new XmlDocument();
            // Write the XML document to the stream
            doc.LoadXml(resResult);

            #endregion

            #region Analyse result
            XmlNode xmlRoot = doc.DocumentElement;

            string statusCode = xmlRoot.SelectSingleNode("STATUS").FirstChild.InnerText;
            string statusMsg = xmlRoot.SelectSingleNode("STATUS").LastChild.InnerText;

            if (statusCode == "0")
            {
                this.Session.Clear();
                common.logoutErrMsg = "Logout successfully! ";
                Response.Redirect("ErrorPage.aspx?ms=2");

            }

            else
            {
                this.Session.Clear();
                common.logoutErrMsg = (statusMsg.Remove(0, 35) + " !");
                Response.Redirect("ErrorPage.aspx?ms=1");
            }
            #endregion
        }
        catch
        {
            this.Session.Clear();
            common.logoutErrMsg = "Logout successfully!";
            Response.Redirect("ErrorPage.aspx?ms=1");
        }
        #endregion
    }

}
