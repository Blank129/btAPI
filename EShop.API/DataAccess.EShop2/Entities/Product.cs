using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EShop2.Entities
{
    public class Product
    {
        public int ProductId { get; set; } 
        public string ProductName { get; set; }
        public int CategoryId { get; set; }
        public int Price { get; set; }
    }

    public class GetProductByIdRequestData
    {
        public int Id { get; set; }
    }
    public class ProductDeleteRequestData
    {
        public int Id { get; set; }
    }
}
