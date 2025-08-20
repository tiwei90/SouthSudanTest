using IdentityManagement.Shared;
using IdentityManagement.Utilities;
using System;
using System.Configuration;

namespace IdentityManagement
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            string sSettingsPath = Server.MapPath(@ConfigurationManager.AppSettings["WebSvcSettings"].ToString());

            Globals.m_sConnString = XmlMethods.GetElementAttributeValue("//Settings//DataSource//ConnectionString", "value", sSettingsPath);
            Globals.m_sServerPath = Server.MapPath(String.Empty) + "\\";
            Globals.m_sSchemaPath = Server.MapPath(XmlMethods.GetElementAttributeValue("//Settings//WebConfig//SCHEMAPATH", "value", sSettingsPath));
            Globals.m_sLogPath = Server.MapPath(XmlMethods.GetElementAttributeValue("//Settings//WebConfig//LOGPATH", "value", sSettingsPath));
            Globals.m_sRequestPath = Server.MapPath(XmlMethods.GetElementAttributeValue("//Settings//WebConfig//XMLPATH", "value", sSettingsPath));
            Globals.m_sDebugMode = ConfigurationManager.AppSettings["DEBUG"];
            Globals.m_sSaveXML = ConfigurationManager.AppSettings["SAVEXML"];
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}