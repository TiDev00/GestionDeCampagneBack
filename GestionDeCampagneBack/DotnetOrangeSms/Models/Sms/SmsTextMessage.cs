using Newtonsoft.Json;

namespace DotnetOrangeSms.Models
{
    public class SmsTextMessage
    {
        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
