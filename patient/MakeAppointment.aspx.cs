using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class patient_MakeAppointment : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
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

            FillDoctor();
        }
        }
        catch (Exception ex)
        {
            ex.ToString();
        }

    }
    private void FillDoctor()
    {
        try
        {

            SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "SELECT * from dbo.DoctorMaster where Status=1";
        cmd.ExecuteNonQuery();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        d1.DataSource = dt;
        d1.DataBind();
        con.Close();
    }
        catch (Exception ex)
        {
            ex.ToString();
        }
    }
    protected void BookDoctor(object sender, EventArgs e)
    {
        try
        {
            //Find the reference of the Repeater Item.
            RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
        int docId = int.Parse((item.FindControl("lblId") as Label).Text);

        con.Open();
        string name = "", exp = "", qly = "", fee = "", images = "", Adate = "", ftime = "", Ttime = "", Purpose = "", Lastvisit = "";

        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "select * from DoctorMaster where id=" + docId + "";
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
            Lastvisit = "22/08/2020";
        }


        Response.Cookies["cookies"].Value = name.ToString() + "&" + qly.ToString() + "&" + exp.ToString() + "&" + fee.ToString() + "&" + images.ToString() + "&" + docId.ToString() + "&" + Adate.ToString() + "&" + ftime.ToString() + "&" + Ttime.ToString() + "&" + Purpose.ToString() + "&" + Lastvisit.ToString();
        Response.Cookies["cookies"].Expires = DateTime.Now.AddDays(1);


        Response.Redirect("/AppointmentSchedule.aspx");
        }
        catch (Exception ex)
        {
            ex.ToString();
        }

    }

}