using CQRSTesting.Application.DTOs;
using CQRSTesting.Application.Products.Commands;
//using CQRSTesting.Application.Products.Commands;
using CQRSTesting.Application.Products.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRSTesting.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {

        //private IMediator _mediator;

        //public ProductController(IMediator mediator)
        //{
        //    _mediator = mediator;
        //}

        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();


        [HttpGet]
        public async Task<ActionResult<List<ProductDTO>>> GetAllProducts()
        {
            //mediator lo que hace en este punto es buscar el handler que corresponde a la petición 
            var products = await Mediator.Send(new GetAllProductsQuery.GetAllProductsQueryRequest());
            //var products = await _mediator.Send(new GetAllProductsQuery.GetAllProductsQueryRequest());
            return products;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> GetProductById(Guid id)
        {
            //mediator lo que hace en este punto es buscar el handler que corresponde a la petición 
            var product = await Mediator.Send(new GetProductByIdQuery.GetProductByIdQueryRequest { ProductId = id });
            return product;
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Post(CreateProductCommand.CreateProductCommandRequest request)
        {
            //mediator lo que hace en este punto es buscar el handler que corresponde a la petición 
            var result = await Mediator.Send(request);
            return result;
        }

    }
}
