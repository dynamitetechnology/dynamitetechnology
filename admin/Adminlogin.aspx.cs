using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class admin_Adminlogin : System.Web.UI.Page
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
        cmd.CommandText = "select * from admin_login where username='" + TextBox1.Text + "' and password='" + TextBox2.Text + "' and IsActive=1";
        cmd.ExecuteNonQuery();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        tot = Convert.ToInt32(dt.Rows.Count.ToString());


        if (tot > 0)
        {
            
                Session["Admin"] = TextBox1.Text;
                Session["id"] = Convert.ToInt32(dt.Rows[0]["id"]);
                Response.Redirect("ADashbaord.aspx");
           

        }
        else
        {
            Label1.Text = "Invalid username or password";
        }


        con.Close();
    }
}