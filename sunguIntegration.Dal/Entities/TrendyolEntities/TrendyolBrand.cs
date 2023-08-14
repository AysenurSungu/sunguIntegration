using System;
using System.ComponentModel.DataAnnotations;

namespace sunguIntegration.Dal.Entities
{
	public class TrendyolBrand
	{
        [Key]
        public int Id { get; set; }
		public int TrendyolId { get; set; }
		public string Name { get; set; }
	}
}

