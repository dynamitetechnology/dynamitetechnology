using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Net;

public partial class patient_OrderMedicine : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
    string url = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["user"] == null)
        {
            Response.Redirect("/Patientlogin.aspx");
        }
        if (!Page.IsPostBack)
        {
            string AppointId = Request.QueryString["AppointId"].ToString();
            string PatientId = Request.QueryString["PatientId"].ToString();
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
            DataTable dt1 = new DataTable();
            SqlCommand cmd1 = con.CreateCommand();
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "select * from PrescriptionOrder where PatientId='" + PatientId + "' and AppointId='"+AppointId+"'";
            cmd1.ExecuteNonQuery();
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            da1.Fill(dt1);
            if (dt1.Rows.Count > 0)
            {


                Label2.Text = "You Already Ordered This prescription Please contact Support !!";
            }

            else
            {
                PrescriptionOrder(AppointId, PatientId);
            }
          

        }
        }
        catch (Exception ex)
        {
            ex.ToString();
        }
    }
    public void PrescriptionOrder(string AppointId, string PatientId)
    {
        try
        {
            DataTable dt = new DataTable();
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = " SELECT dbo.Prescription.AppointID,  dbo.Prescription.PatientID, CONVERT(VARCHAR(11), dbo.Prescription.Date, 106) as Date, dbo.Prescription.Disease, dbo.Prescription.Prescription, dbo.Prescription.Attachment, dbo.PatientRegistration.Address, dbo.PatientRegistration.Phone, dbo.PatientRegistration.City, dbo.PatientRegistration.Pincode FROM dbo.Appointment INNER JOIN dbo.Prescription ON dbo.Appointment.AppointID = dbo.Prescription.AppointID INNER JOIN dbo.PatientRegistration ON dbo.Prescription.PatientID = dbo.PatientRegistration.id where dbo.Prescription.PatientID='" + PatientId + "' and dbo.Prescription.AppointID='" + AppointId+"'";
        cmd.ExecuteNonQuery();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            txtAppointNo.Text = dt.Rows[0]["AppointID"].ToString();
            txtDate.Text = dt.Rows[0]["Date"].ToString();
            txtDisease.Text = dt.Rows[0]["Disease"].ToString();
             url = dt.Rows[0]["Attachment"].ToString();            
            lblfile.Text = "<a href='" + url + "'>Attached File<a/>";
            lblprescription.Text = dt.Rows[0]["Prescription"].ToString();
            txtaddress.Text= dt.Rows[0]["Address"].ToString();
            txtcity.Text= dt.Rows[0]["City"].ToString();
            txtpin.Text= dt.Rows[0]["Pincode"].ToString();
            txtPhone.Text= dt.Rows[0]["Phone"].ToString();
            lblattach.Text = dt.Rows[0]["Attachment"].ToString();

        }
        else
        {
            Label2.Text = "Something Wrong Please contact Support";
        }
    }
        catch (Exception ex)
        {
            ex.ToString();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
       
            if(txtAppointNo.Text!="")
            {
            try
            {
                GenerateOTP();

                string AppointId = Request.QueryString["AppointId"].ToString();
                string PatientId = Request.QueryString["PatientId"].ToString();
                double amount = 0;
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into PrescriptionOrder(PatientId,AppointId,Prescription,Attachment,DeliveryAddress,City,OTP,Phone,Pincode,AppointDate,Remark,OrderDate,Disease,Status,OrderStatus,Amount) values('" + Convert.ToInt32(PatientId) + "','" + Convert.ToInt32(AppointId) + "','" + lblprescription.Text + "','" + lblattach.Text + "','" + txtaddress.Text + "','" + txtcity.Text + "','" + lblotp.Text + "','" + txtPhone.Text + "','" + txtpin.Text + "','" + Convert.ToDateTime(txtDate.Text) + "','" + txtremark.Text + "','" + DateTime.Now + "','" + txtDisease.Text + "',0,'Open','"+ amount + "')";
                cmd.ExecuteNonQuery();
                con.Close();

                string sms_owner = " Your OTP is " + lblotp.Text + " From: Dcare Online Appointment Team";
                string sURL;
                StreamReader objReader;
                sURL = "http://sms.osrinfotech.in/rest/services/sendSMS/sendGroupSms?AUTH_KEY=ab3f47f8841d64f7eb45ed2553d3628&message=" + sms_owner + "&senderId=OSRBPL&routeId=1&mobileNos=" + txtPhone.Text + "&smsContentType=english";

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

                Response.Redirect("ConfirmOrder.aspx?AppointId=" + txtAppointNo.Text);
            }
        catch (Exception ex)
        {
            ex.ToString();
        }
    }
            else
        {
            Label1.Text = "You Already Ordered This Prescription !!";
        }
          
    }
   protected void GenerateOTP()
{

    string numbers = "1234567890";
    string characters = numbers;

    int length = 6;
    string otp = string.Empty;
    for (int i = 0; i < length; i++)
    {
        string character = string.Empty;
        do
        {
            int index = new Random().Next(0, characters.Length);
            character = characters.ToCharArray()[index].ToString();
        } while (otp.IndexOf(character) != -1);
        otp += character;
    }
    lblotp.Text = otp;
}
}