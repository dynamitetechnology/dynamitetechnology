using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class doctor_Mypatient : System.Web.UI.Page
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
                // lblname.Text = (dt2.Rows[0]["id"]).ToString();
                lblname.Text = (dt.Rows[0]["Doctor_Name"]).ToString();
                lblspe.Text = (dt.Rows[0]["Specialization"]).ToString();
                Image2.ImageUrl = dt.Rows[0]["Doctor_Images"].ToString();
                // lblcity.Text = (dt.Rows[0]["City"]).ToString();

            }

            else
            {
                lblname.Text = "";
                lblspe.Text = "";
                //lblcity.Text = "";
            }
            FillPatient();
        }

    }
    private void FillPatient()
    {
       
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "SELECT dbo.PatientRegistration.id,dbo.PatientRegistration.Name,dbo.PatientRegistration.Phone, dbo.PatientRegistration.Address,dbo.PatientRegistration.Age,dbo.PatientRegistration.BloodGroup,dbo.PatientRegistration.City,dbo.PatientRegistration.Gender,dbo.PatientRegistration.Images FROM  dbo.PatientRegistration INNER JOIN dbo.Appointment ON dbo.PatientRegistration.id = dbo.Appointment.PatientID where dbo.Appointment.DoctorID='" + Session["id"].ToString()+ "' group by dbo.PatientRegistration.id,dbo.PatientRegistration.Name,dbo.PatientRegistration.Phone, dbo.PatientRegistration.Address,dbo.PatientRegistration.Age,dbo.PatientRegistration.BloodGroup,dbo.PatientRegistration.City,dbo.PatientRegistration.Gender,dbo.PatientRegistration.Images";
        cmd.ExecuteNonQuery();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        d1.DataSource = dt;
        d1.DataBind();
        con.Close();
    }
}