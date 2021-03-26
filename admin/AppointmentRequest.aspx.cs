using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class admin_AppointmentRequest : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Admin"] == null)
        {
            Response.Redirect("Adminlogin.aspx");
        }
        if (!Page.IsPostBack)
        {
            History();
        }
    }
    public void History()
    {
        DataTable dt = new DataTable();
        con.Open();
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = " Select * FROM  NewAppointment_Time where NewAppointment_Time.Appointment_Status='pending' order by NewAppointment_Time.AptId desc";
        cmd.ExecuteNonQuery();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            d2.DataSource = dt;
            d2.DataBind();

        }
        else
        {
            d2.DataSource = null;
            d2.DataBind();
        }
    }
}