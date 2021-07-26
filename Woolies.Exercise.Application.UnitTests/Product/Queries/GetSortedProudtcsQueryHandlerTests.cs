using AutoMapper;

using Moq;
using Shouldly;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Woolies.Exercise.Application.Contracts.Infrastructure;
using Woolies.Exercise.Application.Features.Products;
using Xunit;

namespace GloboTicket.TicketManagement.Application.UnitTests.Categories.Queries
{
    public class GetSortedProudtcsQueryHandlerTests
    {
        
        private readonly Mock<IProductsClient> _mockProductsClient;
        private readonly Mock<IProductSortingServiceBuilder> _mockProductSortingServiceBuilder;

        public GetSortedProudtcsQueryHandlerTests()
        {
            _mockProductsClient = new Mock<IProductsClient>();
            _mockProductSortingServiceBuilder = new Mock<IProductSortingServiceBuilder>();
                       
        }

        [Fact]
        public async Task GetSortedProuductsTest()
        {
            var handler = new GetSortedProductsQueryHandler(_mockProductsClient.Object, _mockProductSortingServiceBuilder.Object);

            var result = await handler.Handle(new GetSortedProductsQuery() { SortOption=SortOptions.Ascending}, CancellationToken.None);

            result.ShouldBeOfType<List<ProductDto>>();
           
        }
    }
}
