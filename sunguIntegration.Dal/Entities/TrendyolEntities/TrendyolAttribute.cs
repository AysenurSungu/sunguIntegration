using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Globalization;
using System.ComponentModel.DataAnnotations;

namespace sunguIntegration.Dal.Entities
{
    public class TrendyolAttribute
    {
        [Key]
        public int Id { get; set; }
        public int TrendyolId { get; set; }

        [JsonProperty("attributeId")]
        public long AttributeId { get; set; }

        [JsonProperty("attributeValueId", NullValueHandling = NullValueHandling.Ignore)]
        public long? AttributeValueId { get; set; }

        [JsonProperty("customAttributeValue", NullValueHandling = NullValueHandling.Ignore)]
        public string CustomAttributeValue { get; set; } 

    }

}

