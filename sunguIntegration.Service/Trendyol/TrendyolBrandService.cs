using System;
using Azure.Core;
using Newtonsoft.Json.Linq;
using RestSharp;
using sunguIntegration.Dal;
using sunguIntegration.Dal.Models;

namespace sunguIntegration.Service
{
	public class TrendyolBrandService
	{

        private TrendyolContext _trendyolContext;

        public TrendyolBrandService(TrendyolContext trendyolContext)
        {
            _trendyolContext = trendyolContext;
        }

        public void ImportJson(string json)
        {
            JObject jsonResponse = JObject.Parse(json);

            var brands = jsonResponse["brands"].ToObject<List<BrandModel>>();

            foreach (var item in brands)
            {
                _trendyolContext.TrendyolBrands.Add(new Dal.Entities.TrendyolBrand { TrendyolId = item.id, Name = item.name });
                _trendyolContext.SaveChanges();
            }
        }
    }
}

