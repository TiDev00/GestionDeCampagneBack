using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace DotnetOrangeSms.Models.Errors
{
    public class AuthenticationError
    {
       [JsonProperty("error")]
       public string Error { get; }

       [JsonProperty("error_description")]
       public string Description { get; }
    }
}
