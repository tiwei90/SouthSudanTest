using EnrollmentIssuanceSite.AccessManagementWS;
using EnrollmentIssuanceSite.Shared;
using System;
using System.Text;
using System.Xml;

namespace EnrollmentIssuanceSite.UserControl
{
    public partial class IncHeader : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.ExpiresAbsolute = DateTime.Now.AddDays(-1d);
            Response.Expires = -1500;
            Response.CacheControl = "no-cache";

            if (Common.GetCookie(this.Page, "sessionKey") != null)
            {
                string session = Common.GetCookie(this.Page, "sessionKey").ToString();
            }
            else
            {
                Common.logoutErrMsg = "Your session has timed out or has otherwise been ended by the system. Please login again to proceed.";
                Response.Redirect("ErrorPage.aspx?ms=5");
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Common cm = new Common();

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
                requestXmlStr.Append(Session["sessionKey"].ToString());
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
                    Common.logoutErrMsg = "Logout successfully! ";
                    Response.Redirect("ErrorPage.aspx?ms=2");
                }
                else
                {
                    Common.logoutErrMsg = (statusMsg.Remove(0, 35) + " !");
                    Response.Redirect("ErrorPage.aspx?ms=1");
                }
                #endregion
            }
            catch
            {
                Common.logoutErrMsg = "Logout successfully!";
                Response.Redirect("ErrorPage.aspx?ms=1");
            }
        }
    }
}
