using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Checkout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user"] == null)
        {
            Response.Redirect("AppointmentSummary.aspx");
        }
        else
        {
            Response.Redirect("Confirmation.aspx");
        }
    }
}