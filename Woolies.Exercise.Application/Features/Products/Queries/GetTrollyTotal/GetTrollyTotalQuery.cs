using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Woolies.Exercise.Application.Features.Products.Queries
{
    public class ProductQuantity
    {
        public string Name { get; set; }
        public long Quantity { get; set; }
    }

    public class SpecialProduct
    {
        public List<ProductQuantity> Quantities { get; set; }
        public int Total { get; set; }
    }


    public class GetTrollyTotalQuery :IRequest<decimal>
    {
        public List<ProductDto> Products { get; set; }
        public List<SpecialProduct> Specials { get; set; }
        public List<ProductQuantity> Quantities { get; set; }

    }
}
