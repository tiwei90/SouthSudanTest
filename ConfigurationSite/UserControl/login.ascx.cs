using ConfigurationSite.IdentityManagementWS;
using ConfigurationSite.Shared;
using System;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Xml;

namespace ConfigurationSite.usercontrol
{
    public partial class login : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.txtCompName.Value = Request[this.txtCompName.UniqueID];
        }

        protected void btn_login_Click(object sender, ImageClickEventArgs e)
        {
            #region ***

            #region Login Request Xml
            StringBuilder requestXmlStr = new StringBuilder();

            requestXmlStr.Append("<?xml version='1.0' encoding='utf-8' ?>");
            requestXmlStr.Append("<VISWEBREQUEST>");
            requestXmlStr.Append("<PERMISSIONCODE>13.63.9</PERMISSIONCODE>");
            requestXmlStr.Append("<ACTIONDESCRIPTION>User - PasswordLogin</ACTIONDESCRIPTION>");
            //Transaction time
            requestXmlStr.Append("<TRANSACTIONDATETIME>");
            requestXmlStr.Append(System.DateTime.Now.ToString("yyyyMMddHHmmssfff"));
            requestXmlStr.Append("</TRANSACTIONDATETIME>");
            requestXmlStr.Append("<PAYLOAD>");
            //Login name
            requestXmlStr.Append("<LOGINNAME>");
            requestXmlStr.Append(txt_name.Value);
            requestXmlStr.Append("</LOGINNAME>");
            //Password
            requestXmlStr.Append("<PASSWORDHASH>");
            requestXmlStr.Append(CalcPwdHash(txt_pwd.Text));
            requestXmlStr.Append("</PASSWORDHASH>");
            requestXmlStr.Append("<IPADDRESS></IPADDRESS>");
            requestXmlStr.Append("<SESSIONKEY></SESSIONKEY>");
            requestXmlStr.Append("</PAYLOAD>");
            requestXmlStr.Append("</VISWEBREQUEST>");
            #endregion

            #region Calling Web Services and Get Result
            IMService webRequest = new IMService();
            string resResult = webRequest.IdentityManagementRequest(requestXmlStr.ToString());

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(resResult);

            #endregion

            #region Analyse result
            XmlNode xmlRoot = doc.DocumentElement;

            string statusCode = xmlRoot.SelectSingleNode("STATUS").FirstChild.InnerText;
            string statusMsg = xmlRoot.SelectSingleNode("STATUS").LastChild.InnerText;
            HttpCookie session = new HttpCookie("UserSession");

            if (statusCode == "0")
            {
                session.Values.Add("loginName", xmlRoot.SelectSingleNode("PAYLOAD").ChildNodes[0].InnerText);
                session.Values.Add("sessionKey", xmlRoot.SelectSingleNode("PAYLOAD").LastChild.InnerText);
                session.Values.Add("loginTime", System.DateTime.Now.ToShortDateString() + " " + System.DateTime.Now.ToShortTimeString());
                session.Values.Add("PCName", this.txtCompName.Value);

                Response.Cookies.Add(session);

                Response.Redirect("logon.aspx");
            }
            else if (statusMsg == "User - PasswordLogin failed because incorrect Password")
            {
                lblMsg.Visible = true;
                lblMsg.Text = "Invalid Password!";
            }
            else if (statusMsg == "User - PasswordLogin failed because LoginName not found")
            {
                lblMsg.Visible = true;
                lblMsg.Text = "Invalid Username!";
            }
            else
            {
                lblMsg.Text = (statusMsg == string.Empty) ? common.FAILED : statusMsg.Replace(".", ". ");
                lblMsg.Visible = true;
            }
            #endregion

            #endregion
        }
        private string CalcPwdHash(string PlainPwd)
        {
            #region ***
            //This function convert password from plain text into Hash

            System.Security.Cryptography.SHA1CryptoServiceProvider SHA1 = new System.Security.Cryptography.SHA1CryptoServiceProvider();
            UTF8Encoding ue = new UTF8Encoding();
            byte[] pwdbuffer = ue.GetBytes(PlainPwd);
            byte[] hashBytes = SHA1.ComputeHash(pwdbuffer);

            // Convert the encrypted bytes back to a string (base 16)
            string hashString = String.Empty;

            for (int i = 0; i < hashBytes.Length; i++)
            {
                hashString += Convert.ToString(hashBytes[i], 16).PadLeft(2, '0');
            }

            return hashString.PadLeft(32, '0').ToUpper();
            #endregion
        }
    }
}
