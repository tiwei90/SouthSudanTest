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
    public partial class Issuancedetails : System.Web.UI.Page
    {
        private String txtPhotoH = string.Empty;


        protected void Page_Load(object sender, EventArgs e)
        {

            #region maintain data in control after postback
            this.lblDocNo2.Text = Request[this.lblDocNo2.UniqueID];
            this.lblDOB2.Text = Request[this.lblDOB2.UniqueID];
            this.lblDocType2.Text = Request[this.lblDocType2.UniqueID];
            this.lblDOE2.Text = Request[this.lblDOE2.UniqueID];
            this.lblFName2.Text = Request[this.lblFName2.UniqueID];
            this.lblNationality2.Text = Request[this.lblNationality2.UniqueID];
            this.lblPersonalNo2.Text = Request[this.lblPersonalNo2.UniqueID];
            this.lblSex2.Text = Request[this.lblSex2.UniqueID];
            this.lblSurname2.Text = Request[this.lblSurname2.UniqueID];
            #endregion


            if (!Page.IsPostBack)
            {
                APPID.Value = Request.QueryString["done"];
                txtCompName.Value = Request.QueryString["PC"];
                GetDetails(APPID.Value);
                GetRejectReason();
                //GetActiveDoc();

            }

        }
        private void GetDetails(string formNo)
        {
            #region request Applicant Record by AppID 
            try
            {
                EMService enrol = new EMService();
                RequestDataTypeGetDetails reqData = new RequestDataTypeGetDetails();

                reqData.ActionDescription = "Get Details";
                reqData.SessionKey = Common.GetCookie(this.Page, "sessionKey");
                reqData.EnrolLocationName = txtCompName.Value.Trim();
                reqData.SearchType = "1";
                reqData.PermissionCode = Common.GetValue("GetDetailsPermissionCode");
                reqData.ApplicationID = formNo;
                reqData.DocNo = string.Empty;
                reqData.PassportCOI = string.Empty;
                reqData.PassportNo = string.Empty;

                ResponseDataTypeGetDetails responseData = enrol.GetDetails(reqData);

                string statusCode = responseData.StatusCode;
                string statusMsg = responseData.StatusMessage;

                #region display result
                if (statusCode == "0")
                {
                    #region MAIN PROFILE
                    lblDocNo.Text = responseData.DocNo;
                    lblDOE.Text = Convert.ToDateTime(responseData.DocExpiryDate).ToString("dd/MM/yyyy");
                    lblPersonalNo.Text = responseData.PassportNo;
                    lblFormNo.Text = responseData.ApplicationID;
                    lblDocType.Text = responseData.ApprovedDocType;
                    lblSurname.Text = responseData.Surname;
                    lblDOB.Text = Convert.ToDateTime(responseData.BirthDate).ToString("dd/MM/yyyy");
                    lblSex.Text = responseData.Sex == "M" ? "MALE" : "FEMALE";
                    lblNationality.Text = responseData.Nationality.Substring(0, 3);
                    lblFName.Text = responseData.FirstName + " " + responseData.MiddleName;
                    IDPerson.Value = responseData.IDPerson.ToString();
                    #endregion

                    #region FACEIMAGE
                    if (responseData.FaceImage != null)
                    {
                        byte[] binData = responseData.FaceImage;
                        string msg = string.Empty;
                        bool HasPhoto = Common.DecodeBytetoImage(binData, out msg);
                        if (HasPhoto)
                        {
                            string outputFile = @Server.MapPath("") + Common.GetValue("ImgServerPath") + msg;
                            imgPhoto.ImageUrl = Common.GetImgUrl(binData, outputFile, msg);
                        }
                        else
                        {
                            imgPhoto.ImageUrl = Common.ImgDefaultUrl;
                        }
                    }
                    #endregion



                }
                else
                {
                    lblError.Text = statusMsg;
                    lblError.Visible = true;
                }
                #endregion
            }
            catch (Exception ex)
            {
                lblError.Visible = true;
                lblError.Text = ex.Message;
            }

            #endregion
        }
        private void CheckRecordToObsolete()
        {
            #region request by IDPerson
            /*try
        {
            enrollment.VISService enrol = new enrollment.VISService();
            enrollment.re reqData = new enrollment.RequestDataTypeGetDetails();

            reqData.ActionDescription = "Get Details";
            reqData.SessionKey = common.GetCookie(this.Page, "sessionKey");
            reqData.EnrolLocationName = txtCompName.Value.Trim();
            reqData.SearchType = "1";
            reqData.PermissionCode = common.GetValue("GetDetailsPermissionCode");
            reqData.ApplicationID = formNo;
            reqData.DocNo = string.Empty;
            reqData.PassportCOI = string.Empty;
            reqData.PassportNo = string.Empty;

            enrollment.ResponseDataTypeGetDetails responseData = enrol.GetDetails(reqData);

            string statusCode = responseData.StatusCode;
            string statusMsg = responseData.StatusMessage;
        }
        catch (Exception ex)
        {
            lblError.Visible = true;
            lblError.Text = ex.Message;
        }*/
            #endregion

        }
        protected void btnIssue_Click(object sender, EventArgs e)
        {
            #region ***
            Issue_Func();
            #endregion
        }
        private void Issue_Func()
        {
            #region ***
            try
            {

                #region Call the webservices
                EMService issue = new EMService();
                RequestDataTypeIssuance iss = new RequestDataTypeIssuance();
                iss.PermissionCode = Common.GetValue("Issuance");
                iss.ActionDescription = "Issue Visa";
                iss.SessionKey = Common.GetCookie(this.Page, "sessionKey");
                iss.ApplicationID = APPID.Value;
                iss.EnrolLocationName = txtCompName.Value.Trim();
                iss.StageCode = "EM6000";
                iss.RejectedBy = string.Empty;
                iss.RejectReason = string.Empty;
                iss.Remark = string.Empty;

                ResponseDataTypeIssuance getdataissue = issue.Issue(iss);
                string StatusCode = getdataissue.StatusCode;
                string StatusMsg = getdataissue.StatusMessage;

                #endregion

                #region Issuance Process
                if (StatusCode == "0")
                {
                    lblResult.Visible = true;
                    lblResult.Text = "Visa issuance completed successfully. Please give the passport to the applicant!";
                    trButton.Visible = false;
                }
                else
                    throw new Exception(StatusMsg);
                #endregion
            }
            catch (Exception ex)
            {
                lblResult.Visible = false;
                lblError.Visible = true;
                lblError.Text = ex.Message;
            }
            #endregion
        }
        protected void IssueFail_Click(object sender, System.EventArgs e)
        {
            lblLoginError.Text = string.Empty;
            tbButtonPassport.Visible = false;
            tbReject.Visible = true;
            if (Common.GetCookie(this.Page, "IssuanceSV") == "False")
            {
                PanelReject.Visible = false;
                trLogin.Visible = true;
            }
            else
            {
                trLogin.Visible = false;
                PanelReject.Visible = true;
                DDLRejectReason.Focus();
            }


        }

        protected void ClearContent()
        {
            #region ***
            #region Record 1
            lblDocType.Text = string.Empty;
            lblEnrolLoc.Text = string.Empty;
            lblDocNo.Text = string.Empty;
            lblSurname.Text = string.Empty;
            lblFName.Text = string.Empty;
            lblSex.Text = string.Empty;
            lblDOB.Text = string.Empty;
            lblNationality.Text = string.Empty;
            lblDOE.Text = string.Empty;
            lblPersonalNo.Text = string.Empty;

            imgPhoto.ImageUrl = Common.ImgDefaultUrl;
            #endregion

            #region Record 2
            lblDocType2.Text = string.Empty;
            lblDocNo2.Text = string.Empty;
            lblSurname2.Text = string.Empty;
            lblFName2.Text = string.Empty;
            lblSex2.Text = string.Empty;
            lblDOB2.Text = string.Empty;
            lblNationality2.Text = string.Empty;
            lblDOE2.Text = string.Empty;
            lblPersonalNo.Text = string.Empty;

            #endregion

            btnIssue.Enabled = false;
            lblError.Visible = false;
            lblResult.Visible = false;
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
        protected void btn3rdIssue_Click(object sender, EventArgs e)
        {
            #region ***         
            ShowThirdPartyInfo();
            tbButtonPassport.Visible = false;

            #endregion
        }
        private void ShowThirdPartyInfo()
        {
            #region ***
            tbThirdParty.Visible = true;
            btnIssue.Enabled = false;
            btn3rdIssue.Enabled = false;
            btnRead.Disabled = true;

            #endregion
        }
        protected void btnCancelThirdIssue_Click(object sender, EventArgs e)
        {
            #region ***
            tbThirdParty.Visible = false;
            THIRDNAME.Text = string.Empty;
            THIRDTELNO.Text = string.Empty;
            THIRDREMARK.Text = string.Empty;
            THIRDDOCNO.Text = string.Empty;
            btn3rdIssue.Enabled = true;
            btnRead.Disabled = false;
            IssueFail.Enabled = true;
            btnIssue.Enabled = true;
            tbButtonPassport.Visible = true;
            #endregion
        }
        protected void btnThirdIssue_Click(object sender, EventArgs e)
        {
            #region ***
            try
            {

                #region Call the webservices
                EMService issue = new EMService();
                RequestDataTypeThirdPartyIssuance iss = new RequestDataTypeThirdPartyIssuance();
                iss.PermissionCode = Common.GetValue("ThirdPartyIssuance");
                iss.ActionDescription = "Third party issuance";
                iss.SessionKey = Common.GetCookie(this.Page, "sessionKey");
                iss.ApplicationID = APPID.Value;
                iss.EnrolLocationName = txtCompName.Value.Trim();
                iss.StageCode = "EM6000";
                iss.TP_Name = THIRDNAME.Text.ToUpper();
                iss.TP_Phone = THIRDTELNO.Text;
                iss.TP_Remarks = THIRDREMARK.Text.ToUpper();
                iss.TP_DocNo = THIRDDOCNO.Text.ToUpper();

                #endregion

                #region responce
                ResponseDataTypeThirdPartyIssuance getdataissue = issue.ThirdPartyIssue(iss);
                string StatusCode = getdataissue.StatusCode;
                string StatusMsg = getdataissue.StatusMessage;

                #endregion

                #region 3rd issuance process
                if (StatusCode == "0")
                {
                    lblResult.Visible = true;
                    lblResult.Text = "Third party issuance completed successfully. Please hand over the passport!";
                    lblError.Visible = false;
                    tbThirdParty.Visible = false;
                    tbButtonPassport.Visible = true;
                    trButton.Visible = false;

                }
                else
                    throw new Exception(StatusMsg);


                #endregion
            }
            catch (Exception ex)
            {
                tbButtonPassport.Visible = true;
                trButton.Visible = false;
                lblError.Text = ex.Message;
                lblError.Visible = true;
                lblResult.Visible = false;
                Common.WriteLog(@Server.MapPath("") + Common.GetValue("logPath"), "ThirdPartyIssue: " + ex.Message);
            }
            #endregion
        }

        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("QueryIssuance.aspx?arrow=" + Request.QueryString["arrow"] + "&sm=" + Request.QueryString["sm"] + "&PC=" + txtCompName.Value);
        }
        protected void btnloginsuper_Click(object sender, EventArgs e)
        {
            if (txtSuperID.Text == Common.GetCookie(this.Page, "loginName"))
            {
                lblLoginError.Visible = true;
                lblLoginError.Text = "Supervisor ID must not be the same with current login name";
                return;
            }
            SupervisorLogin();
        }
        private void SupervisorLogin()
        {
            #region ***
            try
            {

                #region Login Request Xml
                StringBuilder requestXmlStr = new StringBuilder();

                requestXmlStr.Append("<?xml version='1.0' encoding='utf-8' ?>");
                requestXmlStr.Append("<VISWEBREQUEST>");
                requestXmlStr.Append("<PERMISSIONCODE>13.63.9</PERMISSIONCODE>");
                requestXmlStr.Append("<ACTIONDESCRIPTION>User Login</ACTIONDESCRIPTION>");
                requestXmlStr.Append("<TRANSACTIONDATETIME>");
                requestXmlStr.Append(System.DateTime.Now.ToString("yyyyMMddHHmmssfff"));
                requestXmlStr.Append("</TRANSACTIONDATETIME>");
                requestXmlStr.Append("<PAYLOAD>");
                //Login name
                requestXmlStr.Append("<LOGINNAME>");
                requestXmlStr.Append(txtSuperID.Text);
                requestXmlStr.Append("</LOGINNAME>");
                //Password
                requestXmlStr.Append("<PASSWORDHASH>");
                requestXmlStr.Append(CalcPwdHash(txtSuperPassword.Text));
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
                // Write the XML document to the stream
                doc.LoadXml(resResult);

                #endregion

                #region Analyse result
                XmlNode xmlRoot = doc.DocumentElement;

                string statusCode = xmlRoot.SelectSingleNode("STATUS").FirstChild.InnerText;
                string statusMsg = xmlRoot.SelectSingleNode("STATUS").LastChild.InnerText;
                string sessionKey = xmlRoot.SelectSingleNode("PAYLOAD").LastChild.InnerText;

                #endregion

                if (statusCode == "0")
                {
                    string PermissionFlag = SupervisorPermission(sessionKey);
                    if (PermissionFlag == "False")
                    {
                        lblLoginError.Text = "Unauthorised user!";
                        lblLoginError.Visible = true;
                        txtSuperID.Focus();
                    }
                    else
                    {
                        trLogin.Visible = false;
                        PanelReject.Visible = true;
                        DDLRejectReason.Focus();
                    }
                }
                else
                    throw new Exception(statusMsg);
            }
            catch (Exception ex)
            {
                lblLoginError.Text = ex.Message;
                lblLoginError.Visible = true;
            }
            #endregion
        }
        private string SupervisorPermission(string SessionKey)
        {
            #region ***
            #region Request
            EMService webSvr = new EMService();
            RequestDataTypeGetPermission req = new RequestDataTypeGetPermission();
            req.PermissionCode = Common.GetValue("RejectIssuance");
            req.ActionDescription = "Reject Issuance";
            req.SessionKey = SessionKey; ;
            #endregion

            #region Response
            ResponseDataTypeGetPermission data = webSvr.GetPermission(req);
            string rslt = data.Result;
            #endregion

            return rslt;
            #endregion

        }
        private void GetRejectReason()
        {
            #region ***
            try
            {

                DALMService req = new DALMService();
                RequestDataTypeSelectIssRejectReason reqData = new RequestDataTypeSelectIssRejectReason();

                reqData.ActionDescription = "Get Reject Reason";
                reqData.SessionKey = Common.GetCookie(this.Page, "sessionKey");
                reqData.PermissionCode = "11.120.7";

                ResponseDataTypeSelectIssRejectReason responseData = req.SelectIssRejectReason(reqData);

                string statusCode = responseData.StatusCode;
                string statusMsg = responseData.StatusMessage;


                #region display result
                if (statusCode == "0")
                {
                    DataSet Ds = (DataSet)responseData.ResultList;
                    DDLRejectReason.DataSource = Ds.Tables[0];
                    DDLRejectReason.DataValueField = "RejectCode";
                    DDLRejectReason.DataTextField = "Description";
                    DDLRejectReason.DataBind();
                    DDLRejectReason.Items.Insert(0, new ListItem("-SELECT-", ""));

                }
                else
                    throw new Exception(statusMsg);
                #endregion
            }
            catch (Exception ex)
            {
                lblRejectErr.Visible = true;
                lblRejectErr.Text = ex.Message;
            }

            #endregion
        }
        protected void btnRejectIssuance_Click(object sender, EventArgs e)
        {
            #region ***
            try
            {
                string stagecode = string.Empty;
                string reason = string.Empty;
                string username = string.Empty;
                if (ACTIONCODE.SelectedValue == "N")
                    stagecode = "EM6002";
                else
                {
                    stagecode = "EM6001";
                    reason = DDLRejectReason.SelectedValue;
                }
                if (Common.GetCookie(this.Page, "IssuanceSV") == "False")
                    username = txtSuperID.Text;
                else
                    username = Common.GetCookie(this.Page, "loginName");

                #region Call the webservices
                EMService issue = new EMService();
                RequestDataTypeIssuance iss = new RequestDataTypeIssuance();
                iss.PermissionCode = Common.GetValue("Issuance");
                iss.ActionDescription = "Issue Visa failed";
                iss.SessionKey = Common.GetCookie(this.Page, "sessionKey");
                iss.ApplicationID = APPID.Value;
                iss.EnrolLocationName = txtCompName.Value.Trim();
                iss.StageCode = stagecode;
                iss.RejectedBy = username;
                iss.RejectReason = reason;
                iss.Remark = txtRejectRemark.Text.ToUpper().Trim();

                ResponseDataTypeIssuance getdataissue = issue.Issue(iss);
                string StatusCode = getdataissue.StatusCode;
                string StatusMsg = getdataissue.StatusMessage;

                #endregion

                #region Issuance fail process

                if (StatusCode == "0")
                {
                    tbButtonPassport.Visible = true;
                    trButton.Visible = false;
                    lblResult.Visible = true;
                    lblResult.Text = "Visa issuance is rejected!";
                    lblError.Visible = false;
                    DDLRejectReason.Enabled = false;
                    txtRejectRemark.Enabled = false;
                    btnCancelReject.Enabled = false;
                    btnRejectIssuance.Enabled = false;
                    ACTIONCODE.Enabled = false;


                }
                else
                    throw new Exception(StatusMsg);

                #endregion
            }
            catch (Exception ex)
            {
                lblResult.Visible = false;
                lblError.Visible = true;
                lblError.Text = ex.Message;
            }
            #endregion
        }
        protected void btnCancelLogin_Click(object sender, EventArgs e)
        {
            tbButtonPassport.Visible = true;
            tbReject.Visible = false;
            ResetRejectControl();

        }
        protected void btnCancelReject_Click(object sender, EventArgs e)
        {
            tbButtonPassport.Visible = true;
            PanelReject.Visible = false;
            tbReject.Visible = false;
            ResetRejectControl();
        }
        private void ResetRejectControl()
        {
            txtSuperID.Text = string.Empty;
            txtSuperPassword.Text = string.Empty;
            txtRejectRemark.Text = string.Empty;
            DDLRejectReason.SelectedValue = string.Empty;
        }
        private void SetButtonEnability(bool read, bool third, bool issue, bool reject, bool cancel)
        {
            btnRead.Disabled = read;
            btn3rdIssue.Enabled = third;
            btnIssue.Enabled = issue;
            IssueFail.Enabled = reject;
            btn_cancel.Enabled = cancel;
        }
        private void GetActiveDoc()
        {
            #region ***
            //try
            //{

            //    enrollment.VISService req = new enrollment.VISService();
            //    enrollment.RequestDataTypeGetActiveDoc reqData = new enrollment.RequestDataTypeGetActiveDoc();

            //    reqData.ActionDescription = "Get Active Doc";
            //    reqData.SessionKey = common.GetCookie(this.Page, "sessionKey");
            //    reqData.PermissionCode = common.GetValue("GetActiveDoc");
            //    reqData.IDPerson = Convert.ToInt32(IDPerson.Value);
            //    reqData.EnrolLocationName = txtCompName.Value;

            //    enrollment.ResponseDataTypeGetActiveDoc responseData = req.GetActiveDoc(reqData);

            //    string statusCode = responseData.StatusCode;
            //    string statusMsg = responseData.StatusMessage;


            //    #region display result
            //    if (statusCode == "0")
            //    {
            //        if (responseData.RecCount == 1)
            //        {
            //            lblObsoleteStatus.Text = "YES";                   
            //            lblObsoleteStatus.BackColor = System.Drawing.Color.Red;                    
            //            tbButtonPassport.Visible = false;
            //        }
            //        else
            //        {
            //            lblObsoleteStatus.Text = "NO";
            //            lblObsoleteStatus.BackColor = System.Drawing.Color.LawnGreen;
            //        }
            //    }
            //    else
            //        throw new Exception(statusMsg);
            //    #endregion
            //}
            //catch (Exception ex)
            //{
            //    lblError.Text = ex.Message;
            //    lblError.Visible = true;
            //}

            #endregion
        }
        protected void ACTIONCODE_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ACTIONCODE.SelectedValue == "N")
            {
                DDLRejectReason.Enabled = false;
                DDLRejectReason.Items.Insert(0, new ListItem("", "NA"));
                DDLRejectReason.SelectedIndex = 0;
                RequiredFieldValidator6.Enabled = false;
                lblAstReason.Visible = false;
                lblAstRemarks.Visible = true;
                RFVRemarks.Visible = true;
            }
            else
            {
                DDLRejectReason.Enabled = true;
                if (DDLRejectReason.Items[0].Value == "NA")
                    DDLRejectReason.Items.Remove(DDLRejectReason.Items[0]);
                RequiredFieldValidator6.Enabled = true;
                lblAstReason.Visible = true;
                lblAstRemarks.Visible = false;
                RFVRemarks.Visible = false;
            }
        }
    }
}
