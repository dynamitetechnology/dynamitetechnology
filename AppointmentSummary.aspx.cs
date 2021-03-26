using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class AppointmentSummary : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
    int tot = 0;
    string s;
    string t;
    string[] a = new string[12];
   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
           
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[12] { new DataColumn("name"), new DataColumn("qly"), new DataColumn("exp"), new DataColumn("fee"), new DataColumn("images"), new DataColumn("id"), new DataColumn("Adate"), new DataColumn("ftime"), new DataColumn("Ttime"), new DataColumn("Purpose"), new DataColumn("LastVisit"), new DataColumn("cookieid") });

            if (Request.Cookies["cookies"] != null)
            {
                s = Convert.ToString(Request.Cookies["cookies"].Value);
                string[] strArr = s.Split('|');
                for (int i = 0; i < strArr.Length; i++)
                {
                    t = Convert.ToString(strArr[i].ToString());
                    string[] strArr1 = t.Split('&');
                    for (int j = 0; j < strArr1.Length; j++)
                    {

                        a[j] = strArr1[j].ToString();

                    }

                    dt.Rows.Add(a[0].ToString(), a[1].ToString(), a[2].ToString(), a[3].ToString(), a[4].ToString(), a[5].ToString(), a[6].ToString(), a[7].ToString(), a[8].ToString(), a[9].ToString(), a[10].ToString(), i.ToString());

                }
            }
            else
            {
                Response.Write("<script>alert('please select Doctor'); window.location='Default.aspx';</script>");
            }
            d1.DataSource = dt;
            d1.DataBind();
           

        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            con.Open();
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "select * from PatientRegistration where Phone='" + TextBox1.Text + "' and Password='" + TextBox2.Text + "'";
        cmd.ExecuteNonQuery();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        tot = Convert.ToInt32(dt.Rows.Count.ToString());


        if (tot > 0)
        {
            if (Session["checkoutbutton"] == "yes")
            {
                Session["user"] = TextBox1.Text;
                Session["id"] = Convert.ToInt32(dt.Rows[0]["id"]);
                // Response.Redirect("update_order_details.aspx");
                Response.Redirect("Confirmation.aspx");
            }
            //else
            //{
            //    Session["user"] = TextBox1.Text;
            //    Response.Redirect("order_details.aspx");
            //}

        }
        else
        {
            
            Label1.Text = "Wrong Username or Password";
            TextBox1.Text = "";
            TextBox2.Text = "";
        }


        con.Close();

        }
        catch (Exception ex)
        {

        }
    }
}
