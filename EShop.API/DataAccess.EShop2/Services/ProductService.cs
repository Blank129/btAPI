using DataAccess.EShop.IServices;
using DataAccess.EShop2.Entities;
using DataAccess.EShop2.EntitiesFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EShop.Services
{
    public class ProductService : IProductService
    {
        private EShopDbContext _Context;
        public ProductService(EShopDbContext context)
        {
            _Context = context;
        }

        public async Task<Product> GetProductById(GetProductByIdRequestData requestData)
        {
            try
            {
                var list = _Context.Product.ToList();
                var product = list.Where(s => s.ProductId == requestData.Id).FirstOrDefault();
                return product;               
            }
            catch (Exception)
            {

                throw;
            }
            

        }

        public async Task<List<Product>> GetProducts()
        {
            var list = new List<Product>();
            try
            {
                //for (int i = 0; i < 5; i++)
                //{
                //    list.Add(new Product
                //    {
                //        ProductId = i,
                //        ProductName = "Name " + i,
                //        Price = 100 * i
                //    });
                //}
                return _Context.Product.ToList();
            }
            catch (Exception)
            {

                throw;
            }
            return list;
        }

        public async Task<ReturnData> Product_Delete(ProductDeleteRequestData requestData)
        {
            var returnData = new ReturnData();
            try
            {
                if(requestData == null && requestData.Id == 0)
                {
                    returnData.ReturnCode = -1;
                    returnData.ReturnMsg = "Dữ liệu đầu vào ko hợp lệ";
                    return returnData;
                }
                var product = _Context.Product.Where(s =>s.ProductId == requestData.Id).FirstOrDefault();
                if(product == null || product.ProductId<= 0)
                {
                    returnData.ReturnCode = -2;
                    returnData.ReturnMsg = "Không tồn tại sản phẩm";
                    return returnData;
                }

                _Context.Product.Remove(product);
                var result = _Context.SaveChanges();

                if(result < 0)
                {
                    returnData.ReturnCode = -3;
                    returnData.ReturnMsg = "Xóa sản phẩm thất bại";
                    return returnData;
                }

                returnData.ReturnCode = 1;
                returnData.ReturnMsg = "Xóa sản phẩm thành công";
                return returnData;

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<ReturnData> Product_InsertUpdate(Product product)
        {
            var returnData = new ReturnData();
            try
            {
                if(product.ProductId <= 0)
                {
                    _Context.Product.Add(product);
                    _Context.SaveChanges();
                    returnData.ReturnCode = 1;
                    returnData.ReturnMsg = "Thêm sản phẩm thành công";
                    return returnData;
                }
                else
                {
                    _Context.Product.Update(product);
                    _Context.SaveChanges();
                    returnData.ReturnCode = 1;
                    returnData.ReturnMsg = "Sửa sản phẩm thành công";
                    return returnData;
                }
                
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
