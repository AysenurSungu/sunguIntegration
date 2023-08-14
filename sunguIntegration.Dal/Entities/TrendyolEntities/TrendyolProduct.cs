using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Globalization;
using System.ComponentModel.DataAnnotations;

namespace sunguIntegration.Dal.Entities
{
    public class TrendyolProduct
    {
        [Key]
        public int Id { get; set; }
        public int TrendyolId { get; set; }

        [JsonProperty("barcode")]
        public string Barcode { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("productMainId")]
        public string ProductMainId { get; set; }

        [JsonProperty("brandId")]
        public long BrandId { get; set; }

        [JsonProperty("categoryId")]
        public long CategoryId { get; set; }

        [JsonProperty("quantity")]
        public long Quantity { get; set; }

        [JsonProperty("stockCode")]
        public string StockCode { get; set; }

        [JsonProperty("dimensionalWeight")]
        public long DimensionalWeight { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("currencyType")]
        public string CurrencyType { get; set; }

        [JsonProperty("listPrice")]
        public double ListPrice { get; set; }

        [JsonProperty("salePrice")]
        public double SalePrice { get; set; }

        [JsonProperty("vatRate")]
        public long VatRate { get; set; }

        [JsonProperty("cargoCompanyId")]
        public long CargoCompanyId { get; set; }

        [JsonProperty("deliveryOption")]
        public TrendyolDeliveryOption DeliveryOption { get; set; } = new TrendyolDeliveryOption() { DeliveryDuration = 1,
        FastDeliveryType = "deneme", TrendyolId = 1};

        [JsonProperty("images")]
        public IEnumerable<TrendyolImage> Images { get; set; }

        [JsonProperty("attributes")]
        public IEnumerable<TrendyolAttribute> Attributes { get; set; }
    }

}

