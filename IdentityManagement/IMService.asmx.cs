using IdentityManagement.ObjectHandler;
using System.Web.Services;

namespace IdentityManagement
{
    /// <summary>
    /// Summary description for IMService
    /// </summary>
    [WebService(Namespace = "http://acme.com/", Description = "ACME Company. (M) Web Services . Copyright 2016")]
    public class IMService : System.Web.Services.WebService
    {
        #region Client's Web Methods

        [WebMethod(true, Description = "Identity Management Webservice request digester.")]
        public string IdentityManagementRequest(string s_XMLString)
        {
            MessageHandler rqInfo = new MessageHandler();
            rqInfo.ProcessMessage(s_XMLString);

            return rqInfo.ResultResponse();
        }

        #endregion
    }
}
