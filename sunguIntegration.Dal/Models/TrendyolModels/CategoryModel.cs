using System;
namespace sunguIntegration.Dal.Models
{
	public class CategoryModel
	{
            public int id { get; set; }
            public string name { get; set; }
            public int? parentId { get; set; }
            public IEnumerable<CategoryModel> subCategories { get; set; }
        
    }
}

