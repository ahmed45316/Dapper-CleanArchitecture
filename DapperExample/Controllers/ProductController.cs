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
        public async Task<List<Product>> GetProducts()
        {
            var query = new GetAllProductsQuery();
            List<Product> getSignatureResult = await _mediator.Send(query);
            return getSignatureResult;
        }
    }
}
