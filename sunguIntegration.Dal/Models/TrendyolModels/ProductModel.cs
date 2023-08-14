using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Globalization;
using System.ComponentModel.DataAnnotations;

namespace sunguIntegration.Dal.Models
{
    public class ProductModel
    {
        public int id { get; set; }
        public int trendyolId { get; set; }
        public string barcode { get; set; }
        public string title { get; set; }
        public string productMainId { get; set; }
        public long brandId { get; set; }
        public long categoryId { get; set; }
        public long quantity { get; set; }
        public string stockCode { get; set; }
        public long dimensionalWeight { get; set; }
        public string description { get; set; }
        public string currencyType { get; set; }
        public double listPrice { get; set; }
        public double salePrice { get; set; }
        public long vatRate { get; set; }
        public long cargoCompanyId { get; set; }
        public DeliveryOptionModel deliveryOption { get; set; }
        public ImageModel[] images { get; set; }
        public AttributeModel[] attributes { get; set; }
    }

}