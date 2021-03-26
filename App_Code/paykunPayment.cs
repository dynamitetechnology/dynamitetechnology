using Paykun.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;




namespace Paykun
{
    public class PaykunPayment
    {

        private string GatewayUrlProduction = "https://checkout.paykun.com/payment";
        private string GatewayUrlSandbox = "https://sandbox.paykun.com/payment";
        private string PageTitle = "Processing Payment...";

        private string MerchantId;
        private string AccessToken;
        private string EncryptionKey;
        private bool IsLive;
        private string udf_1;
        private string udf_2;
        private string udf_3;
        private string udf_4;
        private string udf_5;

        PkOrder OrderDetails;
        PkCustomer CustomerDetails;
        PkAddress ShippingAddress;
        PkAddress BillingAddress;

        public PaykunPayment(string _mid, string _accessToken, string _encryptionKey, bool _isLive = true)
        {
            this.MerchantId = _mid;
            this.AccessToken = _accessToken;
            this.EncryptionKey = _encryptionKey;
            this.IsLive = _isLive;

            // Initialize Optional Details
            this.ShippingAddress = new PkAddress("", "", "", "", "");
            this.BillingAddress = new PkAddress("", "", "", "", "");
        }

        public void InitOrder(string _orderId, double _amount, string _productName, string _successUrl, string _failureUrl)
        {

            this.OrderDetails = new PkOrder(_orderId, _amount, _productName, _successUrl, _failureUrl);
        }

        public void AddCustomer(string _name, string _email, string _mono)
        {
            this.CustomerDetails = new PkCustomer(_name, _email, _mono);
        }

        public void AddShippingAddress(string _addressString, string _country, string _state, string _city, string _pincode)
        {
            this.ShippingAddress = new PkAddress(_addressString, _country, _state, _city, _pincode);
        }

        public void AddBillingAddress(string _addressString, string _country, string _state, string _city, string _pincode)
        {
            this.BillingAddress = new PkAddress(_addressString, _country, _state, _city, _pincode);
        }

        public void SetCustomField(string c1, string c2, string c3, string c4, string c5)
        {

            this.udf_1 = c1;
            this.udf_2 = c2;
            this.udf_3 = c3;
            this.udf_4 = c4;
            this.udf_5 = c5;

        }

        public PkCustomForm getRequestData()
        {

            PkCustomForm requestData = new PkCustomForm();
            Dictionary<string, string> _encData = new Dictionary<string, string>();
            _encData.Add("order_no", this.OrderDetails.OrderId);
            _encData.Add("product_name", this.OrderDetails.ProductName);
            _encData.Add("amount", this.OrderDetails.OrderAmount.ToString());
            _encData.Add("success_url", this.OrderDetails.SuccessUrl);
            _encData.Add("failure_url", this.OrderDetails.FailureUrl);
            _encData.Add("customer_name", this.CustomerDetails.CustomerName);
            _encData.Add("customer_email", this.CustomerDetails.CustomerEmail);
            _encData.Add("customer_phone", this.CustomerDetails.CustomerMobileNumber);
            _encData.Add("shipping_address", this.ShippingAddress.AddressString);
            _encData.Add("shipping_city", this.ShippingAddress.City);
            _encData.Add("shipping_state", this.ShippingAddress.State);
            _encData.Add("shipping_country", this.ShippingAddress.Country);
            _encData.Add("shipping_zip", this.ShippingAddress.PinCode);
            _encData.Add("billing_address", this.BillingAddress.AddressString);
            _encData.Add("billing_city", this.BillingAddress.City);
            _encData.Add("billing_state", this.BillingAddress.State);
            _encData.Add("billing_country", this.BillingAddress.Country);
            _encData.Add("billing_zip", this.BillingAddress.PinCode);
            _encData.Add("udf_1", String.IsNullOrEmpty(this.udf_1) ? "" : this.udf_1);
            _encData.Add("udf_2", String.IsNullOrEmpty(this.udf_2) ? "" : this.udf_2);
            _encData.Add("udf_3", String.IsNullOrEmpty(this.udf_3) ? "" : this.udf_3);
            _encData.Add("udf_4", String.IsNullOrEmpty(this.udf_4) ? "" : this.udf_4);
            _encData.Add("udf_5", String.IsNullOrEmpty(this.udf_5) ? "" : this.udf_5);

            string DataString = this.GenerateDataString(_encData);
            string EncryptedReqData = (new Crypto()).Encrypt(DataString, this.EncryptionKey);

            requestData.encryptedRequest = EncryptedReqData;
            requestData.gatewayURL = this.IsLive ? this.GatewayUrlProduction : this.GatewayUrlSandbox;
            requestData.merchantId = this.MerchantId;
            requestData.accessToken = this.AccessToken;
            return requestData;
        }

        public void setCustomField(string c1, string c2, string c3, string c4, string c5)
        {

            this.udf_1 = c1;
            this.udf_2 = c2;
            this.udf_3 = c3;
            this.udf_4 = c4;
            this.udf_5 = c5;

        }

