using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using sunguIntegration.Dal.Entities;
using static Azure.Core.HttpHeader;

namespace sunguIntegration.Dal.Models
{
    public partial class BatchResultResponse
    {
        [Key]
        public int Id { get; set; }
        [JsonProperty("batchRequestId")]
        public string BatchRequestId { get; set; }

        [JsonProperty("items")]
        public IList<Item> Items { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("creationDate")]
        public long CreationDate { get; set; }

        [JsonProperty("lastModification")]
        public long LastModification { get; set; }

        [JsonProperty("sourceType")]
        public string SourceType { get; set; }

        [JsonProperty("itemCount")]
        public long ItemCount { get; set; }

        [JsonProperty("failedItemCount")]
        public long FailedItemCount { get; set; }

        [JsonProperty("batchRequestType")]
        public string BatchRequestType { get; set; }
    }

    public partial class Item
    {
        [Key]
        public int Id { get; set; }
        [JsonProperty("requestItem")]
        public RequestItem RequestItem { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("failureReasons")]
        [NotMapped]
        public string[] FailureReasonsArray { set { FailureReasons = String.Join(", ", value);  } }

        public string FailureReasons { get; set; }
    }

    public partial class RequestItem
    {
        [Key]
        public int Id { get; set; }
        [JsonProperty("product")]
        public TrendyolProduct Product { get; set; }

        [JsonProperty("barcode")]
        public string Barcode { get; set; }
    }

    
}

