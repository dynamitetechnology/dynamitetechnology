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

public partial class Registration : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void BtnSignup_Click(object sender, EventArgs e)
    {
        try
        {
            string register=Check(txtPhone.Text);
        if(register=="Yes")
        {
            GenerateOTP();
          
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into PatientRegistration(Name,Email,Phone,Password,Address,City,Gender,Age,BloodGroup,Images,State,Pincode,Country,FatherName) values('" + txtName.Text + "','" + "" + "','" + txtPhone.Text + "','" + lblotp.Text + "','" + "" + "','" + "" + "','" + "" + "','" + "" + "','" + "" + "',' ~/ProfileImages/patient.jpg' ,'" + "" + "','" + "" + "','" + "" + "','" + "" + "')";
            cmd.ExecuteNonQuery();
            con.Close();

            Label1.Text = "SignUp Completed Succesfully.Password is sent on Mobile No";
            string sms_owner = "Dear " + txtName.Text + ", You Successfully SignUp with DCare. Password is " + lblotp.Text + " From: Dcare Online Appointment Team";
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

            txtName.Text = "";
            txtPhone.Text = "";
        }
        else
        {
            Label1.Text = "This Mobile No Already Registered !!";
            txtName.Text = "";
            txtPhone.Text = "";
        }
    }
        catch (Exception ex)
        {

        }
       
    }
    protected void GenerateOTP()
    {

        string numbers = "1234567890";
        string characters = numbers;

        int length = 5;
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
    protected string Check(string no)
    {
        string validation = string.Empty;
        try
        {
            
        con.Open();
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "SELECT * from PatientRegistration where Phone='"+no+"'";
        cmd.ExecuteNonQuery();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        if(dt.Rows.Count>0)
        {
            validation = "Not";
        }
        else
        {
            validation = "Yes";
        }
       
        }
        catch (Exception ex)
        {

        }
        return validation;
    }
   
}