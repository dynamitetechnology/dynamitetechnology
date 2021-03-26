using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class doctor_call : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
     
    }
   
    protected void Button1_Click(object sender, EventArgs e)
    {
        //string name = Session["Name"].ToString();
        //string message = txtsend.Text;
        //string my = name + "::" + message;

        //Application["message"] = Application["message"] + my + Environment.NewLine;
        //txtsend.Text = "";
    }
}