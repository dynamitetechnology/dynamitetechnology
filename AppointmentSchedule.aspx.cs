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

public partial class AppointmentSchedule : System.Web.UI.Page
{

    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);

    string s;
    string t;
    string[] a = new string[12];
    double tot = 0;
    double ptotal = 0;
    string IMG = "";
    int docid = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //DataTable dt = new DataTable();
            //dt.Columns.AddRange(new DataColumn[12] { new DataColumn("name"), new DataColumn("qly"), new DataColumn("exp"), new DataColumn("fee"), new DataColumn("images"), new DataColumn("id"), new DataColumn("Adate"), new DataColumn("ftime"), new DataColumn("Ttime"),  new DataColumn("Purpose"),  new DataColumn("LastVisit"), new DataColumn("cookieid") });
            //if (Request.Cookies["cookies"] != null)
            //{
            //    s = Convert.ToString(Request.Cookies["cookies"].Value);
            //    string[] strArr = s.Split('|');
            //    for (int i = 0; i < strArr.Length; i++)
            //    {
            //        t = Convert.ToString(strArr[i].ToString());
            //        string[] strArr1 = t.Split('&');
            //        for (int j = 0; j < strArr1.Length; j++)
            //        {
            //            a[j] = strArr1[j].ToString();
            //        }
            //        dt.Rows.Add(a[0].ToString(), a[1].ToString(), a[2].ToString(), a[3].ToString(), a[4].ToString(), a[5].ToString(), a[6].ToString(), a[7].ToString(), a[8].ToString(), a[9].ToString(), a[10].ToString(), i.ToString());
            //    }
            //}
            //else
            //{
            //    Response.Write("<script>alert('please select Doctor'); window.location='Default.aspx';</script>");
            //}
            //d1.DataSource = dt;
            //d1.DataBind();
            //GetContentFromGroup((dt.Rows[0]["id"]).ToString());
            //docid = Convert.ToInt32(dt.Rows[0]["id"]);

        }
        //total.Text = tot.ToString();

      

        try
        {
            string eventid = Request.QueryString["id"];
            //Find the reference of the Repeater Item.
            //RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
            //int docId = int.Parse((item.FindControl("lblId") as Label).Text);

            con.Open();
            string name = "", exp = "", qly = "", fee = "", images = "", Adate = "", ftime = "", Ttime = "", Purpose = "", Lastvisit = "";

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from DoctorMaster where id=" + eventid + "";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                name = dr["Doctor_Name"].ToString();
                exp = dr["Specialization"].ToString();
                fee = dr["Doctor_fee"].ToString();
                qly = dr["Doctor_Qualification"].ToString();
                images = dr["Doctor_Images"].ToString();
                Adate = "22/08/2020";
                ftime = "10:10 AM";
                Ttime = "10:20 AM";
                Purpose = "Treatment";
                Lastvisit = "22/08/2020";
            }
            d1.DataSource = dt;
            d1.DataBind();


            //Response.Cookies["cookies"].Value = name.ToString() + "&" + qly.ToString() + "&" + exp.ToString() + "&" + fee.ToString() + "&" + images.ToString() + "&" + docId.ToString() + "&" + Adate.ToString() + "&" + ftime.ToString() + "&" + Ttime.ToString() + "&" + Purpose.ToString() + "&" + Lastvisit.ToString();
            //Response.Cookies["cookies"].Expires = DateTime.Now.AddDays(1);


            Response.Redirect("AppointmentSchedule.aspx");

        }
        catch (Exception ex)
        {

        }

    }
    protected void b1_Click(object sender, EventArgs e)
    {
        try
        {
            double pt = 0;
        con.Open();


        String AppointDate = txtDate.Text;
        String FromTime = txtTime.Text;
        String ToTime = txtTime1.Text;
        
        DataTable dt1 = new DataTable();
        dt1.Columns.AddRange(new DataColumn[12] { new DataColumn("name"), new DataColumn("qly"), new DataColumn("exp"), new DataColumn("fee"), new DataColumn("images"), new DataColumn("id"), new DataColumn("Adate"), new DataColumn("ftime"), new DataColumn("Ttime"), new DataColumn("Purpose"), new DataColumn("LastVisit"), new DataColumn("cookieid") });
        

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

                dt1.Rows.Add(a[0].ToString(), a[1].ToString(), a[2].ToString(), a[3].ToString(), a[4].ToString(), a[5].ToString(),AppointDate.ToString(), FromTime.ToString(), ToTime.ToString() , a[9].ToString(), a[10].ToString(), i.ToString());
                
            }
           // lblavailable.Text=Availabilty(Convert.ToInt32(a[5].ToString()),txtTime.Text, txtTime1.Text);
        }
        
        foreach (DataRow dr2 in dt1.Rows)
        {

                Response.Cookies["cookies"].Value = dr2["name"].ToString() + "&" + dr2["qly"].ToString() + "&" + dr2["exp"].ToString() + "&" + dr2["fee"].ToString() + "&" + dr2["images"].ToString() + "&" + dr2["id"].ToString()+"&" +dr2["Adate"].ToString()+"&"+dr2["ftime"].ToString()+"&"+dr2["Ttime"].ToString()+"&"+ dr2["Purpose"].ToString() + "&"+dr2["LastVisit"].ToString() + "&"+dr2["cookieid"].ToString();
                Response.Cookies["cookies"].Expires = DateTime.Now.AddDays(1);
            
        }
        Session["checkoutbutton"] = "yes";
        Response.Redirect("Checkout.aspx");
    }
            catch (Exception ex)
            {

            }
    }
    
    public string GetContentFromGroup(string id)
    {
        string strcontent = string.Empty;
        string strContentConntainer = string.Empty;
        try
        {
                
        int j = 0;
        int k = 0;
        con.Open();
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "select * from DoctorMaster where id='" + id + "'";
        cmd.ExecuteNonQuery();
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(ds);
        lblOPdSchedule.Text = string.Empty;
        lblOPdSchedule.Text += "<div>";
        for (k = 0; k < ds.Tables[0].Rows.Count; k++)
        {
            lblOPdSchedule.Text += "<table  style='-webkit-border-radius: 6px; float:left;  padding: 10px 10px 10px 10px;-moz-border-radius: 6px; min-height:60px; max-height: auto; border: 0px solid #C0C0C0;cellpadding='5' width='300px'; cellspacing='20'  background-color: #f6f6f6; border-radius: 6px; -moz-border-radius: 6px; -webkit-border-radius: 6px;  position:relative;   border-collapse: collapse;'>";
            lblOPdSchedule.Text += "<tr><td align='center' style='width:100%;border: solid 0px red; '>" + GetShiftDetails(Convert.ToInt32(ds.Tables[0].Rows[k]["id"])) + "</td></tr>";
            lblOPdSchedule.Text += "</table>";

      }
        lblOPdSchedule.Text += "</div>";
        
        
        }
        catch (Exception ex)
        {

        }
        return strContentConntainer;
    }
  
    public string GetShiftDetails(int id)
    {
        
        string str = string.Empty; ;
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "SELECT FromTime, ToTime, ShiftType FROM DSchedule WHERE(Did = '" + id + "') and Is_Active=1  GROUP BY ShiftType, FromTime, ToTime";
        cmd.ExecuteNonQuery();
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(ds);
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
            {
                str += "<div style='border:solid red 0px; font-size:8px; font-family:Verdana; float:left; width:100%;'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Shift: " + Convert.ToString(ds.Tables[0].Rows[j]["ShiftType"]) + " " + "-&nbsp;" + "&nbsp;" + "" + Convert.ToString(ds.Tables[0].Rows[j]["FromTime"]) + "&nbsp;-&nbsp;" + Convert.ToString(ds.Tables[0].Rows[j]["ToTime"]) + " </br>" + DayRender(Convert.ToString(ds.Tables[0].Rows[j]["ShiftType"]), Convert.ToString(ds.Tables[0].Rows[j]["FromTime"]), Convert.ToString(ds.Tables[0].Rows[j]["ToTime"]), id) + "</div>";
            }
        }
        else
        {
            str = "<span style='font-size:11px; font-family:Verdana;'>No Schedule Found</span>";
        }


        
        return str;
    }
    public string DayRender(string shifttype, string FromTime, string Totime, int id)
    {

        var arlist1 = new ArrayList();
        arlist1.Add("1");
        arlist1.Add("2");
        arlist1.Add("3");
        arlist1.Add("4");
        arlist1.Add("5");
        arlist1.Add("6");
        arlist1.Add("7");
        string str = string.Empty;

        //SqlCommand cmd = con.CreateCommand();
        //cmd.CommandType = CommandType.Text;
        //cmd.CommandText = "SELECT FromTime, ToTime, ShiftType, did FROM DSchedule WHERE(Did = '" + id + "') and Is_Active=1 GROUP BY ShiftType, FromTime, ToTime,did";
        //cmd.ExecuteNonQuery();
        //DataSet ds = new DataSet();
        //SqlDataAdapter da = new SqlDataAdapter(cmd);
        //da.Fill(ds);
        //if (ds.Tables[0].Rows.Count > 0)
        //{
        //    for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
        //    {
        int i = 0;
        SqlCommand cmd1 = con.CreateCommand();
        cmd1.CommandType = CommandType.Text;
        cmd1.CommandText = "select dayid from DSchedule where did=" + id + " and Is_Active=1 and FromTime='" + FromTime.Trim() + "' and  ToTime='" + Totime.Trim() + "' and ShiftType=" + shifttype + "";
        cmd1.ExecuteNonQuery();
        //DataSet ds1 = new DataSet();
        DataTable dt = new DataTable();
        SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
        da1.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            for (int j=0; j<dt.Rows.Count;j++)
            {
                 i = Convert.ToInt16(dt.Rows[j]["dayid"].ToString());
                str += " " + "<a href='#' class='tooltip1' title='Available'>" + GetImages((arlist1[i-1]).ToString()) + "</a>";

            }

        }
    
                else
                {
                   GetImages((i).ToString());
                    str += " " + "<a href='#' class='preview' title='Not Available'  style='border:solid 0px red;'><img src='../../Images/DImage/" + IMG + "' alt='gallery thumbnail'></a>" + "&nbsp;";
                }
            return str;
    }
       // }
     
       
    
    public string GetImages(string DayName)
    {
        
        if(DayName.ToUpper()=="1")
        {
            IMG = "S.png";
            return "<img src='../Images/AImage/S.png' />";
        }
        else if(DayName.ToUpper() == "2")
            {
            IMG = "M.png";
            return "<img src='../Images/AImage/M.png' />";
        }
        else if (DayName.ToUpper() == "3")
        {
            IMG = "T.png";
            return "<img src='../Images/AImage/T.png' />";
        }
        else if (DayName.ToUpper() == "4")
        {
            IMG = "W.png";
            return "<img src='../Images/AImage/W.png' />";
        }
        else if (DayName.ToUpper() == "5")
        {
            IMG = "Thu.png";
            return "<img src='../Images/AImage/Thu.png' />";
        }
        else if (DayName.ToUpper() == "6")
        {
            IMG = "F.png";
            return "<img src='../Images/AImage/F.png' />";
        }
        else if (DayName.ToUpper() == "7")
        {
            IMG = "Sat.png";
            return "<img src='../Images/AImage/Sat.png' />";
        }
        else
        {
            IMG = "";
            return "";
        }
    }
    //public string Availabilty(int id,string ftime,string ttime)
    //{
    //    string str = string.Empty;
    //    var fts = TimeSpan.Parse(ftime);
    //    var tts = TimeSpan.Parse(ttime);
    //    SqlCommand cmd = con.CreateCommand();
    //    cmd.CommandType = CommandType.Text;
    //    cmd.CommandText = "SELECT FromTime, ToTime, ShiftType, did FROM DSchedule WHERE(Did = '" + id + "')  GROUP BY ShiftType, FromTime, ToTime,did";
    //    cmd.ExecuteNonQuery();
    //    DataSet ds = new DataSet();
    //    SqlDataAdapter da = new SqlDataAdapter(cmd);
    //    da.Fill(ds);
    //    if (ds.Tables[0].Rows.Count > 0)
    //    {
         
    //        var fromts = TimeSpan.Parse((ds.Tables[0].Rows[0]["FromTime"]).ToString());            
    //        var tots = TimeSpan.Parse((ds.Tables[0].Rows[0]["ToTime"]).ToString());
    //        if(fts < fromts)
    //    }
    //    else
    //    {

    //    }
    //    return "";
    //}
}