﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Services;

public partial class _Default : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        con.Open();
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = CommandType.Text;        
        cmd.CommandText = "select * from DoctorMaster where Status=1";        
        cmd.ExecuteNonQuery();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        d1.DataSource = dt;
        d1.DataBind();
        con.Close();
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


        Response.Redirect("AppointmentSchedule.aspx");

        }
        catch (Exception ex)
        {

        }
    }
}

