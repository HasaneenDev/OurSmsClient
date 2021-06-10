using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;

namespace AppOurSms
{
    public class OurSmsClient
    {
        int userId;
        string key;
        string baseUri = "https://oursms.app";
        public OurSmsClient(int userId, string key)
        {
            this.userId = userId;
            this.key = key;
        }
        public object SendOtp(string phoneNumber, string otp)
        {
            object result;
            string url = baseUri + "/api/v1/SMS/Add/SendOtpSms";
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "application/json";
            request.Method = "POST";
            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                var json = JsonConvert.SerializeObject(new
                {
                    userId = userId,
                    key = key,
                    phoneNumber = phoneNumber,
                    otp = otp
                });
                streamWriter.Write(json);
            }
            var httpResponse = (HttpWebResponse)request.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                result = streamReader.ReadToEnd();
            }
            return result;
        }

        public object SendOneMessage(string phoneNumber, string message)
        {
            object result;
            string url = baseUri + "/api/v1/SMS/Add/SendOneSms";
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "application/json";
            request.Method = "POST";
            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                var json = JsonConvert.SerializeObject(new
                {
                    userId = userId,
                    key = key,
                    phoneNumber = phoneNumber,
                    Message = message
                });
                streamWriter.Write(json);
            }
            var httpResponse = (HttpWebResponse)request.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                result = streamReader.ReadToEnd();
            }
            return result;
        }

        public object MessageStatus(string messageId)
        {
            object result;
            string url = baseUri + "/api/v1/SMS/Get/GetStatus/" + messageId;
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "application/json";
            request.Method = "GET";
            var httpResponse = (HttpWebResponse)request.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                result = streamReader.ReadToEnd();
            }
            return result;
        }
    }

}
