using System;
using Newtonsoft.Json;

namespace sunguIntegration.Dal.Models
{
	public class ImageModel
	{
        public int id { get; set; }
        public int trendyolId { get; set; }
        public Uri url { get; set; }
    }
}

