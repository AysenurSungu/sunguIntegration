using System;
using RestSharp;
using System.Web;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using System.Security.Policy;
using sunguIntegration.Dal;
using sunguIntegration.Dal.Entities;
using sunguIntegration.DTO.RequestDTO;
using sunguIntegration.DTO.ResponseDTO;

namespace sunguIntegration.Service
{
	public class TrendyolRestService
	{
        private TrendyolContext _trendyolContext;

        public TrendyolRestService(TrendyolContext trendyolContext)
        {
            _trendyolContext = trendyolContext;
        }

        
        public async Task<RestResponse> Post(string url, object? bodyObject=null)
		{
            var trendyolUserInfo = _trendyolContext.TrendyolUserInfos.First();

            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes($"{trendyolUserInfo.TrendyolApi}:{trendyolUserInfo.TrendyolSecretKey}" );
            var key = System.Convert.ToBase64String(plainTextBytes);
            var client = new RestClient(new RestClientOptions());
            var request = new RestRequest(url, Method.Post);
            request.AddHeader("Authorization", $"Basic {key}");
            request.AddHeader("user-agent", $"{trendyolUserInfo.SupplierId} - SelfIntegration");
            if(bodyObject != null)
            {
                request.AddBody(bodyObject);
            }
            RestResponse response = await client.ExecuteAsync(request);
            
            return response;
        }


        public async Task<RestResponse> Put(string url, object? bodyObject = null)
        {
            var trendyolUserInfo = _trendyolContext.TrendyolUserInfos.First();

            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes($"{trendyolUserInfo.TrendyolApi}:{trendyolUserInfo.TrendyolSecretKey}");
            var key = System.Convert.ToBase64String(plainTextBytes);
            var client = new RestClient(new RestClientOptions());
            var request = new RestRequest(url, Method.Post);
            request.AddHeader("Authorization", $"Basic {key}");
            request.AddHeader("user-agent", $"{trendyolUserInfo.SupplierId} - SelfIntegration");
            if (bodyObject != null)
            {
                request.AddBody(bodyObject);
            }
            RestResponse response = await client.ExecuteAsync(request);

            return response;
        }


        public async Task<RestResponse> Get(string url)
        {

            var trendyolUserInfo = _trendyolContext.TrendyolUserInfos.First();

            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes($"{trendyolUserInfo.TrendyolApi}:{trendyolUserInfo.TrendyolSecretKey}");
            var key = System.Convert.ToBase64String(plainTextBytes);

      
            var client = new RestClient(new RestClientOptions());
            var request = new RestRequest(url, Method.Get);
            request.AddHeader("Authorization", $"Basic {key}");
            request.AddHeader("user-agent", $"{trendyolUserInfo.SupplierId} - SelfIntegration");
            RestResponse response = await client.ExecuteAsync(request);

            return response;
        }


        public async Task<RestResponse> Delete(string url, object? bodyObject = null)
        {
            var trendyolUserInfo = _trendyolContext.TrendyolUserInfos.First();

            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes($"{trendyolUserInfo.TrendyolApi}:{trendyolUserInfo.TrendyolSecretKey}");
            var key = System.Convert.ToBase64String(plainTextBytes);
            var client = new RestClient(new RestClientOptions());
            var request = new RestRequest(url, Method.Delete);
            request.AddHeader("Authorization", $"Basic {key}");
            request.AddHeader("user-agent", $"{trendyolUserInfo.SupplierId} - SelfIntegration");
            if (bodyObject != null)
            {
                request.AddBody(bodyObject);
            }
            RestResponse response = await client.ExecuteAsync(request);

            return response;
        }

        public async Task<RestResponse> DeleteProducts(TrendyolDeleteProductsRequestDTO deleteProductsRequest)
        {
            var trendyolUserInfo = _trendyolContext.TrendyolUserInfos.First();

            var deleteProductsResponse = await Delete($"https://api.trendyol.com/sapigw/suppliers/{trendyolUserInfo.SupplierId}/v2/products", deleteProductsRequest);

            return deleteProductsResponse;
        }


