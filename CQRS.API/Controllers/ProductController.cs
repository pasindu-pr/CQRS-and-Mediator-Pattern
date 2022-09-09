using CQRS.Application.Commands;
using CQRS.Application.Queries;
using CQRS.Data.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CQRS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediatr;

        public ProductController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }
        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
           List<Product> products = await _mediatr.Send(new GetProductListQuery());
           return Ok(products);
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            Product product =  await _mediatr.Send(new GetProductByIdQuery { Id = id });
            return Ok(product);
        }

        // POST api/<ValuesController>
        [HttpPost]
        public async Task<IActionResult>  CreateProduct([FromBody] Product product)
        {
            await _mediatr.Send(new CreateProductCommand { Product = product });
            return Ok(product);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] Product product)
        {
            Product updatedProduct =  await _mediatr.Send(new EditProductCommand { ProductId = id, Product = product });
            return Ok(updatedProduct);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            bool isDeleted = await _mediatr.Send(new DeleteProductCommand { productId = id });
            return Ok();
        }
    }
}
