using System;

namespace sunguIntegration.DTO.RequestDTO
{
    public class ItemsDTO
    {
        public TrendyolProductRequestDTO[] items { get; set; }

    }

    public class TrendyolProductRequestDTO
    {
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
        public DeliveryOptionDTO deliveryOption { get; set; }
        public ImageDTO[] images { get; set; }
        public AttributeDTO[] attributes { get; set; }
    }

    public class DeliveryOptionDTO
    {

        public long deliveryDuration { get; set; }
        public string fastDeliveryType { get; set; }
    }

    public class ImageDTO
    {
        public Uri url { get; set; }

    }

    public class AttributeDTO
    {

        public long? attributeValueId { get; set; }
        public string customAttributeValue { get; set; }
    }
}

