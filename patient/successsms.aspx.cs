using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System;

public partial class success : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
    string order = "";
    string order_id;
    string s;
    string t;
    string[] a = new string[12];
    protected void Page_Load(object sender, EventArgs e)
    {

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

                con.Open();
                //SqlCommand cmd3 = con.CreateCommand();
                //cmd3.CommandType = CommandType.Text;
                //cmd3.CommandText = "insert into Appointment(ReqId,DoctorID,PatientID,AppointDate,BookingDate,Appointment_Status,Bill_Amount,Bill_Status,DoctorNotification,PatientNotification,FeedbackStatus,Purpose,Timeslot,LastVisitDate,) values('" + order_id.ToString() + "','" + a[5].ToString() + "','" + Session["id"].ToString() + "','" + a[6].ToString() + "','" + DateTime.Now + "','Pending','" + a[3].ToString() + "','Paid',0,0,0,'" + a[9].ToString() + "','" + time.ToString() + "','" + a[10].ToString() + "')";
                //cmd3.ExecuteNonQuery();
                //con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT dbo.DoctorMaster.Doctor_Name FROM  dbo.DoctorMaster where dbo.DoctorMaster.id ='" + a[5].ToString() + "'";
                cmd.ExecuteNonQuery();
                DataTable dt3 = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt3);
                if (dt3.Rows.Count > 0)
                {

                    lbldoctor.Text = (dt3.Rows[0]["Doctor_Name"]).ToString();
                    lblAppointDate.Text = a[6].ToString() + " " + a[7].ToString() + "-" + a[8].ToString();
                }

            }

        }

    
        else
        {
            Response.Redirect("login.aspx");
        }
           Session["user"] = null;
        Session["checkoutbutton"] = null;
        Session["deliverydate"] = null;
        Session["deliverytime"] = null;

        Response.Cookies["cookies"].Expires = DateTime.Now.AddDays(-1);
        Response.Cookies["cookies"].Expires = DateTime.Now.AddDays(-1);

    }
}