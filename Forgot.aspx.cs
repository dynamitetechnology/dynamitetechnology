using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Forgot : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            con.Open();
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "select * from PatientRegistration where Phone='" + TextBox1.Text + "'";
        cmd.ExecuteNonQuery();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);
    
        if (dt.Rows.Count > 0)
        {
            string Name = dt.Rows[0]["Name"].ToString();
            string Password = dt.Rows[0]["Password"].ToString();
            string sms_owner = "Dear " + Name + ", Your Password is " + Password + " From: Dcare Online Appointment Team";
            string sURL;
            StreamReader objReader;
            sURL = "http://sms.osrinfotech.in/rest/services/sendSMS/sendGroupSms?AUTH_KEY=ab3f47f8841d64f7eb45ed2553d3628&message=" + sms_owner + "&senderId=OSRBPL&routeId=1&mobileNos=" + TextBox1.Text + "&smsContentType=english";

            WebRequest wrGETURL;
            wrGETURL = WebRequest.Create(sURL);
            try
            {
                Stream objStream;
                objStream = wrGETURL.GetResponse().GetResponseStream();
                objReader = new StreamReader(objStream);
                objReader.Close();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            Label1.Text = "Password is sent on Mobile No";
        }
        else
        {
            Label1.Text = "Please enter Registerd Mobile No";
        }


        con.Close();
    }
        catch (Exception ex)
        {

        }
    }
}