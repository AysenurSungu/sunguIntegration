using System;
using sunguIntegration.DTO.RequestDTO;

namespace sunguIntegration.DTO
{
	public class GeneralProductRequestDTO
	{
		public string title { get; set; }
        public string name { get; set; }
        public double price { get; set; }
        
        public TrendyolProductRequestDTO trendyolFields { get; set; }


    }
}

