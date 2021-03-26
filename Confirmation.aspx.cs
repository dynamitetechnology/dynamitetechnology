using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Confirmation : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
    int tot = 0;
    string s;
    string t;
    string[] a = new string[12];
    DateTime LastDate;
    string date1 = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user"] == null)
        {
            Response.Redirect("login.aspx");
        }
        if (!Page.IsPostBack)
        {
            con.Open();
            SqlCommand cmd2 = con.CreateCommand();
            cmd2.CommandType = CommandType.Text;
            cmd2.CommandText = "select top 1 * from Appointment where PatientID='" + Session["id"].ToString() + "'order by AppointID desc";
            cmd2.ExecuteNonQuery();
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            da2.Fill(dt2);
            if (dt2.Rows.Count > 0)
            {
                LastDate = Convert.ToDateTime((dt2.Rows[0]["AppointDate"]).ToString());
                 date1 = LastDate.ToString("dd/MM/yyyy");
            }
            else
            {
                LastDate = DateTime.Now;
                 date1 = LastDate.ToString("dd/MM/yyyy");
            }
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[12] { new DataColumn("name"), new DataColumn("qly"), new DataColumn("exp"), new DataColumn("fee"), new DataColumn("images"), new DataColumn("id"), new DataColumn("Adate"), new DataColumn("ftime"), new DataColumn("Ttime"), new DataColumn("Purpose"), new DataColumn("LastVisit"), new DataColumn("cookieid") });

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

                    dt.Rows.Add(a[0].ToString(), a[1].ToString(), a[2].ToString(), a[3].ToString(), a[4].ToString(), a[5].ToString(), a[6].ToString(), a[7].ToString(), a[8].ToString(), a[9].ToString(), date1.ToString(), i.ToString());

                }
                d1.DataSource = dt;
                d1.DataBind();

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from PatientRegistration where id='" + (dt.Rows[0]["id"]).ToString() + "'";
                cmd.ExecuteNonQuery();
                DataTable dt3 = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt3);
                if (dt3.Rows.Count > 0)
                {
                    lblId.Text = (dt3.Rows[0]["id"]).ToString();
                    txtName.Text = (dt3.Rows[0]["Name"]).ToString();
                    txtPhone.Text = (dt3.Rows[0]["Phone"]).ToString();
                    txtEmail.Text = (dt3.Rows[0]["Email"]).ToString();
                    txtAge.Text = (dt3.Rows[0]["Age"]).ToString();
                    txtAddress.Text = (dt3.Rows[0]["Address"]).ToString();
                    txtCity.Text = (dt3.Rows[0]["City"]).ToString();
                    //txtProblem.Text = (dt2.Rows[0]["HealthProblem"]).ToString();
                    if ((dt3.Rows[0]["BloodGroup"]).ToString() != "")
                    {
                        ddlBloodgroup.SelectedItem.Text = (dt3.Rows[0]["BloodGroup"]).ToString();
                    }
                    if ((dt3.Rows[0]["Gender"]).ToString() != "")
                    {
                        ddlGender.SelectedItem.Text = (dt3.Rows[0]["Gender"]).ToString();
                    }

                }
            }
            else
            {
                Response.Write("<script>alert('please Book later'); window.location='Default.aspx';</script>");
            }


        }
    }
    protected void b1_Click(object sender, EventArgs e)
    {
        try
        {
            if (CheckBox1.Checked==true)
        {
            con.Open();
            SqlCommand cmd2 = con.CreateCommand();
            cmd2.CommandType = CommandType.Text;
            cmd2.CommandText = "select top 1 * from Appointment where PatientID='" + Session["id"].ToString() + "'order by AppointID desc";
            cmd2.ExecuteNonQuery();
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            da2.Fill(dt2);
            if (dt2.Rows.Count > 0)
            {
                LastDate = Convert.ToDateTime((dt2.Rows[0]["AppointDate"]).ToString());
            }
            else
            {
                LastDate = DateTime.Now;
            }
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[12] { new DataColumn("name"), new DataColumn("qly"), new DataColumn("exp"), new DataColumn("fee"), new DataColumn("images"), new DataColumn("id"), new DataColumn("Adate"), new DataColumn("ftime"), new DataColumn("Ttime"), new DataColumn("Purpose"), new DataColumn("LastVisit"), new DataColumn("cookieid") });

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

                    dt.Rows.Add(a[0].ToString(), a[1].ToString(), a[2].ToString(), a[3].ToString(), a[4].ToString(), a[5].ToString(), a[6].ToString(), a[7].ToString(), a[8].ToString(), txtProblem.Text, LastDate, i.ToString());

                }
                foreach (DataRow dr2 in dt.Rows)
                {

                    Response.Cookies["cookies"].Value = dr2["name"].ToString() + "&" + dr2["qly"].ToString() + "&" + dr2["exp"].ToString() + "&" + dr2["fee"].ToString() + "&" + dr2["images"].ToString() + "&" + dr2["id"].ToString() + "&" + dr2["Adate"].ToString() + "&" + dr2["ftime"].ToString() + "&" + dr2["Ttime"].ToString() + "&" + dr2["Purpose"].ToString() + "&" + dr2["LastVisit"].ToString() + "&" + dr2["cookieid"].ToString();
                    Response.Cookies["cookies"].Expires = DateTime.Now.AddDays(1);

                }
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update PatientRegistration set Name='" + txtName.Text + "',Phone='" + txtPhone.Text + "',Address='" + txtAddress.Text + "',City='" + txtCity.Text + "',Email='" + txtEmail.Text + "',Age='" + txtAge.Text + "',BloodGroup='" + ddlBloodgroup.SelectedValue + "',Gender='" + ddlGender.SelectedValue + "' where id='" + lblId.Text + "'";
                cmd.ExecuteNonQuery();
                con.Close();

                Response.Redirect("patient/paykun.aspx");
            }
            else
            {
                Label1.Text = "Please Accept Terms & Condition !!";
            }
        }

    }
        catch (Exception ex)
        {

        }
    }
}