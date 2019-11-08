using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace StoresChain.Models
{
    [Serializable]
    public class Product
    {
        [Key]
        [JsonProperty(PropertyName = "product_id")]
        public int ProductId { get; set; }

        [JsonProperty(PropertyName = "product_name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "store_id")]
        public int StoreId { get; set; }
    }
}
