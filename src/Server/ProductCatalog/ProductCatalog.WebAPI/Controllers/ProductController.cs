using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductCatalog.Application.DTOs;
using ProductCatalog.Application.Interfaces;

namespace ProductCatalog.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService ?? throw new ArgumentNullException(nameof(productService));
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var products = await _productService.GetProducts();

            if (products == null || !products.Any())
                return NotFound("Products Not Found");

            return Ok(products);
        }

        [HttpGet]
        [Route("{id:int}", Name = "GetProduct")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productService.GetById(id);

            if (product == null)
                return NotFound("Product Not Found");

            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProductDTO product)
        {
            if (product == null)
                return BadRequest("Invalid Product");

            await _productService.Add(product);
            return new CreatedAtRouteResult("GetProduct", new { id = product.Id }, product);
        }

        [HttpPut]
        public async Task<IActionResult> Update(int id, [FromBody] ProductDTO product)
        {

            if (product == null)
                return NotFound("Product Not Found");

            if (id != product.Id)
                return NotFound("Product Not Found");

            await _productService.Update(product);

            return Ok(product);
        }


        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteById(int id)
        {
            var product = await _productService.GetById(id);
            if (product == null)
                return NotFound("Product Not Found");

            await _productService.Remove(id);
            return Ok(product);
        }
    }
}
