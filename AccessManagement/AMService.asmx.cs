using AccessManagement.ObjectHandler;
using System.ComponentModel;
using System.Web.Services;

namespace AccessManagement
{
    /// <summary>
    /// Summary description for Service1.
    [WebService(Namespace = "http://acme.com/", Description = "ACME Company. (M) Web Services . Copyright 2025")]
    /// </summary>
    public class AMService : System.Web.Services.WebService
    {
        public AMService()
        {
            //CODEGEN: This call is required by the ASP.NET Web Services Designer
            InitializeComponent();
        }

        #region Component Designer generated code

        //Required by the Web Services Designer 
        private IContainer components = null;

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {

        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #endregion

        // WEB SERVICE EXAMPLE
        // The HelloWorld() example service returns the string Hello World
        // To build, uncomment the following lines then save and build the project
        // To test this web service, press F5

        #region Client's Web Methods

        [WebMethod(true, Description = "Access Management Webservice request digester.")]
        public string AccessManagementRequest(string s_XMLString)
        {
            MessageHandler rqInfo = new MessageHandler();
            rqInfo.ProcessMessage(s_XMLString);

            return rqInfo.ResultResponse();
        }

        #endregion
    }
}
