using CQRSTesting.Domain.Entities;
using CQRSTesting.Persistence.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRSTesting.Application.Products
{
    public class GetAllProductsQuery
    {
        // esta clase representa los parámetros que se le pasan al handler
        public class GetCursoQueryRequest : IRequest<List<Product>> { }

        // handler es la que se encarga de ejecutar la lógica de negocio <entrada, salida>
        public class GetCursoQueryHandler : IRequestHandler<GetCursoQueryRequest, List<Product>>
        {

            private readonly ApplicationDbContext _context;

            public GetCursoQueryHandler(ApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<List<Product>> Handle(GetCursoQueryRequest request, CancellationToken cancellationToken)
            {
                // aquí se ejecuta la lógica de negocio
                var products = await _context.Products.ToListAsync();
                return products;
            }
        }

    }
}
