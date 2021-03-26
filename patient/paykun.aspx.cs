using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Paykun;
using Paykun.Json;

public partial class user_paykun : System.Web.UI.Page
{
    double tot = 0;
    string s;
    string t;
    string[] a = new string[12];
    string order_no;
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["user"] == null)
        {
            Response.Redirect("login.aspx");
        }

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
                tot = tot + (Convert.ToDouble(a[3].ToString()));
            }

            Session["tot"] = tot.ToString();
        }




        order_no = GetRandomPassword(10).ToString();
        Session["order_no"] = order_no.ToString();
        con.Open();
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "select * from PatientRegistration where id='" + Session["id"].ToString() + "'";
        cmd.ExecuteNonQuery();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        foreach (DataRow dr in dt.Rows)
        {

            t2.Text = dr["Name"].ToString();
            t6.Text = dr["Phone"].ToString();
            t4.Text = dr["Email"].ToString();
        }

        con.Close();
        string _name = t2.Text;
        string _email = t4.Text;
        string _mono = t6.Text;

        // Order details
        string _orderId = Session["order_no"].ToString(); // Order ID must be between 10 To 30 Characters and unique for all transactions
        string _productName = "Payment for Consulting";

        //Amount to be paid
        double _amount = Convert.ToDouble(Session["tot"]);

        //Your return success page url
        string _successUrl = "https://dcall.osrinfotech.com/patient/success.aspx"; //create url like this in your website or set existing path

        //Your return failed page url
        string _failureUrl = "https://dcall.osrinfotech.com/patient/fail.aspx"; //create url like this in your website or set existing path

        ////Mandatory
        /*   PaykunPayment _payment = new Paykun.PaykunPayment("622634925946977", "27CCD0357BB7B4BCECF1A3BB2878C0DB", "4A7C88096C78D62EFBE62ABE0E09474D", _isLive: false);*/ // Change _isLive to false for sandbox mode, While using sandbox mode you will need to provide credintials for sandbox and not of live environment
        PaykunPayment _payment = new Paykun.PaykunPayment("060806219399378", "C019A43EB7B95D4D7FA51D148DFE9B3D", "9DFD9CE5071C0413AB33028FEA4EC781", _isLive: true);
        //Mandatory
        _payment.InitOrder(_orderId, _amount, _productName, _successUrl, _failureUrl);

        //Mandatory
        _payment.AddCustomer(_name, _email, _mono);


        //Add here your shipping detail (Optional)
        //If you want to ignore the shipping or billing address, just make all the params an empty string like 

        //_payment.AddShippingAddress("address", "country", "state", "city", "pincode");

        //Add here your billing detail (Optional)
        //If you want to ignore the shipping or billing address, just make all the params an empty string like 
        //_payment.AddBillingAddress("address", "country", "state", "city", "pincode");

        //You can set your custom fields here. for ex. you can set order id for which this transaction is initiated
        //You will get the same order id when you will call the method  _payment.GetTransactionStatus(_reqId)
        _payment.SetCustomField(_orderId, "", "", "", "");

        /**
         * if you want to render your custom form then use _payment.getRequestData(), this will return you with all the require params for the request.
         * create form from the 'PkCustomForm' object and make it auto submit or as per your requirements
         * */
        //PkCustomForm requestData = _payment.getRequestData();

        /*To render the direct form*/
        string _res = _payment.Submit();
        formCode.InnerHtml = _res;
            //_res => use this html to render default payment form. if you want custom form then
            // uncomment this line of code and comment out submit method
            //PkCustomForm requestData = _payment.getRequestData(); ==> For custom form    
            //Message = _res;
            //Response.Write("<form action='https://sandbox.paykun.com/payment' method='post' name='_payment' id='_payment'>");
            //Response.Write("<input type='hidden' name='cmd' value='_xclick'>");
            //Response.Write("<input type='hidden' name='business' value='City Medical And General Store'>");
            //Response.Write("<input type='hidden' name='currency_code' value='INR'>");
            //Response.Write("<input type='hidden' name='item_name' value='payment for purchase'>");
            //Response.Write("<input type='hidden' name='item_number' value='0'>");
            //Response.Write("<input type='hidden' name='amount' value='" + Session["tot"].ToString() + "'>");
            //Response.Write("<input type='hidden' name='return' value='http://localhost:49947/user/payment_success.aspx?order=" + order_no.ToString() + "'>");
            //Response.Write("</form>");

            //Response.Write("<script type='text/javascript'>");
            //Response.Write("document.getElementById('_payment').submit();");
            //Response.Write("</script>");

        }
        catch (Exception ex)
        {
            ex.ToString();
        }

    }
    public static string GetRandomPassword(int length)
    {
        char[] chars = "abcdefghijklmnopqrstuvwxyz1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
        string password = string.Empty;
        Random random = new Random();

        for (int i = 0; i < length; i++)
        {
            int x = random.Next(1, chars.Length);
            //For avoiding Repetation of Characters
            if (!password.Contains(chars.GetValue(x).ToString()))
                password += chars.GetValue(x);
            else
                i = i - 1;
        }
        return password;
    }
}