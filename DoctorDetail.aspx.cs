using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
public partial class DoctorDetail : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
    int id;
    int qty;

    string s;
    string t;
    string[] a = new string[12];
    double tot = 0;
    double ptotal = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] == null)
        {
            Response.Redirect("Default.aspx");
        }
        else
        {

            id = Convert.ToInt32(Request.QueryString["id"].ToString());
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from DoctorMaster where id=" + id + "";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            d1.DataSource = dt;
            d1.DataBind();

            con.Close();
        }

    }
    protected void b1_Click(object sender, EventArgs e)
    {
        try
        {
            double pt = 0;
        con.Open();
        string name = "", exp = "", qly = "", fee = "", images = "",Adate="",ftime="",Ttime="",Purpose="",Lastvisit="";

        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "select * from DoctorMaster where id=" + id + "";
        cmd.ExecuteNonQuery();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        foreach (DataRow dr in dt.Rows)
        {
            name = dr["Doctor_Name"].ToString();
            exp = dr["Specialization"].ToString();
            fee = dr["Doctor_fee"].ToString();
            qly = dr["Doctor_Qualification"].ToString();
            images = dr["Doctor_Images"].ToString();
            Adate = "22/08/2020";
            ftime = "10:10 AM";
            Ttime = "10:20 AM";
            Purpose = "Treatment";
            Lastvisit= "22/08/2020";
        }
        
           
                Response.Cookies["cookies"].Value = name.ToString() + "&" + qly.ToString() + "&"+exp.ToString()+"&" + fee.ToString() + "&" + images.ToString() + "&" + id.ToString() + "&" +Adate.ToString() + "&" +ftime.ToString() + "&" +Ttime.ToString() + "&"+ Purpose.ToString() +"&"+ Lastvisit.ToString();
                Response.Cookies["cookies"].Expires = DateTime.Now.AddDays(1);
           

            Response.Redirect("AppointmentSchedule.aspx");

        }
        catch (Exception ex)
        {

        }





    }


}