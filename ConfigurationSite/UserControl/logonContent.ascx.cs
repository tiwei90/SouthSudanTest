using System;
using System.Web.UI;

public partial class logonContent : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void btn_enrolNew1_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("ApplicationReason.aspx?sm=1");
    }
    protected void btn_DeleteIncomplete_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("DeleteIncomplete.aspx?sm=14");
    }
    protected void btn_DeviceTest_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("DeviceTest.aspx?sm=13");
    }
    protected void btnReprint_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("ResetReprint.aspx?sm=15");
    }
}
