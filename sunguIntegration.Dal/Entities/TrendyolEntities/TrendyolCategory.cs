using System;
using System.ComponentModel.DataAnnotations;

namespace sunguIntegration.Dal.Entities
{
	public class TrendyolCategory
    {
        [Key]
        public int Id { get; set; }
		public int TrendyolId { get; set; }
		public string Name { get; set; }
		public int? ParentId { get; set; }
		public IEnumerable<TrendyolCategory> SubCategories { get; set; }
	}
}

