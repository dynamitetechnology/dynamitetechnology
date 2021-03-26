using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class doctor_Profile : System.Web.UI.Page
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
            DataTable dt = new DataTable();
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from DoctorMaster where id='" + Session["id"].ToString() + "'";
            cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {

                lblname.Text = (dt.Rows[0]["Doctor_Name"]).ToString();
                lblspe.Text = (dt.Rows[0]["Specialization"]).ToString();
                Image2.ImageUrl = dt.Rows[0]["Doctor_Images"].ToString();
                txtName.Text = (dt.Rows[0]["Doctor_Name"]).ToString();              
                txtaddress1.Text = (dt.Rows[0]["Address1"]).ToString();
                txtaddress2.Text = (dt.Rows[0]["Address2"]).ToString();
                txtcity.Text = (dt.Rows[0]["City"]).ToString();
                txtcountry.Text = (dt.Rows[0]["Country"]).ToString();
                txtphone.Text = (dt.Rows[0]["Phone"]).ToString();
                txtpin.Text = (dt.Rows[0]["Pincode"]).ToString();
                txtstate.Text = (dt.Rows[0]["State"]).ToString();
                txtemail.Text = (dt.Rows[0]["Email"]).ToString();             
                ddlGender.SelectedValue = (dt.Rows[0]["Gender"]).ToString();
                txtexp.Text = (dt.Rows[0]["Doctor_Experience"]).ToString();
                txtspecialization.Text = (dt.Rows[0]["Specialization"]).ToString();
                txtquali.Text = (dt.Rows[0]["Doctor_Qualification"]).ToString();
                txtaward.Text = (dt.Rows[0]["Award"]).ToString();
                txtfee.Text = (dt.Rows[0]["Doctor_fee"]).ToString(); 
                Image1.ImageUrl = dt.Rows[0]["Doctor_Images"].ToString();
            }

            else
            {
                lblname.Text = "";              
                txtName.Text = "";
                txtaddress1.Text = "";
                txtaddress2.Text = "";
                txtcity.Text = "";
                txtcountry.Text = "";
                txtphone.Text = "";
                txtpin.Text = "";
                txtstate.Text = "";
                txtemail.Text = "";
                ddlGender.SelectedValue = "";
                txtexp.Text = "";
                txtspecialization.Text = "";
                txtquali.Text = "";
                txtaward.Text = "";
                txtfee.Text = "";
               
            }


        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string logoimage = Image1.ImageUrl;
        con.Open();
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "update DoctorMaster set Doctor_Name='" + txtName.Text + "',Phone='" + txtphone.Text + "',Address1='" + txtaddress1.Text + "',Address2='" + txtaddress2.Text + "',City='" + txtcity.Text + "',Email='" + txtemail.Text + "',Gender='" + ddlGender.SelectedValue + "',State='" + txtstate.Text + "',Pincode='" + txtpin.Text + "', Country='" + txtcountry.Text + "', Doctor_Images='" + logoimage + "',Award='"+txtaward.Text+ "',Doctor_Experience='"+txtexp.Text+ "',Doctor_Qualification='"+txtquali.Text+ "',Specialization='"+txtspecialization.Text+ "',Doctor_fee='"+txtfee.Text+ "'  where id='" + Session["id"].ToString() + "'";
        cmd.ExecuteNonQuery();
        con.Close();
        Clear();
    }
    public void Clear()
    {
        txtName.Text = "";
        txtaddress1.Text = "";
        txtaddress2.Text = "";
        txtcity.Text = "";
        txtcountry.Text = "";
        txtphone.Text = "";
        txtpin.Text = "";
        txtstate.Text = "";
        txtemail.Text = "";
        ddlGender.SelectedValue = "0";
        txtexp.Text = "";
        txtspecialization.Text = "";
        txtquali.Text = "";
        txtaward.Text = "";
        txtfee.Text = "";
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