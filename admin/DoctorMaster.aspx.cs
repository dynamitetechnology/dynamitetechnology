using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;

public partial class admin_DoctorMaster : System.Web.UI.Page
{
    Common cls = Common.getInstance();
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
    public static int Mode;
    public int RId;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Admin"] == null)
        {
            Response.Redirect("Adminlogin.aspx");
        }
        if (!IsPostBack)
        {

            Mode = 0;
            if (Request.QueryString["xyzabc"] != null)
            {
                Mode = 1;
                int DId = Convert.ToInt16(Request.QueryString["xyzabc"]);
                bindDatabyId(DId);
                btnSave.Text = "Update";
            }
            else if (Request.QueryString["abcxyz"] != null)
            {
                Hashtable ht = new Hashtable();
                int DId = Convert.ToInt16(Request.QueryString["abcxyz"]);
                ht.Add("DId", DId);
                cls.ExecuteProcedure_out("DeleteDoctorbyID", ht);
                bindData();
                lblmsg.Text = "Record Deleted successfully!!!";
            }
            bindData();
        }
    }
    private void bindDatabyId(int DId)
    {
        try
        {
            DataTable dt = new DataTable();
            Hashtable ht = new Hashtable();
            ht.Add("DId", DId);
            dt = cls.ExecuteProcedure_GetTable("GetDoctorbyID", ht);
            if (dt.Rows.Count > 0)
            {
                txtName.Text= Convert.ToString(dt.Rows[0]["Doctor_Name"]);
                txtpassword.Text = Convert.ToString(dt.Rows[0]["Password"]);
                txtphone.Text = Convert.ToString(dt.Rows[0]["Phone"]);
                txtpin.Text = Convert.ToString(dt.Rows[0]["Pincode"]);
                txtquali.Text = Convert.ToString(dt.Rows[0]["Doctor_Qualification"]);
                txtspecialization.Text = Convert.ToString(dt.Rows[0]["Specialization"]);
                txtstate.Text = Convert.ToString(dt.Rows[0]["State"]);
                txtfee.Text = Convert.ToString(dt.Rows[0]["Doctor_fee"]);
                txtexp.Text = Convert.ToString(dt.Rows[0]["Doctor_Experience"]);
                txtemail.Text = Convert.ToString(dt.Rows[0]["Email"]);
                txtcountry.Text = Convert.ToString(dt.Rows[0]["Country"]);
                txtcity.Text = Convert.ToString(dt.Rows[0]["City"]);
                txtaward.Text = Convert.ToString(dt.Rows[0]["Award"]);
                txtaddress2.Text = Convert.ToString(dt.Rows[0]["Address2"]);
                txtaddress1.Text = Convert.ToString(dt.Rows[0]["Address1"]);
                Image1.ImageUrl= Convert.ToString(dt.Rows[0]["Doctor_Images"]); 
                ddlGender.Text= Convert.ToString(dt.Rows[0]["Gender"]);

                //if (Convert.ToString(dt.Rows[0]["Is_Active"]) == "1")
                //{

                //    rdoactive.Checked = true;

                //}
                //else
                //{
                //    rdoinactive.Checked = true;
                //}
            }
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
        }
    }
    private void bindData()
    {
        try
        {

            SqlCommand cmd = new SqlCommand("SELECT * from DoctorMaster ", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                dlRoutDirectory.DataSource = ds.Tables[0];
                dlRoutDirectory.DataBind();
            }

        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
        }
    }


    private void clean()
    {
        txtaddress1.Text = "";
        txtaddress2.Text = "";
        txtaward.Text = "";
        txtcity.Text = "";
        txtcountry.Text = "";
        txtemail.Text = "";
        txtexp.Text = "";
        txtfee.Text = "";
        txtName.Text = "";
        txtpassword.Text = "";
        txtphone.Text = "";
        txtpin.Text = "";
        txtquali.Text = "";
        txtspecialization.Text = "";
        txtstate.Text = "";
        
    }
    protected void btnSave_Click(object sender, EventArgs e)

    {
        //int active = 0;
        try
        {

            //if (rdoactive.Checked == true)
            //{
            //    active = 1;
            //}
            //else
            //{
            //    active = 0;
            //}
            string logoimage = Image1.ImageUrl;
            if (logoimage == "")
            {
                logoimage = "~/ProfileImages/doctor.jpg";
            }
            if (Mode == 0)
            {
                SqlCommand saveData = new SqlCommand("Sp_Doctor_Master", con);
                saveData.CommandType = CommandType.StoredProcedure;
                saveData.Parameters.Add(new SqlParameter("id", SqlDbType.Int)).Value = 0;
                saveData.Parameters.Add(new SqlParameter("Mode", SqlDbType.Int)).Value = Mode;
                saveData.Parameters.Add(new SqlParameter("Doctor_Name", SqlDbType.NVarChar, 100)).Value = txtName.Text;
                saveData.Parameters.Add(new SqlParameter("Phone", SqlDbType.NVarChar, 100)).Value = txtphone.Text;
                saveData.Parameters.Add(new SqlParameter("Address1", SqlDbType.NVarChar, 200)).Value = txtaddress1.Text;
                saveData.Parameters.Add(new SqlParameter("Address2", SqlDbType.NVarChar, 200)).Value = txtaddress2.Text;
                saveData.Parameters.Add(new SqlParameter("City", SqlDbType.NVarChar, 100)).Value = txtcity.Text;
                saveData.Parameters.Add(new SqlParameter("Email", SqlDbType.NVarChar, 100)).Value = txtemail.Text;
                saveData.Parameters.Add(new SqlParameter("Gender", SqlDbType.NVarChar, 100)).Value = ddlGender.SelectedValue;
                saveData.Parameters.Add(new SqlParameter("State", SqlDbType.NVarChar, 100)).Value = txtstate.Text;
                saveData.Parameters.Add(new SqlParameter("Pincode", SqlDbType.NVarChar, 100)).Value = txtpin.Text;
                saveData.Parameters.Add(new SqlParameter("Country", SqlDbType.NVarChar, 100)).Value = txtcountry.Text;
                saveData.Parameters.Add(new SqlParameter("Doctor_Images", SqlDbType.NVarChar, 100)).Value = logoimage;
                saveData.Parameters.Add(new SqlParameter("Award", SqlDbType.NVarChar, 100)).Value = txtaward.Text;
                saveData.Parameters.Add(new SqlParameter("Doctor_Experience", SqlDbType.NVarChar, 100)).Value = txtexp.Text;
                saveData.Parameters.Add(new SqlParameter("Doctor_Qualification", SqlDbType.NVarChar, 100)).Value = txtquali.Text;
                saveData.Parameters.Add(new SqlParameter("Specialization", SqlDbType.NVarChar, 100)).Value = txtspecialization.Text;
                saveData.Parameters.Add(new SqlParameter("Doctor_fee", SqlDbType.NVarChar, 100)).Value = txtfee.Text;
                saveData.Parameters.Add(new SqlParameter("Password", SqlDbType.NVarChar, 100)).Value = txtpassword.Text;
                saveData.Parameters.Add(new SqlParameter("Status", SqlDbType.NVarChar, 100)).Value = 1;
                con.Close();
                con.Open();
                saveData.ExecuteNonQuery();
                lblmsg.Text = "data saved successfully.";
                clean();
                bindData();

            }
            else if (Mode == 1)
            {
                int DId = Convert.ToInt16(Request.QueryString["xyzabc"]);
                SqlCommand saveData = new SqlCommand("Sp_Doctor_Master", con);
                saveData.CommandType = CommandType.StoredProcedure;
                saveData.Parameters.Add(new SqlParameter("id", SqlDbType.Int)).Value = DId;
                saveData.Parameters.Add(new SqlParameter("Mode", SqlDbType.Int)).Value = Mode;
                saveData.Parameters.Add(new SqlParameter("Doctor_Name", SqlDbType.NVarChar,100)).Value = txtName.Text;
                saveData.Parameters.Add(new SqlParameter("Phone", SqlDbType.NVarChar,100)).Value = txtphone.Text;
                saveData.Parameters.Add(new SqlParameter("Address1", SqlDbType.NVarChar, 200)).Value = txtaddress1.Text;
                saveData.Parameters.Add(new SqlParameter("Address2", SqlDbType.NVarChar, 200)).Value = txtaddress2.Text;
                saveData.Parameters.Add(new SqlParameter("City", SqlDbType.NVarChar,100)).Value = txtcity.Text;
                saveData.Parameters.Add(new SqlParameter("Email", SqlDbType.NVarChar, 100)).Value = txtemail.Text;
                saveData.Parameters.Add(new SqlParameter("Gender", SqlDbType.NVarChar, 100)).Value = ddlGender.SelectedValue;
                saveData.Parameters.Add(new SqlParameter("State", SqlDbType.NVarChar, 100)).Value = txtstate.Text;
                saveData.Parameters.Add(new SqlParameter("Pincode", SqlDbType.NVarChar, 100)).Value = txtpin.Text;
                saveData.Parameters.Add(new SqlParameter("Country", SqlDbType.NVarChar, 100)).Value = txtcountry.Text;
                saveData.Parameters.Add(new SqlParameter("Doctor_Images", SqlDbType.NVarChar, 100)).Value = logoimage;
                saveData.Parameters.Add(new SqlParameter("Award", SqlDbType.NVarChar, 100)).Value = txtaward.Text;
                saveData.Parameters.Add(new SqlParameter("Doctor_Experience", SqlDbType.NVarChar, 100)).Value = txtexp.Text;
                saveData.Parameters.Add(new SqlParameter("Doctor_Qualification", SqlDbType.NVarChar, 100)).Value = txtquali.Text;
                saveData.Parameters.Add(new SqlParameter("Specialization", SqlDbType.NVarChar, 100)).Value = txtspecialization.Text;
                saveData.Parameters.Add(new SqlParameter("Doctor_fee", SqlDbType.NVarChar, 100)).Value = txtfee.Text;
                saveData.Parameters.Add(new SqlParameter("Password", SqlDbType.NVarChar, 100)).Value = txtpassword.Text;
                saveData.Parameters.Add(new SqlParameter("Status", SqlDbType.NVarChar, 100)).Value = 1;
               
                con.Close();
                con.Open();

                saveData.ExecuteNonQuery();
                lblmsg.Text = "data saved successfully.";
                clean();
                bindData();

            }
        }
        catch (Exception ex)
        {
            lblmsg.Text = " Unable to save Data";
        }
    }
    
 
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        Image1.ImageUrl = addlogo();
        string imageurl = Image1.ImageUrl;
       
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