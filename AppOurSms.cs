using Newtonsoft.Json;
using System.IO;
using System.Net;
using Microsoft.Extensions.DependencyInjection;

namespace AppOurSms
{

    public static class ServiceCollectionExtension
    {
        public static void AddOurSms(this IServiceCollection service,int userId,string key)
        {
            service.AddSingleton<IOurSmsClient>(new OurSmsClient(userId, key));
        }
    }

    public interface IOurSmsClient
    {
        object SendOtp(string phoneNumber, string otp);
        object SendOneMessage(string phoneNumber, string message);
        object MessageStatus(string messageId);
    }
    public class OurSmsClient:IOurSmsClient
    {
        private readonly int _userId;
        private readonly string _key;
        private const string BaseUri = "https://oursms.app";

        public OurSmsClient(int userId, string key)
        {
            _userId = userId;
            _key = key;
        }
        public object SendOtp(string phoneNumber, string otp)
        {
            object result;
            const string url = BaseUri + "/api/v1/SMS/Add/SendOtpSms";
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "application/json";
            request.Method = "POST";
            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                var json = JsonConvert.SerializeObject(new
                {
                    userId = _userId,
                    key = _key,
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
            const string url = BaseUri + "/api/v1/SMS/Add/SendOneSms";
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "application/json";
            request.Method = "POST";
            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                var json = JsonConvert.SerializeObject(new
                {
                    userId = _userId,
                    key = _key,
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
            var url = BaseUri + "/api/v1/SMS/Get/GetStatus/" + messageId;
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
