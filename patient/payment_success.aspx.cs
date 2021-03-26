using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class user_payment_success : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
   

    string order = "";
    string order_id;
    string s;
    string t;
    string[] a = new string[12];
    string type = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (con.State == ConnectionState.Open)
        {
            con.Close();
        }
        con.Open();
        SqlCommand cmd4 = con.CreateCommand();
        cmd4.CommandType = CommandType.Text;
        cmd4.CommandText = "select * from AppointmentRequest where PatientId='" + Session["id"].ToString() + "'";
        cmd4.ExecuteNonQuery();
        DataTable dt4 = new DataTable();
        SqlDataAdapter da4 = new SqlDataAdapter(cmd4);
        da4.Fill(dt4);
        if(dt4.Rows.Count>0)
        {
            type = "Old";
        }
        else
        {
            type = "New";
        }

        order = Request.QueryString["Payment_Id"].ToString();

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from PatientRegistration where id='" + Session["id"].ToString() + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
               string result= checkprevioustransaction(order);
                if(result=="yes")
                {

                }
                else
                {
                    SqlCommand cmd1 = con.CreateCommand();
                    cmd1.CommandType = CommandType.Text;
                    cmd1.CommandText = "insert into AppointmentRequest (PatientId,PatientName,PatientPhone,Email,Address,City,ReqDate,PaymentId,Status,PatientType) values('" + Session["id"].ToString() + "','" + dr["Name"].ToString() + "','" + dr["Phone"].ToString() + "','" + dr["Email"].ToString() + "','" + dr["Address"].ToString() + "','" + dr["City"].ToString() + "','" + DateTime.Now.ToString() + "','" + order + "','Pending','" + type + "')";
                    cmd1.ExecuteNonQuery();
                }
                
            }


            SqlCommand cmd2 = con.CreateCommand();
            cmd2.CommandType = CommandType.Text;
            cmd2.CommandText = "select top 1 * from AppointmentRequest where PatientId='" + Session["id"].ToString() + "' order by ReqId desc ";
            cmd2.ExecuteNonQuery();
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            da2.Fill(dt2);
            foreach (DataRow dr2 in dt2.Rows)
            {
                order_id = dr2["ReqId"].ToString();
            }


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
                    string time = a[7].ToString() + '-' + a[8].ToString();


                    SqlCommand cmd3 = con.CreateCommand();
                    cmd3.CommandType = CommandType.Text;
                    cmd3.CommandText = "insert into Appointment(ReqId,DoctorID,PatientID,AppointDate,BookingDate,Appointment_Status,Bill_Amount,Bill_Status,DoctorNotification,PatientNotification,FeedbackStatus,Purpose,Timeslot,LastVisitDate) values('" + order_id.ToString() + "','" + a[5].ToString() + "','" + Session["id"].ToString() + "','" + Convert.ToDateTime(a[6].ToString()) + "','" + DateTime.Now + "','0','" + a[3].ToString() + "','Paid',0,0,0,'"+ a[9].ToString() + "','" + time.ToString() + "','" + Convert.ToDateTime(a[10].ToString()) + "')";
                    cmd3.ExecuteNonQuery();

                }

            }

       

        Response.Redirect("/successsms.aspx");

    }
        catch (Exception ex)
        {
            ex.ToString();
        }
    }
    public string checkprevioustransaction(string order)
    {
        string result = string.Empty;
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "select * from AppointmentRequest where PaymentId='" + order + "'";
        cmd.ExecuteNonQuery();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        if(dt.Rows.Count>0)
        {
            result="yes";
        }
        else
        {
            result = "no";
        }
        return result;
        
    }
}