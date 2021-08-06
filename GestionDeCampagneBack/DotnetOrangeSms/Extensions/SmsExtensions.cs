using DotnetOrangeSms.Models;
using System.Net;
using System.Threading.Tasks;
using static DotnetOrangeSms.Extensions.ResponseHelper;

namespace DotnetOrangeSms.Extensions
{
    public static class SmsExtensions
    {
        public static async Task<Result<string>> SendSms(this SmsClient smsClient, string message, string from, string to,string senderName = "")
        {
            var sms = new SendSmsModel
            {
                SenderName = senderName,
                SmsMessageRequest = new SmsMessageRequest
                {
                    Sender = $"tel:+{from}",
                    Recipient = $"tel:+{to}",
                    SmsTextMessage = new SmsTextMessage
                    {
                        Message = message
                        
                    }
                }
            };
            var response = await smsClient.PostAsync(sms, $"smsmessaging/v1/outbound/tel%3A%2B{from}/requests");
            if(response.code == HttpStatusCode.Created)
                return new Result<string>(true, string.Empty, response.result);
            return GetError<string>(response);

        }

       
    }
}
