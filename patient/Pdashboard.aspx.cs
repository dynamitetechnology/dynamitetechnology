using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class patient_Pdashboard : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
   
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["user"] == null)
        {
            Response.Redirect("/Patientlogin.aspx");
        }
        if (!Page.IsPostBack)
        {
                DataTable dt = new DataTable();           
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from PatientRegistration where id='" + Session["id"].ToString() + "'";
                cmd.ExecuteNonQuery();             
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                 
                    lblname.Text = (dt.Rows[0]["Name"]).ToString();                 
                    lbladdress.Text = (dt.Rows[0]["Address"]).ToString();
                    lblcity.Text = (dt.Rows[0]["Phone"]).ToString(); 
                    Image2.ImageUrl= (dt.Rows[0]["Images"]).ToString();

            }
            
            else
            {
            lblname.Text = "";
            lbladdress.Text = "";
            lblcity.Text = "";
        }
           Appointments(Convert.ToInt32(Session["id"].ToString()));
          // Prescriptions(Convert.ToInt32(Session["id"].ToString()));

        }
        }
        catch (Exception ex)
        {
            ex.ToString();
        }

    }
     public void Appointments(int id )
    {
        try
        {
            DataTable dt = new DataTable();       
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "SELECT  dbo.Appointment.PatientID,dbo.DoctorMaster.Doctor_Name, dbo.DoctorMaster.Specialization,CONVERT(VARCHAR(11), dbo.Appointment.AppointDate, 106) as AppointDate , dbo.Appointment.Timeslot,CONVERT(VARCHAR(11), dbo.Appointment.LastVisitDate, 106) as LastVisitDate, dbo.Appointment.Bill_Amount,CONVERT(VARCHAR(11), dbo.Appointment.BookingDate, 106) as BookingDate,dbo.Appointment.Appointment_Status FROM dbo.DoctorMaster INNER JOIN dbo.Appointment ON dbo.DoctorMaster.id = dbo.Appointment.DoctorID where dbo.Appointment.PatientID='" + Session["id"].ToString() + "' order by dbo.Appointment.AppointID desc";
        cmd.ExecuteNonQuery();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            d1.DataSource = dt;
            d1.DataBind();

        }
        else
        {
            d1.DataSource = null;
            d1.DataBind();
        }
    }
        catch (Exception ex)
        {
            ex.ToString();
        }
    }
   
}