using Woolies.Exercise.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Woolies.Exercise.Application.Features.Products
{

    public class CustomerPurchase
    {
        public int CustomerId { get; set; }
        public List<Product> Products { get; set; }
    }

    public class ProductDto
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public long Quantity { get; set; }
    }

    public enum SortOptions
    {
        Low,
        High,
        Ascending,
        Descending,
        Recommended
    }

    public class GetSortedProductsQuery : IRequest<List<ProductDto>>
    {
        public SortOptions? SortOption { get; set; }
    }
}
