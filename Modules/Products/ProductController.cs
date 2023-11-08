using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiStore.Modules.Products
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
       private readonly IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        async public Task<IActionResult> GetAll() {
            var products = await _productRepository.GetAll();
            return Ok(new
            {
                message = "All products",
                data = products
            });    

        }




    }
}
