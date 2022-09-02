﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Net;
using System.IO;

namespace FINALBRIGHTPROJECT.ViewModel.BrightModel
{
    public class SMS
    {
        string sms_sent_date = DateTime.Now.ToShortDateString();
        int error_notification = 0;

        public int Error_notification
        {
            get { return error_notification; }
            set { error_notification = value; }
        }
        public string SmsSentdate
        {
            get { return sms_sent_date; }
            set { sms_sent_date = value; }
        }
        private string sending_sms(string url)
        {
            WebResponse Res = default(WebResponse);
            WebRequest Req = default(WebRequest);
            string result = null;
            try
            {
                Req = System.Net.HttpWebRequest.Create(url);
                Res = Req.GetResponse();
                StreamReader strmR = new StreamReader(Res.GetResponseStream());
                result = strmR.ReadToEnd();
                strmR.Close();
            }
            catch (Exception)
            {
                throw new Exception();
            }
            return result;
        }
        public void sending_full_sms(string number, string sms)
        {
            try
            {
                string UserName = "MMvelase60@gmail.com";
                string Password = "Mthobisi";
                string LinK_String = "http://www.winsms.net/api/batchmessage.asp?User=";
                LinK_String = LinK_String + UserName + "&Password=" + Password + "&Delivery=No";
                LinK_String = LinK_String + "&Message=" + sms + "&Numbers=" + number + ";";
                sending_sms(LinK_String);
            }
            catch (Exception)
            {

            }
        }

    }
}