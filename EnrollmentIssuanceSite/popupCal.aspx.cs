using System;
using System.Web.UI.WebControls;

namespace EnrollmentIssuanceSite
{
    public partial class popupCal : System.Web.UI.Page
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
            #region date cannot be greater than todays date
            if (cal.SelectedDate > System.DateTime.Now.Date && Request.QueryString["status"] == "B")
            {
                string script = "<script type=\"text/javascript\">";
                script += "alert(\"";
                script += Request.QueryString["Text"];
                script += " cannot be later than today's date!\");</script>";
                ClientScript.RegisterClientScriptBlock(GetType(), "Calendar_ChangeDate", script);
                return;

            }
            #endregion        

            #region date must be greater than todays date
            if (cal.SelectedDate <= System.DateTime.Now.Date && Request.QueryString["status"] == "L")
            {
                string script = "<script type=\"text/javascript\">";
                script += "alert(\"";
                script += Request.QueryString["Text"];
                script += " must be later than today's date!\");</script>";
                ClientScript.RegisterClientScriptBlock(GetType(), "Calendar_ChangeDate", script);
                return;

            }
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
