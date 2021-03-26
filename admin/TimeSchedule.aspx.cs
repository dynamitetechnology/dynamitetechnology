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

public partial class admin_TimeSchedule : System.Web.UI.Page
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
           
            FillDay();
            FillShift();
            FillDoctor();
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
                cls.ExecuteProcedure_out("DeleteSchedulebyID", ht);
                bindData();
                lblmsg.Text = "Record Deleted successfully!!!";
            }
            bindData();
        }
    }
    private void FillDay()
    {
        SqlCommand cmd = new SqlCommand("Select * from DayMaster ", cn);
        SqlDataAdapter da = new SqlDataAdapter(cmd);      
        DataTable dt = new DataTable();
        da.Fill(dt);

        if (dt.Rows.Count > 0)
        {
            ddlday.Items.Clear();
            ddlday.DataSource = dt;
            ddlday.DataTextField = "Day";
            ddlday.DataValueField = "DayId";
            ddlday.DataBind();
            ddlday.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select", "0"));
        }
        else
        {
            ddlday.Items.Clear();
            ddlday.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select", "0"));
        }


    }
    private void FillShift()
    {
        SqlCommand cmd = new SqlCommand("Select * from ShiftMaster ", cn);
        SqlDataAdapter da = new SqlDataAdapter(cmd);      
        DataTable dt = new DataTable();
        da.Fill(dt);     
        if (dt.Rows.Count > 0)
        {
            ddlshift.Items.Clear();
            ddlshift.DataSource = dt;
            ddlshift.DataTextField = "ShiftName";
            ddlshift.DataValueField = "ShiftId";
            ddlshift.DataBind();

            ddlshift.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select", "0"));
        }
        else
        {
            ddlshift.Items.Clear();
            ddlshift.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select", "0"));
        }
    }
    private void FillDoctor()
    {
        SqlCommand cmd = new SqlCommand("Select * from DoctorMaster ", cn);
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
    private void bindDatabyId(int SchId)
    {
        try
        {
            DataTable dt = new DataTable();
            Hashtable ht = new Hashtable();
            ht.Add("SchId", SchId);
            dt = cls.ExecuteProcedure_GetTable("GetSchedulebyID", ht);
            if (dt.Rows.Count > 0)
            {
                ddldoctor.SelectedValue = Convert.ToString(dt.Rows[0]["Did"]);
                ddlshift.SelectedValue = Convert.ToString(dt.Rows[0]["ShiftType"]);
                txtTime.Text = Convert.ToString(dt.Rows[0]["FromTime"]);
                txtTime1.Text = Convert.ToString(dt.Rows[0]["ToTime"]);
                ddlday.SelectedValue = Convert.ToString(dt.Rows[0]["dayid"]);
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

            SqlCommand cmd = new SqlCommand("SELECT dbo.DoctorMaster.Doctor_Name,dbo.DSchedule.SchId,dbo.ShiftMaster.ShiftName, dbo.DayMaster.Day, dbo.DSchedule.ToTime, dbo.DSchedule.FromTime FROM dbo.DSchedule INNER JOIN  dbo.DayMaster ON dbo.DSchedule.dayid = dbo.DayMaster.DayId INNER JOIN dbo.ShiftMaster ON dbo.DSchedule.ShiftType = dbo.ShiftMaster.ShiftId INNER JOIN dbo.DoctorMaster ON dbo.DSchedule.Did= dbo.DoctorMaster.id ", cn);
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
        ddldoctor.SelectedValue = "0";
        ddlshift.SelectedValue = "0";
        txtTime.Text = "";
        txtTime1.Text = "";
        ddlday.SelectedValue = "0";



    }
    protected void btnSave_Click(object sender, EventArgs e)

    {
        int active = 0;
        try
        {
            int shift = Convert.ToInt32(ddlshift.SelectedItem.Value.ToString());
            int dayid = Convert.ToInt32(ddlday.SelectedItem.Value.ToString());
            int Did = Convert.ToInt32(ddldoctor.SelectedItem.Value.ToString());
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
                SqlCommand saveData = new SqlCommand("Sp_Time_Schedule", cn);
                saveData.CommandType = CommandType.StoredProcedure;
                saveData.Parameters.Add(new SqlParameter("SchId", SqlDbType.Int)).Value = 0;
                saveData.Parameters.Add(new SqlParameter("Mode", SqlDbType.Int)).Value = Mode;
                saveData.Parameters.Add(new SqlParameter("DId", SqlDbType.Int)).Value = Did;
                saveData.Parameters.Add(new SqlParameter("ShiftType", SqlDbType.Int)).Value = shift;
                saveData.Parameters.Add(new SqlParameter("FromTime", SqlDbType.NVarChar, 200)).Value = txtTime.Text;
                saveData.Parameters.Add(new SqlParameter("ToTime", SqlDbType.NVarChar, 100)).Value = txtTime1.Text;
                saveData.Parameters.Add(new SqlParameter("dayid", SqlDbType.Int)).Value = dayid;
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
                saveData.Parameters.Add(new SqlParameter("SchId", SqlDbType.Int)).Value = SchId;
                saveData.Parameters.Add(new SqlParameter("Mode", SqlDbType.Int)).Value = Mode;
                saveData.Parameters.Add(new SqlParameter("DId", SqlDbType.Int)).Value = Did;
                saveData.Parameters.Add(new SqlParameter("ShiftType", SqlDbType.Int)).Value = shift;
                saveData.Parameters.Add(new SqlParameter("FromTime", SqlDbType.NVarChar, 200)).Value = txtTime.Text;
                saveData.Parameters.Add(new SqlParameter("ToTime", SqlDbType.NVarChar, 100)).Value = txtTime1.Text;
                saveData.Parameters.Add(new SqlParameter("dayid", SqlDbType.Int)).Value = dayid;
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
    protected void ddlshift_Changed(object sender, EventArgs e)
    {
        SqlCommand cmd = new SqlCommand("Select FromTime,ToTime from ShiftMaster where ShiftId='" + ddlshift.SelectedValue + "' ", cn);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        // DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        da.Fill(dt);
        txtTime.Text = dt.Rows[0]["FromTime"].ToString();
        txtTime1.Text = dt.Rows[0]["ToTime"].ToString();

    }
}