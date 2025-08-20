using EnrollmentIssuanceSite.DALMWS;
using EnrollmentIssuanceSite.EnrollManagementWS;
using EnrollmentIssuanceSite.IdentityManagementWS;
using EnrollmentIssuanceSite.Shared;
using System;
using System.Data;
using System.Text;
using System.Web.UI;
using System.Xml;

namespace EnrollmentIssuanceSite.UserControl
{
    public partial class Login : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.ExpiresAbsolute = DateTime.Now.AddDays(-1d);
            Response.Expires = -1500;
            Response.CacheControl = "no-cache";
            this.Session.Clear();
        }

        protected void btn_login_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
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
                //Enrollment.Enrollment webRequest = new Enrollment.Enrollment();
                IMService webRequest = new IMService();
                string resResult = webRequest.IdentityManagementRequest(requestXmlStr.ToString());

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
                    Common.SetCookie(this.Page, "loginName", xmlRoot.SelectSingleNode("PAYLOAD").FirstChild.InnerText);
                    Common.SetCookie(this.Page, "sessionKey", xmlRoot.SelectSingleNode("PAYLOAD").LastChild.InnerText);
                    Common.SetCookie(this.Page, "loginTime", System.DateTime.Now.ToShortDateString() + " " + System.DateTime.Now.ToShortTimeString());
                    GetLocationConfig();
                }

                else
                {
                    lblMsg.Text = (statusMsg == string.Empty) ? Common.FAILED : statusMsg.Replace(".", ". ");
                    lblMsg.Visible = true;
                }
                #endregion
            }
            catch (Exception ex)
            {
                lblMsg.Text = ex.Message;
                lblMsg.Visible = true;
            }
        }

        private string CalcPwdHash(string PlainPwd)
        {
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
        }

        private void GetEnrollGroup()
        {
            try
            {
                // GroupPermission 
                // 1st digit - Update Profile
                // 2nd digit - Data Entry
                // 3rd digit - Acceptance Clerk 

                string LevelPermission = "000";
                string Permission = string.Empty;
                string PaymentPermission = "0";
                string ReportPermission = "000";

                #region Request web service
                EMService webSvr = new EMService();
                RequestDataTypeGetPermission chklevel = new RequestDataTypeGetPermission();
                chklevel.ActionDescription = "Check Permission";
                chklevel.SessionKey = Common.GetCookie(this.Page, "sessionKey");
                #endregion

                #region Get Enrollment Permission

                #region Check Partial Enroll
                chklevel.PermissionCode = Common.GetValue("PartialEnrolCode");

                #endregion

                #region Response
                ResponseDataTypeGetPermission data = webSvr.GetPermission(chklevel);
                string rslt = data.Result;
                #endregion

                #region Analyze
                if (rslt == "True")
                    LevelPermission = "001";

                #endregion

                #region Check Data Entry
                chklevel.PermissionCode = Common.GetValue("CompleteEnrol");

                #endregion

                #region Response
                data = webSvr.GetPermission(chklevel);
                rslt = data.Result;
                #endregion

                #region Analyze
                if (rslt == "True")
                    LevelPermission = LevelPermission.Substring(0, 1) + "1" + LevelPermission.Substring(2, 1);

                #endregion

                #region Check Update Profile
                chklevel.PermissionCode = Common.GetValue("UpdateProfile");
                #endregion

                #region Response
                data = webSvr.GetPermission(chklevel);
                rslt = data.Result;
                #endregion

                #region Analyze
                if (rslt == "True")
                    LevelPermission = "1" + LevelPermission.Substring(1, 2);

                #endregion

                Common.SetCookie(this.Page, "GroupPermission", LevelPermission);
                #endregion

                #region Get Approval Permission

                #region 1st Level

                chklevel.PermissionCode = Common.GetValue("GetApproval01List");
                data = webSvr.GetPermission(chklevel);
                string rslt2 = data.Result;

                if (rslt2 == "True")
                    Permission = "1";
                else
                    Permission = "0";
                #endregion

                #region 2nd Level
                chklevel.PermissionCode = Common.GetValue("GetApproval02List");

                data = webSvr.GetPermission(chklevel);
                rslt2 = data.Result;

                if (rslt2 == "True")
                    Permission += "1";
                else
                    Permission += "0";
                #endregion

                #region View Profile
                chklevel.PermissionCode = Common.GetValue("GetViewProfile");

                data = webSvr.GetPermission(chklevel);
                rslt2 = data.Result;

                if (rslt2 == "True")
                    Permission += "1";
                else
                    Permission += "0";
                #endregion

                Common.SetCookie(this.Page, "Permission", Permission);
                #endregion

                #region Get Payment Issuance Permission

                #region Check Reject Issuance
                chklevel.PermissionCode = Common.GetValue("RejectIssuance");
                data = webSvr.GetPermission(chklevel);
                string rslt3 = data.Result;
                Common.SetCookie(this.Page, "IssuanceSV", rslt3);

                #endregion

                #region Check Report Permission

                #region Check Standard Report
                chklevel.PermissionCode = Common.GetValue("StandardReportViewer");
                #endregion

                #region Response
                data = webSvr.GetPermission(chklevel);
                string reportrslt = data.Result;

                if (reportrslt == "True")
                    ReportPermission = "1";
                else
                    ReportPermission = "0";

                #endregion

                #region Check Custom Report
                chklevel.PermissionCode = Common.GetValue("CustomReportViewer");
                #endregion

                #region Response
                data = webSvr.GetPermission(chklevel);
                reportrslt = data.Result;

                if (reportrslt == "True")
                    ReportPermission += "1";
                else
                    ReportPermission += "0";

                #endregion

                #region Check Report Builder
                chklevel.PermissionCode = Common.GetValue("ReportBuilder");
                #endregion

                #region Response
                data = webSvr.GetPermission(chklevel);
                reportrslt = data.Result;

                if (reportrslt == "True")
                    ReportPermission += "1";
                else
                    ReportPermission += "0";

                Common.SetCookie(this.Page, "ReportPermission", ReportPermission);

                #endregion

                #endregion

                #region Check Payment Supervisor
                chklevel.PermissionCode = Common.GetValue("PaymentOverwrite");

                #endregion

                #region Response
                data = webSvr.GetPermission(chklevel);
                string paymentsv = data.Result;
                Common.SetCookie(this.Page, "PaymentSV", paymentsv);

                #endregion

                #region Check Payment
                chklevel.PermissionCode = Common.GetValue("UpdatePayment");

                #endregion

                #region Response
                data = webSvr.GetPermission(chklevel);
                string payment = data.Result;
                if (payment == "True")
                    PaymentPermission = "1";
                else
                    PaymentPermission = "0";

                Common.SetCookie(this.Page, "PaymentPermission", PaymentPermission);

                #endregion

                #region Check Issuance
                chklevel.PermissionCode = Common.GetValue("Issuance");

                #endregion

                #region Response
                data = webSvr.GetPermission(chklevel);
                string iss = data.Result;
                if (iss == "True")
                    PaymentPermission = "1";
                else
                    PaymentPermission = "0";

                Common.SetCookie(this.Page, "IssuancePermission", PaymentPermission);


                #endregion           
                #endregion
            }
            catch (Exception ex)
            {
                lblMsg.Text = ex.Message;
                lblMsg.Visible = true;
            }
        }

        private void GetApprovalGroup()
        {
            string Permission = string.Empty;

            #region 1st Level
            EMService webSvr = new EMService();
            RequestDataTypeGetPermission chklevel = new RequestDataTypeGetPermission();
            chklevel.ActionDescription = "get approval level";
            chklevel.SessionKey = Common.GetCookie(this.Page, "sessionKey").ToString();

            chklevel.PermissionCode = Common.GetValue("GetApproval01List");

            ResponseDataTypeGetPermission data = webSvr.GetPermission(chklevel);
            string rslt = data.Result;

            if (rslt == "True")
                Permission = "1";
            else
                Permission = "0";
            #endregion

            #region 2nd Level
            chklevel.PermissionCode = Common.GetValue("GetApproval02List");

            data = webSvr.GetPermission(chklevel);
            rslt = data.Result;

            if (rslt == "True")
                Permission += "1";
            else
                Permission += "0";
            #endregion

            #region View Profile
            chklevel.PermissionCode = Common.GetValue("GetViewProfile");

            data = webSvr.GetPermission(chklevel);
            rslt = data.Result;

            if (rslt == "True")
                Permission += "1";
            else
                Permission += "0";
            #endregion

            Common.SetCookie(this.Page, "Permission", Permission);
        }

        private void GetPaymentIssuanceGroup()
        {
            string LevelPermission = "0";
            string ReportPermission = "000";

            #region Check Reject Supervisor
            EMService webSvr = new EMService();
            RequestDataTypeGetPermission req = new RequestDataTypeGetPermission();
            req.PermissionCode = Common.GetValue("RejectIssuance");
            req.ActionDescription = "Check Supervisor Permission";
            req.SessionKey = Common.GetCookie(this.Page, "sessionKey");
            #endregion

            #region Check Reject Issuance
            ResponseDataTypeGetPermission data = webSvr.GetPermission(req);
            string rslt = data.Result;
            Common.SetCookie(this.Page, "IssuanceSV", rslt);

            #endregion

            #region Check Report Permission

            #region Check Standard Report
            req.PermissionCode = Common.GetValue("StandardReportViewer");
            #endregion

            #region Response
            data = webSvr.GetPermission(req);
            string reportrslt = data.Result;

            if (reportrslt == "True")
                ReportPermission = "1";
            else
                ReportPermission = "0";

            #endregion

            #region Check Custom Report
            req.PermissionCode = Common.GetValue("CustomReportViewer");
            #endregion

            #region Response
            data = webSvr.GetPermission(req);
            reportrslt = data.Result;

            if (reportrslt == "True")
                ReportPermission += "1";
            else
                ReportPermission += "0";

            #endregion 

            #region Check Report Builder
            req.PermissionCode = Common.GetValue("ReportBuilder");
            #endregion

            #region Response
            data = webSvr.GetPermission(req);
            reportrslt = data.Result;

            if (reportrslt == "True")
                ReportPermission += "1";
            else
                ReportPermission += "0";

            Common.SetCookie(this.Page, "ReportPermission", ReportPermission);

            #endregion 

            #endregion

            #region Check Payment Supervisor
            req.PermissionCode = Common.GetValue("PaymentOverwrite");

            #endregion

            #region Response
            data = webSvr.GetPermission(req);
            string paymentsv = data.Result;
            Common.SetCookie(this.Page, "PaymentSV", paymentsv);

            #endregion                      

            #region Check Payment 
            req.PermissionCode = Common.GetValue("UpdatePayment");

            #endregion

            #region Response
            data = webSvr.GetPermission(req);
            string payment = data.Result;
            if (payment == "True")
                LevelPermission = "1";
            else
                LevelPermission = "0";

            Common.SetCookie(this.Page, "PaymentPermission", LevelPermission);

            #endregion           

            #region Check Issuance
            req.PermissionCode = Common.GetValue("Issuance");

            #endregion

            #region Response
            data = webSvr.GetPermission(req);
            string iss = data.Result;
            if (iss == "True")
                LevelPermission = "1";
            else
                LevelPermission = "0";

            Common.SetCookie(this.Page, "IssuancePermission", LevelPermission);


            #endregion           
        }

        private void GetLocationConfig()
        {
            #region Get Location Permission

            try
            {
                string ConfigLocation = string.Empty;

                #region Check Payment Permission

                DALMService webSvr = new DALMService();
                RequestDataTypeSelectConfigLocation chklevel = new RequestDataTypeSelectConfigLocation();
                chklevel.ActionDescription = "Get Config Location";
                chklevel.SessionKey = Common.GetCookie(this.Page, "sessionKey");
                chklevel.PermissionCode = "11.127.2";

                string[] clientpcinfo = System.Net.Dns.GetHostEntry(Request.ServerVariables["remote_addr"]).HostName.Split(new Char[] { '.' });

                chklevel.LocationName = clientpcinfo[0];// Request.UserHostName;// Request.UserHostAddress // txtCompName.Value;

                #endregion

                #region Response

                ResponseDataTypeSelectAll data = webSvr.SelectConfigLocation(chklevel);
                string statucode = data.StatusCode;
                string statusmsg = data.StatusMessage;

                if (statucode == "0")
                {
                    if (data.ResultList.Tables[0].Rows.Count > 0)
                    {
                        #region Check for location configuration

                        DataSet ds = (DataSet)data.ResultList;
                        bool enrol = (bool)ds.Tables[0].Rows[0]["IsEnrollment"];
                        bool approval = (bool)ds.Tables[0].Rows[0]["IsApproval"];
                        bool payment = (bool)ds.Tables[0].Rows[0]["IsPayment"];
                        bool issuance = (bool)ds.Tables[0].Rows[0]["IsIssuance"];

                        #region Check Enrol

                        if (enrol)
                        {
                            ConfigLocation = "1";
                        }
                        else
                        {
                            ConfigLocation = "0";
                        }

                        #endregion

                        #region Check Payment

                        if (payment)
                        {
                            ConfigLocation += "1";
                        }
                        else
                        {
                            ConfigLocation += "0";
                        }

                        #endregion

                        #region Check Approval

                        if (approval)
                        {
                            ConfigLocation += "1";
                        }
                        else
                        {
                            ConfigLocation += "0";
                        }

                        #endregion

                        #region Check issuance

                        if (issuance)
                        {
                            ConfigLocation += "1";
                        }
                        else
                        {
                            ConfigLocation += "0";
                        }

                        #endregion

                        if (ConfigLocation == "0000")
                        {
                            Response.Redirect("ErrorPage.aspx?ms=7");
                        }
                        else
                        {
                            Common.SetCookie(this.Page, "ConfigLocation", ConfigLocation);
                            GetEnrollGroup();
                            //GetApprovalGroup();
                            //GetPaymentIssuanceGroup();                            
                            Common.SetCookie(this.Page, "PCName", txtCompName.Value.Trim());
                            Response.Redirect("Logon.aspx");
                        }

                        #endregion
                    }
                    else
                    {
                        Response.Redirect("ErrorPage.aspx?ms=8");
                    }
                }
                else
                {
                    throw new Exception(statusmsg);
                }

                #endregion
            }
            catch (Exception ex)
            {
                lblMsg.Text = ex.Message;
                lblMsg.Visible = true;
                Common.WriteLog(@Server.MapPath("") + Common.GetValue("logPath"), "GetLocationConfig(): - " + ex.Message);
            }

            #endregion
        }
    }
}
