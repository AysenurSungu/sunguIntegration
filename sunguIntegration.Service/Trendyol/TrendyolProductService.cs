using System;
using Newtonsoft.Json.Linq;
using sunguIntegration.Dal;
using sunguIntegration.Dal.Entities;
using sunguIntegration.Dal.Models;
using sunguIntegration.DTO.ResponseDTO;

namespace sunguIntegration.Service
{
	public class TrendyolProductService
	{
        private TrendyolContext _trendyolContext;

        public TrendyolProductService(TrendyolContext trendyolContext)
        {
            _trendyolContext = trendyolContext;
        }

        public void ImportJson(string json)
        {
            JObject jsonResponse = JObject.Parse(json);

            var products = jsonResponse["products"].ToObject<List<ProductModel>>();

            foreach (var item in products)
            {
                _trendyolContext.TrendyolProducts.Add(new Dal.Entities.TrendyolProduct 
            { 
                TrendyolId = item.id,
                Barcode = item.barcode,
                Title = item.title,
                ProductMainId = item.productMainId,
                BrandId = item.brandId,
                CategoryId = item.categoryId,
                Quantity = item.quantity,
                StockCode = item.stockCode,
                DimensionalWeight = item.dimensionalWeight,
                Description = item.description,
                CurrencyType = item.currencyType,
                ListPrice = item.listPrice,
                SalePrice = item.salePrice,
                VatRate = item.vatRate,
                CargoCompanyId = item.cargoCompanyId,
                DeliveryOption = new Dal.Entities.TrendyolDeliveryOption
                {
                    DeliveryDuration = item.deliveryOption.deliveryDuration,
                    FastDeliveryType = item.deliveryOption.fastDeliveryType
                },
                Images = item.images.Select(i => new Dal.Entities.TrendyolImage { Url = i.url }).ToArray(),
                Attributes = item.attributes.Select(a => new Dal.Entities.TrendyolAttribute
                {
                    AttributeId = a.attributeId,
                    AttributeValueId = a.attributeValueId,
                    CustomAttributeValue = a.customAttributeValue
                }).ToArray()
            });

            _trendyolContext.SaveChanges();
            }
        }


        public void CreateProduct(ProductModel productModel)
        {
            var trendyolProduct = new TrendyolProduct
            {
                TrendyolId = productModel.trendyolId,
                Barcode = productModel.barcode,
                Title = productModel.title,
                ProductMainId = productModel.productMainId,
                BrandId = productModel.brandId,
                CategoryId = productModel.categoryId,
                Quantity = productModel.quantity,
                StockCode = productModel.stockCode,
                DimensionalWeight = productModel.dimensionalWeight,
                Description = productModel.description,
                CurrencyType = productModel.currencyType,
                ListPrice = productModel.listPrice,
                SalePrice = productModel.salePrice,
                VatRate = productModel.vatRate,
                CargoCompanyId = productModel.cargoCompanyId,
                DeliveryOption = new Dal.Entities.TrendyolDeliveryOption
                {
                    DeliveryDuration = productModel.deliveryOption.deliveryDuration,
                    FastDeliveryType = productModel.deliveryOption.fastDeliveryType
                },
                Images = productModel.images.Select(i => new Dal.Entities.TrendyolImage { Url = i.url }).ToArray(),
                Attributes = productModel.attributes.Select(a => new Dal.Entities.TrendyolAttribute
                {
                    AttributeId = a.attributeId,
                    AttributeValueId = a.attributeValueId,
                    CustomAttributeValue = a.customAttributeValue
                }).ToArray()
            };

            _trendyolContext.TrendyolProducts.Add(trendyolProduct);
            _trendyolContext.SaveChanges();
        }

        public TrendyolBatchRequestResponseDTO ImportBatchRequestJson(string json)
        {
            JObject jsonResponse = JObject.Parse(json);

            var batchResultResponse = jsonResponse.ToObject<BatchResultResponse>();
            _trendyolContext.BatchResultResponses.Add(batchResultResponse);
            _trendyolContext.SaveChanges();

            return new TrendyolBatchRequestResponseDTO()
            {
                barcode = batchResultResponse.Items.First().RequestItem.Barcode,
                failureReasons = batchResultResponse.Items.First().FailureReasons,
                status = batchResultResponse.Status

          
            };

        }



    }
}