        public async Task<RestResponse> CreateProduct(TrendyolProductRequestDTO productRequest)
        {

            var trendyolUserInfo = _trendyolContext.TrendyolUserInfos.First();
            var itemsDTO = new ItemsDTO();
            itemsDTO.items = new TrendyolProductRequestDTO[]
            {
                productRequest
            };

            var productesponse = await Post($"https://api.trendyol.com/sapigw/suppliers/{trendyolUserInfo.SupplierId}/v2/products", itemsDTO);
            
            return productesponse;

        }


        public async Task<RestResponse> UpdateProduct(TrendyolProductRequestDTO productRequest)
        {
            var trendyolUserInfo = _trendyolContext.TrendyolUserInfos.First();
            var itemsDTO = new ItemsDTO();
            itemsDTO.items = new TrendyolProductRequestDTO[]
            {
                productRequest
            };

            var productResponse = await Put($"https://api.trendyol.com/sapigw/suppliers/{trendyolUserInfo.SupplierId}/v2/products", itemsDTO);

            return productResponse;
        }



        /// <summary>
        /// verilen url'in başına 'https://api.trendyol.com/sapigw/suppliers/{supplierId}/' ekler
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public async Task<RestResponse> GetWithSupplier(string url)
        {

            var trendyolUserInfo = _trendyolContext.TrendyolUserInfos.First();

            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes($"{trendyolUserInfo.TrendyolApi}:{trendyolUserInfo.TrendyolSecretKey}");
            var key = System.Convert.ToBase64String(plainTextBytes);
            var client = new RestClient(new RestClientOptions());
            var request = new RestRequest($"https://api.trendyol.com/sapigw/suppliers/{trendyolUserInfo.SupplierId}/{url}", Method.Get);
            request.AddHeader("Authorization", $"Basic {key}");
            request.AddHeader("user-agent", $"{trendyolUserInfo.SupplierId} - SelfIntegration");
            RestResponse response = await client.ExecuteAsync(request);

            return response;
        }

        public async Task<List<TrendyolProvider>> GetProviders()
        {
            var allProviders = await _trendyolContext.TrendyolProviders.ToListAsync();
            return allProviders;
        }

        public async Task<TrendyolProductResponseDTO> FilterProducts(TrendyolProductFilterRequestDTO filterRequest)
        {
            var trendyolUserInfo = _trendyolContext.TrendyolUserInfos.First();
            var baseUrl = $"https://api.trendyol.com/sapigw/suppliers/{trendyolUserInfo.SupplierId}/products";

            var request = new RestRequest(baseUrl);
            request.AddParameter("approved", filterRequest.Approved);
            request.AddParameter("barcode", filterRequest.Barcode);
            request.AddParameter("startDate", filterRequest.StartDate);
            request.AddParameter("endDate", filterRequest.EndDate);
            request.AddParameter("page", filterRequest.Page);
            request.AddParameter("dateQueryType", filterRequest.DateQueryType);
            request.AddParameter("size", filterRequest.Size);
            request.AddParameter("supplierId", filterRequest.SupplierId);
            request.AddParameter("stockCode", filterRequest.StockCode);
            request.AddParameter("archived", filterRequest.Archived);
            request.AddParameter("productMainId", filterRequest.ProductMainId);
            request.AddParameter("onSale", filterRequest.OnSale);
            request.AddParameter("rejected", filterRequest.Rejected);
            request.AddParameter("blacklisted", filterRequest.Blacklisted);
            if (filterRequest.BrandIds != null && filterRequest.BrandIds.Any())
            {
                request.AddParameter("brandIds", string.Join(",", filterRequest.BrandIds));
            }

            var client = new RestClient();
            var response = await client.ExecuteAsync(request);

            TrendyolProductResponseDTO productResponse = JsonConvert.DeserializeObject<TrendyolProductResponseDTO>(response.Content);

            return productResponse;
        }

    }
}

