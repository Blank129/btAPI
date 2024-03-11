using DataAccess.EShop.IServices;
using DataAccess.EShop2.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductService _productService;
        public ProductController(IProductService productService) 
        { 
            _productService = productService;
       
        }
        [HttpGet("Product_Getlist")]
        public async Task<ActionResult> Product_Getlist()
        {
            var list = new List<Product>();
            list = await _productService.GetProducts();
            return Ok(list);
        }
        [HttpPost("Product_Delete")]
        public async Task<ActionResult> Product_Delete(ProductDeleteRequestData requestData)
        {
            var returnData = new ReturnData();
            returnData = await _productService.Product_Delete(requestData);
            return Ok(returnData);
        }
        [HttpPost("Product_InsertUpdate")]
        public async Task<ActionResult> Product_InsertUpdate(Product product)
        {
            var returnData = new ReturnData();
            returnData = await _productService.Product_InsertUpdate(product);
            return Ok(returnData);
        }
        [HttpPost("GetProductById")]
        public async Task<ActionResult> GetProductById(GetProductByIdRequestData requestData)
        {
            var product = new Product();
            product = await _productService.GetProductById(requestData);
            return Ok(product);
        }
    }
}
