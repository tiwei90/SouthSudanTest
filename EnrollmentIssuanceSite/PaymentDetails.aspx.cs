using EnrollmentIssuanceSite.DALMWS;
using EnrollmentIssuanceSite.EnrollManagementWS;
using EnrollmentIssuanceSite.IdentityManagementWS;
using EnrollmentIssuanceSite.Shared;
using System;
using System.Data;
using System.Text;
using System.Web.UI.WebControls;
using System.Xml;

namespace EnrollmentIssuanceSite
{
    public partial class PaymentDetails : System.Web.UI.Page
    {
        private static string PaymentType;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                txtCompName.Value = Request.QueryString["PC"];
                PaymentType = Request.QueryString["PType"];
                APPID.Value = Request.QueryString["done"];
                GetPaymentMethod();
                GetApplicantDetails(APPID.Value);
            }
        }

        private void GetPaymentMethod()
        {
            #region ***
            try
            {
                #region calling web service
                DALMService look = new DALMService();
                RequestDataTypeSelectPaymentMethod reqData = new RequestDataTypeSelectPaymentMethod();

                reqData.ActionDescription = "Get Payment Method";
                reqData.PermissionCode = Common.GetValue("GetPaymentMethod");
                reqData.SessionKey = Common.GetCookie(this.Page, "sessionKey").ToString();
                #endregion

                #region response the request
                ResponseDataTypeSelectPaymentMethod responseData = look.SelectPaymentMethodList(reqData);

                string statusCode = responseData.StatusCode;
                string statusMsg = responseData.StatusMessage;
                #endregion

                #region analize result

                if (statusCode == "0")
                {
                    DataSet Ds = (DataSet)responseData.ResultList;
                    PAYMENTMETHOD.DataSource = Ds.Tables[0];
                    PAYMENTMETHOD.DataValueField = "PaymentMethod";
                    PAYMENTMETHOD.DataTextField = "Description";
                    PAYMENTMETHOD.DataBind();
                    PAYMENTMETHOD.Items.Insert(0, new ListItem("-SELECT-", ""));
                }
                else
                {
                    lblError.Visible = true;
                    lblError.Text = statusMsg;
                }
                #endregion

            }
            catch (Exception ex)
            {
                lblError.Visible = true;
                lblError.Text = ex.Message;
                Common.WriteLog(@Server.MapPath("") + Common.GetValue("logPath"), "Search Payment Method(GetPaymentMethod) - " + ex.Message);
            }


            #endregion

        }
        private void GetFee(string entry)
        {
            #region ***
            try
            {
                #region calling web service
                DALMService look = new DALMService();
                RequestDataTypeSelectFees reqData = new RequestDataTypeSelectFees();

                reqData.ActionDescription = "Get Config Fee";
                reqData.PermissionCode = Common.GetValue("GetConfigFee");
                reqData.SessionKey = Common.GetCookie(this.Page, "sessionKey").ToString();
                reqData.EntryType = entry.Substring(0, 1);

                #endregion

                #region response the request
                ResponseDataTypeSelectFees responseData = look.SelectFee(reqData);

                string statusCode = responseData.StatusCode;
                string statusMsg = responseData.StatusMessage;
                #endregion

                #region analize result

                if (statusCode == "0")
                {
                    txtAmount.Text = responseData.Fee;
                }
                else
                {
                    lblError.Visible = true;
                    lblError.Text = statusMsg;
                }
                #endregion

            }
            catch (Exception ex)
            {
                lblError.Visible = true;
                lblError.Text = ex.Message;
                Common.WriteLog(@Server.MapPath("") + Common.GetValue("logPath"), "Retrieve Processing Fee (GetProcFee) - " + ex.Message);

            }


            #endregion

        }
        private void GetApplicantDetails(string formno)
        {
            #region request Applicant Record by AppID
            try
            {
                #region Request
                EMService enrol = new EMService();
                RequestDataTypeGetDetails reqData = new RequestDataTypeGetDetails();

                reqData.ActionDescription = "Get Details";
                reqData.SessionKey = Common.GetCookie(this.Page, "sessionKey").ToString();
                reqData.EnrolLocationName = txtCompName.Value;
                reqData.SearchType = "1";
                reqData.PermissionCode = Common.GetValue("GetDetails");
                reqData.ApplicationID = formno;
                reqData.DocNo = string.Empty;
                reqData.PassportNo = string.Empty;
                reqData.PassportCOI = string.Empty;

                ResponseDataTypeGetDetails responseData = enrol.GetDetails(reqData);


                string statusCode = responseData.StatusCode;
                string statusMsg = responseData.StatusMessage;
                #endregion

                #region display result
                if (statusCode == "0")
                {
                    ENTRY.Text = responseData.EntryType;
                    DOCTYPE.Text = responseData.DocType;

                    #region MAIN PROFILE
                    SURNAME.Text = responseData.Surname;
                    FIRSTNAME.Text = responseData.FirstName;
                    MIDDLENAME.Text = responseData.MiddleName;
                    SEX.Text = (responseData.Sex == "F") ? "Female".ToUpper() : "Male".ToUpper();
                    BIRTHCOUNTRY.Text = responseData.BirthCountry;
                    DOCTYPE.Text = responseData.DocType;
                    FORMNO.Text = responseData.ApplicationID;
                    NATIONALITY.Text = responseData.Nationality;

                    DOB.Text = Convert.ToDateTime(responseData.BirthDate).ToString("dd/MM/yyyy");
                    #endregion

                    APPREASON.Text = responseData.AppReason;

                    if (responseData.AppReason.Substring(0, 1) == Common.GetValue("ExternalSponsored") || responseData.AppReason.Substring(0, 1) == Common.GetValue("ExternalUnSponsored"))
                        txtAmount.Text = Common.GetValue("ExternalFee");
                    else
                        GetFee(responseData.EntryType);

                }
                else
                {
                    lblError.Text = Common.NORECORD;
                    lblError.Visible = true;
                }
                #endregion
            }
            catch (Exception ex)
            {
                lblError.Visible = true;
                lblError.Text = ex.Message;
                Common.WriteLog(@Server.MapPath("") + Common.GetValue("logPath"), "Retrieve Applicant Details (GetApplicationDetails) - " + ex.Message);
            }

            #endregion
        }

        protected void PAYMENTMETHOD_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region ***
            if (PAYMENTMETHOD.SelectedValue == "1" || PAYMENTMETHOD.SelectedValue == "")
            {

                trOtherPayMethod.Visible = false;
                trCreditCard.Visible = false;
                RFVCardNo.Enabled = false;
                CARDNO.Text = string.Empty;
                RFVOtherMethod.Enabled = false;
                OTHERMETHOD.Text = string.Empty;
            }
            else if (PAYMENTMETHOD.SelectedValue == "99")
            {
                trOtherPayMethod.Visible = true;
                trCreditCard.Visible = false;
                RFVCardNo.Enabled = false;
                CARDNO.Text = string.Empty;
                RFVOtherMethod.Enabled = true;
                OTHERMETHOD.Text = string.Empty;
            }
            else
            {
                RFVOtherMethod.Enabled = false;
                OTHERMETHOD.Text = string.Empty;
                trOtherPayMethod.Visible = false;
                trCreditCard.Visible = true;
                string txt = PAYMENTMETHOD.SelectedItem.ToString();
                string firstChar = txt.Substring(0, 1);
                string remainder = txt.Substring(1, txt.Length - 1);
                lblCardNo.Text = firstChar.ToUpper() + remainder.ToLower() + " No";
                RFVCardNo.ErrorMessage = lblCardNo.Text.Trim() + " is a mandatory field";
                RFVCardNo.Enabled = true;
            }
            #endregion 
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            #region ***

            try
            {
                #region Request Update Payment
                EMService WebSvr = new EMService();
                RequestDataTypeUpdatePayment UdtPyt = new RequestDataTypeUpdatePayment();
                UdtPyt.PermissionCode = Common.GetValue("UpdatePayment");
                UdtPyt.ActionDescription = "Update Payment Details";
                UdtPyt.SessionKey = Common.GetCookie(this.Page, "sessionKey").ToString();
                UdtPyt.ApplicationID = APPID.Value;
                UdtPyt.EnrolLocationName = txtCompName.Value;
                UdtPyt.PaymentMethod = Convert.ToInt32(PAYMENTMETHOD.SelectedValue);
                UdtPyt.PaymentAmt = Convert.ToInt32(txtAmount.Text);
                UdtPyt.ReceiptNo = txtReceiptNo.Text;
                UdtPyt.CardNo = CARDNO.Text;
                UdtPyt.OtherPaymentMethod = OTHERMETHOD.Text;
                UdtPyt.AmountChangedBy = txtreviseID.Text.ToUpper();
                UdtPyt.PaymentRemark = txtRemarks.Text.ToUpper();
                UdtPyt.FeeType = ENTRY.Text.Substring(0, 1);

                #endregion

                #region Response Update Payment
                ResponseDataTypeUpdatePayment ResUdtPyt = WebSvr.UpdatePayment(UdtPyt);
                string StatusCode = ResUdtPyt.StatusCode;
                string StatusMsg = ResUdtPyt.StatusMessage;
                #endregion

                #region payment process

                if (StatusCode == "0")
                {
                    lblResult.Text = "Payment updated successfully!";
                    lblResult.Visible = true;
                    btnSave.Visible = false;
                    btnClearAll.Visible = false;
                    lblError.Visible = false;

                    txtReceiptNo.Enabled = false;
                    PAYMENTMETHOD.Enabled = false;
                    CARDNO.Enabled = false;
                    OTHERMETHOD.Enabled = false;
                    btnChange.Enabled = false;
                    if (APPREASON.Text.Substring(0, 1) == Common.GetValue("ExternalSponsored"))
                        CheckApprovalPermission();
                    else
                        CheckPreApprovalPermission();

                }
                else if (StatusCode != "0")
                {
                    lblError.Text = StatusMsg;
                    lblError.Visible = true;
                    lblResult.Visible = false;
                }
                else
                {
                    throw new Exception(StatusMsg);
                }
                #endregion
            }
            catch (Exception Ex)
            {

                lblError.Text = Ex.Message;
                lblError.Visible = true;
                Common.WriteLog(@Server.MapPath("") + Common.GetValue("logPath"), "Submit Payment (btnSave) - " + Ex.Message);
            }
            #endregion

        }
        protected void btnClearAll_Click(object sender, EventArgs e)
        {
            txtReceiptNo.Text = string.Empty;
            CARDNO.Text = string.Empty;

            OTHERMETHOD.Text = string.Empty;

            PAYMENTMETHOD.SelectedIndex = -1;

            trOtherPayMethod.Visible = false;
            trCreditCard.Visible = false;

        }
        protected void btnChange_Click(object sender, EventArgs e)
        {
            #region Change amount
            if (Convert.ToBoolean(Common.GetCookie(this.Page, "PaymentSV").ToString()) == true)
            {
                PanelRevised.Visible = true;
                txtsuperid.Text = Common.GetCookie(this.Page, "loginName").ToString();
            }
            else
            {
                PanelLogin.Visible = true;
                txtsuperid.Text = string.Empty;
            }
            RFVReceiptNo.Enabled = false;
            lblLoginError.Text = string.Empty;
            RFVPayMethod.Enabled = false;
            btnSave.Enabled = false;
            btnloginsuper.Focus();
            RFVCardNo.Enabled = false;
            RFVOtherMethod.Enabled = false;
            btnClearAll.Enabled = false;
            #endregion
        }
        protected void btnloginsuper_Click(object sender, EventArgs e)
        {
            #region Login Request Xml
            StringBuilder requestXmlStr = new StringBuilder();

            requestXmlStr.Append("<?xml version='1.0' encoding='utf-8' ?>");
            requestXmlStr.Append("<VISWEBREQUEST>");
            requestXmlStr.Append("<PERMISSIONCODE>13.63.9</PERMISSIONCODE>");
            requestXmlStr.Append("<ACTIONDESCRIPTION>Supervisor login-change payment amount</ACTIONDESCRIPTION>");
            requestXmlStr.Append("<TRANSACTIONDATETIME>");
            requestXmlStr.Append(System.DateTime.Now.ToString("yyyyMMddHHmmssfff"));
            requestXmlStr.Append("</TRANSACTIONDATETIME>");
            requestXmlStr.Append("<PAYLOAD>");
            //Login name
            requestXmlStr.Append("<LOGINNAME>");
            requestXmlStr.Append(txtsuperid.Text);
            requestXmlStr.Append("</LOGINNAME>");
            //Password
            requestXmlStr.Append("<PASSWORDHASH>");
            requestXmlStr.Append(CalcPwdHash(txtlogin.Text));
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

            string loginName = xmlRoot.SelectSingleNode("PAYLOAD").FirstChild.InnerText;
            string sessionKey = xmlRoot.SelectSingleNode("PAYLOAD").LastChild.InnerText;
            Common.SetCookie(this.Page, "supername", txtsuperid.Text);
            txtreviseID.Text = Common.GetCookie(this.Page, "supername").ToString();

            #endregion

            #region Request
            EMService webSvr = new EMService();
            RequestDataTypeGetPermission chgpmt = new RequestDataTypeGetPermission();
            chgpmt.PermissionCode = Common.GetValue("PaymentOverwrite");
            chgpmt.ActionDescription = "change payment amount";
            chgpmt.SessionKey = sessionKey.ToString();
            #endregion

            #region Response
            ResponseDataTypeGetPermission data = webSvr.GetPermission(chgpmt);
            string rslt = data.Result;
            #endregion

            #region change process
            if (rslt == "True")
            {
                PanelLogin.Visible = false;
                PanelRevised.Visible = true;
                txtrevisedremarks.Text = string.Empty;
                txtrevisedamount.Text = string.Empty;
                updaterevise.Focus();
            }
            else
            {

                lblLoginError.Text = "Unauthorised user. <br/> &nbsp;Please enter a valid User Name and &nbsp;Password.";
                lblLoginError.Visible = true;
            }
            #endregion
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            #region cancel
            btnClearAll.Enabled = true;
            PanelLogin.Visible = false;
            txtsuperid.Text = string.Empty;
            RFVPayMethod.Enabled = true;
            RFVReceiptNo.Enabled = true;
            btnChange.Enabled = true;

            btnSave.Enabled = true;
            if (PAYMENTMETHOD.SelectedValue != "1" || PAYMENTMETHOD.SelectedValue != "" ||
                PAYMENTMETHOD.SelectedValue != "99")
                RFVCardNo.Enabled = true;

            if (PAYMENTMETHOD.SelectedValue == "99")
                RFVOtherMethod.Enabled = true;

            #endregion
        }
        protected void btncacel2_Click(object sender, EventArgs e)
        {
            #region cancel
            btnClearAll.Enabled = true;
            PanelRevised.Visible = false;
            txtrevisedamount.Text = string.Empty;
            txtrevisedremarks.Text = string.Empty;
            txtreviseID.Text = string.Empty;
            btnSave.Enabled = true;
            btnChange.Enabled = true;
            RFVPayMethod.Enabled = true;
            RFVReceiptNo.Enabled = true;
            if (PAYMENTMETHOD.SelectedValue != "1" || PAYMENTMETHOD.SelectedValue != "" ||
                PAYMENTMETHOD.SelectedValue != "99")
                RFVCardNo.Enabled = true;

            if (PAYMENTMETHOD.SelectedValue == "99")
                RFVOtherMethod.Enabled = true;
            #endregion
        }
        protected void updaterevise_Click(object sender, EventArgs e)
        {
            #region ***
            btnClearAll.Enabled = true;
            txtRemarks.Text = txtrevisedremarks.Text;
            txtAmount.Text = txtrevisedamount.Text;
            PanelRevised.Visible = false;
            RFVReceiptNo.Enabled = true;
            RFVPayMethod.Enabled = true;
            btnSave.Enabled = true;
            trRemarks.Visible = true;
            if (PAYMENTMETHOD.SelectedValue != "1" || PAYMENTMETHOD.SelectedValue != "" ||
                PAYMENTMETHOD.SelectedValue != "99")
                RFVCardNo.Enabled = true;

            if (PAYMENTMETHOD.SelectedValue == "99")
                RFVOtherMethod.Enabled = true;

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
        #region Set Approval Button

        private void CheckPreApprovalPermission()
        {
            if (Common.GetCookie(this.Page, "ConfigLocation").Substring(2, 1) == "1" && Common.GetCookie(this.Page, "Permission").Substring(0, 1) == "1")
                btn_PreApproval.Visible = true;
            else
                btn_PreApproval.Visible = false;
        }
        private void CheckApprovalPermission()
        {
            if (Common.GetCookie(this.Page, "ConfigLocation").Substring(2, 1) == "1" && Common.GetCookie(this.Page, "Permission").Substring(1, 1) == "1")
                btn_Approval.Visible = true;
            else
                btn_Approval.Visible = false;
        }
        protected void btn_PreApproval_Click(object sender, EventArgs e)
        {
            //common.SetCookie(this.Page, "level", "1");
            Response.Redirect("Approval.aspx?done=" + FORMNO.Text + "&arrow=31&sm=31&level=1");
        }
        protected void btn_Approval_Click(object sender, EventArgs e)
        {
            Response.Redirect("Approval.aspx?done=" + FORMNO.Text + "&arrow=32&sm=31&level=2");
        }
        #endregion
    }
}
