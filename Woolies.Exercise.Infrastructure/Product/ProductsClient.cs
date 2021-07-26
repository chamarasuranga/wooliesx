using Woolies.Exercise.Application.Contracts.Infrastructure;
using Woolies.Exercise.Application.Features.Products;
using Woolies.Exercise.Application.Features.Products.Queries;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Woolies.Exercise.Infrastructure;

namespace Woolies.Exercise.Infrastructure.Product
{
    public class ProductsClient : IProductsClient
    {
        private readonly HttpClient _httpClient;
        private readonly AppSettings _appSettings;

        public ProductsClient(HttpClient httpClient, IOptions<AppSettings> appSettings)
        {
            _httpClient = httpClient;
            _appSettings = appSettings.Value;
        }


        public async Task<List<ProductDto>> GetAllProductDtos()
        {
            var responseString = await _httpClient.GetStringAsync($"{_appSettings.WooliesxResourcesUrl}/products?token={_appSettings.WooliesxToken}");

            var products = JsonConvert.DeserializeObject<List<ProductDto>>(responseString);
            return products;
        }

     


        public async Task<List<CustomerPurchase>> GetProductsShopperistory()
        {
            var responseString = await _httpClient.GetStringAsync($"{_appSettings.WooliesxResourcesUrl}/shopperHistory?token={_appSettings.WooliesxToken}");

            var customerPurchases = JsonConvert.DeserializeObject<List<CustomerPurchase>>(responseString);
            return customerPurchases;
        }


        public async Task<decimal> GetTrollytotal(GetTrollyTotalQuery query)
        {
            var json = JsonConvert.SerializeObject(query);

            var body= new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync($"{_appSettings.WooliesxResourcesUrl}/trolleyCalculator?token={_appSettings.WooliesxToken}", body);

            string result = response.Content.ReadAsStringAsync().Result;
           
            return decimal.Parse(result);
        }


    }
}
