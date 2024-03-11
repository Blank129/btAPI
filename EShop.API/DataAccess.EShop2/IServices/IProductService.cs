using DataAccess.EShop2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EShop.IServices
{
    public interface IProductService
    {
        Task<List<Product>> GetProducts();
        Task<Product> GetProductById(GetProductByIdRequestData requestData);
        Task<ReturnData> Product_InsertUpdate(Product product);
        Task<ReturnData> Product_Delete(ProductDeleteRequestData requestData);
    }
}
