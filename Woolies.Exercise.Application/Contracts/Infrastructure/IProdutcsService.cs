using Woolies.Exercise.Application.Features.Products;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Woolies.Exercise.Application.Contracts.Infrastructure
{
    public  interface IProductsClient
    {
        public  Task<List<ProductDto>> GetAllProductDtos();

        public  Task<List<CustomerPurchase>> GetProductsShopperistory();

    }


    public interface IProductSortingService
    {
        public Task<List<ProductDto>> Sort(List<ProductDto> products);

        public SortOptions SortOption { get; set; }

    }

    public interface IProductSortingServiceBuilder
    {
        public IProductSortingService GetProductSortingService(SortOptions sortOption);
    }
}
