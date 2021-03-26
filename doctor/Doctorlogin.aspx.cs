using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class doctor_Doctorlogin : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
    int tot = 0;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        con.Open();
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "select * from DoctorMaster where Email='" + TextBox1.Text + "' and Password='" + TextBox2.Text + "'";
        cmd.ExecuteNonQuery();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        tot = Convert.ToInt32(dt.Rows.Count.ToString());


        if (tot > 0)
        {
            
                Session["user"] = TextBox1.Text;
            Session["Name"] = Convert.ToString(dt.Rows[0]["Doctor_Name"]);
            Session["id"] = Convert.ToInt32(dt.Rows[0]["id"]);
                Response.Redirect("Ddashboard.aspx");
            

        }
        else
        {
            Label1.Text = "Invalid username or password";
        }


        con.Close();
    }
}