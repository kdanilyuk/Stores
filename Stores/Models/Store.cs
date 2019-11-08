using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace StoresChain.Models
{
    [Serializable]
    public class Store
    {
        [Key]
        [JsonProperty(PropertyName = "store_id")]
        public int StoreId { get; set; }

        [JsonProperty(PropertyName = "store_name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "address")]
        public string Address { get; set; }

        [JsonProperty(PropertyName = "opening_time")]
        public string OpeningTime { get; set; }

        [JsonProperty(PropertyName = "closing_time")]
        public string ClosingTime { get; set; }
    }
}
