using Newtonsoft.Json;

namespace DotnetOrangeSms.Models
{
    public class SendSmsModel
    {
        [JsonProperty("outboundSMSMessageRequest")]
        public SmsMessageRequest SmsMessageRequest { get; set; } 
       
        [JsonProperty("senderName")]
        public string SenderName { get; set; }
    }
}
