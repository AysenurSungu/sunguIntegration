using System;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace sunguIntegration.Dal.Entities
{
	public class TrendyolProvider
	{

        [Key]
        public int Id { get; set; }
        public int TrendyolId { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("taxNumber")]
        public string TaxNumber { get; set; }
    }
}

