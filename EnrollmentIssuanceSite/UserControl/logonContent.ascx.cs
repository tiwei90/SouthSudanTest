using EnrollmentIssuanceSite.Shared;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EnrollmentIssuanceSite.UserControl
{
    public partial class LogonContent : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                SetSelectedTab();
                CheckEnrolPermission();
                CheckApprovalPermission();
                CheckPaymentPermission();
                CheckIssuancePermission();
            }

            // Sets the machine id name
            string[] clientpcinfo = System.Net.Dns.GetHostEntry(Request.ServerVariables["remote_addr"]).HostName.Split(new Char[] { '.' });

            txtCompName.Value = clientpcinfo[0];
        }

        private void SetSelectedTab()
        {
            if (Common.GetCookie(this.Page, "ConfigLocation").Substring(0, 1) == "1")
            {
                MultiView1.ActiveViewIndex = 0;
                Menu1.Items[0].Selected = true;
            }
            else if (Common.GetCookie(this.Page, "ConfigLocation").Substring(1, 1) == "1")
            {
                MultiView1.ActiveViewIndex = 1;
                Menu1.Items[1].Selected = true;
            }
            else if (Common.GetCookie(this.Page, "ConfigLocation").Substring(2, 1) == "1")
            {
                MultiView1.ActiveViewIndex = 2;
                Menu1.Items[2].Selected = true;
            }
            else if (Common.GetCookie(this.Page, "ConfigLocation").Substring(3, 1) == "1")
            {
                MultiView1.ActiveViewIndex = 3;
                Menu1.Items[3].Selected = true;
            }
        }

        private void CheckEnrolPermission()
        {
            #region Set Enrollment Location Configuration
            if (Common.GetCookie(this.Page, "ConfigLocation").Substring(0, 1) == "1")
            {
                #region Set Enrollment Permission

                if (Common.GetCookie(this.Page, "GroupPermission") != null)
                {
                    string EnrolPermission = Common.GetCookie(this.Page, "GroupPermission");

                    #region set menu visibility
                    if (EnrolPermission == "000")
                    {
                        trEnrolWarning.Visible = true;
                    }

                    if (EnrolPermission.Substring(2, 1) == "1")//Acceptance Clerk
                    {
                        trRenew.Visible = true;
                        trEnrolNew.Visible = true;
                        trQuery.Visible = true;
                    }

                    if (EnrolPermission.Substring(1, 1) == "1")//Data Entry
                    {
                        trDataEntry.Visible = true;
                        trQuery.Visible = true;
                    }

                    if (EnrolPermission.Substring(0, 1) == "1")//Update Profile
                    {
                        trUpdate.Visible = true;
                        trQuery.Visible = true;
                    }

                    #endregion
                }
                else
                {
                    Response.Redirect("ErrorPage.aspx?ms=5");
                }

                #endregion
                SetReportIconVisibility("E");
            }
            else
                Menu1.Items[0].Enabled = false;
            #endregion
        }

        private void CheckPaymentPermission()
        {
            #region Set Payment Location Configuration
            if (Common.GetCookie(this.Page, "ConfigLocation").Substring(1, 1) == "1")
            {
                #region ***

                if (Common.GetCookie(this.Page, "PaymentPermission") != null)
                {
                    string PaymentPermission = Common.GetCookie(this.Page, "PaymentPermission");

                    #region set menu visibility
                    if (PaymentPermission == "1")
                    {
                        trPayment.Visible = true;
                    }
                    else
                    {
                        trPayWarning.Visible = true;
                    }
                    #endregion
                }
                else
                {

                    Response.Redirect("ErrorPage.aspx?ms=5");
                }
                #endregion
                SetReportIconVisibility("P");
            }
            else
                Menu1.Items[1].Enabled = false;
            #endregion
        }

        private void CheckApprovalPermission()
        {
            #region Set Approval Location Configuration
            if (Common.GetCookie(this.Page, "ConfigLocation").Substring(2, 1) == "1")
            {
                #region ***
                if (Common.GetCookie(this.Page, "Permission") != null)
                {
                    string appPermission = Common.GetCookie(this.Page, "Permission").ToString();

                    if (appPermission != "000")
                    {
                        #region Set Menu Visibility
                        if (appPermission.Substring(0, 1) == "1")
                        {
                            trFirst.Visible = true;
                        }

                        if (appPermission.Substring(1, 1) == "1")
                        {
                            trSecond.Visible = true;
                            trAppUpdate.Visible = true;
                        }

                        if (appPermission.Substring(2, 1) == "1")
                        {
                            trView.Visible = true;
                        }
                        #endregion
                    }
                    else
                        trAppWarning.Visible = true;
                }
                else
                {
                    Response.Redirect("ErrorPage.aspx?ms=5");
                }
                #endregion
                SetReportIconVisibility("A");
            }
            else
                Menu1.Items[2].Enabled = false;
            #endregion
        }

        private void CheckIssuancePermission()
        {
            #region Set Issuance Location Configuration
            if (Common.GetCookie(this.Page, "ConfigLocation").Substring(3, 1) == "1")
            {
                #region ***

                if (Common.GetCookie(this.Page, "IssuancePermission") != null)
                {
                    string IssuancePermission = Common.GetCookie(this.Page, "IssuancePermission");

                    #region set menu visibility
                    if (IssuancePermission == "1")
                        trIssuance.Visible = true;
                    else
                        trIssueWarning.Visible = true;
                    #endregion
                }
                else
                {
                    Response.Redirect("ErrorPage.aspx?ms=5");
                }
                #endregion
                SetReportIconVisibility("I");
            }
            else
                Menu1.Items[3].Enabled = false;
            #endregion
        }

        protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
        {
            MultiView1.ActiveViewIndex = Int32.Parse(e.Item.Value);
        }

        #region Enrollment
        protected void btn_enrolNew_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("ApplicationPart1.aspx?sm=1&arrow=14&PC=" + txtCompName.Value.Trim());
        }

        protected void btn_DataEntry_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("search.aspx?sm=0&arrow=0&PC=" + txtCompName.Value.Trim());
        }

        protected void btn_UpdateProfile_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("UpdateProfile.aspx?sm=A&arrow=20&PC=" + txtCompName.Value.Trim());
        }

        protected void btn_renew_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("ApplicationPart1.aspx?sm=2&arrow=18&PC=" + txtCompName.Value.Trim());
        }

        protected void btn_Query_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Query.aspx?sm=8&arrow=61&PC=" + txtCompName.Value.Trim());
        }
        #endregion

        #region Payment
        protected void btn_payment_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("QueryPayment.aspx?sm=3&arrow=21&PC=" + txtCompName.Value.Trim());
        }
        #endregion

        #region Approval
        protected void btn_First_Click(object sender, ImageClickEventArgs e)
        {
            Common.SetCookie(this.Page, "level", "1");
            Response.Redirect("QueryApproval.aspx?sm=31&arrow=31&level=1&PC=" + txtCompName.Value.Trim());
        }

        protected void btn_Second_Click(object sender, ImageClickEventArgs e)
        {
            Common.SetCookie(this.Page, "level", "2");
            Response.Redirect("QueryApproval.aspx?sm=31&arrow=32&level=2&PC=" + txtCompName.Value.Trim());
        }

        protected void btn_AppUpdate_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("QueryApproval.aspx?sm=31&arrow=33&level=5&PC=" + txtCompName.Value.Trim());
        }

        protected void btn_View_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("QueryView.aspx?sm=31&arrow=34&level=0&PC=" + txtCompName.Value.Trim());
        }
        #endregion

        #region Issuance
        protected void btn_Issuance_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("QueryIssuance.aspx?sm=12&arrow=71&PC=" + txtCompName.Value.Trim());
        }
        #endregion

        #region Report Button
        protected void btn_Report_Click(object sender, ImageClickEventArgs e)
        {
            string script = "<script type=\"text/javascript\">";
            script += "window.open('";
            script += Common.GetValue("ReportPath");
            script += "SessionKey=";
            script += Common.GetCookie(Page, "sessionkey") + "&DeptID=MOF-V',";
            script += "'Reporting','fullscreen=yes,scrollbars=yes,menubar=no,status=no,toolbar=no');";
            script += "</script>";
            Page.ClientScript.RegisterClientScriptBlock(GetType(), "Reports", script);
        }

        private void SetReportIconVisibility(string module)
        {
            if (Common.GetCookie(this.Page, "ReportPermission") != "000")
            {
                #region Check Module
                switch (module)
                {
                    case "E":
                        trReportEnrol.Visible = true;
                        break;
                    case "P":
                        trReportPayment.Visible = true;
                        break;
                    case "A":
                        trReportApproval.Visible = true;
                        break;
                    case "I":
                        trReportIssuance.Visible = true;
                        break;
                    default:
                        trReportEnrol.Visible = false;
                        trReportApproval.Visible = false;
                        trReportPayment.Visible = false;
                        trReportIssuance.Visible = false;
                        break;
                }
                #endregion

            }
        }
        #endregion
    }
}
