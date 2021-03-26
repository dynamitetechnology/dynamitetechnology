using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class patient_Prescription : System.Web.UI.Page
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
            string AppointId = Request.QueryString["AppointId"].ToString();
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
                // lblname.Text = (dt2.Rows[0]["id"]).ToString();
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
            //  Appointments(Convert.ToInt32(Session["id"].ToString()));
            Prescriptions(Convert.ToInt32(AppointId));

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
        cmd.CommandText = " SELECT dbo.Prescription.AppointID, CONVERT(VARCHAR(11), dbo.Prescription.Date, 106) as Date, dbo.Prescription.Disease, dbo.Prescription.Prescription, dbo.Prescription.Attachment,dbo.Prescription.Remark,CONVERT(VARCHAR(11), dbo.Prescription.NextVisitDate, 106) as NextVisitDate,dbo.DoctorMaster.Doctor_Name, dbo.DoctorMaster.Specialization FROM dbo.DoctorMaster INNER JOIN dbo.Prescription ON dbo.DoctorMaster.id = dbo.Prescription.DoctorID where dbo.Prescription.AppointID='" + id + "'";
        cmd.ExecuteNonQuery();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            lblAppointNo.Text = dt.Rows[0]["AppointID"].ToString();
            lblDate.Text = dt.Rows[0]["Date"].ToString();
            lbldisease.Text = dt.Rows[0]["Disease"].ToString();
            string url= dt.Rows[0]["Attachment"].ToString();
            lblfile.Text= "<a href='"+url+"'>Attached File<a/>";
            lblprescription.Text = dt.Rows[0]["Prescription"].ToString();
            lblremark.Text = dt.Rows[0]["Remark"].ToString();
            lblcreated.Text = dt.Rows[0]["Doctor_Name"].ToString();
            lblnext.Text = dt.Rows[0]["NextVisitDate"].ToString();

        }
        else 
        {
           
        }
    }
        catch (Exception ex)
        {
            ex.ToString();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            string AppointId = Request.QueryString["AppointId"].ToString();
        String PatientId = Session["id"].ToString();
        Response.Redirect("OrderMedicine.aspx?AppointId=" + AppointId + "&PatientId=" + PatientId+"");
}
        catch (Exception ex)
        {
            ex.ToString();
        }
    }

}