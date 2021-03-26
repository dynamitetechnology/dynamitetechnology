using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Net;

public partial class patient_ConfirmOrder : System.Web.UI.Page
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
            successdiv.Visible = false;
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
            DataTable dt = new DataTable();
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from PrescriptionOrder where PatientId='" + Session["id"].ToString() + "' and AppointId='"+AppointId+ "' and OTP='"+txtotp.Text+"' and Status=0";
            cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {

                confirmdiv.Visible = false;
                successdiv.Visible = true;
                lblorder.Text = dt.Rows[0]["MOrder"].ToString();
                lblDate.Text = dt.Rows[0]["OrderDate"].ToString();
                UpdateStatus();


            }
            else
            {
                Label1.Text = "Please Enter Valid OTP";
            }
        }
        catch (Exception ex)
        {
            ex.ToString();
        }
    }
    public void UpdateStatus()
    {
        try
        {
            string AppointId = Request.QueryString["AppointId"].ToString();
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "update PrescriptionOrder set Status=1 where PatientId='" + Session["id"].ToString() + "' and AppointId='"+ AppointId + "' and MOrder='"+lblorder.Text+"'";
        cmd.ExecuteNonQuery();
        con.Close();
    }
        catch (Exception ex)
        {
            ex.ToString();
        }
    }
}