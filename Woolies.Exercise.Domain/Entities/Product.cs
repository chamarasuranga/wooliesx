using System;
using System.Collections.Generic;
using System.Text;

namespace Woolies.Exercise.Domain.Entities
{
    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public long Quantity { get; set; }
    }
}
