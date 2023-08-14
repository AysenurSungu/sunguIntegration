using System;
using Azure.Core;
using Newtonsoft.Json.Linq;
using RestSharp;
using sunguIntegration.Dal;
using sunguIntegration.Dal.Models;

namespace sunguIntegration.Service
{
	public class TrendyolCategoryService
	{

		private TrendyolContext _trendyolContext;

        public TrendyolCategoryService(TrendyolContext trendyolContext)
        {
            _trendyolContext = trendyolContext;
        }

        public void ImportJson(string json)
        {
            JObject jsonResponse = JObject.Parse(json);

            var categories = jsonResponse["categories"].ToObject<List<CategoryModel>>();

            foreach (var item in categories)
            {
                _trendyolContext.TrendyolCategories.Add(new Dal.Entities.TrendyolCategory { TrendyolId = item.id, Name = item.name, ParentId = item.parentId });
                _trendyolContext.SaveChanges();
            }
        }
    }
}

