using System;
using System.ComponentModel.DataAnnotations;

namespace sunguIntegration.Dal.Entities
{
	public class TrendyolUserInfo
	{
		[Key]
		public int Id { get; set; }
		public string TrendyolApi { get; set; }
        public string TrendyolSecretKey { get; set; }
        public string SupplierId { get; set; }
    }
}

