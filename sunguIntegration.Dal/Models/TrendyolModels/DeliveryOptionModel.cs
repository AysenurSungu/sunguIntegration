using System;
using Newtonsoft.Json;

namespace sunguIntegration.Dal.Models
{
	public class DeliveryOptionModel
	{
        public int id { get; set; }
        public int trendyolId { get; set; }
        public long deliveryDuration { get; set; }
        public string fastDeliveryType { get; set; }
        
    }
}

