using Paykun;
using Paykun.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class user_success : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                string _reqId = HttpContext.Current.Request.Params.Get("payment-id").ToString(); //Get this params from paykun return url
            //string _reqId = "05745-64541-69405-82270";
            PaykunPayment _payment = new Paykun.PaykunPayment("060806219399378", "C019A43EB7B95D4D7FA51D148DFE9B3D", "9DFD9CE5071C0413AB33028FEA4EC781", _isLive: true);  // Change _isLive to false for sandbox mode, While using sandbox mode you will need to provide credintials for sandbox and not of live environment
            
            TransactionStatusRes transRes = _payment.GetTransactionStatus(_reqId);

            if (transRes.status == true)
            { //Request status

                //handle your response here
                if (transRes.data.transaction.status == "Failed")
                {
                    //Failed transaction

                }
                else if (transRes.data.transaction.status == "Initialized")
                { //Initialized transaction

                }
                else if (transRes.data.transaction.status == "Success")
                { //Success transaction
                    Response.Redirect("payment_success.aspx?Payment_Id=" + _reqId + "");
                }
            }
            else
            {
                //Request error get here your error description
                string error = transRes.errors.errorMessage;
               // Response.Redirect("patient/payment_success.aspx?Payment_Id=" + _reqId + "");
            }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
    }
  
}