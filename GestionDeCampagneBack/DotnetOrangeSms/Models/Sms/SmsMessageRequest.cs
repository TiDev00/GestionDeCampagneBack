using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetOrangeSms.Models
{
    public class SmsMessageRequest
    {
        [JsonProperty("address")]
        public string Recipient { get; set; }
        [JsonProperty("senderAddress")]
        public string Sender { get; set; }
        [JsonProperty("outboundSMSTextMessage")]
        public SmsTextMessage SmsTextMessage { get; set; }
    }
}
