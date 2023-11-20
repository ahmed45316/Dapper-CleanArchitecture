using DapperExample.Application.Queries;
using DapperExample.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DapperExample.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var query = new GetAllProductsQuery();
            List<Product> result = await _mediator.Send(query);
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProducts(int id)
        {
            var query = new GetAllProductsQuery(id);
            List<Product> result = await _mediator.Send(query);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> AddProduct(Product product)
        {
            var command = new ProductCommand("INSERT", product);
            int id = await _mediator.Send(command);
            return Ok(id);
        }
        [HttpPut]
        public async Task<IActionResult> EditProduct(Product product)
        {
            var command = new ProductCommand("UPDATE", product);
            int id = await _mediator.Send(command);
            return Ok(id);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var command = new ProductCommand("DELETE", new Product { Id = id });
            await _mediator.Send(command);
            return Ok();
        }
    }
}
