using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Globalization;
using System.ComponentModel.DataAnnotations;

namespace sunguIntegration.Dal.Entities
{
    public class TrendyolImage
    {

        [Key]
        public int Id { get; set; }
        public int TrendyolId { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }
    }
}

