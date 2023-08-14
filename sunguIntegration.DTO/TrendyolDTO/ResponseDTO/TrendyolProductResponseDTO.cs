using System;
namespace sunguIntegration.DTO.RequestDTO
{
	public class TrendyolProductResponseDTO
	{
        public class ProductResponse
        {
            public int TotalElements { get; set; }
            public int TotalPages { get; set; }
            public int Page { get; set; }
            public int Size { get; set; }
            public List<ProductContentDTO> Content { get; set; }
        }

        public class ProductContentDTO
        {
            public string Id { get; set; }
            public bool Approved { get; set; }
            public bool Archived { get; set; }
            public string ProductCode { get; set; }
            public string BatchRequestId { get; set; }
            public long SupplierId { get; set; }
            public long CreateDateTime { get; set; }
            public long LastUpdateDate { get; set; }
            public string Gender { get; set; }
            public string Brand { get; set; }
            public string Barcode { get; set; }
            public string Title { get; set; }
            public string CategoryName { get; set; }
            public string ProductMainId { get; set; }
            public string Description { get; set; }
            public string StockUnitType { get; set; }
            public int Quantity { get; set; }
            public double ListPrice { get; set; }
            public double SalePrice { get; set; }
            public int VatRate { get; set; }
            public double DimensionalWeight { get; set; }
            public string StockCode { get; set; }
            public DeliveryOptionDTO DeliveryOption { get; set; }
            public List<ImageDTO> Images { get; set; }
            public List<AttributeDTO> Attributes { get; set; }
        }

        public class DeliveryOptionDTO
        {
            public int DeliveryDuration { get; set; }
            public string FastDeliveryType { get; set; }
        }

        public class ImageDTO
        {
            public string Url { get; set; }
        }

        public class AttributeDTO
        {
            public int AttributeId { get; set; }
            public string AttributeName { get; set; }
            public int AttributeValueId { get; set; }
            public string AttributeValue { get; set; }
        }

    }
}