        public string Submit()
        {
            Dictionary<string, string> _encData = new Dictionary<string, string>();
            _encData.Add("order_no", this.OrderDetails.OrderId);
            _encData.Add("product_name", this.OrderDetails.ProductName);
            _encData.Add("amount", this.OrderDetails.OrderAmount.ToString());
            _encData.Add("success_url", this.OrderDetails.SuccessUrl);
            _encData.Add("failure_url", this.OrderDetails.FailureUrl);
            _encData.Add("customer_name", this.CustomerDetails.CustomerName);
            _encData.Add("customer_email", this.CustomerDetails.CustomerEmail);
            _encData.Add("customer_phone", this.CustomerDetails.CustomerMobileNumber);
            _encData.Add("shipping_address", this.ShippingAddress.AddressString);
            _encData.Add("shipping_city", this.ShippingAddress.City);
            _encData.Add("shipping_state", this.ShippingAddress.State);
            _encData.Add("shipping_country", this.ShippingAddress.Country);
            _encData.Add("shipping_zip", this.ShippingAddress.PinCode);
            _encData.Add("billing_address", this.BillingAddress.AddressString);
            _encData.Add("billing_city", this.BillingAddress.City);
            _encData.Add("billing_state", this.BillingAddress.State);
            _encData.Add("billing_country", this.BillingAddress.Country);
            _encData.Add("billing_zip", this.BillingAddress.PinCode);
            _encData.Add("udf_1", String.IsNullOrEmpty(this.udf_1) ? "" : this.udf_1);
            _encData.Add("udf_2", String.IsNullOrEmpty(this.udf_2) ? "" : this.udf_2);
            _encData.Add("udf_3", String.IsNullOrEmpty(this.udf_3) ? "" : this.udf_3);
            _encData.Add("udf_4", String.IsNullOrEmpty(this.udf_4) ? "" : this.udf_4);
            _encData.Add("udf_5", String.IsNullOrEmpty(this.udf_5) ? "" : this.udf_5);

            string DataString = this.GenerateDataString(_encData);
            string EncryptedReqData = (new Crypto()).Encrypt(DataString, this.EncryptionKey);

            string FormString = this.PrepareForm(EncryptedReqData);

            return FormString;
        }

        private string GenerateDataString(Dictionary<string, string> _data)
        {
            string _dataString = "";

            foreach (KeyValuePair<string, string> _item in _data)
            {
                _dataString = _dataString + _item.Key + "::" + _item.Value + ";";
            }

            _dataString = _dataString.TrimEnd(';');

            return _dataString;
        }

        private string PrepareForm(string _encryptedRequest)
        {
            string postUrl = IsLive ? this.GatewayUrlProduction : this.GatewayUrlSandbox;

            return @"<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Strict//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd'>
                    <html lang='en'>
                    <head>
	                    <title>{this.PageTitle}</title>
	                    <meta http-equiv='content-type' content='text/html;charset=utf-8'>
                    </head>
                    <body>
                    <div>
	                    Processing your payment, please wait...
                    </div>
                    <form  action='" + postUrl + @"' method='post' name='server_request' target='_top' >
	                    <table width='80%' align='center' border='0' cellpadding='0' cellspacing='0'>
		                    <tr>
			                    <td><input type='hidden' name='encrypted_request' id='encrypted_request' value='" + _encryptedRequest + @"' /></td>
		                    </tr>
		                    <tr>
			                    <td><input type='hidden' name='merchant_id' id='merchant_id' value='" + this.MerchantId + @"' /></td>
		                    </tr>
		                    <tr>
			                    <td><input type='hidden' name='access_token' id='access_token' value='" + this.AccessToken + @"'></td>
		                    </tr>
	                    </table>
                    </form>
                    </body>
                    <script type='text/javascript'>
	                    document.server_request.submit();
                    </script>
                    </html>";
        }

        public TransactionStatusRes GetTransactionStatus(string reqId)
        {

            string EndPoint = "https://api.paykun.com/v1/merchant/transaction/";

            // Post JSON
            using (var httpClientHandler = new HttpClientHandler())
            {
                //httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
                System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12 | System.Net.SecurityProtocolType.Tls11 | System.Net.SecurityProtocolType.Tls;

                using (var client = new HttpClient(httpClientHandler))
                {

                    client.DefaultRequestHeaders.Add("MerchantId", this.MerchantId);
                    client.DefaultRequestHeaders.Add("AccessToken", this.AccessToken);

                    var result = client.GetAsync(EndPoint + reqId).Result;
                    string resultContent = result.Content.ReadAsStringAsync().Result;

                    Newtonsoft.Json.JsonSerializerSettings settings = new Newtonsoft.Json.JsonSerializerSettings();
                    settings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
                    try
                    {
                        TransactionStatusRes _res = Newtonsoft.Json.JsonConvert.DeserializeObject<TransactionStatusRes>(resultContent, settings);

                        return _res;
                    }
                    catch (Exception ae)
                    {
                        return null;
                    }
                }
            }

        }
    }

    class PkOrder
    {

        public double OrderAmount;
        public string ProductName;
        public string SuccessUrl;
        public string FailureUrl;
        public string OrderId;

        public PkOrder(string _orderId, double _orderAmount, string _productName, string _successUrl, string _failureUrl)
        {
            this.OrderId = _orderId;
            this.OrderAmount = _orderAmount;
            this.ProductName = _productName;
            this.SuccessUrl = _successUrl;
            this.FailureUrl = _failureUrl;
            this.FailureUrl = _failureUrl;
        }
    }

    class PkCustomer
    {
        public string CustomerName;
        public string CustomerEmail;
        public string CustomerMobileNumber;

        public PkCustomer(string _customerName, string _customerEmail, string _customerMobileNumber)
        {
            this.CustomerName = _customerName;
            this.CustomerEmail = _customerEmail;
            this.CustomerMobileNumber = _customerMobileNumber;
        }
    }

    class PkAddress
    {
        public string AddressString;
        public string Country;
        public string State;
        public string City;
        public string PinCode;

        public PkAddress(string _addressString, string _country, string _state, string _city, string _pincode)
        {
            this.AddressString = _addressString;
            this.Country = _country;
            this.State = _state;
            this.City = _city;
            this.PinCode = _pincode;
        }
    }

    public class PkCustomForm
    {

        public string gatewayURL { get; set; }
        public string encryptedRequest { get; set; }
        public string merchantId { get; set; }
        public string accessToken { get; set; }

    }
}
