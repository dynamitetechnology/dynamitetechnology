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

public partial class admin_ViewRequest : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
    Common cls = Common.getInstance();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Admin"] == null)
        {
            Response.Redirect("Adminlogin.aspx");
        }
        if (!Page.IsPostBack)
        {
            string AppointId = Request.QueryString["id"].ToString();
            string PatientId = Request.QueryString["Appointid"].ToString();
            FillDoctor();
                 DataTable dt = new DataTable();
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from View_Appointment_Request where PatientID='" + PatientId + "' and AptId='"+ AppointId + "'";
            cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {

                lbl_age.Text = (dt.Rows[0]["Age"]).ToString();
                lbl_Name.Text = (dt.Rows[0]["Name"]).ToString();
                lbl_Id.Text = (dt.Rows[0]["PatientID"]).ToString();
                lbl_gender.Text = (dt.Rows[0]["Gender"]).ToString();
                lbl_phone.Text = (dt.Rows[0]["Phone"]).ToString();
                lbl_address.Text = (dt.Rows[0]["Address"]).ToString();
                lbl_father.Text = (dt.Rows[0]["FatherName"]).ToString();
                lbl_city.Text = (dt.Rows[0]["City"]).ToString();
                lbl_blood.Text = (dt.Rows[0]["BloodGroup"]).ToString();
                string url = dt.Rows[0]["Record"].ToString();
                lblfile.Text = "<a href='" + url + "'>Attached File<a/>";
                DateTime book= Convert.ToDateTime(dt.Rows[0]["BookingDate"]);
                lbl_booking_date.Text = book.ToLongDateString();
                lbl_appoint.Text= (dt.Rows[0]["AptId"]).ToString();
                lbl_illness.Text= (dt.Rows[0]["Illness"]).ToString();
                lbl_problem.Text= (dt.Rows[0]["Problem"]).ToString();
                lbl_surgey.Text= (dt.Rows[0]["AnySurgery"]).ToString();
                lbl_treatment.Text= (dt.Rows[0]["PresentTreatment"]).ToString();
                lbl_status.Text= (dt.Rows[0]["Appointment_Status"]).ToString();
                lbl_bill.Text= (dt.Rows[0]["Bill_Amount"]).ToString();
                lbl_Req.Text= (dt.Rows[0]["ReqId"]).ToString();



            }

            else
            {
                
            }
        }
    }
    protected void btn_add_Click(object sender, EventArgs e)
    {
        All_Clear();
        Model_Open();
    }
    private void Model_Open()
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append("$('#addeditcategory').modal('show');");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AddShowModalScript", sb.ToString(), false);

    }
    public void All_Clear()
    {
        txtappointdate.Text = "";
        txtdescription.Text = "";
        txttime.Text = "";
        ddldoctor.SelectedIndex = 0;
        ddlstatus.SelectedIndex = 0;
     
    }
    protected void btn_save_Click(object sender, EventArgs e)
    {
        try
        {
                
        con.Open();
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "insert into Appointment(DoctorID,PatientID,AppointDate,BookingDate,Appointment_Status,Bill_Amount,Bill_Status,DoctorNotification,PatientNotification,FeedbackStatus,Purpose,Timeslot,LastVisitDate,ReqId) values('" + ddldoctor.SelectedValue + "', '" + lbl_Id.Text + "', '" + Convert.ToDateTime(txtappointdate.Text) + "', '" + lbl_booking_date.Text + "', '" + ddlstatus.SelectedValue + "', '" + lbl_bill.Text + "', 'Paid','1','1','0','" + lbl_problem.Text + "','"+txttime.Text+"','"+DateTime.Today+"','"+ lbl_Req.Text + "')";
        cmd.ExecuteNonQuery();     
        Alert();
        UpdateNewAppointmentStatus(ddlstatus.SelectedValue.ToString());
            con.Close();
            All_Clear();
            AlertMsg("Appointment Added Successfuly");
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Pop", "$('#addeditcategory').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();", true);

        }
        catch (Exception ex)
        {
        }
    }
    private void AlertMsg(string s)
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append("alert('" + s + "');");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AddShowModalScript", sb.ToString(), false);
    }
    public void UpdateNewAppointmentStatus(string status)
    {
        string AppointId = Request.QueryString["id"].ToString();
        string PatientId = Request.QueryString["Appointid"].ToString();
     
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "Update NewAppointment_Time set Appointment_Status='"+status+ "' where AptId='"+ AppointId + "' and PatientID='"+ PatientId + "'";
        cmd.ExecuteNonQuery();
      
    }
   
    private void Alert()
    {
        string sms_owner = "Dear" + lbl_Name.Text + "For Your AppointMent confirmed with " + ddldoctor.SelectedValue + " on " + txtappointdate.Text + " at " + txttime.Text + ",Please Check All Details from your Dashboard  From: Dcare Online Appointment Team";
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
    private void FillDoctor()
    {
        SqlCommand cmd = new SqlCommand("Select * from DoctorMaster ", con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);       
        DataTable dt = new DataTable();
        da.Fill(dt);
      
        if (dt.Rows.Count > 0)
        {
            ddldoctor.Items.Clear();
            ddldoctor.DataSource = dt;
            ddldoctor.DataTextField = "Doctor_Name";
            ddldoctor.DataValueField = "id";
            ddldoctor.DataBind();

            ddldoctor.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select", "0"));
        }
        else
        {
            ddldoctor.Items.Clear();
            ddldoctor.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select", "0"));
        }
    }
}