using AutoMapper;
using CQRSTesting.Application.DTOs;
using CQRSTesting.Domain.Entities;
using CQRSTesting.Persistence.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRSTesting.Application.Products.Queries
{
    public class GetAllProductsQuery
    {
        // Esta clase representa los parámetros que se le pasan al handler
        public class GetAllProductsQueryRequest : IRequest<List<ProductDTO>> { }

        // El handler es el encargado de ejecutar la lógica de negocio <entrada, salida>
        public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQueryRequest, List<ProductDTO>>
        {
            private readonly ApplicationDbContext _context;
            private readonly IMapper _mapper;

            public GetAllProductsQueryHandler(ApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<ProductDTO>> Handle(GetAllProductsQueryRequest request, CancellationToken cancellationToken)
            {
                // Aquí se ejecuta la lógica de negocio
                var products = await _context.Products.ToListAsync();
                var productsDTO = _mapper.Map<List<Product>, List<ProductDTO>>(products);
                return productsDTO;
            }
        }
    }
}
