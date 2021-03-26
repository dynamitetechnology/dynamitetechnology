using System;
using System.Collections.Generic;
using System.Text;

namespace Paykun.Json
{
    public class Order
    {
        public string order_id { get; set; }
        public string product_name { get; set; }
        public double gross_amount { get; set; }
        public double gateway_fee { get; set; }
        public double tax { get; set; }
    }

    public class Customer
    {
        public string name { get; set; }
        public string email_id { get; set; }
        public string mobile_no { get; set; }
    }

    public class Shipping
    {
        public object address { get; set; }
        public object city { get; set; }
        public object state { get; set; }
        public object country { get; set; }
        public object pincode { get; set; }
    }

    public class Billing
    {
        public object address { get; set; }
        public object city { get; set; }
        public object state { get; set; }
        public object country { get; set; }
        public object pincode { get; set; }
    }

    public class Transaction
    {
        public string payment_id { get; set; }
        public string merchant_email { get; set; }
        public string merchant_id { get; set; }
        public string status { get; set; }
        public int status_flag { get; set; }
        public object payment_mode { get; set; }
        public Order order { get; set; }
        public Customer customer { get; set; }
        public Shipping shipping { get; set; }
        public Billing billing { get; set; }
        public object custom_field_1 { get; set; }
        public object custom_field_2 { get; set; }
        public object custom_field_3 { get; set; }
        public object custom_field_4 { get; set; }
        public object custom_field_5 { get; set; }
        public string date { get; set; }
        
    }

    public class Data
    {
        public string message { get; set; }
        public Transaction transaction { get; set; }
    }

    public class TransactionStatusRes
    {
        public bool status { get; set; }
        public Data data { get; set; }
        public Errors errors { get; set; }
    }

    public class Errors
    {
        public string errorMessage { get; set; }
        public string errorCode { get; set; }
        public string href { get; set; }
    }
}
