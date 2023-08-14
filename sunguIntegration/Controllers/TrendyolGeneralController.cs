using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using sunguIntegration.Dal.Entities;
using sunguIntegration.DTO.RequestDTO;
using sunguIntegration.DTO.ResponseDTO;
using sunguIntegration.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace sunguIntegration.Controllers
{
    [Route("api/[controller]")]
    public class TrendyolGeneralController : Controller
    {
        private TrendyolRestService _trendyolRestService;
        private TrendyolCategoryService _trendyolCategoryService;
        private TrendyolBrandService _trendyolBrandService;
        private TrendyolProductService _trendyolProductService;
        

        public TrendyolGeneralController(TrendyolRestService trendyolRestService,
                                         TrendyolCategoryService trendyolCategoryService,
                                         TrendyolBrandService trendyolBrandService,
                                         TrendyolProductService trendyolProductService)
        {
            _trendyolRestService = trendyolRestService;
            _trendyolCategoryService = trendyolCategoryService;
            _trendyolBrandService = trendyolBrandService;
            _trendyolProductService = trendyolProductService;

        }


        // GET: api/categories
        [HttpGet]
        [Route("getCategories")]
        public async Task<string> GetCategories()
        {
            var categoryResponse = await _trendyolRestService.Get("https://api.trendyol.com/sapigw/product-categories");
            _trendyolCategoryService.ImportJson(categoryResponse.Content);
            return categoryResponse.Content;
        }

        // GET: api/getCategoryAttributes
        [HttpGet]
        [Route("getCategoryAttributes")]
        public async Task<string> GetCategoryAttributes(int categoryId)
        {
            var categoryResponse = await _trendyolRestService.Get($"https://api.trendyol.com/sapigw/product-categories/{categoryId}/attributes");
            return categoryResponse.Content;
        }

        // GET: api/brands
        [HttpGet]
        [Route("getBrands")]
        public async Task<string> GetBrands()
        {
            var brandResponse = await _trendyolRestService.Get("https://api.trendyol.com/sapigw/brands");
            _trendyolBrandService.ImportJson(brandResponse.Content);
            return brandResponse.Content;

        }

        // POST: api/product
        [HttpPost]
        [Route("createProduct")]
        public async Task<string> CreateProduct(TrendyolProductRequestDTO productRequest)
        {
            var productResponse = await _trendyolRestService.CreateProduct(productRequest);
            return productResponse.Content;
        }

        [HttpPut]
        [Route("updateProduct")]
        public async Task<string> UpdateProduct(TrendyolProductRequestDTO productRequest)
        {
            var productResponse = await _trendyolRestService.UpdateProduct(productRequest);
            return productResponse.Content;
        }

        // DELETE: api/deleteProduct
        [HttpDelete]
        [Route("deleteProduct")]
        public async Task<string> DeleteProduct(TrendyolDeleteProductsRequestDTO deleteProductsRequest)
        {
            var deleteProductsResponse = await _trendyolRestService.DeleteProducts(deleteProductsRequest);

            var responseDto = JsonConvert.DeserializeObject<TrendyolDeleteProductsResponseDTO>(deleteProductsResponse.Content);

            return responseDto.BatchRequestId; 
        }


        // GET: api/getBatchRequestResult
        [HttpGet]
        [Route("getBatchRequestResult")]
        public async Task<TrendyolBatchRequestResponseDTO> GetBatchRequestResult(string batchRequestId)
        {
            var productResponse = await _trendyolRestService.GetWithSupplier($"products/batch-requests/{batchRequestId}");
            TrendyolBatchRequestResponseDTO batchRequestResponse = _trendyolProductService.ImportBatchRequestJson(productResponse.Content);
            return batchRequestResponse;

        }

        // GET: api/getSuppliersAddresses
        [HttpGet]
        [Route("getSuppliersAddresses")]
        public async Task<string> GetSuppliersAddresses()
        {
            var suppliersAddresses = await _trendyolRestService.GetWithSupplier("addresses");
            return suppliersAddresses.Content;
        }

        // GET: api/getProviders
        [HttpGet]
        [Route("getProviders")]
        public async Task<List<TrendyolProvider>> GetProviders()
        {
            var suppliersAddresses = await _trendyolRestService.GetProviders();
            return suppliersAddresses;
        }

        [HttpGet]
        [Route("filterProducts")]
        public async Task<TrendyolProductResponseDTO> FilterProducts(TrendyolProductFilterRequestDTO filterRequest)
        {
            var filteredProducts = await _trendyolRestService.FilterProducts(filterRequest);
            return filteredProducts;
        }

        


    }
}

