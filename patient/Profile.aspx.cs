using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class patient_Profile : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);

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
             
                lblname.Text = (dt.Rows[0]["Name"]).ToString();
                lbladdress.Text = (dt.Rows[0]["Address"]).ToString();
                lblcity.Text = (dt.Rows[0]["Phone"]).ToString();
                Image2.ImageUrl = dt.Rows[0]["Images"].ToString();
               txtName.Text= (dt.Rows[0]["Name"]).ToString();
                txtfather.Text = (dt.Rows[0]["FatherName"]).ToString();
                txtaddress.Text = (dt.Rows[0]["Address"]).ToString();
                txtcity.Text = (dt.Rows[0]["City"]).ToString();
                txtcountry.Text = (dt.Rows[0]["Country"]).ToString();
                txtphone.Text = (dt.Rows[0]["Phone"]).ToString();
                txtpin.Text = (dt.Rows[0]["Pincode"]).ToString();
                txtstate.Text = (dt.Rows[0]["State"]).ToString();
                txtemail.Text = (dt.Rows[0]["Email"]).ToString();
                txtage.Text = (dt.Rows[0]["Age"]).ToString();
                ddlBloodgroup.SelectedValue= (dt.Rows[0]["BloodGroup"]).ToString();
                ddlGender.SelectedValue = (dt.Rows[0]["Gender"]).ToString();
                Image1.ImageUrl= dt.Rows[0]["Images"].ToString();
            }

            else
            {
                lblname.Text = "";
                lbladdress.Text = "";
                lblcity.Text = "";
            }
           

        }
    }
        catch (Exception ex)
        {
            ex.ToString();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            string logoimage = Image1.ImageUrl;
        con.Open();
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "update PatientRegistration set Name='" + txtName.Text + "',Phone='" + txtphone.Text + "',Address='" + txtaddress.Text + "',City='" + txtcity.Text + "',Email='" + txtemail.Text + "',Age='" + txtage.Text + "',BloodGroup='" + ddlBloodgroup.SelectedValue + "',Gender='" + ddlGender.SelectedValue + "',State='"+txtstate.Text+"',Pincode='"+ txtpin .Text+ "', Country='"+txtcountry.Text+"', FatherName='"+txtfather.Text+ "',Images='"+logoimage+"'  where id='" + Session["id"].ToString() + "'";
        cmd.ExecuteNonQuery();
        con.Close();
        Clear();
}
        catch (Exception ex)
        {
            ex.ToString();
        }
    }
    public void Clear()
    {
        txtfather.Text = "";
        txtName.Text = "";
        txtphone.Text = "";
        txtpin.Text = "";
        txtstate.Text = "";
        txtemail.Text = "";
        txtcity.Text = "";
        txtage.Text = "";
        txtaddress.Text = "";
        txtcountry.Text = "";
    }
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        Image1.ImageUrl = addlogo();
        string imageurl = Image1.ImageUrl;
        Image2.ImageUrl = imageurl;
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
            string path = Server.MapPath("/ProfileImages/");
            FileUpload1.PostedFile.SaveAs(path + FileUpload1.FileName);
            HttpContext.Current.Session["ImagePath"] = Convert.ToString("/ProfileImages/" + FileUpload1.FileName);
            imageloc = HttpContext.Current.Session["ImagePath"].ToString();
            return imageloc;
        }
        else
        {
        }

        return "";

    }
}