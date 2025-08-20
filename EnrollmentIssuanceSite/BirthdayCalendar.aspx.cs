using System;
using System.Web.UI.WebControls;

namespace EnrollmentIssuanceSite
{
    public partial class BirthdayCalendar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string selectedMonth = cal.SelectedDate.Month.ToString();
                ddlMonth.SelectedValue = (System.DateTime.Now.Month.ToString().Length < 2) ? "0" + System.DateTime.Now.Month.ToString() : System.DateTime.Now.Month.ToString();
                GenerateYear();
                ddlYear.SelectedValue = System.DateTime.Now.Year.ToString();

            }

            if (IsDFDelete.Text == "1")
                ReturnDate();
        }

        private void GenerateYear()
        {
            #region ***
            for (int i = -107; i < 20; i++)
            {
                DateTime year = DateTime.Now.AddYears(i);
                string itemText = year.Year.ToString();
                ddlYear.Items.Add(new ListItem(itemText, itemText));
            }
            #endregion
        }


        protected void ddlMonth_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            System.IFormatProvider frmt = new System.Globalization.CultureInfo("en-US", true);
            string temp = Convert.ToString(ddlMonth.SelectedValue + "/01/" + ddlYear.SelectedValue);
            cal.VisibleDate = DateTime.ParseExact(temp, "MM/dd/yyyy", frmt);
        }

        protected void ddlYear_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            System.IFormatProvider frmt = new System.Globalization.CultureInfo("en-US", true);
            string temp = Convert.ToString(ddlMonth.SelectedValue + "/01/" + ddlYear.SelectedValue);
            cal.VisibleDate = DateTime.ParseExact(temp, "MM/dd/yyyy", frmt);
        }
        protected void cal_SelectionChanged(object sender, EventArgs e)
        {
            int age = (System.DateTime.Now.Year - cal.SelectedDate.Year);

            #region Date of birth cannot be greater than todays date
            if (cal.SelectedDate > System.DateTime.Now.Date)
            {
                string script = "<script type=\"text/javascript\"> alert(\"Date of Birth must not be later than today's date!\");</script>";
                ClientScript.RegisterClientScriptBlock(GetType(), "Calendar_ChangeDate", script);
                return;

            }
            #endregion

            #region  Confirmation of age > 99
            if (age > 99)
            {
                string script = "<script type=\"text/javascript\">ConfirmDate(" + age.ToString() + ",'');</script>";
                ClientScript.RegisterClientScriptBlock(GetType(), "Calendar_ChangeDate", script);
                return;
            }
            #endregion

            #region Applicant must be 18 years old and above
            //if (age < 18 && Request.QueryString["Applicant"] == "Y")
            //{
            //    //string script = "<script type=\"text/javascript\">";
            //    //script += "alert(\"Passport request type is";
            //    //script += Request.QueryString["PType"];
            //    //script = "Applicant has to be 18 years old or older!\");</script>";
            //    string script = "<script type=\"text/javascript\"> alert(\"Applicant has to be 18 years old or older!\");</script>";
            //    ClientScript.RegisterClientScriptBlock(GetType(), "Calendar_ChangeDate", script);
            //    return;
            //}
            #endregion

            #region Passport request type Children must be less than 18 years old
            //if (age > 17 && Request.QueryString["PType"] == "PC" && Request.QueryString["Applicant"] == "Yes")
            //{
            //    string script = "<script type=\"text/javascript\"> alert(\"Passport request type is children. Applicant has to be below 18 years old!\");</script>";
            //    ClientScript.RegisterClientScriptBlock(GetType(), "Calendar_ChangeDate", script);
            //    return;
            //}
            #endregion     

            ReturnDate();
        }

        private void ReturnDate()
        {

            if (Request.QueryString["field"] != "")
            {
                string strScript = "<script type='text/javascript'>window.opener.document." +
                                   Request.QueryString["field"].ToString() + ".value = '";

                strScript += cal.SelectedDate.ToString("dd/MM/yyyy");
                strScript += "';self.close()";
                strScript += "</script>";
                ClientScript.RegisterClientScriptBlock(GetType(), "Calendar_ChangeDate", strScript);

            }


        }
    }
}
