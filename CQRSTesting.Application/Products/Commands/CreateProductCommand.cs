using CQRSTesting.Domain.Entities;
using CQRSTesting.Persistence.Context;
using FluentValidation;
using MediatR;

namespace CQRSTesting.Application.Products.Commands
{
    public class CreateProductCommand
    {
        public class CreateProductCommandRequest : IRequest
        {
            public string Name { get; set; } = string.Empty;
            public string Description { get; set; } = string.Empty;
            public decimal UnitPrice { get; set; } = 0.00M;
            public DateTime DatePublished { get; set; }
        }

        public class CreateProductCommandRequestValidation : AbstractValidator<CreateProductCommandRequest>
        {
            public CreateProductCommandRequestValidation()
            {
                RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required")
                    .MaximumLength(50).WithMessage("Name cannot be longer than 50 characters");

                RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required")
                    .MaximumLength(250).WithMessage("Description cannot be longer than 250 characters");
            }
        }

        public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest>
        {
            private readonly ApplicationDbContext _context;
            public CreateProductCommandHandler(ApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
            {
                // aquí se ejecuta la lógica de negocio
                var product = new Product
                {
                    ProductId = Guid.NewGuid(),
                    Name = request.Name,
                    Description = request.Description,
                    UnitPrice = request.UnitPrice,
                    DatePublished = request.DatePublished,
                    DateCreated = DateTime.Now
                };

                _context.Products.Add(product);
                var valor = await _context.SaveChangesAsync();

                if (valor > 0) return Unit.Value; // si se guardó en la base de datos

                throw new Exception("No se pudo insertar el producto");
            }
        }

    }
}
