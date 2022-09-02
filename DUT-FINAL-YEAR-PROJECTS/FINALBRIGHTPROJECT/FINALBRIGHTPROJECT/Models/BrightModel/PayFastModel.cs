using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;

namespace FINALBRIGHTPROJECT.ViewModel.BrightModel
{
    public class PayFastModel
    {
        [Key]
        public int Id { get; set; }
        public string cmd { get; set; }
        public string merchant_id { get; set; }
        public string merchant_key { get; set; }
        public string m_payment_id { get; set; }
        public string payment_mode { get; set; }
        public string name_first { get; set; }
        public string name_last { get; set; }
        public string email_address { get; set; }
        public string site { get; set; }
        public string return_url { get; set; }
        public string cancel_url { get; set; }
        public string notify_url { get; set; }
        public string item_name { get; set; }
        public decimal amount { get; set; }
        public string actionURL { get; set; }

        public PayFastModel(bool useSandbox)
        {
            this.cmd = "_donation";
            this.payment_mode = ConfigurationManager.AppSettings["PaymentMode"];
            this.merchant_id = ConfigurationManager.AppSettings["PF_MerchantID"];
            this.merchant_key = ConfigurationManager.AppSettings["PF_MerchantKey"];
            this.cancel_url = ConfigurationManager.AppSettings["PF_CancelURL"];
            this.return_url = ConfigurationManager.AppSettings["PF_ReturnURL"];

            if (useSandbox)
            {
                this.actionURL = ConfigurationManager.AppSettings["test_url"];
            }
            else
            {
                this.actionURL = ConfigurationManager.AppSettings["Prod_url"];
            }

            // We can add parameters here, for example OrderId, CustomerId, etc....
            this.notify_url = ConfigurationManager.AppSettings["notify_url"];
            // We can add parameters here, for example OrderId, CustomerId, etc....

        }


    }
}