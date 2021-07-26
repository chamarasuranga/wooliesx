using Woolies.Exercise.Application.Contracts.Infrastructure;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Woolies.Exercise.Application.Features.Products.Queries.GetTrollyTotal
{
    public class GetTrollyTotalHandler : IRequestHandler<GetTrollyTotalQuery, decimal>
    {
        private readonly IProductsClient _productsClient;
        private readonly IProductSortingServiceBuilder _productSortingServiceBuilder;

        public GetTrollyTotalHandler(IProductsClient productsService, IProductSortingServiceBuilder productSortingServiceBuilder)
        {
            this._productsClient = productsService;
            this._productSortingServiceBuilder = productSortingServiceBuilder;
        }

        public async Task<decimal> Handle(GetTrollyTotalQuery request, CancellationToken cancellationToken)
        {
            var products = await _productsClient.GetAllProductDtos();

            //var productsSortingService = this._productSortingServiceBuilder.GetProductSortingService(request.SortOption.Value);

            //var sortedProducts = await productsSortingService.Sort(products);

            return 0;
        }
    }
}
