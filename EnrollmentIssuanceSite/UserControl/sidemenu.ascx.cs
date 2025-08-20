using EnrollmentIssuanceSite.Shared;
using System;
using System.IO;
using System.Xml;

namespace EnrollmentIssuanceSite.UserControl
{
    public partial class Sidemenu : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string trans = Request.QueryString["sm"];
            string done = Request.QueryString["done"];

            if (!Page.IsPostBack)
            {
                DisplayUserInfo();
                #region Define URL according to transaction type
                switch (trans)
                {
                    case "8":
                        HLQuery.NavigateUrl = "../Query.aspx?sm=8&arrow=61&PC=" + Request.QueryString["PC"];
                        HLReadEID.NavigateUrl = "../ReadVisa.aspx?sm=8&arrow=63&PC=" + Request.QueryString["PC"];
                        HLReprint.NavigateUrl = "../QueryReprint.aspx?sm=8&arrow=64&PC=" + Request.QueryString["PC"];
                        break;
                    case "1":
                        HLNewApp.NavigateUrl = "../ApplicationPart1.aspx?sm=1&arrow=14&PC=" + Request.QueryString["PC"];
                        HLResumeEnrol.NavigateUrl = "../search.aspx?sm=7&arrow=21&PC=" + Request.QueryString["PC"];
                        break;
                    case "0":
                        HLPartial.NavigateUrl = "../search.aspx?sm=0&arrow=0&PC=" + Request.QueryString["PC"];
                        HLResumeDE.NavigateUrl = "../search.aspx?sm=11&arrow=2&PC=" + Request.QueryString["PC"];
                        HLExternal.NavigateUrl = "../ApplicationPart1.aspx?sm=4&arrow=40&PC=" + Request.QueryString["PC"];
                        break;
                    case "4":
                        HLPartial.NavigateUrl = "../search.aspx?sm=0&arrow=0&PC=" + Request.QueryString["PC"];
                        HLResumeDE.NavigateUrl = "../search.aspx?sm=11&arrow=2&PC=" + Request.QueryString["PC"];
                        HLExternal.NavigateUrl = "../ApplicationPart1.aspx?sm=4&arrow=40&PC=" + Request.QueryString["PC"];
                        break;
                    case "11":
                        HLResumeDE.NavigateUrl = "../search.aspx?sm=11&arrow=2&PC=" + Request.QueryString["PC"];
                        HLPartial.NavigateUrl = "../search.aspx?sm=0&arrow=0&PC=" + Request.QueryString["PC"];
                        HLExternal.NavigateUrl = "../ApplicationPart1.aspx?sm=4&arrow=40&PC=" + Request.QueryString["PC"];
                        break;
                    case "6":
                        HLResumeDE.NavigateUrl = "../search.aspx?sm=11&arrow=2&PC=" + Request.QueryString["PC"];
                        HLPartial.NavigateUrl = "../search.aspx?sm=0&arrow=0&PC=" + Request.QueryString["PC"];
                        HLExternal.NavigateUrl = "../ApplicationPart1.aspx?sm=4&arrow=40&PC=" + Request.QueryString["PC"];
                        break;
                    case "7":
                        HLResumeEnrol.NavigateUrl = "../search.aspx?sm=7&arrow=21&PC=" + Request.QueryString["PC"];
                        HLNewApp.NavigateUrl = "../ApplicationPart1.aspx?sm=1&arrow=14&PC=" + Request.QueryString["PC"];
                        break;
                    case "9":
                    case "A":
                        HLUpdateDE.NavigateUrl = "../UpdateProfile.aspx?sm=9&arrow=23&PC=" + Request.QueryString["PC"];
                        HLUpdateProfile.NavigateUrl = "../UpdateProfile.aspx?sm=A&arrow=20&PC=" + Request.QueryString["PC"];
                        break;
                    case "3":
                        HLResumeEnrol.NavigateUrl = "../QueryPayment.aspx?sm=3&arrow=21&PC=" + Request.QueryString["PC"];
                        break;
                    case "2":
                        HLRenew.NavigateUrl = "../ApplicationPart1.aspx?sm=2&arrow=18&PC=" + Request.QueryString["PC"];
                        break;
                    case "12":
                        HLIssuance.NavigateUrl = "../QueryIssuance.aspx?sm=12&arrow=71&PC=" + Request.QueryString["PC"];
                        HLQueryIssuance.NavigateUrl = "../Query.aspx?sm=12&arrow=72&PC=" + Request.QueryString["PC"];
                        break;
                    default:
                        break;

                }
                #endregion
            }

            if (done != null && trans != "8")
            {
                IsNew.Value = @Server.MapPath("") + Common.GetValue("xmlServerPath") + done + ".xml";

                if (File.Exists(IsNew.Value))
                {
                    LoadXMLFile(IsNew.Value);
                }
            }

            PageNavigation(trans, done);
            CheckType(trans);
            CheckTransactionType(trans);

