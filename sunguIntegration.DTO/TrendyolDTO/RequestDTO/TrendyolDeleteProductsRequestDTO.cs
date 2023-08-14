using System;
namespace sunguIntegration.DTO.RequestDTO
{
	public class TrendyolDeleteProductsRequestDTO
    {
        public ItemToDeleteDTO[] Items { get; set; }

        public class ItemToDeleteDTO
        {
            public string Barcode { get; set; }
        }
    }
}

