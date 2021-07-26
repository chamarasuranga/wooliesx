using Woolies.Exercise.Application.Contracts.Infrastructure;
using Woolies.Exercise.Application.Features.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Woolies.Exercise.Infrastructure.Product
{

    public class SortByNameDecending : IProductSortingService
    {
        public SortByNameDecending()
        {
            this.SortOption = SortOptions.Descending;
        }

        public Task<List<ProductDto>> Sort(List<ProductDto> products)
        {
            return Task.FromResult(products.OrderByDescending(a => a.Name).ToList());
        }

        public SortOptions SortOption { get; set; }
    }

    public class SortByNameAscending : IProductSortingService
    {
        public SortByNameAscending()
        {
            this.SortOption = SortOptions.Ascending;
        }
        public Task<List<ProductDto>> Sort(List<ProductDto> products)
        {
            return Task.FromResult(products.OrderBy(a => a.Name).ToList());
        }

        public SortOptions SortOption { get; set; }
    }

    public class SortByPriceHighToLow : IProductSortingService
    {
        public SortByPriceHighToLow()
        {
            this.SortOption = SortOptions.Low;
        }

        public Task<List<ProductDto>> Sort(List<ProductDto> products)
        {
            return Task.FromResult(products.OrderByDescending(a => a.Price).ToList());
        }

        public SortOptions SortOption { get; set; }
    }

    public class SortByPriceLowToHigh : IProductSortingService
    {
        public SortByPriceLowToHigh()
        {
            this.SortOption = SortOptions.High;
        }

        public Task<List<ProductDto>> Sort(List<ProductDto> products)
        {
            return Task.FromResult(products.OrderBy(a => a.Price).ToList());
        }

        public SortOptions SortOption { get; set; }
    }


    public class SortByShopperHistory : IProductSortingService
    {
        private readonly IProductsClient _productsClient;
        public SortByShopperHistory(IProductsClient productsClient)
        {
            this.SortOption = SortOptions.Recommended;
            _productsClient = productsClient;
        }

        public async Task<List<ProductDto>> Sort(List<ProductDto> products)
        {
            var customerPurchases = await _productsClient.GetProductsShopperistory();

            foreach (var item in customerPurchases)
            {
                foreach (var ShopperPurchase in item.Products)
                {
                    var product = products.First(a => a.Name == ShopperPurchase.Name);

                    product.Quantity = product.Quantity + ShopperPurchase.Quantity;
                }
            }

            return products.OrderByDescending(a => a.Quantity).ToList(); 
        }

        public SortOptions SortOption { get; set; }
    }



    public class ProductSortingServiceBuilder : IProductSortingServiceBuilder
    {
        private readonly List<IProductSortingService> _productSortingServices;
        public ProductSortingServiceBuilder(IProductsClient productsClient)
        {
            _productSortingServices = new List<IProductSortingService>();
            _productSortingServices.Add(new SortByNameAscending());
            _productSortingServices.Add(new SortByNameDecending());
            _productSortingServices.Add(new SortByPriceHighToLow());
            _productSortingServices.Add(new SortByPriceLowToHigh());
            _productSortingServices.Add(new SortByShopperHistory(productsClient));
        }

        public IProductSortingService GetProductSortingService(SortOptions sortOption)
        {
            var sortingSerivce = _productSortingServices.Where(a => a.SortOption == sortOption).FirstOrDefault();

            if (sortingSerivce == null) throw new Exception($"Sorting Not impelemented for sortOption :{sortOption.ToString()}");

            return sortingSerivce;
        }
    }
}
