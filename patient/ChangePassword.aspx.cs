using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class patient_ChangePassword : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
    int tot = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["user"] == null)
        {
            Response.Redirect("Patientlogin.aspx");
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

        }
    }
        protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtNewpwd.Text == txtNewpwd2.Text)
        {


            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Update PatientRegistration Set Password='" + txtNewpwd.Text + "' where id='" + Session["id"].ToString() + "'";
            cmd.ExecuteNonQuery();
            con.Close();

            Label1.Text = "Password has been changed !!";
            txtOldpwd.Text = "";
            txtNewpwd.Text = "";
            txtNewpwd2.Text = "";


        }
        else
        {
            Label1.Text = "Please Confirm Same Password";
            txtOldpwd.Text = "";
            txtNewpwd.Text = "";
            txtNewpwd2.Text = "";
        }


        con.Close();
        }
        catch (Exception ex)
        {

        }
    }
}