using DapperExample.Application.Services;
using DapperExample.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace DapperExample.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class Product2Controller : ControllerBase
    {
        private readonly IProductService _service;

        public Product2Controller(IProductService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var result = await _service.GetAll();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var result = await _service.GetById(id);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> AddProduct(Product product)
        {
            int id = await _service.Add(product);
            return Ok(id);
        }
        [HttpPut]
        public async Task<IActionResult> EditProduct(Product product)
        {
            int id = await _service.Edit(product);
            return Ok(id);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _service.Delete(id);
            return Ok();
        }
    }
}
