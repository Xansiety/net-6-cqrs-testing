//using AutoMapper;
//using CQRSTesting.Application.DTOs;
//using CQRSTesting.Domain.Entities;
//using CQRSTesting.Persistence.Context;
//using MediatR;
//using Microsoft.EntityFrameworkCore;

//namespace CQRSTesting.Application.Products.Queries
//{
//    public class GetProductByIdQuery
//    {
//        // esta clase representa los parámetros que se le pasan al handler
//        public class GetProductByIdQueryRequest : IRequest<ProductDTO> {
//            public Guid ProductId { get; set; }
//        }

//        // handler es la que se encarga de ejecutar la lógica de negocio <entrada, salida>
//        public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQueryRequest, ProductDTO>
//        {
//            private readonly ApplicationDbContext _context;
//            public readonly IMapper _mapper;

//            public GetProductByIdQueryHandler(ApplicationDbContext context, Mapper mapper)
//            {
//                _context = context;
//                _mapper = mapper;
//            }

//            public async Task<ProductDTO> Handle(GetProductByIdQueryRequest request, CancellationToken cancellationToken)
//            {
//                // aquí se ejecuta la lógica de negocio
//                var product = await _context.Products.FirstOrDefaultAsync(x => x.ProductId == request.ProductId); 
//                var productDTO = _mapper.Map<Product, ProductDTO>(product);
//                return productDTO;
//            }
//        }
//    }
//}
