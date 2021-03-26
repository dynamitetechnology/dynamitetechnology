using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class doctor_Ddashboard : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
  
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user"] == null)
        {
            Response.Redirect("Doctorlogin.aspx");
        }
        if (!Page.IsPostBack)
        {
            DataTable dt = new DataTable();
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from DoctorMaster where id='" + Session["id"].ToString() + "'";
            cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
               
                lblname.Text = (dt.Rows[0]["Doctor_Name"]).ToString();
                lblspe.Text = (dt.Rows[0]["Specialization"]).ToString();
                Image2.ImageUrl = dt.Rows[0]["Doctor_Images"].ToString();
           

            }

            else
            {
                lblname.Text = "";
                lblspe.Text = "";
               
            }
            Total_Appointment();
            //Total_Close_Appointment();
            //Total_Close_Appointment();
            TodayAppointmets(Convert.ToInt32(Session["id"].ToString()));
           // UpcomingAppointmets(Convert.ToInt32(Session["id"].ToString()));
        }
    }
    private void Total_Appointment()
    {
        int count = 0;     
        //int DId = Convert.ToInt32(Session["id"]);
        DataTable dt = new DataTable();

        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "SELECT Count(*)  as count FROM dbo.Appointment where dbo.Appointment.DoctorID='" + Session["id"].ToString() + "'";
        cmd.ExecuteNonQuery();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            count = Convert.ToInt32(dt.Rows[0]["count"]);
        }
        else
        {
            count = 0;
        }
        lbltotal.Text = count.ToString();
    }
    private void Total_Close_Appointment()
    {
        int count = 0;
        //int DId = Convert.ToInt32(Session["id"]);
        DataTable dt = new DataTable();

        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "SELECT Count(*)  as count FROM dbo.Appointment where dbo.Appointment.DoctorID='" + Session["id"].ToString() + "' and Appointment_Status=3";
        cmd.ExecuteNonQuery();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            count = Convert.ToInt32(dt.Rows[0]["count"]);
        }
        else
        {
            count = 0;
        }
        lbltoday.Text = count.ToString();
    }
    private void Total_Open_Appointment()
    {
        int count = 0;
        //int DId = Convert.ToInt32(Session["id"]);
        DataTable dt = new DataTable();

        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "SELECT Count(*)  as count FROM dbo.Appointment where dbo.Appointment.DoctorID='" + Session["id"].ToString() + "' and Appointment_Status=2";
        cmd.ExecuteNonQuery();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            count = Convert.ToInt32(dt.Rows[0]["count"]);
        }
        else
        {
            count = 0;
        }
        lblApoointment.Text = count.ToString();
    }
    //public void UpcomingAppointmets(int id)
    //{
    //    DataTable dt = new DataTable();
       
    //    SqlCommand cmd = con.CreateCommand();
    //    cmd.CommandType = CommandType.Text;
    //    cmd.CommandText = " SELECT dbo.PatientRegistration.Name, dbo.PatientRegistration.id, CONVERT(VARCHAR(11), dbo.Appointment.AppointDate, 106) as AppointDate, dbo.Appointment.Timeslot,dbo.Appointment.Purpose, dbo.Appointment.Bill_Amount,CONVERT(VARCHAR(11), dbo.Appointment.LastVisitDate, 106) as LastVisitDate, dbo.AppointmentRequest.PatientType FROM dbo.PatientRegistration INNER JOIN dbo.Appointment ON dbo.PatientRegistration.id = dbo.Appointment.PatientID INNER JOIN dbo.AppointmentRequest ON dbo.Appointment.ReqId = dbo.AppointmentRequest.ReqId where dbo.Appointment.DoctorID='" + Session["id"].ToString() + "'and dbo.Appointment.AppointDate >'" + DateTime.Today+"'";
    //    cmd.ExecuteNonQuery();
    //    SqlDataAdapter da = new SqlDataAdapter(cmd);
    //    da.Fill(dt);
    //    if (dt.Rows.Count > 0)
    //    {
    //        d1.DataSource = dt;
    //        d1.DataBind();

    //    }
    //    else
    //    {
    //        d1.DataSource = null;
    //        d1.DataBind();
    //    }
    
    //}
    public void TodayAppointmets(int id)
    {
        DataTable dt = new DataTable();

        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "SELECT dbo.Appointment.AppointID, dbo.PatientRegistration.Name, dbo.PatientRegistration.id, CONVERT(VARCHAR(11), dbo.Appointment.AppointDate, 106) as AppointDate, dbo.Appointment.Timeslot,dbo.Appointment.Purpose, dbo.Appointment.Bill_Amount,CONVERT(VARCHAR(11), dbo.Appointment.LastVisitDate, 106) as LastVisitDate, dbo.AppointmentRequest.PatientType FROM dbo.PatientRegistration INNER JOIN dbo.Appointment ON dbo.PatientRegistration.id = dbo.Appointment.PatientID INNER JOIN dbo.AppointmentRequest ON dbo.Appointment.ReqId = dbo.AppointmentRequest.ReqId where dbo.Appointment.DoctorID='" + Session["id"].ToString() + "' ";
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