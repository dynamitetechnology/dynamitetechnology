using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class patient_Prescriptiondash : System.Web.UI.Page
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
                Image2.ImageUrl = (dt.Rows[0]["Images"]).ToString();

            }

            else
            {
                lblname.Text = "";
                lbladdress.Text = "";
                lblcity.Text = "";
            }
           
            Prescriptions(Convert.ToInt32(Session["id"].ToString()));

        }
        }
        catch (Exception ex)
        {
            ex.ToString();
        }

    }
    public void Prescriptions(int id)
    {
            try
            {
                DataTable dt = new DataTable();
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = " SELECT dbo.Prescription.AppointID, CONVERT(VARCHAR(11), dbo.Prescription.Date, 106) as Date, dbo.Prescription.Disease, dbo.Prescription.Prescription, dbo.Prescription.Attachment,dbo.Prescription.Remark,CONVERT(VARCHAR(11), dbo.Prescription.NextVisitDate, 106) as NextVisitDate,dbo.DoctorMaster.Doctor_Name, dbo.DoctorMaster.Specialization FROM dbo.DoctorMaster INNER JOIN dbo.Prescription ON dbo.DoctorMaster.id = dbo.Prescription.DoctorID where dbo.Prescription.PatientID='" + Session["id"].ToString() + "' order by dbo.Prescription.PrescriptionID desc";
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
        catch (Exception ex)
        {
            ex.ToString();
        }
    }
}