            #region Version
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(@Server.MapPath("") + "\\Version.xml");
            XmlNode xmlRoot = xmlDoc.DocumentElement;
            lblModule.Text = xmlRoot.SelectSingleNode("ModuleName").InnerText + " - " + xmlRoot.SelectSingleNode("VersionNo").InnerText;
            //lblVersion.Text = xmlRoot.SelectSingleNode("VersionNo").InnerText;
            #endregion
        }

        private void PageNavigation(string trans, string done)
        {
            #region navigation
            if (done != null)
            {
                PInfo.NavigateUrl = "../ApplicationPart1.aspx?arrow=" + Request.QueryString["arrow"] + "&sm=" + trans + "&done=" + done + "&PC=" + Request.QueryString["PC"];
                contact.NavigateUrl = "../ApplicationPart2.aspx?arrow=" + Request.QueryString["arrow"] + "&sm=" + trans + "&done=" + done + "&PC=" + Request.QueryString["PC"];
                family.NavigateUrl = "../ApplicationPart3.aspx?arrow=" + Request.QueryString["arrow"] + "&sm=" + trans + "&done=" + done + "&PC=" + Request.QueryString["PC"];
                criminal.NavigateUrl = "../ApplicationPart4.aspx?arrow=" + Request.QueryString["arrow"] + "&sm=" + trans + "&done=" + done + "&PC=" + Request.QueryString["PC"];
                additional.NavigateUrl = "../ApplicationPart5.aspx?arrow=" + Request.QueryString["arrow"] + "&sm=" + trans + "&done=" + done + "&PC=" + Request.QueryString["PC"];
                doc.NavigateUrl = "../CheckDMS.aspx?arrow=" + Request.QueryString["arrow"] + "&sm=" + trans + "&done=" + done + "&PC=" + Request.QueryString["PC"];
            }
            #endregion
        }

        private void CheckTransactionType(string mode)
        {
            if (mode == Common.COMPLETEENROLECODE || mode == Common.UPDATEPROFILECODE || mode == Common.GetValue("ExternalDEStage"))
            {
                tbSignature.Visible = false;
                tbFingerprint.Visible = false;
                tbAppPart2.Visible = true;
                tbAppPart3.Visible = true;
                tbAppPart4.Visible = true;
                tbAppPart5.Visible = true;
                tbAppPart6.Visible = true;
            }
            else
            {
                tbSignature.Visible = false;
                tbFingerprint.Visible = false;
                tbAppPart2.Visible = false;
                tbAppPart3.Visible = false;
                tbAppPart4.Visible = false;
                tbAppPart5.Visible = false;
                tbAppPart6.Visible = false;
            }
        }

        private void LoadXMLFile(string fileName)
        {
            try
            {
                if (File.Exists(fileName))
                {
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.Load(fileName);

                    XmlNode xmlRoot = xmlDoc.DocumentElement;
                    XmlNode enrollment = xmlRoot.SelectSingleNode("PAYLOAD/ENROLLMENT");
                    XmlNode enProfile = xmlRoot.SelectSingleNode("PAYLOAD/ENROLLMENT/ENROLPROFILE");
                    string partdone = enrollment.SelectSingleNode("partdone").InnerText;
                    DOCTYPE.Value = enProfile.SelectSingleNode("DOCTYPE").InnerText;

                    CheckPartDone(partdone);
                }
            }
            catch (Exception)
            {

            }
        }

        private void CheckPartDone(string partdone)
        {
            switch (partdone)
            {
                case "0":
                    SetMenuEnability(false, false, false, false, false, false, false, false);
                    break;
                case "1": //Personal
                    SetMenuEnability(true, false, false, false, false, false, false, false);
                    break;
                case "2": //Visa Payment
                    SetMenuEnability(true, true, false, false, false, false, false, false);
                    break;
                case "3"://Fingerprint
                    SetMenuEnability(true, true, true, false, false, false, false, false);
                    break;
                case "4"://Contact & Employment
                    SetMenuEnability(true, true, true, true, false, false, false, false);
                    break;
                case "5"://Family & Travel
                    SetMenuEnability(true, true, true, true, true, false, false, false);
                    break;
                case "6"://Financial
                    SetMenuEnability(true, true, true, true, true, true, false, false);
                    break;
                case "7"://Additional
                    SetMenuEnability(true, true, true, true, true, true, true, false);
                    break;
                case "9"://Doc
                    SetMenuEnability(true, true, true, true, true, true, true, true);
                    break;
                default:
                    SetMenuEnability(false, false, false, false, false, false, false, false);
                    break;

            }
        }

        private void SetMenuEnability(bool Info, bool Sign, bool Finger, bool Contact, bool Family, bool crime, bool Additional, bool Docs)
        {
            PInfo.Enabled = Info;
            signature.Enabled = Sign;
            fingerprint.Enabled = Finger;
            contact.Enabled = Contact;
            family.Enabled = Family;
            criminal.Enabled = crime;
            additional.Enabled = Additional;
            doc.Enabled = Docs;
        }

        private void DisplayUserInfo()
        {
            if (Common.GetCookie(this.Page, "sessionKey") == null)
            {
                Response.Redirect(Common.ErPage);
            }
            else
            {

                lblTime.Text = Convert.ToDateTime(Common.GetCookie(this.Page, "loginTime").ToString()).ToString("dd/MM/yyyy hh:mm:tt");
                lblUserName.Text = Common.GetCookie(this.Page, "loginName").ToString().ToUpper();

            }
        }

        private void SetMenuVisibility(bool newapp, bool entry, bool info, bool query, bool payment, bool replace, bool updateEntry, bool resumeDataEntry, bool issuance, bool approval, bool updateEnrol)
        {
            trNewApplication.Visible = newapp;
            trDataEntry.Visible = entry;
            trApplicantInfo.Visible = info;
            trQuery.Visible = query;
            trResume.Visible = payment;
            trReplace.Visible = replace;
            trUpdateProfileDataEntry.Visible = updateEntry;
            trResumeDataEntry.Visible = resumeDataEntry;
            trIssuance.Visible = issuance;
            trApproval.Visible = approval;
            trUpdateProfile.Visible = updateEnrol;
        }

        private void CheckType(string code)
        {
            switch (code)
            {
                case "0": // Partial enrollment
                    SetMenuVisibility(false, true, false, false, false, false, false, true, false, false, false);
                    break;
                case "1"://New Work Permit
                    SetMenuVisibility(true, false, true, false, false, false, false, false, false, false, false);
                    break;
                case "2"://Renew
                    SetMenuVisibility(false, false, true, false, false, true, false, false, false, false, false);
                    break;
                case "3"://Payment
                    SetMenuVisibility(false, false, false, false, true, false, false, false, false, false, false);
                    break;
                case "4"://External
                    SetMenuVisibility(false, true, true, false, false, false, false, true, false, false, false);
                    break;
                case "5"://Additional
                    SetMenuVisibility(true, false, true, false, true, false, false, false, false, false, false);
                    break;
                case "6"://Data Entry
                    SetMenuVisibility(false, true, true, false, false, false, false, true, false, false, false);
                    break;
                case "7"://Resume Enrollment
                    //CheckGroup();
                    SetMenuVisibility(true, false, true, false, true, false, false, false, false, false, false);
                    break;
                case "8"://Query
                    SetMenuVisibility(false, false, false, true, false, false, false, false, false, false, false);
                    break;
                case "10": //Update Profile - Resume Update
                    SetMenuVisibility(false, false, false, false, false, false, true, false, false, false, false);
                    break;
                case "11": // Resume Data Entry
                    SetMenuVisibility(false, true, false, false, false, false, false, true, false, false, false);
                    break;
                case "9"://Update Profile - Data Entry    
                case "A"://Update Profile - Enrollment
                    SetMenuVisibility(false, false, true, false, false, false, true, false, false, false, true);
                    break;
                case "12"://Issuance 
                    SetMenuVisibility(false, false, false, false, false, false, false, false, true, false, false);
                    break;
                case "31"://Approval 
                    SetMenuVisibility(false, false, false, false, false, false, false, false, false, true, false);
                    CheckAppPermission();
                    break;
                default:
                    Response.Redirect("Logon.aspx");
                    break;
            }
        }

        private void CheckGroup()
        {
            //if (common.GetCookie(this.Page, "GroupPermission") != null)
            //{
            //    string GroupPermission = common.GetCookie(this.Page, "GroupPermission");
            //    switch (GroupPermission)
            //    {
            //        case "010":
            //            SetMenuVisibility(false, true, false, false, false, false, false, true, false);
            //            break;
            //        case "001":
            //            SetMenuVisibility(false, false, false, false, true, false,false, false,false);
            //            break;
            //        case "011":
            //            SetMenuVisibility(false, true, false, false, true, false, false, true,false);
            //            break;
            //        case "101":
            //            SetMenuVisibility(false, false, false, false, true, false, false, false,false);
            //            break;
            //        case "110":
            //            SetMenuVisibility(false, true, false, false, false, false, false, true,false);
            //            break;
            //        case "111":
            //            SetMenuVisibility(false, true, false, false, true, false, false, true,true);
            //            break;
            //        default:
            //            Response.Redirect("Logon.aspx");
            //            break;
            //    }
            //}
            //else
            //{
            //    SetMenuVisibility(false, false, false, false, false, false, false, false,false);
            //}
        }

        private void CheckAppPermission()
        {
            string appPermission = Common.GetCookie(this.Page, "Permission").ToString();

            if (appPermission != "00")
            {
                if (appPermission.Substring(0, 1) == "1")
                    trPreApp.Visible = true;

                if (appPermission.Substring(1, 1) == "1")
                    trFinalApp.Visible = true;

                if (appPermission.Substring(2, 1) == "1")
                    trViewProfile.Visible = true;
            }
        }
    }
}
