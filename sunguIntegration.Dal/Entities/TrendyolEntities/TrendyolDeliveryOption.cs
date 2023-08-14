using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Globalization;
using System.ComponentModel.DataAnnotations;

namespace sunguIntegration.Dal.Entities
{
    public class TrendyolDeliveryOption
    {

        [Key]
        public int Id { get; set; }
        public int TrendyolId { get; set; }

        [JsonProperty("deliveryDuration")]
        public long DeliveryDuration { get; set; }

        [JsonProperty("fastDeliveryType")]
        public string FastDeliveryType { get; set; }
    }

}

