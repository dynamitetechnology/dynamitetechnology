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

public partial class doctor_MakeCall : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user"] == null)
        {
            Response.Redirect("Doctorlogin.aspx");
        }
        if (!Page.IsPostBack)
        {
            string id = Request.QueryString["id"].ToString();
            string AppointID = Request.QueryString["AppointID"].ToString();
            DataTable dt = new DataTable();
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM PatientRegistration where id='" + id + "'";
            cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                lbl_age.Text = (dt.Rows[0]["Age"]).ToString();
                lbl_Name.Text = (dt.Rows[0]["Name"]).ToString();
                lbl_Id.Text = (dt.Rows[0]["id"]).ToString();
                //lbl_appoint.Text= (dt.Rows[0]["AppointID"]).ToString();
                lbl_gender.Text = (dt.Rows[0]["Gender"]).ToString();
                lbl_phone.Text= (dt.Rows[0]["Phone"]).ToString();
                lbl_address.Text= (dt.Rows[0]["Address"]).ToString();
                lbl_father.Text= (dt.Rows[0]["FatherName"]).ToString();
                lbl_city.Text= (dt.Rows[0]["City"]).ToString();
                lbl_blood.Text= (dt.Rows[0]["BloodGroup"]).ToString();

            }

            else
            {

                lbl_age.Text = "";
                lbl_Name.Text = "";
                lbl_Id.Text = "";              
                lbl_gender.Text = "";
                lbl_phone.Text = "";
                lbl_address.Text = "";
                lbl_father.Text = "";
                lbl_city.Text = "";
                lbl_blood.Text = "";

            }
            string Appointid = Request.QueryString["AppointID"].ToString();
            DataTable dt1 = new DataTable();            
            SqlCommand cmd1 = con.CreateCommand();
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "SELECT dbo.AppointmentRequest.PatientType, dbo.Appointment.Timeslot, dbo.Appointment.Purpose, dbo.Appointment.AppointDate, dbo.Appointment.AppointID FROM dbo.Appointment INNER JOIN dbo.AppointmentRequest ON dbo.Appointment.ReqId = dbo.AppointmentRequest.ReqId where dbo.Appointment.AppointID='" + Appointid + "'";
            cmd1.ExecuteNonQuery();
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            da1.Fill(dt1);
            if (dt1.Rows.Count > 0)
            {
                lbl_Date.Text = (dt1.Rows[0]["AppointDate"]).ToString();
                lbl_Time.Text = (dt1.Rows[0]["Timeslot"]).ToString();
                lbl_Purpose.Text = (dt1.Rows[0]["Purpose"]).ToString();
                lbl_Type.Text= (dt1.Rows[0]["PatientType"]).ToString();
                lbl_appoint.Text= (dt1.Rows[0]["AppointID"]).ToString();
              

            }

            else
            {

                lbl_Date.Text = "";
                lbl_Time.Text = "";
                lbl_Purpose.Text = "";
                lbl_Type.Text = "";
                lbl_appoint.Text = "";

            }
            History(id, Appointid);

        }
    }
    public void History(string id,string Appointid)
    {
        DataTable dt = new DataTable();

        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "SELECT dbo.Prescription.Disease, dbo.Prescription.Prescription, dbo.Prescription.Attachment, dbo.Appointment.AppointDate, dbo.Appointment.Timeslot FROM dbo.Appointment INNER JOIN dbo.Prescription ON dbo.Appointment.AppointID = dbo.Prescription.AppointID where Appointment.PatientID = '"+id+ "' and dbo.Appointment.AppointID != '" + Appointid + "' ";
        cmd.ExecuteNonQuery();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            d1.DataSource = dt;
            d1.DataBind();

        }
        else
        {
            d1.DataSource = null;
            d1.DataBind();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string pid = Request.QueryString["id"].ToString();
        Response.Redirect("call.aspx?id="+pid);
    }
    String addlogo()
    {

        Boolean ok = false;
        String imageloc = string.Empty;
        string ext = System.IO.Path.GetExtension(FileUpload1.FileName).ToLower();
        string[] ar = { ".jpg", ".gif", ".jpeg", ".png" };
        for (int i = 0; i < ar.Length; i++)
        {
            if (ext == ar[i])
            {
                ok = true;
                break;
            }

        }

        if (ok)
        {
            string path = Server.MapPath("/Prescription/");
            FileUpload1.PostedFile.SaveAs(path + FileUpload1.FileName);
            HttpContext.Current.Session["ImagePath"] = Convert.ToString("/Prescription/" + FileUpload1.FileName);
            imageloc = HttpContext.Current.Session["ImagePath"].ToString();
            return imageloc;
        }
        else
        {
        }

        return "";

    }
  
    protected void Button2_Click(object sender, EventArgs e)
    {
        Image1.ImageUrl = addlogo();
        string imageurl = Image1.ImageUrl;
        
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into Prescription(AppointID,DoctorID,PatientID,Date,Disease,Prescription,Attachment,NextVisitDate,Remark) values('"+ lbl_appoint.Text + "', '"+Session["id"].ToString()+"', '"+lbl_Id.Text+"', '"+DateTime.Now+"', '"+txtdisease.Text+"', '"+txtprescription.Text+"', '"+ imageurl + "', '"+Convert.ToDateTime(txtDate.Text)+"','"+txtremark.Text+"')";
            cmd.ExecuteNonQuery();
            con.Close();
        lblmsg.Text = "Prescription Submitted Successfully";
        txtDate.Text = "";
        txtdisease.Text = "";
        txtprescription.Text = "";
        txtremark.Text = "";
        string sms_owner = "Dear"+lbl_Name.Text +"For Your AppointMent No " + lbl_appoint.Text + ", Your Prescription added Successfully,Please Check into your panel  From: Dcare Online Appointment Team";
        string sURL;
        StreamReader objReader;
        sURL = "http://sms.osrinfotech.in/rest/services/sendSMS/sendGroupSms?AUTH_KEY=ab3f47f8841d64f7eb45ed2553d3628&message=" + sms_owner + "&senderId=OSRBPL&routeId=1&mobileNos=" + lbl_phone.Text + "&smsContentType=english";

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

    }
    //protected void b1_Click(object sender, EventArgs e)
    //{
    //    Response.Redirect("Ddashboard.aspx");
    //}

    }