using Newtonsoft.Json;
using System;

namespace StoresChain.Models
{
    [Serializable]
    public class ValidityResponse
    {
        [JsonProperty(PropertyName = "is_successful")]
        public bool IsSuccessful { get; set; }

        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }
    }
}
