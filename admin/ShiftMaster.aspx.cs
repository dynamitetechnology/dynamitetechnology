using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_ShiftMaster : System.Web.UI.Page
{
    Common cls = Common.getInstance();
    SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
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
                int SchId = Convert.ToInt16(Request.QueryString["xyzabc"]);
                bindDatabyId(SchId);
                btnSave.Text = "Update";
            }
            else if (Request.QueryString["abcxyz"] != null)
            {
                Hashtable ht = new Hashtable();
                int SchId = Convert.ToInt16(Request.QueryString["abcxyz"]);
                ht.Add("SchId", SchId);
                cls.ExecuteProcedure_out("DeleteShiftbyID", ht);
                bindData();
                lblmsg.Text = "Record Deleted successfully!!!";
            }
            bindData();
        }
    }
    private void bindDatabyId(int SchId)
    {
        try
        {
            DataTable dt = new DataTable();
            Hashtable ht = new Hashtable();
            ht.Add("SchId", SchId);
            dt = cls.ExecuteProcedure_GetTable("GetShiftbyID", ht);
            if (dt.Rows.Count > 0)
            {
               txtShiftName.Text= Convert.ToString(dt.Rows[0]["ShiftName"]);
                txtTime.Text = Convert.ToString(dt.Rows[0]["FromTime"]);
                txtTime1.Text = Convert.ToString(dt.Rows[0]["ToTime"]);
              
                if (Convert.ToString(dt.Rows[0]["Is_Active"]) == "1")
                {

                    rdoactive.Checked = true;

                }
                else
                {
                    rdoinactive.Checked = true;
                }
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

            SqlCommand cmd = new SqlCommand("SELECT * from ShiftMaster ", cn);
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
        txtShiftName.Text = "";
        txtTime.Text = "";
        txtTime1.Text = "";
       
    }
    protected void btnSave_Click(object sender, EventArgs e)

    {
        int active = 0;
        try
        {
          
            if (rdoactive.Checked == true)
            {
                active = 1;
            }
            else
            {
                active = 0;
            }

            if (Mode == 0)
            {
                SqlCommand saveData = new SqlCommand("Sp_Shift_Master", cn);
                saveData.CommandType = CommandType.StoredProcedure;
                saveData.Parameters.Add(new SqlParameter("ShiftId", SqlDbType.Int)).Value = 0;
                saveData.Parameters.Add(new SqlParameter("Mode", SqlDbType.Int)).Value = Mode;           
                saveData.Parameters.Add(new SqlParameter("ShiftName", SqlDbType.NVarChar,200)).Value = txtShiftName.Text;
                saveData.Parameters.Add(new SqlParameter("FromTime", SqlDbType.NVarChar, 200)).Value = txtTime.Text;
                saveData.Parameters.Add(new SqlParameter("ToTime", SqlDbType.NVarChar, 100)).Value = txtTime1.Text;             
                saveData.Parameters.Add(new SqlParameter("active", SqlDbType.Int)).Value = active;
                cn.Close();
                cn.Open();
                saveData.ExecuteNonQuery();
                lblmsg.Text = "data saved successfully.";
                clean();
                bindData();

            }
            else if (Mode == 1)
            {
                int SchId = Convert.ToInt16(Request.QueryString["xyzabc"]);
                SqlCommand saveData = new SqlCommand("Sp_Time_Schedule", cn);
                saveData.CommandType = CommandType.StoredProcedure;
                saveData.Parameters.Add(new SqlParameter("ShiftId", SqlDbType.Int)).Value = SchId;
                saveData.Parameters.Add(new SqlParameter("Mode", SqlDbType.Int)).Value = Mode;
                saveData.Parameters.Add(new SqlParameter("ShiftName", SqlDbType.NVarChar, 200)).Value = txtShiftName.Text;
                saveData.Parameters.Add(new SqlParameter("FromTime", SqlDbType.NVarChar, 200)).Value = txtTime.Text;
                saveData.Parameters.Add(new SqlParameter("ToTime", SqlDbType.NVarChar, 100)).Value = txtTime1.Text;
                saveData.Parameters.Add(new SqlParameter("active", SqlDbType.Int)).Value = active;
                cn.Close();
                cn.Open();

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
}